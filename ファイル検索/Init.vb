Public Class Init

    'COPYDATASTRUCT構造体
    Public Structure COPYDATASTRUCT
        Public dwData As Int32   '送信するビット値
        Public cbData As Int32        'lpDataのバイト数
        Public lpData As String     '送信するデータへのポインタ(0も可能)
    End Structure

    Public Const WM_COPYDATA As Int32 = &H4A
    Public Const WM_USER As Int32 = &H400

    <Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)> _
    Public Shared Function FindWindow( _
         ByVal lpClassName As String, _
         ByVal lpWindowName As String) As IntPtr
    End Function


    <Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)> _
    Public Shared Function SendMessage( _
                            ByVal hWnd As IntPtr, _
                            ByVal wMsg As Int32, _
                            ByVal wParam As Int32, _
                            ByRef lParam As COPYDATASTRUCT) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function


    '<System.Runtime.InteropServices.DllImport("user32.dll")> _
    'Shared Function GetActiveWindow() As IntPtr
    'End Function


    '<System.Runtime.InteropServices.DllImport("user32.dll")> _
    'Shared Function GetForegroundWindow() As IntPtr
    'End Function

    '<System.Runtime.InteropServices.DllImport("user32.dll")> _
    'Shared Function GetWindowTextW(ByVal hwd As Long, ByVal buf As String, ByVal bln As Long) As Long
    'End Function


    Private Shared _mutex As System.Threading.Mutex

    'Public Const KUGIRIMOJI As String = "[" & vbTab & "]"

    <STAThread()> _
    Public Shared Sub Main()

        Dim strMessage As String = ""
        '引数一番目　検索文字列、　引数二番目　アプリケーションタイトル
        For Each cmd As String In My.Application.CommandLineArgs
            'strMessage &= KUGIRIMOJI & cmd
            'Exit For
            strMessage = cmd
            Exit For
        Next
        'If strMessage.Length > 0 Then
        'strMessage = strMessage.Substring(KUGIRIMOJI.Length)
        'End If

        _mutex = New System.Threading.Mutex(False, Common.APP_TITLE_AND_VEARSION)
        'ミューテックスの所有権を要求する
        If _mutex.WaitOne(0, False) = False Then
            'すでに起動していると判断して終了
            'MessageBox.Show("多重起動はできません。")

            Return

        End If

        Dim frm = New frmSearch

        Application.Run(frm)


    End Sub

End Class
