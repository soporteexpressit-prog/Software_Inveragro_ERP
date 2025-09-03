<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMant_Trabajador
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GrupoMasOpcionesBusqueda = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevoRrhhtra = New System.Windows.Forms.ToolStripButton()
        Me.btn_editarRrhhtra = New System.Windows.Forms.ToolStripButton()
        Me.btnexportar_excelRrhhtra = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1Rrhhtra = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnImprimirListaInventarioRrhhtra = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDatosTrabajadorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarFotocheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AFPNETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarAfpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarAfpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExprotarAFPPorEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteGeneralSunatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteSunatPorEmpleadoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeSueldoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.convertirtraclieproverrhh = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConvertirAConductorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_cerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.dtg_Listado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtg_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'GrupoMasOpcionesBusqueda
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance2.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.ContentAreaAppearance = Appearance2
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label1)
        Me.GrupoMasOpcionesBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrupoMasOpcionesBusqueda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.BorderColor2 = System.Drawing.Color.White
        Appearance3.BorderColor3DBase = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.Name = "Segoe UI"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Me.GrupoMasOpcionesBusqueda.HeaderAppearance = Appearance3
        Me.GrupoMasOpcionesBusqueda.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.GrupoMasOpcionesBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.GrupoMasOpcionesBusqueda.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(1283, 39)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 178
        Me.GrupoMasOpcionesBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 18)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "MODULO DE TRABAJADORES"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevoRrhhtra, Me.btn_editarRrhhtra, Me.btnexportar_excelRrhhtra, Me.ToolStripButton1Rrhhtra, Me.convertirtraclieproverrhh, Me.btn_cerrar, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 39)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1283, 38)
        Me.ToolStrip1.TabIndex = 180
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_nuevoRrhhtra
        '
        Me.btn_nuevoRrhhtra.BackColor = System.Drawing.Color.Transparent
        Me.btn_nuevoRrhhtra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevoRrhhtra.ForeColor = System.Drawing.Color.White
        Me.btn_nuevoRrhhtra.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btn_nuevoRrhhtra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevoRrhhtra.Name = "btn_nuevoRrhhtra"
        Me.btn_nuevoRrhhtra.Size = New System.Drawing.Size(89, 35)
        Me.btn_nuevoRrhhtra.Text = " Nuevo   "
        Me.btn_nuevoRrhhtra.ToolTipText = "Nuevo "
        '
        'btn_editarRrhhtra
        '
        Me.btn_editarRrhhtra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editarRrhhtra.ForeColor = System.Drawing.Color.White
        Me.btn_editarRrhhtra.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btn_editarRrhhtra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_editarRrhhtra.Name = "btn_editarRrhhtra"
        Me.btn_editarRrhhtra.Size = New System.Drawing.Size(74, 35)
        Me.btn_editarRrhhtra.Text = " Editar"
        Me.btn_editarRrhhtra.ToolTipText = "Editar"
        '
        'btnexportar_excelRrhhtra
        '
        Me.btnexportar_excelRrhhtra.AutoToolTip = False
        Me.btnexportar_excelRrhhtra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar_excelRrhhtra.ForeColor = System.Drawing.Color.White
        Me.btnexportar_excelRrhhtra.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportar_excelRrhhtra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportar_excelRrhhtra.Name = "btnexportar_excelRrhhtra"
        Me.btnexportar_excelRrhhtra.Size = New System.Drawing.Size(96, 35)
        Me.btnexportar_excelRrhhtra.Text = " Exportar "
        '
        'ToolStripButton1Rrhhtra
        '
        Me.ToolStripButton1Rrhhtra.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1Rrhhtra.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimirListaInventarioRrhhtra, Me.ReporteDatosTrabajadorToolStripMenuItem1, Me.GenerarFotocheckToolStripMenuItem, Me.AFPNETToolStripMenuItem, Me.ReporteDeSueldoToolStripMenuItem})
        Me.ToolStripButton1Rrhhtra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1Rrhhtra.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1Rrhhtra.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.ToolStripButton1Rrhhtra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1Rrhhtra.Name = "ToolStripButton1Rrhhtra"
        Me.ToolStripButton1Rrhhtra.Size = New System.Drawing.Size(103, 35)
        Me.ToolStripButton1Rrhhtra.Text = " Reportes"
        Me.ToolStripButton1Rrhhtra.ToolTipText = "Reportes"
        '
        'btnImprimirListaInventarioRrhhtra
        '
        Me.btnImprimirListaInventarioRrhhtra.Name = "btnImprimirListaInventarioRrhhtra"
        Me.btnImprimirListaInventarioRrhhtra.Size = New System.Drawing.Size(245, 22)
        Me.btnImprimirListaInventarioRrhhtra.Text = "Imprimir Lista"
        Me.btnImprimirListaInventarioRrhhtra.ToolTipText = "Imprimir Lista"
        '
        'ReporteDatosTrabajadorToolStripMenuItem1
        '
        Me.ReporteDatosTrabajadorToolStripMenuItem1.Name = "ReporteDatosTrabajadorToolStripMenuItem1"
        Me.ReporteDatosTrabajadorToolStripMenuItem1.Size = New System.Drawing.Size(245, 22)
        Me.ReporteDatosTrabajadorToolStripMenuItem1.Text = "Reporte Datos Trabajador"
        '
        'GenerarFotocheckToolStripMenuItem
        '
        Me.GenerarFotocheckToolStripMenuItem.Name = "GenerarFotocheckToolStripMenuItem"
        Me.GenerarFotocheckToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.GenerarFotocheckToolStripMenuItem.Text = "Generar Fotocheck"
        '
        'AFPNETToolStripMenuItem
        '
        Me.AFPNETToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAfpToolStripMenuItem, Me.ImportarAfpToolStripMenuItem, Me.ExprotarAFPPorEmpleadoToolStripMenuItem, Me.ReporteGeneralSunatToolStripMenuItem, Me.ReporteSunatPorEmpleadoToolStripMenuItem1})
        Me.AFPNETToolStripMenuItem.Name = "AFPNETToolStripMenuItem"
        Me.AFPNETToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AFPNETToolStripMenuItem.Text = "AFP NET"
        Me.AFPNETToolStripMenuItem.Visible = False
        '
        'ExportarAfpToolStripMenuItem
        '
        Me.ExportarAfpToolStripMenuItem.Name = "ExportarAfpToolStripMenuItem"
        Me.ExportarAfpToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ExportarAfpToolStripMenuItem.Text = "Exportar AFP"
        '
        'ImportarAfpToolStripMenuItem
        '
        Me.ImportarAfpToolStripMenuItem.Name = "ImportarAfpToolStripMenuItem"
        Me.ImportarAfpToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ImportarAfpToolStripMenuItem.Text = "Importar AFP"
        '
        'ExprotarAFPPorEmpleadoToolStripMenuItem
        '
        Me.ExprotarAFPPorEmpleadoToolStripMenuItem.Name = "ExprotarAFPPorEmpleadoToolStripMenuItem"
        Me.ExprotarAFPPorEmpleadoToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ExprotarAFPPorEmpleadoToolStripMenuItem.Text = "Exprotar AFP por empleado"
        '
        'ReporteGeneralSunatToolStripMenuItem
        '
        Me.ReporteGeneralSunatToolStripMenuItem.Name = "ReporteGeneralSunatToolStripMenuItem"
        Me.ReporteGeneralSunatToolStripMenuItem.Size = New System.Drawing.Size(262, 22)
        Me.ReporteGeneralSunatToolStripMenuItem.Text = "Reporte General Sunat"
        Me.ReporteGeneralSunatToolStripMenuItem.Visible = False
        '
        'ReporteSunatPorEmpleadoToolStripMenuItem1
        '
        Me.ReporteSunatPorEmpleadoToolStripMenuItem1.Name = "ReporteSunatPorEmpleadoToolStripMenuItem1"
        Me.ReporteSunatPorEmpleadoToolStripMenuItem1.Size = New System.Drawing.Size(262, 22)
        Me.ReporteSunatPorEmpleadoToolStripMenuItem1.Text = "Reporte Sunat por empleado"
        Me.ReporteSunatPorEmpleadoToolStripMenuItem1.Visible = False
        '
        'ReporteDeSueldoToolStripMenuItem
        '
        Me.ReporteDeSueldoToolStripMenuItem.Name = "ReporteDeSueldoToolStripMenuItem"
        Me.ReporteDeSueldoToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ReporteDeSueldoToolStripMenuItem.Text = "Reporte de Sueldo"
        '
        'convertirtraclieproverrhh
        '
        Me.convertirtraclieproverrhh.BackColor = System.Drawing.Color.Transparent
        Me.convertirtraclieproverrhh.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ConvertirAConductorToolStripMenuItem})
        Me.convertirtraclieproverrhh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.convertirtraclieproverrhh.ForeColor = System.Drawing.Color.White
        Me.convertirtraclieproverrhh.Image = Global.Formularios.My.Resources.Resources.circle_of_two_clockwise_arrows_rotation1
        Me.convertirtraclieproverrhh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.convertirtraclieproverrhh.Name = "convertirtraclieproverrhh"
        Me.convertirtraclieproverrhh.Size = New System.Drawing.Size(179, 35)
        Me.convertirtraclieproverrhh.Text = "Convertir Trabajador"
        Me.convertirtraclieproverrhh.ToolTipText = "Convertir Trabajador"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItem1.Text = "Convertir a cliente"
        Me.ToolStripMenuItem1.ToolTipText = "Convertir a cliente"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItem2.Text = "Convertir a proveedor"
        '
        'ConvertirAConductorToolStripMenuItem
        '
        Me.ConvertirAConductorToolStripMenuItem.Name = "ConvertirAConductorToolStripMenuItem"
        Me.ConvertirAConductorToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.ConvertirAConductorToolStripMenuItem.Text = "Convertir a Conductor"
        Me.ConvertirAConductorToolStripMenuItem.Visible = False
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btn_cerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btn_cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(62, 35)
        Me.btn_cerrar.Text = "Salir"
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
        Me.ToolStripButton2.Size = New System.Drawing.Size(88, 28)
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
        Me.ToolStripButton1.Size = New System.Drawing.Size(77, 28)
        Me.ToolStripButton1.Text = "Filtros"
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(658, 310)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 38)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 188
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'dtg_Listado
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance4.FontData.Name = "Verdana"
        Me.dtg_Listado.DisplayLayout.Appearance = Appearance4
        Me.dtg_Listado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtg_Listado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
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
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
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
        Me.dtg_Listado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtg_Listado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
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
        Me.dtg_Listado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtg_Listado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.dtg_Listado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtg_Listado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtg_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_Listado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_Listado.Location = New System.Drawing.Point(0, 77)
        Me.dtg_Listado.Name = "dtg_Listado"
        Me.dtg_Listado.Size = New System.Drawing.Size(1283, 475)
        Me.dtg_Listado.TabIndex = 187
        Me.dtg_Listado.Text = "UltraGrid1"
        '
        'FrmMant_Trabajador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1283, 552)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtg_Listado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Name = "FrmMant_Trabajador"
        Me.Text = "TRABAJADORES"
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoMasOpcionesBusqueda.ResumeLayout(False)
        Me.GrupoMasOpcionesBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtg_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents GrupoMasOpcionesBusqueda As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btn_nuevoRrhhtra As ToolStripButton
    Friend WithEvents btn_editarRrhhtra As ToolStripButton
    Friend WithEvents ToolStripButton1Rrhhtra As ToolStripDropDownButton
    Friend WithEvents btnImprimirListaInventarioRrhhtra As ToolStripMenuItem
    Friend WithEvents btn_cerrar As ToolStripButton
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents btnexportar_excelRrhhtra As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ReporteDatosTrabajadorToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents convertirtraclieproverrhh As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents GenerarFotocheckToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AFPNETToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportarAfpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarAfpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExprotarAFPPorEmpleadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteGeneralSunatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteSunatPorEmpleadoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents dtg_Listado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ConvertirAConductorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeSueldoToolStripMenuItem As ToolStripMenuItem
End Class
