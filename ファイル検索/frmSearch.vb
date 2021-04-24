Public Class frmSearch

    Private strWinMergePath As String = ""

    ''' <summary>
    ''' WinMergePathのパス
    ''' </summary>
    Public ReadOnly Property WinMergePath() As String
        Get
            If strWinMergePath.Length = 0 Then
                'WinMergeのexeの取得
                Dim regkey As Microsoft.Win32.RegistryKey = _
                    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Thingamahoochie\WinMerge", False)

                If (regkey IsNot Nothing) Then
                    strWinMergePath = CType(regkey.GetValue("Executable"), String)
                    regkey.Close()
                End If
            End If

            Return strWinMergePath
        End Get
    End Property


    <System.Runtime.InteropServices.DllImport("shell32.dll")> _
    Public Shared Function FindExecutable(ByVal lpFile As String, _
        ByVal lpDirectory As String, _
        ByVal lpResult As System.Text.StringBuilder) As Integer

    End Function

    Dim mstrLastSerch As String
    Dim lstCashFile As New List(Of String)


    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Common.APP_TITLE_AND_VEARSION

        For Each strLastSearch As String In My.Settings.LastSearch.Split(Char.Parse(vbTab))
            If strLastSearch.Length > 0 Then
                Me.lstFileList.Items.Add(strLastSearch)
            End If

        Next

    End Sub

    Private Sub frmSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim strSearchFolder As String = ""
        For Each objFolderOrFile As Object In Me.lstFileList.Items
            strSearchFolder &= vbTab & objFolderOrFile.ToString
        Next

        My.Settings.LastSearch = strSearchFolder

        My.Settings.Save()
    End Sub


    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

        If Me.txtSearchFile.Text.Length = 0 Then
            MsgBox(Me.lblSearch.Text & "が入力されていません。")
            Return
        End If

        If Not String.IsNullOrEmpty(Me.txtSearchFile.Text) _
             AndAlso Not Me.txtSearchFile.AutoCompleteCustomSource.Contains(Me.txtSearchFile.Text) Then

            Me.txtSearchFile.AutoCompleteCustomSource.Add(Me.txtSearchFile.Text)

        End If

        'Me.txtSearchFile.AutoCompleteCustomSource = 

        '同じフォルダの場合はファイルを取得しない
        Dim strCashCheckString As String = "" 'Me.cboDrive.Text & Me.chkSougouhansha.Checked.ToString & Me.txtSonotaFolder.Text

        'ファイルの参照
        Dim lstSearchFolder As New List(Of String)
        If Me.lstFileList.Items.Count = 0 Then
            If Me.txtSonotaFolder.Text.Length = 0 Then
                MsgBox(Me.lblFolder.Text & "が入力されていません。")
                Me.txtSonotaFolder.Focus()
                Return
            End If
            lstSearchFolder.Add(Me.txtSonotaFolder.Text)
        Else
            For Each objFolderOrFile As Object In Me.lstFileList.Items
                lstSearchFolder.Add(objFolderOrFile.ToString)
            Next
        End If

        For Each strEachFolder As String In lstSearchFolder
            strCashCheckString &= vbTab & strEachFolder
        Next

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.cmdSearch.Enabled = False
            If mstrLastSerch = strCashCheckString Then     'キャッシュを使用
            Else
                'ファイルを取得
                lstCashFile = New List(Of String)

                Dim lstFolder As New List(Of String)

                Dim objLock As New Object

                '該当フォルダの取得
                Threading.Tasks.Parallel.ForEach(lstSearchFolder,
                        Sub(strEachFolder)
                            '4.0からは EnumerateDirectories(対象ディレクトリ) 
                            'Common.GetFiles(strEachFolder, lstCashFile, lstSearchManage)

                            If System.IO.Directory.Exists(strEachFolder) = True Then

                                '4.0から EnumerateDirectories(対象ディレクトリ) 
                                Dim folders As IEnumerable(Of String) = System.IO.Directory.EnumerateDirectories(
                                    strEachFolder,
                                    "*",
                                    System.IO.SearchOption.AllDirectories) _
                                    .Where(
                                            Function(strFolder)
                                                If strFolder.Contains(".svn") = False OrElse
                                                   strFolder.Contains(".git") = False OrElse
                                                   strFolder.Contains(".vscode") = False Then

                                                    Return True

                                                End If
                                                Return False
                                            End Function
                                    )

                                SyncLock objLock
                                    Dim blnError As Boolean = False
                                    Try
                                        lstFolder.AddRange(folders) '権限などで追加できない場合は無視
                                    Catch ex As Exception
                                        blnError = True
                                    End Try

                                    If blnError = False Then
                                        lstFolder.Add(strEachFolder)
                                    End If
                                End SyncLock

                            End If

                        End Sub
                    )



                lstFolder = lstFolder.Distinct().ToList

                'フォルダ内のファイルを取得
                Threading.Tasks.Parallel.ForEach(lstFolder,
                        Sub(strEachFolder)
                            Dim lst As List(Of String)
                            lst = Nothing

                            Try
                                lst = Common.GetFiles(strEachFolder)
                            Catch ex As Exception
                            End Try

                            If lst IsNot Nothing Then
                                SyncLock objLock        'Lockしないとnothingのデータが出来てしまうため
                                    lstCashFile.AddRange(lst)
                                End SyncLock
                            End If


                        End Sub
                    )

            End If

            mstrLastSerch = strCashCheckString

            Dim lstSearchWord_AND As New List(Of String)
            Dim lstSearchWord_OR As New List(Of String)


            Dim strSearchWord As String = Me.txtSearchFile.Text.Replace("　", " ")

            'orの文字列を取得
            Dim reg As New System.Text.RegularExpressions.Regex("\(.+?\)")

            For Each strMatch As System.Text.RegularExpressions.Match In reg.Matches(strSearchWord)

                Dim strMatchValue As String = strMatch.Value

                '括弧内を置換
                strSearchWord = strSearchWord.Replace(strMatchValue, "")


                strMatchValue = strMatchValue.Replace("(", "")
                strMatchValue = strMatchValue.Replace(")", "")

                For Each strEachSearchWord As String In strMatchValue.Split(" "c)
                    If strEachSearchWord.Trim.Length = 0 Then
                    Else
                        lstSearchWord_OR.Add(strEachSearchWord)
                    End If
                Next

            Next

            For Each strEachSearchWord As String In strSearchWord.Split(" "c)
                If strEachSearchWord.Trim.Length = 0 Then
                Else
                    lstSearchWord_AND.Add(strEachSearchWord)
                End If
            Next


            Dim result =
                (
                    lstCashFile.Where(
                        Function(strEachFile)

                            Dim blnFind As Boolean = True

                            If lstSearchWord_OR.Count > 0 Then
                                blnFind = False

                                'or 検索
                                For Each strEachSearchWord As String In lstSearchWord_OR
                                    Dim blnHantei As Boolean = True
                                    If strEachSearchWord.Length > 1 AndAlso strEachSearchWord.StartsWith("-") Then           'not 判定とする
                                        strEachSearchWord = strEachSearchWord.Substring(2)
                                        blnHantei = Not blnHantei
                                    End If

                                    If strEachFile.ToUpper.Contains(strEachSearchWord.ToUpper) = blnHantei Then
                                        blnFind = True
                                        Exit For
                                    End If
                                Next

                                If blnFind = False Then
                                    Return False
                                End If
                            End If

                            If blnFind = True Then
                                'and 検索
                                For Each strEachSearchWord As String In lstSearchWord_AND
                                    Dim blnHantei As Boolean = False
                                    If strEachSearchWord.Length > 1 AndAlso strEachSearchWord.StartsWith("-") Then           'not 判定とする
                                        strEachSearchWord = strEachSearchWord.Substring(2)
                                        blnHantei = Not blnHantei
                                    End If

                                    If strEachFile.ToUpper.Contains(strEachSearchWord.ToUpper) = blnHantei Then
                                        Return False
                                    End If
                                Next
                            End If

                            Return True

                        End Function
                    ) _
                    .OrderBy(
                        Function(strOrderBy)
                            Return strOrderBy
                        End Function
                    ) _
                    .Select(
                        Function(strEachFile)
                            Dim lstAdd As New List(Of String)

                            lstAdd.Add(strEachFile)

                            Dim strShouryakuFile As String = strEachFile
                            For Each strEachShouryakuFolder As String In lstSearchFolder
                                Dim lastfolder = strEachShouryakuFolder.Split(Char.Parse("\")).Where(Function(w) w.Length > 0).Last()

                                If strShouryakuFile.Contains(strEachShouryakuFolder) Then
                                    strShouryakuFile = "(" + lastfolder + ")" + strShouryakuFile.Substring(strShouryakuFile.IndexOf(strEachShouryakuFolder) + strEachShouryakuFolder.Length)
                                End If
                            Next

                            lstAdd.Add(strShouryakuFile)
                            'Return lstAdd

                            'ファイル名、略名のList
                            Dim lstViewItem As New ListViewItem(CType(lstAdd.ToArray(), String()))
                            Return lstViewItem
                        End Function
                    )
                ).ToList()

            Me.lvSearchResult.BeginUpdate()
            Me.lvSearchResult.Items.Clear()
            Me.lvSearchResult.Items.AddRange(result.ToArray)
            Me.lvSearchResult.EndUpdate()

            'Catch ex As Exception
        Finally
            Me.cmdSearch.Enabled = True
            Me.Cursor = Cursors.Default
        End Try


        If Me.lvSearchResult.Items.Count = 0 Then
            Me.ToolStripStatusLabel.Text = "該当ファイルが見つかりません。"
            Me.txtSearchFile.Select()
        Else
            Me.ToolStripStatusLabel.Text = "検索結果 " & Me.lvSearchResult.Items.Count.ToString & "件　"
            Me.lvSearchResult.Select()
            Me.lvSearchResult.Items(0).Selected = True

        End If
    End Sub


    Private Sub itemSelectWinMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itemSelectWinMerge.Click
        Dim lstFileName As New List(Of String) From {"", ""}
        For i = 0 To Me.lvSearchResult.SelectedItems.Count - 1
            'lstFileName.Add(Me.lvSearchResult.SelectedItems.Item(i).SubItems(0).Text)
            lstFileName(i) = Me.lvSearchResult.SelectedItems.Item(i).SubItems(0).Text
            If i = 1 Then
                Exit For
            End If
        Next

        If lstFileName(0) = "" Then
            MsgBox("ファイル選択されていません。")
            Return
        End If
        Common.OpenWinMerge(Me.WinMergePath, lstFileName(0), lstFileName(1))
    End Sub

    ''' <summary>
    ''' エディタで開く(メニュー)
    ''' </summary>
    Private Sub txtOpenEditor_From_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOpenEditor_From.Click
        OpenEditor(GetFile())
    End Sub


    ''' <summary>
    ''' フォルダを開く
    ''' </summary>
    Private Sub txtOpenFolder_From_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOpenFolder_From.Click
        Dim strFileName As String = GetFile()
        If strFileName.Length = 0 Then
            Return
        End If

        'strFileName = strFileName.Replace(System.IO.Path.GetFileName(strFileName), "")
        Try
            System.Diagnostics.Process.Start("EXPLORER.EXE", "/SELECT,""" & strFileName & """")
        Catch ex As Exception

        End Try


    End Sub



    ''' <summary>
    ''' クリップボードへコピー(フルファイル名)
    ''' </summary>
    Private Sub txtFileCopy_From_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileCopy_From.Click
        Dim strCopy As String = ""
        For i = 0 To Me.lvSearchResult.SelectedItems.Count - 1
            'すぐ下にここだけが違うコードあり
            strCopy &= vbCrLf & Me.lvSearchResult.SelectedItems.Item(i).SubItems(0).Text
        Next

        If strCopy.Replace(vbCrLf, "").Length > 0 Then
            strCopy = strCopy.Substring(vbCrLf.Length)
            Clipboard.SetText(strCopy)
        End If

    End Sub


    ''' <summary>
    ''' クリップボードへコピー(フルファイル名のみ(拡張子の属))
    ''' </summary>
    Private Sub txtFileNameCopy_Click(sender As System.Object, e As System.EventArgs) Handles txtFileNameCopy.Click
        Dim strCopy As String = ""
        For i = 0 To Me.lvSearchResult.SelectedItems.Count - 1
            'すぐ下にここだけが違うコードあり
            strCopy &= vbCrLf & System.IO.Path.GetFileNameWithoutExtension(Me.lvSearchResult.SelectedItems.Item(i).SubItems(0).Text)
        Next

        If strCopy.Replace(vbCrLf, "").Length > 0 Then
            strCopy = strCopy.Substring(vbCrLf.Length)
            Clipboard.SetText(strCopy)
        End If
    End Sub


    Function GetFile() As String
        Try
            Return Me.lvSearchResult.SelectedItems.Item(0).SubItems(0).Text
        Catch ex As Exception
            Return ""
        End Try

    End Function


    ''' <summary>
    ''' テキストエディタで開く
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <remarks></remarks>
    Sub OpenEditor(ByVal strFile As String)
        'Dim strTextExt As String = ""
        If strFile.Length = 0 Then
            Return
        End If

        'txtの実行パスを取得する
        Dim strTempName As String = System.IO.Path.GetTempFileName()
        Dim strTempNameText As String = strTempName & ".txt"

        'ダミーでファイル作成
        Dim Writer As New IO.StreamWriter(strTempNameText, False)
        Writer.WriteLine("")
        Writer.Close()

        '結果を受け取るためのStringBuilderオブジェクト
        Dim exePath As New System.Text.StringBuilder(255)

        If FindExecutable(strTempNameText, Nothing, exePath) > 32 Then
            System.Diagnostics.Process.Start(exePath.ToString, strFile)

        End If

        Call DeleteFile(strTempNameText)
        Call DeleteFile(strTempName)
    End Sub

    Private Sub txtSearchFile_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchFile.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdSearch.PerformClick()
        End If

    End Sub

    ''' <summary>
    ''' 結果のダブルクリックで変換元ファイルをエディタで開く
    ''' </summary>
    Private Sub lvSearchResult_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSearchResult.DoubleClick
        Call txtOpenEditor_From_Click(sender, e)
    End Sub



    Private Sub cmdSelectFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFolder.Click
        Dim fbd As New FolderBrowserDialog


        fbd.Description = "フォルダを指定してください。"
        'ルートフォルダを指定する
        'デフォルトでDesktop
        'fbd.RootFolder = Environment.SpecialFolder.Desktop
        If Me.txtSonotaFolder.Text.Length > 0 Then
            fbd.SelectedPath = Me.txtSonotaFolder.Text
        End If

        'ダイアログを表示する
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            '選択されたフォルダを表示する
            Me.txtSonotaFolder.Text = fbd.SelectedPath
        End If

    End Sub


    ''' <summary>
    ''' ファイル削除
    ''' </summary>
    ''' <param name="strDeleteFile"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteFile(ByVal strDeleteFile As String)
        '（削除するために）ファイル属性から読み取り専用を削除
        Try
            Dim fas As System.IO.FileAttributes = System.IO.File.GetAttributes(strDeleteFile)

            fas = fas And Not System.IO.FileAttributes.ReadOnly
            ' ファイル属性を設定
            System.IO.File.SetAttributes(strDeleteFile, fas)
        Catch
        End Try

        Try
            System.IO.File.Delete(strDeleteFile)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub lvSearchResult_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvSearchResult.ItemDrag
        If Me.lvSearchResult.SelectedItems.Count = 0 Then
            Return
        End If

        Dim lstPath As New List(Of String)
        For i As Integer = 0 To Me.lvSearchResult.SelectedItems.Count - 1
            lstPath.Add(Me.lvSearchResult.SelectedItems.Item(i).SubItems(0).Text())
        Next

        'ほかアプリにドラッグ＆ドロップ
        Dim dataObj As New DataObject(DataFormats.FileDrop, lstPath.ToArray)
        Dim effect As DragDropEffects = DragDropEffects.Copy 'Or DragDropEffects.Move
        Me.lvSearchResult.DoDragDrop(dataObj, effect)
    End Sub


    Private Sub cmdFileAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileAdd.Click

        Dim strFolder As String = Me.txtSonotaFolder.Text

        If strFolder.Length = 0 Then
            MsgBox("フォルダが入力されていません。")
            Me.txtSonotaFolder.Focus()
            Return 'True
        End If

        If strFolder.EndsWith("\") = False Then
            strFolder = strFolder & "\"
        End If

        '既に同じファイルがあるかどうか確認
        For Each strFolderOrFile As String In Me.lstFileList.Items
            If strFolder = strFolderOrFile Then

                MsgBox("既に同じフォルダが存在します。")
                Return
            End If
        Next

        'Dim strDrive As String = strFolder.Substring(0, 1)
        'If Me.cboDrive.Items.Contains(strDrive) = True Then
        '    Me.cboDrive.Text = strDrive
        'End If
        Me.lstFileList.Items.Add(strFolder)

        Me.txtSonotaFolder.Text = ""
        Me.txtSonotaFolder.Focus()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If Me.lstFileList.SelectedItems.Count = 0 Then
            MsgBox("削除するフォルダを選択してください。")
        End If

        Dim lstDelete As New List(Of Object)

        For Each objFolderOrFile As Object In Me.lstFileList.SelectedItems
            lstDelete.Add(objFolderOrFile)
        Next

        If lstDelete.Count > 0 Then
            For Each objFolderOrFile As Object In lstDelete
                Me.lstFileList.Items.Remove(objFolderOrFile)
            Next
        End If
    End Sub

    '選択したListViewItem
    Dim lvi As ListViewItem = Nothing
    '選択したListViewItemのインデックス
    Dim listSelectNo As Integer = 0

    Private Sub lvSearchResult_MouseDown(sender As Object, e As MouseEventArgs) Handles lvSearchResult.MouseDown
        Dim lv As ListView = DirectCast(sender, ListView)
        '選択しているListViewItemを取得
        lvi = lv.GetItemAt(e.X, e.Y)
        If lvi Is Nothing Then
            Return
        End If
        '選択しているListViewItemのインデックスを取得
        listSelectNo = lvi.Index
    End Sub

    Private Sub lvSearchResult_MouseUp(sender As Object, e As MouseEventArgs) Handles lvSearchResult.MouseUp
        Dim lvp As ListView = DirectCast(sender, ListView)
        '【移動先】の選択しているListViewItemを取得
        Dim plvi As ListViewItem = lvp.GetItemAt(e.X, e.Y)

        If plvi Is Nothing Then
            Return
        End If

        '【移動先】の選択しているListViewItemのインデックスを取得
        Dim lnsertNo As Integer = plvi.Index

        '移動元のデータを取得
        Dim tmpData As ListViewItem = lvi

        '移動元のデータを削除
        lvp.Items.Remove(lvi)

        '移動先にデータを追加
        lvp.Items.Insert(lnsertNo, tmpData)
    End Sub
End Class