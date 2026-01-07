<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportePesosGranja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportePesosGranja))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfhasta = New System.Windows.Forms.DateTimePicker()
        Me.CkbOmitirConsDona = New System.Windows.Forms.CheckBox()
        Me.LblEdadPond = New System.Windows.Forms.Label()
        Me.LblEdadPonderada = New System.Windows.Forms.Label()
        Me.LblPesoPromedio = New System.Windows.Forms.Label()
        Me.CkbOmitirFecha = New System.Windows.Forms.CheckBox()
        Me.LblPesoProm = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.BtnBusqueda = New System.Windows.Forms.Button()
        Me.LblAnio = New System.Windows.Forms.Label()
        Me.CkbOmitirSemana = New System.Windows.Forms.CheckBox()
        Me.CmbAnios = New System.Windows.Forms.ComboBox()
        Me.CkbOmitirMes = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbSemanas = New System.Windows.Forms.ComboBox()
        Me.CmbMeses = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblDiaPic = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnExportarhistoricomortalidad = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Clickomitiranio = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.LblDiaPic)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1231, 252)
        Me.Panel1.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Clickomitiranio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpfhasta)
        Me.GroupBox2.Controls.Add(Me.CkbOmitirConsDona)
        Me.GroupBox2.Controls.Add(Me.LblEdadPond)
        Me.GroupBox2.Controls.Add(Me.LblEdadPonderada)
        Me.GroupBox2.Controls.Add(Me.LblPesoPromedio)
        Me.GroupBox2.Controls.Add(Me.CkbOmitirFecha)
        Me.GroupBox2.Controls.Add(Me.LblPesoProm)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.DtpFecha)
        Me.GroupBox2.Controls.Add(Me.BtnBusqueda)
        Me.GroupBox2.Controls.Add(Me.LblAnio)
        Me.GroupBox2.Controls.Add(Me.CkbOmitirSemana)
        Me.GroupBox2.Controls.Add(Me.CmbAnios)
        Me.GroupBox2.Controls.Add(Me.CkbOmitirMes)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.CmbSemanas)
        Me.GroupBox2.Controls.Add(Me.CmbMeses)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 65)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(1151, 144)
        Me.GroupBox2.TabIndex = 260
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtros de Búsqueda"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(5, 86)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "F. Desde :"
        '
        'dtpfhasta
        '
        Me.dtpfhasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfhasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfhasta.Location = New System.Drawing.Point(282, 84)
        Me.dtpfhasta.Name = "dtpfhasta"
        Me.dtpfhasta.Size = New System.Drawing.Size(110, 24)
        Me.dtpfhasta.TabIndex = 270
        '
        'CkbOmitirConsDona
        '
        Me.CkbOmitirConsDona.AutoSize = True
        Me.CkbOmitirConsDona.Location = New System.Drawing.Point(439, 86)
        Me.CkbOmitirConsDona.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CkbOmitirConsDona.Name = "CkbOmitirConsDona"
        Me.CkbOmitirConsDona.Size = New System.Drawing.Size(180, 19)
        Me.CkbOmitirConsDona.TabIndex = 268
        Me.CkbOmitirConsDona.Text = "Omitir Consumo / Donación"
        Me.CkbOmitirConsDona.UseVisualStyleBackColor = True
        '
        'LblEdadPond
        '
        Me.LblEdadPond.AutoSize = True
        Me.LblEdadPond.BackColor = System.Drawing.Color.Transparent
        Me.LblEdadPond.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEdadPond.ForeColor = System.Drawing.Color.Black
        Me.LblEdadPond.Location = New System.Drawing.Point(1078, 110)
        Me.LblEdadPond.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEdadPond.Name = "LblEdadPond"
        Me.LblEdadPond.Size = New System.Drawing.Size(18, 18)
        Me.LblEdadPond.TabIndex = 182
        Me.LblEdadPond.Text = "0"
        '
        'LblEdadPonderada
        '
        Me.LblEdadPonderada.AutoSize = True
        Me.LblEdadPonderada.BackColor = System.Drawing.Color.Transparent
        Me.LblEdadPonderada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEdadPonderada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblEdadPonderada.Location = New System.Drawing.Point(999, 110)
        Me.LblEdadPonderada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEdadPonderada.Name = "LblEdadPonderada"
        Me.LblEdadPonderada.Size = New System.Drawing.Size(15, 18)
        Me.LblEdadPonderada.TabIndex = 178
        Me.LblEdadPonderada.Text = "-"
        '
        'LblPesoPromedio
        '
        Me.LblPesoPromedio.AutoSize = True
        Me.LblPesoPromedio.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoPromedio.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoPromedio.ForeColor = System.Drawing.Color.Black
        Me.LblPesoPromedio.Location = New System.Drawing.Point(913, 110)
        Me.LblPesoPromedio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPesoPromedio.Name = "LblPesoPromedio"
        Me.LblPesoPromedio.Size = New System.Drawing.Size(18, 18)
        Me.LblPesoPromedio.TabIndex = 184
        Me.LblPesoPromedio.Text = "0"
        '
        'CkbOmitirFecha
        '
        Me.CkbOmitirFecha.AutoSize = True
        Me.CkbOmitirFecha.Location = New System.Drawing.Point(340, 110)
        Me.CkbOmitirFecha.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CkbOmitirFecha.Name = "CkbOmitirFecha"
        Me.CkbOmitirFecha.Size = New System.Drawing.Size(62, 19)
        Me.CkbOmitirFecha.TabIndex = 267
        Me.CkbOmitirFecha.Text = "Omitir"
        Me.CkbOmitirFecha.UseVisualStyleBackColor = True
        '
        'LblPesoProm
        '
        Me.LblPesoProm.AutoSize = True
        Me.LblPesoProm.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoProm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoProm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblPesoProm.Location = New System.Drawing.Point(851, 110)
        Me.LblPesoProm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPesoProm.Name = "LblPesoProm"
        Me.LblPesoProm.Size = New System.Drawing.Size(15, 18)
        Me.LblPesoProm.TabIndex = 179
        Me.LblPesoProm.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(205, 86)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 18)
        Me.Label5.TabIndex = 265
        Me.Label5.Text = "F. Hasta :"
        '
        'DtpFecha
        '
        Me.DtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(85, 84)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(110, 24)
        Me.DtpFecha.TabIndex = 266
        '
        'BtnBusqueda
        '
        Me.BtnBusqueda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBusqueda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBusqueda.Image = CType(resources.GetObject("BtnBusqueda.Image"), System.Drawing.Image)
        Me.BtnBusqueda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBusqueda.Location = New System.Drawing.Point(638, 75)
        Me.BtnBusqueda.Name = "BtnBusqueda"
        Me.BtnBusqueda.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.BtnBusqueda.Size = New System.Drawing.Size(92, 41)
        Me.BtnBusqueda.TabIndex = 264
        Me.BtnBusqueda.Text = "Buscar"
        Me.BtnBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBusqueda.UseVisualStyleBackColor = True
        '
        'LblAnio
        '
        Me.LblAnio.AutoSize = True
        Me.LblAnio.BackColor = System.Drawing.Color.Transparent
        Me.LblAnio.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblAnio.Location = New System.Drawing.Point(38, 27)
        Me.LblAnio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAnio.Name = "LblAnio"
        Me.LblAnio.Size = New System.Drawing.Size(51, 18)
        Me.LblAnio.TabIndex = 248
        Me.LblAnio.Text = "Año :"
        '
        'CkbOmitirSemana
        '
        Me.CkbOmitirSemana.AutoSize = True
        Me.CkbOmitirSemana.Location = New System.Drawing.Point(541, 50)
        Me.CkbOmitirSemana.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CkbOmitirSemana.Name = "CkbOmitirSemana"
        Me.CkbOmitirSemana.Size = New System.Drawing.Size(62, 19)
        Me.CkbOmitirSemana.TabIndex = 263
        Me.CkbOmitirSemana.Text = "Omitir"
        Me.CkbOmitirSemana.UseVisualStyleBackColor = True
        '
        'CmbAnios
        '
        Me.CmbAnios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbAnios.FormattingEnabled = True
        Me.CmbAnios.Location = New System.Drawing.Point(85, 24)
        Me.CmbAnios.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbAnios.Name = "CmbAnios"
        Me.CmbAnios.Size = New System.Drawing.Size(103, 28)
        Me.CmbAnios.TabIndex = 249
        '
        'CkbOmitirMes
        '
        Me.CkbOmitirMes.AutoSize = True
        Me.CkbOmitirMes.Location = New System.Drawing.Point(325, 50)
        Me.CkbOmitirMes.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CkbOmitirMes.Name = "CkbOmitirMes"
        Me.CkbOmitirMes.Size = New System.Drawing.Size(62, 19)
        Me.CkbOmitirMes.TabIndex = 262
        Me.CkbOmitirMes.Text = "Omitir"
        Me.CkbOmitirMes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(222, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 18)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Mes :"
        '
        'CmbSemanas
        '
        Me.CmbSemanas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSemanas.FormattingEnabled = True
        Me.CmbSemanas.Location = New System.Drawing.Point(489, 24)
        Me.CmbSemanas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbSemanas.Name = "CmbSemanas"
        Me.CmbSemanas.Size = New System.Drawing.Size(103, 28)
        Me.CmbSemanas.TabIndex = 261
        '
        'CmbMeses
        '
        Me.CmbMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMeses.FormattingEnabled = True
        Me.CmbMeses.Location = New System.Drawing.Point(270, 24)
        Me.CmbMeses.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CmbMeses.Name = "CmbMeses"
        Me.CmbMeses.Size = New System.Drawing.Size(107, 28)
        Me.CmbMeses.TabIndex = 256
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(414, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 18)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Semana :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(969, 28)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 20)
        Me.Label12.TabIndex = 254
        Me.Label12.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(993, 29)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(219, 18)
        Me.Label7.TabIndex = 253
        Me.Label7.Text = "CONSUMOS Y DONACIONES"
        '
        'LblDiaPic
        '
        Me.LblDiaPic.AutoSize = True
        Me.LblDiaPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDiaPic.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiaPic.ForeColor = System.Drawing.Color.Green
        Me.LblDiaPic.Location = New System.Drawing.Point(27, 24)
        Me.LblDiaPic.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDiaPic.Name = "LblDiaPic"
        Me.LblDiaPic.Size = New System.Drawing.Size(185, 25)
        Me.LblDiaPic.TabIndex = 250
        Me.LblDiaPic.Text = "PESOS GRANJA"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExportarhistoricomortalidad, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 214)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1231, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "Monitoreo"
        '
        'BtnExportarhistoricomortalidad
        '
        Me.BtnExportarhistoricomortalidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarhistoricomortalidad.ForeColor = System.Drawing.Color.White
        Me.BtnExportarhistoricomortalidad.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarhistoricomortalidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarhistoricomortalidad.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarhistoricomortalidad.Name = "BtnExportarhistoricomortalidad"
        Me.BtnExportarhistoricomortalidad.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarhistoricomortalidad.Size = New System.Drawing.Size(107, 28)
        Me.BtnExportarhistoricomortalidad.Text = "Exportar"
        Me.BtnExportarhistoricomortalidad.ToolTipText = "Exportar"
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
        Me.BtnCerrar.Size = New System.Drawing.Size(72, 28)
        Me.BtnCerrar.Text = "Salir"
        '
        'dtgListado
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance1
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.AliceBlue
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance14
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 252)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1231, 451)
        Me.dtgListado.TabIndex = 32
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(601, 417)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 33
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'Clickomitiranio
        '
        Me.Clickomitiranio.AutoSize = True
        Me.Clickomitiranio.Location = New System.Drawing.Point(133, 50)
        Me.Clickomitiranio.Margin = New System.Windows.Forms.Padding(2)
        Me.Clickomitiranio.Name = "Clickomitiranio"
        Me.Clickomitiranio.Size = New System.Drawing.Size(62, 19)
        Me.Clickomitiranio.TabIndex = 271
        Me.Clickomitiranio.Text = "Omitir"
        Me.Clickomitiranio.UseVisualStyleBackColor = True
        '
        'FrmReportePesosGranja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 703)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportePesosGranja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PESOS GRANJA"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnExportarhistoricomortalidad As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents CmbAnios As ComboBox
    Friend WithEvents LblAnio As Label
    Friend WithEvents LblDiaPic As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbMeses As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblPesoPromedio As Label
    Friend WithEvents LblEdadPond As Label
    Friend WithEvents LblPesoProm As Label
    Friend WithEvents LblEdadPonderada As Label
    Friend WithEvents CmbSemanas As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CkbOmitirSemana As CheckBox
    Friend WithEvents CkbOmitirMes As CheckBox
    Friend WithEvents BtnBusqueda As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DtpFecha As DateTimePicker
    Friend WithEvents CkbOmitirFecha As CheckBox
    Friend WithEvents CkbOmitirConsDona As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpfhasta As DateTimePicker
    Friend WithEvents Clickomitiranio As CheckBox
End Class
