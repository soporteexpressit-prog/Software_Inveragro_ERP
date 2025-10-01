<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantenimientoPlantel
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbClasificacion = New System.Windows.Forms.ComboBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumChanchillas = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblDensidad = New System.Windows.Forms.Label()
        Me.TxtDensidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnGuardarPcorr = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumChanchillas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardarPcorr, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(468, 38)
        Me.ToolStrip1.TabIndex = 53
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbClasificacion)
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.NumChanchillas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LblDensidad)
        Me.GroupBox1.Controls.Add(Me.TxtDensidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 252)
        Me.GroupBox1.TabIndex = 231
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información Plantel"
        '
        'CmbClasificacion
        '
        Me.CmbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbClasificacion.FormattingEnabled = True
        Me.CmbClasificacion.Items.AddRange(New Object() {"REPRODUCCIÓN", "WEAN TO FINISH"})
        Me.CmbClasificacion.Location = New System.Drawing.Point(171, 163)
        Me.CmbClasificacion.Name = "CmbClasificacion"
        Me.CmbClasificacion.Size = New System.Drawing.Size(121, 21)
        Me.CmbClasificacion.TabIndex = 63
        '
        'TxtDireccion
        '
        Me.TxtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDireccion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDireccion.Location = New System.Drawing.Point(171, 202)
        Me.TxtDireccion.MaxLength = 50
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(222, 22)
        Me.TxtDireccion.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(90, 206)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 14)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Dirección:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(69, 166)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Clasificación:"
        '
        'NumChanchillas
        '
        Me.NumChanchillas.Location = New System.Drawing.Point(171, 74)
        Me.NumChanchillas.Margin = New System.Windows.Forms.Padding(2)
        Me.NumChanchillas.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumChanchillas.Name = "NumChanchillas"
        Me.NumChanchillas.Size = New System.Drawing.Size(121, 20)
        Me.NumChanchillas.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(38, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 14)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "+ N° Chanchillas :"
        '
        'LblDensidad
        '
        Me.LblDensidad.AutoSize = True
        Me.LblDensidad.BackColor = System.Drawing.Color.Transparent
        Me.LblDensidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDensidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblDensidad.Location = New System.Drawing.Point(16, 118)
        Me.LblDensidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDensidad.Name = "LblDensidad"
        Me.LblDensidad.Size = New System.Drawing.Size(148, 14)
        Me.LblDensidad.TabIndex = 56
        Me.LblDensidad.Text = "Densidad por Corral :"
        '
        'TxtDensidad
        '
        Me.TxtDensidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDensidad.Location = New System.Drawing.Point(171, 116)
        Me.TxtDensidad.MaxLength = 50
        Me.TxtDensidad.Name = "TxtDensidad"
        Me.TxtDensidad.Size = New System.Drawing.Size(121, 20)
        Me.TxtDensidad.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(71, 36)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 14)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Descripción :"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(171, 32)
        Me.TxtDescripcion.MaxLength = 50
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(222, 22)
        Me.TxtDescripcion.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(28, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 18)
        Me.Label6.TabIndex = 230
        Me.Label6.Text = "REGISTRO DE PLANTEL"
        '
        'btnGuardarPcorr
        '
        Me.btnGuardarPcorr.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarPcorr.ForeColor = System.Drawing.Color.White
        Me.btnGuardarPcorr.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardarPcorr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardarPcorr.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardarPcorr.Name = "btnGuardarPcorr"
        Me.btnGuardarPcorr.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardarPcorr.Size = New System.Drawing.Size(89, 28)
        Me.btnGuardarPcorr.Text = "Guardar"
        Me.btnGuardarPcorr.ToolTipText = "Guardar"
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
        Me.btnCerrar.Size = New System.Drawing.Size(66, 28)
        Me.btnCerrar.Text = "Salir"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'FrmMantenimientoPlantel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 357)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMantenimientoPlantel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MANTENIMIENTO DE PLANTEL"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumChanchillas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardarPcorr As ToolStripButton
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents NumChanchillas As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents LblDensidad As Label
    Friend WithEvents TxtDensidad As TextBox
    Friend WithEvents CmbClasificacion As ComboBox
    Friend WithEvents TxtDireccion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
