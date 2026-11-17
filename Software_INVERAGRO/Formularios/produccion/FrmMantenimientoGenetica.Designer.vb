<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantenimientoGenetica
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CbxTipo = New System.Windows.Forms.ComboBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAbreviatura = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(487, 440)
        Me.Panel2.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(27, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(340, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "REGISTRO DE GENÉTICA"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CbxTipo)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblAbreviatura)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 143)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(444, 272)
        Me.GroupBox1.TabIndex = 167
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de genética"
        '
        'CbxTipo
        '
        Me.CbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxTipo.FormattingEnabled = True
        Me.CbxTipo.Location = New System.Drawing.Point(182, 182)
        Me.CbxTipo.Name = "CbxTipo"
        Me.CbxTipo.Size = New System.Drawing.Size(209, 28)
        Me.CbxTipo.TabIndex = 70
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(182, 118)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDescripcion.MaxLength = 50
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(209, 29)
        Me.TxtDescripcion.TabIndex = 69
        '
        'TxtCodigo
        '
        Me.TxtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodigo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(182, 65)
        Me.TxtCodigo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCodigo.MaxLength = 5
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(97, 29)
        Me.TxtCodigo.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(31, 185)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 22)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Asignación :"
        '
        'lblAbreviatura
        '
        Me.lblAbreviatura.AutoSize = True
        Me.lblAbreviatura.BackColor = System.Drawing.Color.Transparent
        Me.lblAbreviatura.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbreviatura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblAbreviatura.Location = New System.Drawing.Point(62, 121)
        Me.lblAbreviatura.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblAbreviatura.Name = "lblAbreviatura"
        Me.lblAbreviatura.Size = New System.Drawing.Size(103, 22)
        Me.lblAbreviatura.TabIndex = 67
        Me.lblAbreviatura.Text = "Nombre :"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(73, 68)
        Me.lblDescripcion.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(92, 22)
        Me.lblDescripcion.TabIndex = 47
        Me.lblDescripcion.Text = "Código :"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip2.Size = New System.Drawing.Size(487, 40)
        Me.ToolStrip2.TabIndex = 52
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnSalir.Size = New System.Drawing.Size(84, 30)
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.ToolTipText = "Cerrar"
        '
        'FrmMantenimientoGenetica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 440)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantenimientoGenetica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Genética"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAbreviatura As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnSalir As ToolStripButton
    Friend WithEvents CbxTipo As ComboBox
    Friend WithEvents TxtDescripcion As TextBox
End Class
