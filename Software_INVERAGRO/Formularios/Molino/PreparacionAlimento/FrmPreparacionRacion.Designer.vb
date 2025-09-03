<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPreparacionRacion
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
        Me.components = New System.ComponentModel.Container()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnPrepararRacionMolinoalica = New System.Windows.Forms.ToolStripButton()
        Me.BtnHistoricoPreparacion = New System.Windows.Forms.ToolStripButton()
        Me.btnConsultarPedidosPreparadoMolinoalica = New System.Windows.Forms.ToolStripButton()
        Me.btnHistoricoRacionPreparadaMolinoalica = New System.Windows.Forms.ToolStripButton()
        Me.btnExportarMolinoalica = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListadoPreparacionRacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListadoPreparacionRacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1923, 297)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Location = New System.Drawing.Point(47, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1410, 120)
        Me.GroupBox1.TabIndex = 159
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Búsqueda"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(245, 53)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(358, 28)
        Me.dtpFecha.TabIndex = 177
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(38, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 22)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Seleccione Fecha :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(674, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 22)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "Periodo :"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriodo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.Location = New System.Drawing.Point(787, 56)
        Me.lblPeriodo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(89, 22)
        Me.lblPeriodo.TabIndex = 175
        Me.lblPeriodo.Text = "FECHAS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(42, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(648, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "PREPARACIÓN DE ALIMENTO PARA PLANTELES"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPrepararRacionMolinoalica, Me.BtnHistoricoPreparacion, Me.btnConsultarPedidosPreparadoMolinoalica, Me.btnHistoricoRacionPreparadaMolinoalica, Me.btnExportarMolinoalica, Me.btncerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 257)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1923, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnPrepararRacionMolinoalica
        '
        Me.btnPrepararRacionMolinoalica.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrepararRacionMolinoalica.ForeColor = System.Drawing.Color.White
        Me.btnPrepararRacionMolinoalica.Image = Global.Formularios.My.Resources.Resources.food_and_restaurant
        Me.btnPrepararRacionMolinoalica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrepararRacionMolinoalica.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPrepararRacionMolinoalica.Name = "btnPrepararRacionMolinoalica"
        Me.btnPrepararRacionMolinoalica.Padding = New System.Windows.Forms.Padding(2)
        Me.btnPrepararRacionMolinoalica.Size = New System.Drawing.Size(201, 30)
        Me.btnPrepararRacionMolinoalica.Text = "Preparar Ración"
        Me.btnPrepararRacionMolinoalica.ToolTipText = "Preparar Ración"
        '
        'BtnHistoricoPreparacion
        '
        Me.BtnHistoricoPreparacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHistoricoPreparacion.ForeColor = System.Drawing.Color.White
        Me.BtnHistoricoPreparacion.Image = Global.Formularios.My.Resources.Resources.registro
        Me.BtnHistoricoPreparacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnHistoricoPreparacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnHistoricoPreparacion.Name = "BtnHistoricoPreparacion"
        Me.BtnHistoricoPreparacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnHistoricoPreparacion.Size = New System.Drawing.Size(310, 30)
        Me.BtnHistoricoPreparacion.Text = "Historico de Preparaciones"
        Me.BtnHistoricoPreparacion.ToolTipText = "Despachar Ración"
        '
        'btnConsultarPedidosPreparadoMolinoalica
        '
        Me.btnConsultarPedidosPreparadoMolinoalica.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarPedidosPreparadoMolinoalica.ForeColor = System.Drawing.Color.White
        Me.btnConsultarPedidosPreparadoMolinoalica.Image = Global.Formularios.My.Resources.Resources.forraje
        Me.btnConsultarPedidosPreparadoMolinoalica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConsultarPedidosPreparadoMolinoalica.Margin = New System.Windows.Forms.Padding(5)
        Me.btnConsultarPedidosPreparadoMolinoalica.Name = "btnConsultarPedidosPreparadoMolinoalica"
        Me.btnConsultarPedidosPreparadoMolinoalica.Padding = New System.Windows.Forms.Padding(2)
        Me.btnConsultarPedidosPreparadoMolinoalica.Size = New System.Drawing.Size(240, 30)
        Me.btnConsultarPedidosPreparadoMolinoalica.Text = "Pedidos Preparados"
        Me.btnConsultarPedidosPreparadoMolinoalica.ToolTipText = "Pedidos Preparados"
        '
        'btnHistoricoRacionPreparadaMolinoalica
        '
        Me.btnHistoricoRacionPreparadaMolinoalica.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistoricoRacionPreparadaMolinoalica.ForeColor = System.Drawing.Color.White
        Me.btnHistoricoRacionPreparadaMolinoalica.Image = Global.Formularios.My.Resources.Resources.registro
        Me.btnHistoricoRacionPreparadaMolinoalica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHistoricoRacionPreparadaMolinoalica.Margin = New System.Windows.Forms.Padding(5)
        Me.btnHistoricoRacionPreparadaMolinoalica.Name = "btnHistoricoRacionPreparadaMolinoalica"
        Me.btnHistoricoRacionPreparadaMolinoalica.Padding = New System.Windows.Forms.Padding(2)
        Me.btnHistoricoRacionPreparadaMolinoalica.Size = New System.Drawing.Size(251, 30)
        Me.btnHistoricoRacionPreparadaMolinoalica.Text = "Raciones Preparadas"
        Me.btnHistoricoRacionPreparadaMolinoalica.ToolTipText = "Historico de Preparaciones"
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
        'dtgListadoPreparacionRacion
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.FontData.Name = "Verdana"
        Me.dtgListadoPreparacionRacion.DisplayLayout.Appearance = Appearance1
        Me.dtgListadoPreparacionRacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoPreparacionRacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dtgListadoPreparacionRacion.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListadoPreparacionRacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CellPadding = 0
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.AliceBlue
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.White
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowPreviewAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowSelectorAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Navy
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance14
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dtgListadoPreparacionRacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListadoPreparacionRacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListadoPreparacionRacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListadoPreparacionRacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListadoPreparacionRacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListadoPreparacionRacion.Location = New System.Drawing.Point(0, 297)
        Me.dtgListadoPreparacionRacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListadoPreparacionRacion.Name = "dtgListadoPreparacionRacion"
        Me.dtgListadoPreparacionRacion.Size = New System.Drawing.Size(1923, 488)
        Me.dtgListadoPreparacionRacion.TabIndex = 9
        Me.dtgListadoPreparacionRacion.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Timer1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(895, 514)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 28
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmPreparacionRacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1923, 785)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListadoPreparacionRacion)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmPreparacionRacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PREPARACIÓN DE RACIONES"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListadoPreparacionRacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnPrepararAlimentoMRequeali As ToolStripButton
    Friend WithEvents btnExportarMRequeali As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents dtgListadoPreparacionRacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnConsultarPedidosPreparadoMolinoalica As ToolStripButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnHistoricoRacionPreparadaMolinoalica As ToolStripButton
    Friend WithEvents btnPrepararRacionMolinoalica As ToolStripButton
    Friend WithEvents btnExportarMolinoalica As ToolStripButton
    Friend WithEvents BtnHistoricoPreparacion As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
End Class
