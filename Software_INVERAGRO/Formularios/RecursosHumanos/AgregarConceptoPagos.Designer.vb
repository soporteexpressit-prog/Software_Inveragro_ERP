<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarConceptoPagos
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdescripcionconcepto = New System.Windows.Forms.TextBox()
        Me.cbxTipoConcepto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrupoMasOpcionesBusqueda = New Infragistics.Win.Misc.UltraGroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevoContabilidadbancos = New System.Windows.Forms.ToolStripButton()
        Me.btnEditarContabilidadbancos = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardarContabilidadbancos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "Descripcion:"
        '
        'txtdescripcionconcepto
        '
        Me.txtdescripcionconcepto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtdescripcionconcepto.Location = New System.Drawing.Point(115, 53)
        Me.txtdescripcionconcepto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtdescripcionconcepto.Name = "txtdescripcionconcepto"
        Me.txtdescripcionconcepto.Size = New System.Drawing.Size(391, 21)
        Me.txtdescripcionconcepto.TabIndex = 200
        '
        'cbxTipoConcepto
        '
        Me.cbxTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTipoConcepto.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.cbxTipoConcepto.FormattingEnabled = True
        Me.cbxTipoConcepto.Items.AddRange(New Object() {"INGRESO BASE", "DESCUENTO BASE", "APORTE EMPLEADOR", "INGRESO EXTRA", "DESCUENTO EXTRA"})
        Me.cbxTipoConcepto.Location = New System.Drawing.Point(115, 24)
        Me.cbxTipoConcepto.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cbxTipoConcepto.Name = "cbxTipoConcepto"
        Me.cbxTipoConcepto.Size = New System.Drawing.Size(232, 21)
        Me.cbxTipoConcepto.TabIndex = 202
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(52, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 14)
        Me.Label2.TabIndex = 203
        Me.Label2.Text = "Tipo:"
        '
        'GrupoMasOpcionesBusqueda
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance2.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.ContentAreaAppearance = Appearance2
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.GroupBox1)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label6)
        Me.GrupoMasOpcionesBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrupoMasOpcionesBusqueda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BackColor2 = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.BorderColor2 = System.Drawing.Color.White
        Appearance3.BorderColor3DBase = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.Name = "Segoe UI"
        Appearance3.FontData.SizeInPoints = 10.0!
        Appearance3.ForeColor = System.Drawing.Color.White
        Me.GrupoMasOpcionesBusqueda.HeaderAppearance = Appearance3
        Me.GrupoMasOpcionesBusqueda.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.GrupoMasOpcionesBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.GrupoMasOpcionesBusqueda.Margin = New System.Windows.Forms.Padding(2)
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(890, 134)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 204
        Me.GrupoMasOpcionesBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtdescripcionconcepto)
        Me.GroupBox1.Controls.Add(Me.cbxTipoConcepto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(653, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(11, 9)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONCEPTOS"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevoContabilidadbancos, Me.btnEditarContabilidadbancos, Me.btnCancelar, Me.btnGuardarContabilidadbancos, Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 134)
        Me.ToolStrip2.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip2.Size = New System.Drawing.Size(890, 38)
        Me.ToolStrip2.TabIndex = 208
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnNuevoContabilidadbancos
        '
        Me.btnNuevoContabilidadbancos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoContabilidadbancos.ForeColor = System.Drawing.Color.White
        Me.btnNuevoContabilidadbancos.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnNuevoContabilidadbancos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevoContabilidadbancos.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevoContabilidadbancos.Name = "btnNuevoContabilidadbancos"
        Me.btnNuevoContabilidadbancos.Padding = New System.Windows.Forms.Padding(2)
        Me.btnNuevoContabilidadbancos.Size = New System.Drawing.Size(81, 28)
        Me.btnNuevoContabilidadbancos.Text = "Nuevo "
        Me.btnNuevoContabilidadbancos.ToolTipText = "Nuevo "
        '
        'btnEditarContabilidadbancos
        '
        Me.btnEditarContabilidadbancos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditarContabilidadbancos.ForeColor = System.Drawing.Color.White
        Me.btnEditarContabilidadbancos.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btnEditarContabilidadbancos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditarContabilidadbancos.Margin = New System.Windows.Forms.Padding(5)
        Me.btnEditarContabilidadbancos.Name = "btnEditarContabilidadbancos"
        Me.btnEditarContabilidadbancos.Padding = New System.Windows.Forms.Padding(2)
        Me.btnEditarContabilidadbancos.Size = New System.Drawing.Size(74, 28)
        Me.btnEditarContabilidadbancos.Text = "Editar"
        Me.btnEditarContabilidadbancos.ToolTipText = "Editar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCancelar.Size = New System.Drawing.Size(93, 28)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar"
        Me.btnCancelar.Visible = False
        '
        'btnGuardarContabilidadbancos
        '
        Me.btnGuardarContabilidadbancos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarContabilidadbancos.ForeColor = System.Drawing.Color.White
        Me.btnGuardarContabilidadbancos.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardarContabilidadbancos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardarContabilidadbancos.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardarContabilidadbancos.Name = "btnGuardarContabilidadbancos"
        Me.btnGuardarContabilidadbancos.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardarContabilidadbancos.Size = New System.Drawing.Size(89, 28)
        Me.btnGuardarContabilidadbancos.Text = "Guardar"
        Me.btnGuardarContabilidadbancos.ToolTipText = "Guardar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.Formularios.My.Resources.Resources.salir
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1.Size = New System.Drawing.Size(66, 28)
        Me.ToolStripButton1.Text = "Salir"
        Me.ToolStripButton1.ToolTipText = "Salir"
        '
        'dtgListado
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance4.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance4
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.Color.Navy
        Appearance9.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance11
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.AliceBlue
        Appearance13.BackColor2 = System.Drawing.Color.Silver
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance17
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 172)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(890, 500)
        Me.dtgListado.TabIndex = 209
        Me.dtgListado.Text = "UltraGrid1"
        '
        'AgregarConceptoPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(890, 672)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.Name = "AgregarConceptoPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AGREGAR CONCEPTO"
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoMasOpcionesBusqueda.ResumeLayout(False)
        Me.GrupoMasOpcionesBusqueda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtdescripcionconcepto As TextBox
    Friend WithEvents cbxTipoConcepto As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GrupoMasOpcionesBusqueda As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnNuevoContabilidadbancos As ToolStripButton
    Friend WithEvents btnEditarContabilidadbancos As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents btnGuardarContabilidadbancos As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
End Class
