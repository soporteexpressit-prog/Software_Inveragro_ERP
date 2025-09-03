<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlGuiasTraslado
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
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.GrupoMasOpcionesBusqueda = New Infragistics.Win.Misc.UltraGroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxestado = New System.Windows.Forms.ComboBox()
        Me.cbxtipodocumento = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevaGuiatrasladoventas = New System.Windows.Forms.ToolStripButton()
        Me.btnconfirmar_entregaGuiatrasladoventas = New System.Windows.Forms.ToolStripButton()
        Me.btnAnularguiaGuiatrasladoventas = New System.Windows.Forms.ToolStripButton()
        Me.btngenerar_ventaGuiatrasladoventas = New System.Windows.Forms.ToolStripButton()
        Me.btnadjuntarguiatrasladoMODUVENTA = New System.Windows.Forms.ToolStripButton()
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas = New System.Windows.Forms.ToolStripButton()
        Me.btnreporteGuiatrasladoventas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.lbltitulo)
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
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(1160, 159)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 169
        Me.GrupoMasOpcionesBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbxestado)
        Me.GroupBox1.Controls.Add(Me.cbxtipodocumento)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnConsultar)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 100)
        Me.GroupBox1.TabIndex = 171
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros de Búsqueda"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(134, 63)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(115, 21)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(135, 24)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(115, 21)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(264, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Estado :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(27, 65)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fecha Hasta :"
        '
        'cbxestado
        '
        Me.cbxestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxestado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxestado.FormattingEnabled = True
        Me.cbxestado.Items.AddRange(New Object() {"TODOS", "PENDIENTE", "ENTREGADO", "ANULADO"})
        Me.cbxestado.Location = New System.Drawing.Point(326, 27)
        Me.cbxestado.Name = "cbxestado"
        Me.cbxestado.Size = New System.Drawing.Size(135, 21)
        Me.cbxestado.TabIndex = 161
        '
        'cbxtipodocumento
        '
        Me.cbxtipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxtipodocumento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxtipodocumento.FormattingEnabled = True
        Me.cbxtipodocumento.Items.AddRange(New Object() {"TODOS", "ACTIVO", "ANULADO"})
        Me.cbxtipodocumento.Location = New System.Drawing.Point(1089, 48)
        Me.cbxtipodocumento.Name = "cbxtipodocumento"
        Me.cbxtipodocumento.Size = New System.Drawing.Size(191, 21)
        Me.cbxtipodocumento.TabIndex = 164
        Me.cbxtipodocumento.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 14)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Fecha Desde :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(947, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 14)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "Tipo de Documento :"
        Me.Label5.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(480, 27)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnConsultar.Size = New System.Drawing.Size(101, 34)
        Me.btnConsultar.TabIndex = 162
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.lbltitulo.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbltitulo.Location = New System.Drawing.Point(8, 12)
        Me.lbltitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(417, 18)
        Me.lbltitulo.TabIndex = 128
        Me.lbltitulo.Text = "MÓDULO DE GUIAS DE TRASLADO DE CERDOS"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevaGuiatrasladoventas, Me.btnconfirmar_entregaGuiatrasladoventas, Me.btnAnularguiaGuiatrasladoventas, Me.btngenerar_ventaGuiatrasladoventas, Me.btnadjuntarguiatrasladoMODUVENTA, Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas, Me.btnreporteGuiatrasladoventas, Me.ToolStripButton1, Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 159)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1160, 38)
        Me.ToolStrip1.TabIndex = 168
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevaGuiatrasladoventas
        '
        Me.btnNuevaGuiatrasladoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaGuiatrasladoventas.ForeColor = System.Drawing.Color.White
        Me.btnNuevaGuiatrasladoventas.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnNuevaGuiatrasladoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevaGuiatrasladoventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevaGuiatrasladoventas.Name = "btnNuevaGuiatrasladoventas"
        Me.btnNuevaGuiatrasladoventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnNuevaGuiatrasladoventas.Size = New System.Drawing.Size(81, 28)
        Me.btnNuevaGuiatrasladoventas.Text = "Nuevo "
        Me.btnNuevaGuiatrasladoventas.ToolTipText = "Nuevo "
        '
        'btnconfirmar_entregaGuiatrasladoventas
        '
        Me.btnconfirmar_entregaGuiatrasladoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconfirmar_entregaGuiatrasladoventas.ForeColor = System.Drawing.Color.White
        Me.btnconfirmar_entregaGuiatrasladoventas.Image = Global.Formularios.My.Resources.Resources.paquete_entregado1
        Me.btnconfirmar_entregaGuiatrasladoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnconfirmar_entregaGuiatrasladoventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnconfirmar_entregaGuiatrasladoventas.Name = "btnconfirmar_entregaGuiatrasladoventas"
        Me.btnconfirmar_entregaGuiatrasladoventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnconfirmar_entregaGuiatrasladoventas.Size = New System.Drawing.Size(156, 28)
        Me.btnconfirmar_entregaGuiatrasladoventas.Text = "Confirmar Entrega"
        Me.btnconfirmar_entregaGuiatrasladoventas.Visible = False
        '
        'btnAnularguiaGuiatrasladoventas
        '
        Me.btnAnularguiaGuiatrasladoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnularguiaGuiatrasladoventas.ForeColor = System.Drawing.Color.White
        Me.btnAnularguiaGuiatrasladoventas.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.btnAnularguiaGuiatrasladoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularguiaGuiatrasladoventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAnularguiaGuiatrasladoventas.Name = "btnAnularguiaGuiatrasladoventas"
        Me.btnAnularguiaGuiatrasladoventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnAnularguiaGuiatrasladoventas.Size = New System.Drawing.Size(112, 28)
        Me.btnAnularguiaGuiatrasladoventas.Text = "Anular Guia"
        '
        'btngenerar_ventaGuiatrasladoventas
        '
        Me.btngenerar_ventaGuiatrasladoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngenerar_ventaGuiatrasladoventas.ForeColor = System.Drawing.Color.White
        Me.btngenerar_ventaGuiatrasladoventas.Image = Global.Formularios.My.Resources.Resources.venta
        Me.btngenerar_ventaGuiatrasladoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btngenerar_ventaGuiatrasladoventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btngenerar_ventaGuiatrasladoventas.Name = "btngenerar_ventaGuiatrasladoventas"
        Me.btngenerar_ventaGuiatrasladoventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btngenerar_ventaGuiatrasladoventas.Size = New System.Drawing.Size(131, 28)
        Me.btngenerar_ventaGuiatrasladoventas.Text = "Generar Venta"
        '
        'btnadjuntarguiatrasladoMODUVENTA
        '
        Me.btnadjuntarguiatrasladoMODUVENTA.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadjuntarguiatrasladoMODUVENTA.ForeColor = System.Drawing.Color.White
        Me.btnadjuntarguiatrasladoMODUVENTA.Image = Global.Formularios.My.Resources.Resources.adjuntar
        Me.btnadjuntarguiatrasladoMODUVENTA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnadjuntarguiatrasladoMODUVENTA.Name = "btnadjuntarguiatrasladoMODUVENTA"
        Me.btnadjuntarguiatrasladoMODUVENTA.Size = New System.Drawing.Size(170, 35)
        Me.btnadjuntarguiatrasladoMODUVENTA.Text = "Adjuntar / Actualizar"
        '
        'btngenerar_ajuste_irrecuperableGuiatrasladoventas
        '
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.ForeColor = System.Drawing.Color.White
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Image = Global.Formularios.My.Resources.Resources.ajuste1
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Name = "btngenerar_ajuste_irrecuperableGuiatrasladoventas"
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Size = New System.Drawing.Size(256, 28)
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Text = "Generar Ajuste por Irrecuperable"
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btngenerar_ajuste_irrecuperableGuiatrasladoventas.Visible = False
        '
        'btnreporteGuiatrasladoventas
        '
        Me.btnreporteGuiatrasladoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporteGuiatrasladoventas.ForeColor = System.Drawing.Color.White
        Me.btnreporteGuiatrasladoventas.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.btnreporteGuiatrasladoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnreporteGuiatrasladoventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnreporteGuiatrasladoventas.Name = "btnreporteGuiatrasladoventas"
        Me.btnreporteGuiatrasladoventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnreporteGuiatrasladoventas.Size = New System.Drawing.Size(87, 28)
        Me.btnreporteGuiatrasladoventas.Text = "Reporte"
        Me.btnreporteGuiatrasladoventas.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.Formularios.My.Resources.Resources.filter__2_1
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripButton1.Size = New System.Drawing.Size(77, 28)
        Me.ToolStripButton1.Text = "Filtros"
        Me.ToolStripButton1.ToolTipText = "Cerrar"
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
        'dtgListado
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance4.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance4
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.dtgListado.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.PrefixWithEmptyCell
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
        Appearance8.BackColor = System.Drawing.Color.Navy
        Appearance8.ForeColor = System.Drawing.Color.White
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
        Me.dtgListado.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.EntireColumn
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.dtgListado.DisplayLayout.Override.FixedRowIndicator = Infragistics.Win.UltraWinGrid.FixedRowIndicator.None
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
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 197)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1160, 441)
        Me.dtgListado.TabIndex = 173
        '
        'FrmControlGuiasTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1160, 638)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmControlGuiasTraslado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MÓDULO DE GUIAS DE TRASLADO DE CERDOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoMasOpcionesBusqueda.ResumeLayout(False)
        Me.GrupoMasOpcionesBusqueda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrupoMasOpcionesBusqueda As Infragistics.Win.Misc.UltraGroupBox
    Public WithEvents lbltitulo As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents btnconfirmar_entregaGuiatrasladoventas As ToolStripButton
    Friend WithEvents btnAnularguiaGuiatrasladoventas As ToolStripButton
    Friend WithEvents btngenerar_ventaGuiatrasladoventas As ToolStripButton
    Friend WithEvents btnreporteGuiatrasladoventas As ToolStripButton
    Friend WithEvents btngenerar_ajuste_irrecuperableGuiatrasladoventas As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbxestado As ComboBox
    Friend WithEvents cbxtipodocumento As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnConsultar As Button
    Friend WithEvents btnNuevaGuiatrasladoventas As ToolStripButton
    Friend WithEvents btnadjuntarguiatrasladoMODUVENTA As ToolStripButton
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
