<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAgregarincidencia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.noafiliados = New System.Windows.Forms.TextBox()
        Me.nafiliados = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtnombreaseguradora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbTipoacidente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.cbturno = New System.Windows.Forms.ComboBox()
        Me.dtphorastrabajadas = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtdni = New System.Windows.Forms.TextBox()
        Me.txtlugarocurrencia = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtedad = New System.Windows.Forms.TextBox()
        Me.dtpfechainvestigacion = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtCargo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtsexo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpfechayhoraocurrencia = New System.Windows.Forms.DateTimePicker()
        Me.txtarea = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblContador2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdescripcioncuerpoafe = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.numpersonasafectadas = New System.Windows.Forms.NumericUpDown()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.numdiasdes = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbGradoaccidente = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbGravedadaccidente = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblContador3 = New System.Windows.Forms.Label()
        Me.cbConsecuencia = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbprobabilidad = New System.Windows.Forms.ComboBox()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnañadircausas = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numpersonasafectadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numdiasdes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(32, 48)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(374, 18)
        Me.Label9.TabIndex = 177
        Me.Label9.Text = "REGISTRO DE INCIDENTE / ACCIDENTES"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnsalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(960, 38)
        Me.ToolStrip1.TabIndex = 178
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
        Me.btnGuardar.Size = New System.Drawing.Size(89, 28)
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
        Me.btnsalir.Size = New System.Drawing.Size(66, 28)
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.ToolTipText = "Editar"
        '
        'noafiliados
        '
        Me.noafiliados.BackColor = System.Drawing.SystemColors.Window
        Me.noafiliados.Enabled = False
        Me.noafiliados.Location = New System.Drawing.Point(243, 63)
        Me.noafiliados.Margin = New System.Windows.Forms.Padding(1)
        Me.noafiliados.MaxLength = 100
        Me.noafiliados.Name = "noafiliados"
        Me.noafiliados.ReadOnly = True
        Me.noafiliados.Size = New System.Drawing.Size(71, 22)
        Me.noafiliados.TabIndex = 231
        '
        'nafiliados
        '
        Me.nafiliados.BackColor = System.Drawing.SystemColors.Window
        Me.nafiliados.Enabled = False
        Me.nafiliados.Location = New System.Drawing.Point(243, 32)
        Me.nafiliados.Margin = New System.Windows.Forms.Padding(1)
        Me.nafiliados.MaxLength = 100
        Me.nafiliados.Name = "nafiliados"
        Me.nafiliados.ReadOnly = True
        Me.nafiliados.Size = New System.Drawing.Size(71, 22)
        Me.nafiliados.TabIndex = 230
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(27, 67)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(210, 14)
        Me.Label13.TabIndex = 206
        Me.Label13.Text = "N° de trabajadores no afiliados:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(67, 36)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(170, 14)
        Me.Label8.TabIndex = 205
        Me.Label8.Text = "N° trabajadores afiliados:"
        '
        'txtnombreaseguradora
        '
        Me.txtnombreaseguradora.BackColor = System.Drawing.SystemColors.Window
        Me.txtnombreaseguradora.Enabled = False
        Me.txtnombreaseguradora.Location = New System.Drawing.Point(641, 31)
        Me.txtnombreaseguradora.Margin = New System.Windows.Forms.Padding(1)
        Me.txtnombreaseguradora.MaxLength = 100
        Me.txtnombreaseguradora.Name = "txtnombreaseguradora"
        Me.txtnombreaseguradora.ReadOnly = True
        Me.txtnombreaseguradora.Size = New System.Drawing.Size(270, 22)
        Me.txtnombreaseguradora.TabIndex = 204
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(513, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 14)
        Me.Label2.TabIndex = 203
        Me.Label2.Text = "Tipo de accidente:"
        '
        'cbTipoacidente
        '
        Me.cbTipoacidente.BackColor = System.Drawing.SystemColors.Window
        Me.cbTipoacidente.FormattingEnabled = True
        Me.cbTipoacidente.Location = New System.Drawing.Point(641, 62)
        Me.cbTipoacidente.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbTipoacidente.Name = "cbTipoacidente"
        Me.cbTipoacidente.Size = New System.Drawing.Size(270, 22)
        Me.cbTipoacidente.TabIndex = 201
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(453, 38)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 14)
        Me.Label6.TabIndex = 202
        Me.Label6.Text = "Nombre de la aseguradora:"
        '
        'lblContador
        '
        Me.lblContador.BackColor = System.Drawing.Color.White
        Me.lblContador.Location = New System.Drawing.Point(847, 151)
        Me.lblContador.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(61, 23)
        Me.lblContador.TabIndex = 229
        Me.lblContador.Visible = False
        '
        'cbturno
        '
        Me.cbturno.BackColor = System.Drawing.SystemColors.Window
        Me.cbturno.FormattingEnabled = True
        Me.cbturno.Location = New System.Drawing.Point(572, 53)
        Me.cbturno.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbturno.Name = "cbturno"
        Me.cbturno.Size = New System.Drawing.Size(139, 22)
        Me.cbturno.TabIndex = 228
        '
        'dtphorastrabajadas
        '
        Me.dtphorastrabajadas.CalendarFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphorastrabajadas.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtphorastrabajadas.CustomFormat = "HH:mm"
        Me.dtphorastrabajadas.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtphorastrabajadas.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtphorastrabajadas.Location = New System.Drawing.Point(448, 157)
        Me.dtphorastrabajadas.Name = "dtphorastrabajadas"
        Me.dtphorastrabajadas.Size = New System.Drawing.Size(82, 21)
        Me.dtphorastrabajadas.TabIndex = 227
        Me.dtphorastrabajadas.Value = New Date(2024, 10, 11, 11, 55, 36, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(19, 24)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 14)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "Nombres y apellidos:"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(171, 20)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox4.MaxLength = 100
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(250, 22)
        Me.TextBox4.TabIndex = 226
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(530, 24)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 14)
        Me.Label15.TabIndex = 206
        Me.Label15.Text = "Dni:"
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(425, 19)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(86, 29)
        Me.btnAgregar.TabIndex = 225
        Me.btnAgregar.Text = "Buscar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtdni
        '
        Me.txtdni.BackColor = System.Drawing.SystemColors.Window
        Me.txtdni.Enabled = False
        Me.txtdni.Location = New System.Drawing.Point(572, 20)
        Me.txtdni.Margin = New System.Windows.Forms.Padding(1)
        Me.txtdni.MaxLength = 100
        Me.txtdni.Name = "txtdni"
        Me.txtdni.ReadOnly = True
        Me.txtdni.Size = New System.Drawing.Size(139, 22)
        Me.txtdni.TabIndex = 208
        '
        'txtlugarocurrencia
        '
        Me.txtlugarocurrencia.BackColor = System.Drawing.SystemColors.Window
        Me.txtlugarocurrencia.Location = New System.Drawing.Point(171, 87)
        Me.txtlugarocurrencia.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.txtlugarocurrencia.MaxLength = 1000
        Me.txtlugarocurrencia.Multiline = True
        Me.txtlugarocurrencia.Name = "txtlugarocurrencia"
        Me.txtlugarocurrencia.Size = New System.Drawing.Size(737, 57)
        Me.txtlugarocurrencia.TabIndex = 207
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(744, 24)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 14)
        Me.Label16.TabIndex = 209
        Me.Label16.Text = "Edad:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(571, 197)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(225, 14)
        Me.Label26.TabIndex = 224
        Me.Label26.Text = "Fecha de inicio de la investigación:"
        '
        'txtedad
        '
        Me.txtedad.BackColor = System.Drawing.SystemColors.Window
        Me.txtedad.Enabled = False
        Me.txtedad.Location = New System.Drawing.Point(798, 20)
        Me.txtedad.Margin = New System.Windows.Forms.Padding(1)
        Me.txtedad.MaxLength = 100
        Me.txtedad.Name = "txtedad"
        Me.txtedad.ReadOnly = True
        Me.txtedad.Size = New System.Drawing.Size(111, 22)
        Me.txtedad.TabIndex = 210
        '
        'dtpfechainvestigacion
        '
        Me.dtpfechainvestigacion.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpfechainvestigacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechainvestigacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainvestigacion.Location = New System.Drawing.Point(803, 190)
        Me.dtpfechainvestigacion.Name = "dtpfechainvestigacion"
        Me.dtpfechainvestigacion.Size = New System.Drawing.Size(105, 21)
        Me.dtpfechainvestigacion.TabIndex = 223
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(32, 57)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 14)
        Me.Label17.TabIndex = 211
        Me.Label17.Text = "Puesto de trabajo:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(12, 194)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(153, 14)
        Me.Label25.TabIndex = 222
        Me.Label25.Text = "Fecha de la ocurrencia:"
        '
        'txtCargo
        '
        Me.txtCargo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCargo.Enabled = False
        Me.txtCargo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCargo.Location = New System.Drawing.Point(171, 53)
        Me.txtCargo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtCargo.MaxLength = 100
        Me.txtCargo.Name = "txtCargo"
        Me.txtCargo.ReadOnly = True
        Me.txtCargo.Size = New System.Drawing.Size(161, 22)
        Me.txtCargo.TabIndex = 212
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(287, 160)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(154, 14)
        Me.Label24.TabIndex = 221
        Me.Label24.Text = "(Antes del accidente):"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(357, 57)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 14)
        Me.Label18.TabIndex = 213
        Me.Label18.Text = "Sexo:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(64, 111)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(96, 14)
        Me.Label23.TabIndex = 220
        Me.Label23.Text = "La ocurrencia:"
        '
        'txtsexo
        '
        Me.txtsexo.BackColor = System.Drawing.SystemColors.Window
        Me.txtsexo.Enabled = False
        Me.txtsexo.Location = New System.Drawing.Point(405, 53)
        Me.txtsexo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtsexo.MaxLength = 100
        Me.txtsexo.Name = "txtsexo"
        Me.txtsexo.ReadOnly = True
        Me.txtsexo.Size = New System.Drawing.Size(104, 22)
        Me.txtsexo.TabIndex = 214
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(12, 160)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(271, 14)
        Me.Label22.TabIndex = 219
        Me.Label22.Text = "N° horas trabajadas en la jornada laboral"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(514, 57)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 14)
        Me.Label19.TabIndex = 215
        Me.Label19.Text = "Turno:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(49, 97)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(109, 14)
        Me.Label21.TabIndex = 218
        Me.Label21.Text = "Lugar exacto de"
        '
        'dtpfechayhoraocurrencia
        '
        Me.dtpfechayhoraocurrencia.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpfechayhoraocurrencia.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpfechayhoraocurrencia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechayhoraocurrencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfechayhoraocurrencia.Location = New System.Drawing.Point(171, 191)
        Me.dtpfechayhoraocurrencia.Name = "dtpfechayhoraocurrencia"
        Me.dtpfechayhoraocurrencia.Size = New System.Drawing.Size(154, 21)
        Me.dtpfechayhoraocurrencia.TabIndex = 204
        '
        'txtarea
        '
        Me.txtarea.BackColor = System.Drawing.SystemColors.Window
        Me.txtarea.Enabled = False
        Me.txtarea.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtarea.Location = New System.Drawing.Point(798, 53)
        Me.txtarea.Margin = New System.Windows.Forms.Padding(1)
        Me.txtarea.MaxLength = 100
        Me.txtarea.Name = "txtarea"
        Me.txtarea.ReadOnly = True
        Me.txtarea.Size = New System.Drawing.Size(111, 22)
        Me.txtarea.TabIndex = 217
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(745, 57)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 14)
        Me.Label20.TabIndex = 216
        Me.Label20.Text = "Area:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(146, 110)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 14)
        Me.Label14.TabIndex = 219
        Me.Label14.Text = "lesionado:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContador2
        '
        Me.lblContador2.BackColor = System.Drawing.Color.White
        Me.lblContador2.Location = New System.Drawing.Point(850, 50)
        Me.lblContador2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblContador2.Name = "lblContador2"
        Me.lblContador2.Size = New System.Drawing.Size(58, 26)
        Me.lblContador2.TabIndex = 218
        Me.lblContador2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(103, 110)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 14)
        Me.Label1.TabIndex = 217
        '
        'txtdescripcioncuerpoafe
        '
        Me.txtdescripcioncuerpoafe.BackColor = System.Drawing.SystemColors.Window
        Me.txtdescripcioncuerpoafe.Location = New System.Drawing.Point(231, 86)
        Me.txtdescripcioncuerpoafe.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.txtdescripcioncuerpoafe.MaxLength = 500
        Me.txtdescripcioncuerpoafe.Multiline = True
        Me.txtdescripcioncuerpoafe.Name = "txtdescripcioncuerpoafe"
        Me.txtdescripcioncuerpoafe.Size = New System.Drawing.Size(666, 38)
        Me.txtdescripcioncuerpoafe.TabIndex = 207
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(46, 96)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(173, 14)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = "Describir parte del cuerpo "
        '
        'numpersonasafectadas
        '
        Me.numpersonasafectadas.BackColor = System.Drawing.SystemColors.Control
        Me.numpersonasafectadas.Location = New System.Drawing.Point(712, 50)
        Me.numpersonasafectadas.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.numpersonasafectadas.Name = "numpersonasafectadas"
        Me.numpersonasafectadas.Size = New System.Drawing.Size(51, 22)
        Me.numpersonasafectadas.TabIndex = 214
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(529, 50)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(177, 14)
        Me.Label28.TabIndex = 215
        Me.Label28.Text = "N° de personas afectadas:"
        '
        'numdiasdes
        '
        Me.numdiasdes.BackColor = System.Drawing.SystemColors.Window
        Me.numdiasdes.Location = New System.Drawing.Point(231, 56)
        Me.numdiasdes.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.numdiasdes.Name = "numdiasdes"
        Me.numdiasdes.Size = New System.Drawing.Size(66, 22)
        Me.numdiasdes.TabIndex = 208
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(9, 57)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(210, 14)
        Me.Label27.TabIndex = 209
        Me.Label27.Text = "N° de dias de descanso médico:"
        '
        'cbGradoaccidente
        '
        Me.cbGradoaccidente.BackColor = System.Drawing.SystemColors.Window
        Me.cbGradoaccidente.FormattingEnabled = True
        Me.cbGradoaccidente.Location = New System.Drawing.Point(712, 17)
        Me.cbGradoaccidente.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbGradoaccidente.Name = "cbGradoaccidente"
        Me.cbGradoaccidente.Size = New System.Drawing.Size(196, 22)
        Me.cbGradoaccidente.TabIndex = 212
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(569, 20)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 14)
        Me.Label7.TabIndex = 213
        Me.Label7.Text = "Grado del accidente:"
        '
        'cbGravedadaccidente
        '
        Me.cbGravedadaccidente.BackColor = System.Drawing.SystemColors.Window
        Me.cbGravedadaccidente.FormattingEnabled = True
        Me.cbGravedadaccidente.Location = New System.Drawing.Point(231, 24)
        Me.cbGravedadaccidente.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbGravedadaccidente.Name = "cbGravedadaccidente"
        Me.cbGravedadaccidente.Size = New System.Drawing.Size(196, 22)
        Me.cbGravedadaccidente.TabIndex = 210
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(59, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 14)
        Me.Label5.TabIndex = 211
        Me.Label5.Text = "Gravedad del accidente:"
        '
        'lblContador3
        '
        Me.lblContador3.BackColor = System.Drawing.Color.White
        Me.lblContador3.Location = New System.Drawing.Point(450, 27)
        Me.lblContador3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblContador3.Name = "lblContador3"
        Me.lblContador3.Size = New System.Drawing.Size(52, 20)
        Me.lblContador3.TabIndex = 214
        Me.lblContador3.Visible = False
        '
        'cbConsecuencia
        '
        Me.cbConsecuencia.BackColor = System.Drawing.SystemColors.Window
        Me.cbConsecuencia.FormattingEnabled = True
        Me.cbConsecuencia.Location = New System.Drawing.Point(726, 18)
        Me.cbConsecuencia.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbConsecuencia.Name = "cbConsecuencia"
        Me.cbConsecuencia.Size = New System.Drawing.Size(182, 21)
        Me.cbConsecuencia.TabIndex = 212
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(621, 24)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 14)
        Me.Label11.TabIndex = 213
        Me.Label11.Text = "Consecuencia:"
        '
        'cbprobabilidad
        '
        Me.cbprobabilidad.BackColor = System.Drawing.SystemColors.Window
        Me.cbprobabilidad.FormattingEnabled = True
        Me.cbprobabilidad.Location = New System.Drawing.Point(150, 22)
        Me.cbprobabilidad.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbprobabilidad.Name = "cbprobabilidad"
        Me.cbprobabilidad.Size = New System.Drawing.Size(182, 21)
        Me.cbprobabilidad.TabIndex = 210
        '
        'txtdescripcion
        '
        Me.txtdescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtdescripcion.Location = New System.Drawing.Point(15, 17)
        Me.txtdescripcion.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.txtdescripcion.MaxLength = 1000
        Me.txtdescripcion.Multiline = True
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(893, 61)
        Me.txtdescripcion.TabIndex = 208
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(42, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 14)
        Me.Label3.TabIndex = 211
        Me.Label3.Text = "Probabilidad:"
        '
        'btnañadircausas
        '
        Me.btnañadircausas.BackColor = System.Drawing.Color.White
        Me.btnañadircausas.Font = New System.Drawing.Font("Verdana", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnañadircausas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnañadircausas.Image = Global.Formularios.My.Resources.Resources.Agregar_24_Px
        Me.btnañadircausas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnañadircausas.Location = New System.Drawing.Point(783, 21)
        Me.btnañadircausas.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.btnañadircausas.Name = "btnañadircausas"
        Me.btnañadircausas.Size = New System.Drawing.Size(128, 31)
        Me.btnañadircausas.TabIndex = 208
        Me.btnañadircausas.Text = "Añadir Causas"
        Me.btnañadircausas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnañadircausas.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(153, 26)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(1)
        Me.TextBox5.MaxLength = 100
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(317, 21)
        Me.TextBox5.TabIndex = 207
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(474, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 29)
        Me.Button1.TabIndex = 206
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(7, 33)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 14)
        Me.Label12.TabIndex = 205
        Me.Label12.Text = "Nombres y apellidos:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.noafiliados)
        Me.GroupBox1.Controls.Add(Me.cbTipoacidente)
        Me.GroupBox1.Controls.Add(Me.nafiliados)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtnombreaseguradora)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(32, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(916, 98)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Completar SI el Empleador Considera Alto Riesgo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblContador)
        Me.GroupBox2.Controls.Add(Me.txtlugarocurrencia)
        Me.GroupBox2.Controls.Add(Me.dtphorastrabajadas)
        Me.GroupBox2.Controls.Add(Me.cbturno)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.dtpfechainvestigacion)
        Me.GroupBox2.Controls.Add(Me.txtarea)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.dtpfechayhoraocurrencia)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtsexo)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtdni)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtCargo)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtedad)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(35, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(913, 226)
        Me.GroupBox2.TabIndex = 214
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Accidentado"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblContador2)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.numpersonasafectadas)
        Me.GroupBox3.Controls.Add(Me.txtdescripcioncuerpoafe)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.numdiasdes)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbGradoaccidente)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cbGravedadaccidente)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(35, 419)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(913, 137)
        Me.GroupBox3.TabIndex = 215
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Completar Solo En Caso Accidente de Trabajo"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtdescripcion)
        Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(35, 562)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(913, 87)
        Me.GroupBox4.TabIndex = 216
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Describir Claramente Como Sucedió El Accidente / Emergencia"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblContador3)
        Me.GroupBox5.Controls.Add(Me.cbConsecuencia)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.cbprobabilidad)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(35, 655)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(913, 56)
        Me.GroupBox5.TabIndex = 217
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Describir Claramente Como Sucedió El Accidente / Emergencia"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnañadircausas)
        Me.GroupBox6.Controls.Add(Me.TextBox5)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.Button1)
        Me.GroupBox6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(32, 717)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(916, 66)
        Me.GroupBox6.TabIndex = 218
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Encargado de la Investigación"
        '
        'FrmAgregarincidencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(960, 798)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label9)
        Me.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(976, 837)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(976, 837)
        Me.Name = "FrmAgregarincidencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO DE INCIDENTE"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numpersonasafectadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numdiasdes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnsalir As ToolStripButton
    Friend WithEvents txtnombreaseguradora As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTipoacidente As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbturno As ComboBox
    Friend WithEvents dtphorastrabajadas As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtdni As TextBox
    Friend WithEvents txtlugarocurrencia As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtedad As TextBox
    Friend WithEvents dtpfechainvestigacion As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtCargo As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtsexo As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents dtpfechayhoraocurrencia As DateTimePicker
    Friend WithEvents txtarea As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtdescripcioncuerpoafe As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents numpersonasafectadas As NumericUpDown
    Friend WithEvents Label28 As Label
    Friend WithEvents numdiasdes As NumericUpDown
    Friend WithEvents Label27 As Label
    Friend WithEvents cbGradoaccidente As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbGravedadaccidente As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbConsecuencia As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbprobabilidad As ComboBox
    Friend WithEvents txtdescripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnañadircausas As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents lblContador As Label
    Friend WithEvents lblContador2 As Label
    Friend WithEvents lblContador3 As Label
    Friend WithEvents noafiliados As TextBox
    Friend WithEvents nafiliados As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
End Class
