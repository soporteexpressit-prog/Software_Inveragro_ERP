<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmControlExcedente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlExcedente))
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
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.ChkVisualizarxInsumo = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevoxRacion = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarxRacion = New System.Windows.Forms.ToolStripButton()
        Me.BtnNuevoxInsumo = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarxInsumo = New System.Windows.Forms.ToolStripButton()
        Me.btnExportarMolinoinexce = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dtgListadoInsumoExcedente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.dtgListadoInsumoExcedente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.BarraOpciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1283, 212)
        Me.Panel2.TabIndex = 9
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.ChkVisualizarxInsumo)
        Me.GrupoFiltros.Controls.Add(Me.btnBuscar)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaHasta)
        Me.GrupoFiltros.Controls.Add(Me.cmbEstado)
        Me.GrupoFiltros.Controls.Add(Me.Label4)
        Me.GrupoFiltros.Controls.Add(Me.Label1)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaDesde)
        Me.GrupoFiltros.Location = New System.Drawing.Point(15, 54)
        Me.GrupoFiltros.Margin = New System.Windows.Forms.Padding(2)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Padding = New System.Windows.Forms.Padding(2)
        Me.GrupoFiltros.Size = New System.Drawing.Size(1045, 103)
        Me.GrupoFiltros.TabIndex = 159
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros de Búsqueda"
        '
        'ChkVisualizarxInsumo
        '
        Me.ChkVisualizarxInsumo.AutoSize = True
        Me.ChkVisualizarxInsumo.Location = New System.Drawing.Point(863, 70)
        Me.ChkVisualizarxInsumo.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkVisualizarxInsumo.Name = "ChkVisualizarxInsumo"
        Me.ChkVisualizarxInsumo.Size = New System.Drawing.Size(161, 17)
        Me.ChkVisualizarxInsumo.TabIndex = 173
        Me.ChkVisualizarxInsumo.Text = "Visualizar Apartado x Insumo"
        Me.ChkVisualizarxInsumo.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(661, 46)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Padding = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.btnBuscar.Size = New System.Drawing.Size(92, 41)
        Me.btnBuscar.TabIndex = 170
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(133, 68)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(240, 21)
        Me.dtpFechaHasta.TabIndex = 167
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"REALIZADO", "CANCELADO"})
        Me.cmbEstado.Location = New System.Drawing.Point(466, 31)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(131, 21)
        Me.cmbEstado.TabIndex = 169
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(25, 70)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 14)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "Fecha Hasta :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(399, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Estado :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(22, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 14)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Fecha Desde :"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(133, 29)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(240, 21)
        Me.dtpFechaDesde.TabIndex = 166
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(30, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(337, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONTROL DE INSUMOS EXCEDENTES"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevoxRacion, Me.BtnCancelarxRacion, Me.BtnNuevoxInsumo, Me.BtnCancelarxInsumo, Me.btnExportarMolinoinexce, Me.btncerrar, Me.ToolStripButton1})
        Me.BarraOpciones.Location = New System.Drawing.Point(0, 174)
        Me.BarraOpciones.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BarraOpciones.Size = New System.Drawing.Size(1283, 38)
        Me.BarraOpciones.TabIndex = 52
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'BtnNuevoxRacion
        '
        Me.BtnNuevoxRacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevoxRacion.ForeColor = System.Drawing.Color.White
        Me.BtnNuevoxRacion.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.BtnNuevoxRacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoxRacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnNuevoxRacion.Name = "BtnNuevoxRacion"
        Me.BtnNuevoxRacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnNuevoxRacion.Size = New System.Drawing.Size(163, 28)
        Me.BtnNuevoxRacion.Text = "Excedente x Ración"
        Me.BtnNuevoxRacion.ToolTipText = "Nuevo "
        '
        'BtnCancelarxRacion
        '
        Me.BtnCancelarxRacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarxRacion.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarxRacion.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.BtnCancelarxRacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarxRacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarxRacion.Name = "BtnCancelarxRacion"
        Me.BtnCancelarxRacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarxRacion.Size = New System.Drawing.Size(93, 28)
        Me.BtnCancelarxRacion.Text = "Cancelar"
        '
        'BtnNuevoxInsumo
        '
        Me.BtnNuevoxInsumo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevoxInsumo.ForeColor = System.Drawing.Color.White
        Me.BtnNuevoxInsumo.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.BtnNuevoxInsumo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoxInsumo.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnNuevoxInsumo.Name = "BtnNuevoxInsumo"
        Me.BtnNuevoxInsumo.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnNuevoxInsumo.Size = New System.Drawing.Size(168, 28)
        Me.BtnNuevoxInsumo.Text = "Excedente x Insumo"
        Me.BtnNuevoxInsumo.ToolTipText = "Nuevo "
        '
        'BtnCancelarxInsumo
        '
        Me.BtnCancelarxInsumo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarxInsumo.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarxInsumo.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.BtnCancelarxInsumo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarxInsumo.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarxInsumo.Name = "BtnCancelarxInsumo"
        Me.BtnCancelarxInsumo.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarxInsumo.Size = New System.Drawing.Size(93, 28)
        Me.BtnCancelarxInsumo.Text = "Cancelar"
        '
        'btnExportarMolinoinexce
        '
        Me.btnExportarMolinoinexce.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportarMolinoinexce.ForeColor = System.Drawing.Color.White
        Me.btnExportarMolinoinexce.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnExportarMolinoinexce.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportarMolinoinexce.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExportarMolinoinexce.Name = "btnExportarMolinoinexce"
        Me.btnExportarMolinoinexce.Padding = New System.Windows.Forms.Padding(2)
        Me.btnExportarMolinoinexce.Size = New System.Drawing.Size(92, 28)
        Me.btnExportarMolinoinexce.Text = "Exportar"
        Me.btnExportarMolinoinexce.ToolTipText = "Exportar"
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
        Me.btncerrar.Size = New System.Drawing.Size(66, 28)
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
        Me.ToolStripButton1.Size = New System.Drawing.Size(77, 28)
        Me.ToolStripButton1.Text = "Filtros"
        '
        'dtgListadoInsumoExcedente
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.FontData.Name = "Verdana"
        Me.dtgListadoInsumoExcedente.DisplayLayout.Appearance = Appearance1
        Me.dtgListadoInsumoExcedente.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoInsumoExcedente.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoInsumoExcedente.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoInsumoExcedente.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dtgListadoInsumoExcedente.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListadoInsumoExcedente.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListadoInsumoExcedente.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dtgListadoInsumoExcedente.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListadoInsumoExcedente.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.CellPadding = 0
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.AliceBlue
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.White
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.RowPreviewAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.RowSelectorAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Navy
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance14
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListadoInsumoExcedente.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dtgListadoInsumoExcedente.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListadoInsumoExcedente.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListadoInsumoExcedente.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListadoInsumoExcedente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListadoInsumoExcedente.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListadoInsumoExcedente.Location = New System.Drawing.Point(0, 212)
        Me.dtgListadoInsumoExcedente.Name = "dtgListadoInsumoExcedente"
        Me.dtgListadoInsumoExcedente.Size = New System.Drawing.Size(1283, 448)
        Me.dtgListadoInsumoExcedente.TabIndex = 29
        Me.dtgListadoInsumoExcedente.Text = "UltraGrid1"
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(622, 376)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 30
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'BackgroundWorker1
        '
        '
        'FrmControlExcedente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 660)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListadoInsumoExcedente)
        Me.Controls.Add(Me.Panel2)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmControlExcedente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE EXCEDENTES"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.dtgListadoInsumoExcedente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents BarraOpciones As ToolStrip
    Friend WithEvents btnExportarMolinoinexce As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents dtgListadoInsumoExcedente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnBuscar As Button
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents BtnNuevoxRacion As ToolStripButton
    Friend WithEvents BtnCancelarxRacion As ToolStripButton
    Friend WithEvents ChkVisualizarxInsumo As CheckBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BtnNuevoxInsumo As ToolStripButton
    Friend WithEvents BtnCancelarxInsumo As ToolStripButton
End Class
