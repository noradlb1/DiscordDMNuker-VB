Imports System.Net
Namespace DiscordDMNuker
    Partial Class Main
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
            Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
            Me.listBox1 = New System.Windows.Forms.ListBox()
            Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.toolStripButton1 = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.statusStrip1.SuspendLayout()
            Me.toolStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'statusStrip1
            '
            Me.statusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
            Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel1})
            Me.statusStrip1.Location = New System.Drawing.Point(0, 267)
            Me.statusStrip1.Name = "statusStrip1"
            Me.statusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
            Me.statusStrip1.Size = New System.Drawing.Size(501, 22)
            Me.statusStrip1.SizingGrip = False
            Me.statusStrip1.TabIndex = 11
            Me.statusStrip1.Text = "statusStrip1"
            '
            'toolStripStatusLabel1
            '
            Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
            Me.toolStripStatusLabel1.Size = New System.Drawing.Size(64, 17)
            Me.toolStripStatusLabel1.Text = "Status: Idle"
            '
            'listBox1
            '
            Me.listBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.listBox1.FormattingEnabled = True
            Me.listBox1.HorizontalScrollbar = True
            Me.listBox1.ItemHeight = 15
            Me.listBox1.Location = New System.Drawing.Point(0, 25)
            Me.listBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.listBox1.Name = "listBox1"
            Me.listBox1.ScrollAlwaysVisible = True
            Me.listBox1.Size = New System.Drawing.Size(501, 264)
            Me.listBox1.TabIndex = 10
            '
            'toolStrip1
            '
            Me.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.toolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
            Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripButton1, Me.toolStripSeparator1})
            Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
            Me.toolStrip1.Name = "toolStrip1"
            Me.toolStrip1.ShowItemToolTips = False
            Me.toolStrip1.Size = New System.Drawing.Size(501, 25)
            Me.toolStrip1.TabIndex = 9
            Me.toolStrip1.Text = "toolStrip1"
            '
            'toolStripButton1
            '
            Me.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.toolStripButton1.Image = CType(resources.GetObject("toolStripButton1.Image"), System.Drawing.Image)
            Me.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.toolStripButton1.Name = "toolStripButton1"
            Me.toolStripButton1.Size = New System.Drawing.Size(35, 22)
            Me.toolStripButton1.Text = "Start"
            '
            'toolStripSeparator1
            '
            Me.toolStripSeparator1.Name = "toolStripSeparator1"
            Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(501, 289)
            Me.Controls.Add(Me.statusStrip1)
            Me.Controls.Add(Me.listBox1)
            Me.Controls.Add(Me.toolStrip1)
            Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.Name = "Main"
            Me.Text = "Main"
            Me.statusStrip1.ResumeLayout(False)
            Me.statusStrip1.PerformLayout()
            Me.toolStrip1.ResumeLayout(False)
            Me.toolStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private statusStrip1 As Windows.Forms.StatusStrip
        Private toolStripStatusLabel1 As Windows.Forms.ToolStripStatusLabel
        Private listBox1 As Windows.Forms.ListBox
        Private toolStrip1 As Windows.Forms.ToolStrip
        Private toolStripButton1 As Windows.Forms.ToolStripButton
        Private toolStripSeparator1 As Windows.Forms.ToolStripSeparator
    End Class
End Namespace
