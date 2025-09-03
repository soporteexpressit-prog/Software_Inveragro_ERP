<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBajaDerechoHabiento
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtapaternohijo = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtamaternohijo = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtnombrehijo = New System.Windows.Forms.TextBox()
        Me.lblContador1 = New System.Windows.Forms.Label()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtfechabaja = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxmotivodebaja = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.cbxmotivodebaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(674, 38)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.btnGuardar.Size = New System.Drawing.Size(89, 28)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTipText = "Guardar "
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCerrar.Size = New System.Drawing.Size(66, 28)
        Me.btnCerrar.Text = "Salir"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.Label44)
        Me.UltraGroupBox1.Controls.Add(Me.txtapaternohijo)
        Me.UltraGroupBox1.Controls.Add(Me.Label45)
        Me.UltraGroupBox1.Controls.Add(Me.txtamaternohijo)
        Me.UltraGroupBox1.Controls.Add(Me.Label46)
        Me.UltraGroupBox1.Controls.Add(Me.txtnombrehijo)
        Me.UltraGroupBox1.Controls.Add(Me.lblContador1)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(18, 38)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(623, 104)
        Me.UltraGroupBox1.TabIndex = 291
        Me.UltraGroupBox1.Text = "Datos del Familiar"
        Me.UltraGroupBox1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(331, 71)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(109, 13)
        Me.Label44.TabIndex = 289
        Me.Label44.Text = "Apellido materno:"
        '
        'txtapaternohijo
        '
        Me.txtapaternohijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapaternohijo.Enabled = False
        Me.txtapaternohijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtapaternohijo.Location = New System.Drawing.Point(142, 67)
        Me.txtapaternohijo.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtapaternohijo.MaxLength = 50
        Me.txtapaternohijo.Name = "txtapaternohijo"
        Me.txtapaternohijo.Size = New System.Drawing.Size(144, 21)
        Me.txtapaternohijo.TabIndex = 288
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(15, 71)
        Me.Label45.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(105, 13)
        Me.Label45.TabIndex = 287
        Me.Label45.Text = "Apellido Paterno:"
        '
        'txtamaternohijo
        '
        Me.txtamaternohijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtamaternohijo.Enabled = False
        Me.txtamaternohijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamaternohijo.Location = New System.Drawing.Point(460, 67)
        Me.txtamaternohijo.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtamaternohijo.MaxLength = 50
        Me.txtamaternohijo.Name = "txtamaternohijo"
        Me.txtamaternohijo.Size = New System.Drawing.Size(144, 21)
        Me.txtamaternohijo.TabIndex = 286
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(57, 32)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(63, 13)
        Me.Label46.TabIndex = 285
        Me.Label46.Text = "Nombres:"
        '
        'txtnombrehijo
        '
        Me.txtnombrehijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombrehijo.Enabled = False
        Me.txtnombrehijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombrehijo.Location = New System.Drawing.Point(142, 30)
        Me.txtnombrehijo.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.txtnombrehijo.MaxLength = 50
        Me.txtnombrehijo.Name = "txtnombrehijo"
        Me.txtnombrehijo.Size = New System.Drawing.Size(462, 21)
        Me.txtnombrehijo.TabIndex = 284
        '
        'lblContador1
        '
        Me.lblContador1.AutoSize = True
        Me.lblContador1.Location = New System.Drawing.Point(714, 141)
        Me.lblContador1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblContador1.Name = "lblContador1"
        Me.lblContador1.Size = New System.Drawing.Size(0, 15)
        Me.lblContador1.TabIndex = 192
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox2.Controls.Add(Me.Label2)
        Me.UltraGroupBox2.Controls.Add(Me.dtfechabaja)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.cbxmotivodebaja)
        Me.UltraGroupBox2.Controls.Add(Me.Label6)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(18, 154)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(623, 58)
        Me.UltraGroupBox2.TabIndex = 294
        Me.UltraGroupBox2.Text = "Razón de la baja"
        Me.UltraGroupBox2.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 297
        Me.Label2.Text = "Fecha de Baja"
        '
        'dtfechabaja
        '
        Me.dtfechabaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfechabaja.Location = New System.Drawing.Point(89, 24)
        Me.dtfechabaja.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtfechabaja.Name = "dtfechabaja"
        Me.dtfechabaja.Size = New System.Drawing.Size(110, 21)
        Me.dtfechabaja.TabIndex = 296
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(282, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Motivo de Baja"
        '
        'cbxmotivodebaja
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbxmotivodebaja.DisplayLayout.Appearance = Appearance1
        Me.cbxmotivodebaja.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cbxmotivodebaja.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.cbxmotivodebaja.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbxmotivodebaja.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.cbxmotivodebaja.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cbxmotivodebaja.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.cbxmotivodebaja.DisplayLayout.MaxColScrollRegions = 1
        Me.cbxmotivodebaja.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbxmotivodebaja.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cbxmotivodebaja.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.cbxmotivodebaja.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.cbxmotivodebaja.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.cbxmotivodebaja.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cbxmotivodebaja.DisplayLayout.Override.CellAppearance = Appearance8
        Me.cbxmotivodebaja.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.cbxmotivodebaja.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.cbxmotivodebaja.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.cbxmotivodebaja.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.cbxmotivodebaja.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cbxmotivodebaja.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.cbxmotivodebaja.DisplayLayout.Override.RowAppearance = Appearance11
        Me.cbxmotivodebaja.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbxmotivodebaja.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.cbxmotivodebaja.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cbxmotivodebaja.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cbxmotivodebaja.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cbxmotivodebaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxmotivodebaja.Location = New System.Drawing.Point(393, 24)
        Me.cbxmotivodebaja.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbxmotivodebaja.Name = "cbxmotivodebaja"
        Me.cbxmotivodebaja.Size = New System.Drawing.Size(211, 24)
        Me.cbxmotivodebaja.TabIndex = 294
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(714, 141)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 15)
        Me.Label6.TabIndex = 192
        '
        'FrmBajaDerechoHabiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(674, 228)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmBajaDerechoHabiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REVOCAR DERECHO DE HABIENTO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.cbxmotivodebaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblContador1 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents txtapaternohijo As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents txtamaternohijo As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents txtnombrehijo As TextBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtfechabaja As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxmotivodebaja As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label6 As Label
End Class
