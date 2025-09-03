<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambiarLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambiarLote))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardarLote = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.LblFechaCierre = New System.Windows.Forms.Label()
        Me.LblFechaApertura = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAsignarLote = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBuscarCerda = New System.Windows.Forms.Button()
        Me.LblSeleccionarCerda = New System.Windows.Forms.Label()
        Me.LblCodArete = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardarLote, Me.BtnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(564, 40)
        Me.ToolStrip1.TabIndex = 170
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnGuardarLote
        '
        Me.BtnGuardarLote.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarLote.ForeColor = System.Drawing.Color.White
        Me.BtnGuardarLote.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.BtnGuardarLote.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardarLote.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardarLote.Name = "BtnGuardarLote"
        Me.BtnGuardarLote.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardarLote.Size = New System.Drawing.Size(121, 30)
        Me.BtnGuardarLote.Text = "Guardar"
        Me.BtnGuardarLote.ToolTipText = "Guardar"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(157, 149)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 22)
        Me.Label4.TabIndex = 210
        Me.Label4.Text = "Lote :"
        '
        'TxtLote
        '
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLote.Location = New System.Drawing.Point(241, 146)
        Me.TxtLote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtLote.MaxLength = 4
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(120, 28)
        Me.TxtLote.TabIndex = 211
        Me.TxtLote.TabStop = False
        '
        'LblFechaCierre
        '
        Me.LblFechaCierre.AutoSize = True
        Me.LblFechaCierre.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaCierre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaCierre.ForeColor = System.Drawing.Color.Black
        Me.LblFechaCierre.Location = New System.Drawing.Point(241, 91)
        Me.LblFechaCierre.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFechaCierre.Name = "LblFechaCierre"
        Me.LblFechaCierre.Size = New System.Drawing.Size(85, 22)
        Me.LblFechaCierre.TabIndex = 215
        Me.LblFechaCierre.Text = "- / - / -"
        '
        'LblFechaApertura
        '
        Me.LblFechaApertura.AutoSize = True
        Me.LblFechaApertura.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaApertura.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaApertura.ForeColor = System.Drawing.Color.Black
        Me.LblFechaApertura.Location = New System.Drawing.Point(241, 39)
        Me.LblFechaApertura.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFechaApertura.Name = "LblFechaApertura"
        Me.LblFechaApertura.Size = New System.Drawing.Size(85, 22)
        Me.LblFechaApertura.TabIndex = 214
        Me.LblFechaApertura.Text = "- / - / -"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(73, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 22)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Fecha Cierre :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(44, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 22)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Fecha Apertura :"
        '
        'BtnAsignarLote
        '
        Me.BtnAsignarLote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAsignarLote.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAsignarLote.Image = CType(resources.GetObject("BtnAsignarLote.Image"), System.Drawing.Image)
        Me.BtnAsignarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAsignarLote.Location = New System.Drawing.Point(371, 138)
        Me.BtnAsignarLote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnAsignarLote.Name = "BtnAsignarLote"
        Me.BtnAsignarLote.Size = New System.Drawing.Size(48, 45)
        Me.BtnAsignarLote.TabIndex = 209
        Me.BtnAsignarLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAsignarLote.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBuscarCerda)
        Me.GroupBox1.Controls.Add(Me.LblSeleccionarCerda)
        Me.GroupBox1.Controls.Add(Me.LblCodArete)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 100)
        Me.GroupBox1.TabIndex = 173
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de la Cerda"
        '
        'BtnBuscarCerda
        '
        Me.BtnBuscarCerda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCerda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarCerda.Image = CType(resources.GetObject("BtnBuscarCerda.Image"), System.Drawing.Image)
        Me.BtnBuscarCerda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCerda.Location = New System.Drawing.Point(462, 33)
        Me.BtnBuscarCerda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarCerda.Name = "BtnBuscarCerda"
        Me.BtnBuscarCerda.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarCerda.TabIndex = 221
        Me.BtnBuscarCerda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCerda.UseVisualStyleBackColor = True
        '
        'LblSeleccionarCerda
        '
        Me.LblSeleccionarCerda.AutoSize = True
        Me.LblSeleccionarCerda.BackColor = System.Drawing.Color.Transparent
        Me.LblSeleccionarCerda.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionarCerda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblSeleccionarCerda.Location = New System.Drawing.Point(269, 44)
        Me.LblSeleccionarCerda.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblSeleccionarCerda.Name = "LblSeleccionarCerda"
        Me.LblSeleccionarCerda.Size = New System.Drawing.Size(183, 22)
        Me.LblSeleccionarCerda.TabIndex = 220
        Me.LblSeleccionarCerda.Text = "Seleccione Cerda"
        '
        'LblCodArete
        '
        Me.LblCodArete.AutoSize = True
        Me.LblCodArete.BackColor = System.Drawing.Color.Yellow
        Me.LblCodArete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodArete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCodArete.Location = New System.Drawing.Point(116, 41)
        Me.LblCodArete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCodArete.Name = "LblCodArete"
        Me.LblCodArete.Size = New System.Drawing.Size(25, 29)
        Me.LblCodArete.TabIndex = 222
        Me.LblCodArete.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(21, 44)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 22)
        Me.Label3.TabIndex = 219
        Me.Label3.Text = "Arete :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblFechaCierre)
        Me.GroupBox2.Controls.Add(Me.TxtLote)
        Me.GroupBox2.Controls.Add(Me.LblFechaApertura)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.BtnAsignarLote)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(536, 198)
        Me.GroupBox2.TabIndex = 174
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información del Lote"
        '
        'FrmCambiarLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(564, 391)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambiarLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRAR CAMBIO DE LOTE"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardarLote As ToolStripButton
    Friend WithEvents BtnSalir As ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtLote As TextBox
    Friend WithEvents BtnAsignarLote As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblFechaCierre As Label
    Friend WithEvents LblFechaApertura As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnBuscarCerda As Button
    Friend WithEvents LblSeleccionarCerda As Label
    Friend WithEvents LblCodArete As Label
    Friend WithEvents Label3 As Label
End Class
