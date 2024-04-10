Imports Discord
Imports DiscordDMNukerVB.DiscordDMNuker.Extensions
Imports System
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows.Forms
Public Class Main
    Inherits Form
    Private Status As ToolStripStatusLabel
    Private Logs As ListBox
    Private Shared ReadOnly random As Random = New Random()
    Private ReadOnly currentPath As String = Directory.GetCurrentDirectory()
    Private ReadOnly allowedExtensions As String() = {".mp4", ".avi", ".mov", ".mkv", ".flv", ".wmv", ".webm", ".jpg", ".jpeg", ".png", ".gif", ".mp3", ".wav", ".ogg", ".flac", ".m4a", ".txt", ".json"} ' Video
    ' Image
    ' Audio
    ' Text
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Directory.Exists(Path.Combine(currentPath, "SavedMedia")) Then
            Directory.CreateDirectory(Path.Combine(currentPath, "SavedMedia"))
        End If

        If Not Directory.Exists(Path.Combine(currentPath, "SavedConvos")) Then
            Directory.CreateDirectory(Path.Combine(currentPath, "SavedConvos"))
        End If
    End Sub
    Private Shared Function CreateProxyWithCredentials(proxyComponents As String()) As WebProxy
        Dim host = proxyComponents(0)
        Dim port = Integer.Parse(proxyComponents(1))
        Dim username = proxyComponents(2)
        Dim password = proxyComponents(3)

        Dim credentials As ICredentials = New NetworkCredential(username, password)
        Dim proxyUri = New Uri($"http://{host}:{port}")

        Return New WebProxy(proxyUri, False, Nothing, credentials)
    End Function
    Public Shared Function RandomString(length As Integer) As String
        Const chars = "abcdefghijklmnopqrstuvwxyz0123456789"
        Return New String(Enumerable.Repeat(chars, length).[Select](Function(s) s(random.Next(s.Length))).ToArray())
    End Function
    Public Shared Function RemoveSpecialCharacters(str As String) As String
        Return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled)
    End Function
    Private Async Function DownloadAndSaveAsync(url As String, currentPath As String, fileName As String) As Task
        Using httpClient = New HttpClient()
            Dim response = Await httpClient.GetAsync(url)

            If response.IsSuccessStatusCode Then
                Dim fullPath = Path.Combine(currentPath, "SavedMedia", fileName)
                Using fileStream = New FileStream(fullPath, FileMode.Create)
                    Await response.Content.CopyToAsync(fileStream)
                End Using

                Logs.SafeAddItem($"Saved Image/Video: {fileName}")
            Else
                ' Handle the error appropriately, e.g.:
                Logs.SafeAddItem($"Failed to download Image/Video: {fileName}. Status code: {response.StatusCode}")
            End If
        End Using
    End Function
    Private Async Sub Start(Token As String, MainId As ULong, savepicsnvids As Boolean, savemessages As Boolean, delete As Boolean, IsGroupChat As Boolean, Edit As Boolean, MessageContent As String, IsChannel As Boolean, ChannelId As ULong, proxy As String)
        Await Task.Run(Async Function()
                           Try
                               Status.SafeChangeText("Starting")
                               Dim client As DiscordClient
                               If Not String.IsNullOrEmpty(proxy) Then
                                   Dim proxyComponents = proxy.Split(":"c)

                                   Dim webProxy As WebProxy

                                   Select Case proxyComponents.Length
                                       Case 2
                                           Dim host = proxyComponents(0)
                                           Dim port = Integer.Parse(proxyComponents(1))

                                           webProxy = New WebProxy(host, port)
                                       Case 4
                                           webProxy = CreateProxyWithCredentials(proxyComponents)
                                       Case Else
                                           Throw New ArgumentException("Invalid proxy format.")
                                   End Select
                                   client = New DiscordClient(Token, New ApiConfig With {
                                                                             .Proxy = webProxy
                                                                         })
                               Else
                                   client = New DiscordClient(Token)
                               End If

                               Logs.SafeAddItem($"Logged In To: {client.User.Username}")
                               If Not IsGroupChat AndAlso Not IsChannel Then
                                   Dim user = Await client.GetUserAsync(MainId)
                                   Dim channel = Await client.CreateDMAsync(MainId)
                                   Logs.SafeAddItem($"Created DMs With: {user.Username}")
                                   Dim messages = Await client.GetChannelMessagesAsync(channel.Id)
                                   Status.SafeChangeText("In Progress....")
                                   Dim convoPath = $"SavedConvos/{RemoveSpecialCharacters(user.Username)}{random.Next(1, 999999999)}.txt"

                                   For Each message In messages
                                       If savemessages Then

                                           Using writer As StreamWriter = New StreamWriter(convoPath, True)
                                               writer.WriteLine($"{message.Author.User.Username} || {message.Content}")
                                           End Using
                                       End If

                                       If savepicsnvids Then
                                           If message.Attachments IsNot Nothing Then
                                               For Each Attachment In message.Attachments
                                                   If allowedExtensions.Any(Function(ext) Attachment.FileName.Contains(ext)) Then
                                                       Dim httpClient = New HttpClient()
                                                       Dim fileName = $"{RandomString(4)}{Attachment.FileName}"
                                                       Await DownloadAndSaveAsync(Attachment.Url, currentPath, fileName)
                                                   End If
                                               Next
                                           End If
                                       End If

                                       If delete OrElse Edit Then
                                           If message.Author.User.Id = client.User.Id AndAlso message.Type <> MessageType.GuildMemberJoin AndAlso message.Type <> MessageType.ChannelPinnedMessage AndAlso message.Type <> MessageType.GuildBoostedTier1 AndAlso message.Type <> MessageType.GuildBoostedTier2 AndAlso message.Type <> MessageType.GuildBoostedTier3 AndAlso message.Type <> MessageType.GuildMemberJoin AndAlso message.Type <> MessageType.GuildBoosted AndAlso message.Type <> MessageType.ThreadCreated AndAlso message.Type <> MessageType.ThreadStarterMessage AndAlso message.Type <> MessageType.RecipientAdd AndAlso message.Type <> MessageType.RecipientRemove AndAlso message.Type <> MessageType.Call Then
                                               If delete Then
                                                   Await message.DeleteAsync()
                                                   Logs.SafeAddItem($"Deleted Message: {message.Content}")
                                                   Await Task.Delay(New Random().Next(2200, 2500))
                                               End If

                                               If Edit Then
                                                   Await message.EditAsync(New MessageEditProperties With {
                                                                                             .Content = MessageContent
                                                                                         })
                                                   Logs.SafeAddItem($"Edited Message: {message.Content}")
                                                   Await Task.Delay(New Random().Next(2200, 2500))
                                               End If
                                           End If
                                       End If
                                   Next
                                   Status.SafeChangeText("Completed")
                               ElseIf IsGroupChat Then
                                   Dim GroupChat = Await client.GetChannelAsync(MainId)
                                   If Not Equals(GroupChat.Name, Nothing) Then
                                       Logs.SafeAddItem($"Hooked Group With Name: {GroupChat.Name}")
                                       Dim msg = Await client.GetChannelMessagesAsync(GroupChat.Id)
                                       Status.SafeChangeText("In Progress....")
                                       Dim Convo = $"SavedConvos/{RemoveSpecialCharacters(GroupChat.Name)}{random.Next(1, 999_999_999)}.txt"
                                       For Each message In msg
                                           If savemessages Then

                                               Using writer As StreamWriter = New StreamWriter(Convo, True)
                                                   writer.WriteLine($"{message.Author.User.Username} || {message.Content}")
                                               End Using
                                           End If

                                           If savepicsnvids Then
                                               If message.Attachments IsNot Nothing Then
                                                   For Each Attachment In message.Attachments
                                                       If allowedExtensions.Any(Function(ext) Attachment.FileName.Contains(ext)) Then
                                                           Dim httpClient = New HttpClient()
                                                           Dim fileName = $"{RandomString(4)}{Attachment.FileName}"
                                                           Await DownloadAndSaveAsync(Attachment.Url, currentPath, fileName)
                                                       End If
                                                   Next
                                               End If
                                           End If

                                           If delete OrElse Edit Then
                                               If message.Author.User.Id = client.User.Id AndAlso message.Type <> MessageType.GuildMemberJoin AndAlso message.Type <> MessageType.ChannelPinnedMessage AndAlso message.Type <> MessageType.GuildBoostedTier1 AndAlso message.Type <> MessageType.GuildBoostedTier2 AndAlso message.Type <> MessageType.GuildBoostedTier3 AndAlso message.Type <> MessageType.GuildMemberJoin AndAlso message.Type <> MessageType.GuildBoosted AndAlso message.Type <> MessageType.ThreadCreated AndAlso message.Type <> MessageType.ThreadStarterMessage AndAlso message.Type <> MessageType.RecipientAdd AndAlso message.Type <> MessageType.RecipientRemove AndAlso message.Type <> MessageType.Call Then
                                                   If delete Then
                                                       Await message.DeleteAsync()
                                                       Logs.SafeAddItem($"Deleted Message: {message.Content}")
                                                       Await Task.Delay(New Random().Next(2200, 2500))
                                                   End If

                                                   If Edit Then
                                                       Await message.EditAsync(New MessageEditProperties With {
                                                                                                 .Content = MessageContent
                                                                                             })
                                                       Logs.SafeAddItem($"Edited Message: {message.Content}")
                                                       Await Task.Delay(New Random().Next(2200, 2500))
                                                   End If
                                               End If
                                           End If
                                       Next
                                   End If
                                   Status.SafeChangeText("Completed")
                               ElseIf IsChannel Then
                                   Dim Channel = Await client.GetChannelAsync(ChannelId)
                                   Dim msg = Await client.GetChannelMessagesAsync(Channel.Id)
                                   Status.SafeChangeText("In Progress....")
                                   Dim Convo = $"SavedConvos/{Channel.Name}{random.Next(1, 999_999_999)}.txt"
                                   For Each message In msg
                                       If savemessages Then

                                           Using writer As StreamWriter = New StreamWriter(Convo, True)
                                               writer.WriteLine($"{message.Author.User.Username} || {message.Content}")
                                           End Using
                                       End If

                                       If savepicsnvids Then
                                           If message.Attachments IsNot Nothing Then
                                               For Each Attachment In message.Attachments
                                                   If allowedExtensions.Any(Function(ext) Attachment.FileName.Contains(ext)) Then
                                                       Dim httpClient = New HttpClient()
                                                       Dim fileName = $"{RandomString(4)}{Attachment.FileName}"
                                                       Await DownloadAndSaveAsync(Attachment.Url, currentPath, fileName)
                                                   End If
                                               Next
                                           End If
                                       End If

                                       If delete OrElse Edit Then
                                           If message.Author.User.Id = client.User.Id AndAlso message.Type <> MessageType.GuildMemberJoin AndAlso message.Type <> MessageType.ChannelPinnedMessage AndAlso message.Type <> MessageType.GuildBoostedTier1 AndAlso message.Type <> MessageType.GuildBoostedTier2 AndAlso message.Type <> MessageType.GuildBoostedTier3 AndAlso message.Type <> MessageType.GuildMemberJoin AndAlso message.Type <> MessageType.GuildBoosted AndAlso message.Type <> MessageType.ThreadCreated AndAlso message.Type <> MessageType.ThreadStarterMessage AndAlso message.Type <> MessageType.RecipientAdd AndAlso message.Type <> MessageType.RecipientRemove AndAlso message.Type <> MessageType.Call Then
                                               If delete Then
                                                   Await message.DeleteAsync()
                                                   Logs.SafeAddItem($"Deleted Message: {message.Content}")
                                                   Await Task.Delay(New Random().Next(2200, 2500))
                                               End If

                                               If Edit Then
                                                   Await message.EditAsync(New MessageEditProperties With {
                                                                                             .Content = MessageContent
                                                                                         })
                                                   Logs.SafeAddItem($"Edited Message: {message.Content}")
                                                   Await Task.Delay(New Random().Next(2200, 2500))
                                               End If
                                           End If
                                       End If
                                   Next
                                   Status.SafeChangeText("Completed")
                               Else
                                   Throw New Exception("Something went horribly wrong before i can continue, please check your internet connection, discord token and message parameters.")
                               End If

                           Catch
                           End Try
                       End Function)
    End Sub
    Private Sub toolStripButton1_Click(sender As Object, e As EventArgs)
        Using FormStart As FormStart = New FormStart()
            FormStart.ShowDialog()
            If FormStart.Start Then
                Status = ToolStripStatusLabel1
                Logs = ListBox1

                Start(FormStart.Token, FormStart.MainId, FormStart.SavePicsNVids, FormStart.SaveMessages, FormStart.Delete, FormStart.IsGroupChat, FormStart.Edit, FormStart.Message, FormStart.IsChannel, FormStart.ChannelId, FormStart.Proxy)
            End If
        End Using
    End Sub
End Class