<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistoricoCerda
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblEtapa = New System.Windows.Forms.Label()
        Me.LblCodArete = New System.Windows.Forms.Label()
        Me.LblEtapaAnimal = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DtgListadoHistorico = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.CbxResponsables = New System.Windows.Forms.CheckBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DtgListadoHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.CbxResponsables)
        Me.Panel2.Controls.Add(Me.LblEtapa)
        Me.Panel2.Controls.Add(Me.LblCodArete)
        Me.Panel2.Controls.Add(Me.LblEtapaAnimal)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(855, 666)
        Me.Panel2.TabIndex = 9
        '
        'LblEtapa
        '
        Me.LblEtapa.AutoSize = True
        Me.LblEtapa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblEtapa.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtapa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblEtapa.Location = New System.Drawing.Point(107, 90)
        Me.LblEtapa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEtapa.Name = "LblEtapa"
        Me.LblEtapa.Size = New System.Drawing.Size(42, 18)
        Me.LblEtapa.TabIndex = 216
        Me.LblEtapa.Text = "- - -"
        '
        'LblCodArete
        '
        Me.LblCodArete.AutoSize = True
        Me.LblCodArete.BackColor = System.Drawing.Color.Yellow
        Me.LblCodArete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodArete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCodArete.Location = New System.Drawing.Point(107, 53)
        Me.LblCodArete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCodArete.Name = "LblCodArete"
        Me.LblCodArete.Size = New System.Drawing.Size(42, 18)
        Me.LblCodArete.TabIndex = 215
        Me.LblCodArete.Text = "- - -"
        '
        'LblEtapaAnimal
        '
        Me.LblEtapaAnimal.AutoSize = True
        Me.LblEtapaAnimal.BackColor = System.Drawing.Color.Transparent
        Me.LblEtapaAnimal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEtapaAnimal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblEtapaAnimal.Location = New System.Drawing.Point(37, 92)
        Me.LblEtapaAnimal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblEtapaAnimal.Name = "LblEtapaAnimal"
        Me.LblEtapaAnimal.Size = New System.Drawing.Size(53, 14)
        Me.LblEtapaAnimal.TabIndex = 193
        Me.LblEtapaAnimal.Text = "Etapa :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(39, 55)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 14)
        Me.Label23.TabIndex = 192
        Me.Label23.Text = "Arete :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DtgListadoHistorico)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 133)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(839, 526)
        Me.GroupBox2.TabIndex = 161
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Historial"
        '
        'DtgListadoHistorico
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.FontData.Name = "Verdana"
        Me.DtgListadoHistorico.DisplayLayout.Appearance = Appearance1
        Me.DtgListadoHistorico.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DtgListadoHistorico.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.DtgListadoHistorico.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DtgListadoHistorico.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.DtgListadoHistorico.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DtgListadoHistorico.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DtgListadoHistorico.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.DtgListadoHistorico.DisplayLayout.MaxColScrollRegions = 1
        Me.DtgListadoHistorico.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DtgListadoHistorico.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.DtgListadoHistorico.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.DtgListadoHistorico.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DtgListadoHistorico.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.DtgListadoHistorico.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DtgListadoHistorico.DisplayLayout.Override.CellAppearance = Appearance8
        Me.DtgListadoHistorico.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DtgListadoHistorico.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.DtgListadoHistorico.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.AliceBlue
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Me.DtgListadoHistorico.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.DtgListadoHistorico.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DtgListadoHistorico.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.DtgListadoHistorico.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.White
        Me.DtgListadoHistorico.DisplayLayout.Override.RowPreviewAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.DtgListadoHistorico.DisplayLayout.Override.RowSelectorAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Navy
        Me.DtgListadoHistorico.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance14
        Me.DtgListadoHistorico.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DtgListadoHistorico.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.DtgListadoHistorico.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DtgListadoHistorico.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DtgListadoHistorico.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DtgListadoHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DtgListadoHistorico.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgListadoHistorico.Location = New System.Drawing.Point(2, 15)
        Me.DtgListadoHistorico.Name = "DtgListadoHistorico"
        Me.DtgListadoHistorico.Size = New System.Drawing.Size(835, 509)
        Me.DtgListadoHistorico.TabIndex = 175
        Me.DtgListadoHistorico.Text = "UltraGrid1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(855, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'CbxResponsables
        '
        Me.CbxResponsables.AutoSize = True
        Me.CbxResponsables.Location = New System.Drawing.Point(713, 85)
        Me.CbxResponsables.Name = "CbxResponsables"
        Me.CbxResponsables.Size = New System.Drawing.Size(93, 17)
        Me.CbxResponsables.TabIndex = 217
        Me.CbxResponsables.Text = "Responsables"
        Me.CbxResponsables.UseVisualStyleBackColor = True
        '
        'FrmHistoricoCerda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 666)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHistoricoCerda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORICO DE CERDA"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DtgListadoHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DtgListadoHistorico As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents LblEtapaAnimal As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents LblCodArete As Label
    Friend WithEvents LblEtapa As Label
    Friend WithEvents CbxResponsables As CheckBox
End Class
