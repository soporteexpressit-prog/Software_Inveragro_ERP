<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnviarCorreoArchivoOC
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.PrimerFormato = New System.Windows.Forms.TabPage()
        Me.TxtDestinatario1 = New System.Windows.Forms.TextBox()
        Me.LblRemitente1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtPieCorreo = New System.Windows.Forms.RichTextBox()
        Me.TxtCuerpoCorreo = New System.Windows.Forms.RichTextBox()
        Me.TxtEncabezadoCorreo = New System.Windows.Forms.RichTextBox()
        Me.SegundoFormato = New System.Windows.Forms.TabPage()
        Me.TxtDestinatario2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSubirArchivo = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtCuerpoCorreoArchivo = New System.Windows.Forms.RichTextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LblRemitente2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnEnviarCorreo = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.PrimerFormato.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SegundoFormato.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(624, 456)
        Me.Panel2.TabIndex = 11
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.PrimerFormato)
        Me.TabControl1.Controls.Add(Me.SegundoFormato)
        Me.TabControl1.Location = New System.Drawing.Point(15, 43)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(597, 399)
        Me.TabControl1.TabIndex = 198
        '
        'PrimerFormato
        '
        Me.PrimerFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.PrimerFormato.Controls.Add(Me.TxtDestinatario1)
        Me.PrimerFormato.Controls.Add(Me.LblRemitente1)
        Me.PrimerFormato.Controls.Add(Me.Label4)
        Me.PrimerFormato.Controls.Add(Me.Label5)
        Me.PrimerFormato.Controls.Add(Me.GroupBox3)
        Me.PrimerFormato.Location = New System.Drawing.Point(4, 22)
        Me.PrimerFormato.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PrimerFormato.Name = "PrimerFormato"
        Me.PrimerFormato.Size = New System.Drawing.Size(589, 373)
        Me.PrimerFormato.TabIndex = 4
        Me.PrimerFormato.Text = "Primer Formato"
        '
        'TxtDestinatario1
        '
        Me.TxtDestinatario1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtDestinatario1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestinatario1.Location = New System.Drawing.Point(159, 46)
        Me.TxtDestinatario1.MaxLength = 50
        Me.TxtDestinatario1.Name = "TxtDestinatario1"
        Me.TxtDestinatario1.Size = New System.Drawing.Size(321, 24)
        Me.TxtDestinatario1.TabIndex = 184
        Me.TxtDestinatario1.TabStop = False
        '
        'LblRemitente1
        '
        Me.LblRemitente1.AutoSize = True
        Me.LblRemitente1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemitente1.ForeColor = System.Drawing.Color.Black
        Me.LblRemitente1.Location = New System.Drawing.Point(159, 20)
        Me.LblRemitente1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRemitente1.Name = "LblRemitente1"
        Me.LblRemitente1.Size = New System.Drawing.Size(33, 14)
        Me.LblRemitente1.TabIndex = 183
        Me.LblRemitente1.Text = "- - -"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(56, 49)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 14)
        Me.Label4.TabIndex = 182
        Me.Label4.Text = "Destinatario :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(67, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 14)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = "Remitente :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtPieCorreo)
        Me.GroupBox3.Controls.Add(Me.TxtCuerpoCorreo)
        Me.GroupBox3.Controls.Add(Me.TxtEncabezadoCorreo)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 96)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(561, 260)
        Me.GroupBox3.TabIndex = 180
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "INFORMACIÓN DEL MENSAJE"
        '
        'TxtPieCorreo
        '
        Me.TxtPieCorreo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPieCorreo.Location = New System.Drawing.Point(4, 170)
        Me.TxtPieCorreo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtPieCorreo.MaxLength = 10000
        Me.TxtPieCorreo.Name = "TxtPieCorreo"
        Me.TxtPieCorreo.Size = New System.Drawing.Size(554, 87)
        Me.TxtPieCorreo.TabIndex = 174
        Me.TxtPieCorreo.Text = ""
        '
        'TxtCuerpoCorreo
        '
        Me.TxtCuerpoCorreo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuerpoCorreo.Location = New System.Drawing.Point(4, 77)
        Me.TxtCuerpoCorreo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCuerpoCorreo.MaxLength = 10000
        Me.TxtCuerpoCorreo.Name = "TxtCuerpoCorreo"
        Me.TxtCuerpoCorreo.Size = New System.Drawing.Size(554, 90)
        Me.TxtCuerpoCorreo.TabIndex = 173
        Me.TxtCuerpoCorreo.Text = ""
        '
        'TxtEncabezadoCorreo
        '
        Me.TxtEncabezadoCorreo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEncabezadoCorreo.Location = New System.Drawing.Point(4, 24)
        Me.TxtEncabezadoCorreo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtEncabezadoCorreo.MaxLength = 10000
        Me.TxtEncabezadoCorreo.Name = "TxtEncabezadoCorreo"
        Me.TxtEncabezadoCorreo.Size = New System.Drawing.Size(554, 51)
        Me.TxtEncabezadoCorreo.TabIndex = 172
        Me.TxtEncabezadoCorreo.Text = ""
        '
        'SegundoFormato
        '
        Me.SegundoFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.SegundoFormato.Controls.Add(Me.TxtDestinatario2)
        Me.SegundoFormato.Controls.Add(Me.GroupBox2)
        Me.SegundoFormato.Controls.Add(Me.GroupBox1)
        Me.SegundoFormato.Controls.Add(Me.Label28)
        Me.SegundoFormato.Controls.Add(Me.LblRemitente2)
        Me.SegundoFormato.Controls.Add(Me.Label1)
        Me.SegundoFormato.Location = New System.Drawing.Point(4, 22)
        Me.SegundoFormato.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SegundoFormato.Name = "SegundoFormato"
        Me.SegundoFormato.Size = New System.Drawing.Size(589, 373)
        Me.SegundoFormato.TabIndex = 5
        Me.SegundoFormato.Text = "Segundo Formato"
        '
        'TxtDestinatario2
        '
        Me.TxtDestinatario2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtDestinatario2.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestinatario2.Location = New System.Drawing.Point(141, 49)
        Me.TxtDestinatario2.MaxLength = 50
        Me.TxtDestinatario2.Name = "TxtDestinatario2"
        Me.TxtDestinatario2.Size = New System.Drawing.Size(321, 24)
        Me.TxtDestinatario2.TabIndex = 179
        Me.TxtDestinatario2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSubirArchivo)
        Me.GroupBox2.Controls.Add(Me.txtArchivo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 215)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(568, 88)
        Me.GroupBox2.TabIndex = 175
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ADJUNTAR ARCHIVO (OPCIONAL)"
        '
        'btnSubirArchivo
        '
        Me.btnSubirArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubirArchivo.Location = New System.Drawing.Point(371, 36)
        Me.btnSubirArchivo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSubirArchivo.Name = "btnSubirArchivo"
        Me.btnSubirArchivo.Size = New System.Drawing.Size(109, 28)
        Me.btnSubirArchivo.TabIndex = 177
        Me.btnSubirArchivo.Text = "Subir Archivo"
        Me.btnSubirArchivo.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArchivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.Location = New System.Drawing.Point(105, 41)
        Me.txtArchivo.MaxLength = 50
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(253, 21)
        Me.txtArchivo.TabIndex = 176
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(39, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Archivo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtCuerpoCorreoArchivo)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 99)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(568, 112)
        Me.GroupBox1.TabIndex = 160
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "INFORMACIÓN DEL MENSAJE"
        '
        'TxtCuerpoCorreoArchivo
        '
        Me.TxtCuerpoCorreoArchivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuerpoCorreoArchivo.Location = New System.Drawing.Point(4, 27)
        Me.TxtCuerpoCorreoArchivo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TxtCuerpoCorreoArchivo.MaxLength = 1000
        Me.TxtCuerpoCorreoArchivo.Name = "TxtCuerpoCorreoArchivo"
        Me.TxtCuerpoCorreoArchivo.Size = New System.Drawing.Size(561, 80)
        Me.TxtCuerpoCorreoArchivo.TabIndex = 174
        Me.TxtCuerpoCorreoArchivo.Text = "BUENAS"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(49, 23)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(80, 14)
        Me.Label28.TabIndex = 161
        Me.Label28.Text = "Remitente :"
        '
        'LblRemitente2
        '
        Me.LblRemitente2.AutoSize = True
        Me.LblRemitente2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemitente2.ForeColor = System.Drawing.Color.Black
        Me.LblRemitente2.Location = New System.Drawing.Point(142, 23)
        Me.LblRemitente2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRemitente2.Name = "LblRemitente2"
        Me.LblRemitente2.Size = New System.Drawing.Size(33, 14)
        Me.LblRemitente2.TabIndex = 163
        Me.LblRemitente2.Text = "- - -"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 14)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Destinatario :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnEnviarCorreo, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(624, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnEnviarCorreo
        '
        Me.BtnEnviarCorreo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnviarCorreo.ForeColor = System.Drawing.Color.White
        Me.BtnEnviarCorreo.Image = Global.Formularios.My.Resources.Resources.enviar
        Me.BtnEnviarCorreo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEnviarCorreo.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnEnviarCorreo.Name = "BtnEnviarCorreo"
        Me.BtnEnviarCorreo.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnEnviarCorreo.Size = New System.Drawing.Size(126, 28)
        Me.BtnEnviarCorreo.Text = "Enviar Correo"
        Me.BtnEnviarCorreo.ToolTipText = "Enviar"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.ForeColor = System.Drawing.Color.White
        Me.BtnCerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.BtnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCerrar.Size = New System.Drawing.Size(66, 28)
        Me.BtnCerrar.Text = "Salir"
        Me.BtnCerrar.ToolTipText = "Cerrar"
        '
        'FrmEnviarCorreoArchivoOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 456)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEnviarCorreoArchivoOC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ENVIAR CORREO"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.PrimerFormato.ResumeLayout(False)
        Me.PrimerFormato.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.SegundoFormato.ResumeLayout(False)
        Me.SegundoFormato.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtDestinatario2 As TextBox
    Friend WithEvents LblRemitente2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtCuerpoCorreoArchivo As RichTextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnEnviarCorreo As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSubirArchivo As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents PrimerFormato As TabPage
    Friend WithEvents SegundoFormato As TabPage
    Friend WithEvents TxtDestinatario1 As TextBox
    Friend WithEvents LblRemitente1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TxtPieCorreo As RichTextBox
    Friend WithEvents TxtCuerpoCorreo As RichTextBox
    Friend WithEvents TxtEncabezadoCorreo As RichTextBox
End Class
