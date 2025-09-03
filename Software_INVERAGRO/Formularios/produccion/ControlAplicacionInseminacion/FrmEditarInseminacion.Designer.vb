<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditarInseminacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditarInseminacion))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtCondCorporal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCodArete = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblDosisDisponibles = New System.Windows.Forms.Label()
        Me.TxtCodInseminacion = New System.Windows.Forms.TextBox()
        Me.BtnBuscarMG = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnEncargado = New System.Windows.Forms.Button()
        Me.TxtNombreEncargado = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDniEncargado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtCantExpulsada = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumDosisInseminar = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbViaAplicacion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpFechaMonta = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumDosisInseminar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TxtCondCorporal)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.LblCodArete)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 593)
        Me.Panel2.TabIndex = 10
        '
        'TxtCondCorporal
        '
        Me.TxtCondCorporal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCondCorporal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCondCorporal.Location = New System.Drawing.Point(670, 80)
        Me.TxtCondCorporal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCondCorporal.MaxLength = 50
        Me.TxtCondCorporal.Name = "TxtCondCorporal"
        Me.TxtCondCorporal.Size = New System.Drawing.Size(90, 28)
        Me.TxtCondCorporal.TabIndex = 179
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(499, 83)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 22)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Cond Corporal :"
        '
        'LblCodArete
        '
        Me.LblCodArete.AutoSize = True
        Me.LblCodArete.BackColor = System.Drawing.Color.Yellow
        Me.LblCodArete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodArete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblCodArete.Location = New System.Drawing.Point(51, 80)
        Me.LblCodArete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCodArete.Name = "LblCodArete"
        Me.LblCodArete.Size = New System.Drawing.Size(65, 29)
        Me.LblCodArete.TabIndex = 216
        Me.LblCodArete.Text = "- - -"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.LblDosisDisponibles)
        Me.GroupBox2.Controls.Add(Me.TxtCodInseminacion)
        Me.GroupBox2.Controls.Add(Me.BtnBuscarMG)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 291)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(766, 143)
        Me.GroupBox2.TabIndex = 181
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información General"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(47, 37)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 22)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "Código Semen Verraco :"
        '
        'LblDosisDisponibles
        '
        Me.LblDosisDisponibles.AutoSize = True
        Me.LblDosisDisponibles.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LblDosisDisponibles.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDosisDisponibles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblDosisDisponibles.Location = New System.Drawing.Point(300, 85)
        Me.LblDosisDisponibles.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblDosisDisponibles.Name = "LblDosisDisponibles"
        Me.LblDosisDisponibles.Size = New System.Drawing.Size(65, 29)
        Me.LblDosisDisponibles.TabIndex = 177
        Me.LblDosisDisponibles.Text = "- - -"
        '
        'TxtCodInseminacion
        '
        Me.TxtCodInseminacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodInseminacion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodInseminacion.Location = New System.Drawing.Point(300, 34)
        Me.TxtCodInseminacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCodInseminacion.MaxLength = 50
        Me.TxtCodInseminacion.Name = "TxtCodInseminacion"
        Me.TxtCodInseminacion.Size = New System.Drawing.Size(152, 28)
        Me.TxtCodInseminacion.TabIndex = 178
        '
        'BtnBuscarMG
        '
        Me.BtnBuscarMG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarMG.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarMG.Image = CType(resources.GetObject("BtnBuscarMG.Image"), System.Drawing.Image)
        Me.BtnBuscarMG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarMG.Location = New System.Drawing.Point(480, 26)
        Me.BtnBuscarMG.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarMG.Name = "BtnBuscarMG"
        Me.BtnBuscarMG.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarMG.TabIndex = 168
        Me.BtnBuscarMG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarMG.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(74, 88)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(203, 22)
        Me.Label10.TabIndex = 176
        Me.Label10.Text = "N° Dosis Disponibles:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnEncargado)
        Me.GroupBox3.Controls.Add(Me.TxtNombreEncargado)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.TxtDniEncargado)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 440)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(766, 138)
        Me.GroupBox3.TabIndex = 181
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inseminador"
        '
        'BtnEncargado
        '
        Me.BtnEncargado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEncargado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEncargado.Image = CType(resources.GetObject("BtnEncargado.Image"), System.Drawing.Image)
        Me.BtnEncargado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEncargado.Location = New System.Drawing.Point(625, 27)
        Me.BtnEncargado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnEncargado.Name = "BtnEncargado"
        Me.BtnEncargado.Size = New System.Drawing.Size(48, 45)
        Me.BtnEncargado.TabIndex = 168
        Me.BtnEncargado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEncargado.UseVisualStyleBackColor = True
        '
        'TxtNombreEncargado
        '
        Me.TxtNombreEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreEncargado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNombreEncargado.Location = New System.Drawing.Point(196, 86)
        Me.TxtNombreEncargado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtNombreEncargado.MaxLength = 50
        Me.TxtNombreEncargado.Name = "TxtNombreEncargado"
        Me.TxtNombreEncargado.Size = New System.Drawing.Size(477, 28)
        Me.TxtNombreEncargado.TabIndex = 170
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(123, 38)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 22)
        Me.Label12.TabIndex = 168
        Me.Label12.Text = "DNI :"
        '
        'TxtDniEncargado
        '
        Me.TxtDniEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDniEncargado.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDniEncargado.Location = New System.Drawing.Point(196, 35)
        Me.TxtDniEncargado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDniEncargado.MaxLength = 50
        Me.TxtDniEncargado.Name = "TxtDniEncargado"
        Me.TxtDniEncargado.Size = New System.Drawing.Size(288, 28)
        Me.TxtDniEncargado.TabIndex = 168
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(56, 89)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 22)
        Me.Label11.TabIndex = 169
        Me.Label11.Text = "Encargado :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtCantExpulsada)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NumDosisInseminar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CmbViaAplicacion)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DtpFechaMonta)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(766, 147)
        Me.GroupBox1.TabIndex = 180
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información Material Genético"
        '
        'TxtCantExpulsada
        '
        Me.TxtCantExpulsada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCantExpulsada.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantExpulsada.Location = New System.Drawing.Point(248, 90)
        Me.TxtCantExpulsada.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCantExpulsada.MaxLength = 3
        Me.TxtCantExpulsada.Name = "TxtCantExpulsada"
        Me.TxtCantExpulsada.Size = New System.Drawing.Size(90, 28)
        Me.TxtCantExpulsada.TabIndex = 166
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(30, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 22)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Cantidad Expulsada :"
        '
        'NumDosisInseminar
        '
        Me.NumDosisInseminar.Location = New System.Drawing.Point(529, 94)
        Me.NumDosisInseminar.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumDosisInseminar.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumDosisInseminar.Name = "NumDosisInseminar"
        Me.NumDosisInseminar.Size = New System.Drawing.Size(120, 26)
        Me.NumDosisInseminar.TabIndex = 175
        Me.NumDosisInseminar.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(388, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 22)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "N° de Dosis :"
        '
        'CmbViaAplicacion
        '
        Me.CmbViaAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbViaAplicacion.FormattingEnabled = True
        Me.CmbViaAplicacion.Items.AddRange(New Object() {"CERVICAL", "POST-CERVICAL"})
        Me.CmbViaAplicacion.Location = New System.Drawing.Point(529, 37)
        Me.CmbViaAplicacion.Name = "CmbViaAplicacion"
        Me.CmbViaAplicacion.Size = New System.Drawing.Size(209, 28)
        Me.CmbViaAplicacion.TabIndex = 177
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(465, 40)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 22)
        Me.Label7.TabIndex = 176
        Me.Label7.Text = "Vía :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(94, 40)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 22)
        Me.Label9.TabIndex = 173
        Me.Label9.Text = "Fecha Monta :"
        '
        'DtpFechaMonta
        '
        Me.DtpFechaMonta.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaMonta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaMonta.Location = New System.Drawing.Point(248, 37)
        Me.DtpFechaMonta.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFechaMonta.Name = "DtpFechaMonta"
        Me.DtpFechaMonta.Size = New System.Drawing.Size(179, 28)
        Me.DtpFechaMonta.TabIndex = 174
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnGuardar, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(807, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.editar_texto
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardar.Size = New System.Drawing.Size(98, 30)
        Me.BtnGuardar.Text = "Editar"
        Me.BtnGuardar.ToolTipText = "Guardar"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.ForeColor = System.Drawing.Color.White
        Me.BtnCerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.BtnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnCerrar.Size = New System.Drawing.Size(84, 30)
        Me.BtnCerrar.Text = "Salir"
        Me.BtnCerrar.ToolTipText = "Cerrar"
        '
        'FrmEditarInseminacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 593)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditarInseminacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EDITAR INSEMINACIÓN"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumDosisInseminar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtCodInseminacion As TextBox
    Friend WithEvents LblDosisDisponibles As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents BtnBuscarMG As Button
    Friend WithEvents CmbViaAplicacion As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents NumDosisInseminar As NumericUpDown
    Friend WithEvents DtpFechaMonta As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtCantExpulsada As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCondCorporal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnEncargado As Button
    Friend WithEvents TxtNombreEncargado As TextBox
    Friend WithEvents TxtDniEncargado As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblCodArete As Label
End Class
