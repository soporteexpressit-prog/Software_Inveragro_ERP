<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlCorral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlCorral))
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.btnBuscarCorral = New System.Windows.Forms.Button()
        Me.cmbUbicacion = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevoCorralpro = New System.Windows.Forms.ToolStripButton()
        Me.BtnEditarCorralpro = New System.Windows.Forms.ToolStripButton()
        Me.BtnExportarCorralpro = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1196, 188)
        Me.Panel2.TabIndex = 8
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.Label1)
        Me.GrupoFiltros.Controls.Add(Me.CmbEstado)
        Me.GrupoFiltros.Controls.Add(Me.btnBuscarCorral)
        Me.GrupoFiltros.Controls.Add(Me.cmbUbicacion)
        Me.GrupoFiltros.Controls.Add(Me.txtDescripcion)
        Me.GrupoFiltros.Controls.Add(Me.Label2)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Location = New System.Drawing.Point(24, 52)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Size = New System.Drawing.Size(866, 81)
        Me.GrupoFiltros.TabIndex = 159
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros de Búsqueda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(544, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Estado:"
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.CmbEstado.Location = New System.Drawing.Point(608, 37)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(95, 21)
        Me.CmbEstado.TabIndex = 167
        '
        'btnBuscarCorral
        '
        Me.btnBuscarCorral.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarCorral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCorral.Image = CType(resources.GetObject("btnBuscarCorral.Image"), System.Drawing.Image)
        Me.btnBuscarCorral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCorral.Location = New System.Drawing.Point(744, 27)
        Me.btnBuscarCorral.Name = "btnBuscarCorral"
        Me.btnBuscarCorral.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBuscarCorral.Size = New System.Drawing.Size(92, 41)
        Me.btnBuscarCorral.TabIndex = 163
        Me.btnBuscarCorral.Text = "Buscar"
        Me.btnBuscarCorral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarCorral.UseVisualStyleBackColor = True
        '
        'cmbUbicacion
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbUbicacion.DisplayLayout.Appearance = Appearance1
        Me.cmbUbicacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbUbicacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbUbicacion.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbUbicacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cmbUbicacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbUbicacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cmbUbicacion.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbUbicacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbUbicacion.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbUbicacion.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cmbUbicacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cmbUbicacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUbicacion.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbUbicacion.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cmbUbicacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cmbUbicacion.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbUbicacion.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cmbUbicacion.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cmbUbicacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbUbicacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cmbUbicacion.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cmbUbicacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbUbicacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cmbUbicacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbUbicacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbUbicacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbUbicacion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbUbicacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacion.Location = New System.Drawing.Point(351, 35)
        Me.cmbUbicacion.Name = "cmbUbicacion"
        Me.cmbUbicacion.Size = New System.Drawing.Size(139, 25)
        Me.cmbUbicacion.TabIndex = 166
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(85, 36)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(168, 22)
        Me.txtDescripcion.TabIndex = 164
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(290, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Plantel:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 40)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Corral :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(34, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(226, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONTROL DE CORRALES"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevoCorralpro, Me.BtnEditarCorralpro, Me.BtnExportarCorralpro, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 150)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1196, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNuevoCorralpro
        '
        Me.BtnNuevoCorralpro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevoCorralpro.ForeColor = System.Drawing.Color.White
        Me.BtnNuevoCorralpro.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.BtnNuevoCorralpro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoCorralpro.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnNuevoCorralpro.Name = "BtnNuevoCorralpro"
        Me.BtnNuevoCorralpro.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnNuevoCorralpro.Size = New System.Drawing.Size(81, 28)
        Me.BtnNuevoCorralpro.Text = "Nuevo "
        Me.BtnNuevoCorralpro.ToolTipText = "Nuevo "
        '
        'BtnEditarCorralpro
        '
        Me.BtnEditarCorralpro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditarCorralpro.ForeColor = System.Drawing.Color.White
        Me.BtnEditarCorralpro.Image = Global.Formularios.My.Resources.Resources.editar
        Me.BtnEditarCorralpro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditarCorralpro.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnEditarCorralpro.Name = "BtnEditarCorralpro"
        Me.BtnEditarCorralpro.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnEditarCorralpro.Size = New System.Drawing.Size(74, 28)
        Me.BtnEditarCorralpro.Text = "Editar"
        '
        'BtnExportarCorralpro
        '
        Me.BtnExportarCorralpro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarCorralpro.ForeColor = System.Drawing.Color.White
        Me.BtnExportarCorralpro.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarCorralpro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarCorralpro.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarCorralpro.Name = "BtnExportarCorralpro"
        Me.BtnExportarCorralpro.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarCorralpro.Size = New System.Drawing.Size(92, 28)
        Me.BtnExportarCorralpro.Text = "Exportar"
        Me.BtnExportarCorralpro.ToolTipText = "Exportar"
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
        Me.BtnCerrar.Size = New System.Drawing.Size(66, 28)
        Me.BtnCerrar.Text = "Salir"
        '
        'dtgListado
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance13.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance13
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.Navy
        Appearance18.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance20
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.Color.AliceBlue
        Appearance22.BackColor2 = System.Drawing.Color.Silver
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance25
        Appearance26.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance26
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 188)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1196, 467)
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
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(573, 384)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 26
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlCorral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 655)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmControlCorral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE CORRALES"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        CType(Me.cmbUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnBuscarCorral As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnNuevoCorralpro As ToolStripButton
    Friend WithEvents BtnEditarCorralpro As ToolStripButton
    Friend WithEvents BtnExportarCorralpro As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Label6 As Label
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents cmbUbicacion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label2 As Label
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents Label1 As Label
End Class
