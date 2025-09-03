<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMandarCamalAnimal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMandarCamalAnimal))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblCodArete = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnMotivo = New System.Windows.Forms.Button()
        Me.BtnBloquearFecha = New System.Windows.Forms.Button()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.LblPeso = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnSeleccionarEvidencia = New System.Windows.Forms.Button()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.BtnMotivoCamal = New System.Windows.Forms.Button()
        Me.TxtMotivoMortalidad = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.CbxChanchillaEngorde = New System.Windows.Forms.CheckBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.CbxChanchillaEngorde)
        Me.Panel2.Controls.Add(Me.LblCodArete)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(908, 544)
        Me.Panel2.TabIndex = 11
        '
        'LblCodArete
        '
        Me.LblCodArete.AutoSize = True
        Me.LblCodArete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblCodArete.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodArete.ForeColor = System.Drawing.Color.Black
        Me.LblCodArete.Location = New System.Drawing.Point(111, 79)
        Me.LblCodArete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCodArete.Name = "LblCodArete"
        Me.LblCodArete.Size = New System.Drawing.Size(22, 25)
        Me.LblCodArete.TabIndex = 180
        Me.LblCodArete.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(26, 80)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 22)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "Arete:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnMotivo)
        Me.GroupBox1.Controls.Add(Me.BtnBloquearFecha)
        Me.GroupBox1.Controls.Add(Me.TxtPeso)
        Me.GroupBox1.Controls.Add(Me.LblPeso)
        Me.GroupBox1.Controls.Add(Me.DtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnSeleccionarEvidencia)
        Me.GroupBox1.Controls.Add(Me.picFoto)
        Me.GroupBox1.Controls.Add(Me.BtnMotivoCamal)
        Me.GroupBox1.Controls.Add(Me.TxtMotivoMortalidad)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(881, 406)
        Me.GroupBox1.TabIndex = 160
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de envío a camal"
        '
        'BtnMotivo
        '
        Me.BtnMotivo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMotivo.AutoSize = True
        Me.BtnMotivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMotivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMotivo.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnMotivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMotivo.Location = New System.Drawing.Point(180, 52)
        Me.BtnMotivo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnMotivo.Name = "BtnMotivo"
        Me.BtnMotivo.Size = New System.Drawing.Size(36, 37)
        Me.BtnMotivo.TabIndex = 221
        Me.BtnMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMotivo.UseVisualStyleBackColor = True
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
        Me.BtnBloquearFecha.Location = New System.Drawing.Point(833, 52)
        Me.BtnBloquearFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearFecha.Name = "BtnBloquearFecha"
        Me.BtnBloquearFecha.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearFecha.TabIndex = 220
        Me.BtnBloquearFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearFecha.UseVisualStyleBackColor = True
        '
        'TxtPeso
        '
        Me.TxtPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPeso.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPeso.Location = New System.Drawing.Point(180, 360)
        Me.TxtPeso.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPeso.MaxLength = 50
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(124, 28)
        Me.TxtPeso.TabIndex = 206
        Me.TxtPeso.TabStop = False
        Me.TxtPeso.Text = "0"
        '
        'LblPeso
        '
        Me.LblPeso.AutoSize = True
        Me.LblPeso.BackColor = System.Drawing.Color.Transparent
        Me.LblPeso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblPeso.Location = New System.Drawing.Point(97, 363)
        Me.LblPeso.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPeso.Name = "LblPeso"
        Me.LblPeso.Size = New System.Drawing.Size(71, 22)
        Me.LblPeso.TabIndex = 205
        Me.LblPeso.Text = "Peso :"
        '
        'DtpFecha
        '
        Me.DtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(654, 56)
        Me.DtpFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(171, 28)
        Me.DtpFecha.TabIndex = 204
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(562, 59)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 22)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "Fecha :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(19, 214)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 22)
        Me.Label2.TabIndex = 201
        Me.Label2.Text = "Observación :"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(23, 251)
        Me.txtDescripcion.MaxLength = 150
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(479, 86)
        Me.txtDescripcion.TabIndex = 200
        Me.txtDescripcion.Text = "NINGUNO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(525, 117)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 22)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Evidencia :"
        '
        'BtnSeleccionarEvidencia
        '
        Me.BtnSeleccionarEvidencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnSeleccionarEvidencia.Location = New System.Drawing.Point(607, 348)
        Me.BtnSeleccionarEvidencia.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.BtnSeleccionarEvidencia.Name = "BtnSeleccionarEvidencia"
        Me.BtnSeleccionarEvidencia.Size = New System.Drawing.Size(249, 40)
        Me.BtnSeleccionarEvidencia.TabIndex = 198
        Me.BtnSeleccionarEvidencia.Text = "Subir Foto"
        Me.BtnSeleccionarEvidencia.UseVisualStyleBackColor = True
        '
        'picFoto
        '
        Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFoto.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picFoto.Location = New System.Drawing.Point(607, 157)
        Me.picFoto.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(249, 180)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFoto.TabIndex = 197
        Me.picFoto.TabStop = False
        '
        'BtnMotivoCamal
        '
        Me.BtnMotivoCamal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMotivoCamal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMotivoCamal.Image = CType(resources.GetObject("BtnMotivoCamal.Image"), System.Drawing.Image)
        Me.BtnMotivoCamal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMotivoCamal.Location = New System.Drawing.Point(119, 48)
        Me.BtnMotivoCamal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnMotivoCamal.Name = "BtnMotivoCamal"
        Me.BtnMotivoCamal.Size = New System.Drawing.Size(48, 45)
        Me.BtnMotivoCamal.TabIndex = 196
        Me.BtnMotivoCamal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMotivoCamal.UseVisualStyleBackColor = True
        '
        'TxtMotivoMortalidad
        '
        Me.TxtMotivoMortalidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivoMortalidad.Location = New System.Drawing.Point(23, 101)
        Me.TxtMotivoMortalidad.MaxLength = 200
        Me.TxtMotivoMortalidad.Name = "TxtMotivoMortalidad"
        Me.TxtMotivoMortalidad.Size = New System.Drawing.Size(479, 90)
        Me.TxtMotivoMortalidad.TabIndex = 195
        Me.TxtMotivoMortalidad.TabStop = False
        Me.TxtMotivoMortalidad.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(19, 59)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 22)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "Motivo :"
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
        Me.ToolStrip1.Size = New System.Drawing.Size(908, 40)
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
        'CbxChanchillaEngorde
        '
        Me.CbxChanchillaEngorde.AutoSize = True
        Me.CbxChanchillaEngorde.Location = New System.Drawing.Point(689, 79)
        Me.CbxChanchillaEngorde.Name = "CbxChanchillaEngorde"
        Me.CbxChanchillaEngorde.Size = New System.Drawing.Size(195, 24)
        Me.CbxChanchillaEngorde.TabIndex = 181
        Me.CbxChanchillaEngorde.Text = "Chanchilla de Engorde"
        Me.CbxChanchillaEngorde.UseVisualStyleBackColor = True
        '
        'FrmMandarCamalAnimal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 544)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMandarCamalAnimal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRAR ENVIO A CAMAL"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents BtnMotivoCamal As Button
    Friend WithEvents TxtMotivoMortalidad As RichTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BtnSeleccionarEvidencia As Button
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescripcion As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DtpFecha As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtPeso As TextBox
    Friend WithEvents LblPeso As Label
    Friend WithEvents BtnBloquearFecha As Button
    Friend WithEvents BtnMotivo As Button
    Friend WithEvents LblCodArete As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents CbxChanchillaEngorde As CheckBox
End Class
