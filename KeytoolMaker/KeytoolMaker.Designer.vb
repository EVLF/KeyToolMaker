<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeytoolMaker
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BW = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Logger = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Roboto", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(1168, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Create Key"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BW
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1168, 60)
        Me.Panel1.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Roboto", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(0, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(1168, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "About"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 80
        '
        'Logger
        '
        Me.Logger.BackColor = System.Drawing.Color.Black
        Me.Logger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Logger.Font = New System.Drawing.Font("Rockwell Condensed", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Logger.ForeColor = System.Drawing.Color.Lime
        Me.Logger.Location = New System.Drawing.Point(0, 60)
        Me.Logger.Multiline = True
        Me.Logger.Name = "Logger"
        Me.Logger.Size = New System.Drawing.Size(1168, 374)
        Me.Logger.TabIndex = 5
        Me.Logger.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KeytoolMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 434)
        Me.Controls.Add(Me.Logger)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Name = "KeytoolMaker"
        Me.ShowIcon = False
        Me.Text = "KeytoolMaker"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents BW As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Logger As TextBox
End Class
