<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlFormula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmControlFormula))
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.CmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.BtnNutricionista = New System.Windows.Forms.ToolStripButton()
        Me.BtnAccesoVisualizacion = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevaNucleoNctrfor = New System.Windows.Forms.ToolStripButton()
        Me.btnInsumosNctrfor = New System.Windows.Forms.ToolStripButton()
        Me.btnCrearFormulaNctrfor = New System.Windows.Forms.ToolStripButton()
        Me.btnAsignarFormulaNctrfor = New System.Windows.Forms.ToolStripButton()
        Me.BtnVerFormulamolinocontrolformula = New System.Windows.Forms.ToolStripButton()
        Me.BtnRacionesAsignadasMolinocontrolform = New System.Windows.Forms.ToolStripButton()
        Me.BtnActivar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCancelarnutricionmodulo = New System.Windows.Forms.ToolStripButton()
        Me.btnexportarNctrfor = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        Me.BarraOpciones.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.BarraOpciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2120, 310)
        Me.Panel2.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(39, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(340, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CONTROL DE FÓRMULAS"
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.Label1)
        Me.GrupoFiltros.Controls.Add(Me.BtnBuscar)
        Me.GrupoFiltros.Controls.Add(Me.CmbEstado)
        Me.GrupoFiltros.Controls.Add(Me.Label4)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaHasta)
        Me.GrupoFiltros.Controls.Add(Me.dtpFechaDesde)
        Me.GrupoFiltros.Location = New System.Drawing.Point(25, 89)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Size = New System.Drawing.Size(1293, 148)
        Me.GrupoFiltros.TabIndex = 169
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros de Búsqueda"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(690, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 22)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "Estado :"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscar.Location = New System.Drawing.Point(1101, 56)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.BtnBuscar.Size = New System.Drawing.Size(138, 62)
        Me.BtnBuscar.TabIndex = 162
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'CmbEstado
        '
        Me.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbEstado.FormattingEnabled = True
        Me.CmbEstado.Items.AddRange(New Object() {"ACTIVO", "FINALIZADO", "CANCELADO"})
        Me.CmbEstado.Location = New System.Drawing.Point(796, 48)
        Me.CmbEstado.Name = "CmbEstado"
        Me.CmbEstado.Size = New System.Drawing.Size(166, 28)
        Me.CmbEstado.TabIndex = 164
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(53, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 22)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fecha Hasta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(47, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Fecha Desde:"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(214, 90)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(358, 28)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(214, 48)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(358, 28)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(513, 293)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(8, 8)
        Me.GroupBox1.TabIndex = 168
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraOpciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNutricionista, Me.BtnAccesoVisualizacion, Me.btnNuevaNucleoNctrfor, Me.btnInsumosNctrfor, Me.btnCrearFormulaNctrfor, Me.btnAsignarFormulaNctrfor, Me.BtnVerFormulamolinocontrolformula, Me.BtnRacionesAsignadasMolinocontrolform, Me.BtnActivar, Me.BtnCancelarnutricionmodulo, Me.btnexportarNctrfor})
        Me.BarraOpciones.Location = New System.Drawing.Point(0, 270)
        Me.BarraOpciones.Margin = New System.Windows.Forms.Padding(3)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.BarraOpciones.Size = New System.Drawing.Size(2120, 40)
        Me.BarraOpciones.TabIndex = 52
        Me.BarraOpciones.Text = "ToolStrip1"
        '
        'BtnNutricionista
        '
        Me.BtnNutricionista.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNutricionista.ForeColor = System.Drawing.Color.White
        Me.BtnNutricionista.Image = Global.Formularios.My.Resources.Resources.saco
        Me.BtnNutricionista.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNutricionista.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnNutricionista.Name = "BtnNutricionista"
        Me.BtnNutricionista.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnNutricionista.Size = New System.Drawing.Size(168, 30)
        Me.BtnNutricionista.Text = "Nutricionista"
        '
        'BtnAccesoVisualizacion
        '
        Me.BtnAccesoVisualizacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAccesoVisualizacion.ForeColor = System.Drawing.Color.White
        Me.BtnAccesoVisualizacion.Image = Global.Formularios.My.Resources.Resources.ver24px
        Me.BtnAccesoVisualizacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAccesoVisualizacion.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnAccesoVisualizacion.Name = "BtnAccesoVisualizacion"
        Me.BtnAccesoVisualizacion.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnAccesoVisualizacion.Size = New System.Drawing.Size(270, 30)
        Me.BtnAccesoVisualizacion.Text = "Ver Ración x Ubicación"
        '
        'btnNuevaNucleoNctrfor
        '
        Me.btnNuevaNucleoNctrfor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaNucleoNctrfor.ForeColor = System.Drawing.Color.White
        Me.btnNuevaNucleoNctrfor.Image = Global.Formularios.My.Resources.Resources.saco
        Me.btnNuevaNucleoNctrfor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevaNucleoNctrfor.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevaNucleoNctrfor.Name = "btnNuevaNucleoNctrfor"
        Me.btnNuevaNucleoNctrfor.Padding = New System.Windows.Forms.Padding(2)
        Me.btnNuevaNucleoNctrfor.Size = New System.Drawing.Size(263, 30)
        Me.btnNuevaNucleoNctrfor.Text = "Mantenimiento Ración"
        '
        'btnInsumosNctrfor
        '
        Me.btnInsumosNctrfor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsumosNctrfor.ForeColor = System.Drawing.Color.White
        Me.btnInsumosNctrfor.Image = Global.Formularios.My.Resources.Resources.gestion_insumos2
        Me.btnInsumosNctrfor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInsumosNctrfor.Margin = New System.Windows.Forms.Padding(5)
        Me.btnInsumosNctrfor.Name = "btnInsumosNctrfor"
        Me.btnInsumosNctrfor.Padding = New System.Windows.Forms.Padding(2)
        Me.btnInsumosNctrfor.Size = New System.Drawing.Size(241, 30)
        Me.btnInsumosNctrfor.Text = "Gestión de Insumos"
        '
        'btnCrearFormulaNctrfor
        '
        Me.btnCrearFormulaNctrfor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearFormulaNctrfor.ForeColor = System.Drawing.Color.White
        Me.btnCrearFormulaNctrfor.Image = Global.Formularios.My.Resources.Resources.formula
        Me.btnCrearFormulaNctrfor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCrearFormulaNctrfor.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCrearFormulaNctrfor.Name = "btnCrearFormulaNctrfor"
        Me.btnCrearFormulaNctrfor.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCrearFormulaNctrfor.Size = New System.Drawing.Size(191, 30)
        Me.btnCrearFormulaNctrfor.Text = "Nueva Fórmula"
        '
        'btnAsignarFormulaNctrfor
        '
        Me.btnAsignarFormulaNctrfor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignarFormulaNctrfor.ForeColor = System.Drawing.Color.White
        Me.btnAsignarFormulaNctrfor.Image = Global.Formularios.My.Resources.Resources.scale
        Me.btnAsignarFormulaNctrfor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAsignarFormulaNctrfor.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAsignarFormulaNctrfor.Name = "btnAsignarFormulaNctrfor"
        Me.btnAsignarFormulaNctrfor.Padding = New System.Windows.Forms.Padding(2)
        Me.btnAsignarFormulaNctrfor.Size = New System.Drawing.Size(116, 30)
        Me.btnAsignarFormulaNctrfor.Text = "Asignar"
        '
        'BtnVerFormulamolinocontrolformula
        '
        Me.BtnVerFormulamolinocontrolformula.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVerFormulamolinocontrolformula.ForeColor = System.Drawing.Color.White
        Me.BtnVerFormulamolinocontrolformula.Image = Global.Formularios.My.Resources.Resources.ver24px
        Me.BtnVerFormulamolinocontrolformula.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVerFormulamolinocontrolformula.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnVerFormulamolinocontrolformula.Name = "BtnVerFormulamolinocontrolformula"
        Me.BtnVerFormulamolinocontrolformula.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnVerFormulamolinocontrolformula.Size = New System.Drawing.Size(189, 30)
        Me.BtnVerFormulamolinocontrolformula.Text = "Fórmula/Costo"
        Me.BtnVerFormulamolinocontrolformula.ToolTipText = "Ver Fórmula"
        '
        'BtnRacionesAsignadasMolinocontrolform
        '
        Me.BtnRacionesAsignadasMolinocontrolform.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRacionesAsignadasMolinocontrolform.ForeColor = System.Drawing.Color.White
        Me.BtnRacionesAsignadasMolinocontrolform.Image = Global.Formularios.My.Resources.Resources.asignar__1_
        Me.BtnRacionesAsignadasMolinocontrolform.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRacionesAsignadasMolinocontrolform.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnRacionesAsignadasMolinocontrolform.Name = "BtnRacionesAsignadasMolinocontrolform"
        Me.BtnRacionesAsignadasMolinocontrolform.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnRacionesAsignadasMolinocontrolform.Size = New System.Drawing.Size(240, 30)
        Me.BtnRacionesAsignadasMolinocontrolform.Text = "Raciones Asignadas"
        Me.BtnRacionesAsignadasMolinocontrolform.ToolTipText = "Raciones"
        '
        'BtnActivar
        '
        Me.BtnActivar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActivar.ForeColor = System.Drawing.Color.White
        Me.BtnActivar.Image = Global.Formularios.My.Resources.Resources.accept
        Me.BtnActivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnActivar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnActivar.Name = "BtnActivar"
        Me.BtnActivar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnActivar.Size = New System.Drawing.Size(110, 30)
        Me.BtnActivar.Text = "Activar"
        Me.BtnActivar.ToolTipText = "Solo para activar fórmulas en estado Finalizado"
        '
        'BtnCancelarnutricionmodulo
        '
        Me.BtnCancelarnutricionmodulo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelarnutricionmodulo.ForeColor = System.Drawing.Color.White
        Me.BtnCancelarnutricionmodulo.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.BtnCancelarnutricionmodulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCancelarnutricionmodulo.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCancelarnutricionmodulo.Name = "BtnCancelarnutricionmodulo"
        Me.BtnCancelarnutricionmodulo.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCancelarnutricionmodulo.Size = New System.Drawing.Size(126, 30)
        Me.BtnCancelarnutricionmodulo.Text = "Cancelar"
        '
        'btnexportarNctrfor
        '
        Me.btnexportarNctrfor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportarNctrfor.ForeColor = System.Drawing.Color.White
        Me.btnexportarNctrfor.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportarNctrfor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportarNctrfor.Margin = New System.Windows.Forms.Padding(5)
        Me.btnexportarNctrfor.Name = "btnexportarNctrfor"
        Me.btnexportarNctrfor.Padding = New System.Windows.Forms.Padding(2)
        Me.btnexportarNctrfor.Size = New System.Drawing.Size(125, 30)
        Me.btnexportarNctrfor.Text = "Exportar"
        Me.btnexportarNctrfor.ToolTipText = "Exportar"
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
        Me.dtgListado.Location = New System.Drawing.Point(0, 310)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(2120, 512)
        Me.dtgListado.TabIndex = 10
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(1005, 545)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 27
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlFormula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2120, 822)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmControlFormula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE FORMULAS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BarraOpciones As ToolStrip
    Friend WithEvents btnCrearFormulaNctrfor As ToolStripButton
    Friend WithEvents btnexportarNctrfor As ToolStripButton
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnNuevaNucleoNctrfor As ToolStripButton
    Friend WithEvents btnInsumosNctrfor As ToolStripButton
    Friend WithEvents btnAsignarFormulaNctrfor As ToolStripButton
    Friend WithEvents BtnVerFormulamolinocontrolformula As ToolStripButton
    Friend WithEvents BtnRacionesAsignadasMolinocontrolform As ToolStripButton
    Friend WithEvents BtnAccesoVisualizacion As ToolStripButton
    Friend WithEvents BtnCancelarnutricionmodulo As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbEstado As ComboBox
    Friend WithEvents BtnActivar As ToolStripButton
    Friend WithEvents BtnNutricionista As ToolStripButton
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ptbx_Cargando As PictureBox
End Class
