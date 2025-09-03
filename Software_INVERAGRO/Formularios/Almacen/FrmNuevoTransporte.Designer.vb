<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevoTransporte
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
        Me.btnnuevoytipo = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpesotara = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_capacidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbmarca = New System.Windows.Forms.ComboBox()
        Me.txt_año = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbtipovehiculo = New System.Windows.Forms.ComboBox()
        Me.txt_modelo = New System.Windows.Forms.TextBox()
        Me.cs16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_numplaca = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbestado = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnnuevoytipo, Me.btnGuardar, Me.btnsalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1121, 40)
        Me.ToolStrip1.TabIndex = 180
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnnuevoytipo
        '
        Me.btnnuevoytipo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnnuevoytipo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevoytipo.ForeColor = System.Drawing.Color.White
        Me.btnnuevoytipo.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnnuevoytipo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnuevoytipo.Margin = New System.Windows.Forms.Padding(5)
        Me.btnnuevoytipo.Name = "btnnuevoytipo"
        Me.btnnuevoytipo.Padding = New System.Windows.Forms.Padding(2)
        Me.btnnuevoytipo.Size = New System.Drawing.Size(329, 30)
        Me.btnnuevoytipo.Text = "Nuevo Tipo Vehículo / Marca"
        Me.btnnuevoytipo.ToolTipText = "Nuevo "
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
        Me.btnGuardar.ToolTipText = "Nuevo "
        '
        'btnsalir
        '
        Me.btnsalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalir.ForeColor = System.Drawing.Color.White
        Me.btnsalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnsalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnsalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Padding = New System.Windows.Forms.Padding(2)
        Me.btnsalir.Size = New System.Drawing.Size(84, 30)
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.ToolTipText = "Editar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtpesotara)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_capacidad)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbmarca)
        Me.GroupBox1.Controls.Add(Me.txt_año)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbtipovehiculo)
        Me.GroupBox1.Controls.Add(Me.txt_modelo)
        Me.GroupBox1.Controls.Add(Me.cs16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_numplaca)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 148)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1033, 274)
        Me.GroupBox1.TabIndex = 238
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Transporte:"
        '
        'txtpesotara
        '
        Me.txtpesotara.BackColor = System.Drawing.SystemColors.Window
        Me.txtpesotara.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.txtpesotara.Location = New System.Drawing.Point(268, 210)
        Me.txtpesotara.Margin = New System.Windows.Forms.Padding(2)
        Me.txtpesotara.MaxLength = 100
        Me.txtpesotara.Name = "txtpesotara"
        Me.txtpesotara.Size = New System.Drawing.Size(217, 31)
        Me.txtpesotara.TabIndex = 250
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(98, 213)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 28)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Peso tara (Tn):"
        '
        'txt_capacidad
        '
        Me.txt_capacidad.BackColor = System.Drawing.SystemColors.Window
        Me.txt_capacidad.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.txt_capacidad.Location = New System.Drawing.Point(268, 155)
        Me.txt_capacidad.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_capacidad.MaxLength = 100
        Me.txt_capacidad.Name = "txt_capacidad"
        Me.txt_capacidad.Size = New System.Drawing.Size(217, 31)
        Me.txt_capacidad.TabIndex = 248
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 156)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(250, 28)
        Me.Label3.TabIndex = 247
        Me.Label3.Text = "Capacidad de carga (Tn):"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(568, 97)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 32)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Marca:"
        '
        'cbmarca
        '
        Me.cbmarca.BackColor = System.Drawing.SystemColors.Window
        Me.cbmarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmarca.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.cbmarca.FormattingEnabled = True
        Me.cbmarca.Items.AddRange(New Object() {" "})
        Me.cbmarca.Location = New System.Drawing.Point(653, 99)
        Me.cbmarca.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbmarca.Name = "cbmarca"
        Me.cbmarca.Size = New System.Drawing.Size(348, 33)
        Me.cbmarca.TabIndex = 245
        '
        'txt_año
        '
        Me.txt_año.CustomFormat = "yyyy"
        Me.txt_año.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_año.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txt_año.Location = New System.Drawing.Point(268, 101)
        Me.txt_año.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_año.Name = "txt_año"
        Me.txt_año.Size = New System.Drawing.Size(217, 28)
        Me.txt_año.TabIndex = 244
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(500, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 23)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Tipo vehículo:"
        '
        'cbtipovehiculo
        '
        Me.cbtipovehiculo.BackColor = System.Drawing.SystemColors.Window
        Me.cbtipovehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipovehiculo.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.cbtipovehiculo.FormattingEnabled = True
        Me.cbtipovehiculo.Items.AddRange(New Object() {" "})
        Me.cbtipovehiculo.Location = New System.Drawing.Point(653, 45)
        Me.cbtipovehiculo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbtipovehiculo.Name = "cbtipovehiculo"
        Me.cbtipovehiculo.Size = New System.Drawing.Size(348, 33)
        Me.cbtipovehiculo.TabIndex = 239
        '
        'txt_modelo
        '
        Me.txt_modelo.BackColor = System.Drawing.SystemColors.Window
        Me.txt_modelo.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.txt_modelo.Location = New System.Drawing.Point(652, 155)
        Me.txt_modelo.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_modelo.MaxLength = 100
        Me.txt_modelo.Name = "txt_modelo"
        Me.txt_modelo.Size = New System.Drawing.Size(348, 31)
        Me.txt_modelo.TabIndex = 212
        '
        'cs16
        '
        Me.cs16.BackColor = System.Drawing.Color.Transparent
        Me.cs16.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.cs16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.cs16.Location = New System.Drawing.Point(555, 156)
        Me.cs16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.cs16.Name = "cs16"
        Me.cs16.Size = New System.Drawing.Size(89, 28)
        Me.cs16.TabIndex = 211
        Me.cs16.Text = "Modelo:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(98, 101)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(160, 29)
        Me.Label15.TabIndex = 206
        Me.Label15.Text = "Año fabricación:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(111, 47)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 29)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "Número placa: "
        '
        'txt_numplaca
        '
        Me.txt_numplaca.BackColor = System.Drawing.SystemColors.Window
        Me.txt_numplaca.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numplaca.Location = New System.Drawing.Point(268, 45)
        Me.txt_numplaca.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_numplaca.MaxLength = 100
        Me.txt_numplaca.Name = "txt_numplaca"
        Me.txt_numplaca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_numplaca.Size = New System.Drawing.Size(217, 31)
        Me.txt_numplaca.TabIndex = 226
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(36, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(429, 48)
        Me.Label9.TabIndex = 235
        Me.Label9.Text = "REGISTRO DE TRANSPORTES"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(674, 83)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 32)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Estado:"
        '
        'cbestado
        '
        Me.cbestado.BackColor = System.Drawing.SystemColors.Window
        Me.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbestado.FormattingEnabled = True
        Me.cbestado.Items.AddRange(New Object() {"ACTIVO", "EN MANTENIMIENTO", "INACTIVO"})
        Me.cbestado.Location = New System.Drawing.Point(762, 85)
        Me.cbestado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbestado.Name = "cbestado"
        Me.cbestado.Size = New System.Drawing.Size(217, 28)
        Me.cbestado.TabIndex = 249
        '
        'FrmNuevoTransporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1121, 452)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbestado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNuevoTransporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRAR TRANSPORTE"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnsalir As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbtipovehiculo As ComboBox
    Friend WithEvents txt_modelo As TextBox
    Friend WithEvents cs16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_numplaca As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbmarca As ComboBox
    Friend WithEvents txt_año As DateTimePicker
    Friend WithEvents txt_capacidad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cbestado As ComboBox
    Friend WithEvents txtpesotara As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnnuevoytipo As ToolStripButton
End Class
