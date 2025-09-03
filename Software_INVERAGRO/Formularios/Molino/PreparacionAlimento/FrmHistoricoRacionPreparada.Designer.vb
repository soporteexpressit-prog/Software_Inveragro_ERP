<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmHistoricoRacionPreparada
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHistoricoRacionPreparada))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrupoMasOpcionesBusqueda = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.dtgListadoInsumoPreparado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnExportarMolinoalica = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListadoInsumoPreparado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.UltraGroupBox1)
        Me.Panel2.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1542, 300)
        Me.Panel2.TabIndex = 9
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Near
        Me.UltraGroupBox1.Controls.Add(Me.btnConsultar)
        Me.UltraGroupBox1.Controls.Add(Me.dtpFechaHasta)
        Me.UltraGroupBox1.Controls.Add(Me.dtpFechaDesde)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.HeaderAppearance = Appearance2
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 102)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1542, 198)
        Me.UltraGroupBox1.TabIndex = 158
        Me.UltraGroupBox1.Text = "FILTRO DE BÚSQUEDA FECHA DE PREPARACIÓN"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(238, 114)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(358, 28)
        Me.dtpFechaHasta.TabIndex = 183
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(238, 66)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(358, 28)
        Me.dtpFechaDesde.TabIndex = 182
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(71, 69)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 22)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Fecha Desde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(77, 117)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 22)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Fecha Hasta:"
        '
        'GrupoMasOpcionesBusqueda
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.Appearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance4.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.ContentAreaAppearance = Appearance4
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label6)
        Me.GrupoMasOpcionesBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrupoMasOpcionesBusqueda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BorderColor = System.Drawing.Color.White
        Appearance5.BorderColor2 = System.Drawing.Color.White
        Appearance5.BorderColor3DBase = System.Drawing.Color.White
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.Name = "Segoe UI"
        Appearance5.FontData.SizeInPoints = 10.0!
        Appearance5.ForeColor = System.Drawing.Color.White
        Me.GrupoMasOpcionesBusqueda.HeaderAppearance = Appearance5
        Me.GrupoMasOpcionesBusqueda.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.GrupoMasOpcionesBusqueda.Location = New System.Drawing.Point(0, 40)
        Me.GrupoMasOpcionesBusqueda.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(1542, 62)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 169
        Me.GrupoMasOpcionesBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(553, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "HISTORICO DE RACIONES PREPARADAS"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportarMolinoalica, Me.btncerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1542, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'dtgListadoInsumoPreparado
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance6.FontData.Name = "Verdana"
        Me.dtgListadoInsumoPreparado.DisplayLayout.Appearance = Appearance6
        Me.dtgListadoInsumoPreparado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoInsumoPreparado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoInsumoPreparado.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoInsumoPreparado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.dtgListadoInsumoPreparado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoInsumoPreparado.DisplayLayout.GroupByBox.Hidden = True
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoInsumoPreparado.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.dtgListadoInsumoPreparado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListadoInsumoPreparado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.Color.White
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.Navy
        Appearance11.ForeColor = System.Drawing.Color.White
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.CellAppearance = Appearance13
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.CellPadding = 0
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.AliceBlue
        Appearance15.BackColor2 = System.Drawing.Color.Silver
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.TextHAlignAsString = "Left"
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.RowAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.White
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.RowPreviewAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.White
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.RowSelectorAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.Navy
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance19
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListadoInsumoPreparado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.dtgListadoInsumoPreparado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListadoInsumoPreparado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListadoInsumoPreparado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListadoInsumoPreparado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListadoInsumoPreparado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListadoInsumoPreparado.Location = New System.Drawing.Point(0, 300)
        Me.dtgListadoInsumoPreparado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListadoInsumoPreparado.Name = "dtgListadoInsumoPreparado"
        Me.dtgListadoInsumoPreparado.Size = New System.Drawing.Size(1542, 699)
        Me.dtgListadoInsumoPreparado.TabIndex = 176
        Me.dtgListadoInsumoPreparado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(739, 601)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 178
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(754, 80)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.btnConsultar.Size = New System.Drawing.Size(138, 62)
        Me.btnConsultar.TabIndex = 184
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'btnExportarMolinoalica
        '
        Me.btnExportarMolinoalica.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarMolinoalica.ForeColor = System.Drawing.Color.White
        Me.btnExportarMolinoalica.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnExportarMolinoalica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportarMolinoalica.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExportarMolinoalica.Name = "btnExportarMolinoalica"
        Me.btnExportarMolinoalica.Padding = New System.Windows.Forms.Padding(2)
        Me.btnExportarMolinoalica.Size = New System.Drawing.Size(125, 30)
        Me.btnExportarMolinoalica.Text = "Exportar"
        Me.btnExportarMolinoalica.ToolTipText = "Exportar"
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
        'FrmHistoricoRacionPreparada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1542, 999)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListadoInsumoPreparado)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHistoricoRacionPreparada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORICO RACIONES PREPARADAS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoMasOpcionesBusqueda.ResumeLayout(False)
        Me.GrupoMasOpcionesBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListadoInsumoPreparado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GrupoMasOpcionesBusqueda As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents btnConsultar As Button
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtgListadoInsumoPreparado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents btnExportarMolinoalica As ToolStripButton
End Class
