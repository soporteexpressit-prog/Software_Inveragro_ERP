<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlRacion
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.btnGestionAntiNctrra = New System.Windows.Forms.ToolStripButton()
        Me.btnVincularQuitarAntiNctrra = New System.Windows.Forms.ToolStripButton()
        Me.btnGestionPlanMedicadoNctrra = New System.Windows.Forms.ToolStripButton()
        Me.btnQuitarPlanMedicadoNctrra = New System.Windows.Forms.ToolStripButton()
        Me.btnExportarNctrra = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.BarraOpciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1779, 145)
        Me.Panel2.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(44, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(472, 29)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "CONTROL DE RACIONES Y EXTRAS"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGestionAntiNctrra, Me.btnVincularQuitarAntiNctrra, Me.btnGestionPlanMedicadoNctrra, Me.btnQuitarPlanMedicadoNctrra, Me.btnExportarNctrra, Me.btnCerrar})
        Me.BarraOpciones.Location = New System.Drawing.Point(0, 105)
        Me.BarraOpciones.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.BarraOpciones.Size = New System.Drawing.Size(1779, 40)
        Me.BarraOpciones.TabIndex = 52
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'btnGestionAntiNctrra
        '
        Me.btnGestionAntiNctrra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGestionAntiNctrra.ForeColor = System.Drawing.Color.White
        Me.btnGestionAntiNctrra.Image = Global.Formularios.My.Resources.Resources.informe_medico__1_
        Me.btnGestionAntiNctrra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGestionAntiNctrra.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGestionAntiNctrra.Name = "btnGestionAntiNctrra"
        Me.btnGestionAntiNctrra.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGestionAntiNctrra.Size = New System.Drawing.Size(162, 30)
        Me.btnGestionAntiNctrra.Text = "Gestión Anti"
        '
        'btnVincularQuitarAntiNctrra
        '
        Me.btnVincularQuitarAntiNctrra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVincularQuitarAntiNctrra.ForeColor = System.Drawing.Color.White
        Me.btnVincularQuitarAntiNctrra.Image = Global.Formularios.My.Resources.Resources.medicamentos
        Me.btnVincularQuitarAntiNctrra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVincularQuitarAntiNctrra.Margin = New System.Windows.Forms.Padding(5)
        Me.btnVincularQuitarAntiNctrra.Name = "btnVincularQuitarAntiNctrra"
        Me.btnVincularQuitarAntiNctrra.Padding = New System.Windows.Forms.Padding(2)
        Me.btnVincularQuitarAntiNctrra.Size = New System.Drawing.Size(256, 30)
        Me.btnVincularQuitarAntiNctrra.Text = "Vincular / Quitar Anti"
        '
        'btnGestionPlanMedicadoNctrra
        '
        Me.btnGestionPlanMedicadoNctrra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGestionPlanMedicadoNctrra.ForeColor = System.Drawing.Color.White
        Me.btnGestionPlanMedicadoNctrra.Image = Global.Formularios.My.Resources.Resources.informe_medico__1_
        Me.btnGestionPlanMedicadoNctrra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGestionPlanMedicadoNctrra.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGestionPlanMedicadoNctrra.Name = "btnGestionPlanMedicadoNctrra"
        Me.btnGestionPlanMedicadoNctrra.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGestionPlanMedicadoNctrra.Size = New System.Drawing.Size(267, 30)
        Me.btnGestionPlanMedicadoNctrra.Text = "Gestión Plan Medicado"
        '
        'btnQuitarPlanMedicadoNctrra
        '
        Me.btnQuitarPlanMedicadoNctrra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarPlanMedicadoNctrra.ForeColor = System.Drawing.Color.White
        Me.btnQuitarPlanMedicadoNctrra.Image = Global.Formularios.My.Resources.Resources.medicamentos
        Me.btnQuitarPlanMedicadoNctrra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuitarPlanMedicadoNctrra.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuitarPlanMedicadoNctrra.Name = "btnQuitarPlanMedicadoNctrra"
        Me.btnQuitarPlanMedicadoNctrra.Padding = New System.Windows.Forms.Padding(2)
        Me.btnQuitarPlanMedicadoNctrra.Size = New System.Drawing.Size(253, 30)
        Me.btnQuitarPlanMedicadoNctrra.Text = "Quitar Plan Medicado"
        '
        'btnExportarNctrra
        '
        Me.btnExportarNctrra.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarNctrra.ForeColor = System.Drawing.Color.White
        Me.btnExportarNctrra.Image = Global.Formularios.My.Resources.Resources.Exportar24px
        Me.btnExportarNctrra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportarNctrra.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExportarNctrra.Name = "btnExportarNctrra"
        Me.btnExportarNctrra.Padding = New System.Windows.Forms.Padding(2)
        Me.btnExportarNctrra.Size = New System.Drawing.Size(125, 30)
        Me.btnExportarNctrra.Text = "Exportar"
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
        Me.btnCerrar.Size = New System.Drawing.Size(84, 30)
        Me.btnCerrar.Text = "Salir"
        '
        'dtgListado
        '
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 145)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1779, 893)
        Me.dtgListado.TabIndex = 26
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(864, 525)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 29
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlRacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1779, 1038)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmControlRacion"
        Me.Text = "CONTROL DE RACIONES Y EXTRAS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BarraOpciones As ToolStrip
    Friend WithEvents btnVincularQuitarAntiNctrra As ToolStripButton
    Friend WithEvents btnGestionAntiNctrra As ToolStripButton
    Friend WithEvents btnExportarNctrra As ToolStripButton
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnGestionPlanMedicadoNctrra As ToolStripButton
    Friend WithEvents btnQuitarPlanMedicadoNctrra As ToolStripButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Ptbx_Cargando As PictureBox
End Class
