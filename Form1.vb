Imports System.Web

Public Class Form1


    Dim bmp As Bitmap
    Dim WithEvents but As Button
    Dim OnlineTime As Date
    Dim Online As Boolean = False
    Dim LastCommand As String = "Empty"  '上一个命令

    '===========常数设定区============
    Const X_Start As Integer = 5 '横向裁剪范围起始值
    Const X_End As Integer = 31 '横向裁剪范围终止值
    Const Y_Start As Integer = 2 '纵向裁剪范围起始值
    Const Y_End As Integer = 10 '纵向裁剪范围终止值
    Const CharWeight As Integer = 6 '字符宽度
    Const GapBetweenChar As Integer = 1 '字符间隙
    Const ColorTh As Integer = 200 '颜色阈值
    Const URL_LoginPage1 As String = "http://192.168.3.11:7001/QDHWSingle/login.jsp"
    Const URL_LoginPage2 As String = "http://192.168.3.11:7001/QDHWSingle/loginqd.jsp"
    Const URL_SuccessPage1 As String = "http://192.168.3.11:7001/QDHWSingle/login.do"
    Const URL_SuccessPage2 As String = "http://192.168.3.11:7001/QDHWSingle/successqd.jsp"
    Const URL_FailPage As String = "http://192.168.3.11:7001/QDHWSingle/login.do"
    Const URL_LogoffPage As String = "http://192.168.3.11:7001/QDHWSingle/logoff.do"
    Const CopyRightString As String = "版权所有(C)青岛大学(C)COPYRIGHT QINGDAO UNIVERSITY"
    Const PageTitle As String = "青岛大学校园网Portal"
    Const SuccessString As String = "您已经登陆成功"

    Dim Data(4) As String
    Dim CharMode(10) As String

    Private Property Password()
        Get
            Dim Key1 As Microsoft.Win32.RegistryKey
            Key1 = My.Computer.Registry.CurrentUser   '返回当前用户键
            Dim Key2 As Microsoft.Win32.RegistryKey
            Key2 = Key1.OpenSubKey("QDU_Network_AutoLoginer", True)
            If Key2 Is Nothing Then
                Key2 = Key1.CreateSubKey("QDU_Network_AutoLoginer")  '如果键不存在就创建它
            End If
            '创建项，如果不存在就创建，如果存在则覆盖
            Dim sb As New System.Text.StringBuilder
            sb.AppendLine(Key2.GetValue("password"))
            Return sb.ToString
        End Get
        Set(ByVal value)
            Dim Key1 As Microsoft.Win32.RegistryKey
            Key1 = My.Computer.Registry.CurrentUser   '返回当前用户键
            Dim Key2 As Microsoft.Win32.RegistryKey
            Key2 = Key1.OpenSubKey("QDU_Network_AutoLoginer", True)
            If Key2 Is Nothing Then
                Key2 = Key1.CreateSubKey("QDU_Network_AutoLoginer")  '如果键不存在就创建它
            End If
            '创建项，如果不存在就创建，如果存在则覆盖
            Key2.SetValue("password", value)
        End Set
    End Property

    Private Property Username()
        Get
            Dim Key1 As Microsoft.Win32.RegistryKey
            Key1 = My.Computer.Registry.CurrentUser   '返回当前用户键
            Dim Key2 As Microsoft.Win32.RegistryKey
            Key2 = Key1.OpenSubKey("QDU_Network_AutoLoginer", True)
            If Key2 Is Nothing Then
                Key2 = Key1.CreateSubKey("QDU_Network_AutoLoginer")  '如果键不存在就创建它
            End If
            '创建项，如果不存在就创建，如果存在则覆盖
            Dim sb As New System.Text.StringBuilder
            sb.AppendLine(Key2.GetValue("username"))
            Return sb.ToString
        End Get
        Set(ByVal value)
            Dim Key1 As Microsoft.Win32.RegistryKey
            Key1 = My.Computer.Registry.CurrentUser   '返回当前用户键
            Dim Key2 As Microsoft.Win32.RegistryKey
            Key2 = Key1.OpenSubKey("QDU_Network_AutoLoginer", True)
            If Key2 Is Nothing Then
                Key2 = Key1.CreateSubKey("QDU_Network_AutoLoginer")  '如果键不存在就创建它
            End If
            '创建项，如果不存在就创建，如果存在则覆盖
            Key2.SetValue("username", value)
        End Set
    End Property

    Private Property AutoLogin()
        Get
            Dim Key1 As Microsoft.Win32.RegistryKey
            Key1 = My.Computer.Registry.CurrentUser   '返回当前用户键
            Dim Key2 As Microsoft.Win32.RegistryKey
            Key2 = Key1.OpenSubKey("QDU_Network_AutoLoginer", True)
            If Key2 Is Nothing Then
                Key2 = Key1.CreateSubKey("QDU_Network_AutoLoginer")  '如果键不存在就创建它
            End If
            '创建项，如果不存在就创建，如果存在则覆盖
            Dim sb As New System.Text.StringBuilder
            sb.AppendLine(Key2.GetValue("autologin"))
            Return sb.ToString
        End Get
        Set(ByVal value)
            Dim Key1 As Microsoft.Win32.RegistryKey
            Key1 = My.Computer.Registry.CurrentUser   '返回当前用户键
            Dim Key2 As Microsoft.Win32.RegistryKey
            Key2 = Key1.OpenSubKey("QDU_Network_AutoLoginer", True)
            If Key2 Is Nothing Then
                Key2 = Key1.CreateSubKey("QDU_Network_AutoLoginer")  '如果键不存在就创建它
            End If
            '创建项，如果不存在就创建，如果存在则覆盖
            Key2.SetValue("autologin", value)
        End Set
    End Property


    Private Function DelQuery(ByVal URL As String)
        Return URL.Split("?")(0)
    End Function

    Private Function IndityCheckCode(ByVal bmp As Drawing.Bitmap) As String
        '验证码识别部分
        Data(1) = "" : Data(2) = "" : Data(3) = "" : Data(4) = ""
        Dim TempChar = "0"
        Dim ReturnString As String = ""
        For y = Y_Start To Y_End
            For x = X_Start To X_End
                If (x - X_Start + 1) Mod (CharWeight + GapBetweenChar) <> 0 Then
                    If bmp.GetPixel(x, y).R > ColorTh Then
                        TempChar = "1"
                    Else
                        TempChar = "0"
                    End If
                    Data(CInt((x - X_Start + 4) / (CharWeight + GapBetweenChar))) += TempChar
                End If
            Next
        Next
        For i = 1 To 4
            For j = 0 To 9
                If Data(i) = CharMode(j) Then
                    ReturnString += j.ToString
                End If
            Next
        Next
        If ReturnString = "" Then
            ReturnString = "0000"
        End If
        Return ReturnString
    End Function

    Private Sub InitProg()
        '初始化字模数据
        CharMode(0) = "001100010010100001100001100001100001100001010010001100"
        CharMode(1) = "001100010100000100000100000100000100000100000100011111"
        CharMode(2) = "111100000010000010000010000100001000010000100000111110"
        CharMode(3) = "111100000010000010000100011000000100000010000010011100"
        CharMode(4) = "000010000110001010010010100010111111000010000010000010"
        CharMode(5) = "111110100000100000111000000100000010000010000100111000"
        CharMode(6) = "001111010000100000101100110010100001100001010010001100"
        CharMode(7) = "111111000001000010000100000100001000001000010000010000"
        CharMode(8) = "011110100001100001010010011110100001100001100001011110"
        CharMode(9) = "001100010010100001100001010011001101000001000010111100"

        LastCommand = "FormLoadCheck"
        WebBrowser1.Navigate(URL_SuccessPage2 + "?time=" + DateTime.Now.Ticks.ToString)

        UsernameTextbox.Text = Username
        PasswordTextbox.Text = Password
        If AutoLogin = "0" Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        NotifyIcon1.Visible = False
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Now.Date.Day <> 10 Then
        'MsgBox("内测版仅支持2012年12月10日使用")
        'End
        'End If

        InitProg()
    End Sub

    Private Sub WaitClient()
        If CheckBox1.Checked Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Logined()
        '登陆成功后要做的一些事情
        Online = True
        Button1.Enabled = True
        StateButton.Text = "当前状态：已登录"
        UsernameButton.Visible = True
        UsernameButton.Text = "当前账号：" + Username
        Button1.Text = "下线"
        LastCommand = "Logoff"
        OnlineTime = Now
        TimerOnline.Start()
        NotifyIcon1.ShowBalloonTip(1000, "登录成功", Username + "现在已登陆", ToolTipIcon.None)
    End Sub

    Private Sub FillFormOnLogin()
        Dim CtrlRange
        Dim CheckCodeImage As Drawing.Bitmap
        CtrlRange = WebBrowser1.Document.Body.DomElement.createControlRange()
        CtrlRange.add(WebBrowser1.Document.DomDocument.GetElementById("codeImg"))
        CtrlRange.execCommand("Copy")
        CheckCodeImage = Clipboard.GetData(DataFormats.Bitmap)
        WebBrowser1.Document.All("logName").SetAttribute("value", UsernameTextbox.Text)
        WebBrowser1.Document.All("logPW").SetAttribute("value", PasswordTextbox.Text)
        WebBrowser1.Document.All("validatecode").SetAttribute("value", IndityCheckCode(CheckCodeImage))
        Debug.Print("LogName=" + IndityCheckCode(CheckCodeImage))
        Clipboard.Clear()
        CtrlRange = Nothing
        CheckCodeImage = Nothing


    End Sub

    Private Sub Login(Optional ByVal Button As Boolean = False)
        If CheckBox1.Checked Or Button Then '如果开启自动登陆
            Button1.Enabled = False
            If Not (DelQuery(WebBrowser1.Url.ToString) = URL_LoginPage1 Or DelQuery(WebBrowser1.Url.ToString) = URL_LoginPage2 Or DelQuery(WebBrowser1.Url.ToString) = URL_LogoffPage) Then
                LastCommand = "ReNavigateLogin"
                WebBrowser1.Navigate(URL_LoginPage1 + "?time=" + DateTime.Now.Ticks.ToString)
            Else
                LastCommand = "RequestLogin"
                FillFormOnLogin()
                ClickOnLogin()
            End If
        End If
    End Sub

    Private Sub ClickOnLogin()
        Try
            WebBrowser1.Document.All("loginImg").InvokeMember("click")
        Catch
            MsgBox("不足5秒钟")
            Button1.Enabled = True
        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If DelQuery(e.Url.ToString) = "about:blank" Then
            Exit Sub '过滤初始空白页
        End If
        If DelQuery(e.Url.ToString) = URL_SuccessPage1 Then LastCommand = "RequestLogin"
        Debug.Print(Now.ToString + "    " + e.Url.ToString + "    " + LastCommand)
        Select Case LastCommand
            Case "Empty"  '未执行任何命令
                Exit Sub
            Case "FormLoadCheck"  '开软件校验
                If WebBrowser1.Document.Title = PageTitle Then '已接入校园网环境
                    Select Case DelQuery(e.Url.ToString)
                        Case URL_SuccessPage1, URL_SuccessPage2 '开软件时已经成功拨号
                            Logined()
                        Case URL_LoginPage1, URL_LoginPage2 '开软件后未登录
                            Login()
                    End Select
                Else
                    '等待xClient客户端接入校园网环境
                    WaitClient()
                End If
            Case "WaitClient"
                If WebBrowser1.Document.Title = PageTitle Then '如果已经进入校园网环境
                    Login()
                Else
                    Timer1.Start()  '重新启动定时器以进行下一次检测
                End If

            Case "RequestLogin"
                If ((DelQuery(WebBrowser1.Url.ToString) = URL_SuccessPage1 _
                    Or DelQuery(WebBrowser1.Url.ToString) = URL_SuccessPage2) _
                    And (InStr(WebBrowser1.Document.Body.InnerText, SuccessString) <> 0)) _
                Then  '登陆成功
                    Logined()
                Else '登陆失败()
                    Dim MsgboxResult As Microsoft.VisualBasic.MsgBoxResult
                    MsgboxResult = MsgBox(Replace(WebBrowser1.Document.Body.InnerText, CopyRightString, ""), MsgBoxStyle.RetryCancel, "登录失败")
                    If MsgboxResult = Microsoft.VisualBasic.MsgBoxResult.Retry Then
                        '用户要求重试
                        For Each abc As System.Windows.Forms.HtmlElement In WebBrowser1.Document.GetElementsByTagName("img")
                            abc.InvokeMember("click")
                        Next
                        LastCommand = "ReLogin"
                    Else
                        '用户选择取消
                        WebBrowser1.Navigate(URL_LoginPage1 + "?time=" + DateTime.Now.Ticks.ToString)
                        LastCommand = "Logoff"
                        Button1.Enabled = True
                    End If
                End If
            Case "Logined"
                If ((DelQuery(WebBrowser1.Url.ToString) = URL_SuccessPage1 _
                Or DelQuery(WebBrowser1.Url.ToString) = URL_SuccessPage2) _
                And (InStr(WebBrowser1.Document.Body.InnerText, SuccessString) <> 0)) Then
                    Logined()
                End If
            Case "ReNavigateLogin"
                Login()
            Case "ReLogin"
                Login()
            Case "Logoff"
                Online = False
                Button1.Enabled = True
                Button1.Text = "登录"
                FillFormOnLogin()
                StateButton.Text = "当前状态：离线"
                UsernameButton.Visible = False
                TimerOnline.Stop()
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        If Online Then
            Try
                WebBrowser1.Document.All("print_img").InvokeMember("click")
                CheckBox1.Checked = False
            Catch
                MsgBox("不足5秒钟")
                Button1.Enabled = True
                Exit Sub
            End Try
            'TimerOnline.Stop()
        Else
            Login(True)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Button1.Enabled = False
            AutoLogin = "1"
            Timer1.Start()
        Else
            Button1.Enabled = False
            AutoLogin = "0"
            Timer1.Stop()
        End If
    End Sub

    Private Sub TimerOnline_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Label3.Text = "上线时间：" + DateDiff(DateInterval.Minute, OnlineTime, Now()).ToString + "分钟"
    End Sub

    Private Sub Timer1_Tick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Online Then
            Timer1.Stop() '如果以在线则停止循环检测环境
            Exit Sub
        End If
        WebBrowser1.Navigate(URL_SuccessPage2)  '循环等待，检测频率1次/秒
        LastCommand = "WaitClient"
        Timer1.Stop() '停止下一次循环以等待Webborwer重新启动定时器
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
            Me.Hide()
        End If
    End Sub

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        End
    End Sub

    Private Sub UsernameTextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextbox.TextChanged
        Username = UsernameTextbox.Text
    End Sub

    Private Sub PasswordTextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordTextbox.TextChanged
        Password = PasswordTextbox.Text
    End Sub

    Private Sub TimerOnline_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerOnline.Tick
        Label3.Text = "上线时间：" + (Now - OnlineTime).Hours.ToString + "小时" + (Now - OnlineTime).Minutes.ToString + "分钟" + (Now - OnlineTime).Seconds.ToString + "秒"
    End Sub
End Class