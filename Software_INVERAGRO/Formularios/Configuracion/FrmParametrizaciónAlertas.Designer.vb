<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParametrizaciónAlertas
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TsBtn_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnseleccionar1 = New System.Windows.Forms.Button()
        Me.numv1 = New System.Windows.Forms.NumericUpDown()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.txtprecioplantel5 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtprecioplantel4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtprecioplantel3 = New System.Windows.Forms.TextBox()
        Me.txtprecioplantel2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtprecioplantel1molinero = New System.Windows.Forms.TextBox()
        Me.txtprecioplantel1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_montodarioeventual = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbnagrario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtasignafamiliar = New System.Windows.Forms.TextBox()
        Me.txtessalud = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtseguromasvida = New System.Windows.Forms.TextBox()
        Me.txtsumini = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcostomarrana = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtcostomolino = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(7, 198)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(319, 14)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "Alertar Cuentas por Pagar a partir de : N° Días "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.TsBtn_Cerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1460, 38)
        Me.ToolStrip1.TabIndex = 40
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.Formularios.My.Resources.Resources.saving
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Size = New System.Drawing.Size(184, 28)
        Me.btnGuardar.Tag = "343"
        Me.btnGuardar.Text = "Guardar Configuración"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'TsBtn_Cerrar
        '
        Me.TsBtn_Cerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TsBtn_Cerrar.ForeColor = System.Drawing.Color.White
        Me.TsBtn_Cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.TsBtn_Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.TsBtn_Cerrar.Name = "TsBtn_Cerrar"
        Me.TsBtn_Cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.TsBtn_Cerrar.RightToLeftAutoMirrorImage = True
        Me.TsBtn_Cerrar.Size = New System.Drawing.Size(66, 28)
        Me.TsBtn_Cerrar.Tag = "3434"
        Me.TsBtn_Cerrar.Text = "Salir"
        Me.TsBtn_Cerrar.ToolTipText = "Cerrar"
        '
        'UltraGroupBox1
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Me.UltraGroupBox1.Appearance = Appearance1
        Me.UltraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance2
        Me.UltraGroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Controls.Add(Me.Label12)
        Me.UltraGroupBox1.Controls.Add(Me.btnseleccionar1)
        Me.UltraGroupBox1.Controls.Add(Me.numv1)
        Me.UltraGroupBox1.Controls.Add(Me.picFoto)
        Me.UltraGroupBox1.Controls.Add(Me.Label6)
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Lavender
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 9.0!
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.TextHAlignAsString = "Center"
        Me.UltraGroupBox1.HeaderAppearance = Appearance3
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox1.Location = New System.Drawing.Point(7, 45)
        Me.UltraGroupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(466, 276)
        Me.UltraGroupBox1.TabIndex = 39
        Me.UltraGroupBox1.Text = "PARAMETRIZACIÓN DEL SISTEMA"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(335, 248)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(94, 20)
        Me.NumericUpDown2.TabIndex = 175
        Me.NumericUpDown2.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown2.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 250)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(319, 14)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Alertar Cuentas por Pagar a partir de : N° Días "
        Me.Label2.Visible = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(335, 222)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(94, 20)
        Me.NumericUpDown1.TabIndex = 173
        Me.NumericUpDown1.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 224)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(319, 14)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Alertar Cuentas por Pagar a partir de : N° Días "
        Me.Label1.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(151, 36)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(145, 14)
        Me.Label12.TabIndex = 167
        Me.Label12.Text = "Logo de la Empresa :"
        '
        'btnseleccionar1
        '
        Me.btnseleccionar1.ForeColor = System.Drawing.Color.Black
        Me.btnseleccionar1.Location = New System.Drawing.Point(154, 166)
        Me.btnseleccionar1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnseleccionar1.Name = "btnseleccionar1"
        Me.btnseleccionar1.Size = New System.Drawing.Size(140, 21)
        Me.btnseleccionar1.TabIndex = 171
        Me.btnseleccionar1.Text = "SELECCIONAR IMAGEN"
        Me.btnseleccionar1.UseVisualStyleBackColor = True
        '
        'numv1
        '
        Me.numv1.Location = New System.Drawing.Point(335, 196)
        Me.numv1.Name = "numv1"
        Me.numv1.Size = New System.Drawing.Size(94, 20)
        Me.numv1.TabIndex = 72
        Me.numv1.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'picFoto
        '
        Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFoto.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picFoto.Location = New System.Drawing.Point(154, 55)
        Me.picFoto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(141, 108)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFoto.TabIndex = 168
        Me.picFoto.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'UltraGroupBox2
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Me.UltraGroupBox2.Appearance = Appearance4
        Me.UltraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.UltraGroupBox2.ContentAreaAppearance = Appearance5
        Me.UltraGroupBox2.Controls.Add(Me.txtcostomarrana)
        Me.UltraGroupBox2.Controls.Add(Me.Label17)
        Me.UltraGroupBox2.Controls.Add(Me.txtcostomolino)
        Me.UltraGroupBox2.Controls.Add(Me.Label18)
        Me.UltraGroupBox2.Controls.Add(Me.txtprecioplantel5)
        Me.UltraGroupBox2.Controls.Add(Me.Label10)
        Me.UltraGroupBox2.Controls.Add(Me.txtprecioplantel4)
        Me.UltraGroupBox2.Controls.Add(Me.Label11)
        Me.UltraGroupBox2.Controls.Add(Me.txtprecioplantel3)
        Me.UltraGroupBox2.Controls.Add(Me.txtprecioplantel2)
        Me.UltraGroupBox2.Controls.Add(Me.Label13)
        Me.UltraGroupBox2.Controls.Add(Me.Label14)
        Me.UltraGroupBox2.Controls.Add(Me.txtprecioplantel1molinero)
        Me.UltraGroupBox2.Controls.Add(Me.txtprecioplantel1)
        Me.UltraGroupBox2.Controls.Add(Me.Label15)
        Me.UltraGroupBox2.Controls.Add(Me.Label16)
        Me.UltraGroupBox2.Controls.Add(Me.txt_montodarioeventual)
        Me.UltraGroupBox2.Controls.Add(Me.Label9)
        Me.UltraGroupBox2.Controls.Add(Me.tbnagrario)
        Me.UltraGroupBox2.Controls.Add(Me.Label8)
        Me.UltraGroupBox2.Controls.Add(Me.txtasignafamiliar)
        Me.UltraGroupBox2.Controls.Add(Me.txtessalud)
        Me.UltraGroupBox2.Controls.Add(Me.Label5)
        Me.UltraGroupBox2.Controls.Add(Me.Label7)
        Me.UltraGroupBox2.Controls.Add(Me.txtseguromasvida)
        Me.UltraGroupBox2.Controls.Add(Me.txtsumini)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Controls.Add(Me.Label3)
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Lavender
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.SizeInPoints = 9.0!
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.TextHAlignAsString = "Center"
        Me.UltraGroupBox2.HeaderAppearance = Appearance6
        Me.UltraGroupBox2.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4Thick
        Me.UltraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder
        Me.UltraGroupBox2.Location = New System.Drawing.Point(7, 337)
        Me.UltraGroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(466, 378)
        Me.UltraGroupBox2.TabIndex = 190
        Me.UltraGroupBox2.Text = "PARAMETRIZACIÓN DEL RECURSOS HUMANOS"
        '
        'txtprecioplantel5
        '
        Me.txtprecioplantel5.Location = New System.Drawing.Point(333, 303)
        Me.txtprecioplantel5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtprecioplantel5.Name = "txtprecioplantel5"
        Me.txtprecioplantel5.Size = New System.Drawing.Size(95, 20)
        Me.txtprecioplantel5.TabIndex = 213
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(85, 304)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(239, 14)
        Me.Label10.TabIndex = 212
        Me.Label10.Text = "PRECIO HORA EXTRA PLANTEL 5 : "
        '
        'txtprecioplantel4
        '
        Me.txtprecioplantel4.Location = New System.Drawing.Point(333, 282)
        Me.txtprecioplantel4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtprecioplantel4.Name = "txtprecioplantel4"
        Me.txtprecioplantel4.Size = New System.Drawing.Size(95, 20)
        Me.txtprecioplantel4.TabIndex = 211
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(85, 283)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(239, 14)
        Me.Label11.TabIndex = 210
        Me.Label11.Text = "PRECIO HORA EXTRA PLANTEL 4 : "
        '
        'txtprecioplantel3
        '
        Me.txtprecioplantel3.Location = New System.Drawing.Point(333, 257)
        Me.txtprecioplantel3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtprecioplantel3.Name = "txtprecioplantel3"
        Me.txtprecioplantel3.Size = New System.Drawing.Size(95, 20)
        Me.txtprecioplantel3.TabIndex = 209
        '
        'txtprecioplantel2
        '
        Me.txtprecioplantel2.Location = New System.Drawing.Point(333, 231)
        Me.txtprecioplantel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtprecioplantel2.Name = "txtprecioplantel2"
        Me.txtprecioplantel2.Size = New System.Drawing.Size(95, 20)
        Me.txtprecioplantel2.TabIndex = 208
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(85, 259)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(239, 14)
        Me.Label13.TabIndex = 207
        Me.Label13.Text = "PRECIO HORA EXTRA PLANTEL 3 : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(85, 232)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(239, 14)
        Me.Label14.TabIndex = 206
        Me.Label14.Text = "PRECIO HORA EXTRA PLANTEL 2 : "
        '
        'txtprecioplantel1molinero
        '
        Me.txtprecioplantel1molinero.Location = New System.Drawing.Point(333, 209)
        Me.txtprecioplantel1molinero.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtprecioplantel1molinero.Name = "txtprecioplantel1molinero"
        Me.txtprecioplantel1molinero.Size = New System.Drawing.Size(95, 20)
        Me.txtprecioplantel1molinero.TabIndex = 205
        '
        'txtprecioplantel1
        '
        Me.txtprecioplantel1.Location = New System.Drawing.Point(333, 182)
        Me.txtprecioplantel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtprecioplantel1.Name = "txtprecioplantel1"
        Me.txtprecioplantel1.Size = New System.Drawing.Size(95, 20)
        Me.txtprecioplantel1.TabIndex = 204
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(7, 209)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(313, 14)
        Me.Label15.TabIndex = 203
        Me.Label15.Text = "PRECIO HORA EXTRA PLANTEL 1 MOLINERO :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(84, 183)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(235, 14)
        Me.Label16.TabIndex = 202
        Me.Label16.Text = "PRECIO HORA EXTRA PLANTEL 1 :"
        '
        'txt_montodarioeventual
        '
        Me.txt_montodarioeventual.Location = New System.Drawing.Point(333, 154)
        Me.txt_montodarioeventual.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_montodarioeventual.Name = "txt_montodarioeventual"
        Me.txt_montodarioeventual.Size = New System.Drawing.Size(95, 20)
        Me.txt_montodarioeventual.TabIndex = 201
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(25, 155)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(299, 14)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "MONTO DIARIO DE PERSONAL EVENTUAL : "
        '
        'tbnagrario
        '
        Me.tbnagrario.Location = New System.Drawing.Point(333, 129)
        Me.tbnagrario.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbnagrario.Name = "tbnagrario"
        Me.tbnagrario.Size = New System.Drawing.Size(95, 20)
        Me.tbnagrario.TabIndex = 199
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(82, 130)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(242, 14)
        Me.Label8.TabIndex = 198
        Me.Label8.Text = "PORCENTAJE DE BONO AGRARIO : "
        '
        'txtasignafamiliar
        '
        Me.txtasignafamiliar.Location = New System.Drawing.Point(333, 104)
        Me.txtasignafamiliar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtasignafamiliar.Name = "txtasignafamiliar"
        Me.txtasignafamiliar.Size = New System.Drawing.Size(95, 20)
        Me.txtasignafamiliar.TabIndex = 197
        '
        'txtessalud
        '
        Me.txtessalud.Location = New System.Drawing.Point(333, 77)
        Me.txtessalud.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtessalud.Name = "txtessalud"
        Me.txtessalud.Size = New System.Drawing.Size(95, 20)
        Me.txtessalud.TabIndex = 196
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(32, 105)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(289, 14)
        Me.Label5.TabIndex = 195
        Me.Label5.Text = "PORCENTAJE DE ASIGNACIÓN FAMILIAR: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(240, 79)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 14)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "ESSALUD : "
        '
        'txtseguromasvida
        '
        Me.txtseguromasvida.Location = New System.Drawing.Point(333, 55)
        Me.txtseguromasvida.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtseguromasvida.Name = "txtseguromasvida"
        Me.txtseguromasvida.Size = New System.Drawing.Size(95, 20)
        Me.txtseguromasvida.TabIndex = 193
        '
        'txtsumini
        '
        Me.txtsumini.Location = New System.Drawing.Point(333, 29)
        Me.txtsumini.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtsumini.Name = "txtsumini"
        Me.txtsumini.Size = New System.Drawing.Size(95, 20)
        Me.txtsumini.TabIndex = 192
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(260, 56)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "+VIDA :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(192, 30)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 14)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = "SUELDO MINIMO :"
        '
        'txtcostomarrana
        '
        Me.txtcostomarrana.Location = New System.Drawing.Point(333, 348)
        Me.txtcostomarrana.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcostomarrana.Name = "txtcostomarrana"
        Me.txtcostomarrana.Size = New System.Drawing.Size(95, 20)
        Me.txtcostomarrana.TabIndex = 217
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(92, 349)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(232, 14)
        Me.Label17.TabIndex = 216
        Me.Label17.Text = "PRECIO HORA EXTRA MARRANA : "
        '
        'txtcostomolino
        '
        Me.txtcostomolino.Location = New System.Drawing.Point(333, 327)
        Me.txtcostomolino.Margin = New System.Windows.Forms.Padding(2)
        Me.txtcostomolino.Name = "txtcostomolino"
        Me.txtcostomolino.Size = New System.Drawing.Size(95, 20)
        Me.txtcostomolino.TabIndex = 215
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(148, 327)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(176, 14)
        Me.Label18.TabIndex = 214
        Me.Label18.Text = "PRECIO HORA MOLINO : "
        '
        'FrmParametrizaciónAlertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1460, 722)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "FrmParametrizaciónAlertas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TsBtn_Cerrar As ToolStripButton
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents numv1 As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents btnseleccionar1 As Button
    Friend WithEvents picFoto As PictureBox
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents txt_montodarioeventual As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbnagrario As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtasignafamiliar As TextBox
    Friend WithEvents txtessalud As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtseguromasvida As TextBox
    Friend WithEvents txtsumini As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtprecioplantel5 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtprecioplantel4 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtprecioplantel3 As TextBox
    Friend WithEvents txtprecioplantel2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtprecioplantel1molinero As TextBox
    Friend WithEvents txtprecioplantel1 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtcostomarrana As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtcostomolino As TextBox
    Friend WithEvents Label18 As Label
End Class
