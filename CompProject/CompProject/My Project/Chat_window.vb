Imports System.IO
Imports System.Net.Sockets
Public Class Chat_window
    Dim host As String = "localhost"
    Dim Listener As New TcpListener(8080)
    Dim Client As New TcpClient(host, 8080)
    Dim reader As New StreamReader(Client.GetStream())
    Dim message As String = msg.Text

    Private Sub Chat_window_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Ticker.Stop()
        reader.Dispose()
        Listener.Stop()
    End Sub

    Private Sub Chat_window_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Ticker.Start()
        Listener.Start()
    End Sub

    Private Sub Ticker_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ticker.Tick

        If Listener.Pending = True Then
            message += vbNewLine + reader.ReadToEnd
        End If
    End Sub

    Private Sub send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles send.Click

    End Sub
End Class