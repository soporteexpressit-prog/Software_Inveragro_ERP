<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarHorarios
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHorasExtras = New System.Windows.Forms.TextBox()
        Me.txtPagoEspecial = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHorasLaboradas = New System.Windows.Forms.TextBox()
        Me.txtHorasRefrigerio = New System.Windows.Forms.TextBox()
        Me.cbHabilitarHEX = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxPermisoMedico = New System.Windows.Forms.ComboBox()
        Me.cbxInasistencia = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.dtpHoraEntrada = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraSalida = New System.Windows.Forms.DateTimePicker()
        Me.cbxAsistencia = New System.Windows.Forms.CheckBox()
        Me.txtObservacion = New System.Windows.Forms.RichTextBox()
        Me.cbxDescanso = New System.Windows.Forms.CheckBox()
        Me.cbxFeriado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHorasExtrasMarranas = New System.Windows.Forms.TextBox()
        Me.cbHorasExtrasMarranas = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(494, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 29)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hora Salida"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(57, 383)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Observación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(53, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Horas Extras"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(46, 346)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 18)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Pago Especial"
        '
        'txtHorasExtras
        '
        Me.txtHorasExtras.Location = New System.Drawing.Point(202, 232)
        Me.txtHorasExtras.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHorasExtras.Name = "txtHorasExtras"
        Me.txtHorasExtras.Size = New System.Drawing.Size(184, 26)
        Me.txtHorasExtras.TabIndex = 11
        '
        'txtPagoEspecial
        '
        Me.txtPagoEspecial.Location = New System.Drawing.Point(203, 347)
        Me.txtPagoEspecial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPagoEspecial.Name = "txtPagoEspecial"
        Me.txtPagoEspecial.Size = New System.Drawing.Size(427, 26)
        Me.txtPagoEspecial.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(17, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 18)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Horas Laboradas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(21, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 18)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Horas Refrigerio"
        '
        'txtHorasLaboradas
        '
        Me.txtHorasLaboradas.Location = New System.Drawing.Point(202, 159)
        Me.txtHorasLaboradas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHorasLaboradas.Name = "txtHorasLaboradas"
        Me.txtHorasLaboradas.Size = New System.Drawing.Size(427, 26)
        Me.txtHorasLaboradas.TabIndex = 15
        '
        'txtHorasRefrigerio
        '
        Me.txtHorasRefrigerio.Location = New System.Drawing.Point(202, 194)
        Me.txtHorasRefrigerio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHorasRefrigerio.Name = "txtHorasRefrigerio"
        Me.txtHorasRefrigerio.Size = New System.Drawing.Size(427, 26)
        Me.txtHorasRefrigerio.TabIndex = 16
        '
        'cbHabilitarHEX
        '
        Me.cbHabilitarHEX.Location = New System.Drawing.Point(392, 227)
        Me.cbHabilitarHEX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbHabilitarHEX.Name = "cbHabilitarHEX"
        Me.cbHabilitarHEX.Size = New System.Drawing.Size(22, 38)
        Me.cbHabilitarHEX.TabIndex = 18
        Me.cbHabilitarHEX.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(177, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(187, 29)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Hora Entrada"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(28, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Permiso Médico"
        '
        'cbxPermisoMedico
        '
        Me.cbxPermisoMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPermisoMedico.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.cbxPermisoMedico.FormattingEnabled = True
        Me.cbxPermisoMedico.Items.AddRange(New Object() {"SI", "NO"})
        Me.cbxPermisoMedico.Location = New System.Drawing.Point(202, 265)
        Me.cbxPermisoMedico.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxPermisoMedico.Name = "cbxPermisoMedico"
        Me.cbxPermisoMedico.Size = New System.Drawing.Size(427, 28)
        Me.cbxPermisoMedico.TabIndex = 22
        '
        'cbxInasistencia
        '
        Me.cbxInasistencia.AutoSize = True
        Me.cbxInasistencia.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cbxInasistencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.cbxInasistencia.Location = New System.Drawing.Point(516, 508)
        Me.cbxInasistencia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxInasistencia.Name = "cbxInasistencia"
        Me.cbxInasistencia.Size = New System.Drawing.Size(118, 22)
        Me.cbxInasistencia.TabIndex = 23
        Me.cbxInasistencia.Text = "No asistió"
        Me.cbxInasistencia.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(790, 40)
        Me.ToolStrip1.TabIndex = 199
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Size = New System.Drawing.Size(84, 30)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Cerrar"
        '
        'dtpHoraEntrada
        '
        Me.dtpHoraEntrada.CustomFormat = "HH:mm"
        Me.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraEntrada.Location = New System.Drawing.Point(202, 111)
        Me.dtpHoraEntrada.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpHoraEntrada.Name = "dtpHoraEntrada"
        Me.dtpHoraEntrada.ShowUpDown = True
        Me.dtpHoraEntrada.Size = New System.Drawing.Size(127, 26)
        Me.dtpHoraEntrada.TabIndex = 200
        Me.dtpHoraEntrada.Value = New Date(2024, 11, 28, 6, 0, 0, 0)
        '
        'dtpHoraSalida
        '
        Me.dtpHoraSalida.CustomFormat = "HH:mm"
        Me.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHoraSalida.Location = New System.Drawing.Point(497, 111)
        Me.dtpHoraSalida.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpHoraSalida.Name = "dtpHoraSalida"
        Me.dtpHoraSalida.ShowUpDown = True
        Me.dtpHoraSalida.Size = New System.Drawing.Size(122, 26)
        Me.dtpHoraSalida.TabIndex = 201
        Me.dtpHoraSalida.Value = New Date(2024, 11, 28, 17, 0, 0, 0)
        '
        'cbxAsistencia
        '
        Me.cbxAsistencia.AutoSize = True
        Me.cbxAsistencia.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cbxAsistencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.cbxAsistencia.Location = New System.Drawing.Point(516, 538)
        Me.cbxAsistencia.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxAsistencia.Name = "cbxAsistencia"
        Me.cbxAsistencia.Size = New System.Drawing.Size(90, 22)
        Me.cbxAsistencia.TabIndex = 202
        Me.cbxAsistencia.Text = "Asistió"
        Me.cbxAsistencia.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(203, 383)
        Me.txtObservacion.MaxLength = 200
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(428, 112)
        Me.txtObservacion.TabIndex = 203
        Me.txtObservacion.Text = ""
        '
        'cbxDescanso
        '
        Me.cbxDescanso.AutoSize = True
        Me.cbxDescanso.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cbxDescanso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.cbxDescanso.Location = New System.Drawing.Point(516, 568)
        Me.cbxDescanso.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxDescanso.Name = "cbxDescanso"
        Me.cbxDescanso.Size = New System.Drawing.Size(118, 22)
        Me.cbxDescanso.TabIndex = 204
        Me.cbxDescanso.Text = "Descanso"
        Me.cbxDescanso.UseVisualStyleBackColor = True
        '
        'cbxFeriado
        '
        Me.cbxFeriado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFeriado.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.cbxFeriado.FormattingEnabled = True
        Me.cbxFeriado.Items.AddRange(New Object() {"SIN ASIGNAR", "SI", "NO"})
        Me.cbxFeriado.Location = New System.Drawing.Point(203, 305)
        Me.cbxFeriado.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxFeriado.Name = "cbxFeriado"
        Me.cbxFeriado.Size = New System.Drawing.Size(427, 28)
        Me.cbxFeriado.TabIndex = 205
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(28, 309)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 18)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "Trabajo Feriado"
        '
        'txtHorasExtrasMarranas
        '
        Me.txtHorasExtrasMarranas.Location = New System.Drawing.Point(516, 232)
        Me.txtHorasExtrasMarranas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHorasExtrasMarranas.Name = "txtHorasExtrasMarranas"
        Me.txtHorasExtrasMarranas.ReadOnly = True
        Me.txtHorasExtrasMarranas.Size = New System.Drawing.Size(113, 26)
        Me.txtHorasExtrasMarranas.TabIndex = 207
        '
        'cbHorasExtrasMarranas
        '
        Me.cbHorasExtrasMarranas.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cbHorasExtrasMarranas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.cbHorasExtrasMarranas.Location = New System.Drawing.Point(635, 227)
        Me.cbHorasExtrasMarranas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbHorasExtrasMarranas.Name = "cbHorasExtrasMarranas"
        Me.cbHorasExtrasMarranas.Size = New System.Drawing.Size(138, 38)
        Me.cbHorasExtrasMarranas.TabIndex = 208
        Me.cbHorasExtrasMarranas.Text = "Marranas"
        Me.cbHorasExtrasMarranas.UseVisualStyleBackColor = True
        '
        'frmEditarHorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(790, 620)
        Me.Controls.Add(Me.cbHorasExtrasMarranas)
        Me.Controls.Add(Me.txtHorasExtrasMarranas)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbxFeriado)
        Me.Controls.Add(Me.cbxDescanso)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.cbxAsistencia)
        Me.Controls.Add(Me.dtpHoraSalida)
        Me.Controls.Add(Me.dtpHoraEntrada)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.cbxInasistencia)
        Me.Controls.Add(Me.cbxPermisoMedico)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbHabilitarHEX)
        Me.Controls.Add(Me.txtHorasRefrigerio)
        Me.Controls.Add(Me.txtHorasLaboradas)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPagoEspecial)
        Me.Controls.Add(Me.txtHorasExtras)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmEditarHorarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EDITAR HORARIO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtHorasExtras As TextBox
    Friend WithEvents txtPagoEspecial As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtHorasLaboradas As TextBox
    Friend WithEvents txtHorasRefrigerio As TextBox
    Friend WithEvents cbHabilitarHEX As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxPermisoMedico As ComboBox
    Friend WithEvents cbxInasistencia As CheckBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnSalir As ToolStripButton
    Friend WithEvents dtpHoraEntrada As DateTimePicker
    Friend WithEvents dtpHoraSalida As DateTimePicker
    Friend WithEvents cbxAsistencia As CheckBox
    Friend WithEvents txtObservacion As RichTextBox
    Friend WithEvents cbxDescanso As CheckBox
    Friend WithEvents cbxFeriado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtHorasExtrasMarranas As TextBox
    Friend WithEvents cbHorasExtrasMarranas As CheckBox
End Class
