<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCostoxKiloDetalleF2
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblCostoVeteBruto = New System.Windows.Forms.Label()
        Me.LblDiasCampana = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblFinChanchilla = New System.Windows.Forms.Label()
        Me.LblInicioChanchilla = New System.Windows.Forms.Label()
        Me.LblFinInseminacion = New System.Windows.Forms.Label()
        Me.LblInicioInseminacion = New System.Windows.Forms.Label()
        Me.LblFinCampana = New System.Windows.Forms.Label()
        Me.LblInicioCampana = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTitle = New System.Windows.Forms.Label()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.BtnExportarprocontrolcerdos = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnDetalleVacGestantes = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblTotalMasVacGestantes = New System.Windows.Forms.Label()
        Me.LblTotalVacGestantes = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(746, 600)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 33
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 395)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1665, 587)
        Me.dtgListado.TabIndex = 32
        Me.dtgListado.Text = "UltraGrid1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.BtnDetalleVacGestantes)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.LblTotalVacGestantes)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.LblTotal)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.LblCostoVeteBruto)
        Me.Panel2.Controls.Add(Me.LblDiasCampana)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.LblFinChanchilla)
        Me.Panel2.Controls.Add(Me.LblInicioChanchilla)
        Me.Panel2.Controls.Add(Me.LblFinInseminacion)
        Me.Panel2.Controls.Add(Me.LblInicioInseminacion)
        Me.Panel2.Controls.Add(Me.LblFinCampana)
        Me.Panel2.Controls.Add(Me.LblInicioCampana)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.LblTitle)
        Me.Panel2.Controls.Add(Me.BarraOpciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1665, 395)
        Me.Panel2.TabIndex = 31
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.BackColor = System.Drawing.Color.GreenYellow
        Me.LblTotal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New System.Drawing.Point(968, 289)
        Me.LblTotal.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(26, 25)
        Me.LblTotal.TabIndex = 217
        Me.LblTotal.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.GreenYellow
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(817, 289)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 25)
        Me.Label11.TabIndex = 216
        Me.Label11.Text = "SUBTOTAL :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.GreenYellow
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(37, 291)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(742, 20)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = "Solo se considera productos de categoría MEDICINA - ACCESORIOS VETERINARIOS "
        '
        'LblCostoVeteBruto
        '
        Me.LblCostoVeteBruto.AutoSize = True
        Me.LblCostoVeteBruto.BackColor = System.Drawing.Color.Transparent
        Me.LblCostoVeteBruto.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCostoVeteBruto.ForeColor = System.Drawing.Color.Black
        Me.LblCostoVeteBruto.Location = New System.Drawing.Point(837, 192)
        Me.LblCostoVeteBruto.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCostoVeteBruto.Name = "LblCostoVeteBruto"
        Me.LblCostoVeteBruto.Size = New System.Drawing.Size(20, 20)
        Me.LblCostoVeteBruto.TabIndex = 211
        Me.LblCostoVeteBruto.Text = "0"
        '
        'LblDiasCampana
        '
        Me.LblDiasCampana.AutoSize = True
        Me.LblDiasCampana.BackColor = System.Drawing.Color.Transparent
        Me.LblDiasCampana.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiasCampana.ForeColor = System.Drawing.Color.Black
        Me.LblDiasCampana.Location = New System.Drawing.Point(304, 192)
        Me.LblDiasCampana.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblDiasCampana.Name = "LblDiasCampana"
        Me.LblDiasCampana.Size = New System.Drawing.Size(20, 20)
        Me.LblDiasCampana.TabIndex = 210
        Me.LblDiasCampana.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(568, 191)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 22)
        Me.Label3.TabIndex = 208
        Me.Label3.Text = "Costo Veterinario Bruto :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(162, 191)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 22)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "N° Paridas :"
        '
        'LblFinChanchilla
        '
        Me.LblFinChanchilla.AutoSize = True
        Me.LblFinChanchilla.BackColor = System.Drawing.Color.Transparent
        Me.LblFinChanchilla.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFinChanchilla.ForeColor = System.Drawing.Color.Black
        Me.LblFinChanchilla.Location = New System.Drawing.Point(837, 148)
        Me.LblFinChanchilla.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFinChanchilla.Name = "LblFinChanchilla"
        Me.LblFinChanchilla.Size = New System.Drawing.Size(73, 20)
        Me.LblFinChanchilla.TabIndex = 206
        Me.LblFinChanchilla.Text = "- / - / -"
        '
        'LblInicioChanchilla
        '
        Me.LblInicioChanchilla.AutoSize = True
        Me.LblInicioChanchilla.BackColor = System.Drawing.Color.Yellow
        Me.LblInicioChanchilla.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInicioChanchilla.ForeColor = System.Drawing.Color.Black
        Me.LblInicioChanchilla.Location = New System.Drawing.Point(837, 111)
        Me.LblInicioChanchilla.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblInicioChanchilla.Name = "LblInicioChanchilla"
        Me.LblInicioChanchilla.Size = New System.Drawing.Size(73, 20)
        Me.LblInicioChanchilla.TabIndex = 205
        Me.LblInicioChanchilla.Text = "- / - / -"
        '
        'LblFinInseminacion
        '
        Me.LblFinInseminacion.AutoSize = True
        Me.LblFinInseminacion.BackColor = System.Drawing.Color.Yellow
        Me.LblFinInseminacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFinInseminacion.ForeColor = System.Drawing.Color.Black
        Me.LblFinInseminacion.Location = New System.Drawing.Point(1320, 148)
        Me.LblFinInseminacion.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFinInseminacion.Name = "LblFinInseminacion"
        Me.LblFinInseminacion.Size = New System.Drawing.Size(73, 20)
        Me.LblFinInseminacion.TabIndex = 204
        Me.LblFinInseminacion.Text = "- / - / -"
        '
        'LblInicioInseminacion
        '
        Me.LblInicioInseminacion.AutoSize = True
        Me.LblInicioInseminacion.BackColor = System.Drawing.Color.Transparent
        Me.LblInicioInseminacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInicioInseminacion.ForeColor = System.Drawing.Color.Black
        Me.LblInicioInseminacion.Location = New System.Drawing.Point(1320, 111)
        Me.LblInicioInseminacion.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblInicioInseminacion.Name = "LblInicioInseminacion"
        Me.LblInicioInseminacion.Size = New System.Drawing.Size(73, 20)
        Me.LblInicioInseminacion.TabIndex = 203
        Me.LblInicioInseminacion.Text = "- / - / -"
        '
        'LblFinCampana
        '
        Me.LblFinCampana.AutoSize = True
        Me.LblFinCampana.BackColor = System.Drawing.Color.Transparent
        Me.LblFinCampana.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFinCampana.ForeColor = System.Drawing.Color.Black
        Me.LblFinCampana.Location = New System.Drawing.Point(304, 148)
        Me.LblFinCampana.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFinCampana.Name = "LblFinCampana"
        Me.LblFinCampana.Size = New System.Drawing.Size(73, 20)
        Me.LblFinCampana.TabIndex = 202
        Me.LblFinCampana.Text = "- / - / -"
        '
        'LblInicioCampana
        '
        Me.LblInicioCampana.AutoSize = True
        Me.LblInicioCampana.BackColor = System.Drawing.Color.Transparent
        Me.LblInicioCampana.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInicioCampana.ForeColor = System.Drawing.Color.Black
        Me.LblInicioCampana.Location = New System.Drawing.Point(304, 111)
        Me.LblInicioCampana.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblInicioCampana.Name = "LblInicioCampana"
        Me.LblInicioCampana.Size = New System.Drawing.Size(73, 20)
        Me.LblInicioCampana.TabIndex = 201
        Me.LblInicioCampana.Text = "- / - / -"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(663, 146)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(165, 22)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "Fin Chanchilla :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(638, 109)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(192, 22)
        Me.Label10.TabIndex = 199
        Me.Label10.Text = "Inicio Chanchilla :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1116, 146)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(198, 22)
        Me.Label7.TabIndex = 198
        Me.Label7.Text = "Fin Inseminación :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(1090, 109)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(225, 22)
        Me.Label8.TabIndex = 197
        Me.Label8.Text = "Inicio Inseminación :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(141, 146)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 22)
        Me.Label4.TabIndex = 196
        Me.Label4.Text = "Fin Campaña :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(116, 109)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 22)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = "Inicio Campaña :"
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.LblTitle.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LblTitle.Location = New System.Drawing.Point(32, 31)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(609, 29)
        Me.LblTitle.TabIndex = 128
        Me.LblTitle.Text = "Reporte detallado (GASTOS VETERINARIOS)"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExportarprocontrolcerdos, Me.BtnCerrar})
        Me.BarraOpciones.Location = New System.Drawing.Point(0, 355)
        Me.BarraOpciones.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.BarraOpciones.Size = New System.Drawing.Size(1665, 40)
        Me.BarraOpciones.TabIndex = 52
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'BtnExportarprocontrolcerdos
        '
        Me.BtnExportarprocontrolcerdos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarprocontrolcerdos.ForeColor = System.Drawing.Color.White
        Me.BtnExportarprocontrolcerdos.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarprocontrolcerdos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarprocontrolcerdos.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarprocontrolcerdos.Name = "BtnExportarprocontrolcerdos"
        Me.BtnExportarprocontrolcerdos.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarprocontrolcerdos.Size = New System.Drawing.Size(125, 30)
        Me.BtnExportarprocontrolcerdos.Text = "Exportar"
        Me.BtnExportarprocontrolcerdos.ToolTipText = "Exportar"
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
        'BtnDetalleVacGestantes
        '
        Me.BtnDetalleVacGestantes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDetalleVacGestantes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDetalleVacGestantes.Image = Global.Formularios.My.Resources.Resources.buscar16px
        Me.BtnDetalleVacGestantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDetalleVacGestantes.Location = New System.Drawing.Point(1220, 191)
        Me.BtnDetalleVacGestantes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnDetalleVacGestantes.Name = "BtnDetalleVacGestantes"
        Me.BtnDetalleVacGestantes.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.BtnDetalleVacGestantes.Size = New System.Drawing.Size(173, 48)
        Me.BtnDetalleVacGestantes.TabIndex = 250
        Me.BtnDetalleVacGestantes.Tag = "Muestra Motivos de Mortalidad más Frecuentes"
        Me.BtnDetalleVacGestantes.Text = "Vac. Gestantes"
        Me.BtnDetalleVacGestantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDetalleVacGestantes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.LblTotalMasVacGestantes)
        Me.GroupBox1.Location = New System.Drawing.Point(1425, 251)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 78)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(19, 30)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 25)
        Me.Label13.TabIndex = 240
        Me.Label13.Text = "TOTAL :"
        '
        'LblTotalMasVacGestantes
        '
        Me.LblTotalMasVacGestantes.AutoSize = True
        Me.LblTotalMasVacGestantes.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalMasVacGestantes.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMasVacGestantes.ForeColor = System.Drawing.Color.Black
        Me.LblTotalMasVacGestantes.Location = New System.Drawing.Point(133, 30)
        Me.LblTotalMasVacGestantes.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalMasVacGestantes.Name = "LblTotalMasVacGestantes"
        Me.LblTotalMasVacGestantes.Size = New System.Drawing.Size(26, 25)
        Me.LblTotalMasVacGestantes.TabIndex = 241
        Me.LblTotalMasVacGestantes.Text = "0"
        '
        'LblTotalVacGestantes
        '
        Me.LblTotalVacGestantes.AutoSize = True
        Me.LblTotalVacGestantes.BackColor = System.Drawing.Color.DarkOrange
        Me.LblTotalVacGestantes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalVacGestantes.ForeColor = System.Drawing.Color.White
        Me.LblTotalVacGestantes.Location = New System.Drawing.Point(1314, 290)
        Me.LblTotalVacGestantes.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalVacGestantes.Name = "LblTotalVacGestantes"
        Me.LblTotalVacGestantes.Size = New System.Drawing.Size(23, 22)
        Me.LblTotalVacGestantes.TabIndex = 248
        Me.LblTotalVacGestantes.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.DarkOrange
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1113, 290)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 22)
        Me.Label5.TabIndex = 247
        Me.Label5.Text = "VAC. GESTANTES :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(1082, 289)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 25)
        Me.Label15.TabIndex = 251
        Me.Label15.Text = "+"
        '
        'FrmRptCostoxKiloDetalleF2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1665, 982)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmRptCostoxKiloDetalleF2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DETALLADO"
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblCostoVeteBruto As Label
    Friend WithEvents LblDiasCampana As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblFinChanchilla As Label
    Friend WithEvents LblInicioChanchilla As Label
    Friend WithEvents LblFinInseminacion As Label
    Friend WithEvents LblInicioInseminacion As Label
    Friend WithEvents LblFinCampana As Label
    Friend WithEvents LblInicioCampana As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTitle As Label
    Friend WithEvents BarraOpciones As ToolStrip
    Friend WithEvents BtnExportarprocontrolcerdos As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Label6 As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnDetalleVacGestantes As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents LblTotalMasVacGestantes As Label
    Friend WithEvents LblTotalVacGestantes As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label15 As Label
End Class
