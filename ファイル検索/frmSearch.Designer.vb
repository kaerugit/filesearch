<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.lstFileList = New System.Windows.Forms.ListBox()
        Me.cmdFileAdd = New System.Windows.Forms.Button()
        Me.cmdSelectFolder = New System.Windows.Forms.Button()
        Me.txtSonotaFolder = New System.Windows.Forms.TextBox()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearchFile = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.txtOpenEditor_From = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtOpenFolder_From = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtFileNameCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtFileCopy_From = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemSelectWinMerge = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lvSearchResult = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tip検索備考 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdDelete)
        Me.Panel1.Controls.Add(Me.lstFileList)
        Me.Panel1.Controls.Add(Me.cmdFileAdd)
        Me.Panel1.Controls.Add(Me.cmdSelectFolder)
        Me.Panel1.Controls.Add(Me.txtSonotaFolder)
        Me.Panel1.Controls.Add(Me.lblFolder)
        Me.Panel1.Controls.Add(Me.cmdSearch)
        Me.Panel1.Controls.Add(Me.lblSearch)
        Me.Panel1.Controls.Add(Me.txtSearchFile)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(837, 155)
        Me.Panel1.TabIndex = 18
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(203, 84)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(57, 23)
        Me.cmdDelete.TabIndex = 29
        Me.cmdDelete.Text = "削除"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'lstFileList
        '
        Me.lstFileList.ItemHeight = 12
        Me.lstFileList.Location = New System.Drawing.Point(266, 31)
        Me.lstFileList.Name = "lstFileList"
        Me.lstFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileList.Size = New System.Drawing.Size(544, 76)
        Me.lstFileList.TabIndex = 28
        '
        'cmdFileAdd
        '
        Me.cmdFileAdd.Location = New System.Drawing.Point(95, 31)
        Me.cmdFileAdd.Name = "cmdFileAdd"
        Me.cmdFileAdd.Size = New System.Drawing.Size(165, 23)
        Me.cmdFileAdd.TabIndex = 27
        Me.cmdFileAdd.Text = "複数フォルダの場合は追加"
        Me.cmdFileAdd.UseVisualStyleBackColor = True
        '
        'cmdSelectFolder
        '
        Me.cmdSelectFolder.Location = New System.Drawing.Point(770, 4)
        Me.cmdSelectFolder.Name = "cmdSelectFolder"
        Me.cmdSelectFolder.Size = New System.Drawing.Size(40, 23)
        Me.cmdSelectFolder.TabIndex = 26
        Me.cmdSelectFolder.Text = "・・・"
        Me.cmdSelectFolder.UseVisualStyleBackColor = True
        '
        'txtSonotaFolder
        '
        Me.txtSonotaFolder.Location = New System.Drawing.Point(95, 6)
        Me.txtSonotaFolder.Name = "txtSonotaFolder"
        Me.txtSonotaFolder.Size = New System.Drawing.Size(669, 19)
        Me.txtSonotaFolder.TabIndex = 25
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.Location = New System.Drawing.Point(25, 9)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(64, 12)
        Me.lblFolder.TabIndex = 24
        Me.lblFolder.Text = "検索フォルダ"
        Me.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(735, 113)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 20
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(20, 120)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(69, 12)
        Me.lblSearch.TabIndex = 19
        Me.lblSearch.Text = "検索用ワード"
        Me.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearchFile
        '
        Me.txtSearchFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtSearchFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtSearchFile.Location = New System.Drawing.Point(95, 117)
        Me.txtSearchFile.Name = "txtSearchFile"
        Me.txtSearchFile.Size = New System.Drawing.Size(634, 19)
        Me.txtSearchFile.TabIndex = 18
        Me.tip検索備考.SetToolTip(Me.txtSearchFile, "■スペース区切りでAnd検索" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "例：""aa bb"" ⇒aa かつ bb" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "■括弧内はor検索" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "例：""(aa bb)  cc ""⇒(aa 又は bb) かつ cc" &
        "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "■先頭マイナスでnot検索" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-aa -bb ⇒ aa以外　かつ bb以外" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "※一度検索すると結果をキャッシュしますので、新規追加のファイルが結果から漏" &
        "れる可能性があります。")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtOpenEditor_From, Me.txtOpenFolder_From, Me.txtFileNameCopy, Me.txtFileCopy_From, Me.itemSelectWinMerge})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(296, 114)
        '
        'txtOpenEditor_From
        '
        Me.txtOpenEditor_From.Name = "txtOpenEditor_From"
        Me.txtOpenEditor_From.Size = New System.Drawing.Size(295, 22)
        Me.txtOpenEditor_From.Text = "テキストエディタで開く"
        '
        'txtOpenFolder_From
        '
        Me.txtOpenFolder_From.Name = "txtOpenFolder_From"
        Me.txtOpenFolder_From.Size = New System.Drawing.Size(295, 22)
        Me.txtOpenFolder_From.Text = "フォルダを開く"
        '
        'txtFileNameCopy
        '
        Me.txtFileNameCopy.Name = "txtFileNameCopy"
        Me.txtFileNameCopy.Size = New System.Drawing.Size(295, 22)
        Me.txtFileNameCopy.Text = "ファイル名をクリップボードにコピー"
        '
        'txtFileCopy_From
        '
        Me.txtFileCopy_From.Name = "txtFileCopy_From"
        Me.txtFileCopy_From.Size = New System.Drawing.Size(295, 22)
        Me.txtFileCopy_From.Text = "ファイル名をクリップボードにコピー(フルファイル名)"
        '
        'itemSelectWinMerge
        '
        Me.itemSelectWinMerge.Name = "itemSelectWinMerge"
        Me.itemSelectWinMerge.Size = New System.Drawing.Size(295, 22)
        Me.itemSelectWinMerge.Text = "選択した2つのファイルをWinMergeしてみる"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 492)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(837, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 460)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(837, 32)
        Me.Panel3.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(531, 12)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "※検索結果欄を選択して右クリックで色々出てきます。又、他アプリ(WinMerge等)にドラッグアンドドロップも可能。"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lvSearchResult)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(837, 305)
        Me.Panel2.TabIndex = 22
        '
        'lvSearchResult
        '
        Me.lvSearchResult.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader1})
        Me.lvSearchResult.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSearchResult.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lvSearchResult.FullRowSelect = True
        Me.lvSearchResult.GridLines = True
        Me.lvSearchResult.HideSelection = False
        Me.lvSearchResult.Location = New System.Drawing.Point(0, 0)
        Me.lvSearchResult.Name = "lvSearchResult"
        Me.lvSearchResult.Size = New System.Drawing.Size(837, 305)
        Me.lvSearchResult.TabIndex = 3
        Me.lvSearchResult.UseCompatibleStateImageBehavior = False
        Me.lvSearchResult.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "ファイル名"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ファイル名"
        Me.ColumnHeader1.Width = 700
        '
        'frmSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 514)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSearch"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearchFile As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lvSearchResult As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSonotaFolder As System.Windows.Forms.TextBox
    Friend WithEvents lblFolder As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdSelectFolder As System.Windows.Forms.Button
    Friend WithEvents itemSelectWinMerge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOpenEditor_From As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOpenFolder_From As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFileCopy_From As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdFileAdd As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents lstFileList As System.Windows.Forms.ListBox
    Friend WithEvents tip検索備考 As System.Windows.Forms.ToolTip
    Friend WithEvents txtFileNameCopy As System.Windows.Forms.ToolStripMenuItem
End Class
