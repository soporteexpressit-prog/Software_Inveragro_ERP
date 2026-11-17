<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantAsociarRacionProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantAsociarRacionProducto))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BtnProductoEquivalencia1 = New System.Windows.Forms.Button()
        Me.TxtNombreEqProducto1 = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnProductoEquivalencia2 = New System.Windows.Forms.Button()
        Me.TxtNombreEqProducto2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.BtnProductoEquivalencia1)
        Me.GroupBox2.Controls.Add(Me.TxtNombreEqProducto1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(45, 88)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(791, 117)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto Equivalencia 1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(38, 71)
        Me.Label24.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(120, 22)
        Me.Label24.TabIndex = 183
        Me.Label24.Text = "Producto 1 :"
        '
        'BtnProductoEquivalencia1
        '
        Me.BtnProductoEquivalencia1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnProductoEquivalencia1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProductoEquivalencia1.Image = CType(resources.GetObject("BtnProductoEquivalencia1.Image"), System.Drawing.Image)
        Me.BtnProductoEquivalencia1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProductoEquivalencia1.Location = New System.Drawing.Point(707, 60)
        Me.BtnProductoEquivalencia1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnProductoEquivalencia1.Name = "BtnProductoEquivalencia1"
        Me.BtnProductoEquivalencia1.Size = New System.Drawing.Size(48, 45)
        Me.BtnProductoEquivalencia1.TabIndex = 169
        Me.BtnProductoEquivalencia1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProductoEquivalencia1.UseVisualStyleBackColor = True
        '
        'TxtNombreEqProducto1
        '
        Me.TxtNombreEqProducto1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreEqProducto1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreEqProducto1.Location = New System.Drawing.Point(178, 68)
        Me.TxtNombreEqProducto1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNombreEqProducto1.MaxLength = 50
        Me.TxtNombreEqProducto1.Name = "TxtNombreEqProducto1"
        Me.TxtNombreEqProducto1.Size = New System.Drawing.Size(484, 28)
        Me.TxtNombreEqProducto1.TabIndex = 171
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(870, 40)
        Me.ToolStrip1.TabIndex = 6
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
        Me.btnGuardar.ToolTipText = "Guardar "
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCerrar.Size = New System.Drawing.Size(90, 30)
        Me.btnCerrar.Text = "Salir "
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnProductoEquivalencia2)
        Me.GroupBox1.Controls.Add(Me.TxtNombreEqProducto2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(45, 241)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(791, 117)
        Me.GroupBox1.TabIndex = 184
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto Equivalencia 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(38, 69)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 22)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Producto 2 :"
        '
        'BtnProductoEquivalencia2
        '
        Me.BtnProductoEquivalencia2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnProductoEquivalencia2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProductoEquivalencia2.Image = CType(resources.GetObject("BtnProductoEquivalencia2.Image"), System.Drawing.Image)
        Me.BtnProductoEquivalencia2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProductoEquivalencia2.Location = New System.Drawing.Point(707, 58)
        Me.BtnProductoEquivalencia2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnProductoEquivalencia2.Name = "BtnProductoEquivalencia2"
        Me.BtnProductoEquivalencia2.Size = New System.Drawing.Size(48, 45)
        Me.BtnProductoEquivalencia2.TabIndex = 169
        Me.BtnProductoEquivalencia2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProductoEquivalencia2.UseVisualStyleBackColor = True
        '
        'TxtNombreEqProducto2
        '
        Me.TxtNombreEqProducto2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreEqProducto2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreEqProducto2.Location = New System.Drawing.Point(178, 66)
        Me.TxtNombreEqProducto2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNombreEqProducto2.MaxLength = 50
        Me.TxtNombreEqProducto2.Name = "TxtNombreEqProducto2"
        Me.TxtNombreEqProducto2.Size = New System.Drawing.Size(484, 28)
        Me.TxtNombreEqProducto2.TabIndex = 171
        '
        'FrmMantAsociarRacionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 396)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantAsociarRacionProducto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ASOCIAR"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents BtnProductoEquivalencia1 As Button
    Friend WithEvents TxtNombreEqProducto1 As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnProductoEquivalencia2 As Button
    Friend WithEvents TxtNombreEqProducto2 As TextBox
End Class
