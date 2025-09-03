<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedidoPreparado
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GrupoMasOpcionesBusqueda = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListadoPreparacionRacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.btnExportarMolinoalica = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListadoPreparacionRacion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1212, 270)
        Me.Panel2.TabIndex = 7
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.dtpFecha)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.lblPeriodo)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox1.HeaderAppearance = Appearance2
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 103)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1212, 167)
        Me.UltraGroupBox1.TabIndex = 159
        Me.UltraGroupBox1.Text = "FILTRO DE BÚSQUEDA"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Location = New System.Drawing.Point(263, 80)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(358, 28)
        Me.dtpFecha.TabIndex = 181
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(56, 83)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 22)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Seleccione Fecha :"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.BackColor = System.Drawing.Color.Transparent
        Me.lblPeriodo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.Location = New System.Drawing.Point(804, 83)
        Me.lblPeriodo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(89, 22)
        Me.lblPeriodo.TabIndex = 179
        Me.lblPeriodo.Text = "FECHAS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(692, 83)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 22)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "Periodo :"
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
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(1212, 63)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 163
        Me.GrupoMasOpcionesBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(640, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "REQUERIMIENTOS PREPARADOS POR SEMANA"
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
        Me.ToolStrip1.Size = New System.Drawing.Size(1212, 40)
        Me.ToolStrip1.TabIndex = 164
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance6.FontData.Name = "Verdana"
        Me.dtgListadoPreparacionRacion.DisplayLayout.Appearance = Appearance6
        Me.dtgListadoPreparacionRacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoPreparacionRacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.Hidden = True
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoPreparacionRacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.dtgListadoPreparacionRacion.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListadoPreparacionRacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.Color.White
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.Navy
        Appearance11.ForeColor = System.Drawing.Color.White
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CellAppearance = Appearance13
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.CellPadding = 0
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.AliceBlue
        Appearance15.BackColor2 = System.Drawing.Color.Silver
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.TextHAlignAsString = "Left"
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.White
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowPreviewAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.White
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowSelectorAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.Navy
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance19
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListadoPreparacionRacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.dtgListadoPreparacionRacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListadoPreparacionRacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListadoPreparacionRacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListadoPreparacionRacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListadoPreparacionRacion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListadoPreparacionRacion.Location = New System.Drawing.Point(0, 270)
        Me.dtgListadoPreparacionRacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListadoPreparacionRacion.Name = "dtgListadoPreparacionRacion"
        Me.dtgListadoPreparacionRacion.Size = New System.Drawing.Size(1212, 658)
        Me.dtgListadoPreparacionRacion.TabIndex = 8
        Me.dtgListadoPreparacionRacion.Text = "UltraGrid1"
        '
        'Timer1
        '
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(554, 533)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 29
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
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
        'FrmPedidoPreparado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 928)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListadoPreparacionRacion)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPedidoPreparado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REQUERIMIENTOS PREPARADOS"
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
        CType(Me.dtgListadoPreparacionRacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GrupoMasOpcionesBusqueda As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtgListadoPreparacionRacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents btnExportarMolinoalica As ToolStripButton
End Class
