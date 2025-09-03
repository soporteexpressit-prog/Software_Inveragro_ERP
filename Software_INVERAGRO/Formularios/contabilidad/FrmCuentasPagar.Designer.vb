<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCuentasPagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentasPagar))
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
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.txtproveedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcodproveedor = New System.Windows.Forms.TextBox()
        Me.cbxestado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2ctcp = New System.Windows.Forms.ToolStripButton()
        Me.btneditarcuentapagar = New System.Windows.Forms.ToolStripButton()
        Me.btnpagomultiplecontabilidad = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.btnPagarctcp = New System.Windows.Forms.ToolStripButton()
        Me.btnAnularctcp = New System.Windows.Forms.ToolStripButton()
        Me.btnnuevoprestamoctcp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1ctcp = New System.Windows.Forms.ToolStripButton()
        Me.btnexportarctcp = New System.Windows.Forms.ToolStripButton()
        Me.btnPagoDebitadoctcp = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cktodods = New System.Windows.Forms.CheckBox()
        Me.cktodosfechas = New System.Windows.Forms.CheckBox()
        Me.cbxbancodestino = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxliquidado = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(740, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(84, 29)
        Me.btnBuscar.TabIndex = 173
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(741, 52)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(82, 29)
        Me.btnConsultar.TabIndex = 169
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtproveedor
        '
        Me.txtproveedor.BackColor = System.Drawing.Color.White
        Me.txtproveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproveedor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtproveedor.Location = New System.Drawing.Point(244, 19)
        Me.txtproveedor.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtproveedor.MaxLength = 150
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(406, 21)
        Me.txtproveedor.TabIndex = 167
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(66, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "Titular :"
        '
        'txtcodproveedor
        '
        Me.txtcodproveedor.BackColor = System.Drawing.Color.White
        Me.txtcodproveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodproveedor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodproveedor.Location = New System.Drawing.Point(136, 19)
        Me.txtcodproveedor.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtcodproveedor.MaxLength = 150
        Me.txtcodproveedor.Name = "txtcodproveedor"
        Me.txtcodproveedor.ReadOnly = True
        Me.txtcodproveedor.Size = New System.Drawing.Size(82, 21)
        Me.txtcodproveedor.TabIndex = 165
        '
        'cbxestado
        '
        Me.cbxestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxestado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxestado.FormattingEnabled = True
        Me.cbxestado.Items.AddRange(New Object() {"TODOS", "ACTIVO", "ANULADO"})
        Me.cbxestado.Location = New System.Drawing.Point(997, 19)
        Me.cbxestado.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbxestado.Name = "cbxestado"
        Me.cbxestado.Size = New System.Drawing.Size(130, 21)
        Me.cbxestado.TabIndex = 161
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(856, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 14)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Estado de Cuenta:"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(517, 56)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(133, 21)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(136, 56)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(133, 21)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 59)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 14)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Fecha Desde :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(407, 59)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fecha Hasta :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2ctcp, Me.btneditarcuentapagar, Me.btnpagomultiplecontabilidad, Me.ToolStripButton2, Me.btnPagarctcp, Me.btnAnularctcp, Me.btnnuevoprestamoctcp, Me.ToolStripButton1ctcp, Me.btnexportarctcp, Me.btnPagoDebitadoctcp, Me.btncerrar, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 170)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1432, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2ctcp
        '
        Me.ToolStripButton2ctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2ctcp.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2ctcp.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.ToolStripButton2ctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2ctcp.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton2ctcp.Name = "ToolStripButton2ctcp"
        Me.ToolStripButton2ctcp.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton2ctcp.Size = New System.Drawing.Size(119, 28)
        Me.ToolStripButton2ctcp.Text = "Nuevo Gasto"
        '
        'btneditarcuentapagar
        '
        Me.btneditarcuentapagar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditarcuentapagar.ForeColor = System.Drawing.Color.White
        Me.btneditarcuentapagar.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btneditarcuentapagar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btneditarcuentapagar.Margin = New System.Windows.Forms.Padding(5)
        Me.btneditarcuentapagar.Name = "btneditarcuentapagar"
        Me.btneditarcuentapagar.Padding = New System.Windows.Forms.Padding(2)
        Me.btneditarcuentapagar.Size = New System.Drawing.Size(74, 28)
        Me.btneditarcuentapagar.Text = "Editar"
        '
        'btnpagomultiplecontabilidad
        '
        Me.btnpagomultiplecontabilidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpagomultiplecontabilidad.ForeColor = System.Drawing.Color.White
        Me.btnpagomultiplecontabilidad.Image = Global.Formularios.My.Resources.Resources.Pagar_24_px
        Me.btnpagomultiplecontabilidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnpagomultiplecontabilidad.Margin = New System.Windows.Forms.Padding(5)
        Me.btnpagomultiplecontabilidad.Name = "btnpagomultiplecontabilidad"
        Me.btnpagomultiplecontabilidad.Padding = New System.Windows.Forms.Padding(2)
        Me.btnpagomultiplecontabilidad.Size = New System.Drawing.Size(124, 28)
        Me.btnpagomultiplecontabilidad.Text = "Pago Multiple"
        Me.btnpagomultiplecontabilidad.ToolTipText = "Pagar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2.Image = Global.Formularios.My.Resources.Resources.Pagar_24_px
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton2.Size = New System.Drawing.Size(74, 28)
        Me.ToolStripButton2.Text = "Pagar"
        Me.ToolStripButton2.ToolTipText = "Pagar"
        '
        'btnPagarctcp
        '
        Me.btnPagarctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagarctcp.ForeColor = System.Drawing.Color.White
        Me.btnPagarctcp.Image = Global.Formularios.My.Resources.Resources.Pagar_24_px
        Me.btnPagarctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPagarctcp.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPagarctcp.Name = "btnPagarctcp"
        Me.btnPagarctcp.Padding = New System.Windows.Forms.Padding(2)
        Me.btnPagarctcp.Size = New System.Drawing.Size(116, 28)
        Me.btnPagarctcp.Text = "Aplicar Nota"
        Me.btnPagarctcp.ToolTipText = "Pagar"
        '
        'btnAnularctcp
        '
        Me.btnAnularctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnularctcp.ForeColor = System.Drawing.Color.White
        Me.btnAnularctcp.Image = Global.Formularios.My.Resources.Resources.Cancelar24px
        Me.btnAnularctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularctcp.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAnularctcp.Name = "btnAnularctcp"
        Me.btnAnularctcp.Padding = New System.Windows.Forms.Padding(2)
        Me.btnAnularctcp.Size = New System.Drawing.Size(78, 28)
        Me.btnAnularctcp.Text = "Anular"
        Me.btnAnularctcp.ToolTipText = "Anular"
        '
        'btnnuevoprestamoctcp
        '
        Me.btnnuevoprestamoctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevoprestamoctcp.ForeColor = System.Drawing.Color.White
        Me.btnnuevoprestamoctcp.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnnuevoprestamoctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnuevoprestamoctcp.Margin = New System.Windows.Forms.Padding(5)
        Me.btnnuevoprestamoctcp.Name = "btnnuevoprestamoctcp"
        Me.btnnuevoprestamoctcp.Padding = New System.Windows.Forms.Padding(2)
        Me.btnnuevoprestamoctcp.Size = New System.Drawing.Size(144, 28)
        Me.btnnuevoprestamoctcp.Text = "Nuevo Prestamo"
        '
        'ToolStripButton1ctcp
        '
        Me.ToolStripButton1ctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1ctcp.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1ctcp.Image = Global.Formularios.My.Resources.Resources.prestamo
        Me.ToolStripButton1ctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1ctcp.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1ctcp.Name = "ToolStripButton1ctcp"
        Me.ToolStripButton1ctcp.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1ctcp.Size = New System.Drawing.Size(125, 28)
        Me.ToolStripButton1ctcp.Text = "Ver Prestamo"
        '
        'btnexportarctcp
        '
        Me.btnexportarctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportarctcp.ForeColor = System.Drawing.Color.White
        Me.btnexportarctcp.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportarctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportarctcp.Margin = New System.Windows.Forms.Padding(5)
        Me.btnexportarctcp.Name = "btnexportarctcp"
        Me.btnexportarctcp.Padding = New System.Windows.Forms.Padding(2)
        Me.btnexportarctcp.Size = New System.Drawing.Size(92, 28)
        Me.btnexportarctcp.Text = "Exportar"
        Me.btnexportarctcp.ToolTipText = "Exportar"
        '
        'btnPagoDebitadoctcp
        '
        Me.btnPagoDebitadoctcp.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagoDebitadoctcp.ForeColor = System.Drawing.Color.White
        Me.btnPagoDebitadoctcp.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnPagoDebitadoctcp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPagoDebitadoctcp.Name = "btnPagoDebitadoctcp"
        Me.btnPagoDebitadoctcp.Size = New System.Drawing.Size(141, 35)
        Me.btnPagoDebitadoctcp.Text = "Pagos Debitados"
        '
        'btncerrar
        '
        Me.btncerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncerrar.ForeColor = System.Drawing.Color.White
        Me.btncerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btncerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btncerrar.Size = New System.Drawing.Size(66, 28)
        Me.btncerrar.Text = "Salir"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripButton1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.Formularios.My.Resources.Resources.filter__2_1
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1.Size = New System.Drawing.Size(77, 28)
        Me.ToolStripButton1.Text = "Filtros"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1432, 208)
        Me.Panel2.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(11, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 18)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "CUENTAS POR PAGAR"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cktodods)
        Me.GroupBox1.Controls.Add(Me.cktodosfechas)
        Me.GroupBox1.Controls.Add(Me.cbxbancodestino)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbxliquidado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.cbxestado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox1.Controls.Add(Me.txtproveedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtcodproveedor)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1152, 120)
        Me.GroupBox1.TabIndex = 161
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de Búsqueda"
        '
        'cktodods
        '
        Me.cktodods.AutoSize = True
        Me.cktodods.BackColor = System.Drawing.Color.White
        Me.cktodods.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cktodods.Checked = True
        Me.cktodods.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cktodods.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cktodods.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cktodods.Location = New System.Drawing.Point(662, 21)
        Me.cktodods.Margin = New System.Windows.Forms.Padding(2)
        Me.cktodods.Name = "cktodods"
        Me.cktodods.Size = New System.Drawing.Size(71, 17)
        Me.cktodods.TabIndex = 180
        Me.cktodods.Text = "Todos :   "
        Me.cktodods.UseVisualStyleBackColor = False
        '
        'cktodosfechas
        '
        Me.cktodosfechas.AutoSize = True
        Me.cktodosfechas.BackColor = System.Drawing.Color.White
        Me.cktodosfechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cktodosfechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cktodosfechas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cktodosfechas.Location = New System.Drawing.Point(662, 56)
        Me.cktodosfechas.Margin = New System.Windows.Forms.Padding(2)
        Me.cktodosfechas.Name = "cktodosfechas"
        Me.cktodosfechas.Size = New System.Drawing.Size(71, 17)
        Me.cktodosfechas.TabIndex = 179
        Me.cktodosfechas.Text = "Todos :   "
        Me.cktodosfechas.UseVisualStyleBackColor = False
        '
        'cbxbancodestino
        '
        Me.cbxbancodestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxbancodestino.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxbancodestino.FormattingEnabled = True
        Me.cbxbancodestino.Items.AddRange(New Object() {"TODOS", "ACTIVO", "ANULADO"})
        Me.cbxbancodestino.Location = New System.Drawing.Point(136, 93)
        Me.cbxbancodestino.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbxbancodestino.Name = "cbxbancodestino"
        Me.cbxbancodestino.Size = New System.Drawing.Size(514, 21)
        Me.cbxbancodestino.TabIndex = 178
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(65, 96)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 14)
        Me.Label7.TabIndex = 177
        Me.Label7.Text = "Banco : "
        '
        'cbxliquidado
        '
        Me.cbxliquidado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxliquidado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxliquidado.FormattingEnabled = True
        Me.cbxliquidado.Items.AddRange(New Object() {"TODOS", "SI", "NO"})
        Me.cbxliquidado.Location = New System.Drawing.Point(997, 56)
        Me.cbxliquidado.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbxliquidado.Name = "cbxliquidado"
        Me.cbxliquidado.Size = New System.Drawing.Size(130, 21)
        Me.cbxliquidado.TabIndex = 176
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(905, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "Liquidado :"
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 208)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1432, 344)
        Me.dtgListado.TabIndex = 9
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(549, 408)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 10
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmCuentasPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1432, 552)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmCuentasPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmCuentasPagar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbxestado As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnPagarctcp As ToolStripButton
    Friend WithEvents btnexportarctcp As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents btnAnularctcp As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcodproveedor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtproveedor As TextBox
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents btnConsultar As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnnuevoprestamoctcp As ToolStripButton
    Friend WithEvents ToolStripButton1ctcp As ToolStripButton
    Friend WithEvents btnBuscar As Button
    Friend WithEvents ToolStripButton2ctcp As ToolStripButton
    Friend WithEvents btnPagoDebitadoctcp As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btneditarcuentapagar As ToolStripButton
    Friend WithEvents btnpagomultiplecontabilidad As ToolStripButton
    Friend WithEvents cbxliquidado As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxbancodestino As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cktodosfechas As CheckBox
    Friend WithEvents cktodods As CheckBox
    Friend WithEvents ToolStripButton2 As ToolStripButton
End Class

