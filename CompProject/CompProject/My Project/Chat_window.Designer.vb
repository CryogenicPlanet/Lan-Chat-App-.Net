<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chat_window
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.disp_msg = New System.Windows.Forms.TextBox()
        Me.msg = New System.Windows.Forms.TextBox()
        Me.send = New System.Windows.Forms.Button()
        Me.Ticker = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Comp Name"
        '
        'disp_msg
        '
        Me.disp_msg.Enabled = False
        Me.disp_msg.Location = New System.Drawing.Point(164, 19)
        Me.disp_msg.Multiline = True
        Me.disp_msg.Name = "disp_msg"
        Me.disp_msg.Size = New System.Drawing.Size(267, 248)
        Me.disp_msg.TabIndex = 1
        '
        'msg
        '
        Me.msg.Location = New System.Drawing.Point(164, 288)
        Me.msg.Multiline = True
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(267, 20)
        Me.msg.TabIndex = 2
        '
        'send
        '
        Me.send.Location = New System.Drawing.Point(40, 285)
        Me.send.Name = "send"
        Me.send.Size = New System.Drawing.Size(75, 23)
        Me.send.TabIndex = 3
        Me.send.Text = "Send"
        Me.send.UseVisualStyleBackColor = True
        '
        'Ticker
        '
        '
        'Chat_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 375)
        Me.Controls.Add(Me.send)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.disp_msg)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Chat_window"
        Me.Text = "Chat_window"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents disp_msg As System.Windows.Forms.TextBox
    Friend WithEvents msg As System.Windows.Forms.TextBox
    Friend WithEvents send As System.Windows.Forms.Button
    Friend WithEvents Ticker As System.Windows.Forms.Timer
End Class
