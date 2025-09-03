<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPedidoTransferenciaCerdos
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
        Me.cbxplanteles = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpedido = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtstock = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxalmacendestino = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxmotivotransaccion = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtobservacion = New System.Windows.Forms.RichTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtcantidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TsBtn_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.txtstockdisponibleslimento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcantidadalimento = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dtpedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbxmotivotransaccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.txtcantidadalimento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxplanteles
        '
        Me.cbxplanteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxplanteles.FormattingEnabled = True
        Me.cbxplanteles.Location = New System.Drawing.Point(197, 48)
        Me.cbxplanteles.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbxplanteles.Name = "cbxplanteles"
        Me.cbxplanteles.Size = New System.Drawing.Size(349, 26)
        Me.cbxplanteles.TabIndex = 168
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(600, 21)
        Me.Label13.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "F. Pedido :"
        '
        'dtpedido
        '
        Me.dtpedido.DateTime = New Date(2010, 12, 16, 0, 0, 0, 0)
        Me.dtpedido.Location = New System.Drawing.Point(686, 19)
        Me.dtpedido.Margin = New System.Windows.Forms.Padding(7, 4, 7, 4)
        Me.dtpedido.Name = "dtpedido"
        Me.dtpedido.Size = New System.Drawing.Size(195, 29)
        Me.dtpedido.TabIndex = 4
        Me.dtpedido.TabStop = False
        Me.dtpedido.Value = New Date(2010, 12, 16, 0, 0, 0, 0)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(110, 50)
        Me.Label21.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 22)
        Me.Label21.TabIndex = 162
        Me.Label21.Text = "Plantel :"
        '
        'txtstock
        '
        Me.txtstock.Location = New System.Drawing.Point(260, 174)
        Me.txtstock.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtstock.Name = "txtstock"
        Me.txtstock.ReadOnly = True
        Me.txtstock.Size = New System.Drawing.Size(109, 27)
        Me.txtstock.TabIndex = 194
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxalmacendestino)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cbxmotivotransaccion)
        Me.GroupBox2.Controls.Add(Me.cbxplanteles)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtpedido)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(63, 61)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(912, 107)
        Me.GroupBox2.TabIndex = 193
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información"
        '
        'cbxalmacendestino
        '
        Me.cbxalmacendestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxalmacendestino.FormattingEnabled = True
        Me.cbxalmacendestino.Location = New System.Drawing.Point(196, 75)
        Me.cbxalmacendestino.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbxalmacendestino.Name = "cbxalmacendestino"
        Me.cbxalmacendestino.Size = New System.Drawing.Size(349, 26)
        Me.cbxalmacendestino.TabIndex = 174
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(105, 77)
        Me.Label2.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 22)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Destino :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(35, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 22)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Motivo Transacción :"
        '
        'cbxmotivotransaccion
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbxmotivotransaccion.DisplayLayout.Appearance = Appearance1
        Me.cbxmotivotransaccion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cbxmotivotransaccion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cbxmotivotransaccion.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbxmotivotransaccion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cbxmotivotransaccion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbxmotivotransaccion.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cbxmotivotransaccion.DisplayLayout.MaxColScrollRegions = 1
        Me.cbxmotivotransaccion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbxmotivotransaccion.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cbxmotivotransaccion.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cbxmotivotransaccion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cbxmotivotransaccion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cbxmotivotransaccion.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cbxmotivotransaccion.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cbxmotivotransaccion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cbxmotivotransaccion.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cbxmotivotransaccion.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cbxmotivotransaccion.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cbxmotivotransaccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cbxmotivotransaccion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cbxmotivotransaccion.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cbxmotivotransaccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbxmotivotransaccion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cbxmotivotransaccion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cbxmotivotransaccion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cbxmotivotransaccion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cbxmotivotransaccion.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cbxmotivotransaccion.Location = New System.Drawing.Point(196, 19)
        Me.cbxmotivotransaccion.Margin = New System.Windows.Forms.Padding(7, 4, 7, 4)
        Me.cbxmotivotransaccion.Name = "cbxmotivotransaccion"
        Me.cbxmotivotransaccion.Size = New System.Drawing.Size(356, 30)
        Me.cbxmotivotransaccion.TabIndex = 172
        Me.cbxmotivotransaccion.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(123, 263)
        Me.Label9.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 22)
        Me.Label9.TabIndex = 185
        Me.Label9.Text = "Observación :"
        '
        'txtobservacion
        '
        Me.txtobservacion.Location = New System.Drawing.Point(260, 261)
        Me.txtobservacion.Margin = New System.Windows.Forms.Padding(7, 4, 7, 4)
        Me.txtobservacion.MaxLength = 100
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(520, 42)
        Me.txtobservacion.TabIndex = 186
        Me.txtobservacion.Text = ""
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(96, 174)
        Me.Label27.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(173, 22)
        Me.Label27.TabIndex = 184
        Me.Label27.Text = "Stock Disponible :"
        '
        'txtcantidad
        '
        Appearance13.BackColor = System.Drawing.Color.Orange
        Me.txtcantidad.Appearance = Appearance13
        Me.txtcantidad.BackColor = System.Drawing.Color.Orange
        Me.txtcantidad.Location = New System.Drawing.Point(259, 208)
        Me.txtcantidad.Margin = New System.Windows.Forms.Padding(7, 4, 7, 4)
        Me.txtcantidad.MaxLength = 8
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(108, 29)
        Me.txtcantidad.TabIndex = 177
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(157, 211)
        Me.Label4.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 22)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Cantidad :"
        '
        'TsBtn_Cerrar
        '
        Me.TsBtn_Cerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsBtn_Cerrar.ForeColor = System.Drawing.Color.White
        Me.TsBtn_Cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.TsBtn_Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.TsBtn_Cerrar.Name = "TsBtn_Cerrar"
        Me.TsBtn_Cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.TsBtn_Cerrar.RightToLeftAutoMirrorImage = True
        Me.TsBtn_Cerrar.Size = New System.Drawing.Size(84, 30)
        Me.TsBtn_Cerrar.Tag = "3434"
        Me.TsBtn_Cerrar.Text = "Salir"
        Me.TsBtn_Cerrar.ToolTipText = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.btnGuardar.Tag = "343"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.TsBtn_Cerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(968, 40)
        Me.ToolStrip1.TabIndex = 180
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'txtstockdisponibleslimento
        '
        Me.txtstockdisponibleslimento.Location = New System.Drawing.Point(1514, 99)
        Me.txtstockdisponibleslimento.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtstockdisponibleslimento.Name = "txtstockdisponibleslimento"
        Me.txtstockdisponibleslimento.ReadOnly = True
        Me.txtstockdisponibleslimento.Size = New System.Drawing.Size(109, 27)
        Me.txtstockdisponibleslimento.TabIndex = 198
        Me.txtstockdisponibleslimento.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1257, 99)
        Me.Label3.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(259, 22)
        Me.Label3.TabIndex = 197
        Me.Label3.Text = "Stock Disponible Alimento :"
        Me.Label3.Visible = False
        '
        'txtcantidadalimento
        '
        Appearance14.BackColor = System.Drawing.Color.Orange
        Me.txtcantidadalimento.Appearance = Appearance14
        Me.txtcantidadalimento.BackColor = System.Drawing.Color.Orange
        Me.txtcantidadalimento.Location = New System.Drawing.Point(666, 208)
        Me.txtcantidadalimento.Margin = New System.Windows.Forms.Padding(7, 4, 7, 4)
        Me.txtcantidadalimento.MaxLength = 8
        Me.txtcantidadalimento.Name = "txtcantidadalimento"
        Me.txtcantidadalimento.Size = New System.Drawing.Size(108, 29)
        Me.txtcantidadalimento.TabIndex = 195
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(478, 211)
        Me.Label5.Margin = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 22)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "Cantidad SAC Eng. :"
        '
        'FrmPedidoTransferenciaCerdos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 346)
        Me.Controls.Add(Me.txtstockdisponibleslimento)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcantidadalimento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtstock)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtobservacion)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmPedidoTransferenciaCerdos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NUEVA TRANSFERENCIA DE CERDOS"
        CType(Me.dtpedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cbxmotivotransaccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.txtcantidadalimento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxplanteles As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents dtpedido As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label21 As Label
    Friend WithEvents txtstock As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxmotivotransaccion As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label9 As Label
    Friend WithEvents txtobservacion As RichTextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtcantidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label4 As Label
    Friend WithEvents TsBtn_Cerrar As ToolStripButton
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents cbxalmacendestino As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtstockdisponibleslimento As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcantidadalimento As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As Label
End Class
