<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRegistrarMovimientoLechon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrarMovimientoLechon))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.NumCriasDonar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnCriasCerda = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBloquearFechaMovimiento = New System.Windows.Forms.Button()
        Me.BtnBuscarCerda1 = New System.Windows.Forms.Button()
        Me.LblTotalCrias1 = New System.Windows.Forms.Label()
        Me.LblCrias1 = New System.Windows.Forms.Label()
        Me.LblTotalCrias2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RtnDejarVacia = New System.Windows.Forms.RadioButton()
        Me.RtnSeguirLactando = New System.Windows.Forms.RadioButton()
        Me.BtnBuscarCerda2 = New System.Windows.Forms.Button()
        Me.TxtCodArete2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbAccion = New System.Windows.Forms.ComboBox()
        Me.DtpFechaMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodArete1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.BtnBloqueoCerda1 = New System.Windows.Forms.Button()
        Me.BtnBloqueoCerda2 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(946, 467)
        Me.Panel2.TabIndex = 13
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblMensaje)
        Me.GroupBox2.Controls.Add(Me.NumCriasDonar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.BtnCriasCerda)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 350)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(881, 101)
        Me.GroupBox2.TabIndex = 227
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cantidad Crias"
        '
        'LblMensaje
        '
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.BackColor = System.Drawing.Color.Yellow
        Me.LblMensaje.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.ForeColor = System.Drawing.Color.Black
        Me.LblMensaje.Location = New System.Drawing.Point(528, 50)
        Me.LblMensaje.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(16, 18)
        Me.LblMensaje.TabIndex = 227
        Me.LblMensaje.Text = "-"
        '
        'NumCriasDonar
        '
        Me.NumCriasDonar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.NumCriasDonar.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumCriasDonar.Location = New System.Drawing.Point(237, 45)
        Me.NumCriasDonar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.NumCriasDonar.MaxLength = 50
        Me.NumCriasDonar.Name = "NumCriasDonar"
        Me.NumCriasDonar.Size = New System.Drawing.Size(78, 28)
        Me.NumCriasDonar.TabIndex = 217
        Me.NumCriasDonar.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(117, 48)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 22)
        Me.Label4.TabIndex = 216
        Me.Label4.Text = "Cantidad :"
        '
        'BtnCriasCerda
        '
        Me.BtnCriasCerda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCriasCerda.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCriasCerda.Image = CType(resources.GetObject("BtnCriasCerda.Image"), System.Drawing.Image)
        Me.BtnCriasCerda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCriasCerda.Location = New System.Drawing.Point(337, 37)
        Me.BtnCriasCerda.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnCriasCerda.Name = "BtnCriasCerda"
        Me.BtnCriasCerda.Size = New System.Drawing.Size(48, 45)
        Me.BtnCriasCerda.TabIndex = 218
        Me.BtnCriasCerda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCriasCerda.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnBloqueoCerda2)
        Me.GroupBox1.Controls.Add(Me.BtnBloqueoCerda1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarCerda1)
        Me.GroupBox1.Controls.Add(Me.LblTotalCrias1)
        Me.GroupBox1.Controls.Add(Me.BtnBloquearFechaMovimiento)
        Me.GroupBox1.Controls.Add(Me.LblCrias1)
        Me.GroupBox1.Controls.Add(Me.LblTotalCrias2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.RtnDejarVacia)
        Me.GroupBox1.Controls.Add(Me.RtnSeguirLactando)
        Me.GroupBox1.Controls.Add(Me.BtnBuscarCerda2)
        Me.GroupBox1.Controls.Add(Me.TxtCodArete2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CmbAccion)
        Me.GroupBox1.Controls.Add(Me.DtpFechaMovimiento)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtCodArete1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(903, 252)
        Me.GroupBox1.TabIndex = 160
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la madre"
        '
        'BtnBloquearFechaMovimiento
        '
        Me.BtnBloquearFechaMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloquearFechaMovimiento.AutoSize = True
        Me.BtnBloquearFechaMovimiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloquearFechaMovimiento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloquearFechaMovimiento.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloquearFechaMovimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloquearFechaMovimiento.Location = New System.Drawing.Point(839, 46)
        Me.BtnBloquearFechaMovimiento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloquearFechaMovimiento.Name = "BtnBloquearFechaMovimiento"
        Me.BtnBloquearFechaMovimiento.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloquearFechaMovimiento.TabIndex = 228
        Me.BtnBloquearFechaMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloquearFechaMovimiento.UseVisualStyleBackColor = True
        '
        'BtnBuscarCerda1
        '
        Me.BtnBuscarCerda1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCerda1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarCerda1.Image = CType(resources.GetObject("BtnBuscarCerda1.Image"), System.Drawing.Image)
        Me.BtnBuscarCerda1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCerda1.Location = New System.Drawing.Point(310, 42)
        Me.BtnBuscarCerda1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarCerda1.Name = "BtnBuscarCerda1"
        Me.BtnBuscarCerda1.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarCerda1.TabIndex = 227
        Me.BtnBuscarCerda1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCerda1.UseVisualStyleBackColor = True
        '
        'LblTotalCrias1
        '
        Me.LblTotalCrias1.AutoSize = True
        Me.LblTotalCrias1.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalCrias1.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCrias1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTotalCrias1.Location = New System.Drawing.Point(265, 86)
        Me.LblTotalCrias1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalCrias1.Name = "LblTotalCrias1"
        Me.LblTotalCrias1.Size = New System.Drawing.Size(18, 17)
        Me.LblTotalCrias1.TabIndex = 226
        Me.LblTotalCrias1.Text = "0"
        '
        'LblCrias1
        '
        Me.LblCrias1.AutoSize = True
        Me.LblCrias1.BackColor = System.Drawing.Color.Transparent
        Me.LblCrias1.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCrias1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCrias1.Location = New System.Drawing.Point(174, 86)
        Me.LblCrias1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCrias1.Name = "LblCrias1"
        Me.LblCrias1.Size = New System.Drawing.Size(82, 17)
        Me.LblCrias1.TabIndex = 225
        Me.LblCrias1.Text = "N° Crías :"
        '
        'LblTotalCrias2
        '
        Me.LblTotalCrias2.AutoSize = True
        Me.LblTotalCrias2.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalCrias2.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCrias2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTotalCrias2.Location = New System.Drawing.Point(733, 170)
        Me.LblTotalCrias2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalCrias2.Name = "LblTotalCrias2"
        Me.LblTotalCrias2.Size = New System.Drawing.Size(18, 17)
        Me.LblTotalCrias2.TabIndex = 224
        Me.LblTotalCrias2.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(644, 170)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 17)
        Me.Label6.TabIndex = 223
        Me.Label6.Text = "N° Crías :"
        '
        'RtnDejarVacia
        '
        Me.RtnDejarVacia.AutoSize = True
        Me.RtnDejarVacia.Location = New System.Drawing.Point(53, 198)
        Me.RtnDejarVacia.Name = "RtnDejarVacia"
        Me.RtnDejarVacia.Size = New System.Drawing.Size(112, 24)
        Me.RtnDejarVacia.TabIndex = 222
        Me.RtnDejarVacia.TabStop = True
        Me.RtnDejarVacia.Text = "Dejar vacía"
        Me.RtnDejarVacia.UseVisualStyleBackColor = True
        '
        'RtnSeguirLactando
        '
        Me.RtnSeguirLactando.AutoSize = True
        Me.RtnSeguirLactando.Location = New System.Drawing.Point(211, 198)
        Me.RtnSeguirLactando.Name = "RtnSeguirLactando"
        Me.RtnSeguirLactando.Size = New System.Drawing.Size(145, 24)
        Me.RtnSeguirLactando.TabIndex = 221
        Me.RtnSeguirLactando.TabStop = True
        Me.RtnSeguirLactando.Text = "Seguir lactando"
        Me.RtnSeguirLactando.UseVisualStyleBackColor = True
        '
        'BtnBuscarCerda2
        '
        Me.BtnBuscarCerda2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBuscarCerda2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscarCerda2.Image = CType(resources.GetObject("BtnBuscarCerda2.Image"), System.Drawing.Image)
        Me.BtnBuscarCerda2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBuscarCerda2.Location = New System.Drawing.Point(783, 126)
        Me.BtnBuscarCerda2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBuscarCerda2.Name = "BtnBuscarCerda2"
        Me.BtnBuscarCerda2.Size = New System.Drawing.Size(48, 45)
        Me.BtnBuscarCerda2.TabIndex = 213
        Me.BtnBuscarCerda2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBuscarCerda2.UseVisualStyleBackColor = True
        '
        'TxtCodArete2
        '
        Me.TxtCodArete2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodArete2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodArete2.Location = New System.Drawing.Point(647, 134)
        Me.TxtCodArete2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCodArete2.MaxLength = 50
        Me.TxtCodArete2.Name = "TxtCodArete2"
        Me.TxtCodArete2.Size = New System.Drawing.Size(128, 28)
        Me.TxtCodArete2.TabIndex = 214
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(486, 137)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 22)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "ID hembra 2 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(74, 137)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 22)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Acción :"
        '
        'CmbAccion
        '
        Me.CmbAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAccion.FormattingEnabled = True
        Me.CmbAccion.Items.AddRange(New Object() {"DONAR LECHONES", "RECIBIR LECHONES"})
        Me.CmbAccion.Location = New System.Drawing.Point(174, 134)
        Me.CmbAccion.Name = "CmbAccion"
        Me.CmbAccion.Size = New System.Drawing.Size(228, 28)
        Me.CmbAccion.TabIndex = 211
        '
        'DtpFechaMovimiento
        '
        Me.DtpFechaMovimiento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaMovimiento.Location = New System.Drawing.Point(644, 50)
        Me.DtpFechaMovimiento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtpFechaMovimiento.Name = "DtpFechaMovimiento"
        Me.DtpFechaMovimiento.Size = New System.Drawing.Size(187, 28)
        Me.DtpFechaMovimiento.TabIndex = 209
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(431, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 22)
        Me.Label2.TabIndex = 210
        Me.Label2.Text = "Fecha Movimiento :"
        '
        'TxtCodArete1
        '
        Me.TxtCodArete1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodArete1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodArete1.Location = New System.Drawing.Point(174, 50)
        Me.TxtCodArete1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtCodArete1.MaxLength = 50
        Me.TxtCodArete1.Name = "TxtCodArete1"
        Me.TxtCodArete1.Size = New System.Drawing.Size(128, 28)
        Me.TxtCodArete1.TabIndex = 206
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(32, 53)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 22)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "ID hembra :"
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
        Me.ToolStrip1.Size = New System.Drawing.Size(946, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.BtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.BtnGuardar.Text = "Guardar"
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
        'BtnBloqueoCerda1
        '
        Me.BtnBloqueoCerda1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloqueoCerda1.AutoSize = True
        Me.BtnBloqueoCerda1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloqueoCerda1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloqueoCerda1.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloqueoCerda1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloqueoCerda1.Location = New System.Drawing.Point(366, 46)
        Me.BtnBloqueoCerda1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloqueoCerda1.Name = "BtnBloqueoCerda1"
        Me.BtnBloqueoCerda1.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloqueoCerda1.TabIndex = 229
        Me.BtnBloqueoCerda1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloqueoCerda1.UseVisualStyleBackColor = True
        '
        'BtnBloqueoCerda2
        '
        Me.BtnBloqueoCerda2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBloqueoCerda2.AutoSize = True
        Me.BtnBloqueoCerda2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBloqueoCerda2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBloqueoCerda2.Image = Global.Formularios.My.Resources.Resources.candado_16px
        Me.BtnBloqueoCerda2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBloqueoCerda2.Location = New System.Drawing.Point(839, 130)
        Me.BtnBloqueoCerda2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnBloqueoCerda2.Name = "BtnBloqueoCerda2"
        Me.BtnBloqueoCerda2.Size = New System.Drawing.Size(36, 37)
        Me.BtnBloqueoCerda2.TabIndex = 230
        Me.BtnBloqueoCerda2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnBloqueoCerda2.UseVisualStyleBackColor = True
        '
        'FrmRegistrarMovimientoLechon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 467)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistrarMovimientoLechon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRAR MOVIMIENTO DE LECHÓN"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtCodArete1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnGuardar As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbAccion As ComboBox
    Friend WithEvents DtpFechaMovimiento As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnBuscarCerda2 As Button
    Friend WithEvents TxtCodArete2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NumCriasDonar As TextBox
    Friend WithEvents BtnCriasCerda As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents RtnDejarVacia As RadioButton
    Friend WithEvents RtnSeguirLactando As RadioButton
    Friend WithEvents LblTotalCrias2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblTotalCrias1 As Label
    Friend WithEvents LblCrias1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblMensaje As Label
    Friend WithEvents BtnBuscarCerda1 As Button
    Friend WithEvents BtnBloquearFechaMovimiento As Button
    Friend WithEvents BtnBloqueoCerda2 As Button
    Friend WithEvents BtnBloqueoCerda1 As Button
End Class
