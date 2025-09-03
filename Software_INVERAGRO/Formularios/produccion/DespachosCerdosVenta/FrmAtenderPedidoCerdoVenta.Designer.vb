<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAtenderPedidoCerdoVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAtenderPedidoCerdoVenta))
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.LblStockAlimento = New System.Windows.Forms.Label()
        Me.LblStock = New System.Windows.Forms.Label()
        Me.LblCantidadSacos = New System.Windows.Forms.Label()
        Me.NumSacos = New System.Windows.Forms.NumericUpDown()
        Me.BtnBuscarAlimento = New System.Windows.Forms.Button()
        Me.TxtNombreAlimento = New System.Windows.Forms.TextBox()
        Me.LblAlimento = New System.Windows.Forms.Label()
        Me.TxtCantidadAnimales = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtPesoTotal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDetalleColores = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblSolicitudSacosEngorde = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.LblCantidadSolicitada = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtPeso = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCantidadCrias = New System.Windows.Forms.Label()
        Me.LblCrias1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumCantidad = New System.Windows.Forms.NumericUpDown()
        Me.BtnIngresar = New System.Windows.Forms.Button()
        Me.BtnBuscarCorralVenta = New System.Windows.Forms.Button()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NumSacos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.TxtCantidadAnimales)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.TxtPesoTotal)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1212, 1021)
        Me.Panel2.TabIndex = 14
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LblMensaje)
        Me.GroupBox5.Controls.Add(Me.LblStockAlimento)
        Me.GroupBox5.Controls.Add(Me.LblStock)
        Me.GroupBox5.Controls.Add(Me.LblCantidadSacos)
        Me.GroupBox5.Controls.Add(Me.NumSacos)
        Me.GroupBox5.Controls.Add(Me.BtnBuscarAlimento)
        Me.GroupBox5.Controls.Add(Me.TxtNombreAlimento)
        Me.GroupBox5.Controls.Add(Me.LblAlimento)
        Me.GroupBox5.Location = New System.Drawing.Point(797, 322)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(404, 168)
        Me.GroupBox5.TabIndex = 231
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Información de Sacos"
        '
        'LblMensaje
        '
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblMensaje.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblMensaje.Location = New System.Drawing.Point(130, 96)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(174, 22)
        Me.LblMensaje.TabIndex = 219
        Me.LblMensaje.Text = "NO SOLICITADO"
        '
        'LblStockAlimento
        '
        Me.LblStockAlimento.AutoSize = True
        Me.LblStockAlimento.BackColor = System.Drawing.Color.Transparent
        Me.LblStockAlimento.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStockAlimento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStockAlimento.Location = New System.Drawing.Point(246, 85)
        Me.LblStockAlimento.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblStockAlimento.Name = "LblStockAlimento"
        Me.LblStockAlimento.Size = New System.Drawing.Size(18, 17)
        Me.LblStockAlimento.TabIndex = 228
        Me.LblStockAlimento.Text = "0"
        '
        'LblStock
        '
        Me.LblStock.AutoSize = True
        Me.LblStock.BackColor = System.Drawing.Color.Transparent
        Me.LblStock.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStock.Location = New System.Drawing.Point(134, 85)
        Me.LblStock.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblStock.Name = "LblStock"
        Me.LblStock.Size = New System.Drawing.Size(99, 17)
        Me.LblStock.TabIndex = 227
        Me.LblStock.Text = "Stock (tn) :"
        '
        'LblCantidadSacos
        '
        Me.LblCantidadSacos.AutoSize = True
        Me.LblCantidadSacos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadSacos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadSacos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCantidadSacos.Location = New System.Drawing.Point(44, 123)
        Me.LblCantidadSacos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCantidadSacos.Name = "LblCantidadSacos"
        Me.LblCantidadSacos.Size = New System.Drawing.Size(223, 22)
        Me.LblCantidadSacos.TabIndex = 210
        Me.LblCantidadSacos.Text = "Cantidad Sacos (kg):"
        '
        'NumSacos
        '
        Me.NumSacos.Location = New System.Drawing.Point(283, 121)
        Me.NumSacos.Name = "NumSacos"
        Me.NumSacos.Size = New System.Drawing.Size(87, 26)
        Me.NumSacos.TabIndex = 209
        '
        'BtnBuscarAlimento
        '
        Me.BtnBuscarAlimento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarAlimento.Image = CType(resources.GetObject("BtnBuscarAlimento.Image"), System.Drawing.Image)
        Me.BtnBuscarAlimento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarAlimento.Location = New System.Drawing.Point(324, 38)
        Me.BtnBuscarAlimento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarAlimento.Name = "BtnBuscarAlimento"
        Me.BtnBuscarAlimento.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarAlimento.TabIndex = 205
        Me.BtnBuscarAlimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarAlimento.UseVisualStyleBackColor = True
        '
        'TxtNombreAlimento
        '
        Me.TxtNombreAlimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreAlimento.Location = New System.Drawing.Point(156, 46)
        Me.TxtNombreAlimento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNombreAlimento.MaxLength = 50
        Me.TxtNombreAlimento.Name = "TxtNombreAlimento"
        Me.TxtNombreAlimento.Size = New System.Drawing.Size(153, 28)
        Me.TxtNombreAlimento.TabIndex = 206
        '
        'LblAlimento
        '
        Me.LblAlimento.AutoSize = True
        Me.LblAlimento.BackColor = System.Drawing.Color.Transparent
        Me.LblAlimento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlimento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblAlimento.Location = New System.Drawing.Point(34, 49)
        Me.LblAlimento.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblAlimento.Name = "LblAlimento"
        Me.LblAlimento.Size = New System.Drawing.Size(113, 22)
        Me.LblAlimento.TabIndex = 207
        Me.LblAlimento.Text = "Alimento :"
        '
        'TxtCantidadAnimales
        '
        Me.TxtCantidadAnimales.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCantidadAnimales.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadAnimales.Location = New System.Drawing.Point(370, 962)
        Me.TxtCantidadAnimales.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCantidadAnimales.MaxLength = 5
        Me.TxtCantidadAnimales.Name = "TxtCantidadAnimales"
        Me.TxtCantidadAnimales.Size = New System.Drawing.Size(115, 28)
        Me.TxtCantidadAnimales.TabIndex = 233
        Me.TxtCantidadAnimales.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(148, 965)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(212, 22)
        Me.Label9.TabIndex = 232
        Me.Label9.Text = "Cantidad Animales :"
        '
        'TxtPesoTotal
        '
        Me.TxtPesoTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPesoTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPesoTotal.Location = New System.Drawing.Point(1044, 962)
        Me.TxtPesoTotal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPesoTotal.MaxLength = 5
        Me.TxtPesoTotal.Name = "TxtPesoTotal"
        Me.TxtPesoTotal.Size = New System.Drawing.Size(115, 28)
        Me.TxtPesoTotal.TabIndex = 231
        Me.TxtPesoTotal.Text = "0.0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(906, 965)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 22)
        Me.Label8.TabIndex = 231
        Me.Label8.Text = "Peso Total :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.TxtDetalleColores)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 496)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1185, 103)
        Me.GroupBox4.TabIndex = 211
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle de colores (opcional)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(72, 47)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 22)
        Me.Label7.TabIndex = 217
        Me.Label7.Text = "Colores : "
        '
        'TxtDetalleColores
        '
        Me.TxtDetalleColores.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDetalleColores.Location = New System.Drawing.Point(185, 31)
        Me.TxtDetalleColores.MaxLength = 100
        Me.TxtDetalleColores.Name = "TxtDetalleColores"
        Me.TxtDetalleColores.Size = New System.Drawing.Size(530, 56)
        Me.TxtDetalleColores.TabIndex = 217
        Me.TxtDetalleColores.Text = "NINGUNO"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtgListado)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 605)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1185, 326)
        Me.GroupBox2.TabIndex = 210
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle de Despacho para Venta"
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
        Me.dtgListado.Size = New System.Drawing.Size(1179, 301)
        Me.dtgListado.TabIndex = 176
        Me.dtgListado.Text = "UltraGrid1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DtpFecha)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.LblSolicitudSacosEngorde)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TxtObservacion)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.LblCliente)
        Me.GroupBox3.Controls.Add(Me.LblCantidadSolicitada)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 79)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1186, 235)
        Me.GroupBox3.TabIndex = 209
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información de Cliente"
        '
        'DtpFecha
        '
        Me.DtpFecha.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(303, 32)
        Me.DtpFecha.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(167, 28)
        Me.DtpFecha.TabIndex = 220
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(204, 35)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 22)
        Me.Label10.TabIndex = 219
        Me.Label10.Text = "Fecha : "
        '
        'LblSolicitudSacosEngorde
        '
        Me.LblSolicitudSacosEngorde.AutoSize = True
        Me.LblSolicitudSacosEngorde.BackColor = System.Drawing.Color.Transparent
        Me.LblSolicitudSacosEngorde.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSolicitudSacosEngorde.ForeColor = System.Drawing.Color.Black
        Me.LblSolicitudSacosEngorde.Location = New System.Drawing.Point(1053, 117)
        Me.LblSolicitudSacosEngorde.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblSolicitudSacosEngorde.Name = "LblSolicitudSacosEngorde"
        Me.LblSolicitudSacosEngorde.Size = New System.Drawing.Size(23, 22)
        Me.LblSolicitudSacosEngorde.TabIndex = 218
        Me.LblSolicitudSacosEngorde.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(861, 117)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(178, 22)
        Me.Label11.TabIndex = 217
        Me.Label11.Text = "Sacos Engorde : "
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObservacion.Location = New System.Drawing.Point(303, 157)
        Me.TxtObservacion.MaxLength = 200
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(849, 56)
        Me.TxtObservacion.TabIndex = 216
        Me.TxtObservacion.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(218, 160)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 22)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "Nota : "
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.Color.Black
        Me.LblCliente.Location = New System.Drawing.Point(308, 76)
        Me.LblCliente.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(19, 22)
        Me.LblCliente.TabIndex = 214
        Me.LblCliente.Text = "-"
        '
        'LblCantidadSolicitada
        '
        Me.LblCantidadSolicitada.AutoSize = True
        Me.LblCantidadSolicitada.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadSolicitada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadSolicitada.ForeColor = System.Drawing.Color.Black
        Me.LblCantidadSolicitada.Location = New System.Drawing.Point(308, 117)
        Me.LblCantidadSolicitada.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCantidadSolicitada.Name = "LblCantidadSolicitada"
        Me.LblCantidadSolicitada.Size = New System.Drawing.Size(23, 22)
        Me.LblCantidadSolicitada.TabIndex = 213
        Me.LblCantidadSolicitada.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(70, 117)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 22)
        Me.Label3.TabIndex = 212
        Me.Label3.Text = "Cantidad Solicitada : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(195, 76)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 22)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Cliente : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtPeso)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtCantidadCrias)
        Me.GroupBox1.Controls.Add(Me.LblCrias1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.NumCantidad)
        Me.GroupBox1.Controls.Add(Me.BtnIngresar)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarCorralVenta)
        Me.GroupBox1.Controls.Add(Me.TxtLote)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 322)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 168)
        Me.GroupBox1.TabIndex = 160
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de Despacho de Cerdo"
        '
        'TxtPeso
        '
        Me.TxtPeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPeso.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPeso.Location = New System.Drawing.Point(145, 117)
        Me.TxtPeso.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPeso.MaxLength = 10
        Me.TxtPeso.Name = "TxtPeso"
        Me.TxtPeso.Size = New System.Drawing.Size(115, 28)
        Me.TxtPeso.TabIndex = 230
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(59, 119)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 22)
        Me.Label6.TabIndex = 229
        Me.Label6.Text = "Peso :"
        '
        'TxtCantidadCrias
        '
        Me.TxtCantidadCrias.AutoSize = True
        Me.TxtCantidadCrias.BackColor = System.Drawing.Color.Transparent
        Me.TxtCantidadCrias.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidadCrias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtCantidadCrias.Location = New System.Drawing.Point(252, 80)
        Me.TxtCantidadCrias.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.TxtCantidadCrias.Name = "TxtCantidadCrias"
        Me.TxtCantidadCrias.Size = New System.Drawing.Size(18, 17)
        Me.TxtCantidadCrias.TabIndex = 228
        Me.TxtCantidadCrias.Text = "0"
        '
        'LblCrias1
        '
        Me.LblCrias1.AutoSize = True
        Me.LblCrias1.BackColor = System.Drawing.Color.Transparent
        Me.LblCrias1.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCrias1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCrias1.Location = New System.Drawing.Point(147, 80)
        Me.LblCrias1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCrias1.Name = "LblCrias1"
        Me.LblCrias1.Size = New System.Drawing.Size(98, 17)
        Me.LblCrias1.TabIndex = 227
        Me.LblCrias1.Text = "N° Cerdos :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(468, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 22)
        Me.Label4.TabIndex = 210
        Me.Label4.Text = "Cantidad Venta :"
        '
        'NumCantidad
        '
        Me.NumCantidad.Location = New System.Drawing.Point(672, 48)
        Me.NumCantidad.Name = "NumCantidad"
        Me.NumCantidad.Size = New System.Drawing.Size(87, 26)
        Me.NumCantidad.TabIndex = 209
        '
        'BtnIngresar
        '
        Me.BtnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngresar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIngresar.Image = Global.Formularios.My.Resources.Resources.Agregar_24_Px1
        Me.BtnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIngresar.Location = New System.Drawing.Point(598, 108)
        Me.BtnIngresar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Size = New System.Drawing.Size(161, 45)
        Me.BtnIngresar.TabIndex = 208
        Me.BtnIngresar.Text = "Ingresar"
        Me.BtnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnIngresar.UseVisualStyleBackColor = True
        '
        'BtnBuscarCorralVenta
        '
        Me.BtnBuscarCorralVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCorralVenta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarCorralVenta.Image = CType(resources.GetObject("BtnBuscarCorralVenta.Image"), System.Drawing.Image)
        Me.BtnBuscarCorralVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCorralVenta.Location = New System.Drawing.Point(313, 38)
        Me.BtnBuscarCorralVenta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarCorralVenta.Name = "BtnBuscarCorralVenta"
        Me.BtnBuscarCorralVenta.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarCorralVenta.TabIndex = 205
        Me.BtnBuscarCorralVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCorralVenta.UseVisualStyleBackColor = True
        '
        'TxtLote
        '
        Me.TxtLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLote.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLote.Location = New System.Drawing.Point(145, 46)
        Me.TxtLote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtLote.MaxLength = 50
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(153, 28)
        Me.TxtLote.TabIndex = 206
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(64, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 22)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "Lote :"
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
        Me.ToolStrip1.Size = New System.Drawing.Size(1212, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
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
        'FrmAtenderPedidoCerdoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 1021)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAtenderPedidoCerdoVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ATENDER PEDIDO DE CERDO"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NumSacos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LblCantidadSolicitada As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtCantidadCrias As Label
    Friend WithEvents LblCrias1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NumCantidad As NumericUpDown
    Friend WithEvents BtnIngresar As Button
    Friend WithEvents BtnBuscarCorralVenta As Button
    Friend WithEvents TxtLote As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtPeso As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtObservacion As RichTextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDetalleColores As RichTextBox
    Friend WithEvents TxtPesoTotal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtCantidadAnimales As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents LblStockAlimento As Label
    Friend WithEvents LblStock As Label
    Friend WithEvents LblCantidadSacos As Label
    Friend WithEvents NumSacos As NumericUpDown
    Friend WithEvents BtnBuscarAlimento As Button
    Friend WithEvents TxtNombreAlimento As TextBox
    Friend WithEvents LblAlimento As Label
    Friend WithEvents LblSolicitudSacosEngorde As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblMensaje As Label
    Friend WithEvents DtpFecha As DateTimePicker
    Friend WithEvents Label10 As Label
End Class
