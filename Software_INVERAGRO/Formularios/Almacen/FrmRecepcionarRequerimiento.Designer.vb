<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecepcionarRequerimiento
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TsBtn_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cktodo = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtobservacion = New System.Windows.Forms.RichTextBox()
        Me.dtfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtcantrecibido = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtcantidadpedido = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtproducto = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dtglistado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtcantrecibido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcantidadpedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtglistado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.TsBtn_Cerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(741, 38)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Size = New System.Drawing.Size(83, 28)
        Me.btnGuardar.Tag = "343"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'TsBtn_Cerrar
        '
        Me.TsBtn_Cerrar.ForeColor = System.Drawing.Color.White
        Me.TsBtn_Cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.TsBtn_Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.TsBtn_Cerrar.Name = "TsBtn_Cerrar"
        Me.TsBtn_Cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.TsBtn_Cerrar.Size = New System.Drawing.Size(61, 28)
        Me.TsBtn_Cerrar.Tag = "3434"
        Me.TsBtn_Cerrar.Text = "Salir"
        Me.TsBtn_Cerrar.ToolTipText = "Cerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cktodo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtobservacion)
        Me.GroupBox1.Controls.Add(Me.dtfecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 128)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'cktodo
        '
        Me.cktodo.AutoSize = True
        Me.cktodo.BackColor = System.Drawing.Color.White
        Me.cktodo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cktodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.cktodo.Location = New System.Drawing.Point(471, 37)
        Me.cktodo.Name = "cktodo"
        Me.cktodo.Size = New System.Drawing.Size(159, 18)
        Me.cktodo.TabIndex = 49
        Me.cktodo.Text = "Recepción Completa"
        Me.cktodo.UseVisualStyleBackColor = False
        Me.cktodo.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(41, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 14)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Observación :"
        '
        'txtobservacion
        '
        Me.txtobservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobservacion.Location = New System.Drawing.Point(141, 74)
        Me.txtobservacion.MaxLength = 150
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(489, 37)
        Me.txtobservacion.TabIndex = 47
        Me.txtobservacion.Text = "NINGUNO"
        '
        'dtfecha
        '
        Me.dtfecha.Location = New System.Drawing.Point(141, 34)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.Size = New System.Drawing.Size(260, 21)
        Me.dtfecha.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(15, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 14)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Fecha Recepción :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnagregar)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtcantrecibido)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtcantidadpedido)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtproducto)
        Me.GroupBox3.Controls.Add(Me.dtglistado)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(11, 173)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(709, 434)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle de Productos"
        '
        'btnagregar
        '
        Me.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnagregar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregar.Image = Global.Formularios.My.Resources.Resources.Agregar_24_Px
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregar.Location = New System.Drawing.Point(497, 15)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(85, 34)
        Me.btnagregar.TabIndex = 184
        Me.btnagregar.Text = "Añadir"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(283, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 14)
        Me.Label7.TabIndex = 183
        Me.Label7.Text = "Cant.Recibido :"
        '
        'txtcantrecibido
        '
        Appearance1.BackColor = System.Drawing.Color.Orange
        Me.txtcantrecibido.Appearance = Appearance1
        Me.txtcantrecibido.BackColor = System.Drawing.Color.Orange
        Me.txtcantrecibido.Location = New System.Drawing.Point(391, 49)
        Me.txtcantrecibido.MaxLength = 8
        Me.txtcantrecibido.Name = "txtcantrecibido"
        Me.txtcantrecibido.Size = New System.Drawing.Size(100, 23)
        Me.txtcantrecibido.TabIndex = 182
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(40, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 14)
        Me.Label9.TabIndex = 181
        Me.Label9.Text = "Cant.Pedido :"
        '
        'txtcantidadpedido
        '
        Me.txtcantidadpedido.Location = New System.Drawing.Point(139, 49)
        Me.txtcantidadpedido.MaxLength = 8
        Me.txtcantidadpedido.Name = "txtcantidadpedido"
        Me.txtcantidadpedido.ReadOnly = True
        Me.txtcantidadpedido.Size = New System.Drawing.Size(94, 23)
        Me.txtcantidadpedido.TabIndex = 180
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(62, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 14)
        Me.Label10.TabIndex = 179
        Me.Label10.Text = "Producto :"
        '
        'txtproducto
        '
        Appearance2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtproducto.Appearance = Appearance2
        Me.txtproducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtproducto.Location = New System.Drawing.Point(140, 20)
        Me.txtproducto.Name = "txtproducto"
        Me.txtproducto.ReadOnly = True
        Me.txtproducto.Size = New System.Drawing.Size(352, 23)
        Me.txtproducto.TabIndex = 178
        Me.txtproducto.TabStop = False
        '
        'dtglistado
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.SystemColors.InfoText
        Appearance3.BorderColor2 = System.Drawing.Color.Silver
        Appearance3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dtglistado.DisplayLayout.Appearance = Appearance3
        Me.dtglistado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.dtglistado.DisplayLayout.CaptionAppearance = Appearance4
        Me.dtglistado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.dtglistado.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtglistado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.dtglistado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtglistado.DisplayLayout.GroupByBox.Hidden = True
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtglistado.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.dtglistado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtglistado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.InfoText
        Appearance8.ForeColor = System.Drawing.Color.White
        Me.dtglistado.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance9.BackColor2 = System.Drawing.Color.Silver
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.ForeColor = System.Drawing.Color.White
        Me.dtglistado.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.dtglistado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtglistado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.dtglistado.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtglistado.DisplayLayout.Override.CellAppearance = Appearance11
        Me.dtglistado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtglistado.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.dtglistado.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.dtglistado.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.dtglistado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtglistado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.dtglistado.DisplayLayout.Override.RowAppearance = Appearance14
        Me.dtglistado.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dtglistado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.dtglistado.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.None
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtglistado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dtglistado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtglistado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtglistado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtglistado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtglistado.Location = New System.Drawing.Point(3, 102)
        Me.dtglistado.Name = "dtglistado"
        Me.dtglistado.Size = New System.Drawing.Size(703, 329)
        Me.dtglistado.TabIndex = 49
        '
        'FrmRecepcionarRequerimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(741, 618)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmRecepcionarRequerimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RECEPCIONAR REQUERIMIENTO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtcantrecibido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcantidadpedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtglistado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents TsBtn_Cerrar As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cktodo As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtobservacion As RichTextBox
    Friend WithEvents dtfecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnagregar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtcantrecibido As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label9 As Label
    Friend WithEvents txtcantidadpedido As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label10 As Label
    Friend WithEvents txtproducto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dtglistado As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
