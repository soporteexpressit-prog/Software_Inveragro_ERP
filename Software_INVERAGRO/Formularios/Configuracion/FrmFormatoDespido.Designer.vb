<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormatoDespido
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.btnParrafo02 = New System.Windows.Forms.Button()
        Me.btnParrafo01 = New System.Windows.Forms.Button()
        Me.btnEditarLogo = New System.Windows.Forms.Button()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblParrafo02 = New System.Windows.Forms.Label()
        Me.lblParrafo01 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBoxLogoDespido = New System.Windows.Forms.PictureBox()
        Me.PanelContenedor.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.PictureBoxLogoDespido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelContenedor
        '
        Me.PanelContenedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.PanelContenedor.Controls.Add(Me.UltraGroupBox2)
        Me.PanelContenedor.Controls.Add(Me.UltraGroupBox1)
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.Location = New System.Drawing.Point(0, 0)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(1670, 1010)
        Me.PanelContenedor.TabIndex = 10
        '
        'UltraGroupBox2
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox2.Appearance = Appearance1
        Me.UltraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox2.Controls.Add(Me.btnParrafo02)
        Me.UltraGroupBox2.Controls.Add(Me.btnParrafo01)
        Me.UltraGroupBox2.Controls.Add(Me.btnEditarLogo)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox2.HeaderAppearance = Appearance2
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(1251, 15)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(388, 958)
        Me.UltraGroupBox2.TabIndex = 161
        Me.UltraGroupBox2.Text = "OPCIONES DE EDICIÓN"
        '
        'btnParrafo02
        '
        Me.btnParrafo02.BackColor = System.Drawing.Color.DarkGreen
        Me.btnParrafo02.ForeColor = System.Drawing.Color.White
        Me.btnParrafo02.Location = New System.Drawing.Point(54, 573)
        Me.btnParrafo02.Name = "btnParrafo02"
        Me.btnParrafo02.Size = New System.Drawing.Size(277, 67)
        Me.btnParrafo02.TabIndex = 2
        Me.btnParrafo02.Text = "EDITAR PÁRRAFO 02"
        Me.btnParrafo02.UseVisualStyleBackColor = False
        '
        'btnParrafo01
        '
        Me.btnParrafo01.BackColor = System.Drawing.Color.DarkGreen
        Me.btnParrafo01.ForeColor = System.Drawing.Color.White
        Me.btnParrafo01.Location = New System.Drawing.Point(54, 429)
        Me.btnParrafo01.Name = "btnParrafo01"
        Me.btnParrafo01.Size = New System.Drawing.Size(277, 67)
        Me.btnParrafo01.TabIndex = 1
        Me.btnParrafo01.Text = "EDITAR PÁRRAFO 01"
        Me.btnParrafo01.UseVisualStyleBackColor = False
        '
        'btnEditarLogo
        '
        Me.btnEditarLogo.BackColor = System.Drawing.Color.DarkGreen
        Me.btnEditarLogo.ForeColor = System.Drawing.Color.White
        Me.btnEditarLogo.Location = New System.Drawing.Point(54, 292)
        Me.btnEditarLogo.Name = "btnEditarLogo"
        Me.btnEditarLogo.Size = New System.Drawing.Size(277, 67)
        Me.btnEditarLogo.TabIndex = 0
        Me.btnEditarLogo.Text = "EDITAR LOGO"
        Me.btnEditarLogo.UseVisualStyleBackColor = False
        '
        'UltraGroupBox1
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.Color.White
        Me.UltraGroupBox1.Appearance = Appearance3
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.lblParrafo02)
        Me.UltraGroupBox1.Controls.Add(Me.lblParrafo01)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.Controls.Add(Me.Label5)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.PictureBoxLogoDespido)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.HeaderAppearance = Appearance4
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(31, 15)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1179, 958)
        Me.UltraGroupBox1.TabIndex = 160
        Me.UltraGroupBox1.Text = "FORMATO DESPIDO"
        '
        'lblParrafo02
        '
        Me.lblParrafo02.AutoSize = True
        Me.lblParrafo02.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParrafo02.Location = New System.Drawing.Point(58, 643)
        Me.lblParrafo02.Name = "lblParrafo02"
        Me.lblParrafo02.Size = New System.Drawing.Size(123, 22)
        Me.lblParrafo02.TabIndex = 8
        Me.lblParrafo02.Text = "PARRAFO 02"
        '
        'lblParrafo01
        '
        Me.lblParrafo01.AutoSize = True
        Me.lblParrafo01.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParrafo01.Location = New System.Drawing.Point(58, 473)
        Me.lblParrafo01.Name = "lblParrafo01"
        Me.lblParrafo01.Size = New System.Drawing.Size(123, 22)
        Me.lblParrafo01.TabIndex = 7
        Me.lblParrafo01.Text = "PARRAFO 01"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(54, 890)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 22)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Atentamente"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 379)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 22)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Presente.-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(58, 348)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nombre/s Trabajador/es"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 319)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 22)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Señor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(262, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ciudad, 00 de mes del 0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(383, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CARTA DE PREAVISO DE DESPIDO"
        '
        'PictureBoxLogoDespido
        '
        Me.PictureBoxLogoDespido.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.PictureBoxLogoDespido.Location = New System.Drawing.Point(45, 59)
        Me.PictureBoxLogoDespido.Name = "PictureBoxLogoDespido"
        Me.PictureBoxLogoDespido.Size = New System.Drawing.Size(409, 112)
        Me.PictureBoxLogoDespido.TabIndex = 0
        Me.PictureBoxLogoDespido.TabStop = False
        '
        'FrmFormatoDespido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1670, 1010)
        Me.Controls.Add(Me.PanelContenedor)
        Me.Name = "FrmFormatoDespido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FORMATO DESPIDO"
        Me.PanelContenedor.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.PictureBoxLogoDespido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContenedor As Panel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnParrafo02 As Button
    Friend WithEvents btnParrafo01 As Button
    Friend WithEvents btnEditarLogo As Button
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblParrafo02 As Label
    Friend WithEvents lblParrafo01 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBoxLogoDespido As PictureBox
End Class
