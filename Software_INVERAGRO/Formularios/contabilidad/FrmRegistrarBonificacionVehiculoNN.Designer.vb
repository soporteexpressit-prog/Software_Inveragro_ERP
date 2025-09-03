<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistrarBonificacionVehiculoNN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrarBonificacionVehiculoNN))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnBuscarActivo = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumSerie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtfechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSubirArchivoExpediente = New System.Windows.Forms.Button()
        Me.txtArchivoExpediente = New System.Windows.Forms.TextBox()
        Me.txtNumExpediente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSubirArchivoResolucion = New System.Windows.Forms.Button()
        Me.txtArchivoBonificacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtfechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtfechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtfechaResolucion = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumResolucion = New System.Windows.Forms.TextBox()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.txtNumPermiso = New System.Windows.Forms.TextBox()
        Me.lblPlaca = New System.Windows.Forms.Label()
        Me.lblNumSerie = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardarActivo = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1145, 483)
        Me.Panel2.TabIndex = 55
        '
        'btnBuscarActivo
        '
        Me.btnBuscarActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarActivo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarActivo.Image = CType(resources.GetObject("btnBuscarActivo.Image"), System.Drawing.Image)
        Me.btnBuscarActivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarActivo.Location = New System.Drawing.Point(978, 31)
        Me.btnBuscarActivo.Name = "btnBuscarActivo"
        Me.btnBuscarActivo.Size = New System.Drawing.Size(79, 29)
        Me.btnBuscarActivo.TabIndex = 192
        Me.btnBuscarActivo.Text = "Buscar"
        Me.btnBuscarActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarActivo.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(497, 36)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(460, 22)
        Me.txtDescripcion.TabIndex = 190
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(400, 41)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 14)
        Me.Label8.TabIndex = 191
        Me.Label8.Text = "Descripción:"
        '
        'txtNumSerie
        '
        Me.txtNumSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumSerie.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumSerie.Location = New System.Drawing.Point(145, 36)
        Me.txtNumSerie.MaxLength = 50
        Me.txtNumSerie.Name = "txtNumSerie"
        Me.txtNumSerie.Size = New System.Drawing.Size(209, 22)
        Me.txtNumSerie.TabIndex = 160
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(63, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "Nro Serie:"
        '
        'dtfechaApertura
        '
        Me.dtfechaApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfechaApertura.Location = New System.Drawing.Point(146, 75)
        Me.dtfechaApertura.Margin = New System.Windows.Forms.Padding(2)
        Me.dtfechaApertura.Name = "dtfechaApertura"
        Me.dtfechaApertura.Size = New System.Drawing.Size(211, 20)
        Me.dtfechaApertura.TabIndex = 193
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(22, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 14)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "Fecha Apertura:"
        '
        'btnSubirArchivoExpediente
        '
        Me.btnSubirArchivoExpediente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSubirArchivoExpediente.Image = Global.Formularios.My.Resources.Resources.adjunto_archivo
        Me.btnSubirArchivoExpediente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubirArchivoExpediente.Location = New System.Drawing.Point(978, 74)
        Me.btnSubirArchivoExpediente.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSubirArchivoExpediente.Name = "btnSubirArchivoExpediente"
        Me.btnSubirArchivoExpediente.Size = New System.Drawing.Size(84, 29)
        Me.btnSubirArchivoExpediente.TabIndex = 194
        Me.btnSubirArchivoExpediente.Text = "Archivo"
        Me.btnSubirArchivoExpediente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubirArchivoExpediente.UseVisualStyleBackColor = True
        '
        'txtArchivoExpediente
        '
        Me.txtArchivoExpediente.Location = New System.Drawing.Point(497, 78)
        Me.txtArchivoExpediente.Margin = New System.Windows.Forms.Padding(2)
        Me.txtArchivoExpediente.Name = "txtArchivoExpediente"
        Me.txtArchivoExpediente.Size = New System.Drawing.Size(460, 20)
        Me.txtArchivoExpediente.TabIndex = 193
        '
        'txtNumExpediente
        '
        Me.txtNumExpediente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumExpediente.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumExpediente.Location = New System.Drawing.Point(146, 34)
        Me.txtNumExpediente.MaxLength = 20
        Me.txtNumExpediente.Name = "txtNumExpediente"
        Me.txtNumExpediente.Size = New System.Drawing.Size(209, 22)
        Me.txtNumExpediente.TabIndex = 160
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(386, 81)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 14)
        Me.Label7.TabIndex = 192
        Me.Label7.Text = "Subir Archivo :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 14)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "Nro Expediente:"
        '
        'btnSubirArchivoResolucion
        '
        Me.btnSubirArchivoResolucion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSubirArchivoResolucion.Image = Global.Formularios.My.Resources.Resources.adjunto_archivo
        Me.btnSubirArchivoResolucion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSubirArchivoResolucion.Location = New System.Drawing.Point(735, 118)
        Me.btnSubirArchivoResolucion.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSubirArchivoResolucion.Name = "btnSubirArchivoResolucion"
        Me.btnSubirArchivoResolucion.Size = New System.Drawing.Size(86, 27)
        Me.btnSubirArchivoResolucion.TabIndex = 191
        Me.btnSubirArchivoResolucion.Text = "Archivo"
        Me.btnSubirArchivoResolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSubirArchivoResolucion.UseVisualStyleBackColor = True
        '
        'txtArchivoBonificacion
        '
        Me.txtArchivoBonificacion.Location = New System.Drawing.Point(143, 122)
        Me.txtArchivoBonificacion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtArchivoBonificacion.Name = "txtArchivoBonificacion"
        Me.txtArchivoBonificacion.Size = New System.Drawing.Size(562, 20)
        Me.txtArchivoBonificacion.TabIndex = 190
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(28, 128)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 14)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Subir Archivo :"
        '
        'dtfechaFin
        '
        Me.dtfechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfechaFin.Location = New System.Drawing.Point(494, 82)
        Me.dtfechaFin.Margin = New System.Windows.Forms.Padding(2)
        Me.dtfechaFin.Name = "dtfechaFin"
        Me.dtfechaFin.Size = New System.Drawing.Size(211, 20)
        Me.dtfechaFin.TabIndex = 188
        '
        'dtfechaInicio
        '
        Me.dtfechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfechaInicio.Location = New System.Drawing.Point(142, 82)
        Me.dtfechaInicio.Margin = New System.Windows.Forms.Padding(2)
        Me.dtfechaInicio.Name = "dtfechaInicio"
        Me.dtfechaInicio.Size = New System.Drawing.Size(209, 20)
        Me.dtfechaInicio.TabIndex = 187
        '
        'dtfechaResolucion
        '
        Me.dtfechaResolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfechaResolucion.Location = New System.Drawing.Point(868, 82)
        Me.dtfechaResolucion.Margin = New System.Windows.Forms.Padding(2)
        Me.dtfechaResolucion.Name = "dtfechaResolucion"
        Me.dtfechaResolucion.Size = New System.Drawing.Size(226, 20)
        Me.dtfechaResolucion.TabIndex = 186
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(732, 86)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 14)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "Fecha Resolución :"
        '
        'txtNumResolucion
        '
        Me.txtNumResolucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumResolucion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumResolucion.Location = New System.Drawing.Point(494, 34)
        Me.txtNumResolucion.MaxLength = 50
        Me.txtNumResolucion.Name = "txtNumResolucion"
        Me.txtNumResolucion.Size = New System.Drawing.Size(211, 22)
        Me.txtNumResolucion.TabIndex = 184
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.BackColor = System.Drawing.Color.Transparent
        Me.lblCapacidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblCapacidad.Location = New System.Drawing.Point(374, 37)
        Me.lblCapacidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(109, 14)
        Me.lblCapacidad.TabIndex = 183
        Me.lblCapacidad.Text = "Nro Resolución :"
        '
        'txtNumPermiso
        '
        Me.txtNumPermiso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumPermiso.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPermiso.Location = New System.Drawing.Point(142, 34)
        Me.txtNumPermiso.MaxLength = 10
        Me.txtNumPermiso.Name = "txtNumPermiso"
        Me.txtNumPermiso.Size = New System.Drawing.Size(209, 22)
        Me.txtNumPermiso.TabIndex = 182
        '
        'lblPlaca
        '
        Me.lblPlaca.AutoSize = True
        Me.lblPlaca.BackColor = System.Drawing.Color.Transparent
        Me.lblPlaca.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblPlaca.Location = New System.Drawing.Point(17, 39)
        Me.lblPlaca.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPlaca.Name = "lblPlaca"
        Me.lblPlaca.Size = New System.Drawing.Size(108, 14)
        Me.lblPlaca.TabIndex = 181
        Me.lblPlaca.Text = "Nro de Permiso:"
        '
        'lblNumSerie
        '
        Me.lblNumSerie.AutoSize = True
        Me.lblNumSerie.BackColor = System.Drawing.Color.Transparent
        Me.lblNumSerie.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumSerie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblNumSerie.Location = New System.Drawing.Point(412, 87)
        Me.lblNumSerie.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumSerie.Name = "lblNumSerie"
        Me.lblNumSerie.Size = New System.Drawing.Size(71, 14)
        Me.lblNumSerie.TabIndex = 177
        Me.lblNumSerie.Text = "Fecha Fin:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lblDescripcion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(39, 82)
        Me.lblDescripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(86, 14)
        Me.lblDescripcion.TabIndex = 159
        Me.lblDescripcion.Text = "Fecha Inicio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(11, 49)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(450, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "REGISTRAR BONIFICACIÓN VEHÍCULOS CON SNN"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardarActivo, Me.btnSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Margin = New System.Windows.Forms.Padding(2)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip2.Size = New System.Drawing.Size(1145, 38)
        Me.ToolStrip2.TabIndex = 52
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnGuardarActivo
        '
        Me.btnGuardarActivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarActivo.ForeColor = System.Drawing.Color.White
        Me.btnGuardarActivo.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardarActivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardarActivo.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardarActivo.Name = "btnGuardarActivo"
        Me.btnGuardarActivo.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardarActivo.Size = New System.Drawing.Size(89, 28)
        Me.btnGuardarActivo.Text = "Guardar"
        Me.btnGuardarActivo.ToolTipText = "Guardar"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Padding = New System.Windows.Forms.Padding(2)
        Me.btnSalir.Size = New System.Drawing.Size(66, 28)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Cerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscarActivo)
        Me.GroupBox1.Controls.Add(Me.txtNumSerie)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 386)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1116, 74)
        Me.GroupBox1.TabIndex = 56
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del Activo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtfechaApertura)
        Me.GroupBox2.Controls.Add(Me.btnSubirArchivoExpediente)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtArchivoExpediente)
        Me.GroupBox2.Controls.Add(Me.txtNumExpediente)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 250)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1116, 115)
        Me.GroupBox2.TabIndex = 191
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información del Expediente:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSubirArchivoResolucion)
        Me.GroupBox3.Controls.Add(Me.txtArchivoBonificacion)
        Me.GroupBox3.Controls.Add(Me.lblDescripcion)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.lblNumSerie)
        Me.GroupBox3.Controls.Add(Me.dtfechaFin)
        Me.GroupBox3.Controls.Add(Me.lblPlaca)
        Me.GroupBox3.Controls.Add(Me.dtfechaInicio)
        Me.GroupBox3.Controls.Add(Me.txtNumPermiso)
        Me.GroupBox3.Controls.Add(Me.dtfechaResolucion)
        Me.GroupBox3.Controls.Add(Me.lblCapacidad)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtNumResolucion)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(14, 80)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1113, 164)
        Me.GroupBox3.TabIndex = 56
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información de Bonificación:"
        '
        'FrmRegistrarBonificacionVehiculoNN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1145, 480)
        Me.Controls.Add(Me.Panel2)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(1161, 519)
        Me.MinimumSize = New System.Drawing.Size(1161, 519)
        Me.Name = "FrmRegistrarBonificacionVehiculoNN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BONIFICACIONES PARA VEHÍCULOS CON SUSPENSIÓN NEUMÁTICA O NEUMÁTICOS EXTRA ANCHOS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtNumResolucion As TextBox
    Friend WithEvents lblCapacidad As Label
    Friend WithEvents txtNumPermiso As TextBox
    Friend WithEvents lblPlaca As Label
    Friend WithEvents lblNumSerie As Label
    Friend WithEvents txtNumExpediente As TextBox
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnGuardarActivo As ToolStripButton
    Friend WithEvents btnSalir As ToolStripButton
    Friend WithEvents dtfechaFin As DateTimePicker
    Friend WithEvents dtfechaInicio As DateTimePicker
    Friend WithEvents dtfechaResolucion As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNumSerie As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSubirArchivoResolucion As Button
    Friend WithEvents txtArchivoBonificacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtfechaApertura As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSubirArchivoExpediente As Button
    Friend WithEvents txtArchivoExpediente As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnBuscarActivo As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
