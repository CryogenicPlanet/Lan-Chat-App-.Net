Option Explicit On
Imports System.IO
Imports System.Net.Sockets
Imports CompProject
Public Class chatwindon
    Public Message, Sent As String
    Public ComputerName As String
    Dim Client As TcpClient
    Dim private_string As String = listerner.Get_private_string()
    Dim host As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry("localhost")
    Private Sub _Load() Handles MyBase.Load
        Me.Text = "Chat with-" + ComputerName
        Timer1.Start()
        listerner.Start()
        TextBox3.TextAlign = Forms.HorizontalAlignment.Right
        TextBox1.Text = Message

    End Sub

    Private Sub _Tick() Handles Timer1.Tick
        Dim temp As String
        If listerner.Pending() = True Then
            Client = listerner.AcceptClient()
            Dim Reader As New StreamReader(Client.GetStream())
            Message &= vbNewLine & vbNewLine
            While Reader.Peek > -1
                temp &= Convert.ToChar(Reader.Read()).ToString

            End While
            listerner.Set_Message(temp)
            If listerner.Authenticate_String = True Then
                Message &= listerner.Get_message()
                TextBox1.Text = Message
            End If
        End If
    End Sub

    Private Sub btnClick() Handles Button1.Click
        Dim input As String = TextBox2.Text
        TextBox2.Text = ""
        Sent &= vbNewLine & vbNewLine & input
        TextBox3.Text = Sent
        Try
            Client = New TcpClient(ComputerName, 8000)
            Dim Writer As New StreamWriter(Client.GetStream())
            Writer.Write(private_string & "#" & host.HostName & ":" & input)

            Writer.Flush()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class