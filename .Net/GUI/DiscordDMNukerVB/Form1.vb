Imports System
Imports System.Windows.Forms
Imports DiscordDMNukerVB.DiscordDMNuker

Public Class FormStart
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

    Private Sub Guna2GradientButtonStart_Click(sender As Object, e As EventArgs) Handles Guna2GradientButtonStart.Click
        Start = True
        MainId = Convert.ToUInt64(Guna2TextBoxvID.Text.Trim())
        Token = Guna2TextBoxToken.Text.Trim()
        SavePicsNVids = Guna2CheckBoxSaveIm.Checked
        SaveMessages = Guna2CheckBoxSaveMa.Checked
        Delete = Guna2CheckBoxDelet.Checked
        IsGroupChat = Guna2CheckBoxInGr.Checked
        Edit = Guna2CheckBoxEditMas.Checked
        Message = Guna2TextBox5.Text.Trim()
        IsChannel = Guna2CheckBoxInCha.Checked
        'My.Settings.Default.Token = Guna2TextBoxToken.Text
        My.Settings.Token = Guna2TextBoxToken.Text
        'My.Settings.Default.Save()
        My.Settings.Save()
        Proxy = Guna2TextBoxProxy.Text.Trim()
        If IsChannel Then
            ChannelId = Convert.ToUInt64(Guna2TextBoxChaID.Text.Trim())
        End If

        Close()
    End Sub

    Private Sub FormStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2TextBoxToken.Text = My.Settings.Token
    End Sub
End Class
