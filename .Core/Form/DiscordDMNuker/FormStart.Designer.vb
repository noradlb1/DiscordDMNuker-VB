Imports System.Net
Namespace DiscordDMNuker
    Partial Class FormStart
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
            textBox1 = New Windows.Forms.TextBox()
            label2 = New Windows.Forms.Label()
            label1 = New Windows.Forms.Label()
            textBox2 = New Windows.Forms.TextBox()
            button1 = New Windows.Forms.Button()
            checkBox1 = New Windows.Forms.CheckBox()
            checkBox2 = New Windows.Forms.CheckBox()
            checkBox3 = New Windows.Forms.CheckBox()
            checkBox4 = New Windows.Forms.CheckBox()
            checkBox5 = New Windows.Forms.CheckBox()
            textBox3 = New Windows.Forms.TextBox()
            checkBox6 = New Windows.Forms.CheckBox()
            textBox4 = New Windows.Forms.TextBox()
            label4 = New Windows.Forms.Label()
            textBox5 = New Windows.Forms.TextBox()
            label3 = New Windows.Forms.Label()
            SuspendLayout()
            ' 
            ' textBox1
            ' 
            textBox1.Location = New Drawing.Point(15, 27)
            textBox1.Margin = New Windows.Forms.Padding(2, 1, 2, 1)
            textBox1.Name = "textBox1"
            textBox1.Size = New Drawing.Size(182, 23)
            textBox1.TabIndex = 15
            ' 
            ' label2
            ' 
            label2.AutoSize = True
            label2.Location = New Drawing.Point(37, 10)
            label2.Margin = New Windows.Forms.Padding(2, 0, 2, 0)
            label2.Name = "label2"
            label2.Size = New Drawing.Size(126, 15)
            label2.TabIndex = 14
            label2.Text = "Guild/Group/Victim ID"
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Location = New Drawing.Point(76, 91)
            label1.Margin = New Windows.Forms.Padding(2, 0, 2, 0)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(38, 15)
            label1.TabIndex = 16
            label1.Text = "Token"
            ' 
            ' textBox2
            ' 
            textBox2.Location = New Drawing.Point(16, 107)
            textBox2.Margin = New Windows.Forms.Padding(2, 1, 2, 1)
            textBox2.Name = "textBox2"
            textBox2.Size = New Drawing.Size(180, 23)
            textBox2.TabIndex = 17
            ' 
            ' button1
            ' 
            button1.Location = New Drawing.Point(7, 383)
            button1.Margin = New Windows.Forms.Padding(2, 1, 2, 1)
            button1.Name = "button1"
            button1.Size = New Drawing.Size(186, 35)
            button1.TabIndex = 18
            button1.Text = "Start"
            button1.UseVisualStyleBackColor = True
            AddHandler button1.Click, AddressOf button1_Click
            ' 
            ' checkBox1
            ' 
            checkBox1.AutoSize = True
            checkBox1.Location = New Drawing.Point(16, 191)
            checkBox1.Margin = New Windows.Forms.Padding(2)
            checkBox1.Name = "checkBox1"
            checkBox1.Size = New Drawing.Size(118, 19)
            checkBox1.TabIndex = 21
            checkBox1.Text = "Save Images/Vids"
            checkBox1.UseVisualStyleBackColor = True
            ' 
            ' checkBox2
            ' 
            checkBox2.AutoSize = True
            checkBox2.Location = New Drawing.Point(16, 215)
            checkBox2.Margin = New Windows.Forms.Padding(2)
            checkBox2.Name = "checkBox2"
            checkBox2.Size = New Drawing.Size(104, 19)
            checkBox2.TabIndex = 22
            checkBox2.Text = "Save Messages"
            checkBox2.UseVisualStyleBackColor = True
            ' 
            ' checkBox3
            ' 
            checkBox3.AutoSize = True
            checkBox3.Location = New Drawing.Point(16, 240)
            checkBox3.Margin = New Windows.Forms.Padding(2)
            checkBox3.Name = "checkBox3"
            checkBox3.Size = New Drawing.Size(113, 19)
            checkBox3.TabIndex = 23
            checkBox3.Text = "Delete Messages"
            checkBox3.UseVisualStyleBackColor = True
            ' 
            ' checkBox4
            ' 
            checkBox4.AutoSize = True
            checkBox4.Location = New Drawing.Point(16, 264)
            checkBox4.Margin = New Windows.Forms.Padding(2)
            checkBox4.Name = "checkBox4"
            checkBox4.Size = New Drawing.Size(98, 19)
            checkBox4.TabIndex = 24
            checkBox4.Text = "Is Group Chat"
            checkBox4.UseVisualStyleBackColor = True
            ' 
            ' checkBox5
            ' 
            checkBox5.AutoSize = True
            checkBox5.Location = New Drawing.Point(15, 312)
            checkBox5.Margin = New Windows.Forms.Padding(2)
            checkBox5.Name = "checkBox5"
            checkBox5.Size = New Drawing.Size(100, 19)
            checkBox5.TabIndex = 25
            checkBox5.Text = "Edit Messages"
            checkBox5.UseVisualStyleBackColor = True
            ' 
            ' textBox3
            ' 
            textBox3.Location = New Drawing.Point(8, 334)
            textBox3.Margin = New Windows.Forms.Padding(2, 1, 2, 1)
            textBox3.Multiline = True
            textBox3.Name = "textBox3"
            textBox3.Size = New Drawing.Size(185, 47)
            textBox3.TabIndex = 26
            ' 
            ' checkBox6
            ' 
            checkBox6.AutoSize = True
            checkBox6.Location = New Drawing.Point(16, 288)
            checkBox6.Margin = New Windows.Forms.Padding(2)
            checkBox6.Name = "checkBox6"
            checkBox6.Size = New Drawing.Size(81, 19)
            checkBox6.TabIndex = 27
            checkBox6.Text = "Is Channel"
            checkBox6.UseVisualStyleBackColor = True
            ' 
            ' textBox4
            ' 
            textBox4.Location = New Drawing.Point(16, 67)
            textBox4.Margin = New Windows.Forms.Padding(2, 1, 2, 1)
            textBox4.Name = "textBox4"
            textBox4.Size = New Drawing.Size(181, 23)
            textBox4.TabIndex = 29
            ' 
            ' label4
            ' 
            label4.AutoSize = True
            label4.Location = New Drawing.Point(65, 51)
            label4.Margin = New Windows.Forms.Padding(2, 0, 2, 0)
            label4.Name = "label4"
            label4.Size = New Drawing.Size(65, 15)
            label4.TabIndex = 28
            label4.Text = "Channel ID"
            ' 
            ' textBox5
            ' 
            textBox5.Location = New Drawing.Point(13, 147)
            textBox5.Margin = New Windows.Forms.Padding(2, 1, 2, 1)
            textBox5.Name = "textBox5"
            textBox5.Size = New Drawing.Size(180, 23)
            textBox5.TabIndex = 31
            ' 
            ' label3
            ' 
            label3.AutoSize = True
            label3.Location = New Drawing.Point(73, 131)
            label3.Margin = New Windows.Forms.Padding(2, 0, 2, 0)
            label3.Name = "label3"
            label3.Size = New Drawing.Size(37, 15)
            label3.TabIndex = 30
            label3.Text = "Proxy"
            ' 
            ' FormStart
            ' 
            AutoScaleDimensions = New Drawing.SizeF(7F, 15F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(197, 425)
            Controls.Add(textBox5)
            Controls.Add(label3)
            Controls.Add(textBox4)
            Controls.Add(label4)
            Controls.Add(checkBox6)
            Controls.Add(textBox3)
            Controls.Add(checkBox5)
            Controls.Add(checkBox4)
            Controls.Add(checkBox3)
            Controls.Add(checkBox2)
            Controls.Add(checkBox1)
            Controls.Add(button1)
            Controls.Add(textBox2)
            Controls.Add(label1)
            Controls.Add(textBox1)
            Controls.Add(label2)
            Margin = New Windows.Forms.Padding(2)
            Name = "FormStart"
            Text = "Nuke"
            AddHandler Load, AddressOf FormStart_Load
            ResumeLayout(False)
            PerformLayout()
        End Sub

#End Region

        Private textBox1 As Windows.Forms.TextBox
        Private label2 As Windows.Forms.Label
        Private label1 As Windows.Forms.Label
        Private textBox2 As Windows.Forms.TextBox
        Private button1 As Windows.Forms.Button
        Private checkBox1 As Windows.Forms.CheckBox
        Private checkBox2 As Windows.Forms.CheckBox
        Private checkBox3 As Windows.Forms.CheckBox
        Private checkBox4 As Windows.Forms.CheckBox
        Private checkBox5 As Windows.Forms.CheckBox
        Private textBox3 As Windows.Forms.TextBox
        Private checkBox6 As Windows.Forms.CheckBox
        Private textBox4 As Windows.Forms.TextBox
        Private label4 As Windows.Forms.Label
        Private textBox5 As Windows.Forms.TextBox
        Private label3 As Windows.Forms.Label
    End Class
End Namespace
