<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditarclienteBanco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditarclienteBanco))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnbuscarpoveedor = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtcodproveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtproveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TsBtn_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnactualizarproveedorventa = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtcodproveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnbuscarpoveedor)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.txtcodproveedor)
        Me.GroupBox1.Controls.Add(Me.txtproveedor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 95)
        Me.GroupBox1.TabIndex = 411
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documento"
        '
        'btnbuscarpoveedor
        '
        Me.btnbuscarpoveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbuscarpoveedor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbuscarpoveedor.Image = CType(resources.GetObject("btnbuscarpoveedor.Image"), System.Drawing.Image)
        Me.btnbuscarpoveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbuscarpoveedor.Location = New System.Drawing.Point(284, 20)
        Me.btnbuscarpoveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnbuscarpoveedor.Name = "btnbuscarpoveedor"
        Me.btnbuscarpoveedor.Size = New System.Drawing.Size(82, 29)
        Me.btnbuscarpoveedor.TabIndex = 385
        Me.btnbuscarpoveedor.Text = "Buscar"
        Me.btnbuscarpoveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnbuscarpoveedor.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(134, 60)
        Me.Label29.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 14)
        Me.Label29.TabIndex = 389
        Me.Label29.Text = "Datos :"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(127, 25)
        Me.Label28.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 14)
        Me.Label28.TabIndex = 388
        Me.Label28.Text = "Código :"
        '
        'txtcodproveedor
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(216, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtcodproveedor.Appearance = Appearance1
        Me.txtcodproveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtcodproveedor.Enabled = False
        Me.txtcodproveedor.Location = New System.Drawing.Point(194, 25)
        Me.txtcodproveedor.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtcodproveedor.Name = "txtcodproveedor"
        Me.txtcodproveedor.ReadOnly = True
        Me.txtcodproveedor.Size = New System.Drawing.Size(81, 23)
        Me.txtcodproveedor.TabIndex = 387
        Me.txtcodproveedor.TabStop = False
        '
        'txtproveedor
        '
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(216, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtproveedor.Appearance = Appearance2
        Me.txtproveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txtproveedor.Location = New System.Drawing.Point(194, 59)
        Me.txtproveedor.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(488, 23)
        Me.txtproveedor.TabIndex = 386
        Me.txtproveedor.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnactualizarproveedorventa, Me.TsBtn_Cerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(736, 38)
        Me.ToolStrip1.TabIndex = 412
        Me.ToolStrip1.TabStop = True
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
        Me.btnGuardar.Size = New System.Drawing.Size(101, 28)
        Me.btnGuardar.Tag = "343"
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'TsBtn_Cerrar
        '
        Me.TsBtn_Cerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsBtn_Cerrar.ForeColor = System.Drawing.Color.White
        Me.TsBtn_Cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.TsBtn_Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.TsBtn_Cerrar.Name = "TsBtn_Cerrar"
        Me.TsBtn_Cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.TsBtn_Cerrar.Size = New System.Drawing.Size(80, 28)
        Me.TsBtn_Cerrar.Tag = "3434"
        Me.TsBtn_Cerrar.Text = "SALIR "
        Me.TsBtn_Cerrar.ToolTipText = "Cerrar"
        '
        'btnactualizarproveedorventa
        '
        Me.btnactualizarproveedorventa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnactualizarproveedorventa.ForeColor = System.Drawing.Color.White
        Me.btnactualizarproveedorventa.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnactualizarproveedorventa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnactualizarproveedorventa.Margin = New System.Windows.Forms.Padding(5)
        Me.btnactualizarproveedorventa.Name = "btnactualizarproveedorventa"
        Me.btnactualizarproveedorventa.Padding = New System.Windows.Forms.Padding(2)
        Me.btnactualizarproveedorventa.Size = New System.Drawing.Size(120, 28)
        Me.btnactualizarproveedorventa.Tag = "343"
        Me.btnactualizarproveedorventa.Text = "ACTUALIZAR"
        Me.btnactualizarproveedorventa.ToolTipText = "Guardar"
        '
        'FrmEditarclienteBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(736, 181)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmEditarclienteBanco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EDITAR CLIENTE BANCO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtcodproveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnbuscarpoveedor As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents txtcodproveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtproveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents TsBtn_Cerrar As ToolStripButton
    Friend WithEvents btnactualizarproveedorventa As ToolStripButton
End Class
