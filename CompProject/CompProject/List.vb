Imports System.Windows.Controls
Imports CompProject
Imports System.DirectoryServices
Public Class List
    Private Delegate Sub UpdateDelegate(ByVal s As String)
    Dim chatwindows() As chatwindon
    Private Sub List_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim t As New Threading.Thread(AddressOf GetNetworkComputers)
        t.IsBackground = True
        t.Start()
        listerner.Start()

        Try
            Dim host As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry("localhost")
            Label2.Text &= vbNewLine & host.HostName
        Catch ex As Exception
            Label2.Text = "There has been an error getting this computer's name" & ex.Message
        End Try

    End Sub
    Private Sub AddListBoxItem(ByVal s As String)

        LBox.Items.Add(s)
        ReDim Preserve chatwindows(chatwindows.Length + LBox.Items.Count)
    End Sub
    Public Sub clearlbox()
        LBox.Items.Clear()
    End Sub
    Public Sub GetNetworkComputers()
        clearlbox()
        Try
            Dim alWorkGroups As New ArrayList
            Dim de As New DirectoryEntry

            de.Path = "WinNT:"
            For Each d As DirectoryEntry In de.Children
                If d.SchemaClassName = "Domain" Then alWorkGroups.Add(d.Name)
                d.Dispose()
            Next

            For Each workgroup As String In alWorkGroups

                de.Path = "WinNT://" & workgroup
                For Each d As DirectoryEntry In de.Children

                    If d.SchemaClassName = "Computer" Then

                        Dim del As UpdateDelegate = AddressOf AddListBoxItem
                        Me.Invoke(del, d.Name)

                    End If

                    d.Dispose()

                Next
            Next
        Catch Excep As Exception
            MsgBox("Error While Reading Directories:" & Excep.Message())
        End Try
        If listerner.Listen = True Then
            IncomingMessage()
        End If
    End Sub
    Private Sub LBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBox.SelectedValueChanged

        ' MessageBox.Show(LBox.SelectedItem().ToString())
        Dim chat As New chatwindon
        chat.ComputerName = LBox.SelectedItem().ToString()
        For Each chatwindow In chatwindows
            If chatwindow.ComputerName = LBox.SelectedItem().ToString() Then
                chatwindow.Focus()
            Else
                chat.Show()
                chat.Focus()
            End If
            chatwindows(chatwindows.Length + 1) = chat
        Next
    End Sub
    Public Sub IncomingMessage()
        Dim host As String = listerner.GetHost()
        Dim message As String = listerner.Get_message()
        Dim chat As New chatwindon
        chat.ComputerName = host
        For Each chatwindow In chatwindows
            If chatwindow.ComputerName = host Then
                chatwindow.Focus()
                chatwindow.Message = message
            Else
                chat.Message = message
                chat.Show()
                chat.Focus()
            End If
            chatwindows(chatwindows.Length + 1) = chat
        Next
    End Sub

End Class