<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlClientes
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlClientes))
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.GrupoMasOpcionesBusqueda = New System.Windows.Forms.GroupBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.txtbusqueda = New System.Windows.Forms.TextBox()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevoVctrlcli = New System.Windows.Forms.ToolStripButton()
        Me.btn_editarVctrlcli = New System.Windows.Forms.ToolStripButton()
        Me.btnexportar_excelVctrlcli = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1Vctrlcli = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnImprimirListaClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnconvertirclientesVentas = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConvertirAProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_cerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dtg_Listado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.ConvertirAConductorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtg_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1982, 198)
        Me.Panel1.TabIndex = 21
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.HeaderAppearance = Appearance3
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1982, 198)
        Me.UltraGroupBox1.TabIndex = 160
        '
        'GrupoMasOpcionesBusqueda
        '
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.btnConsultar)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.txtbusqueda)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.UltraLabel3)
        Me.GrupoMasOpcionesBusqueda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GrupoMasOpcionesBusqueda.Location = New System.Drawing.Point(9, 71)
        Me.GrupoMasOpcionesBusqueda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(1125, 108)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 163
        Me.GrupoMasOpcionesBusqueda.TabStop = False
        Me.GrupoMasOpcionesBusqueda.Text = "Filtro de Búsqueda"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(978, 31)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.btnConsultar.Size = New System.Drawing.Size(138, 62)
        Me.btnConsultar.TabIndex = 162
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtbusqueda
        '
        Me.txtbusqueda.Location = New System.Drawing.Point(262, 48)
        Me.txtbusqueda.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtbusqueda.Name = "txtbusqueda"
        Me.txtbusqueda.Size = New System.Drawing.Size(672, 28)
        Me.txtbusqueda.TabIndex = 159
        '
        'UltraLabel3
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.FontData.SizeInPoints = 9.0!
        Appearance2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance2
        Me.UltraLabel3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(102, 49)
        Me.UltraLabel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(98, 31)
        Me.UltraLabel3.TabIndex = 158
        Me.UltraLabel3.Text = "Cliente :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(20, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(322, 29)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "CONTROL DE CLIENTES"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevoVctrlcli, Me.btn_editarVctrlcli, Me.btnexportar_excelVctrlcli, Me.ToolStripButton1Vctrlcli, Me.btnconvertirclientesVentas, Me.btn_cerrar, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 198)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1982, 40)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_nuevoVctrlcli
        '
        Me.btn_nuevoVctrlcli.BackColor = System.Drawing.Color.Transparent
        Me.btn_nuevoVctrlcli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevoVctrlcli.ForeColor = System.Drawing.Color.White
        Me.btn_nuevoVctrlcli.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btn_nuevoVctrlcli.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevoVctrlcli.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_nuevoVctrlcli.Name = "btn_nuevoVctrlcli"
        Me.btn_nuevoVctrlcli.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_nuevoVctrlcli.Size = New System.Drawing.Size(108, 30)
        Me.btn_nuevoVctrlcli.Text = " Nuevo"
        Me.btn_nuevoVctrlcli.ToolTipText = "Nuevo "
        '
        'btn_editarVctrlcli
        '
        Me.btn_editarVctrlcli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editarVctrlcli.ForeColor = System.Drawing.Color.White
        Me.btn_editarVctrlcli.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btn_editarVctrlcli.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_editarVctrlcli.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_editarVctrlcli.Name = "btn_editarVctrlcli"
        Me.btn_editarVctrlcli.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_editarVctrlcli.Size = New System.Drawing.Size(128, 30)
        Me.btn_editarVctrlcli.Text = " Editar    "
        Me.btn_editarVctrlcli.ToolTipText = "Editar"
        '
        'btnexportar_excelVctrlcli
        '
        Me.btnexportar_excelVctrlcli.AutoToolTip = False
        Me.btnexportar_excelVctrlcli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar_excelVctrlcli.ForeColor = System.Drawing.Color.White
        Me.btnexportar_excelVctrlcli.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportar_excelVctrlcli.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportar_excelVctrlcli.Margin = New System.Windows.Forms.Padding(5)
        Me.btnexportar_excelVctrlcli.Name = "btnexportar_excelVctrlcli"
        Me.btnexportar_excelVctrlcli.Padding = New System.Windows.Forms.Padding(2)
        Me.btnexportar_excelVctrlcli.Size = New System.Drawing.Size(125, 30)
        Me.btnexportar_excelVctrlcli.Text = "Exportar"
        Me.btnexportar_excelVctrlcli.ToolTipText = "Exportar"
        '
        'ToolStripButton1Vctrlcli
        '
        Me.ToolStripButton1Vctrlcli.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1Vctrlcli.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimirListaClientes})
        Me.ToolStripButton1Vctrlcli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1Vctrlcli.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1Vctrlcli.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.ToolStripButton1Vctrlcli.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1Vctrlcli.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1Vctrlcli.Name = "ToolStripButton1Vctrlcli"
        Me.ToolStripButton1Vctrlcli.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1Vctrlcli.Size = New System.Drawing.Size(149, 30)
        Me.ToolStripButton1Vctrlcli.Text = " Reportes"
        Me.ToolStripButton1Vctrlcli.ToolTipText = "Reportes"
        '
        'btnImprimirListaClientes
        '
        Me.btnImprimirListaClientes.Name = "btnImprimirListaClientes"
        Me.btnImprimirListaClientes.Size = New System.Drawing.Size(255, 34)
        Me.btnImprimirListaClientes.Text = "Imprimir Lista"
        Me.btnImprimirListaClientes.ToolTipText = "Imprimir Lista de Inventario"
        '
        'btnconvertirclientesVentas
        '
        Me.btnconvertirclientesVentas.BackColor = System.Drawing.Color.Transparent
        Me.btnconvertirclientesVentas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ConvertirAProveedorToolStripMenuItem, Me.ConvertirAConductorToolStripMenuItem})
        Me.btnconvertirclientesVentas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconvertirclientesVentas.ForeColor = System.Drawing.Color.White
        Me.btnconvertirclientesVentas.Image = Global.Formularios.My.Resources.Resources.circle_of_two_clockwise_arrows_rotation
        Me.btnconvertirclientesVentas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnconvertirclientesVentas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnconvertirclientesVentas.Name = "btnconvertirclientesVentas"
        Me.btnconvertirclientesVentas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnconvertirclientesVentas.Size = New System.Drawing.Size(222, 30)
        Me.btnconvertirclientesVentas.Text = "Convertir Cliente"
        Me.btnconvertirclientesVentas.ToolTipText = "Reportes"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(339, 34)
        Me.ToolStripMenuItem1.Text = "Convertir a Trabajador"
        Me.ToolStripMenuItem1.ToolTipText = "Imprimir Lista de Inventario"
        '
        'ConvertirAProveedorToolStripMenuItem
        '
        Me.ConvertirAProveedorToolStripMenuItem.Name = "ConvertirAProveedorToolStripMenuItem"
        Me.ConvertirAProveedorToolStripMenuItem.Size = New System.Drawing.Size(339, 34)
        Me.ConvertirAProveedorToolStripMenuItem.Text = "Convertir a Proveedor"
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btn_cerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btn_cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_cerrar.Size = New System.Drawing.Size(90, 30)
        Me.btn_cerrar.Text = " Salir"
        Me.btn_cerrar.ToolTipText = "Cerrar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripButton2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2.Image = Global.Formularios.My.Resources.Resources.enlace
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton2.Size = New System.Drawing.Size(121, 30)
        Me.ToolStripButton2.Text = "Agrupar"
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
        Me.ToolStripButton1.Size = New System.Drawing.Size(102, 30)
        Me.ToolStripButton1.Text = "Filtros"
        '
        'dtg_Listado
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance4.FontData.Name = "Verdana"
        Me.dtg_Listado.DisplayLayout.Appearance = Appearance4
        Me.dtg_Listado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtg_Listado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.dtg_Listado.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.PrefixWithEmptyCell
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.dtg_Listado.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtg_Listado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.dtg_Listado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtg_Listado.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.dtg_Listado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtg_Listado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.Color.Navy
        Appearance8.ForeColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.Navy
        Appearance9.ForeColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.dtg_Listado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtg_Listado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.dtg_Listado.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtg_Listado.DisplayLayout.Override.CellAppearance = Appearance11
        Me.dtg_Listado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtg_Listado.DisplayLayout.Override.CellPadding = 0
        Me.dtg_Listado.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.EntireColumn
        Me.dtg_Listado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtg_Listado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.dtg_Listado.DisplayLayout.Override.FixedRowIndicator = Infragistics.Win.UltraWinGrid.FixedRowIndicator.None
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.dtg_Listado.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.AliceBlue
        Appearance13.BackColor2 = System.Drawing.Color.Silver
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.TextHAlignAsString = "Left"
        Me.dtg_Listado.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.dtg_Listado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtg_Listado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.dtg_Listado.DisplayLayout.Override.RowAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.RowPreviewAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.RowSelectorAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.Navy
        Me.dtg_Listado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance17
        Me.dtg_Listado.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.dtg_Listado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtg_Listado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.dtg_Listado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtg_Listado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtg_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_Listado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_Listado.Location = New System.Drawing.Point(0, 238)
        Me.dtg_Listado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtg_Listado.Name = "dtg_Listado"
        Me.dtg_Listado.Size = New System.Drawing.Size(1982, 650)
        Me.dtg_Listado.TabIndex = 23
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(1017, 525)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 58)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 24
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'ConvertirAConductorToolStripMenuItem
        '
        Me.ConvertirAConductorToolStripMenuItem.Name = "ConvertirAConductorToolStripMenuItem"
        Me.ConvertirAConductorToolStripMenuItem.Size = New System.Drawing.Size(339, 34)
        Me.ConvertirAConductorToolStripMenuItem.Text = "Convertir a Conductor"
        '
        'FrmControlClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1982, 888)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtg_Listado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FrmControlClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE CLIENTES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.GrupoMasOpcionesBusqueda.ResumeLayout(False)
        Me.GrupoMasOpcionesBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtg_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnConsultar As Button
    Friend WithEvents txtbusqueda As TextBox
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btn_nuevoVctrlcli As ToolStripButton
    Friend WithEvents btn_editarVctrlcli As ToolStripButton
    Friend WithEvents btnexportar_excelVctrlcli As ToolStripButton
    Friend WithEvents ToolStripButton1Vctrlcli As ToolStripDropDownButton
    Friend WithEvents btnImprimirListaClientes As ToolStripMenuItem
    Friend WithEvents btn_cerrar As ToolStripButton
    Friend WithEvents dtg_Listado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents GrupoMasOpcionesBusqueda As GroupBox
    Friend WithEvents btnconvertirclientesVentas As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConvertirAProveedorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConvertirAConductorToolStripMenuItem As ToolStripMenuItem
End Class
