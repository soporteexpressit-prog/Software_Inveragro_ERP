<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmControlPedidoAlimento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlPedidoAlimento))
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
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnNuevoNpea = New System.Windows.Forms.ToolStripButton()
        Me.btnAprobarNpea = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelarNpea = New System.Windows.Forms.ToolStripButton()
        Me.BtnConsolidadoRacionmodulonutricion = New System.Windows.Forms.ToolStripButton()
        Me.btnExportarNpea = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.BtnReporteSemanal = New System.Windows.Forms.ToolStripButton()
        Me.BarraOpciones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevoNpea, Me.btnAprobarNpea, Me.btnCancelarNpea, Me.BtnConsolidadoRacionmodulonutricion, Me.BtnReporteSemanal, Me.btnExportarNpea, Me.btncerrar})
        Me.BarraOpciones.Location = New System.Drawing.Point(0, 272)
        Me.BarraOpciones.Margin = New System.Windows.Forms.Padding(3)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.BarraOpciones.Size = New System.Drawing.Size(2153, 40)
        Me.BarraOpciones.TabIndex = 52
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnNuevoNpea
        '
        Me.btnNuevoNpea.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoNpea.ForeColor = System.Drawing.Color.White
        Me.btnNuevoNpea.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnNuevoNpea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevoNpea.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevoNpea.Name = "btnNuevoNpea"
        Me.btnNuevoNpea.Padding = New System.Windows.Forms.Padding(2)
        Me.btnNuevoNpea.Size = New System.Drawing.Size(108, 30)
        Me.btnNuevoNpea.Text = "Nuevo "
        Me.btnNuevoNpea.ToolTipText = "Nuevo "
        '
        'btnAprobarNpea
        '
        Me.btnAprobarNpea.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobarNpea.ForeColor = System.Drawing.Color.White
        Me.btnAprobarNpea.Image = Global.Formularios.My.Resources.Resources.aprobado__1_
        Me.btnAprobarNpea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAprobarNpea.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAprobarNpea.Name = "btnAprobarNpea"
        Me.btnAprobarNpea.Padding = New System.Windows.Forms.Padding(2)
        Me.btnAprobarNpea.Size = New System.Drawing.Size(120, 30)
        Me.btnAprobarNpea.Text = "Aprobar"
        '
        'btnCancelarNpea
        '
        Me.btnCancelarNpea.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarNpea.ForeColor = System.Drawing.Color.White
        Me.btnCancelarNpea.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.btnCancelarNpea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelarNpea.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCancelarNpea.Name = "btnCancelarNpea"
        Me.btnCancelarNpea.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCancelarNpea.Size = New System.Drawing.Size(105, 30)
        Me.btnCancelarNpea.Text = "Anular"
        '
        'BtnConsolidadoRacionmodulonutricion
        '
        Me.BtnConsolidadoRacionmodulonutricion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsolidadoRacionmodulonutricion.ForeColor = System.Drawing.Color.White
        Me.BtnConsolidadoRacionmodulonutricion.Image = Global.Formularios.My.Resources.Resources.consolidar
        Me.BtnConsolidadoRacionmodulonutricion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnConsolidadoRacionmodulonutricion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnConsolidadoRacionmodulonutricion.Name = "BtnConsolidadoRacionmodulonutricion"
        Me.BtnConsolidadoRacionmodulonutricion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnConsolidadoRacionmodulonutricion.Size = New System.Drawing.Size(352, 30)
        Me.BtnConsolidadoRacionmodulonutricion.Text = "Consolidado de Pedidos Ración"
        Me.BtnConsolidadoRacionmodulonutricion.ToolTipText = "Consolidado"
        '
        'btnExportarNpea
        '
        Me.btnExportarNpea.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarNpea.ForeColor = System.Drawing.Color.White
        Me.btnExportarNpea.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnExportarNpea.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportarNpea.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExportarNpea.Name = "btnExportarNpea"
        Me.btnExportarNpea.Padding = New System.Windows.Forms.Padding(2)
        Me.btnExportarNpea.Size = New System.Drawing.Size(125, 30)
        Me.btnExportarNpea.Text = "Exportar"
        Me.btnExportarNpea.ToolTipText = "Exportar"
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
        Me.btncerrar.Size = New System.Drawing.Size(84, 30)
        Me.btncerrar.Text = "Salir"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.BarraOpciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2153, 312)
        Me.Panel2.TabIndex = 8
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.btnBuscar)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaHasta)
        Me.GrupoFiltros.Controls.Add(Me.cmbEstado)
        Me.GrupoFiltros.Controls.Add(Me.Label4)
        Me.GrupoFiltros.Controls.Add(Me.Label1)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaDesde)
        Me.GrupoFiltros.Location = New System.Drawing.Point(29, 79)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Size = New System.Drawing.Size(1248, 163)
        Me.GrupoFiltros.TabIndex = 159
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros de Búsqueda"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1022, 71)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.btnBuscar.Size = New System.Drawing.Size(152, 62)
        Me.btnBuscar.TabIndex = 162
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(230, 105)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(358, 28)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"TODOS", "PENDIENTE", "APROBADO", "CANCELADO"})
        Me.cmbEstado.Location = New System.Drawing.Point(730, 47)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(194, 28)
        Me.cmbEstado.TabIndex = 161
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(69, 108)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 22)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fecha Hasta :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(630, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 22)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Estado :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(64, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Fecha Desde :"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(231, 45)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(358, 28)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(48, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(510, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONTROL DE PEDIDOS DE ALIMENTO"
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 312)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(2153, 470)
        Me.dtgListado.TabIndex = 9
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(1033, 491)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 26
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'BtnReporteSemanal
        '
        Me.BtnReporteSemanal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnReporteSemanal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReporteSemanal.ForeColor = System.Drawing.Color.White
        Me.BtnReporteSemanal.Image = Global.Formularios.My.Resources.Resources.Reporte_24_px
        Me.BtnReporteSemanal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnReporteSemanal.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnReporteSemanal.Name = "BtnReporteSemanal"
        Me.BtnReporteSemanal.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnReporteSemanal.Size = New System.Drawing.Size(211, 30)
        Me.BtnReporteSemanal.Text = "Reporte Semanal"
        Me.BtnReporteSemanal.ToolTipText = "Exportar"
        '
        'FrmControlPedidoAlimento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2153, 782)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmControlPedidoAlimento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE PEDIDO DE ALIMENTO"
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BarraOpciones As ToolStrip
    Friend WithEvents btnNuevoNpea As ToolStripButton
    Friend WithEvents btnExportarNpea As ToolStripButton
    Friend WithEvents btnAprobarNpea As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnCancelarNpea As ToolStripButton
    Friend WithEvents BtnConsolidadoRacionmodulonutricion As ToolStripButton
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents BtnReporteSemanal As ToolStripButton
End Class
