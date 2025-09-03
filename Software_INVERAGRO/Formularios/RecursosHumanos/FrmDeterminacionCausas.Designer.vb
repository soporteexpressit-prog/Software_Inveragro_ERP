<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeterminacionCausas
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardarmodelu = New System.Windows.Forms.ToolStripButton()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblContador1 = New System.Windows.Forms.Label()
        Me.lblContador = New System.Windows.Forms.Label()
        Me.txtdescripcionCI = New System.Windows.Forms.TextBox()
        Me.txtcodigoCI = New System.Windows.Forms.TextBox()
        Me.txtasci = New System.Windows.Forms.TextBox()
        Me.txtcsci = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblContador3 = New System.Windows.Forms.Label()
        Me.lblContador2 = New System.Windows.Forms.Label()
        Me.txtdescripCB = New System.Windows.Forms.TextBox()
        Me.txtcodigoCB = New System.Windows.Forms.TextBox()
        Me.txtfpcb = New System.Windows.Forms.TextBox()
        Me.txtftcb = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtfaltafc = New System.Windows.Forms.TextBox()
        Me.txtcodfc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardarmodelu, Me.btnsalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1239, 38)
        Me.ToolStrip1.TabIndex = 179
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardarmodelu
        '
        Me.btnGuardarmodelu.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarmodelu.ForeColor = System.Drawing.Color.White
        Me.btnGuardarmodelu.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardarmodelu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardarmodelu.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardarmodelu.Name = "btnGuardarmodelu"
        Me.btnGuardarmodelu.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardarmodelu.Size = New System.Drawing.Size(89, 28)
        Me.btnGuardarmodelu.Text = "Guardar"
        Me.btnGuardarmodelu.ToolTipText = "Nuevo "
        '
        'btnsalir
        '
        Me.btnsalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalir.ForeColor = System.Drawing.Color.White
        Me.btnsalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnsalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnsalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Padding = New System.Windows.Forms.Padding(2)
        Me.btnsalir.Size = New System.Drawing.Size(66, 28)
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.ToolTipText = "Editar"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(52, 75)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(322, 18)
        Me.Label12.TabIndex = 185
        Me.Label12.Text = "MODULO DETERMINACIÓN DE CAUSAS"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox1.Controls.Add(Me.lblContador1)
        Me.UltraGroupBox1.Controls.Add(Me.lblContador)
        Me.UltraGroupBox1.Controls.Add(Me.txtdescripcionCI)
        Me.UltraGroupBox1.Controls.Add(Me.txtcodigoCI)
        Me.UltraGroupBox1.Controls.Add(Me.txtasci)
        Me.UltraGroupBox1.Controls.Add(Me.txtcsci)
        Me.UltraGroupBox1.Controls.Add(Me.Label5)
        Me.UltraGroupBox1.Controls.Add(Me.Label4)
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(52, 137)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1149, 295)
        Me.UltraGroupBox1.TabIndex = 186
        Me.UltraGroupBox1.Text = "CAUSAS INMEDIATAS"
        Me.UltraGroupBox1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI
        '
        'lblContador1
        '
        Me.lblContador1.AutoSize = True
        Me.lblContador1.Location = New System.Drawing.Point(1071, 217)
        Me.lblContador1.Name = "lblContador1"
        Me.lblContador1.Size = New System.Drawing.Size(0, 15)
        Me.lblContador1.TabIndex = 192
        '
        'lblContador
        '
        Me.lblContador.AutoSize = True
        Me.lblContador.Location = New System.Drawing.Point(674, 217)
        Me.lblContador.Name = "lblContador"
        Me.lblContador.Size = New System.Drawing.Size(0, 15)
        Me.lblContador.TabIndex = 191
        '
        'txtdescripcionCI
        '
        Me.txtdescripcionCI.AcceptsReturn = True
        Me.txtdescripcionCI.BackColor = System.Drawing.SystemColors.Window
        Me.txtdescripcionCI.Location = New System.Drawing.Point(804, 85)
        Me.txtdescripcionCI.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdescripcionCI.MaxLength = 250
        Me.txtdescripcionCI.Multiline = True
        Me.txtdescripcionCI.Name = "txtdescripcionCI"
        Me.txtdescripcionCI.Size = New System.Drawing.Size(280, 153)
        Me.txtdescripcionCI.TabIndex = 190
        '
        'txtcodigoCI
        '
        Me.txtcodigoCI.BackColor = System.Drawing.SystemColors.Window
        Me.txtcodigoCI.Location = New System.Drawing.Point(466, 85)
        Me.txtcodigoCI.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcodigoCI.MaxLength = 250
        Me.txtcodigoCI.Multiline = True
        Me.txtcodigoCI.Name = "txtcodigoCI"
        Me.txtcodigoCI.Size = New System.Drawing.Size(280, 153)
        Me.txtcodigoCI.TabIndex = 189
        '
        'txtasci
        '
        Me.txtasci.BackColor = System.Drawing.SystemColors.Window
        Me.txtasci.Location = New System.Drawing.Point(15, 197)
        Me.txtasci.Margin = New System.Windows.Forms.Padding(2)
        Me.txtasci.Multiline = True
        Me.txtasci.Name = "txtasci"
        Me.txtasci.Size = New System.Drawing.Size(384, 47)
        Me.txtasci.TabIndex = 188
        '
        'txtcsci
        '
        Me.txtcsci.BackColor = System.Drawing.SystemColors.Window
        Me.txtcsci.Location = New System.Drawing.Point(15, 85)
        Me.txtcsci.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcsci.Multiline = True
        Me.txtcsci.Name = "txtcsci"
        Me.txtcsci.Size = New System.Drawing.Size(384, 47)
        Me.txtcsci.TabIndex = 187
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(804, 48)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 14)
        Me.Label5.TabIndex = 186
        Me.Label5.Text = "Descripción:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(466, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 14)
        Me.Label4.TabIndex = 185
        Me.Label4.Text = "Código:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(15, 157)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 14)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "Actos subestándares:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 14)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Condiciones subestándares:"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox2.Controls.Add(Me.lblContador3)
        Me.UltraGroupBox2.Controls.Add(Me.lblContador2)
        Me.UltraGroupBox2.Controls.Add(Me.txtdescripCB)
        Me.UltraGroupBox2.Controls.Add(Me.txtcodigoCB)
        Me.UltraGroupBox2.Controls.Add(Me.txtfpcb)
        Me.UltraGroupBox2.Controls.Add(Me.txtftcb)
        Me.UltraGroupBox2.Controls.Add(Me.Label6)
        Me.UltraGroupBox2.Controls.Add(Me.Label7)
        Me.UltraGroupBox2.Controls.Add(Me.Label8)
        Me.UltraGroupBox2.Controls.Add(Me.Label9)
        Me.UltraGroupBox2.Controls.Add(Me.Label10)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(56, 468)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(1148, 300)
        Me.UltraGroupBox2.TabIndex = 191
        Me.UltraGroupBox2.Text = "CAUSAS BÁSICAS"
        '
        'lblContador3
        '
        Me.lblContador3.AutoSize = True
        Me.lblContador3.Location = New System.Drawing.Point(1070, 218)
        Me.lblContador3.Name = "lblContador3"
        Me.lblContador3.Size = New System.Drawing.Size(0, 15)
        Me.lblContador3.TabIndex = 193
        '
        'lblContador2
        '
        Me.lblContador2.AutoSize = True
        Me.lblContador2.Location = New System.Drawing.Point(681, 218)
        Me.lblContador2.Name = "lblContador2"
        Me.lblContador2.Size = New System.Drawing.Size(0, 15)
        Me.lblContador2.TabIndex = 192
        '
        'txtdescripCB
        '
        Me.txtdescripCB.BackColor = System.Drawing.SystemColors.Window
        Me.txtdescripCB.Location = New System.Drawing.Point(804, 75)
        Me.txtdescripCB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtdescripCB.MaxLength = 250
        Me.txtdescripCB.Multiline = True
        Me.txtdescripCB.Name = "txtdescripCB"
        Me.txtdescripCB.Size = New System.Drawing.Size(280, 153)
        Me.txtdescripCB.TabIndex = 191
        '
        'txtcodigoCB
        '
        Me.txtcodigoCB.BackColor = System.Drawing.SystemColors.Window
        Me.txtcodigoCB.Location = New System.Drawing.Point(464, 75)
        Me.txtcodigoCB.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcodigoCB.MaxLength = 250
        Me.txtcodigoCB.Multiline = True
        Me.txtcodigoCB.Name = "txtcodigoCB"
        Me.txtcodigoCB.Size = New System.Drawing.Size(280, 153)
        Me.txtcodigoCB.TabIndex = 190
        '
        'txtfpcb
        '
        Me.txtfpcb.BackColor = System.Drawing.SystemColors.Window
        Me.txtfpcb.Location = New System.Drawing.Point(15, 182)
        Me.txtfpcb.Margin = New System.Windows.Forms.Padding(2)
        Me.txtfpcb.Multiline = True
        Me.txtfpcb.Name = "txtfpcb"
        Me.txtfpcb.Size = New System.Drawing.Size(384, 47)
        Me.txtfpcb.TabIndex = 189
        '
        'txtftcb
        '
        Me.txtftcb.BackColor = System.Drawing.SystemColors.Window
        Me.txtftcb.Location = New System.Drawing.Point(18, 78)
        Me.txtftcb.Margin = New System.Windows.Forms.Padding(2)
        Me.txtftcb.Multiline = True
        Me.txtftcb.Name = "txtftcb"
        Me.txtftcb.Size = New System.Drawing.Size(384, 47)
        Me.txtftcb.TabIndex = 188
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(804, 48)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 14)
        Me.Label6.TabIndex = 187
        Me.Label6.Text = "Descripción:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(464, 48)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 14)
        Me.Label7.TabIndex = 186
        Me.Label7.Text = "Código:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(15, 149)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 14)
        Me.Label8.TabIndex = 185
        Me.Label8.Text = "Factores personales:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(15, 48)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(146, 14)
        Me.Label9.TabIndex = 184
        Me.Label9.Text = "Factores De Trabajo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(150, 15)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 14)
        Me.Label10.TabIndex = 183
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.UltraGroupBox3.Controls.Add(Me.txtfaltafc)
        Me.UltraGroupBox3.Controls.Add(Me.txtcodfc)
        Me.UltraGroupBox3.Controls.Add(Me.Label11)
        Me.UltraGroupBox3.Controls.Add(Me.Label14)
        Me.UltraGroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(52, 782)
        Me.UltraGroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(1149, 129)
        Me.UltraGroupBox3.TabIndex = 192
        Me.UltraGroupBox3.Text = "FALTA DE CONTROL"
        '
        'txtfaltafc
        '
        Me.txtfaltafc.BackColor = System.Drawing.SystemColors.Window
        Me.txtfaltafc.Location = New System.Drawing.Point(464, 74)
        Me.txtfaltafc.Margin = New System.Windows.Forms.Padding(2)
        Me.txtfaltafc.Multiline = True
        Me.txtfaltafc.Name = "txtfaltafc"
        Me.txtfaltafc.Size = New System.Drawing.Size(620, 47)
        Me.txtfaltafc.TabIndex = 186
        '
        'txtcodfc
        '
        Me.txtcodfc.BackColor = System.Drawing.SystemColors.Window
        Me.txtcodfc.Location = New System.Drawing.Point(15, 74)
        Me.txtcodfc.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcodfc.Multiline = True
        Me.txtcodfc.Name = "txtcodfc"
        Me.txtcodfc.Size = New System.Drawing.Size(384, 47)
        Me.txtcodfc.TabIndex = 185
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(464, 48)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 14)
        Me.Label11.TabIndex = 184
        Me.Label11.Text = "Falta de control:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(15, 48)
        Me.Label14.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 14)
        Me.Label14.TabIndex = 183
        Me.Label14.Text = "Código:"
        '
        'FrmDeterminacionCausas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1239, 931)
        Me.Controls.Add(Me.UltraGroupBox3)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmDeterminacionCausas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETERMINACION DE CAUSAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardarmodelu As ToolStripButton
    Friend WithEvents btnsalir As ToolStripButton
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Label12 As Label
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtdescripcionCI As TextBox
    Friend WithEvents txtcodigoCI As TextBox
    Friend WithEvents txtasci As TextBox
    Friend WithEvents txtcsci As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtdescripCB As TextBox
    Friend WithEvents txtcodigoCB As TextBox
    Friend WithEvents txtfpcb As TextBox
    Friend WithEvents txtftcb As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txtfaltafc As TextBox
    Friend WithEvents txtcodfc As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblContador As Label
    Friend WithEvents lblContador1 As Label
    Friend WithEvents lblContador2 As Label
    Friend WithEvents lblContador3 As Label
End Class
