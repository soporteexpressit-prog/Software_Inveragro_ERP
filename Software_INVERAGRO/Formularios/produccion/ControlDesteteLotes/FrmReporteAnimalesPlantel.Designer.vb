<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteAnimalesPlantel
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
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnExportar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblConsumoAlimentoTotalCampaña = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblAproxVentaSemana = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCampaña = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblPesoTotalVentaConsDona = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblTotalConsDona = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LblPesoTotalConsDona = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblConversionAlimenticia = New System.Windows.Forms.Label()
        Me.GananciaDiariaPeso = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PorcentajeEmergenciaCampaña = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblRetorno = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblIngreso = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblEmergencia = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblEdadPromedioLote = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblPromedioPesoVenta = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblPesoVenta = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblVendidos = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PorcentajeMortalidadCampana = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTotalMortalidad = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RtnMortalidad = New System.Windows.Forms.RadioButton()
        Me.RtnGeneral = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblTotalAnimales = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 275)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1283, 382)
        Me.dtgListado.TabIndex = 180
        Me.dtgListado.Text = "UltraGrid1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExportar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1283, 38)
        Me.ToolStrip1.TabIndex = 179
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnExportar
        '
        Me.BtnExportar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportar.ForeColor = System.Drawing.Color.White
        Me.BtnExportar.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportar.Size = New System.Drawing.Size(92, 28)
        Me.BtnExportar.Text = "Exportar"
        Me.BtnExportar.ToolTipText = "Exportar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Size = New System.Drawing.Size(66, 28)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Editar"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LblConsumoAlimentoTotalCampaña)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.LblAproxVentaSemana)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.LblCampaña)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LblTotalAnimales)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 38)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1283, 237)
        Me.Panel2.TabIndex = 181
        '
        'LblConsumoAlimentoTotalCampaña
        '
        Me.LblConsumoAlimentoTotalCampaña.AutoSize = True
        Me.LblConsumoAlimentoTotalCampaña.BackColor = System.Drawing.Color.Transparent
        Me.LblConsumoAlimentoTotalCampaña.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsumoAlimentoTotalCampaña.ForeColor = System.Drawing.Color.Green
        Me.LblConsumoAlimentoTotalCampaña.Location = New System.Drawing.Point(318, 202)
        Me.LblConsumoAlimentoTotalCampaña.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblConsumoAlimentoTotalCampaña.Name = "LblConsumoAlimentoTotalCampaña"
        Me.LblConsumoAlimentoTotalCampaña.Size = New System.Drawing.Size(16, 14)
        Me.LblConsumoAlimentoTotalCampaña.TabIndex = 258
        Me.LblConsumoAlimentoTotalCampaña.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(21, 202)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(291, 14)
        Me.Label17.TabIndex = 258
        Me.Label17.Text = "Consumo Alimento Total de la Campaña (kg):"
        '
        'LblAproxVentaSemana
        '
        Me.LblAproxVentaSemana.AutoSize = True
        Me.LblAproxVentaSemana.BackColor = System.Drawing.Color.Transparent
        Me.LblAproxVentaSemana.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAproxVentaSemana.ForeColor = System.Drawing.Color.Black
        Me.LblAproxVentaSemana.Location = New System.Drawing.Point(1080, 20)
        Me.LblAproxVentaSemana.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAproxVentaSemana.Name = "LblAproxVentaSemana"
        Me.LblAproxVentaSemana.Size = New System.Drawing.Size(19, 18)
        Me.LblAproxVentaSemana.TabIndex = 239
        Me.LblAproxVentaSemana.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(779, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 18)
        Me.Label4.TabIndex = 238
        Me.Label4.Text = "CANT. APROX. VENTAS X SEMANA :"
        '
        'LblCampaña
        '
        Me.LblCampaña.AutoSize = True
        Me.LblCampaña.BackColor = System.Drawing.Color.Transparent
        Me.LblCampaña.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCampaña.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCampaña.Location = New System.Drawing.Point(31, 20)
        Me.LblCampaña.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCampaña.Name = "LblCampaña"
        Me.LblCampaña.Size = New System.Drawing.Size(16, 18)
        Me.LblCampaña.TabIndex = 237
        Me.LblCampaña.Text = "-"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblPesoTotalVentaConsDona)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.LblTotalConsDona)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.LblPesoTotalConsDona)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.LblConversionAlimenticia)
        Me.GroupBox2.Controls.Add(Me.GananciaDiariaPeso)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.PorcentajeEmergenciaCampaña)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.LblRetorno)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.LblIngreso)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.LblEmergencia)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.LblEdadPromedioLote)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.LblPromedioPesoVenta)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.LblPesoVenta)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.LblVendidos)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.PorcentajeMortalidadCampana)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LblTotalMortalidad)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 53)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(1340, 127)
        Me.GroupBox2.TabIndex = 232
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información"
        '
        'LblPesoTotalVentaConsDona
        '
        Me.LblPesoTotalVentaConsDona.AutoSize = True
        Me.LblPesoTotalVentaConsDona.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoTotalVentaConsDona.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoTotalVentaConsDona.ForeColor = System.Drawing.Color.Green
        Me.LblPesoTotalVentaConsDona.Location = New System.Drawing.Point(1222, 95)
        Me.LblPesoTotalVentaConsDona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPesoTotalVentaConsDona.Name = "LblPesoTotalVentaConsDona"
        Me.LblPesoTotalVentaConsDona.Size = New System.Drawing.Size(16, 14)
        Me.LblPesoTotalVentaConsDona.TabIndex = 257
        Me.LblPesoTotalVentaConsDona.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(1105, 95)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 14)
        Me.Label14.TabIndex = 256
        Me.Label14.Text = "Peso Total Salida:"
        '
        'LblTotalConsDona
        '
        Me.LblTotalConsDona.AutoSize = True
        Me.LblTotalConsDona.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalConsDona.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalConsDona.ForeColor = System.Drawing.Color.Green
        Me.LblTotalConsDona.Location = New System.Drawing.Point(1222, 59)
        Me.LblTotalConsDona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalConsDona.Name = "LblTotalConsDona"
        Me.LblTotalConsDona.Size = New System.Drawing.Size(16, 14)
        Me.LblTotalConsDona.TabIndex = 255
        Me.LblTotalConsDona.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(1099, 59)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(123, 14)
        Me.Label18.TabIndex = 254
        Me.Label18.Text = "Total Cons. Dona.:"
        '
        'LblPesoTotalConsDona
        '
        Me.LblPesoTotalConsDona.AutoSize = True
        Me.LblPesoTotalConsDona.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoTotalConsDona.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoTotalConsDona.ForeColor = System.Drawing.Color.Green
        Me.LblPesoTotalConsDona.Location = New System.Drawing.Point(1222, 24)
        Me.LblPesoTotalConsDona.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPesoTotalConsDona.Name = "LblPesoTotalConsDona"
        Me.LblPesoTotalConsDona.Size = New System.Drawing.Size(16, 14)
        Me.LblPesoTotalConsDona.TabIndex = 253
        Me.LblPesoTotalConsDona.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(1038, 24)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(187, 14)
        Me.Label16.TabIndex = 252
        Me.Label16.Text = "Peso Total Cons. Dona. (kg):"
        '
        'LblConversionAlimenticia
        '
        Me.LblConversionAlimenticia.AutoSize = True
        Me.LblConversionAlimenticia.BackColor = System.Drawing.Color.Transparent
        Me.LblConversionAlimenticia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConversionAlimenticia.ForeColor = System.Drawing.Color.Green
        Me.LblConversionAlimenticia.Location = New System.Drawing.Point(935, 24)
        Me.LblConversionAlimenticia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblConversionAlimenticia.Name = "LblConversionAlimenticia"
        Me.LblConversionAlimenticia.Size = New System.Drawing.Size(16, 14)
        Me.LblConversionAlimenticia.TabIndex = 251
        Me.LblConversionAlimenticia.Text = "0"
        '
        'GananciaDiariaPeso
        '
        Me.GananciaDiariaPeso.AutoSize = True
        Me.GananciaDiariaPeso.BackColor = System.Drawing.Color.Transparent
        Me.GananciaDiariaPeso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GananciaDiariaPeso.ForeColor = System.Drawing.Color.Green
        Me.GananciaDiariaPeso.Location = New System.Drawing.Point(935, 59)
        Me.GananciaDiariaPeso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.GananciaDiariaPeso.Name = "GananciaDiariaPeso"
        Me.GananciaDiariaPeso.Size = New System.Drawing.Size(16, 14)
        Me.GananciaDiariaPeso.TabIndex = 250
        Me.GananciaDiariaPeso.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(793, 59)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(145, 14)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Ganancia Diaria Peso:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(783, 24)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 14)
        Me.Label12.TabIndex = 248
        Me.Label12.Text = "Conversión Alimenticia:"
        '
        'PorcentajeEmergenciaCampaña
        '
        Me.PorcentajeEmergenciaCampaña.AutoSize = True
        Me.PorcentajeEmergenciaCampaña.BackColor = System.Drawing.Color.Transparent
        Me.PorcentajeEmergenciaCampaña.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PorcentajeEmergenciaCampaña.ForeColor = System.Drawing.Color.Green
        Me.PorcentajeEmergenciaCampaña.Location = New System.Drawing.Point(666, 59)
        Me.PorcentajeEmergenciaCampaña.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PorcentajeEmergenciaCampaña.Name = "PorcentajeEmergenciaCampaña"
        Me.PorcentajeEmergenciaCampaña.Size = New System.Drawing.Size(16, 14)
        Me.PorcentajeEmergenciaCampaña.TabIndex = 247
        Me.PorcentajeEmergenciaCampaña.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(529, 59)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 14)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "% Emergencia Total:"
        '
        'LblRetorno
        '
        Me.LblRetorno.AutoSize = True
        Me.LblRetorno.BackColor = System.Drawing.Color.Transparent
        Me.LblRetorno.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRetorno.ForeColor = System.Drawing.Color.Black
        Me.LblRetorno.Location = New System.Drawing.Point(109, 59)
        Me.LblRetorno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRetorno.Name = "LblRetorno"
        Me.LblRetorno.Size = New System.Drawing.Size(16, 14)
        Me.LblRetorno.TabIndex = 244
        Me.LblRetorno.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(13, 59)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 14)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "Total Retorno:"
        '
        'LblIngreso
        '
        Me.LblIngreso.AutoSize = True
        Me.LblIngreso.BackColor = System.Drawing.Color.Transparent
        Me.LblIngreso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIngreso.ForeColor = System.Drawing.Color.Black
        Me.LblIngreso.Location = New System.Drawing.Point(109, 24)
        Me.LblIngreso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblIngreso.Name = "LblIngreso"
        Me.LblIngreso.Size = New System.Drawing.Size(16, 14)
        Me.LblIngreso.TabIndex = 238
        Me.LblIngreso.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(15, 24)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 14)
        Me.Label10.TabIndex = 243
        Me.Label10.Text = "Total Ingreso:"
        '
        'LblEmergencia
        '
        Me.LblEmergencia.AutoSize = True
        Me.LblEmergencia.BackColor = System.Drawing.Color.Transparent
        Me.LblEmergencia.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmergencia.ForeColor = System.Drawing.Color.Green
        Me.LblEmergencia.Location = New System.Drawing.Point(666, 24)
        Me.LblEmergencia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEmergencia.Name = "LblEmergencia"
        Me.LblEmergencia.Size = New System.Drawing.Size(16, 14)
        Me.LblEmergencia.TabIndex = 242
        Me.LblEmergencia.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(579, 24)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 14)
        Me.Label15.TabIndex = 241
        Me.Label15.Text = "Emergencia:"
        '
        'LblEdadPromedioLote
        '
        Me.LblEdadPromedioLote.AutoSize = True
        Me.LblEdadPromedioLote.BackColor = System.Drawing.Color.Transparent
        Me.LblEdadPromedioLote.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEdadPromedioLote.ForeColor = System.Drawing.Color.Green
        Me.LblEdadPromedioLote.Location = New System.Drawing.Point(935, 95)
        Me.LblEdadPromedioLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEdadPromedioLote.Name = "LblEdadPromedioLote"
        Me.LblEdadPromedioLote.Size = New System.Drawing.Size(16, 14)
        Me.LblEdadPromedioLote.TabIndex = 240
        Me.LblEdadPromedioLote.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(791, 95)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(147, 14)
        Me.Label13.TabIndex = 239
        Me.Label13.Text = "Edad Promedio Venta:"
        '
        'LblPromedioPesoVenta
        '
        Me.LblPromedioPesoVenta.AutoSize = True
        Me.LblPromedioPesoVenta.BackColor = System.Drawing.Color.Transparent
        Me.LblPromedioPesoVenta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromedioPesoVenta.ForeColor = System.Drawing.Color.Green
        Me.LblPromedioPesoVenta.Location = New System.Drawing.Point(667, 95)
        Me.LblPromedioPesoVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPromedioPesoVenta.Name = "LblPromedioPesoVenta"
        Me.LblPromedioPesoVenta.Size = New System.Drawing.Size(16, 14)
        Me.LblPromedioPesoVenta.TabIndex = 238
        Me.LblPromedioPesoVenta.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(493, 95)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(175, 14)
        Me.Label11.TabIndex = 237
        Me.Label11.Text = "Peso Promedio Venta (kg):"
        '
        'LblPesoVenta
        '
        Me.LblPesoVenta.AutoSize = True
        Me.LblPesoVenta.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoVenta.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoVenta.ForeColor = System.Drawing.Color.Green
        Me.LblPesoVenta.Location = New System.Drawing.Point(377, 95)
        Me.LblPesoVenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPesoVenta.Name = "LblPesoVenta"
        Me.LblPesoVenta.Size = New System.Drawing.Size(16, 14)
        Me.LblPesoVenta.TabIndex = 236
        Me.LblPesoVenta.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(233, 95)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 14)
        Me.Label9.TabIndex = 235
        Me.Label9.Text = "Peso Total Venta (kg):"
        '
        'LblVendidos
        '
        Me.LblVendidos.AutoSize = True
        Me.LblVendidos.BackColor = System.Drawing.Color.Transparent
        Me.LblVendidos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendidos.ForeColor = System.Drawing.Color.Green
        Me.LblVendidos.Location = New System.Drawing.Point(109, 95)
        Me.LblVendidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblVendidos.Name = "LblVendidos"
        Me.LblVendidos.Size = New System.Drawing.Size(16, 14)
        Me.LblVendidos.TabIndex = 234
        Me.LblVendidos.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(41, 95)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 14)
        Me.Label8.TabIndex = 233
        Me.Label8.Text = "Vendidos:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(249, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 14)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "% Mortalidad Total:"
        '
        'PorcentajeMortalidadCampana
        '
        Me.PorcentajeMortalidadCampana.AutoSize = True
        Me.PorcentajeMortalidadCampana.BackColor = System.Drawing.Color.Transparent
        Me.PorcentajeMortalidadCampana.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PorcentajeMortalidadCampana.ForeColor = System.Drawing.Color.Red
        Me.PorcentajeMortalidadCampana.Location = New System.Drawing.Point(377, 59)
        Me.PorcentajeMortalidadCampana.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PorcentajeMortalidadCampana.Name = "PorcentajeMortalidadCampana"
        Me.PorcentajeMortalidadCampana.Size = New System.Drawing.Size(16, 14)
        Me.PorcentajeMortalidadCampana.TabIndex = 232
        Me.PorcentajeMortalidadCampana.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(271, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 14)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "Motalidad Total:"
        '
        'LblTotalMortalidad
        '
        Me.LblTotalMortalidad.AutoSize = True
        Me.LblTotalMortalidad.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalMortalidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMortalidad.ForeColor = System.Drawing.Color.Red
        Me.LblTotalMortalidad.Location = New System.Drawing.Point(377, 24)
        Me.LblTotalMortalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalMortalidad.Name = "LblTotalMortalidad"
        Me.LblTotalMortalidad.Size = New System.Drawing.Size(16, 14)
        Me.LblTotalMortalidad.TabIndex = 228
        Me.LblTotalMortalidad.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RtnMortalidad)
        Me.GroupBox1.Controls.Add(Me.RtnGeneral)
        Me.GroupBox1.Location = New System.Drawing.Point(1359, 53)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(111, 127)
        Me.GroupBox1.TabIndex = 231
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Búsqueda"
        '
        'RtnMortalidad
        '
        Me.RtnMortalidad.AutoSize = True
        Me.RtnMortalidad.Location = New System.Drawing.Point(23, 81)
        Me.RtnMortalidad.Margin = New System.Windows.Forms.Padding(2)
        Me.RtnMortalidad.Name = "RtnMortalidad"
        Me.RtnMortalidad.Size = New System.Drawing.Size(74, 17)
        Me.RtnMortalidad.TabIndex = 2
        Me.RtnMortalidad.TabStop = True
        Me.RtnMortalidad.Text = "Mortalidad"
        Me.RtnMortalidad.UseVisualStyleBackColor = True
        '
        'RtnGeneral
        '
        Me.RtnGeneral.AutoSize = True
        Me.RtnGeneral.Location = New System.Drawing.Point(23, 34)
        Me.RtnGeneral.Margin = New System.Windows.Forms.Padding(2)
        Me.RtnGeneral.Name = "RtnGeneral"
        Me.RtnGeneral.Size = New System.Drawing.Size(62, 17)
        Me.RtnGeneral.TabIndex = 0
        Me.RtnGeneral.TabStop = True
        Me.RtnGeneral.Text = "General"
        Me.RtnGeneral.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(395, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 18)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "DISPONIBLES PARA VENTA :"
        '
        'LblTotalAnimales
        '
        Me.LblTotalAnimales.AutoSize = True
        Me.LblTotalAnimales.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalAnimales.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAnimales.ForeColor = System.Drawing.Color.Black
        Me.LblTotalAnimales.Location = New System.Drawing.Point(640, 20)
        Me.LblTotalAnimales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalAnimales.Name = "LblTotalAnimales"
        Me.LblTotalAnimales.Size = New System.Drawing.Size(19, 18)
        Me.LblTotalAnimales.TabIndex = 230
        Me.LblTotalAnimales.Text = "0"
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(716, 379)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 182
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmReporteAnimalesPlantel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 657)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReporteAnimalesPlantel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DE LOTES POR PLANTEL"
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnSalir As ToolStripButton
    Friend WithEvents BtnExportar As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RtnGeneral As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents LblTotalMortalidad As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblTotalAnimales As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PorcentajeMortalidadCampana As Label
    Friend WithEvents LblVendidos As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblPesoVenta As Label
    Friend WithEvents LblPromedioPesoVenta As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblEdadPromedioLote As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblCampaña As Label
    Friend WithEvents LblEmergencia As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents LblIngreso As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblRetorno As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblAproxVentaSemana As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RtnMortalidad As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents PorcentajeEmergenciaCampaña As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblConversionAlimenticia As Label
    Friend WithEvents GananciaDiariaPeso As Label
    Friend WithEvents LblPesoTotalConsDona As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LblTotalConsDona As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents LblPesoTotalVentaConsDona As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LblConsumoAlimentoTotalCampaña As Label
    Friend WithEvents Label17 As Label
End Class
