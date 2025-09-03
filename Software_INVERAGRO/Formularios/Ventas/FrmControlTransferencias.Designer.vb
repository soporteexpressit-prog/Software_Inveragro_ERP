<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlTransferencias
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.cbxestado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrupoMasOpcionesBusqueda = New System.Windows.Forms.GroupBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnnuevatransferenciaventas = New System.Windows.Forms.ToolStripButton()
        Me.btnRecepcionarVmopevetransferenciaventas = New System.Windows.Forms.ToolStripSplitButton()
        Me.CONGUIADETRASLADOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SINGUIADETRASLADOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btneditar = New System.Windows.Forms.ToolStripButton()
        Me.btnhistoricoretransferenciaventas = New System.Windows.Forms.ToolStripButton()
        Me.btnventaoirrecuperablestransferenciaventas = New System.Windows.Forms.ToolStripButton()
        Me.btnajustespedidoventas = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnexportarVmopevetransferenciaventas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnanulacionesdisponibles = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AnularAjusteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.GrupoMasOpcionesBusqueda.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxestado
        '
        Me.cbxestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxestado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxestado.FormattingEnabled = True
        Me.cbxestado.Items.AddRange(New Object() {"TODOS", "ACTIVO", "ANULADO"})
        Me.cbxestado.Location = New System.Drawing.Point(339, 66)
        Me.cbxestado.Name = "cbxestado"
        Me.cbxestado.Size = New System.Drawing.Size(135, 21)
        Me.cbxestado.TabIndex = 161
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(277, 68)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Estado :"
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1894, 195)
        Me.Panel2.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1894, 157)
        Me.Panel1.TabIndex = 159
        '
        'UltraGroupBox2
        '
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance20.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox2.Appearance = Appearance20
        Me.UltraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Near
        Me.UltraGroupBox2.Controls.Add(Me.Label2)
        Me.UltraGroupBox2.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance21.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox2.HeaderAppearance = Appearance21
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1894, 157)
        Me.UltraGroupBox2.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(283, 18)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "MÓDULO DE TRANSFERENCIAS"
        '
        'GrupoMasOpcionesBusqueda
        '
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.dtpFechaHasta)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.txtProveedor)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.dtpFechaDesde)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label1)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label4)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label7)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.cbxestado)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label3)
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.btnConsultar)
        Me.GrupoMasOpcionesBusqueda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.GrupoMasOpcionesBusqueda.Location = New System.Drawing.Point(12, 49)
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(747, 100)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 170
        Me.GrupoMasOpcionesBusqueda.TabStop = False
        Me.GrupoMasOpcionesBusqueda.Text = "Filtros de Búsqueda"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(339, 26)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProveedor.MaxLength = 200
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(263, 21)
        Me.txtProveedor.TabIndex = 169
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(265, 28)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Clientes :"
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(632, 45)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnConsultar.Size = New System.Drawing.Size(101, 34)
        Me.btnConsultar.TabIndex = 162
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnnuevatransferenciaventas, Me.btnRecepcionarVmopevetransferenciaventas, Me.btneditar, Me.btnanulacionesdisponibles, Me.btnajustespedidoventas, Me.btnhistoricoretransferenciaventas, Me.btnventaoirrecuperablestransferenciaventas, Me.btnexportarVmopevetransferenciaventas, Me.ToolStripButton1, Me.btncerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 157)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1894, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnnuevatransferenciaventas
        '
        Me.btnnuevatransferenciaventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevatransferenciaventas.ForeColor = System.Drawing.Color.White
        Me.btnnuevatransferenciaventas.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnnuevatransferenciaventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnuevatransferenciaventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnnuevatransferenciaventas.Name = "btnnuevatransferenciaventas"
        Me.btnnuevatransferenciaventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnnuevatransferenciaventas.Size = New System.Drawing.Size(77, 28)
        Me.btnnuevatransferenciaventas.Text = "Nuevo"
        Me.btnnuevatransferenciaventas.ToolTipText = "Nuevo"
        '
        'btnRecepcionarVmopevetransferenciaventas
        '
        Me.btnRecepcionarVmopevetransferenciaventas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CONGUIADETRASLADOToolStripMenuItem, Me.SINGUIADETRASLADOToolStripMenuItem})
        Me.btnRecepcionarVmopevetransferenciaventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecepcionarVmopevetransferenciaventas.ForeColor = System.Drawing.Color.White
        Me.btnRecepcionarVmopevetransferenciaventas.Image = Global.Formularios.My.Resources.Resources.entrega_rapida__1_
        Me.btnRecepcionarVmopevetransferenciaventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecepcionarVmopevetransferenciaventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnRecepcionarVmopevetransferenciaventas.Name = "btnRecepcionarVmopevetransferenciaventas"
        Me.btnRecepcionarVmopevetransferenciaventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnRecepcionarVmopevetransferenciaventas.Size = New System.Drawing.Size(111, 28)
        Me.btnRecepcionarVmopevetransferenciaventas.Text = "Despacho"
        Me.btnRecepcionarVmopevetransferenciaventas.Visible = False
        '
        'CONGUIADETRASLADOToolStripMenuItem
        '
        Me.CONGUIADETRASLADOToolStripMenuItem.Name = "CONGUIADETRASLADOToolStripMenuItem"
        Me.CONGUIADETRASLADOToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.CONGUIADETRASLADOToolStripMenuItem.Text = "CON GUIA DE TRASLADO"
        '
        'SINGUIADETRASLADOToolStripMenuItem
        '
        Me.SINGUIADETRASLADOToolStripMenuItem.Name = "SINGUIADETRASLADOToolStripMenuItem"
        Me.SINGUIADETRASLADOToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.SINGUIADETRASLADOToolStripMenuItem.Text = "SIN GUIA DE TRASLADO"
        '
        'btneditar
        '
        Me.btneditar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditar.ForeColor = System.Drawing.Color.White
        Me.btneditar.Image = Global.Formularios.My.Resources.Resources.editar
        Me.btneditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btneditar.Margin = New System.Windows.Forms.Padding(5)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Padding = New System.Windows.Forms.Padding(2)
        Me.btneditar.Size = New System.Drawing.Size(74, 28)
        Me.btneditar.Text = "Editar"
        '
        'btnhistoricoretransferenciaventas
        '
        Me.btnhistoricoretransferenciaventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnhistoricoretransferenciaventas.ForeColor = System.Drawing.Color.White
        Me.btnhistoricoretransferenciaventas.Image = Global.Formularios.My.Resources.Resources.Historico_24_px1
        Me.btnhistoricoretransferenciaventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnhistoricoretransferenciaventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnhistoricoretransferenciaventas.Name = "btnhistoricoretransferenciaventas"
        Me.btnhistoricoretransferenciaventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnhistoricoretransferenciaventas.Size = New System.Drawing.Size(189, 28)
        Me.btnhistoricoretransferenciaventas.Text = "Historico de Despachos"
        '
        'btnventaoirrecuperablestransferenciaventas
        '
        Me.btnventaoirrecuperablestransferenciaventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnventaoirrecuperablestransferenciaventas.ForeColor = System.Drawing.Color.White
        Me.btnventaoirrecuperablestransferenciaventas.Image = Global.Formularios.My.Resources.Resources.ajuste
        Me.btnventaoirrecuperablestransferenciaventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnventaoirrecuperablestransferenciaventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnventaoirrecuperablestransferenciaventas.Name = "btnventaoirrecuperablestransferenciaventas"
        Me.btnventaoirrecuperablestransferenciaventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnventaoirrecuperablestransferenciaventas.Size = New System.Drawing.Size(338, 28)
        Me.btnventaoirrecuperablestransferenciaventas.Text = "Ventas / Ajustes Anexadas por Transportistas"
        '
        'btnajustespedidoventas
        '
        Me.btnajustespedidoventas.BackColor = System.Drawing.Color.Transparent
        Me.btnajustespedidoventas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem10, Me.ToolStripMenuItem11})
        Me.btnajustespedidoventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnajustespedidoventas.ForeColor = System.Drawing.Color.White
        Me.btnajustespedidoventas.Image = Global.Formularios.My.Resources.Resources.portapapeles
        Me.btnajustespedidoventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnajustespedidoventas.Name = "btnajustespedidoventas"
        Me.btnajustespedidoventas.Size = New System.Drawing.Size(82, 35)
        Me.btnajustespedidoventas.Text = "Ajuste"
        Me.btnajustespedidoventas.ToolTipText = "Convertir Trabajador"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(179, 22)
        Me.ToolStripMenuItem10.Text = "Ajuste Positivo"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(179, 22)
        Me.ToolStripMenuItem11.Text = "Ajuste Negativo"
        '
        'btnexportarVmopevetransferenciaventas
        '
        Me.btnexportarVmopevetransferenciaventas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportarVmopevetransferenciaventas.ForeColor = System.Drawing.Color.White
        Me.btnexportarVmopevetransferenciaventas.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.btnexportarVmopevetransferenciaventas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexportarVmopevetransferenciaventas.Margin = New System.Windows.Forms.Padding(5)
        Me.btnexportarVmopevetransferenciaventas.Name = "btnexportarVmopevetransferenciaventas"
        Me.btnexportarVmopevetransferenciaventas.Padding = New System.Windows.Forms.Padding(2)
        Me.btnexportarVmopevetransferenciaventas.Size = New System.Drawing.Size(92, 28)
        Me.btnexportarVmopevetransferenciaventas.Text = "Exportar"
        Me.btnexportarVmopevetransferenciaventas.ToolTipText = "Exportar"
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
        'btnanulacionesdisponibles
        '
        Me.btnanulacionesdisponibles.BackColor = System.Drawing.Color.Transparent
        Me.btnanulacionesdisponibles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnularAjusteToolStripMenuItem, Me.ToolStripMenuItem5})
        Me.btnanulacionesdisponibles.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnanulacionesdisponibles.ForeColor = System.Drawing.Color.White
        Me.btnanulacionesdisponibles.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.btnanulacionesdisponibles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnanulacionesdisponibles.Name = "btnanulacionesdisponibles"
        Me.btnanulacionesdisponibles.Size = New System.Drawing.Size(83, 35)
        Me.btnanulacionesdisponibles.Text = "Anular"
        Me.btnanulacionesdisponibles.ToolTipText = "Convertir Trabajador"
        '
        'AnularAjusteToolStripMenuItem
        '
        Me.AnularAjusteToolStripMenuItem.Name = "AnularAjusteToolStripMenuItem"
        Me.AnularAjusteToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.AnularAjusteToolStripMenuItem.Text = "Anular Ajuste"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(227, 22)
        Me.ToolStripMenuItem5.Text = "Anular Pedido de venta"
        '
        'dtgListado
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance3.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance3
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.Color.Navy
        Appearance8.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance10
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.AliceBlue
        Appearance12.BackColor2 = System.Drawing.Color.Silver
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance16
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 195)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1894, 411)
        Me.dtgListado.TabIndex = 8
        Me.dtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(931, 360)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 9
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlTransferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1894, 606)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmControlTransferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MODULO DE CONTROL DE TRANSFERENCIAS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.GrupoMasOpcionesBusqueda.ResumeLayout(False)
        Me.GrupoMasOpcionesBusqueda.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnexportarVmopevetransferenciaventas As Windows.Forms.ToolStripButton
    Friend WithEvents btncerrar As Windows.Forms.ToolStripButton
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtpFechaDesde As Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbxestado As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents dtpFechaHasta As Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnhistoricoretransferenciaventas As ToolStripButton
    Friend WithEvents btnRecepcionarVmopevetransferenciaventas As ToolStripSplitButton
    Friend WithEvents CONGUIADETRASLADOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SINGUIADETRASLADOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents btnventaoirrecuperablestransferenciaventas As ToolStripButton
    Friend WithEvents btnnuevatransferenciaventas As ToolStripButton
    Friend WithEvents GrupoMasOpcionesBusqueda As GroupBox
    Friend WithEvents btneditar As ToolStripButton
    Friend WithEvents btnajustespedidoventas As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem10 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Friend WithEvents btnanulacionesdisponibles As ToolStripDropDownButton
    Friend WithEvents AnularAjusteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
End Class
