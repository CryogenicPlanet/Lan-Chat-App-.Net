Option Explicit On
Imports System.IO
Imports System.Net.Sockets
Imports System.Security.Cryptography
Imports System.Text
Module listerner
    Public base64_outhtoken As String = "d71Avkf4g/qsuoWyZsB+wcQO8OyH3yZd8R8F8r9ENLKOqkDARbTqMOOw2eBa5j2c2x0qiFH5QyqISnC2gqo0Rg=="
    Dim ListerNer As New TcpListener(8000)
    Dim Client As New TcpClient
    Dim message As String
    Dim Status As Boolean = False
    Public Sub Start()

        If Status = False Then
            Dim t As New Threading.Thread(AddressOf Listen)
            t.IsBackground = True
            t.Start()
            ListerNer.Start()
            Status = False
        End If
    End Sub
    Public Function Pending()
        If ListerNer.Pending = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Authenticate_String()
        Dim private_key As String

        private_key = Mid(message, 1, InStr(message, "#") - 1)
        If Hash512(private_key) = base64_outhtoken Then
            message = Mid(message, InStr(message, "#") + 1)
            Return True
        Else
            Return False
            End If

    End Function
    Public Function AcceptClient()
        Return ListerNer.AcceptTcpClient()
    End Function
    Public Function Listen()
        message = ""
        If ListerNer.Pending() = True Then
            Client = ListerNer.AcceptTcpClient()
            Dim Reader As New StreamReader(Client.GetStream())
            While Reader.Peek > -1
                message &= Convert.ToChar(Reader.Read()).ToString()
                If Authenticate_String() = False Then
                    message = ""
                End If
            End While
        End If
        If message <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Get_message()

        Return message

    End Function
    Public Function GetHost()

        Dim collen_loc As Integer
            Dim host As String
            If InStr(message, " : ") = True Then
                collen_loc = InStr(message, ";")
                host = Mid(message, 1, collen_loc - 1)
                Return host

            End If

    End Function
    Public Function Hash512(password As String) As String
        Dim convertedToBytes As Byte() = Encoding.UTF8.GetBytes(password)
        Dim hashType As HashAlgorithm = New SHA512Managed()
        Dim hashBytes As Byte() = hashType.ComputeHash(convertedToBytes)
        Dim hashedResult As String = Convert.ToBase64String(hashBytes)
        Console.WriteLine(hashedResult)
        Return hashedResult
    End Function
    Public Function Get_private_string()
        Return "cryogenicplanet"
    End Function
    Public Sub Set_Message(ByVal s As String)
        message = s
    End Sub
End Module
