<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegularizarSalidaConArete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegularizarSalidaConArete))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DtpFechaControl = New System.Windows.Forms.DateTimePicker()
        Me.LblPlantel = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtMotivoMortalidad = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnMotivoMortalidad = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.TxtAreteAnimal = New System.Windows.Forms.TextBox()
        Me.BtnBuscarAnimal = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TxtAreteAnimal)
        Me.Panel2.Controls.Add(Me.BtnBuscarAnimal)
        Me.Panel2.Controls.Add(Me.TxtObservacion)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtMotivoMortalidad)
        Me.Panel2.Controls.Add(Me.BtnMotivoMortalidad)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.DtpFechaControl)
        Me.Panel2.Controls.Add(Me.LblPlantel)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(586, 276)
        Me.Panel2.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(375, 117)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 14)
        Me.Label12.TabIndex = 216
        Me.Label12.Text = "Fecha :"
        '
        'DtpFechaControl
        '
        Me.DtpFechaControl.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaControl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaControl.Location = New System.Drawing.Point(442, 114)
        Me.DtpFechaControl.Name = "DtpFechaControl"
        Me.DtpFechaControl.Size = New System.Drawing.Size(115, 21)
        Me.DtpFechaControl.TabIndex = 217
        '
        'LblPlantel
        '
        Me.LblPlantel.AutoSize = True
        Me.LblPlantel.BackColor = System.Drawing.Color.Transparent
        Me.LblPlantel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlantel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblPlantel.Location = New System.Drawing.Point(29, 59)
        Me.LblPlantel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPlantel.Name = "LblPlantel"
        Me.LblPlantel.Size = New System.Drawing.Size(88, 18)
        Me.LblPlantel.TabIndex = 187
        Me.LblPlantel.Text = "PLANTEL"
        Me.LblPlantel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(586, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BackgroundWorker1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(223, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(351, 13)
        Me.Label1.TabIndex = 222
        Me.Label1.Text = "Solo lista las VACIAS, VIVOS y estado de venta PENDIENTE"
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservacion.Location = New System.Drawing.Point(41, 196)
        Me.TxtObservacion.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtObservacion.MaxLength = 200
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(204, 53)
        Me.TxtObservacion.TabIndex = 227
        Me.TxtObservacion.Text = "NINGUNA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(41, 172)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 226
        Me.Label2.Text = "Observación :"
        '
        'TxtMotivoMortalidad
        '
        Me.TxtMotivoMortalidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivoMortalidad.Location = New System.Drawing.Point(312, 196)
        Me.TxtMotivoMortalidad.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMotivoMortalidad.MaxLength = 200
        Me.TxtMotivoMortalidad.Name = "TxtMotivoMortalidad"
        Me.TxtMotivoMortalidad.Size = New System.Drawing.Size(255, 53)
        Me.TxtMotivoMortalidad.TabIndex = 225
        Me.TxtMotivoMortalidad.TabStop = False
        Me.TxtMotivoMortalidad.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(312, 172)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 14)
        Me.Label9.TabIndex = 223
        Me.Label9.Text = "Motivo :"
        '
        'BtnMotivoMortalidad
        '
        Me.BtnMotivoMortalidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMotivoMortalidad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMotivoMortalidad.Image = CType(resources.GetObject("BtnMotivoMortalidad.Image"), System.Drawing.Image)
        Me.BtnMotivoMortalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMotivoMortalidad.Location = New System.Drawing.Point(378, 165)
        Me.BtnMotivoMortalidad.Name = "BtnMotivoMortalidad"
        Me.BtnMotivoMortalidad.Size = New System.Drawing.Size(32, 29)
        Me.BtnMotivoMortalidad.TabIndex = 224
        Me.BtnMotivoMortalidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMotivoMortalidad.UseVisualStyleBackColor = True
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
        Me.BtnGuardar.Size = New System.Drawing.Size(89, 28)
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
        Me.BtnCerrar.Size = New System.Drawing.Size(66, 28)
        Me.BtnCerrar.Text = "Salir"
        Me.BtnCerrar.ToolTipText = "Cerrar"
        '
        'TxtAreteAnimal
        '
        Me.TxtAreteAnimal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAreteAnimal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAreteAnimal.Location = New System.Drawing.Point(97, 114)
        Me.TxtAreteAnimal.MaxLength = 50
        Me.TxtAreteAnimal.Name = "TxtAreteAnimal"
        Me.TxtAreteAnimal.Size = New System.Drawing.Size(110, 21)
        Me.TxtAreteAnimal.TabIndex = 230
        '
        'BtnBuscarAnimal
        '
        Me.BtnBuscarAnimal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarAnimal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarAnimal.Image = CType(resources.GetObject("BtnBuscarAnimal.Image"), System.Drawing.Image)
        Me.BtnBuscarAnimal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarAnimal.Location = New System.Drawing.Point(213, 110)
        Me.BtnBuscarAnimal.Name = "BtnBuscarAnimal"
        Me.BtnBuscarAnimal.Size = New System.Drawing.Size(32, 29)
        Me.BtnBuscarAnimal.TabIndex = 229
        Me.BtnBuscarAnimal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarAnimal.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(41, 117)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 231
        Me.Label3.Text = "Arete :"
        '
        'FrmRegularizarSalidaConArete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 276)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegularizarSalidaConArete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGULARIZACION DE ANIMALES CODIFICADOS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents DtpFechaControl As DateTimePicker
    Friend WithEvents LblPlantel As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtObservacion As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtMotivoMortalidad As RichTextBox
    Friend WithEvents BtnMotivoMortalidad As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtAreteAnimal As TextBox
    Friend WithEvents BtnBuscarAnimal As Button
End Class
