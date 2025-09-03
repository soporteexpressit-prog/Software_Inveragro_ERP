<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlBajada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlBajada))
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BarraNavegacion = New System.Windows.Forms.ToolStrip()
        Me.BtnConfirmarBajada = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarConfirmacion = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarBajada = New System.Windows.Forms.ToolStripButton()
        Me.BtnConfirmarPeso = New System.Windows.Forms.ToolStripButton()
        Me.BtnRetornarCerdascontrolbajadapro = New System.Windows.Forms.ToolStripButton()
        Me.BtnExportarControlCerdacontrolbajadapro = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnreporteRrhhctrlcapaci = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnReporteGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbAnios = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbUbicacion = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraNavegacion.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        CType(Me.CmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 286)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1965, 699)
        Me.dtgListado.TabIndex = 37
        Me.dtgListado.Tag = "   "
        Me.dtgListado.Text = "UltraGrid1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(62, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(869, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONTROL DE CERDOS EN BAJADA Y RETORNO DE CHANCHILLAS"
        '
        'BarraNavegacion
        '
        Me.BarraNavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraNavegacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraNavegacion.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraNavegacion.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraNavegacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnConfirmarBajada, Me.BtnCancelarConfirmacion, Me.BtnCancelarBajada, Me.BtnConfirmarPeso, Me.BtnRetornarCerdascontrolbajadapro, Me.BtnExportarControlCerdacontrolbajadapro, Me.BtnCerrar, Me.btnreporteRrhhctrlcapaci})
        Me.BarraNavegacion.Location = New System.Drawing.Point(0, 246)
        Me.BarraNavegacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BarraNavegacion.Name = "BarraNavegacion"
        Me.BarraNavegacion.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.BarraNavegacion.Size = New System.Drawing.Size(1965, 40)
        Me.BarraNavegacion.TabIndex = 52
        Me.BarraNavegacion.Text = "Monitoreo"
        '
        'BtnConfirmarBajada
        '
        Me.BtnConfirmarBajada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmarBajada.ForeColor = System.Drawing.Color.White
        Me.BtnConfirmarBajada.Image = Global.Formularios.My.Resources.Resources.camion_de_carga
        Me.BtnConfirmarBajada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnConfirmarBajada.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnConfirmarBajada.Name = "BtnConfirmarBajada"
        Me.BtnConfirmarBajada.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnConfirmarBajada.Size = New System.Drawing.Size(215, 30)
        Me.BtnConfirmarBajada.Text = "Confirmar Bajada"
        Me.BtnConfirmarBajada.ToolTipText = "Filtrar"
        '
        'BtnCancelarConfirmacion
        '
        Me.BtnCancelarConfirmacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarConfirmacion.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarConfirmacion.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.BtnCancelarConfirmacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarConfirmacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarConfirmacion.Name = "BtnCancelarConfirmacion"
        Me.BtnCancelarConfirmacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarConfirmacion.Size = New System.Drawing.Size(266, 30)
        Me.BtnCancelarConfirmacion.Text = "Cancelar Confirmación"
        Me.BtnCancelarConfirmacion.ToolTipText = "Filtrar"
        '
        'BtnCancelarBajada
        '
        Me.BtnCancelarBajada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarBajada.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarBajada.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.BtnCancelarBajada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarBajada.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarBajada.Name = "BtnCancelarBajada"
        Me.BtnCancelarBajada.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarBajada.Size = New System.Drawing.Size(202, 30)
        Me.BtnCancelarBajada.Text = "Cancelar Bajada"
        Me.BtnCancelarBajada.ToolTipText = "Filtrar"
        '
        'BtnConfirmarPeso
        '
        Me.BtnConfirmarPeso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirmarPeso.ForeColor = System.Drawing.Color.White
        Me.BtnConfirmarPeso.Image = Global.Formularios.My.Resources.Resources.peso
        Me.BtnConfirmarPeso.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnConfirmarPeso.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnConfirmarPeso.Name = "BtnConfirmarPeso"
        Me.BtnConfirmarPeso.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnConfirmarPeso.Size = New System.Drawing.Size(269, 30)
        Me.BtnConfirmarPeso.Text = "Confirmar Peso Bajada"
        Me.BtnConfirmarPeso.ToolTipText = "Peso"
        '
        'BtnRetornarCerdascontrolbajadapro
        '
        Me.BtnRetornarCerdascontrolbajadapro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRetornarCerdascontrolbajadapro.ForeColor = System.Drawing.Color.White
        Me.BtnRetornarCerdascontrolbajadapro.Image = Global.Formularios.My.Resources.Resources.deshacer
        Me.BtnRetornarCerdascontrolbajadapro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRetornarCerdascontrolbajadapro.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnRetornarCerdascontrolbajadapro.Name = "BtnRetornarCerdascontrolbajadapro"
        Me.BtnRetornarCerdascontrolbajadapro.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnRetornarCerdascontrolbajadapro.Size = New System.Drawing.Size(249, 30)
        Me.BtnRetornarCerdascontrolbajadapro.Text = "Retornar Chanchillas"
        Me.BtnRetornarCerdascontrolbajadapro.ToolTipText = "Parto"
        '
        'BtnExportarControlCerdacontrolbajadapro
        '
        Me.BtnExportarControlCerdacontrolbajadapro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarControlCerdacontrolbajadapro.ForeColor = System.Drawing.Color.White
        Me.BtnExportarControlCerdacontrolbajadapro.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarControlCerdacontrolbajadapro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarControlCerdacontrolbajadapro.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarControlCerdacontrolbajadapro.Name = "BtnExportarControlCerdacontrolbajadapro"
        Me.BtnExportarControlCerdacontrolbajadapro.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarControlCerdacontrolbajadapro.Size = New System.Drawing.Size(125, 30)
        Me.BtnExportarControlCerdacontrolbajadapro.Text = "Exportar"
        Me.BtnExportarControlCerdacontrolbajadapro.ToolTipText = "Exportar"
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
        Me.BtnCerrar.Size = New System.Drawing.Size(84, 30)
        Me.BtnCerrar.Text = "Salir"
        '
        'btnreporteRrhhctrlcapaci
        '
        Me.btnreporteRrhhctrlcapaci.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnreporteRrhhctrlcapaci.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporteGeneral})
        Me.btnreporteRrhhctrlcapaci.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporteRrhhctrlcapaci.ForeColor = System.Drawing.Color.White
        Me.btnreporteRrhhctrlcapaci.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.btnreporteRrhhctrlcapaci.Margin = New System.Windows.Forms.Padding(5)
        Me.btnreporteRrhhctrlcapaci.Name = "btnreporteRrhhctrlcapaci"
        Me.btnreporteRrhhctrlcapaci.Padding = New System.Windows.Forms.Padding(2)
        Me.btnreporteRrhhctrlcapaci.Size = New System.Drawing.Size(143, 30)
        Me.btnreporteRrhhctrlcapaci.Text = "Reportes"
        '
        'BtnReporteGeneral
        '
        Me.BtnReporteGeneral.Name = "BtnReporteGeneral"
        Me.BtnReporteGeneral.Size = New System.Drawing.Size(247, 34)
        Me.BtnReporteGeneral.Text = "Bajada x Lote"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.BarraNavegacion)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1965, 286)
        Me.Panel2.TabIndex = 14
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.btnBuscar)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.CmbAnios)
        Me.GrupoFiltros.Controls.Add(Me.Label5)
        Me.GrupoFiltros.Controls.Add(Me.CmbUbicacion)
        Me.GrupoFiltros.Location = New System.Drawing.Point(38, 98)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Size = New System.Drawing.Size(984, 111)
        Me.GrupoFiltros.TabIndex = 183
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros de Búsqueda"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(778, 27)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.btnBuscar.Size = New System.Drawing.Size(138, 63)
        Me.btnBuscar.TabIndex = 182
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(383, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 22)
        Me.Label3.TabIndex = 177
        Me.Label3.Text = "Seleccione año :"
        '
        'CmbAnios
        '
        Me.CmbAnios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbAnios.FormattingEnabled = True
        Me.CmbAnios.Location = New System.Drawing.Point(567, 40)
        Me.CmbAnios.Name = "CmbAnios"
        Me.CmbAnios.Size = New System.Drawing.Size(140, 37)
        Me.CmbAnios.TabIndex = 178
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(44, 47)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 22)
        Me.Label5.TabIndex = 181
        Me.Label5.Text = "Plantel :"
        '
        'CmbUbicacion
        '
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.CmbUbicacion.DisplayLayout.Appearance = Appearance16
        Me.CmbUbicacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.CmbUbicacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbUbicacion.DisplayLayout.GroupByBox.Appearance = Appearance17
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbUbicacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance18
        Me.CmbUbicacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance19.BackColor2 = System.Drawing.SystemColors.Control
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbUbicacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance19
        Me.CmbUbicacion.DisplayLayout.MaxColScrollRegions = 1
        Me.CmbUbicacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmbUbicacion.DisplayLayout.Override.ActiveCellAppearance = Appearance20
        Appearance21.BackColor = System.Drawing.SystemColors.Highlight
        Appearance21.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.CmbUbicacion.DisplayLayout.Override.ActiveRowAppearance = Appearance21
        Me.CmbUbicacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.CmbUbicacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Me.CmbUbicacion.DisplayLayout.Override.CardAreaAppearance = Appearance22
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.CmbUbicacion.DisplayLayout.Override.CellAppearance = Appearance23
        Me.CmbUbicacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.CmbUbicacion.DisplayLayout.Override.CellPadding = 0
        Appearance24.BackColor = System.Drawing.SystemColors.Control
        Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbUbicacion.DisplayLayout.Override.GroupByRowAppearance = Appearance24
        Appearance25.TextHAlignAsString = "Left"
        Me.CmbUbicacion.DisplayLayout.Override.HeaderAppearance = Appearance25
        Me.CmbUbicacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.CmbUbicacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.Color.Silver
        Me.CmbUbicacion.DisplayLayout.Override.RowAppearance = Appearance26
        Me.CmbUbicacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbUbicacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
        Me.CmbUbicacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.CmbUbicacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.CmbUbicacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.CmbUbicacion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CmbUbicacion.Location = New System.Drawing.Point(143, 44)
        Me.CmbUbicacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Size = New System.Drawing.Size(182, 29)
        Me.CmbUbicacion.TabIndex = 180
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(939, 551)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 38
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlBajada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1965, 985)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmControlBajada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE BAJADA"
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraNavegacion.ResumeLayout(False)
        Me.BarraNavegacion.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        CType(Me.CmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents BarraNavegacion As ToolStrip
    Friend WithEvents BtnRetornarCerdascontrolbajadapro As ToolStripButton
    Friend WithEvents BtnExportarControlCerdacontrolbajadapro As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CmbAnios As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbUbicacion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents BtnConfirmarBajada As ToolStripButton
    Friend WithEvents BtnCancelarBajada As ToolStripButton
    Friend WithEvents BtnCancelarConfirmacion As ToolStripButton
    Friend WithEvents BtnConfirmarPeso As ToolStripButton
    Friend WithEvents btnreporteRrhhctrlcapaci As ToolStripDropDownButton
    Friend WithEvents BtnReporteGeneral As ToolStripMenuItem
    Friend WithEvents GrupoFiltros As GroupBox
End Class
