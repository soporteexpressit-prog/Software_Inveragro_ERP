<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImpresionFormula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpresionFormula))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblSeleccionadoPlus = New System.Windows.Forms.Label()
        Me.LblPlus = New System.Windows.Forms.Label()
        Me.BtnPlus = New System.Windows.Forms.Button()
        Me.CbxPlus = New System.Windows.Forms.CheckBox()
        Me.LblSeleccionadoMedic = New System.Windows.Forms.Label()
        Me.LblMedicaciones = New System.Windows.Forms.Label()
        Me.BtnBuscarMedicacion = New System.Windows.Forms.Button()
        Me.TxtNota = New System.Windows.Forms.RichTextBox()
        Me.CbxAnti = New System.Windows.Forms.CheckBox()
        Me.CbxMedicado = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmTipoPremixero = New System.Windows.Forms.ComboBox()
        Me.txtPreparacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtnImpresionRacion = New System.Windows.Forms.ToolStripButton()
        Me.BtnImpresionPremixero = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LblSeleccionadoPlus)
        Me.Panel2.Controls.Add(Me.LblPlus)
        Me.Panel2.Controls.Add(Me.BtnPlus)
        Me.Panel2.Controls.Add(Me.CbxPlus)
        Me.Panel2.Controls.Add(Me.LblSeleccionadoMedic)
        Me.Panel2.Controls.Add(Me.LblMedicaciones)
        Me.Panel2.Controls.Add(Me.BtnBuscarMedicacion)
        Me.Panel2.Controls.Add(Me.TxtNota)
        Me.Panel2.Controls.Add(Me.CbxAnti)
        Me.Panel2.Controls.Add(Me.CbxMedicado)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.CmTipoPremixero)
        Me.Panel2.Controls.Add(Me.txtPreparacion)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(852, 451)
        Me.Panel2.TabIndex = 54
        '
        'LblSeleccionadoPlus
        '
        Me.LblSeleccionadoPlus.AutoSize = True
        Me.LblSeleccionadoPlus.BackColor = System.Drawing.Color.Transparent
        Me.LblSeleccionadoPlus.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionadoPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSeleccionadoPlus.Location = New System.Drawing.Point(567, 373)
        Me.LblSeleccionadoPlus.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblSeleccionadoPlus.Name = "LblSeleccionadoPlus"
        Me.LblSeleccionadoPlus.Size = New System.Drawing.Size(15, 17)
        Me.LblSeleccionadoPlus.TabIndex = 229
        Me.LblSeleccionadoPlus.Text = "-"
        '
        'LblPlus
        '
        Me.LblPlus.AutoSize = True
        Me.LblPlus.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblPlus.Location = New System.Drawing.Point(619, 342)
        Me.LblPlus.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblPlus.Name = "LblPlus"
        Me.LblPlus.Size = New System.Drawing.Size(66, 22)
        Me.LblPlus.TabIndex = 228
        Me.LblPlus.Text = "Plus :"
        '
        'BtnPlus
        '
        Me.BtnPlus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPlus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlus.Image = CType(resources.GetObject("BtnPlus.Image"), System.Drawing.Image)
        Me.BtnPlus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPlus.Location = New System.Drawing.Point(692, 331)
        Me.BtnPlus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnPlus.Name = "BtnPlus"
        Me.BtnPlus.Size = New System.Drawing.Size(48, 45)
        Me.BtnPlus.TabIndex = 227
        Me.BtnPlus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPlus.UseVisualStyleBackColor = True
        '
        'CbxPlus
        '
        Me.CbxPlus.AutoSize = True
        Me.CbxPlus.Location = New System.Drawing.Point(735, 181)
        Me.CbxPlus.Name = "CbxPlus"
        Me.CbxPlus.Size = New System.Drawing.Size(65, 24)
        Me.CbxPlus.TabIndex = 226
        Me.CbxPlus.Text = "Plus"
        Me.CbxPlus.UseVisualStyleBackColor = True
        '
        'LblSeleccionadoMedic
        '
        Me.LblSeleccionadoMedic.AutoSize = True
        Me.LblSeleccionadoMedic.BackColor = System.Drawing.Color.Transparent
        Me.LblSeleccionadoMedic.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionadoMedic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSeleccionadoMedic.Location = New System.Drawing.Point(567, 299)
        Me.LblSeleccionadoMedic.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblSeleccionadoMedic.Name = "LblSeleccionadoMedic"
        Me.LblSeleccionadoMedic.Size = New System.Drawing.Size(15, 17)
        Me.LblSeleccionadoMedic.TabIndex = 225
        Me.LblSeleccionadoMedic.Text = "-"
        '
        'LblMedicaciones
        '
        Me.LblMedicaciones.AutoSize = True
        Me.LblMedicaciones.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMedicaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblMedicaciones.Location = New System.Drawing.Point(526, 268)
        Me.LblMedicaciones.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblMedicaciones.Name = "LblMedicaciones"
        Me.LblMedicaciones.Size = New System.Drawing.Size(159, 22)
        Me.LblMedicaciones.TabIndex = 182
        Me.LblMedicaciones.Text = "Medicaciones :"
        '
        'BtnBuscarMedicacion
        '
        Me.BtnBuscarMedicacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarMedicacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarMedicacion.Image = CType(resources.GetObject("BtnBuscarMedicacion.Image"), System.Drawing.Image)
        Me.BtnBuscarMedicacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarMedicacion.Location = New System.Drawing.Point(692, 257)
        Me.BtnBuscarMedicacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarMedicacion.Name = "BtnBuscarMedicacion"
        Me.BtnBuscarMedicacion.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarMedicacion.TabIndex = 181
        Me.BtnBuscarMedicacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarMedicacion.UseVisualStyleBackColor = True
        '
        'TxtNota
        '
        Me.TxtNota.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(43, 230)
        Me.TxtNota.MaxLength = 200
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(427, 197)
        Me.TxtNota.TabIndex = 172
        Me.TxtNota.Text = "NINGUNO"
        '
        'CbxAnti
        '
        Me.CbxAnti.AutoSize = True
        Me.CbxAnti.Location = New System.Drawing.Point(475, 181)
        Me.CbxAnti.Name = "CbxAnti"
        Me.CbxAnti.Size = New System.Drawing.Size(96, 24)
        Me.CbxAnti.TabIndex = 171
        Me.CbxAnti.Text = "Con Anti"
        Me.CbxAnti.UseVisualStyleBackColor = True
        '
        'CbxMedicado
        '
        Me.CbxMedicado.AutoSize = True
        Me.CbxMedicado.Location = New System.Drawing.Point(603, 181)
        Me.CbxMedicado.Name = "CbxMedicado"
        Me.CbxMedicado.Size = New System.Drawing.Size(104, 24)
        Me.CbxMedicado.TabIndex = 170
        Me.CbxMedicado.Text = "Medicado"
        Me.CbxMedicado.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(39, 185)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 22)
        Me.Label2.TabIndex = 169
        Me.Label2.Text = "Observación :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(462, 86)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 22)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Tipo Premixero :"
        '
        'CmTipoPremixero
        '
        Me.CmTipoPremixero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmTipoPremixero.FormattingEnabled = True
        Me.CmTipoPremixero.Items.AddRange(New Object() {"PREMIXERO 1", "PREMIXERO 2", "PREMIXERO 3"})
        Me.CmTipoPremixero.Location = New System.Drawing.Point(466, 120)
        Me.CmTipoPremixero.Name = "CmTipoPremixero"
        Me.CmTipoPremixero.Size = New System.Drawing.Size(235, 28)
        Me.CmTipoPremixero.TabIndex = 167
        '
        'txtPreparacion
        '
        Me.txtPreparacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPreparacion.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreparacion.Location = New System.Drawing.Point(43, 116)
        Me.txtPreparacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPreparacion.MaxLength = 4
        Me.txtPreparacion.Name = "txtPreparacion"
        Me.txtPreparacion.Size = New System.Drawing.Size(71, 37)
        Me.txtPreparacion.TabIndex = 166
        Me.txtPreparacion.Text = "5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(39, 86)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(267, 22)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Diseño Preparación (tn) :"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnImpresionRacion, Me.BtnImpresionPremixero})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip2.Size = New System.Drawing.Size(852, 40)
        Me.ToolStrip2.TabIndex = 52
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'BtnImpresionRacion
        '
        Me.BtnImpresionRacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImpresionRacion.ForeColor = System.Drawing.Color.White
        Me.BtnImpresionRacion.Image = Global.Formularios.My.Resources.Resources.imprimir
        Me.BtnImpresionRacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImpresionRacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnImpresionRacion.Name = "BtnImpresionRacion"
        Me.BtnImpresionRacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnImpresionRacion.Size = New System.Drawing.Size(146, 30)
        Me.BtnImpresionRacion.Text = "Por Ración"
        Me.BtnImpresionRacion.ToolTipText = "Salir"
        '
        'BtnImpresionPremixero
        '
        Me.BtnImpresionPremixero.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImpresionPremixero.ForeColor = System.Drawing.Color.White
        Me.BtnImpresionPremixero.Image = Global.Formularios.My.Resources.Resources.imprimir
        Me.BtnImpresionPremixero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImpresionPremixero.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnImpresionPremixero.Name = "BtnImpresionPremixero"
        Me.BtnImpresionPremixero.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnImpresionPremixero.Size = New System.Drawing.Size(182, 30)
        Me.BtnImpresionPremixero.Text = "Por Premixero"
        Me.BtnImpresionPremixero.ToolTipText = "Salir"
        '
        'FrmImpresionFormula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 451)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpresionFormula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IMPRIMIR PREPARACIÓN RACIÓN"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtPreparacion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents BtnImpresionRacion As ToolStripButton
    Friend WithEvents BtnImpresionPremixero As ToolStripButton
    Friend WithEvents CmTipoPremixero As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CbxAnti As CheckBox
    Friend WithEvents CbxMedicado As CheckBox
    Friend WithEvents TxtNota As RichTextBox
    Friend WithEvents LblMedicaciones As Label
    Friend WithEvents BtnBuscarMedicacion As Button
    Friend WithEvents LblSeleccionadoMedic As Label
    Friend WithEvents CbxPlus As CheckBox
    Friend WithEvents LblSeleccionadoPlus As Label
    Friend WithEvents LblPlus As Label
    Friend WithEvents BtnPlus As Button
End Class
