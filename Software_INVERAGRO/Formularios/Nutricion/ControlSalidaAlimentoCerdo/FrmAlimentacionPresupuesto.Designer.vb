<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAlimentacionPresupuesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlimentacionPresupuesto))
        Me.LblDiaPic = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbLotes = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.CmbAnios = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.LblEdad = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDescripcionAlimento = New System.Windows.Forms.TextBox()
        Me.btnBuscarInsumos = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtObjetivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPesoDestete = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtPresentacionSacos = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtTotalAlimento = New System.Windows.Forms.TextBox()
        Me.LblResultado = New System.Windows.Forms.TextBox()
        Me.TxtConsumoAlimento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblFechaNacimiento = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblTotalAnimales = New System.Windows.Forms.Label()
        Me.TxtGrupo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BtnSeleccioneGrupo = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BtnDividirGrupos = New System.Windows.Forms.Button()
        Me.btnIngresarGrupo = New System.Windows.Forms.Button()
        CType(Me.CmbLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblDiaPic
        '
        Me.LblDiaPic.AutoSize = True
        Me.LblDiaPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDiaPic.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiaPic.ForeColor = System.Drawing.Color.Green
        Me.LblDiaPic.Location = New System.Drawing.Point(26, 68)
        Me.LblDiaPic.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblDiaPic.Name = "LblDiaPic"
        Me.LblDiaPic.Size = New System.Drawing.Size(385, 25)
        Me.LblDiaPic.TabIndex = 249
        Me.LblDiaPic.Text = "ALIMENTACIÓN Y PRESUPUESTO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(300, 132)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 22)
        Me.Label5.TabIndex = 248
        Me.Label5.Text = "Lotes :"
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
        Me.CmbLotes.Location = New System.Drawing.Point(381, 129)
        Me.CmbLotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmbLotes.Name = "CmbLotes"
        Me.CmbLotes.Size = New System.Drawing.Size(142, 29)
        Me.CmbLotes.TabIndex = 247
        '
        'CmbAnios
        '
        Me.CmbAnios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbAnios.FormattingEnabled = True
        Me.CmbAnios.Location = New System.Drawing.Point(120, 127)
        Me.CmbAnios.Name = "CmbAnios"
        Me.CmbAnios.Size = New System.Drawing.Size(138, 33)
        Me.CmbAnios.TabIndex = 246
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(54, 132)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 22)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Año :"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(797, 40)
        Me.ToolStrip1.TabIndex = 251
        Me.ToolStrip1.Text = "Monitoreo"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar2
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.BtnGuardar.Text = "Guardar"
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
        'LblEdad
        '
        Me.LblEdad.AutoSize = True
        Me.LblEdad.BackColor = System.Drawing.Color.Transparent
        Me.LblEdad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEdad.ForeColor = System.Drawing.Color.Black
        Me.LblEdad.Location = New System.Drawing.Point(690, 132)
        Me.LblEdad.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblEdad.Name = "LblEdad"
        Me.LblEdad.Size = New System.Drawing.Size(21, 22)
        Me.LblEdad.TabIndex = 253
        Me.LblEdad.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(608, 132)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 22)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = "Edad :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDescripcionAlimento)
        Me.GroupBox1.Controls.Add(Me.btnBuscarInsumos)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 309)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(727, 106)
        Me.GroupBox1.TabIndex = 254
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del Alimento"
        '
        'txtDescripcionAlimento
        '
        Me.txtDescripcionAlimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionAlimento.Location = New System.Drawing.Point(129, 45)
        Me.txtDescripcionAlimento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDescripcionAlimento.MaxLength = 50
        Me.txtDescripcionAlimento.Name = "txtDescripcionAlimento"
        Me.txtDescripcionAlimento.Size = New System.Drawing.Size(248, 28)
        Me.txtDescripcionAlimento.TabIndex = 173
        '
        'btnBuscarInsumos
        '
        Me.btnBuscarInsumos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarInsumos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarInsumos.Image = CType(resources.GetObject("btnBuscarInsumos.Image"), System.Drawing.Image)
        Me.btnBuscarInsumos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarInsumos.Location = New System.Drawing.Point(385, 37)
        Me.btnBuscarInsumos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscarInsumos.Name = "btnBuscarInsumos"
        Me.btnBuscarInsumos.Size = New System.Drawing.Size(48, 45)
        Me.btnBuscarInsumos.TabIndex = 171
        Me.btnBuscarInsumos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarInsumos.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(34, 48)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 22)
        Me.Label8.TabIndex = 172
        Me.Label8.Text = "Ración :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(64, 465)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 22)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Objetivo :"
        '
        'TxtObjetivo
        '
        Me.TxtObjetivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObjetivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObjetivo.Location = New System.Drawing.Point(174, 462)
        Me.TxtObjetivo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtObjetivo.MaxLength = 50
        Me.TxtObjetivo.Name = "TxtObjetivo"
        Me.TxtObjetivo.Size = New System.Drawing.Size(79, 28)
        Me.TxtObjetivo.TabIndex = 255
        Me.TxtObjetivo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(300, 465)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 22)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Peso Destete :"
        '
        'TxtPesoDestete
        '
        Me.TxtPesoDestete.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPesoDestete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPesoDestete.Location = New System.Drawing.Point(453, 462)
        Me.TxtPesoDestete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPesoDestete.MaxLength = 50
        Me.TxtPesoDestete.Name = "TxtPesoDestete"
        Me.TxtPesoDestete.Size = New System.Drawing.Size(79, 28)
        Me.TxtPesoDestete.TabIndex = 257
        Me.TxtPesoDestete.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(584, 465)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 22)
        Me.Label4.TabIndex = 260
        Me.Label4.Text = "C.A :"
        '
        'TxtCa
        '
        Me.TxtCa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCa.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCa.Location = New System.Drawing.Point(647, 462)
        Me.TxtCa.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCa.MaxLength = 50
        Me.TxtCa.Name = "TxtCa"
        Me.TxtCa.Size = New System.Drawing.Size(79, 28)
        Me.TxtCa.TabIndex = 259
        Me.TxtCa.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(375, 604)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(225, 22)
        Me.Label10.TabIndex = 264
        Me.Label10.Text = "Presentación en Sacos :"
        '
        'TxtPresentacionSacos
        '
        Me.TxtPresentacionSacos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPresentacionSacos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPresentacionSacos.Location = New System.Drawing.Point(609, 601)
        Me.TxtPresentacionSacos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPresentacionSacos.MaxLength = 50
        Me.TxtPresentacionSacos.Name = "TxtPresentacionSacos"
        Me.TxtPresentacionSacos.Size = New System.Drawing.Size(87, 28)
        Me.TxtPresentacionSacos.TabIndex = 263
        Me.TxtPresentacionSacos.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(47, 604)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(197, 22)
        Me.Label11.TabIndex = 266
        Me.Label11.Text = "Total Alimento (kg) :"
        '
        'TxtTotalAlimento
        '
        Me.TxtTotalAlimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTotalAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAlimento.Location = New System.Drawing.Point(251, 601)
        Me.TxtTotalAlimento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtTotalAlimento.MaxLength = 50
        Me.TxtTotalAlimento.Name = "TxtTotalAlimento"
        Me.TxtTotalAlimento.Size = New System.Drawing.Size(93, 28)
        Me.TxtTotalAlimento.TabIndex = 265
        Me.TxtTotalAlimento.TabStop = False
        '
        'LblResultado
        '
        Me.LblResultado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LblResultado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResultado.Location = New System.Drawing.Point(251, 533)
        Me.LblResultado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LblResultado.MaxLength = 50
        Me.LblResultado.Name = "LblResultado"
        Me.LblResultado.Size = New System.Drawing.Size(93, 28)
        Me.LblResultado.TabIndex = 267
        Me.LblResultado.TabStop = False
        '
        'TxtConsumoAlimento
        '
        Me.TxtConsumoAlimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsumoAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConsumoAlimento.Location = New System.Drawing.Point(609, 533)
        Me.TxtConsumoAlimento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtConsumoAlimento.MaxLength = 50
        Me.TxtConsumoAlimento.Name = "TxtConsumoAlimento"
        Me.TxtConsumoAlimento.Size = New System.Drawing.Size(87, 28)
        Me.TxtConsumoAlimento.TabIndex = 268
        Me.TxtConsumoAlimento.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(111, 536)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 22)
        Me.Label9.TabIndex = 269
        Me.Label9.Text = "Kg/Animal :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(425, 536)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(176, 22)
        Me.Label12.TabIndex = 270
        Me.Label12.Text = "Kg Progresivos :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblFechaNacimiento)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.LblTotalAnimales)
        Me.GroupBox2.Controls.Add(Me.TxtGrupo)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.BtnSeleccioneGrupo)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(34, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(727, 106)
        Me.GroupBox2.TabIndex = 255
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selección del Grupo"
        '
        'LblFechaNacimiento
        '
        Me.LblFechaNacimiento.AutoSize = True
        Me.LblFechaNacimiento.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaNacimiento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaNacimiento.ForeColor = System.Drawing.Color.Black
        Me.LblFechaNacimiento.Location = New System.Drawing.Point(632, 64)
        Me.LblFechaNacimiento.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFechaNacimiento.Name = "LblFechaNacimiento"
        Me.LblFechaNacimiento.Size = New System.Drawing.Size(21, 22)
        Me.LblFechaNacimiento.TabIndex = 274
        Me.LblFechaNacimiento.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(439, 64)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(183, 22)
        Me.Label16.TabIndex = 273
        Me.Label16.Text = "Fecha Nacimiento :"
        '
        'LblTotalAnimales
        '
        Me.LblTotalAnimales.AutoSize = True
        Me.LblTotalAnimales.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalAnimales.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAnimales.ForeColor = System.Drawing.Color.Black
        Me.LblTotalAnimales.Location = New System.Drawing.Point(632, 27)
        Me.LblTotalAnimales.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalAnimales.Name = "LblTotalAnimales"
        Me.LblTotalAnimales.Size = New System.Drawing.Size(21, 22)
        Me.LblTotalAnimales.TabIndex = 272
        Me.LblTotalAnimales.Text = "0"
        '
        'TxtGrupo
        '
        Me.TxtGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGrupo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrupo.Location = New System.Drawing.Point(129, 45)
        Me.TxtGrupo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtGrupo.MaxLength = 50
        Me.TxtGrupo.Name = "TxtGrupo"
        Me.TxtGrupo.Size = New System.Drawing.Size(181, 28)
        Me.TxtGrupo.TabIndex = 173
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(467, 27)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(155, 22)
        Me.Label15.TabIndex = 271
        Me.Label15.Text = "Total Animales :"
        '
        'BtnSeleccioneGrupo
        '
        Me.BtnSeleccioneGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSeleccioneGrupo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeleccioneGrupo.Image = CType(resources.GetObject("BtnSeleccioneGrupo.Image"), System.Drawing.Image)
        Me.BtnSeleccioneGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSeleccioneGrupo.Location = New System.Drawing.Point(329, 37)
        Me.BtnSeleccioneGrupo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnSeleccioneGrupo.Name = "BtnSeleccioneGrupo"
        Me.BtnSeleccioneGrupo.Size = New System.Drawing.Size(48, 45)
        Me.BtnSeleccioneGrupo.TabIndex = 171
        Me.BtnSeleccioneGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSeleccioneGrupo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(39, 48)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 22)
        Me.Label13.TabIndex = 172
        Me.Label13.Text = "Grupo :"
        '
        'BtnDividirGrupos
        '
        Me.BtnDividirGrupos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDividirGrupos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDividirGrupos.Image = Global.Formularios.My.Resources.Resources.division_alimento
        Me.BtnDividirGrupos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDividirGrupos.Location = New System.Drawing.Point(505, 688)
        Me.BtnDividirGrupos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnDividirGrupos.Name = "BtnDividirGrupos"
        Me.BtnDividirGrupos.Size = New System.Drawing.Size(256, 45)
        Me.BtnDividirGrupos.TabIndex = 271
        Me.BtnDividirGrupos.Text = "Distribuir Alimento"
        Me.BtnDividirGrupos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnDividirGrupos.UseVisualStyleBackColor = True
        '
        'btnIngresarGrupo
        '
        Me.btnIngresarGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIngresarGrupo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresarGrupo.Image = Global.Formularios.My.Resources.Resources.Agregar_24_Px
        Me.btnIngresarGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresarGrupo.Location = New System.Drawing.Point(31, 688)
        Me.btnIngresarGrupo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnIngresarGrupo.Name = "btnIngresarGrupo"
        Me.btnIngresarGrupo.Size = New System.Drawing.Size(193, 45)
        Me.btnIngresarGrupo.TabIndex = 281
        Me.btnIngresarGrupo.Text = "Distribuciones"
        Me.btnIngresarGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIngresarGrupo.UseVisualStyleBackColor = True
        '
        'FrmAlimentacionPresupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(797, 778)
        Me.Controls.Add(Me.btnIngresarGrupo)
        Me.Controls.Add(Me.BtnDividirGrupos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtConsumoAlimento)
        Me.Controls.Add(Me.LblResultado)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtTotalAlimento)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtPresentacionSacos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPesoDestete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtObjetivo)
        Me.Controls.Add(Me.LblEdad)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.LblDiaPic)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmbLotes)
        Me.Controls.Add(Me.CmbAnios)
        Me.Controls.Add(Me.Label3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAlimentacionPresupuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ALIMENTACIÓN Y PRESUPUESTO"
        CType(Me.CmbLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDiaPic As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbLotes As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CmbAnios As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents LblEdad As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtObjetivo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPesoDestete As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtCa As TextBox
    Friend WithEvents txtDescripcionAlimento As TextBox
    Friend WithEvents btnBuscarInsumos As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtPresentacionSacos As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtTotalAlimento As TextBox
    Friend WithEvents LblResultado As TextBox
    Friend WithEvents TxtConsumoAlimento As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblTotalAnimales As Label
    Friend WithEvents TxtGrupo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents BtnSeleccioneGrupo As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents LblFechaNacimiento As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnDividirGrupos As Button
    Friend WithEvents btnIngresarGrupo As Button
End Class
