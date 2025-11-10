<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlAlimento
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnKardexAlmacenali = New System.Windows.Forms.ToolStripButton()
        Me.btnConsolidadoalmacenali = New System.Windows.Forms.ToolStripButton()
        Me.BtnVerFormula = New System.Windows.Forms.ToolStripButton()
        Me.BtnPedidoAlimentoalmacenali = New System.Windows.Forms.ToolStripButton()
        Me.btnExportaralmacenali = New System.Windows.Forms.ToolStripButton()
        Me.btnAsignarUnidadesMedida = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditarUnidadMedida = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnreporteRrhhctrlcapaci = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnReporteAnual = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnReporteSemanal = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteRecepcionesDespachos = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblalmacen = New Infragistics.Win.Misc.UltraLabel()
        Me.cbxalmacen = New System.Windows.Forms.ComboBox()
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
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnKardexAlmacenali, Me.btnConsolidadoalmacenali, Me.BtnVerFormula, Me.BtnPedidoAlimentoalmacenali, Me.btnExportaralmacenali, Me.btnAsignarUnidadesMedida, Me.BtnEditarUnidadMedida, Me.btncerrar, Me.btnreporteRrhhctrlcapaci})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 143)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1283, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnKardexAlmacenali
        '
        Me.BtnKardexAlmacenali.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKardexAlmacenali.ForeColor = System.Drawing.Color.White
        Me.BtnKardexAlmacenali.Image = Global.Formularios.My.Resources.Resources.portapapeles
        Me.BtnKardexAlmacenali.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnKardexAlmacenali.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnKardexAlmacenali.Name = "BtnKardexAlmacenali"
        Me.BtnKardexAlmacenali.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnKardexAlmacenali.Size = New System.Drawing.Size(82, 28)
        Me.BtnKardexAlmacenali.Text = "Kardex"
        '
        'btnConsolidadoalmacenali
        '
        Me.btnConsolidadoalmacenali.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsolidadoalmacenali.ForeColor = System.Drawing.Color.White
        Me.btnConsolidadoalmacenali.Image = Global.Formularios.My.Resources.Resources.consolidar
        Me.btnConsolidadoalmacenali.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsolidadoalmacenali.Margin = New System.Windows.Forms.Padding(5)
        Me.btnConsolidadoalmacenali.Name = "btnConsolidadoalmacenali"
        Me.btnConsolidadoalmacenali.Padding = New System.Windows.Forms.Padding(2)
        Me.btnConsolidadoalmacenali.Size = New System.Drawing.Size(115, 28)
        Me.btnConsolidadoalmacenali.Text = "Consolidado"
        '
        'BtnVerFormula
        '
        Me.BtnVerFormula.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVerFormula.ForeColor = System.Drawing.Color.White
        Me.BtnVerFormula.Image = Global.Formularios.My.Resources.Resources.ver24px
        Me.BtnVerFormula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVerFormula.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnVerFormula.Name = "BtnVerFormula"
        Me.BtnVerFormula.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnVerFormula.Size = New System.Drawing.Size(116, 28)
        Me.BtnVerFormula.Text = "Ver Fórmula"
        '
        'BtnPedidoAlimentoalmacenali
        '
        Me.BtnPedidoAlimentoalmacenali.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPedidoAlimentoalmacenali.ForeColor = System.Drawing.Color.White
        Me.BtnPedidoAlimentoalmacenali.Image = Global.Formularios.My.Resources.Resources.notas
        Me.BtnPedidoAlimentoalmacenali.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPedidoAlimentoalmacenali.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnPedidoAlimentoalmacenali.Name = "BtnPedidoAlimentoalmacenali"
        Me.BtnPedidoAlimentoalmacenali.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnPedidoAlimentoalmacenali.Size = New System.Drawing.Size(155, 28)
        Me.BtnPedidoAlimentoalmacenali.Text = "Pedidos de Ración"
        '
        'btnExportaralmacenali
        '
        Me.btnExportaralmacenali.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportaralmacenali.ForeColor = System.Drawing.Color.White
        Me.btnExportaralmacenali.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnExportaralmacenali.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportaralmacenali.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExportaralmacenali.Name = "btnExportaralmacenali"
        Me.btnExportaralmacenali.Padding = New System.Windows.Forms.Padding(2)
        Me.btnExportaralmacenali.Size = New System.Drawing.Size(92, 28)
        Me.btnExportaralmacenali.Text = "Exportar"
        Me.btnExportaralmacenali.ToolTipText = "Exportar"
        '
        'btnAsignarUnidadesMedida
        '
        Me.btnAsignarUnidadesMedida.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnAsignarUnidadesMedida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignarUnidadesMedida.ForeColor = System.Drawing.Color.White
        Me.btnAsignarUnidadesMedida.Image = Global.Formularios.My.Resources.Resources.sincronizar
        Me.btnAsignarUnidadesMedida.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAsignarUnidadesMedida.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAsignarUnidadesMedida.Name = "btnAsignarUnidadesMedida"
        Me.btnAsignarUnidadesMedida.Padding = New System.Windows.Forms.Padding(2)
        Me.btnAsignarUnidadesMedida.Size = New System.Drawing.Size(114, 28)
        Me.btnAsignarUnidadesMedida.Text = "Asignar U.M"
        Me.btnAsignarUnidadesMedida.ToolTipText = "Asignar U.M"
        '
        'BtnEditarUnidadMedida
        '
        Me.BtnEditarUnidadMedida.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnEditarUnidadMedida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditarUnidadMedida.ForeColor = System.Drawing.Color.White
        Me.BtnEditarUnidadMedida.Image = Global.Formularios.My.Resources.Resources.editar_texto
        Me.BtnEditarUnidadMedida.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditarUnidadMedida.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnEditarUnidadMedida.Name = "BtnEditarUnidadMedida"
        Me.BtnEditarUnidadMedida.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnEditarUnidadMedida.Size = New System.Drawing.Size(103, 28)
        Me.BtnEditarUnidadMedida.Text = "Editar U.M"
        Me.BtnEditarUnidadMedida.ToolTipText = "Asignar U.M"
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
        'btnreporteRrhhctrlcapaci
        '
        Me.btnreporteRrhhctrlcapaci.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnreporteRrhhctrlcapaci.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnReporteAnual, Me.BtnReporteSemanal, Me.ReporteRecepcionesDespachos})
        Me.btnreporteRrhhctrlcapaci.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporteRrhhctrlcapaci.ForeColor = System.Drawing.Color.White
        Me.btnreporteRrhhctrlcapaci.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.btnreporteRrhhctrlcapaci.Margin = New System.Windows.Forms.Padding(5)
        Me.btnreporteRrhhctrlcapaci.Name = "btnreporteRrhhctrlcapaci"
        Me.btnreporteRrhhctrlcapaci.Padding = New System.Windows.Forms.Padding(2)
        Me.btnreporteRrhhctrlcapaci.Size = New System.Drawing.Size(103, 28)
        Me.btnreporteRrhhctrlcapaci.Text = "Reportes"
        '
        'BtnReporteAnual
        '
        Me.BtnReporteAnual.Name = "BtnReporteAnual"
        Me.BtnReporteAnual.Size = New System.Drawing.Size(243, 22)
        Me.BtnReporteAnual.Text = "Alimento Anual"
        '
        'BtnReporteSemanal
        '
        Me.BtnReporteSemanal.Name = "BtnReporteSemanal"
        Me.BtnReporteSemanal.Size = New System.Drawing.Size(243, 22)
        Me.BtnReporteSemanal.Text = "Alimento Semanal"
        '
        'ReporteRecepcionesDespachos
        '
        Me.ReporteRecepcionesDespachos.Name = "ReporteRecepcionesDespachos"
        Me.ReporteRecepcionesDespachos.Size = New System.Drawing.Size(243, 22)
        Me.ReporteRecepcionesDespachos.Text = "Despachos y Recepciones"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1283, 181)
        Me.Panel2.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblalmacen)
        Me.GroupBox1.Controls.Add(Me.cbxalmacen)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 57)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(539, 77)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro de Búsqueda"
        '
        'lblalmacen
        '
        Appearance17.BackColor = System.Drawing.Color.Transparent
        Appearance17.FontData.SizeInPoints = 9.0!
        Appearance17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance17.TextVAlignAsString = "Middle"
        Me.lblalmacen.Appearance = Appearance17
        Me.lblalmacen.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblalmacen.Location = New System.Drawing.Point(29, 34)
        Me.lblalmacen.Name = "lblalmacen"
        Me.lblalmacen.Size = New System.Drawing.Size(73, 20)
        Me.lblalmacen.TabIndex = 181
        Me.lblalmacen.Text = "Almacen :"
        '
        'cbxalmacen
        '
        Me.cbxalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxalmacen.FormattingEnabled = True
        Me.cbxalmacen.Location = New System.Drawing.Point(108, 34)
        Me.cbxalmacen.Name = "cbxalmacen"
        Me.cbxalmacen.Size = New System.Drawing.Size(375, 21)
        Me.cbxalmacen.TabIndex = 182
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(11, 19)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(322, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONTROL DE ALIMENTO DE CERDO"
        '
        'dtgListado
        '
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance2.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance2
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.Color.Navy
        Appearance7.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance9
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.AliceBlue
        Appearance11.BackColor2 = System.Drawing.Color.Silver
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance15
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 181)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1283, 409)
        Me.dtgListado.TabIndex = 10
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(668, 283)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 27
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlAlimento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 590)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmControlAlimento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE ALIMENTOS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnExportaralmacenali As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnConsolidadoalmacenali As ToolStripButton
    Friend WithEvents BtnPedidoAlimentoalmacenali As ToolStripButton
    Friend WithEvents BtnKardexAlmacenali As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblalmacen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cbxalmacen As ComboBox
    Friend WithEvents btnreporteRrhhctrlcapaci As ToolStripDropDownButton
    Friend WithEvents BtnReporteAnual As ToolStripMenuItem
    Friend WithEvents BtnReporteSemanal As ToolStripMenuItem
    Friend WithEvents ReporteRecepcionesDespachos As ToolStripMenuItem
    Friend WithEvents BtnVerFormula As ToolStripButton
    Friend WithEvents btnAsignarUnidadesMedida As ToolStripButton
    Friend WithEvents BtnEditarUnidadMedida As ToolStripButton
End Class
