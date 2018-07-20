Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading
Imports System.Runtime.Serialization.Formatters.Binary

Public Class remote
    Public TCPClient As New TcpClient
    Public NetStream As NetworkStream

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        If NetStream.CanWrite Then
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("remote")
            NetStream.Write(sendBytes, 0, sendBytes.Length)
        End If
        Form1.Show()
    End Sub
End Class
