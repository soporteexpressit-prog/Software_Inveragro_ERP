<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgregarDescansoMedico
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
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ct22 = New System.Windows.Forms.TextBox()
        Me.ct21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbtpdescanso = New System.Windows.Forms.ComboBox()
        Me.lblDiasDiferencia = New System.Windows.Forms.Label()
        Me.txtmotivopermiso = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtdni = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtedad = New System.Windows.Forms.TextBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtcargo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtsexo = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.checkpendiete = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.lb_dias_disponibles = New System.Windows.Forms.Label()
        Me.txt_dias_pendientes = New System.Windows.Forms.Label()
        Me.ct23 = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cbxventaVaca = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.checkpendiete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxventaVaca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ToolStrip1.Size = New System.Drawing.Size(916, 38)
        Me.ToolStrip1.TabIndex = 179
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(11, 51)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(232, 18)
        Me.Label9.TabIndex = 180
        Me.Label9.Text = "REGISTRO DE PERMISOS"
        '
        'ct22
        '
        Me.ct22.BackColor = System.Drawing.SystemColors.Window
        Me.ct22.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ct22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ct22.Location = New System.Drawing.Point(174, 274)
        Me.ct22.MaxLength = 100
        Me.ct22.Name = "ct22"
        Me.ct22.ReadOnly = True
        Me.ct22.Size = New System.Drawing.Size(377, 22)
        Me.ct22.TabIndex = 242
        '
        'ct21
        '
        Me.ct21.AutoSize = True
        Me.ct21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ct21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ct21.Location = New System.Drawing.Point(27, 277)
        Me.ct21.Name = "ct21"
        Me.ct21.Size = New System.Drawing.Size(141, 14)
        Me.ct21.TabIndex = 241
        Me.ct21.Text = "Adjuntar Documento:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(57, 44)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 14)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Tipo de permiso:"
        '
        'cbtpdescanso
        '
        Me.cbtpdescanso.BackColor = System.Drawing.SystemColors.Window
        Me.cbtpdescanso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtpdescanso.FormattingEnabled = True
        Me.cbtpdescanso.Location = New System.Drawing.Point(181, 42)
        Me.cbtpdescanso.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.cbtpdescanso.Name = "cbtpdescanso"
        Me.cbtpdescanso.Size = New System.Drawing.Size(241, 21)
        Me.cbtpdescanso.TabIndex = 239
        '
        'lblDiasDiferencia
        '
        Me.lblDiasDiferencia.BackColor = System.Drawing.Color.White
        Me.lblDiasDiferencia.Location = New System.Drawing.Point(177, 156)
        Me.lblDiasDiferencia.Name = "lblDiasDiferencia"
        Me.lblDiasDiferencia.Size = New System.Drawing.Size(77, 25)
        Me.lblDiasDiferencia.TabIndex = 232
        Me.lblDiasDiferencia.Text = "0"
        Me.lblDiasDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmotivopermiso
        '
        Me.txtmotivopermiso.BackColor = System.Drawing.SystemColors.Window
        Me.txtmotivopermiso.Location = New System.Drawing.Point(174, 197)
        Me.txtmotivopermiso.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.txtmotivopermiso.MaxLength = 1000
        Me.txtmotivopermiso.Multiline = True
        Me.txtmotivopermiso.Name = "txtmotivopermiso"
        Me.txtmotivopermiso.Size = New System.Drawing.Size(697, 55)
        Me.txtmotivopermiso.TabIndex = 231
        Me.txtmotivopermiso.Text = "NINGUNO"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(85, 199)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 14)
        Me.Label21.TabIndex = 230
        Me.Label21.Text = "Descripción:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(9, 161)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(162, 14)
        Me.Label27.TabIndex = 229
        Me.Label27.Text = "N° de dias de descanso:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(556, 42)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(101, 21)
        Me.dtpFechaInicio.TabIndex = 227
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(34, 80)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 14)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "Nombres y Apellidos:"
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.SystemColors.Window
        Me.txtnombre.Enabled = False
        Me.txtnombre.Location = New System.Drawing.Point(182, 76)
        Me.txtnombre.Margin = New System.Windows.Forms.Padding(1)
        Me.txtnombre.MaxLength = 100
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(370, 20)
        Me.txtnombre.TabIndex = 226
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(666, 80)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 14)
        Me.Label15.TabIndex = 206
        Me.Label15.Text = "Dni:"
        '
        'txtdni
        '
        Me.txtdni.BackColor = System.Drawing.SystemColors.Window
        Me.txtdni.Enabled = False
        Me.txtdni.Location = New System.Drawing.Point(711, 76)
        Me.txtdni.Margin = New System.Windows.Forms.Padding(1)
        Me.txtdni.MaxLength = 100
        Me.txtdni.Name = "txtdni"
        Me.txtdni.ReadOnly = True
        Me.txtdni.Size = New System.Drawing.Size(160, 20)
        Me.txtdni.TabIndex = 208
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(437, 119)
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
        Me.Label26.Location = New System.Drawing.Point(665, 44)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 14)
        Me.Label26.TabIndex = 224
        Me.Label26.Text = "Fecha de fin:"
        '
        'txtedad
        '
        Me.txtedad.BackColor = System.Drawing.SystemColors.Window
        Me.txtedad.Enabled = False
        Me.txtedad.Location = New System.Drawing.Point(487, 118)
        Me.txtedad.Margin = New System.Windows.Forms.Padding(1)
        Me.txtedad.MaxLength = 100
        Me.txtedad.Name = "txtedad"
        Me.txtedad.ReadOnly = True
        Me.txtedad.Size = New System.Drawing.Size(101, 20)
        Me.txtedad.TabIndex = 210
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CalendarMonthBackground = System.Drawing.SystemColors.Control
        Me.dtpFechaFin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(771, 42)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(100, 21)
        Me.dtpFechaFin.TabIndex = 223
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(46, 119)
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
        Me.Label25.Location = New System.Drawing.Point(441, 44)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(104, 14)
        Me.Label25.TabIndex = 222
        Me.Label25.Text = "Fecha de inicio:"
        '
        'txtcargo
        '
        Me.txtcargo.BackColor = System.Drawing.SystemColors.Window
        Me.txtcargo.Enabled = False
        Me.txtcargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtcargo.Location = New System.Drawing.Point(182, 118)
        Me.txtcargo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtcargo.MaxLength = 100
        Me.txtcargo.Name = "txtcargo"
        Me.txtcargo.ReadOnly = True
        Me.txtcargo.Size = New System.Drawing.Size(241, 20)
        Me.txtcargo.TabIndex = 212
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(597, 119)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 14)
        Me.Label18.TabIndex = 213
        Me.Label18.Text = "Sexo:"
        '
        'txtsexo
        '
        Me.txtsexo.BackColor = System.Drawing.SystemColors.Window
        Me.txtsexo.Enabled = False
        Me.txtsexo.Location = New System.Drawing.Point(641, 118)
        Me.txtsexo.Margin = New System.Windows.Forms.Padding(1)
        Me.txtsexo.MaxLength = 100
        Me.txtsexo.Name = "txtsexo"
        Me.txtsexo.ReadOnly = True
        Me.txtsexo.Size = New System.Drawing.Size(160, 20)
        Me.txtsexo.TabIndex = 214
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(464, 72)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(101, 21)
        Me.DateTimePicker2.TabIndex = 233
        Me.DateTimePicker2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(327, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 14)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "Fecha de Registro:"
        Me.Label1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.checkpendiete)
        Me.GroupBox1.Controls.Add(Me.lb_dias_disponibles)
        Me.GroupBox1.Controls.Add(Me.txt_dias_pendientes)
        Me.GroupBox1.Controls.Add(Me.ct23)
        Me.GroupBox1.Controls.Add(Me.txtcargo)
        Me.GroupBox1.Controls.Add(Me.ct22)
        Me.GroupBox1.Controls.Add(Me.ct21)
        Me.GroupBox1.Controls.Add(Me.txtsexo)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblDiasDiferencia)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtmotivopermiso)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.cbtpdescanso)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.txtedad)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.txtdni)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtnombre)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(888, 316)
        Me.GroupBox1.TabIndex = 234
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Descanso:"
        '
        'checkpendiete
        '
        Me.checkpendiete.Location = New System.Drawing.Point(625, 159)
        Me.checkpendiete.Margin = New System.Windows.Forms.Padding(2)
        Me.checkpendiete.Name = "checkpendiete"
        Me.checkpendiete.Size = New System.Drawing.Size(125, 19)
        Me.checkpendiete.TabIndex = 246
        Me.checkpendiete.Text = "Adelanto de días"
        '
        'lb_dias_disponibles
        '
        Me.lb_dias_disponibles.BackColor = System.Drawing.Color.White
        Me.lb_dias_disponibles.Location = New System.Drawing.Point(509, 156)
        Me.lb_dias_disponibles.Name = "lb_dias_disponibles"
        Me.lb_dias_disponibles.Size = New System.Drawing.Size(77, 25)
        Me.lb_dias_disponibles.TabIndex = 245
        Me.lb_dias_disponibles.Text = "0"
        Me.lb_dias_disponibles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_dias_pendientes
        '
        Me.txt_dias_pendientes.AutoSize = True
        Me.txt_dias_pendientes.BackColor = System.Drawing.Color.Transparent
        Me.txt_dias_pendientes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dias_pendientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txt_dias_pendientes.Location = New System.Drawing.Point(272, 161)
        Me.txt_dias_pendientes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt_dias_pendientes.Name = "txt_dias_pendientes"
        Me.txt_dias_pendientes.Size = New System.Drawing.Size(224, 14)
        Me.txt_dias_pendientes.TabIndex = 244
        Me.txt_dias_pendientes.Text = "N° Días de Descanso Disponibles :"
        '
        'ct23
        '
        Me.ct23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ct23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ct23.Image = Global.Formularios.My.Resources.Resources.adjunto_archivo
        Me.ct23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ct23.Location = New System.Drawing.Point(556, 269)
        Me.ct23.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ct23.Name = "ct23"
        Me.ct23.Size = New System.Drawing.Size(90, 30)
        Me.ct23.TabIndex = 243
        Me.ct23.Text = "Adjuntar"
        Me.ct23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ct23.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(557, 73)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(77, 29)
        Me.btnAgregar.TabIndex = 225
        Me.btnAgregar.Text = "Buscar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cbxventaVaca
        '
        Me.cbxventaVaca.Location = New System.Drawing.Point(785, 52)
        Me.cbxventaVaca.Margin = New System.Windows.Forms.Padding(2)
        Me.cbxventaVaca.Name = "cbxventaVaca"
        Me.cbxventaVaca.Size = New System.Drawing.Size(117, 17)
        Me.cbxventaVaca.TabIndex = 247
        Me.cbxventaVaca.Text = "Venta vacaciones"
        '
        'FrmAgregarDescansoMedico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(916, 414)
        Me.Controls.Add(Me.cbxventaVaca)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximumSize = New System.Drawing.Size(932, 453)
        Me.MinimumSize = New System.Drawing.Size(932, 453)
        Me.Name = "FrmAgregarDescansoMedico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AGREGAR DESCANSO MEDICO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.checkpendiete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxventaVaca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnsalir As ToolStripButton
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtdni As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtedad As TextBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtcargo As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtsexo As TextBox
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label27 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtmotivopermiso As TextBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDiasDiferencia As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbtpdescanso As ComboBox
    Friend WithEvents ct23 As Button
    Friend WithEvents ct22 As TextBox
    Friend WithEvents ct21 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lb_dias_disponibles As Label
    Friend WithEvents txt_dias_pendientes As Label
    Friend WithEvents checkpendiete As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cbxventaVaca As Infragistics.Win.UltraWinEditors.UltraCheckEditor
End Class
