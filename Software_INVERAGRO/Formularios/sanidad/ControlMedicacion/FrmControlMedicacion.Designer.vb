<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlMedicacion
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnVacunacion = New System.Windows.Forms.ToolStripButton()
        Me.BtnTratamiento = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarmedicacioncerdossanidav2 = New System.Windows.Forms.ToolStripButton()
        Me.BtnExportarMedicacioncerdosanidadv2 = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.BtnCronograma = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BtnCronogramaGestacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCronogramaEngorde = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbUbicacion = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.CmbModoAplicacion = New System.Windows.Forms.ComboBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscarMedicacion = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.btnNuevaMedicacionsanidad = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarmedicacioncerdossanida = New System.Windows.Forms.ToolStripButton()
        Me.BtnExportarMedicacioncerdosanidad = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnFiltros = New System.Windows.Forms.ToolStripButton()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        CType(Me.CmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 238)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1212, 389)
        Me.dtgListado.TabIndex = 27
        Me.dtgListado.Text = "UltraGrid1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnVacunacion, Me.BtnTratamiento, Me.BtnCancelarmedicacioncerdossanidav2, Me.BtnExportarMedicacioncerdosanidadv2, Me.BtnSalir, Me.BtnCronograma})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 200)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1212, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnVacunacion
        '
        Me.BtnVacunacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVacunacion.ForeColor = System.Drawing.Color.White
        Me.BtnVacunacion.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.BtnVacunacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVacunacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnVacunacion.Name = "BtnVacunacion"
        Me.BtnVacunacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnVacunacion.Size = New System.Drawing.Size(110, 28)
        Me.BtnVacunacion.Text = "Vacunación"
        Me.BtnVacunacion.ToolTipText = "Nuevo "
        '
        'BtnTratamiento
        '
        Me.BtnTratamiento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTratamiento.ForeColor = System.Drawing.Color.White
        Me.BtnTratamiento.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.BtnTratamiento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnTratamiento.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnTratamiento.Name = "BtnTratamiento"
        Me.BtnTratamiento.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnTratamiento.Size = New System.Drawing.Size(115, 28)
        Me.BtnTratamiento.Text = "Tratamiento"
        Me.BtnTratamiento.ToolTipText = "Nuevo "
        '
        'BtnCancelarmedicacioncerdossanidav2
        '
        Me.BtnCancelarmedicacioncerdossanidav2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarmedicacioncerdossanidav2.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarmedicacioncerdossanidav2.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.BtnCancelarmedicacioncerdossanidav2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarmedicacioncerdossanidav2.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarmedicacioncerdossanidav2.Name = "BtnCancelarmedicacioncerdossanidav2"
        Me.BtnCancelarmedicacioncerdossanidav2.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarmedicacioncerdossanidav2.Size = New System.Drawing.Size(93, 28)
        Me.BtnCancelarmedicacioncerdossanidav2.Text = "Cancelar"
        '
        'BtnExportarMedicacioncerdosanidadv2
        '
        Me.BtnExportarMedicacioncerdosanidadv2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarMedicacioncerdosanidadv2.ForeColor = System.Drawing.Color.White
        Me.BtnExportarMedicacioncerdosanidadv2.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarMedicacioncerdosanidadv2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarMedicacioncerdosanidadv2.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarMedicacioncerdosanidadv2.Name = "BtnExportarMedicacioncerdosanidadv2"
        Me.BtnExportarMedicacioncerdosanidadv2.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarMedicacioncerdosanidadv2.Size = New System.Drawing.Size(92, 28)
        Me.BtnExportarMedicacioncerdosanidadv2.Text = "Exportar"
        Me.BtnExportarMedicacioncerdosanidadv2.ToolTipText = "Exportar"
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnSalir.Size = New System.Drawing.Size(66, 28)
        Me.BtnSalir.Text = "Salir"
        '
        'BtnCronograma
        '
        Me.BtnCronograma.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnCronograma.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCronogramaGestacion, Me.BtnCronogramaEngorde})
        Me.BtnCronograma.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCronograma.ForeColor = System.Drawing.Color.White
        Me.BtnCronograma.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.BtnCronograma.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCronograma.Name = "BtnCronograma"
        Me.BtnCronograma.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCronograma.Size = New System.Drawing.Size(224, 28)
        Me.BtnCronograma.Text = "Cronograma de Vacunación"
        '
        'BtnCronogramaGestacion
        '
        Me.BtnCronogramaGestacion.Name = "BtnCronogramaGestacion"
        Me.BtnCronogramaGestacion.Size = New System.Drawing.Size(180, 22)
        Me.BtnCronogramaGestacion.Text = "Gestación"
        '
        'BtnCronogramaEngorde
        '
        Me.BtnCronogramaEngorde.Name = "BtnCronogramaEngorde"
        Me.BtnCronogramaEngorde.Size = New System.Drawing.Size(180, 22)
        Me.BtnCronogramaEngorde.Text = "Engorde"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1212, 238)
        Me.Panel2.TabIndex = 9
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.CmbEstado)
        Me.GrupoFiltros.Controls.Add(Me.Label5)
        Me.GrupoFiltros.Controls.Add(Me.CmbUbicacion)
        Me.GrupoFiltros.Controls.Add(Me.Label1)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaHasta)
        Me.GrupoFiltros.Controls.Add(Me.CmbModoAplicacion)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaDesde)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.Label2)
        Me.GrupoFiltros.Controls.Add(Me.Label4)
        Me.GrupoFiltros.Controls.Add(Me.btnBuscarMedicacion)
        Me.GrupoFiltros.Location = New System.Drawing.Point(21, 65)
        Me.GrupoFiltros.Margin = New System.Windows.Forms.Padding(2)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Padding = New System.Windows.Forms.Padding(2)
        Me.GrupoFiltros.Size = New System.Drawing.Size(1085, 113)
        Me.GrupoFiltros.TabIndex = 170
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros de Búsqueda"
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Items.AddRange(New Object() {"APLICADO", "CANCELADO"})
        Me.CmbEstado.Location = New System.Drawing.Point(800, 35)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(111, 21)
        Me.CmbEstado.TabIndex = 170
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(733, 37)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 14)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "Estado :"
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
        Me.CmbUbicacion.Location = New System.Drawing.Point(519, 68)
        Me.CmbUbicacion.Name = "CmbUbicacion"
        Me.CmbUbicacion.Size = New System.Drawing.Size(147, 22)
        Me.CmbUbicacion.TabIndex = 168
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(450, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Plantel :"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(143, 70)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(240, 21)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'CmbModoAplicacion
        '
        Me.CmbModoAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbModoAplicacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbModoAplicacion.FormattingEnabled = True
        Me.CmbModoAplicacion.Items.AddRange(New Object() {"VACUNACIÓN", "TRATAMIENTO"})
        Me.CmbModoAplicacion.Location = New System.Drawing.Point(519, 35)
        Me.CmbModoAplicacion.Name = "CmbModoAplicacion"
        Me.CmbModoAplicacion.Size = New System.Drawing.Size(148, 21)
        Me.CmbModoAplicacion.TabIndex = 165
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(143, 35)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(240, 21)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(35, 37)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 14)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Fecha Desde :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(468, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "Tipo :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(38, 72)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 14)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fecha Hasta :"
        '
        'btnBuscarMedicacion
        '
        Me.btnBuscarMedicacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarMedicacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarMedicacion.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnBuscarMedicacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarMedicacion.Location = New System.Drawing.Point(973, 45)
        Me.btnBuscarMedicacion.Name = "btnBuscarMedicacion"
        Me.btnBuscarMedicacion.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBuscarMedicacion.Size = New System.Drawing.Size(92, 41)
        Me.btnBuscarMedicacion.TabIndex = 163
        Me.btnBuscarMedicacion.Text = "Buscar"
        Me.btnBuscarMedicacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarMedicacion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(37, 27)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(296, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "VACUNACIÓN Y TRATAMIENTOS"
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(567, 356)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 28
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'btnNuevaMedicacionsanidad
        '
        Me.btnNuevaMedicacionsanidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaMedicacionsanidad.ForeColor = System.Drawing.Color.White
        Me.btnNuevaMedicacionsanidad.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnNuevaMedicacionsanidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevaMedicacionsanidad.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevaMedicacionsanidad.Name = "btnNuevaMedicacionsanidad"
        Me.btnNuevaMedicacionsanidad.Padding = New System.Windows.Forms.Padding(2)
        Me.btnNuevaMedicacionsanidad.Size = New System.Drawing.Size(108, 30)
        Me.btnNuevaMedicacionsanidad.Text = "Nuevo "
        Me.btnNuevaMedicacionsanidad.ToolTipText = "Nuevo "
        '
        'BtnCancelarmedicacioncerdossanida
        '
        Me.BtnCancelarmedicacioncerdossanida.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarmedicacioncerdossanida.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarmedicacioncerdossanida.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnCancelarmedicacioncerdossanida.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarmedicacioncerdossanida.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarmedicacioncerdossanida.Name = "BtnCancelarmedicacioncerdossanida"
        Me.BtnCancelarmedicacioncerdossanida.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarmedicacioncerdossanida.Size = New System.Drawing.Size(126, 30)
        Me.BtnCancelarmedicacioncerdossanida.Text = "Cancelar"
        Me.BtnCancelarmedicacioncerdossanida.ToolTipText = "Exportar"
        '
        'BtnExportarMedicacioncerdosanidad
        '
        Me.BtnExportarMedicacioncerdosanidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarMedicacioncerdosanidad.ForeColor = System.Drawing.Color.White
        Me.BtnExportarMedicacioncerdosanidad.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarMedicacioncerdosanidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarMedicacioncerdosanidad.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarMedicacioncerdosanidad.Name = "BtnExportarMedicacioncerdosanidad"
        Me.BtnExportarMedicacioncerdosanidad.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarMedicacioncerdosanidad.Size = New System.Drawing.Size(125, 30)
        Me.BtnExportarMedicacioncerdosanidad.Text = "Exportar"
        Me.BtnExportarMedicacioncerdosanidad.ToolTipText = "Exportar"
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
        'BtnFiltros
        '
        Me.BtnFiltros.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnFiltros.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltros.ForeColor = System.Drawing.Color.White
        Me.BtnFiltros.Image = Global.Formularios.My.Resources.Resources.filter__2_1
        Me.BtnFiltros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnFiltros.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnFiltros.Name = "BtnFiltros"
        Me.BtnFiltros.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnFiltros.Size = New System.Drawing.Size(102, 30)
        Me.BtnFiltros.Text = "Filtros"
        '
        'FrmControlMedicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 627)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmControlMedicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE MEDICACIÓN CERDOS"
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        CType(Me.CmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNuevaMedicacionsanidad As ToolStripButton
    Friend WithEvents BtnExportarMedicacioncerdosanidad As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents BtnFiltros As ToolStripButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BtnCancelarmedicacioncerdossanida As ToolStripButton
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnTratamiento As ToolStripButton
    Friend WithEvents BtnCancelarmedicacioncerdossanidav2 As ToolStripButton
    Friend WithEvents BtnExportarMedicacioncerdosanidadv2 As ToolStripButton
    Friend WithEvents BtnSalir As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents CmbUbicacion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents CmbModoAplicacion As ComboBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBuscarMedicacion As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnVacunacion As ToolStripButton
    Friend WithEvents BtnCronograma As ToolStripDropDownButton
    Friend WithEvents BtnCronogramaGestacion As ToolStripMenuItem
    Friend WithEvents BtnCronogramaEngorde As ToolStripMenuItem
End Class
