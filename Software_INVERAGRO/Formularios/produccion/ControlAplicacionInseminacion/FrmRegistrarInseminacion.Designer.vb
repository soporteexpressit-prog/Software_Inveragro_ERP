<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistrarInseminacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrarInseminacion))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BtnBuscarCerda = New System.Windows.Forms.Button()
        Me.LblSeleccionarCerda = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnBloquearEncargado = New System.Windows.Forms.Button()
        Me.BtnAgregarServicio = New System.Windows.Forms.Button()
        Me.BtnEncargado = New System.Windows.Forms.Button()
        Me.TxtNombreEncargado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnBloquearMateGene = New System.Windows.Forms.Button()
        Me.TxtVerraco = New System.Windows.Forms.TextBox()
        Me.LblDosisDisponibles = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnBuscarMG = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBloquearVia = New System.Windows.Forms.Button()
        Me.BtnBloquearCantExpulsada = New System.Windows.Forms.Button()
        Me.BtnBloquearFecha = New System.Windows.Forms.Button()
        Me.CmbViaAplicacion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCantExpulsada = New System.Windows.Forms.TextBox()
        Me.NumDosisInseminar = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpFechaMonta = New System.Windows.Forms.DateTimePicker()
        Me.TxtCondCorporal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCodArete = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumDosisInseminar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TxtPeso)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.BtnBuscarCerda)
        Me.Panel2.Controls.Add(Me.LblSeleccionarCerda)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.TxtCondCorporal)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.LblCodArete)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1053, 766)
        Me.Panel2.TabIndex = 9
        '
        'TxtPeso
        '
        Me.TxtPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPeso.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPeso.Location = New System.Drawing.Point(111, 144)
        Me.TxtPeso.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPeso.MaxLength = 5
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(90, 28)
        Me.TxtPeso.TabIndex = 223
        Me.TxtPeso.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(35, 147)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 22)
        Me.Label5.TabIndex = 222
        Me.Label5.Text = "Peso :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtgListado)
        Me.GroupBox4.Location = New System.Drawing.Point(18, 557)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1018, 198)
        Me.GroupBox4.TabIndex = 221
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle del los servicios"
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
        Me.dtgListado.Location = New System.Drawing.Point(3, 22)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1012, 173)
        Me.dtgListado.TabIndex = 175
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BtnBuscarCerda
        '
        Me.BtnBuscarCerda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCerda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarCerda.Image = CType(resources.GetObject("BtnBuscarCerda.Image"), System.Drawing.Image)
        Me.BtnBuscarCerda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCerda.Location = New System.Drawing.Point(949, 73)
        Me.BtnBuscarCerda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarCerda.Name = "BtnBuscarCerda"
        Me.BtnBuscarCerda.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarCerda.TabIndex = 220
        Me.BtnBuscarCerda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCerda.UseVisualStyleBackColor = True
        '
        'LblSeleccionarCerda
        '
        Me.LblSeleccionarCerda.AutoSize = True
        Me.LblSeleccionarCerda.BackColor = System.Drawing.Color.Transparent
        Me.LblSeleccionarCerda.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeleccionarCerda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblSeleccionarCerda.Location = New System.Drawing.Point(756, 84)
        Me.LblSeleccionarCerda.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblSeleccionarCerda.Name = "LblSeleccionarCerda"
        Me.LblSeleccionarCerda.Size = New System.Drawing.Size(183, 22)
        Me.LblSeleccionarCerda.TabIndex = 219
        Me.LblSeleccionarCerda.Text = "Seleccione Cerda"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnBloquearEncargado)
        Me.GroupBox3.Controls.Add(Me.BtnAgregarServicio)
        Me.GroupBox3.Controls.Add(Me.BtnEncargado)
        Me.GroupBox3.Controls.Add(Me.TxtNombreEncargado)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 454)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1015, 97)
        Me.GroupBox3.TabIndex = 218
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inseminador"
        '
        'BtnBloquearEncargado
        '
        Me.BtnBloquearEncargado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearEncargado.AutoSize = True
        Me.BtnBloquearEncargado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearEncargado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearEncargado.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearEncargado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearEncargado.Location = New System.Drawing.Point(642, 36)
        Me.BtnBloquearEncargado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearEncargado.Name = "BtnBloquearEncargado"
        Me.BtnBloquearEncargado.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearEncargado.TabIndex = 218
        Me.BtnBloquearEncargado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearEncargado.UseVisualStyleBackColor = True
        '
        'BtnAgregarServicio
        '
        Me.BtnAgregarServicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAgregarServicio.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregarServicio.Image = Global.Formularios.My.Resources.Resources.Agregar_24_Px
        Me.BtnAgregarServicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregarServicio.Location = New System.Drawing.Point(751, 32)
        Me.BtnAgregarServicio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnAgregarServicio.Name = "BtnAgregarServicio"
        Me.BtnAgregarServicio.Size = New System.Drawing.Size(257, 45)
        Me.BtnAgregarServicio.TabIndex = 222
        Me.BtnAgregarServicio.Text = "Agregar Servicio"
        Me.BtnAgregarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAgregarServicio.UseVisualStyleBackColor = True
        '
        'BtnEncargado
        '
        Me.BtnEncargado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEncargado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEncargado.Image = CType(resources.GetObject("BtnEncargado.Image"), System.Drawing.Image)
        Me.BtnEncargado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEncargado.Location = New System.Drawing.Point(586, 32)
        Me.BtnEncargado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnEncargado.Name = "BtnEncargado"
        Me.BtnEncargado.Size = New System.Drawing.Size(48, 45)
        Me.BtnEncargado.TabIndex = 168
        Me.BtnEncargado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEncargado.UseVisualStyleBackColor = True
        '
        'TxtNombreEncargado
        '
        Me.TxtNombreEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreEncargado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreEncargado.Location = New System.Drawing.Point(170, 40)
        Me.TxtNombreEncargado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNombreEncargado.MaxLength = 50
        Me.TxtNombreEncargado.Name = "TxtNombreEncargado"
        Me.TxtNombreEncargado.Size = New System.Drawing.Size(408, 28)
        Me.TxtNombreEncargado.TabIndex = 170
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(22, 43)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 22)
        Me.Label11.TabIndex = 169
        Me.Label11.Text = "Inseminador :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnBloquearMateGene)
        Me.GroupBox2.Controls.Add(Me.TxtVerraco)
        Me.GroupBox2.Controls.Add(Me.LblDosisDisponibles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.BtnBuscarMG)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 344)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1015, 104)
        Me.GroupBox2.TabIndex = 217
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información Material Genético"
        '
        'BtnBloquearMateGene
        '
        Me.BtnBloquearMateGene.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearMateGene.AutoSize = True
        Me.BtnBloquearMateGene.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearMateGene.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearMateGene.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearMateGene.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearMateGene.Location = New System.Drawing.Point(522, 36)
        Me.BtnBloquearMateGene.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearMateGene.Name = "BtnBloquearMateGene"
        Me.BtnBloquearMateGene.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearMateGene.TabIndex = 218
        Me.BtnBloquearMateGene.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearMateGene.UseVisualStyleBackColor = True
        '
        'TxtVerraco
        '
        Me.TxtVerraco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVerraco.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVerraco.Location = New System.Drawing.Point(308, 41)
        Me.TxtVerraco.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtVerraco.MaxLength = 50
        Me.TxtVerraco.Name = "TxtVerraco"
        Me.TxtVerraco.Size = New System.Drawing.Size(150, 28)
        Me.TxtVerraco.TabIndex = 178
        '
        'LblDosisDisponibles
        '
        Me.LblDosisDisponibles.AutoSize = True
        Me.LblDosisDisponibles.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblDosisDisponibles.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDosisDisponibles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblDosisDisponibles.Location = New System.Drawing.Point(914, 41)
        Me.LblDosisDisponibles.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblDosisDisponibles.Name = "LblDosisDisponibles"
        Me.LblDosisDisponibles.Size = New System.Drawing.Size(30, 29)
        Me.LblDosisDisponibles.TabIndex = 177
        Me.LblDosisDisponibles.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(65, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 22)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "Código Semen Verraco :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(683, 44)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(203, 22)
        Me.Label10.TabIndex = 176
        Me.Label10.Text = "N° Dosis Disponibles:"
        '
        'BtnBuscarMG
        '
        Me.BtnBuscarMG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarMG.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarMG.Image = CType(resources.GetObject("BtnBuscarMG.Image"), System.Drawing.Image)
        Me.BtnBuscarMG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarMG.Location = New System.Drawing.Point(466, 33)
        Me.BtnBuscarMG.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarMG.Name = "BtnBuscarMG"
        Me.BtnBuscarMG.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarMG.TabIndex = 168
        Me.BtnBuscarMG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarMG.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBloquearVia)
        Me.GroupBox1.Controls.Add(Me.BtnBloquearCantExpulsada)
        Me.GroupBox1.Controls.Add(Me.BtnBloquearFecha)
        Me.GroupBox1.Controls.Add(Me.CmbViaAplicacion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCantExpulsada)
        Me.GroupBox1.Controls.Add(Me.NumDosisInseminar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DtpFechaMonta)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1015, 144)
        Me.GroupBox1.TabIndex = 216
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información General"
        '
        'BtnBloquearVia
        '
        Me.BtnBloquearVia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearVia.AutoSize = True
        Me.BtnBloquearVia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearVia.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearVia.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearVia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearVia.Location = New System.Drawing.Point(943, 25)
        Me.BtnBloquearVia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearVia.Name = "BtnBloquearVia"
        Me.BtnBloquearVia.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearVia.TabIndex = 217
        Me.BtnBloquearVia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearVia.UseVisualStyleBackColor = True
        '
        'BtnBloquearCantExpulsada
        '
        Me.BtnBloquearCantExpulsada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearCantExpulsada.AutoSize = True
        Me.BtnBloquearCantExpulsada.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearCantExpulsada.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearCantExpulsada.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearCantExpulsada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearCantExpulsada.Location = New System.Drawing.Point(434, 80)
        Me.BtnBloquearCantExpulsada.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearCantExpulsada.Name = "BtnBloquearCantExpulsada"
        Me.BtnBloquearCantExpulsada.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearCantExpulsada.TabIndex = 216
        Me.BtnBloquearCantExpulsada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearCantExpulsada.UseVisualStyleBackColor = True
        '
        'BtnBloquearFecha
        '
        Me.BtnBloquearFecha.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearFecha.AutoSize = True
        Me.BtnBloquearFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearFecha.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearFecha.Location = New System.Drawing.Point(486, 27)
        Me.BtnBloquearFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearFecha.Name = "BtnBloquearFecha"
        Me.BtnBloquearFecha.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearFecha.TabIndex = 215
        Me.BtnBloquearFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearFecha.UseVisualStyleBackColor = True
        '
        'CmbViaAplicacion
        '
        Me.CmbViaAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbViaAplicacion.FormattingEnabled = True
        Me.CmbViaAplicacion.Items.AddRange(New Object() {"CERVICAL", "POST-CERVICAL"})
        Me.CmbViaAplicacion.Location = New System.Drawing.Point(745, 31)
        Me.CmbViaAplicacion.Name = "CmbViaAplicacion"
        Me.CmbViaAplicacion.Size = New System.Drawing.Size(186, 28)
        Me.CmbViaAplicacion.TabIndex = 177
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(601, 85)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 22)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "N° de Dosis :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(681, 34)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 22)
        Me.Label7.TabIndex = 176
        Me.Label7.Text = "Vía :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(92, 87)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Cantidad Expulsada :"
        '
        'TxtCantExpulsada
        '
        Me.TxtCantExpulsada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCantExpulsada.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantExpulsada.Location = New System.Drawing.Point(308, 84)
        Me.TxtCantExpulsada.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCantExpulsada.MaxLength = 3
        Me.TxtCantExpulsada.Name = "TxtCantExpulsada"
        Me.TxtCantExpulsada.Size = New System.Drawing.Size(120, 28)
        Me.TxtCantExpulsada.TabIndex = 166
        Me.TxtCantExpulsada.Text = "3"
        '
        'NumDosisInseminar
        '
        Me.NumDosisInseminar.Location = New System.Drawing.Point(745, 83)
        Me.NumDosisInseminar.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumDosisInseminar.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumDosisInseminar.Name = "NumDosisInseminar"
        Me.NumDosisInseminar.Size = New System.Drawing.Size(120, 26)
        Me.NumDosisInseminar.TabIndex = 175
        Me.NumDosisInseminar.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(156, 34)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 22)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "Fecha Monta :"
        '
        'DtpFechaMonta
        '
        Me.DtpFechaMonta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaMonta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaMonta.Location = New System.Drawing.Point(308, 31)
        Me.DtpFechaMonta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFechaMonta.Name = "DtpFechaMonta"
        Me.DtpFechaMonta.Size = New System.Drawing.Size(170, 28)
        Me.DtpFechaMonta.TabIndex = 174
        '
        'TxtCondCorporal
        '
        Me.TxtCondCorporal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCondCorporal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCondCorporal.Location = New System.Drawing.Point(907, 144)
        Me.TxtCondCorporal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCondCorporal.MaxLength = 5
        Me.TxtCondCorporal.Name = "TxtCondCorporal"
        Me.TxtCondCorporal.Size = New System.Drawing.Size(90, 28)
        Me.TxtCondCorporal.TabIndex = 177
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(736, 147)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 22)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Cond Corporal :"
        '
        'LblCodArete
        '
        Me.LblCodArete.AutoSize = True
        Me.LblCodArete.BackColor = System.Drawing.Color.Yellow
        Me.LblCodArete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodArete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCodArete.Location = New System.Drawing.Point(31, 81)
        Me.LblCodArete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCodArete.Name = "LblCodArete"
        Me.LblCodArete.Size = New System.Drawing.Size(25, 29)
        Me.LblCodArete.TabIndex = 215
        Me.LblCodArete.Tag = "S"
        Me.LblCodArete.Text = "-"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1053, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.inseminacion__1_
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.ToolTipText = "Guardar"
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
        Me.BtnCerrar.ToolTipText = "Cerrar"
        '
        'FrmRegistrarInseminacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 766)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistrarInseminacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRAR INSEMINACIÓN"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumDosisInseminar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtCantExpulsada As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents BtnBuscarMG As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents DtpFechaMonta As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents LblDosisDisponibles As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumDosisInseminar As NumericUpDown
    Friend WithEvents TxtCondCorporal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbViaAplicacion As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtVerraco As TextBox
    Friend WithEvents BtnEncargado As Button
    Friend WithEvents TxtNombreEncargado As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblCodArete As Label
    Friend WithEvents BtnBuscarCerda As Button
    Friend WithEvents LblSeleccionarCerda As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BtnAgregarServicio As Button
    Friend WithEvents BtnBloquearCantExpulsada As Button
    Friend WithEvents BtnBloquearFecha As Button
    Friend WithEvents BtnBloquearEncargado As Button
    Friend WithEvents BtnBloquearVia As Button
    Friend WithEvents TxtPeso As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnBloquearMateGene As Button
End Class
