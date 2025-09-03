<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlTransportesIF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlTransportesIF))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnnuevoRrhhdm = New System.Windows.Forms.ToolStripButton()
        Me.btneditarpermisorrhh = New System.Windows.Forms.ToolStripButton()
        Me.btncancelarpermisorrrhh = New System.Windows.Forms.ToolStripButton()
        Me.btnexportarRrhhdm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2Rrhhdm = New System.Windows.Forms.ToolStripButton()
        Me.ConceptosRRHHVACACIONESPERMISOS = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMincidentes = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(110, 38)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Fecha Desde :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(114, 91)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 22)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fecha Hasta :"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Checked = False
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(264, 85)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(504, 28)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Checked = False
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(264, 31)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(504, 28)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnnuevoRrhhdm, Me.btneditarpermisorrhh, Me.btncancelarpermisorrrhh, Me.btnexportarRrhhdm, Me.ToolStripButton2Rrhhdm, Me.ConceptosRRHHVACACIONESPERMISOS, Me.btncerrar, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 234)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1809, 40)
        Me.ToolStrip1.TabIndex = 163
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnnuevoRrhhdm
        '
        Me.btnnuevoRrhhdm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevoRrhhdm.ForeColor = System.Drawing.Color.White
        Me.btnnuevoRrhhdm.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnnuevoRrhhdm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnuevoRrhhdm.Margin = New System.Windows.Forms.Padding(5)
        Me.btnnuevoRrhhdm.Name = "btnnuevoRrhhdm"
        Me.btnnuevoRrhhdm.Padding = New System.Windows.Forms.Padding(2)
        Me.btnnuevoRrhhdm.Size = New System.Drawing.Size(108, 30)
        Me.btnnuevoRrhhdm.Text = "Nuevo "
        Me.btnnuevoRrhhdm.ToolTipText = "Nuevo "
        '
        'btneditarpermisorrhh
        '
        Me.btneditarpermisorrhh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditarpermisorrhh.ForeColor = System.Drawing.Color.White
        Me.btneditarpermisorrhh.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btneditarpermisorrhh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btneditarpermisorrhh.Margin = New System.Windows.Forms.Padding(5)
        Me.btneditarpermisorrhh.Name = "btneditarpermisorrhh"
        Me.btneditarpermisorrhh.Padding = New System.Windows.Forms.Padding(2)
        Me.btneditarpermisorrhh.Size = New System.Drawing.Size(98, 30)
        Me.btneditarpermisorrhh.Text = "Editar"
        Me.btneditarpermisorrhh.ToolTipText = "Nuevo "
        '
        'btncancelarpermisorrrhh
        '
        Me.btncancelarpermisorrrhh.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelarpermisorrrhh.ForeColor = System.Drawing.Color.White
        Me.btncancelarpermisorrrhh.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.btncancelarpermisorrrhh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancelarpermisorrrhh.Margin = New System.Windows.Forms.Padding(5)
        Me.btncancelarpermisorrrhh.Name = "btncancelarpermisorrrhh"
        Me.btncancelarpermisorrrhh.Padding = New System.Windows.Forms.Padding(2)
        Me.btncancelarpermisorrrhh.Size = New System.Drawing.Size(126, 30)
        Me.btncancelarpermisorrrhh.Text = "Cancelar"
        Me.btncancelarpermisorrrhh.ToolTipText = "Nuevo "
        '
        'btnexportarRrhhdm
        '
        Me.btnexportarRrhhdm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportarRrhhdm.ForeColor = System.Drawing.Color.White
        Me.btnexportarRrhhdm.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportarRrhhdm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportarRrhhdm.Margin = New System.Windows.Forms.Padding(5)
        Me.btnexportarRrhhdm.Name = "btnexportarRrhhdm"
        Me.btnexportarRrhhdm.Padding = New System.Windows.Forms.Padding(2)
        Me.btnexportarRrhhdm.Size = New System.Drawing.Size(125, 30)
        Me.btnexportarRrhhdm.Text = "Exportar"
        Me.btnexportarRrhhdm.ToolTipText = "Exportar"
        '
        'ToolStripButton2Rrhhdm
        '
        Me.ToolStripButton2Rrhhdm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2Rrhhdm.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2Rrhhdm.Image = Global.Formularios.My.Resources.Resources.adjuntar
        Me.ToolStripButton2Rrhhdm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2Rrhhdm.Name = "ToolStripButton2Rrhhdm"
        Me.ToolStripButton2Rrhhdm.Size = New System.Drawing.Size(223, 35)
        Me.ToolStripButton2Rrhhdm.Text = "Adjuntar sustento "
        '
        'ConceptosRRHHVACACIONESPERMISOS
        '
        Me.ConceptosRRHHVACACIONESPERMISOS.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConceptosRRHHVACACIONESPERMISOS.ForeColor = System.Drawing.Color.White
        Me.ConceptosRRHHVACACIONESPERMISOS.Image = Global.Formularios.My.Resources.Resources.registro1
        Me.ConceptosRRHHVACACIONESPERMISOS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConceptosRRHHVACACIONESPERMISOS.Margin = New System.Windows.Forms.Padding(5)
        Me.ConceptosRRHHVACACIONESPERMISOS.Name = "ConceptosRRHHVACACIONESPERMISOS"
        Me.ConceptosRRHHVACACIONESPERMISOS.Padding = New System.Windows.Forms.Padding(2)
        Me.ConceptosRRHHVACACIONESPERMISOS.Size = New System.Drawing.Size(143, 30)
        Me.ConceptosRRHHVACACIONESPERMISOS.Text = "Conceptos"
        Me.ConceptosRRHHVACACIONESPERMISOS.ToolTipText = "Conceptos"
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripButton1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.Formularios.My.Resources.Resources.filter__2_1
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1.Size = New System.Drawing.Size(102, 30)
        Me.ToolStripButton1.Text = "Filtros"
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
        Me.dtgListado.Location = New System.Drawing.Point(4, 24)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(6)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1801, 651)
        Me.dtgListado.TabIndex = 164
        Me.dtgListado.Text = "UltraGrid1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox1.Controls.Add(Me.btnMincidentes)
        Me.GroupBox1.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 74)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1488, 132)
        Me.GroupBox1.TabIndex = 165
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'btnMincidentes
        '
        Me.btnMincidentes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMincidentes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMincidentes.Image = CType(resources.GetObject("btnMincidentes.Image"), System.Drawing.Image)
        Me.btnMincidentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMincidentes.Location = New System.Drawing.Point(801, 75)
        Me.btnMincidentes.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.btnMincidentes.Name = "btnMincidentes"
        Me.btnMincidentes.Size = New System.Drawing.Size(126, 48)
        Me.btnMincidentes.TabIndex = 162
        Me.btnMincidentes.Text = "Buscar"
        Me.btnMincidentes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMincidentes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(14, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(533, 29)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "MODULO DE REGISTROS DE PERMISOS"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1809, 274)
        Me.Panel1.TabIndex = 167
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtgListado)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 274)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1809, 680)
        Me.GroupBox2.TabIndex = 168
        Me.GroupBox2.TabStop = False
        '
        'FrmControlTransportesIF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1809, 954)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmControlTransportesIF"
        Me.Text = "FrmControlDescansoMedico"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnMincidentes As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnnuevoRrhhdm As ToolStripButton
    Friend WithEvents btnexportarRrhhdm As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStripButton2Rrhhdm As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ConceptosRRHHVACACIONESPERMISOS As ToolStripButton
    Friend WithEvents btneditarpermisorrhh As ToolStripButton
    Friend WithEvents btncancelarpermisorrrhh As ToolStripButton
End Class
