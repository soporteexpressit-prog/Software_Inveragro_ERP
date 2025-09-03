<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAlimentarGrupoDestete
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtCantidadAlimento = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.LblGrupo = New System.Windows.Forms.Label()
        Me.LblStockAlimento = New System.Windows.Forms.Label()
        Me.LblConsumoAlimento = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblAlimento = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtCantidadAlimento)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(31, 244)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(583, 106)
        Me.GroupBox2.TabIndex = 281
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ingresar Cantidad de Alimento"
        '
        'TxtCantidadAlimento
        '
        Me.TxtCantidadAlimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCantidadAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadAlimento.Location = New System.Drawing.Point(162, 46)
        Me.TxtCantidadAlimento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCantidadAlimento.MaxLength = 50
        Me.TxtCantidadAlimento.Name = "TxtCantidadAlimento"
        Me.TxtCantidadAlimento.Size = New System.Drawing.Size(149, 28)
        Me.TxtCantidadAlimento.TabIndex = 173
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(39, 48)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 22)
        Me.Label13.TabIndex = 172
        Me.Label13.Text = "Cantidad :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(90, 177)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 22)
        Me.Label9.TabIndex = 294
        Me.Label9.Text = "Stock:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(634, 40)
        Me.ToolStrip1.TabIndex = 277
        Me.ToolStrip1.Text = "Monitoreo"
        '
        'LblGrupo
        '
        Me.LblGrupo.AutoSize = True
        Me.LblGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblGrupo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGrupo.ForeColor = System.Drawing.Color.Green
        Me.LblGrupo.Location = New System.Drawing.Point(26, 79)
        Me.LblGrupo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblGrupo.Name = "LblGrupo"
        Me.LblGrupo.Size = New System.Drawing.Size(22, 25)
        Me.LblGrupo.TabIndex = 276
        Me.LblGrupo.Text = "-"
        '
        'LblStockAlimento
        '
        Me.LblStockAlimento.AutoSize = True
        Me.LblStockAlimento.BackColor = System.Drawing.Color.Transparent
        Me.LblStockAlimento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStockAlimento.ForeColor = System.Drawing.Color.Black
        Me.LblStockAlimento.Location = New System.Drawing.Point(178, 177)
        Me.LblStockAlimento.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblStockAlimento.Name = "LblStockAlimento"
        Me.LblStockAlimento.Size = New System.Drawing.Size(21, 22)
        Me.LblStockAlimento.TabIndex = 275
        Me.LblStockAlimento.Text = "0"
        '
        'LblConsumoAlimento
        '
        Me.LblConsumoAlimento.AutoSize = True
        Me.LblConsumoAlimento.BackColor = System.Drawing.Color.Transparent
        Me.LblConsumoAlimento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsumoAlimento.ForeColor = System.Drawing.Color.Black
        Me.LblConsumoAlimento.Location = New System.Drawing.Point(502, 177)
        Me.LblConsumoAlimento.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblConsumoAlimento.Name = "LblConsumoAlimento"
        Me.LblConsumoAlimento.Size = New System.Drawing.Size(21, 22)
        Me.LblConsumoAlimento.TabIndex = 296
        Me.LblConsumoAlimento.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(355, 177)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 22)
        Me.Label6.TabIndex = 297
        Me.Label6.Text = "Consumido :"
        '
        'LblAlimento
        '
        Me.LblAlimento.AutoSize = True
        Me.LblAlimento.BackColor = System.Drawing.Color.Transparent
        Me.LblAlimento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlimento.ForeColor = System.Drawing.Color.Black
        Me.LblAlimento.Location = New System.Drawing.Point(178, 134)
        Me.LblAlimento.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblAlimento.Name = "LblAlimento"
        Me.LblAlimento.Size = New System.Drawing.Size(18, 22)
        Me.LblAlimento.TabIndex = 298
        Me.LblAlimento.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(56, 134)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 22)
        Me.Label2.TabIndex = 299
        Me.Label2.Text = "Alimento:"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar2
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.BtnGuardar.Text = "Guardar"
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
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(352, 80)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 22)
        Me.Label1.TabIndex = 300
        Me.Label1.Text = "Fecha :"
        '
        'DtpFecha
        '
        Me.DtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(450, 77)
        Me.DtpFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(164, 28)
        Me.DtpFecha.TabIndex = 301
        '
        'FrmAlimentarGrupoDestete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(634, 373)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.LblAlimento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblConsumoAlimento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblStockAlimento)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LblGrupo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAlimentarGrupoDestete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alimentación por Grupos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtCantidadAlimento As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents LblGrupo As Label
    Friend WithEvents LblStockAlimento As Label
    Friend WithEvents LblConsumoAlimento As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblAlimento As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpFecha As DateTimePicker
End Class
