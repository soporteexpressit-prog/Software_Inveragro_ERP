<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteCondicionCorporal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteCondicionCorporal))
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
        Me.Contenedor = New System.Windows.Forms.Panel()
        Me.FiltrosBusqueda = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.LblLotes = New System.Windows.Forms.Label()
        Me.CmbLotes = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.LblPeriodo = New System.Windows.Forms.Label()
        Me.CmbAnios = New System.Windows.Forms.ComboBox()
        Me.NumLote = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblSemana = New System.Windows.Forms.Label()
        Me.LblDiaPic = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BarraNavegacion = New System.Windows.Forms.ToolStrip()
        Me.BtnExportarControlCerdacontrollotespro = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.CmbTipoControl = New System.Windows.Forms.ComboBox()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Contenedor.SuspendLayout()
        Me.FiltrosBusqueda.SuspendLayout()
        CType(Me.CmbLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumLote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraNavegacion.SuspendLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Contenedor
        '
        Me.Contenedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Contenedor.Controls.Add(Me.Label1)
        Me.Contenedor.Controls.Add(Me.FiltrosBusqueda)
        Me.Contenedor.Controls.Add(Me.LblDiaPic)
        Me.Contenedor.Controls.Add(Me.Label6)
        Me.Contenedor.Controls.Add(Me.BarraNavegacion)
        Me.Contenedor.Controls.Add(Me.CmbTipoControl)
        Me.Contenedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.Contenedor.Location = New System.Drawing.Point(0, 0)
        Me.Contenedor.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.Size = New System.Drawing.Size(699, 232)
        Me.Contenedor.TabIndex = 16
        '
        'FiltrosBusqueda
        '
        Me.FiltrosBusqueda.Controls.Add(Me.btnBuscar)
        Me.FiltrosBusqueda.Controls.Add(Me.LblLotes)
        Me.FiltrosBusqueda.Controls.Add(Me.CmbLotes)
        Me.FiltrosBusqueda.Controls.Add(Me.LblPeriodo)
        Me.FiltrosBusqueda.Controls.Add(Me.CmbAnios)
        Me.FiltrosBusqueda.Controls.Add(Me.NumLote)
        Me.FiltrosBusqueda.Controls.Add(Me.Label2)
        Me.FiltrosBusqueda.Controls.Add(Me.LblSemana)
        Me.FiltrosBusqueda.Location = New System.Drawing.Point(36, 71)
        Me.FiltrosBusqueda.Name = "FiltrosBusqueda"
        Me.FiltrosBusqueda.Size = New System.Drawing.Size(643, 104)
        Me.FiltrosBusqueda.TabIndex = 240
        Me.FiltrosBusqueda.TabStop = False
        Me.FiltrosBusqueda.Text = "Filtros de Búsqueda"
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(427, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBuscar.Size = New System.Drawing.Size(92, 41)
        Me.btnBuscar.TabIndex = 189
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'LblLotes
        '
        Me.LblLotes.AutoSize = True
        Me.LblLotes.BackColor = System.Drawing.Color.Transparent
        Me.LblLotes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblLotes.Location = New System.Drawing.Point(230, 37)
        Me.LblLotes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblLotes.Name = "LblLotes"
        Me.LblLotes.Size = New System.Drawing.Size(51, 14)
        Me.LblLotes.TabIndex = 188
        Me.LblLotes.Text = "Lotes :"
        '
        'CmbLotes
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.CmbLotes.DisplayLayout.Appearance = Appearance1
        Me.CmbLotes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.CmbLotes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbLotes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbLotes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.CmbLotes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbLotes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.CmbLotes.DisplayLayout.MaxColScrollRegions = 1
        Me.CmbLotes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmbLotes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.CmbLotes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.CmbLotes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.CmbLotes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.CmbLotes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.CmbLotes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.CmbLotes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.CmbLotes.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbLotes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.CmbLotes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.CmbLotes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.CmbLotes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.CmbLotes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.CmbLotes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbLotes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.CmbLotes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.CmbLotes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.CmbLotes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.CmbLotes.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CmbLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbLotes.Location = New System.Drawing.Point(289, 32)
        Me.CmbLotes.Name = "CmbLotes"
        Me.CmbLotes.Size = New System.Drawing.Size(111, 24)
        Me.CmbLotes.TabIndex = 187
        '
        'LblPeriodo
        '
        Me.LblPeriodo.AutoSize = True
        Me.LblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.LblPeriodo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.LblPeriodo.Location = New System.Drawing.Point(28, 76)
        Me.LblPeriodo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPeriodo.Name = "LblPeriodo"
        Me.LblPeriodo.Size = New System.Drawing.Size(12, 14)
        Me.LblPeriodo.TabIndex = 186
        Me.LblPeriodo.Text = "-"
        '
        'CmbAnios
        '
        Me.CmbAnios.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbAnios.FormattingEnabled = True
        Me.CmbAnios.Location = New System.Drawing.Point(74, 33)
        Me.CmbAnios.Margin = New System.Windows.Forms.Padding(2)
        Me.CmbAnios.Name = "CmbAnios"
        Me.CmbAnios.Size = New System.Drawing.Size(95, 22)
        Me.CmbAnios.TabIndex = 183
        '
        'NumLote
        '
        Me.NumLote.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumLote.Location = New System.Drawing.Point(289, 33)
        Me.NumLote.Margin = New System.Windows.Forms.Padding(2)
        Me.NumLote.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.NumLote.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumLote.Name = "NumLote"
        Me.NumLote.Size = New System.Drawing.Size(62, 22)
        Me.NumLote.TabIndex = 185
        Me.NumLote.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(28, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Año :"
        '
        'LblSemana
        '
        Me.LblSemana.AutoSize = True
        Me.LblSemana.BackColor = System.Drawing.Color.Transparent
        Me.LblSemana.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblSemana.Location = New System.Drawing.Point(214, 37)
        Me.LblSemana.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSemana.Name = "LblSemana"
        Me.LblSemana.Size = New System.Drawing.Size(67, 14)
        Me.LblSemana.TabIndex = 182
        Me.LblSemana.Text = "Semana :"
        '
        'LblDiaPic
        '
        Me.LblDiaPic.AutoSize = True
        Me.LblDiaPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDiaPic.Font = New System.Drawing.Font("Verdana", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiaPic.ForeColor = System.Drawing.Color.Green
        Me.LblDiaPic.Location = New System.Drawing.Point(1327, 83)
        Me.LblDiaPic.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDiaPic.Name = "LblDiaPic"
        Me.LblDiaPic.Size = New System.Drawing.Size(19, 23)
        Me.LblDiaPic.TabIndex = 239
        Me.LblDiaPic.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(33, 25)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(340, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "REPORTE DE CONDICIÓN CORPORAL"
        '
        'BarraNavegacion
        '
        Me.BarraNavegacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraNavegacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraNavegacion.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraNavegacion.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraNavegacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExportarControlCerdacontrollotespro, Me.BtnCerrar})
        Me.BarraNavegacion.Location = New System.Drawing.Point(0, 194)
        Me.BarraNavegacion.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.BarraNavegacion.Name = "BarraNavegacion"
        Me.BarraNavegacion.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BarraNavegacion.Size = New System.Drawing.Size(699, 38)
        Me.BarraNavegacion.TabIndex = 52
        Me.BarraNavegacion.Text = "Monitoreo"
        '
        'BtnExportarControlCerdacontrollotespro
        '
        Me.BtnExportarControlCerdacontrollotespro.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarControlCerdacontrollotespro.ForeColor = System.Drawing.Color.White
        Me.BtnExportarControlCerdacontrollotespro.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarControlCerdacontrollotespro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarControlCerdacontrollotespro.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarControlCerdacontrollotespro.Name = "BtnExportarControlCerdacontrollotespro"
        Me.BtnExportarControlCerdacontrollotespro.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarControlCerdacontrollotespro.Size = New System.Drawing.Size(92, 28)
        Me.BtnExportarControlCerdacontrollotespro.Text = "Exportar"
        Me.BtnExportarControlCerdacontrollotespro.ToolTipText = "Exportar"
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
        'CmbTipoControl
        '
        Me.CmbTipoControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoControl.FormattingEnabled = True
        Me.CmbTipoControl.Items.AddRange(New Object() {"GESTACION", "MATERNIDAD"})
        Me.CmbTipoControl.Location = New System.Drawing.Point(543, 24)
        Me.CmbTipoControl.Name = "CmbTipoControl"
        Me.CmbTipoControl.Size = New System.Drawing.Size(121, 21)
        Me.CmbTipoControl.TabIndex = 0
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(314, 334)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 42
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 232)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(699, 271)
        Me.dtgListado.TabIndex = 41
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(488, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "Área :"
        '
        'FrmReporteCondicionCorporal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 503)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Contenedor)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReporteCondicionCorporal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE CONDICIÓN CORPORAL"
        Me.Contenedor.ResumeLayout(False)
        Me.Contenedor.PerformLayout()
        Me.FiltrosBusqueda.ResumeLayout(False)
        Me.FiltrosBusqueda.PerformLayout()
        CType(Me.CmbLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumLote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraNavegacion.ResumeLayout(False)
        Me.BarraNavegacion.PerformLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Contenedor As Panel
    Friend WithEvents LblDiaPic As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BarraNavegacion As ToolStrip
    Friend WithEvents BtnExportarControlCerdacontrollotespro As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents FiltrosBusqueda As GroupBox
    Friend WithEvents CmbTipoControl As ComboBox
    Friend WithEvents LblPeriodo As Label
    Friend WithEvents CmbAnios As ComboBox
    Friend WithEvents NumLote As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents LblSemana As Label
    Friend WithEvents LblLotes As Label
    Friend WithEvents CmbLotes As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnBuscar As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
End Class
