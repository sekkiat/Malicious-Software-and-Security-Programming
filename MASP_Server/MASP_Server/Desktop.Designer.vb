<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Desktop
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.username = New System.Windows.Forms.Label()
        Me.os = New System.Windows.Forms.Label()
        Me.hostname = New System.Windows.Forms.Label()
        Me.macaddress = New System.Windows.Forms.Label()
        Me.ipaddress = New System.Windows.Forms.Label()
        Me.osplatform = New System.Windows.Forms.Label()
        Me.osversion = New System.Windows.Forms.Label()
        Me.pysicalmemory = New System.Windows.Forms.Label()
        Me.virtualmemory = New System.Windows.Forms.Label()
        Me.FlatButton1 = New MASP_Server.FlatButton()
        Me.FlatButton2 = New MASP_Server.FlatButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Operating System"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Host name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Mac Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ip Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "OS Platform"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "OS Version"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(237, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 19)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Pysical Memory"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(237, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Virtual Memory"
        '
        'username
        '
        Me.username.AutoSize = True
        Me.username.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.username.Location = New System.Drawing.Point(116, 13)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(0, 21)
        Me.username.TabIndex = 0
        '
        'os
        '
        Me.os.AutoSize = True
        Me.os.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.os.Location = New System.Drawing.Point(118, 81)
        Me.os.Name = "os"
        Me.os.Size = New System.Drawing.Size(0, 21)
        Me.os.TabIndex = 0
        '
        'hostname
        '
        Me.hostname.AutoSize = True
        Me.hostname.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hostname.Location = New System.Drawing.Point(116, 48)
        Me.hostname.Name = "hostname"
        Me.hostname.Size = New System.Drawing.Size(0, 21)
        Me.hostname.TabIndex = 0
        '
        'macaddress
        '
        Me.macaddress.AutoSize = True
        Me.macaddress.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.macaddress.Location = New System.Drawing.Point(118, 111)
        Me.macaddress.Name = "macaddress"
        Me.macaddress.Size = New System.Drawing.Size(0, 21)
        Me.macaddress.TabIndex = 0
        '
        'ipaddress
        '
        Me.ipaddress.AutoSize = True
        Me.ipaddress.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ipaddress.Location = New System.Drawing.Point(118, 144)
        Me.ipaddress.Name = "ipaddress"
        Me.ipaddress.Size = New System.Drawing.Size(0, 21)
        Me.ipaddress.TabIndex = 0
        '
        'osplatform
        '
        Me.osplatform.AutoSize = True
        Me.osplatform.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.osplatform.Location = New System.Drawing.Point(118, 176)
        Me.osplatform.Name = "osplatform"
        Me.osplatform.Size = New System.Drawing.Size(0, 21)
        Me.osplatform.TabIndex = 0
        '
        'osversion
        '
        Me.osversion.AutoSize = True
        Me.osversion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.osversion.Location = New System.Drawing.Point(118, 209)
        Me.osversion.Name = "osversion"
        Me.osversion.Size = New System.Drawing.Size(0, 21)
        Me.osversion.TabIndex = 0
        '
        'pysicalmemory
        '
        Me.pysicalmemory.AutoSize = True
        Me.pysicalmemory.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pysicalmemory.Location = New System.Drawing.Point(375, 13)
        Me.pysicalmemory.Name = "pysicalmemory"
        Me.pysicalmemory.Size = New System.Drawing.Size(0, 21)
        Me.pysicalmemory.TabIndex = 0
        '
        'virtualmemory
        '
        Me.virtualmemory.AutoSize = True
        Me.virtualmemory.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.virtualmemory.Location = New System.Drawing.Point(368, 46)
        Me.virtualmemory.Name = "virtualmemory"
        Me.virtualmemory.Size = New System.Drawing.Size(0, 21)
        Me.virtualmemory.TabIndex = 0
        '
        'FlatButton1
        '
        Me.FlatButton1.BackColor = System.Drawing.Color.Transparent
        Me.FlatButton1.BaseColor = System.Drawing.Color.MediumSeaGreen
        Me.FlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlatButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FlatButton1.Location = New System.Drawing.Point(229, 162)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.Rounded = False
        Me.FlatButton1.Size = New System.Drawing.Size(134, 32)
        Me.FlatButton1.TabIndex = 1
        Me.FlatButton1.Text = "Extract SAM File"
        Me.FlatButton1.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'FlatButton2
        '
        Me.FlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.FlatButton2.BaseColor = System.Drawing.Color.MediumSeaGreen
        Me.FlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlatButton2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FlatButton2.Location = New System.Drawing.Point(209, 195)
        Me.FlatButton2.Name = "FlatButton2"
        Me.FlatButton2.Rounded = False
        Me.FlatButton2.Size = New System.Drawing.Size(154, 32)
        Me.FlatButton2.TabIndex = 1
        Me.FlatButton2.Text = "Download SAM File"
        Me.FlatButton2.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'Desktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FlatButton2)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.virtualmemory)
        Me.Controls.Add(Me.osversion)
        Me.Controls.Add(Me.macaddress)
        Me.Controls.Add(Me.pysicalmemory)
        Me.Controls.Add(Me.osplatform)
        Me.Controls.Add(Me.hostname)
        Me.Controls.Add(Me.ipaddress)
        Me.Controls.Add(Me.os)
        Me.Controls.Add(Me.username)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Desktop"
        Me.Size = New System.Drawing.Size(746, 391)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents username As Label
    Friend WithEvents os As Label
    Friend WithEvents hostname As Label
    Friend WithEvents macaddress As Label
    Friend WithEvents ipaddress As Label
    Friend WithEvents osplatform As Label
    Friend WithEvents osversion As Label
    Friend WithEvents pysicalmemory As Label
    Friend WithEvents virtualmemory As Label
    Friend WithEvents FlatButton1 As FlatButton
    Friend WithEvents FlatButton2 As FlatButton
End Class
