Imports System.DirectoryServices
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LBox.Items.Clear()
        Dim childEntry As DirectoryEntry
        Dim ParentEntry As New DirectoryEntry
        Try
            ParentEntry.Path = "WinNT:"
            For Each childEntry In ParentEntry.Children
                Select Case childEntry.SchemaClassName
                    Case "Domain"

                        Dim SubChildEntry As DirectoryEntry
                        Dim SubParentEntry As New DirectoryEntry
                        SubParentEntry.Path = "WinNT://" & childEntry.Name
                        For Each SubChildEntry In SubParentEntry.Children

                            Select Case SubChildEntry.SchemaClassName
                                Case "Computer"
                                    LBox.Items.Add(SubChildEntry.Name)
                            End Select
                        Next
                End Select
            Next
        Catch Excep As Exception
            MsgBox("Error While Reading Directories")
        Finally
            ParentEntry = Nothing
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Get All Machines"
        Label1.Text = "All Machines"
        Button1.Text = "Get All Machines"

    End Sub

    Private Sub LBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBox.SelectedValueChanged
        MessageBox.Show(LBox.SelectedItem().ToString())
    End Sub
End Class
