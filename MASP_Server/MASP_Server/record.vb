Imports System.IO
Imports System.Text
Imports System.Net.Sockets

Public Class record
    Public TCPClient As New TcpClient
    Public NetStream As NetworkStream
    Dim Thread As System.Threading.Thread

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        If NetStream.CanWrite Then
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("record")
            NetStream.Write(sendBytes, 0, sendBytes.Length)
        End If
        FlatButton2.Enabled = True
        FlatButton1.Enabled = False
        FlatButton3.Enabled = False
    End Sub

    Private Sub FlatButton3_Click(sender As Object, e As EventArgs) Handles FlatButton3.Click
        FlatButton3.Enabled = False
        Thread = New System.Threading.Thread(AddressOf download)
        Thread.Start()
    End Sub

    Private Sub FlatButton4_Click(sender As Object, e As EventArgs) Handles FlatButton4.Click
        My.Computer.Audio.Play("C:\Users\Romeo VaVa\Desktop\abc.wav", AudioPlayMode.Background)
    End Sub
    Private Sub record_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        If NetStream.CanWrite Then
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("stop")
            NetStream.Write(sendBytes, 0, sendBytes.Length)
        End If
        Thread.Sleep(2000)
        FlatButton2.Enabled = False
        FlatButton1.Enabled = True
        FlatButton4.Enabled = False
        FlatButton3.Enabled = True
    End Sub

    Private Sub download()
        Dim fs As FileStream = File.OpenWrite("C:\Users\Romeo VaVa\Desktop\abc.wav")
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/test.wav"), System.Net.FtpWebRequest)
        request.EnableSsl = True
        request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
        request.Credentials = New System.Net.NetworkCredential("watchdogscanner@gmail.com", "W@tchD0g_Scanner01172017")
        Dim response As System.Net.FtpWebResponse = request.GetResponse()
        request.GetResponse.GetResponseStream.CopyTo(fs)
        fs.Close()
        Me.Invoke(Sub()
                      MessageBox.Show("File is downloaded")
                      FlatButton4.Enabled = True
                  End Sub)
    End Sub
End Class
