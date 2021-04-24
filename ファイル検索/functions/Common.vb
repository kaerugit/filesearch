Public Class Common

    Public Const APP_TITLE_AND_VEARSION As String = "ファイル検索 Ver 1.00"


    ''' <summary>
    ''' フォルダ内のファイルを取得
    ''' </summary>
    ''' <param name="strFolder">フォルダ名</param>
    ''' <remarks></remarks>
    Public Shared Function GetFiles(ByVal strFolder As String) As List(Of String)
        Dim lstMotoFile As New List(Of String)

        If System.IO.Directory.Exists(strFolder) = False Then
            Return lstMotoFile
        End If


        For Each strEachFileName As String In System.IO.Directory.GetFiles(strFolder)
            lstMotoFile.Add(strEachFileName)
        Next

        Return lstMotoFile
    End Function


    ''' <summary>
    ''' WinMargeの実行
    ''' </summary>
    ''' <param name="strMotoFile">変換前ファイル</param>
    ''' <param name="strSakiFile">変換後ファイル</param>
    ''' <remarks></remarks>
    Public Shared Sub OpenWinMerge(ByVal strWinMergePass As String, ByVal strMotoFile As String, ByVal strSakiFile As String)

        If strWinMergePass.Length = 0 Then '手抜き
            MsgBox("WinMergeの実行ファイルが設定されていません。")
            'Me.txtWinMergePass.Focus()
            Return
        End If

        'DBにはドライブ名が落ちていないので付与する
        Dim strDrive As String = ""
        'If strMotoFile.StartsWith(":\") Then
        '    strDrive = Common.GetDrive(strMotoFile)
        'End If

        Dim strWinMergeMotoFile As String = strDrive & strMotoFile
        Dim strWinMergeSakiFile As String = strDrive & strSakiFile

        'If strWinMergeMotoFile.Length = 0 OrElse strWinMergeSakiFile.Length = 0 Then
        'Return
        'End If

        Try
            Process.Start(strWinMergePass, "-e -x -ub -dl """ & strWinMergeMotoFile & """ -dr """ & strWinMergeSakiFile & """ """ & strWinMergeMotoFile & """ """ & strWinMergeSakiFile & """")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

End Class
