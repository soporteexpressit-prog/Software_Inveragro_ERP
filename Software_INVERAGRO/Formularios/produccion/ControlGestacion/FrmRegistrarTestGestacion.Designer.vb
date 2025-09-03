<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistrarTestGestacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrarTestGestacion))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnBloquearFecha = New System.Windows.Forms.Button()
        Me.BtnBuscarCerda = New System.Windows.Forms.Button()
        Me.LblSeleccionarCerda = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnSeleccionarEvidencia = New System.Windows.Forms.Button()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.DtpFechaPerdida = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCodArete = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBloquearResultado = New System.Windows.Forms.Button()
        Me.ChkEnviarCamal = New System.Windows.Forms.CheckBox()
        Me.LblMuertos = New System.Windows.Forms.Label()
        Me.NumTotalMuertos = New System.Windows.Forms.NumericUpDown()
        Me.CmbResultado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumTotalMuertos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnBloquearFecha)
        Me.Panel2.Controls.Add(Me.BtnBuscarCerda)
        Me.Panel2.Controls.Add(Me.LblSeleccionarCerda)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.DtpFechaPerdida)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LblCodArete)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(837, 732)
        Me.Panel2.TabIndex = 9
        '
        'BtnBloquearFecha
        '
        Me.BtnBloquearFecha.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearFecha.AutoSize = True
        Me.BtnBloquearFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearFecha.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearFecha.Location = New System.Drawing.Point(748, 148)
        Me.BtnBloquearFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearFecha.Name = "BtnBloquearFecha"
        Me.BtnBloquearFecha.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearFecha.TabIndex = 219
        Me.BtnBloquearFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearFecha.UseVisualStyleBackColor = True
        '
        'BtnBuscarCerda
        '
        Me.BtnBuscarCerda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCerda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarCerda.Image = CType(resources.GetObject("BtnBuscarCerda.Image"), System.Drawing.Image)
        Me.BtnBuscarCerda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCerda.Location = New System.Drawing.Point(736, 73)
        Me.BtnBuscarCerda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarCerda.Name = "BtnBuscarCerda"
        Me.BtnBuscarCerda.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarCerda.TabIndex = 218
        Me.BtnBuscarCerda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCerda.UseVisualStyleBackColor = True
        '
        'LblSeleccionarCerda
        '
        Me.LblSeleccionarCerda.AutoSize = True
        Me.LblSeleccionarCerda.BackColor = System.Drawing.Color.Transparent
        Me.LblSeleccionarCerda.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionarCerda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblSeleccionarCerda.Location = New System.Drawing.Point(544, 84)
        Me.LblSeleccionarCerda.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblSeleccionarCerda.Name = "LblSeleccionarCerda"
        Me.LblSeleccionarCerda.Size = New System.Drawing.Size(183, 22)
        Me.LblSeleccionarCerda.TabIndex = 217
        Me.LblSeleccionarCerda.Text = "Seleccione Cerda"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnSeleccionarEvidencia)
        Me.GroupBox2.Controls.Add(Me.picFoto)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 448)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(806, 268)
        Me.GroupBox2.TabIndex = 181
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Evidencia de Aborto"
        '
        'BtnSeleccionarEvidencia
        '
        Me.BtnSeleccionarEvidencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnSeleccionarEvidencia.Location = New System.Drawing.Point(311, 219)
        Me.BtnSeleccionarEvidencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.BtnSeleccionarEvidencia.Name = "BtnSeleccionarEvidencia"
        Me.BtnSeleccionarEvidencia.Size = New System.Drawing.Size(202, 40)
        Me.BtnSeleccionarEvidencia.TabIndex = 198
        Me.BtnSeleccionarEvidencia.Text = "Subir Foto"
        Me.BtnSeleccionarEvidencia.UseVisualStyleBackColor = True
        '
        'picFoto
        '
        Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFoto.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picFoto.Location = New System.Drawing.Point(252, 27)
        Me.picFoto.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(321, 181)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFoto.TabIndex = 197
        Me.picFoto.TabStop = False
        '
        'DtpFechaPerdida
        '
        Me.DtpFechaPerdida.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaPerdida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaPerdida.Location = New System.Drawing.Point(558, 152)
        Me.DtpFechaPerdida.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFechaPerdida.Name = "DtpFechaPerdida"
        Me.DtpFechaPerdida.Size = New System.Drawing.Size(185, 28)
        Me.DtpFechaPerdida.TabIndex = 179
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(350, 155)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 22)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Fecha de Pérdida :"
        '
        'LblCodArete
        '
        Me.LblCodArete.AutoSize = True
        Me.LblCodArete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblCodArete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodArete.ForeColor = System.Drawing.Color.Black
        Me.LblCodArete.Location = New System.Drawing.Point(66, 81)
        Me.LblCodArete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCodArete.Name = "LblCodArete"
        Me.LblCodArete.Size = New System.Drawing.Size(25, 29)
        Me.LblCodArete.TabIndex = 178
        Me.LblCodArete.Text = "-"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBloquearResultado)
        Me.GroupBox1.Controls.Add(Me.ChkEnviarCamal)
        Me.GroupBox1.Controls.Add(Me.LblMuertos)
        Me.GroupBox1.Controls.Add(Me.NumTotalMuertos)
        Me.GroupBox1.Controls.Add(Me.CmbResultado)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(806, 242)
        Me.GroupBox1.TabIndex = 160
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de pérdida"
        '
        'BtnBloquearResultado
        '
        Me.BtnBloquearResultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearResultado.AutoSize = True
        Me.BtnBloquearResultado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearResultado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearResultado.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearResultado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearResultado.Location = New System.Drawing.Point(420, 50)
        Me.BtnBloquearResultado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearResultado.Name = "BtnBloquearResultado"
        Me.BtnBloquearResultado.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearResultado.TabIndex = 220
        Me.BtnBloquearResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearResultado.UseVisualStyleBackColor = True
        '
        'ChkEnviarCamal
        '
        Me.ChkEnviarCamal.AutoSize = True
        Me.ChkEnviarCamal.Location = New System.Drawing.Point(642, 192)
        Me.ChkEnviarCamal.Name = "ChkEnviarCamal"
        Me.ChkEnviarCamal.Size = New System.Drawing.Size(141, 24)
        Me.ChkEnviarCamal.TabIndex = 199
        Me.ChkEnviarCamal.Text = "Enviar a Camal"
        Me.ChkEnviarCamal.UseVisualStyleBackColor = True
        '
        'LblMuertos
        '
        Me.LblMuertos.AutoSize = True
        Me.LblMuertos.BackColor = System.Drawing.Color.Transparent
        Me.LblMuertos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMuertos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblMuertos.Location = New System.Drawing.Point(515, 57)
        Me.LblMuertos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMuertos.Name = "LblMuertos"
        Me.LblMuertos.Size = New System.Drawing.Size(137, 22)
        Me.LblMuertos.TabIndex = 184
        Me.LblMuertos.Text = "N° Muertos :"
        '
        'NumTotalMuertos
        '
        Me.NumTotalMuertos.Location = New System.Drawing.Point(661, 55)
        Me.NumTotalMuertos.Name = "NumTotalMuertos"
        Me.NumTotalMuertos.Size = New System.Drawing.Size(83, 26)
        Me.NumTotalMuertos.TabIndex = 183
        '
        'CmbResultado
        '
        Me.CmbResultado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbResultado.FormattingEnabled = True
        Me.CmbResultado.Items.AddRange(New Object() {"REPETICIÓN CELO", "FALSA PREÑEZ", "ABORTO"})
        Me.CmbResultado.Location = New System.Drawing.Point(194, 54)
        Me.CmbResultado.Name = "CmbResultado"
        Me.CmbResultado.Size = New System.Drawing.Size(219, 28)
        Me.CmbResultado.TabIndex = 179
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(67, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 22)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Resultado:"
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservacion.Location = New System.Drawing.Point(194, 117)
        Me.TxtObservacion.MaxLength = 200
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(404, 99)
        Me.TxtObservacion.TabIndex = 172
        Me.TxtObservacion.Text = "NINGUNA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 117)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 22)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Observación :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(837, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.ToolTipText = "Guardar"
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
        Me.BtnCerrar.Size = New System.Drawing.Size(84, 30)
        Me.BtnCerrar.Text = "Salir"
        Me.BtnCerrar.ToolTipText = "Cerrar"
        '
        'FrmRegistrarTestGestacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 732)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistrarTestGestacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRAR PÉRDIDA REPRODUCTIVA"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumTotalMuertos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtObservacion As RichTextBox
    Friend WithEvents LblCodArete As Label
    Friend WithEvents CmbResultado As ComboBox
    Friend WithEvents DtpFechaPerdida As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents LblMuertos As Label
    Friend WithEvents NumTotalMuertos As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnSeleccionarEvidencia As Button
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents BtnBuscarCerda As Button
    Friend WithEvents LblSeleccionarCerda As Label
    Friend WithEvents ChkEnviarCamal As CheckBox
    Friend WithEvents BtnBloquearFecha As Button
    Friend WithEvents BtnBloquearResultado As Button
End Class
