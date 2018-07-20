Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Form1
    Public TCPClient As New TcpClient
    Public NetStream As NetworkStream
    Dim tcpl As TcpListener
    Dim Thread As System.Threading.Thread
    Dim ns As NetworkStream
    Dim listening As New Thread(AddressOf Listen)
    Dim GetImage As New Thread(AddressOf ReceiveImage)

    'listen the incoming connection
    Private Sub Listen()
        While TCPClient.Connected = False
            tcpl.Start()
            TCPClient = tcpl.AcceptTcpClient
        End While
        GetImage.Start()
    End Sub

    Private Sub ReceiveImage()
        Dim bf As New BinaryFormatter
        While TCPClient.Connected = True
            ns = TCPClient.GetStream
            'deserialize - deserialize into object graph
            PictureBox_View.Image = bf.Deserialize(ns)
        End While
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tcpl = New TcpListener("9001")
        listening.Start()
    End Sub

    Private Sub PictureBox_View_Click(sender As Object, e As EventArgs)

    End Sub
End Class