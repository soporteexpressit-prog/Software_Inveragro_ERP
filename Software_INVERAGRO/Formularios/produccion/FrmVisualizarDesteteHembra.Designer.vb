<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVisualizarDesteteHembra
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblResponsable = New System.Windows.Forms.Label()
        Me.LblCodCerdo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.LblPromDestete = New System.Windows.Forms.Label()
        Me.LblNacidosHembras = New System.Windows.Forms.Label()
        Me.LblNacidosMachos = New System.Windows.Forms.Label()
        Me.LblDestetoNodriza = New System.Windows.Forms.Label()
        Me.LblPesoDestete = New System.Windows.Forms.Label()
        Me.LblFechaControl = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.LblCondCorporal = New System.Windows.Forms.Label()
        Me.LblArea = New System.Windows.Forms.Label()
        Me.LblPlantel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LblLote)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.LblResponsable)
        Me.Panel2.Controls.Add(Me.LblCodCerdo)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.GrupoFiltros)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(961, 664)
        Me.Panel2.TabIndex = 12
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.BackColor = System.Drawing.Color.Transparent
        Me.LblLote.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLote.ForeColor = System.Drawing.Color.Black
        Me.LblLote.Location = New System.Drawing.Point(560, 84)
        Me.LblLote.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(18, 22)
        Me.LblLote.TabIndex = 200
        Me.LblLote.Text = "-"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(482, 84)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 22)
        Me.Label16.TabIndex = 200
        Me.Label16.Text = "Lote :"
        '
        'LblResponsable
        '
        Me.LblResponsable.AutoSize = True
        Me.LblResponsable.BackColor = System.Drawing.Color.Transparent
        Me.LblResponsable.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblResponsable.ForeColor = System.Drawing.Color.Black
        Me.LblResponsable.Location = New System.Drawing.Point(218, 608)
        Me.LblResponsable.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblResponsable.Name = "LblResponsable"
        Me.LblResponsable.Size = New System.Drawing.Size(18, 22)
        Me.LblResponsable.TabIndex = 198
        Me.LblResponsable.Text = "-"
        '
        'LblCodCerdo
        '
        Me.LblCodCerdo.AutoSize = True
        Me.LblCodCerdo.BackColor = System.Drawing.Color.Transparent
        Me.LblCodCerdo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodCerdo.ForeColor = System.Drawing.Color.Black
        Me.LblCodCerdo.Location = New System.Drawing.Point(789, 84)
        Me.LblCodCerdo.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCodCerdo.Name = "LblCodCerdo"
        Me.LblCodCerdo.Size = New System.Drawing.Size(19, 22)
        Me.LblCodCerdo.TabIndex = 188
        Me.LblCodCerdo.Text = "-"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(702, 84)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 22)
        Me.Label9.TabIndex = 187
        Me.Label9.Text = "Arete :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(54, 608)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 22)
        Me.Label4.TabIndex = 185
        Me.Label4.Text = "Responsable :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblMensaje)
        Me.GroupBox1.Controls.Add(Me.LblPromDestete)
        Me.GroupBox1.Controls.Add(Me.LblNacidosHembras)
        Me.GroupBox1.Controls.Add(Me.LblNacidosMachos)
        Me.GroupBox1.Controls.Add(Me.LblDestetoNodriza)
        Me.GroupBox1.Controls.Add(Me.LblPesoDestete)
        Me.GroupBox1.Controls.Add(Me.LblFechaControl)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(916, 326)
        Me.GroupBox1.TabIndex = 187
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de destete"
        '
        'LblMensaje
        '
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.BackColor = System.Drawing.Color.Transparent
        Me.LblMensaje.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.Black
        Me.LblMensaje.Location = New System.Drawing.Point(456, 271)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(87, 22)
        Me.LblMensaje.TabIndex = 199
        Me.LblMensaje.Text = "mensaje"
        '
        'LblPromDestete
        '
        Me.LblPromDestete.AutoSize = True
        Me.LblPromDestete.BackColor = System.Drawing.Color.Transparent
        Me.LblPromDestete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromDestete.ForeColor = System.Drawing.Color.Black
        Me.LblPromDestete.Location = New System.Drawing.Point(602, 141)
        Me.LblPromDestete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPromDestete.Name = "LblPromDestete"
        Me.LblPromDestete.Size = New System.Drawing.Size(18, 22)
        Me.LblPromDestete.TabIndex = 197
        Me.LblPromDestete.Text = "-"
        '
        'LblNacidosHembras
        '
        Me.LblNacidosHembras.AutoSize = True
        Me.LblNacidosHembras.BackColor = System.Drawing.Color.Transparent
        Me.LblNacidosHembras.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNacidosHembras.ForeColor = System.Drawing.Color.Black
        Me.LblNacidosHembras.Location = New System.Drawing.Point(822, 56)
        Me.LblNacidosHembras.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblNacidosHembras.Name = "LblNacidosHembras"
        Me.LblNacidosHembras.Size = New System.Drawing.Size(18, 22)
        Me.LblNacidosHembras.TabIndex = 196
        Me.LblNacidosHembras.Text = "-"
        '
        'LblNacidosMachos
        '
        Me.LblNacidosMachos.AutoSize = True
        Me.LblNacidosMachos.BackColor = System.Drawing.Color.Transparent
        Me.LblNacidosMachos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNacidosMachos.ForeColor = System.Drawing.Color.Black
        Me.LblNacidosMachos.Location = New System.Drawing.Point(522, 56)
        Me.LblNacidosMachos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblNacidosMachos.Name = "LblNacidosMachos"
        Me.LblNacidosMachos.Size = New System.Drawing.Size(18, 22)
        Me.LblNacidosMachos.TabIndex = 195
        Me.LblNacidosMachos.Text = "-"
        '
        'LblDestetoNodriza
        '
        Me.LblDestetoNodriza.AutoSize = True
        Me.LblDestetoNodriza.BackColor = System.Drawing.Color.Transparent
        Me.LblDestetoNodriza.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDestetoNodriza.ForeColor = System.Drawing.Color.Black
        Me.LblDestetoNodriza.Location = New System.Drawing.Point(218, 223)
        Me.LblDestetoNodriza.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblDestetoNodriza.Name = "LblDestetoNodriza"
        Me.LblDestetoNodriza.Size = New System.Drawing.Size(18, 22)
        Me.LblDestetoNodriza.TabIndex = 194
        Me.LblDestetoNodriza.Text = "-"
        '
        'LblPesoDestete
        '
        Me.LblPesoDestete.AutoSize = True
        Me.LblPesoDestete.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoDestete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoDestete.ForeColor = System.Drawing.Color.Black
        Me.LblPesoDestete.Location = New System.Drawing.Point(218, 141)
        Me.LblPesoDestete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoDestete.Name = "LblPesoDestete"
        Me.LblPesoDestete.Size = New System.Drawing.Size(18, 22)
        Me.LblPesoDestete.TabIndex = 193
        Me.LblPesoDestete.Text = "-"
        '
        'LblFechaControl
        '
        Me.LblFechaControl.AutoSize = True
        Me.LblFechaControl.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaControl.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaControl.ForeColor = System.Drawing.Color.Black
        Me.LblFechaControl.Location = New System.Drawing.Point(218, 56)
        Me.LblFechaControl.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFechaControl.Name = "LblFechaControl"
        Me.LblFechaControl.Size = New System.Drawing.Size(18, 22)
        Me.LblFechaControl.TabIndex = 192
        Me.LblFechaControl.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(21, 223)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(185, 22)
        Me.Label12.TabIndex = 189
        Me.Label12.Text = "Desteto Nodriza :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(411, 141)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 22)
        Me.Label10.TabIndex = 188
        Me.Label10.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(53, 141)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 22)
        Me.Label7.TabIndex = 185
        Me.Label7.Text = "Peso destete :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(696, 56)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 22)
        Me.Label8.TabIndex = 186
        Me.Label8.Text = "Hembras :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(123, 56)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 22)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Fecha :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(411, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Machos :"
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.LblCondCorporal)
        Me.GrupoFiltros.Controls.Add(Me.LblArea)
        Me.GrupoFiltros.Controls.Add(Me.LblPlantel)
        Me.GrupoFiltros.Controls.Add(Me.Label11)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.Label5)
        Me.GrupoFiltros.Location = New System.Drawing.Point(22, 137)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Size = New System.Drawing.Size(916, 106)
        Me.GrupoFiltros.TabIndex = 186
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Ubicación"
        '
        'LblCondCorporal
        '
        Me.LblCondCorporal.AutoSize = True
        Me.LblCondCorporal.BackColor = System.Drawing.Color.Transparent
        Me.LblCondCorporal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCondCorporal.ForeColor = System.Drawing.Color.Black
        Me.LblCondCorporal.Location = New System.Drawing.Point(822, 49)
        Me.LblCondCorporal.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCondCorporal.Name = "LblCondCorporal"
        Me.LblCondCorporal.Size = New System.Drawing.Size(18, 22)
        Me.LblCondCorporal.TabIndex = 200
        Me.LblCondCorporal.Text = "-"
        '
        'LblArea
        '
        Me.LblArea.AutoSize = True
        Me.LblArea.BackColor = System.Drawing.Color.Transparent
        Me.LblArea.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblArea.ForeColor = System.Drawing.Color.Black
        Me.LblArea.Location = New System.Drawing.Point(459, 49)
        Me.LblArea.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblArea.Name = "LblArea"
        Me.LblArea.Size = New System.Drawing.Size(18, 22)
        Me.LblArea.TabIndex = 191
        Me.LblArea.Text = "-"
        '
        'LblPlantel
        '
        Me.LblPlantel.AutoSize = True
        Me.LblPlantel.BackColor = System.Drawing.Color.Transparent
        Me.LblPlantel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlantel.ForeColor = System.Drawing.Color.Black
        Me.LblPlantel.Location = New System.Drawing.Point(139, 49)
        Me.LblPlantel.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPlantel.Name = "LblPlantel"
        Me.LblPlantel.Size = New System.Drawing.Size(18, 22)
        Me.LblPlantel.TabIndex = 190
        Me.LblPlantel.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(637, 49)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 22)
        Me.Label11.TabIndex = 189
        Me.Label11.Text = "Cond. Corporal :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(34, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 22)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Plantel :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(377, 49)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 22)
        Me.Label5.TabIndex = 184
        Me.Label5.Text = "Área :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(31, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(338, 29)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "INFORMACIÓN DESTETE"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(961, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnSalir.Size = New System.Drawing.Size(84, 30)
        Me.BtnSalir.Text = "Salir"
        '
        'BackgroundWorker1
        '
        '
        'FrmVisualizarDesteteHembra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 664)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVisualizarDesteteHembra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INFORMACIÓN DE DESTETE"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnSalir As ToolStripButton
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblCodCerdo As Label
    Friend WithEvents LblPlantel As Label
    Friend WithEvents LblArea As Label
    Friend WithEvents LblFechaControl As Label
    Friend WithEvents LblPesoDestete As Label
    Friend WithEvents LblDestetoNodriza As Label
    Friend WithEvents LblNacidosMachos As Label
    Friend WithEvents LblNacidosHembras As Label
    Friend WithEvents LblPromDestete As Label
    Friend WithEvents LblResponsable As Label
    Friend WithEvents LblMensaje As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LblLote As Label
    Friend WithEvents LblCondCorporal As Label
End Class
