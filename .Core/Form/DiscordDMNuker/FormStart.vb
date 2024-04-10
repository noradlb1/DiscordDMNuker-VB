Imports System
Imports System.Windows.Forms

Namespace DiscordDMNuker
    Public Partial Class FormStart
        Inherits Form
        Public Start As Boolean = False
        Public MainId As ULong
        Public ChannelId As ULong
        Public Token As String
        Public Message As String
        Public Delay As Integer
        Public SavePicsNVids As Boolean
        Public SaveMessages As Boolean
        Public Delete As Boolean
        Public Edit As Boolean
        Public IsGroupChat As Boolean
        Public IsChannel As Boolean
        Public Proxy As String
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub label3_Click(sender As Object, e As EventArgs)

        End Sub

        Private Sub button1_Click(sender As Object, e As EventArgs)
            Start = True
            MainId = Convert.ToUInt64(textBox1.Text.Trim())
            Token = textBox2.Text.Trim()
            SavePicsNVids = checkBox1.Checked
            SaveMessages = checkBox2.Checked
            Delete = checkBox3.Checked
            IsGroupChat = checkBox4.Checked
            Edit = checkBox5.Checked
            Message = textBox3.Text.Trim()
            IsChannel = checkBox6.Checked
            Properties.Settings.Default.Token = textBox2.Text
            Properties.Settings.Default.Save()
            Proxy = textBox5.Text.Trim()
            If IsChannel Then
                ChannelId = Convert.ToUInt64(textBox4.Text.Trim())
            End If

            Close()
        End Sub

        Private Sub FormStart_Load(sender As Object, e As EventArgs)
            textBox2.Text = Properties.Settings.Default.Token
        End Sub
    End Class
End Namespace
