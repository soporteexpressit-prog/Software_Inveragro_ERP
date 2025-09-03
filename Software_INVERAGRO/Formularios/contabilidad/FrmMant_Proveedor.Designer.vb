<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMant_Proveedor
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.dtg_Listado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevocomprasproveedores = New System.Windows.Forms.ToolStripButton()
        Me.btn_editarcomprasproveedores = New System.Windows.Forms.ToolStripButton()
        Me.btnexportar_excelcomprasproveedores = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1comprasproveedores = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnImprimirListaProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1ComprasConvercli = New System.Windows.Forms.ToolStripButton()
        Me.btn_cerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dtg_Listado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(381, 29)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "MODULO DE PROVEEDORES"
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AccessibleName = "Selección de nuevo elemento"
        Me.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.miniToolStrip.Location = New System.Drawing.Point(1, 2)
        Me.miniToolStrip.Margin = New System.Windows.Forms.Padding(2)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.miniToolStrip.Size = New System.Drawing.Size(944, 38)
        Me.miniToolStrip.TabIndex = 181
        '
        'dtg_Listado
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.FontData.Name = "Verdana"
        Me.dtg_Listado.DisplayLayout.Appearance = Appearance1
        Me.dtg_Listado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtg_Listado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dtg_Listado.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtg_Listado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dtg_Listado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtg_Listado.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dtg_Listado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtg_Listado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtg_Listado.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dtg_Listado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtg_Listado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dtg_Listado.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtg_Listado.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dtg_Listado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtg_Listado.DisplayLayout.Override.CellPadding = 0
        Me.dtg_Listado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtg_Listado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dtg_Listado.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.AliceBlue
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Me.dtg_Listado.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dtg_Listado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtg_Listado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dtg_Listado.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.RowPreviewAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.dtg_Listado.DisplayLayout.Override.RowSelectorAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Navy
        Me.dtg_Listado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance14
        Me.dtg_Listado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtg_Listado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dtg_Listado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtg_Listado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtg_Listado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtg_Listado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_Listado.Location = New System.Drawing.Point(4, 24)
        Me.dtg_Listado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtg_Listado.Name = "dtg_Listado"
        Me.dtg_Listado.Size = New System.Drawing.Size(1754, 858)
        Me.dtg_Listado.TabIndex = 181
        Me.dtg_Listado.Text = "UltraGrid1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevocomprasproveedores, Me.btn_editarcomprasproveedores, Me.btnexportar_excelcomprasproveedores, Me.ToolStripButton1comprasproveedores, Me.ToolStripButton1ComprasConvercli, Me.btn_cerrar, Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 99)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1762, 43)
        Me.ToolStrip1.TabIndex = 180
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_nuevocomprasproveedores
        '
        Me.btn_nuevocomprasproveedores.BackColor = System.Drawing.Color.Transparent
        Me.btn_nuevocomprasproveedores.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevocomprasproveedores.ForeColor = System.Drawing.Color.White
        Me.btn_nuevocomprasproveedores.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btn_nuevocomprasproveedores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevocomprasproveedores.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_nuevocomprasproveedores.Name = "btn_nuevocomprasproveedores"
        Me.btn_nuevocomprasproveedores.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_nuevocomprasproveedores.Size = New System.Drawing.Size(118, 33)
        Me.btn_nuevocomprasproveedores.Text = " Nuevo"
        Me.btn_nuevocomprasproveedores.ToolTipText = "Nuevo "
        '
        'btn_editarcomprasproveedores
        '
        Me.btn_editarcomprasproveedores.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editarcomprasproveedores.ForeColor = System.Drawing.Color.White
        Me.btn_editarcomprasproveedores.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btn_editarcomprasproveedores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_editarcomprasproveedores.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_editarcomprasproveedores.Name = "btn_editarcomprasproveedores"
        Me.btn_editarcomprasproveedores.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_editarcomprasproveedores.Size = New System.Drawing.Size(135, 33)
        Me.btn_editarcomprasproveedores.Text = " Editar   "
        Me.btn_editarcomprasproveedores.ToolTipText = "Editar"
        '
        'btnexportar_excelcomprasproveedores
        '
        Me.btnexportar_excelcomprasproveedores.AutoToolTip = False
        Me.btnexportar_excelcomprasproveedores.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar_excelcomprasproveedores.ForeColor = System.Drawing.Color.White
        Me.btnexportar_excelcomprasproveedores.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportar_excelcomprasproveedores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportar_excelcomprasproveedores.Margin = New System.Windows.Forms.Padding(5)
        Me.btnexportar_excelcomprasproveedores.Name = "btnexportar_excelcomprasproveedores"
        Me.btnexportar_excelcomprasproveedores.Padding = New System.Windows.Forms.Padding(2)
        Me.btnexportar_excelcomprasproveedores.Size = New System.Drawing.Size(144, 33)
        Me.btnexportar_excelcomprasproveedores.Text = " Exportar"
        '
        'ToolStripButton1comprasproveedores
        '
        Me.ToolStripButton1comprasproveedores.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1comprasproveedores.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimirListaProveedor})
        Me.ToolStripButton1comprasproveedores.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1comprasproveedores.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1comprasproveedores.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.ToolStripButton1comprasproveedores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1comprasproveedores.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1comprasproveedores.Name = "ToolStripButton1comprasproveedores"
        Me.ToolStripButton1comprasproveedores.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1comprasproveedores.Size = New System.Drawing.Size(162, 33)
        Me.ToolStripButton1comprasproveedores.Text = " Reportes"
        Me.ToolStripButton1comprasproveedores.ToolTipText = "Reportes"
        '
        'btnImprimirListaProveedor
        '
        Me.btnImprimirListaProveedor.Name = "btnImprimirListaProveedor"
        Me.btnImprimirListaProveedor.Size = New System.Drawing.Size(276, 34)
        Me.btnImprimirListaProveedor.Text = "Imprimir Lista"
        Me.btnImprimirListaProveedor.ToolTipText = "Imprimir Lista"
        '
        'ToolStripButton1ComprasConvercli
        '
        Me.ToolStripButton1ComprasConvercli.AutoToolTip = False
        Me.ToolStripButton1ComprasConvercli.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1ComprasConvercli.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1ComprasConvercli.Image = Global.Formularios.My.Resources.Resources.circle_of_two_clockwise_arrows_rotation
        Me.ToolStripButton1ComprasConvercli.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1ComprasConvercli.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1ComprasConvercli.Name = "ToolStripButton1ComprasConvercli"
        Me.ToolStripButton1ComprasConvercli.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1ComprasConvercli.Size = New System.Drawing.Size(246, 33)
        Me.ToolStripButton1ComprasConvercli.Text = "Convertir a cliente"
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btn_cerrar.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.ForeColor = System.Drawing.Color.White
        Me.btn_cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btn_cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btn_cerrar.Size = New System.Drawing.Size(91, 33)
        Me.btn_cerrar.Text = "Salir"
        Me.btn_cerrar.ToolTipText = "Cerrar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripButton2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2.Image = Global.Formularios.My.Resources.Resources.enlace
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton2.Size = New System.Drawing.Size(121, 33)
        Me.ToolStripButton2.Text = "Agrupar"
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
        Me.ToolStripButton1.Size = New System.Drawing.Size(102, 33)
        Me.ToolStripButton1.Text = "Filtros"
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(483, 537)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 182
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1762, 142)
        Me.Panel1.TabIndex = 183
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtg_Listado)
        Me.GroupBox1.Controls.Add(Me.Ptbx_Cargando)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 142)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1762, 887)
        Me.GroupBox1.TabIndex = 184
        Me.GroupBox1.TabStop = False
        '
        'FrmMant_Proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1762, 1029)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMant_Proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PROVEEDORES"
        CType(Me.dtg_Listado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents miniToolStrip As ToolStrip
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtg_Listado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btn_nuevocomprasproveedores As ToolStripButton
    Friend WithEvents btn_editarcomprasproveedores As ToolStripButton
    Friend WithEvents btnexportar_excelcomprasproveedores As ToolStripButton
    Friend WithEvents ToolStripButton1comprasproveedores As ToolStripDropDownButton
    Friend WithEvents btnImprimirListaProveedor As ToolStripMenuItem
    Friend WithEvents ToolStripButton1ComprasConvercli As ToolStripButton
    Friend WithEvents btn_cerrar As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
End Class
