<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.Button1 = New System.Windows.Forms.Button
        Me.UsernameTextbox = New System.Windows.Forms.TextBox
        Me.PasswordTextbox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TuopanMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StateButton = New System.Windows.Forms.ToolStripMenuItem
        Me.UsernameButton = New System.Windows.Forms.ToolStripMenuItem
        Me.QuitButton = New System.Windows.Forms.ToolStripMenuItem
        Me.TimerOnline = New System.Windows.Forms.Timer(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TuopanMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(15, 133)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1024, 213)
        Me.WebBrowser1.TabIndex = 2
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(281, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 45)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "登陆"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UsernameTextbox
        '
        Me.UsernameTextbox.Location = New System.Drawing.Point(108, 21)
        Me.UsernameTextbox.Name = "UsernameTextbox"
        Me.UsernameTextbox.Size = New System.Drawing.Size(167, 21)
        Me.UsernameTextbox.TabIndex = 4
        '
        'PasswordTextbox
        '
        Me.PasswordTextbox.Location = New System.Drawing.Point(108, 48)
        Me.PasswordTextbox.Name = "PasswordTextbox"
        Me.PasswordTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextbox.Size = New System.Drawing.Size(89, 21)
        Me.PasswordTextbox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "帐号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "密码："
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(203, 51)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 10
        Me.CheckBox1.Text = "自动登陆"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "上线时间："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "by 逆光"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CheckCode.My.Resources.Resources.graffic
        Me.PictureBox1.Location = New System.Drawing.Point(15, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.TuopanMenu
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "校园网自动登录器"
        Me.NotifyIcon1.Visible = True
        '
        'TuopanMenu
        '
        Me.TuopanMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StateButton, Me.UsernameButton, Me.QuitButton})
        Me.TuopanMenu.Name = "TuopanMenu"
        Me.TuopanMenu.Size = New System.Drawing.Size(161, 70)
        '
        'StateButton
        '
        Me.StateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.StateButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.StateButton.Name = "StateButton"
        Me.StateButton.Size = New System.Drawing.Size(160, 22)
        Me.StateButton.Text = "当前状态：离线"
        '
        'UsernameButton
        '
        Me.UsernameButton.Name = "UsernameButton"
        Me.UsernameButton.Size = New System.Drawing.Size(160, 22)
        Me.UsernameButton.Text = "当前帐号："
        Me.UsernameButton.Visible = False
        '
        'QuitButton
        '
        Me.QuitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.QuitButton.Name = "QuitButton"
        Me.QuitButton.Size = New System.Drawing.Size(160, 22)
        Me.QuitButton.Text = "退出"
        '
        'TimerOnline
        '
        Me.TimerOnline.Interval = 1000
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "公测版"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 133)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PasswordTextbox)
        Me.Controls.Add(Me.UsernameTextbox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "青岛大学校园网自动登录器"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TuopanMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UsernameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents TuopanMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QuitButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StateButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsernameButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerOnline As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
