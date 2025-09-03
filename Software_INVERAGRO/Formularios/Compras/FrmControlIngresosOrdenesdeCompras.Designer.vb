<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlIngresosOrdenesdeCompras
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cbxestado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxtipodocumento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.GrupoMasOpcionesBusqueda = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevocomprasordencompa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.AjustarOrdenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinalizarOrdenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarOrdenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnEnviarCorreocomprasordenes = New System.Windows.Forms.ToolStripButton()
        Me.btnRecepcionarcomprasordencompa = New System.Windows.Forms.ToolStripButton()
        Me.btnconfirmar_facturacioncomprasordencompa = New System.Windows.Forms.ToolStripButton()
        Me.btnadjuntarcomprasordencompa = New System.Windows.Forms.ToolStripButton()
        Me.btnreportes = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnFacturasVinculadas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeOrdenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnhistoricorecepcionescomprasordencompa = New System.Windows.Forms.ToolStripButton()
        Me.btnAnularcomprasordencompa = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cbxestado.Location = New System.Drawing.Point(821, 42)
        Me.cbxestado.Name = "cbxestado"
        Me.cbxestado.Size = New System.Drawing.Size(191, 21)
        Me.cbxestado.TabIndex = 161
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(750, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Estado :"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Location = New System.Drawing.Point(486, 41)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(249, 21)
        Me.dtpFechaHasta.TabIndex = 159
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Location = New System.Drawing.Point(119, 39)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(256, 21)
        Me.dtpFechaDesde.TabIndex = 158
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 41)
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
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(382, 44)
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
        Me.Panel2.Size = New System.Drawing.Size(1830, 202)
        Me.Panel2.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UltraGroupBox2)
        Me.Panel1.Controls.Add(Me.GrupoMasOpcionesBusqueda)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1830, 164)
        Me.Panel1.TabIndex = 159
        '
        'UltraGroupBox2
        '
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox2.Appearance = Appearance1
        Me.UltraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox2.Controls.Add(Me.txtProveedor)
        Me.UltraGroupBox2.Controls.Add(Me.txtProducto)
        Me.UltraGroupBox2.Controls.Add(Me.Label6)
        Me.UltraGroupBox2.Controls.Add(Me.Label7)
        Me.UltraGroupBox2.Controls.Add(Me.cbxtipodocumento)
        Me.UltraGroupBox2.Controls.Add(Me.Label5)
        Me.UltraGroupBox2.Controls.Add(Me.btnConsultar)
        Me.UltraGroupBox2.Controls.Add(Me.Label3)
        Me.UltraGroupBox2.Controls.Add(Me.cbxestado)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.dtpFechaHasta)
        Me.UltraGroupBox2.Controls.Add(Me.dtpFechaDesde)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.UltraGroupBox2.HeaderAppearance = Appearance2
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 44)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1830, 120)
        Me.UltraGroupBox2.TabIndex = 160
        Me.UltraGroupBox2.Text = "FILTRO DE BÚSQUEDA"
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(486, 74)
        Me.txtProveedor.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProveedor.MaxLength = 200
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(249, 21)
        Me.txtProveedor.TabIndex = 169
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(119, 74)
        Me.txtProducto.Margin = New System.Windows.Forms.Padding(1)
        Me.txtProducto.MaxLength = 100
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(256, 21)
        Me.txtProducto.TabIndex = 168
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(37, 76)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 14)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "Producto:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(394, 77)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 14)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Proveedor :"
        '
        'cbxtipodocumento
        '
        Me.cbxtipodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxtipodocumento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxtipodocumento.FormattingEnabled = True
        Me.cbxtipodocumento.Items.AddRange(New Object() {"TODOS", "ACTIVO", "ANULADO"})
        Me.cbxtipodocumento.Location = New System.Drawing.Point(821, 76)
        Me.cbxtipodocumento.Name = "cbxtipodocumento"
        Me.cbxtipodocumento.Size = New System.Drawing.Size(191, 21)
        Me.cbxtipodocumento.TabIndex = 164
        Me.cbxtipodocumento.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(742, 81)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 14)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "T. de Doc:"
        Me.Label5.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.Formularios.My.Resources.Resources.buscando__1_
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(1025, 38)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(1)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.btnConsultar.Size = New System.Drawing.Size(91, 38)
        Me.btnConsultar.TabIndex = 162
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'GrupoMasOpcionesBusqueda
        '
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.Appearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Appearance4.BorderColor = System.Drawing.Color.Black
        Me.GrupoMasOpcionesBusqueda.ContentAreaAppearance = Appearance4
        Me.GrupoMasOpcionesBusqueda.Controls.Add(Me.Label2)
        Me.GrupoMasOpcionesBusqueda.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrupoMasOpcionesBusqueda.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.BackColor2 = System.Drawing.Color.White
        Appearance5.BorderColor = System.Drawing.Color.White
        Appearance5.BorderColor2 = System.Drawing.Color.White
        Appearance5.BorderColor3DBase = System.Drawing.Color.White
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.Name = "Segoe UI"
        Appearance5.FontData.SizeInPoints = 10.0!
        Appearance5.ForeColor = System.Drawing.Color.White
        Me.GrupoMasOpcionesBusqueda.HeaderAppearance = Appearance5
        Me.GrupoMasOpcionesBusqueda.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOutsideBorder
        Me.GrupoMasOpcionesBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.GrupoMasOpcionesBusqueda.Name = "GrupoMasOpcionesBusqueda"
        Me.GrupoMasOpcionesBusqueda.Size = New System.Drawing.Size(1830, 44)
        Me.GrupoMasOpcionesBusqueda.TabIndex = 22
        Me.GrupoMasOpcionesBusqueda.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2003
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(467, 18)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "MÓDULO DE ORDENES DE COMPRA DE PRODUCTOS"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevocomprasordencompa, Me.ToolStripSplitButton1, Me.BtnEnviarCorreocomprasordenes, Me.btnRecepcionarcomprasordencompa, Me.btnconfirmar_facturacioncomprasordencompa, Me.btnadjuntarcomprasordencompa, Me.btnreportes, Me.btnhistoricorecepcionescomprasordencompa, Me.btnAnularcomprasordencompa, Me.btncerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 164)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1830, 38)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevocomprasordencompa
        '
        Me.btnNuevocomprasordencompa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevocomprasordencompa.ForeColor = System.Drawing.Color.White
        Me.btnNuevocomprasordencompa.Image = Global.Formularios.My.Resources.Resources.nuevo
        Me.btnNuevocomprasordencompa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevocomprasordencompa.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNuevocomprasordencompa.Name = "btnNuevocomprasordencompa"
        Me.btnNuevocomprasordencompa.Padding = New System.Windows.Forms.Padding(2)
        Me.btnNuevocomprasordencompa.Size = New System.Drawing.Size(81, 28)
        Me.btnNuevocomprasordencompa.Text = "Nuevo "
        Me.btnNuevocomprasordencompa.ToolTipText = "Nuevo "
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AjustarOrdenToolStripMenuItem, Me.FinalizarOrdenToolStripMenuItem, Me.EditarOrdenToolStripMenuItem})
        Me.ToolStripSplitButton1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripSplitButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSplitButton1.Image = Global.Formularios.My.Resources.Resources.Actualizar
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(127, 35)
        Me.ToolStripSplitButton1.Text = "Editar Orden"
        '
        'AjustarOrdenToolStripMenuItem
        '
        Me.AjustarOrdenToolStripMenuItem.Name = "AjustarOrdenToolStripMenuItem"
        Me.AjustarOrdenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.AjustarOrdenToolStripMenuItem.Text = "Ajustar Orden"
        '
        'FinalizarOrdenToolStripMenuItem
        '
        Me.FinalizarOrdenToolStripMenuItem.Name = "FinalizarOrdenToolStripMenuItem"
        Me.FinalizarOrdenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.FinalizarOrdenToolStripMenuItem.Text = "Finalizar Orden"
        '
        'EditarOrdenToolStripMenuItem
        '
        Me.EditarOrdenToolStripMenuItem.Name = "EditarOrdenToolStripMenuItem"
        Me.EditarOrdenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.EditarOrdenToolStripMenuItem.Text = "Editar Orden"
        '
        'BtnEnviarCorreocomprasordenes
        '
        Me.BtnEnviarCorreocomprasordenes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnviarCorreocomprasordenes.ForeColor = System.Drawing.Color.White
        Me.BtnEnviarCorreocomprasordenes.Image = Global.Formularios.My.Resources.Resources.enviar
        Me.BtnEnviarCorreocomprasordenes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEnviarCorreocomprasordenes.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnEnviarCorreocomprasordenes.Name = "BtnEnviarCorreocomprasordenes"
        Me.BtnEnviarCorreocomprasordenes.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnEnviarCorreocomprasordenes.Size = New System.Drawing.Size(126, 28)
        Me.BtnEnviarCorreocomprasordenes.Text = "Enviar Correo"
        Me.BtnEnviarCorreocomprasordenes.ToolTipText = "Exportar"
        '
        'btnRecepcionarcomprasordencompa
        '
        Me.btnRecepcionarcomprasordencompa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecepcionarcomprasordencompa.ForeColor = System.Drawing.Color.White
        Me.btnRecepcionarcomprasordencompa.Image = Global.Formularios.My.Resources.Resources.recepcionar_24_px
        Me.btnRecepcionarcomprasordencompa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecepcionarcomprasordencompa.Margin = New System.Windows.Forms.Padding(5)
        Me.btnRecepcionarcomprasordencompa.Name = "btnRecepcionarcomprasordencompa"
        Me.btnRecepcionarcomprasordencompa.Padding = New System.Windows.Forms.Padding(2)
        Me.btnRecepcionarcomprasordencompa.Size = New System.Drawing.Size(116, 28)
        Me.btnRecepcionarcomprasordencompa.Text = "Recepcionar"
        '
        'btnconfirmar_facturacioncomprasordencompa
        '
        Me.btnconfirmar_facturacioncomprasordencompa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconfirmar_facturacioncomprasordencompa.ForeColor = System.Drawing.Color.White
        Me.btnconfirmar_facturacioncomprasordencompa.Image = Global.Formularios.My.Resources.Resources.archivar_factura2
        Me.btnconfirmar_facturacioncomprasordencompa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnconfirmar_facturacioncomprasordencompa.Margin = New System.Windows.Forms.Padding(5)
        Me.btnconfirmar_facturacioncomprasordencompa.Name = "btnconfirmar_facturacioncomprasordencompa"
        Me.btnconfirmar_facturacioncomprasordencompa.Padding = New System.Windows.Forms.Padding(2)
        Me.btnconfirmar_facturacioncomprasordencompa.Size = New System.Drawing.Size(170, 28)
        Me.btnconfirmar_facturacioncomprasordencompa.Text = "Enviar a Facturación"
        '
        'btnadjuntarcomprasordencompa
        '
        Me.btnadjuntarcomprasordencompa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadjuntarcomprasordencompa.ForeColor = System.Drawing.Color.White
        Me.btnadjuntarcomprasordencompa.Image = Global.Formularios.My.Resources.Resources.adjuntar
        Me.btnadjuntarcomprasordencompa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnadjuntarcomprasordencompa.Name = "btnadjuntarcomprasordencompa"
        Me.btnadjuntarcomprasordencompa.Size = New System.Drawing.Size(160, 35)
        Me.btnadjuntarcomprasordencompa.Text = "Adjuntar Cotización"
        '
        'btnreportes
        '
        Me.btnreportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFacturasVinculadas, Me.ExportarToolStripMenuItem, Me.ReporteDeOrdenToolStripMenuItem})
        Me.btnreportes.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnreportes.ForeColor = System.Drawing.Color.White
        Me.btnreportes.Image = Global.Formularios.My.Resources.Resources.reporte
        Me.btnreportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnreportes.Name = "btnreportes"
        Me.btnreportes.Size = New System.Drawing.Size(99, 35)
        Me.btnreportes.Text = "Reportes"
        '
        'btnFacturasVinculadas
        '
        Me.btnFacturasVinculadas.Name = "btnFacturasVinculadas"
        Me.btnFacturasVinculadas.Size = New System.Drawing.Size(206, 22)
        Me.btnFacturasVinculadas.Text = "Facturas Vinculadas"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'ReporteDeOrdenToolStripMenuItem
        '
        Me.ReporteDeOrdenToolStripMenuItem.Name = "ReporteDeOrdenToolStripMenuItem"
        Me.ReporteDeOrdenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ReporteDeOrdenToolStripMenuItem.Text = "Reporte de Orden"
        '
        'btnhistoricorecepcionescomprasordencompa
        '
        Me.btnhistoricorecepcionescomprasordencompa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnhistoricorecepcionescomprasordencompa.ForeColor = System.Drawing.Color.White
        Me.btnhistoricorecepcionescomprasordencompa.Image = Global.Formularios.My.Resources.Resources.Historico_24_px1
        Me.btnhistoricorecepcionescomprasordencompa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnhistoricorecepcionescomprasordencompa.Margin = New System.Windows.Forms.Padding(5)
        Me.btnhistoricorecepcionescomprasordencompa.Name = "btnhistoricorecepcionescomprasordencompa"
        Me.btnhistoricorecepcionescomprasordencompa.Padding = New System.Windows.Forms.Padding(2)
        Me.btnhistoricorecepcionescomprasordencompa.Size = New System.Drawing.Size(185, 28)
        Me.btnhistoricorecepcionescomprasordencompa.Text = "Historico de Recepción"
        '
        'btnAnularcomprasordencompa
        '
        Me.btnAnularcomprasordencompa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnularcomprasordencompa.ForeColor = System.Drawing.Color.White
        Me.btnAnularcomprasordencompa.Image = Global.Formularios.My.Resources.Resources.cancelar
        Me.btnAnularcomprasordencompa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularcomprasordencompa.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAnularcomprasordencompa.Name = "btnAnularcomprasordencompa"
        Me.btnAnularcomprasordencompa.Padding = New System.Windows.Forms.Padding(2)
        Me.btnAnularcomprasordencompa.Size = New System.Drawing.Size(78, 28)
        Me.btnAnularcomprasordencompa.Text = "Anular"
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
        'dtgListado
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance6.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance6
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.Color.White
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.Color.Navy
        Appearance11.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance13
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Me.dtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.dtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.AliceBlue
        Appearance15.BackColor2 = System.Drawing.Color.Silver
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance19
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(0, 202)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(2)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(1830, 404)
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
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(904, 389)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(2)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(29, 24)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 9
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'FrmControlIngresosOrdenesdeCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1830, 606)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.dtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmControlIngresosOrdenesdeCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MODULO DE ORDENES DE COMPRA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.GrupoMasOpcionesBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnNuevocomprasordencompa As Windows.Forms.ToolStripButton
    Friend WithEvents btncerrar As Windows.Forms.ToolStripButton
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtpFechaDesde As Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents cbxestado As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents dtpFechaHasta As Windows.Forms.DateTimePicker
    Friend WithEvents btnConsultar As Windows.Forms.Button
    Friend WithEvents btnAnularcomprasordencompa As Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GrupoMasOpcionesBusqueda As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents cbxtipodocumento As Windows.Forms.ComboBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents btnRecepcionarcomprasordencompa As Windows.Forms.ToolStripButton
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtProducto As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnhistoricorecepcionescomprasordencompa As ToolStripButton
    Friend WithEvents btnadjuntarcomprasordencompa As ToolStripButton
    Friend WithEvents btnconfirmar_facturacioncomprasordencompa As ToolStripButton
    Friend WithEvents BtnEnviarCorreocomprasordenes As ToolStripButton
    Friend WithEvents btnreportes As ToolStripDropDownButton
    Friend WithEvents btnFacturasVinculadas As ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeOrdenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents AjustarOrdenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FinalizarOrdenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarOrdenToolStripMenuItem As ToolStripMenuItem
End Class
