<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteBajada
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblDiaPic = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnExportarBajada = New System.Windows.Forms.ToolStripButton()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblPesoPromedio = New System.Windows.Forms.Label()
        Me.LblPesoProm = New System.Windows.Forms.Label()
        Me.LblPesoTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblTotalCamborEnviadas = New System.Windows.Forms.Label()
        Me.LblPorcMortalidad = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTotalMortalidad = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblTotalEngordeEnviadas = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblTotalAniEnviados = New System.Windows.Forms.Label()
        Me.LblTotalPurasEnviadas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbLotes = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.CmbAnios = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.DtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CmbLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LblDiaPic)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.CmbLotes)
        Me.Panel2.Controls.Add(Me.CmbAnios)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1685, 313)
        Me.Panel2.TabIndex = 16
        '
        'LblDiaPic
        '
        Me.LblDiaPic.AutoSize = True
        Me.LblDiaPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblDiaPic.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiaPic.ForeColor = System.Drawing.Color.Green
        Me.LblDiaPic.Location = New System.Drawing.Point(32, 48)
        Me.LblDiaPic.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblDiaPic.Name = "LblDiaPic"
        Me.LblDiaPic.Size = New System.Drawing.Size(253, 29)
        Me.LblDiaPic.TabIndex = 241
        Me.LblDiaPic.Text = "REPORTE BAJADA"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnExportarBajada, Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 273)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1685, 40)
        Me.ToolStrip1.TabIndex = 181
        Me.ToolStrip1.Text = "Monitoreo"
        '
        'BtnExportarBajada
        '
        Me.BtnExportarBajada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarBajada.ForeColor = System.Drawing.Color.White
        Me.BtnExportarBajada.Image = Global.Formularios.My.Resources.Resources.exportar2
        Me.BtnExportarBajada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExportarBajada.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnExportarBajada.Name = "BtnExportarBajada"
        Me.BtnExportarBajada.Padding = New System.Windows.Forms.Padding(2)
        Me.BtnExportarBajada.Size = New System.Drawing.Size(125, 30)
        Me.BtnExportarBajada.Text = "Exportar"
        Me.BtnExportarBajada.ToolTipText = "Exportar"
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
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblPesoPromedio)
        Me.GroupBox1.Controls.Add(Me.LblPesoProm)
        Me.GroupBox1.Controls.Add(Me.LblPesoTotal)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.LblTotalCamborEnviadas)
        Me.GroupBox1.Controls.Add(Me.LblPorcMortalidad)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LblTotalMortalidad)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblTotalEngordeEnviadas)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LblTotalAniEnviados)
        Me.GroupBox1.Controls.Add(Me.LblTotalPurasEnviadas)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1631, 139)
        Me.GroupBox1.TabIndex = 180
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de Partos"
        '
        'LblPesoPromedio
        '
        Me.LblPesoPromedio.AutoSize = True
        Me.LblPesoPromedio.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoPromedio.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoPromedio.ForeColor = System.Drawing.Color.Black
        Me.LblPesoPromedio.Location = New System.Drawing.Point(1441, 88)
        Me.LblPesoPromedio.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoPromedio.Name = "LblPesoPromedio"
        Me.LblPesoPromedio.Size = New System.Drawing.Size(21, 22)
        Me.LblPesoPromedio.TabIndex = 197
        Me.LblPesoPromedio.Text = "0"
        '
        'LblPesoProm
        '
        Me.LblPesoProm.AutoSize = True
        Me.LblPesoProm.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoProm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoProm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblPesoProm.Location = New System.Drawing.Point(1311, 88)
        Me.LblPesoProm.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoProm.Name = "LblPesoProm"
        Me.LblPesoProm.Size = New System.Drawing.Size(18, 22)
        Me.LblPesoProm.TabIndex = 196
        Me.LblPesoProm.Text = "-"
        '
        'LblPesoTotal
        '
        Me.LblPesoTotal.AutoSize = True
        Me.LblPesoTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoTotal.ForeColor = System.Drawing.Color.Black
        Me.LblPesoTotal.Location = New System.Drawing.Point(1441, 42)
        Me.LblPesoTotal.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoTotal.Name = "LblPesoTotal"
        Me.LblPesoTotal.Size = New System.Drawing.Size(21, 22)
        Me.LblPesoTotal.TabIndex = 195
        Me.LblPesoTotal.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(1311, 42)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 22)
        Me.Label12.TabIndex = 194
        Me.Label12.Text = "Peso Total :"
        '
        'LblTotalCamborEnviadas
        '
        Me.LblTotalCamborEnviadas.AutoSize = True
        Me.LblTotalCamborEnviadas.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalCamborEnviadas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalCamborEnviadas.ForeColor = System.Drawing.Color.Black
        Me.LblTotalCamborEnviadas.Location = New System.Drawing.Point(740, 42)
        Me.LblTotalCamborEnviadas.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalCamborEnviadas.Name = "LblTotalCamborEnviadas"
        Me.LblTotalCamborEnviadas.Size = New System.Drawing.Size(21, 22)
        Me.LblTotalCamborEnviadas.TabIndex = 193
        Me.LblTotalCamborEnviadas.Text = "0"
        '
        'LblPorcMortalidad
        '
        Me.LblPorcMortalidad.AutoSize = True
        Me.LblPorcMortalidad.BackColor = System.Drawing.Color.Transparent
        Me.LblPorcMortalidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPorcMortalidad.ForeColor = System.Drawing.Color.Black
        Me.LblPorcMortalidad.Location = New System.Drawing.Point(1141, 88)
        Me.LblPorcMortalidad.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPorcMortalidad.Name = "LblPorcMortalidad"
        Me.LblPorcMortalidad.Size = New System.Drawing.Size(21, 22)
        Me.LblPorcMortalidad.TabIndex = 192
        Me.LblPorcMortalidad.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(979, 88)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 22)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "% Mortalidad :"
        '
        'LblTotalMortalidad
        '
        Me.LblTotalMortalidad.AutoSize = True
        Me.LblTotalMortalidad.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalMortalidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMortalidad.ForeColor = System.Drawing.Color.Black
        Me.LblTotalMortalidad.Location = New System.Drawing.Point(1141, 42)
        Me.LblTotalMortalidad.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalMortalidad.Name = "LblTotalMortalidad"
        Me.LblTotalMortalidad.Size = New System.Drawing.Size(21, 22)
        Me.LblTotalMortalidad.TabIndex = 190
        Me.LblTotalMortalidad.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(955, 42)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 22)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "Total Mortalidad :"
        '
        'LblTotalEngordeEnviadas
        '
        Me.LblTotalEngordeEnviadas.AutoSize = True
        Me.LblTotalEngordeEnviadas.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalEngordeEnviadas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalEngordeEnviadas.ForeColor = System.Drawing.Color.Black
        Me.LblTotalEngordeEnviadas.Location = New System.Drawing.Point(740, 88)
        Me.LblTotalEngordeEnviadas.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalEngordeEnviadas.Name = "LblTotalEngordeEnviadas"
        Me.LblTotalEngordeEnviadas.Size = New System.Drawing.Size(21, 22)
        Me.LblTotalEngordeEnviadas.TabIndex = 188
        Me.LblTotalEngordeEnviadas.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(495, 88)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(233, 22)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "Total Engorde Enviados :"
        '
        'LblTotalAniEnviados
        '
        Me.LblTotalAniEnviados.AutoSize = True
        Me.LblTotalAniEnviados.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalAniEnviados.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAniEnviados.ForeColor = System.Drawing.Color.Black
        Me.LblTotalAniEnviados.Location = New System.Drawing.Point(279, 42)
        Me.LblTotalAniEnviados.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalAniEnviados.Name = "LblTotalAniEnviados"
        Me.LblTotalAniEnviados.Size = New System.Drawing.Size(21, 22)
        Me.LblTotalAniEnviados.TabIndex = 176
        Me.LblTotalAniEnviados.Text = "0"
        '
        'LblTotalPurasEnviadas
        '
        Me.LblTotalPurasEnviadas.AutoSize = True
        Me.LblTotalPurasEnviadas.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalPurasEnviadas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPurasEnviadas.ForeColor = System.Drawing.Color.Black
        Me.LblTotalPurasEnviadas.Location = New System.Drawing.Point(279, 88)
        Me.LblTotalPurasEnviadas.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalPurasEnviadas.Name = "LblTotalPurasEnviadas"
        Me.LblTotalPurasEnviadas.Size = New System.Drawing.Size(21, 22)
        Me.LblTotalPurasEnviadas.TabIndex = 174
        Me.LblTotalPurasEnviadas.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(453, 42)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(275, 22)
        Me.Label4.TabIndex = 171
        Me.Label4.Text = "Total Camborough Enviadas :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(26, 42)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 22)
        Me.Label1.TabIndex = 169
        Me.Label1.Text = "Total Animales Enviados :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(58, 88)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(209, 22)
        Me.Label10.TabIndex = 168
        Me.Label10.Text = "Total Puras Enviadas :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(582, 51)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 22)
        Me.Label5.TabIndex = 178
        Me.Label5.Text = "Lotes :"
        '
        'CmbLotes
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.CmbLotes.DisplayLayout.Appearance = Appearance1
        Me.CmbLotes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.CmbLotes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbLotes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbLotes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.CmbLotes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.CmbLotes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.CmbLotes.DisplayLayout.MaxColScrollRegions = 1
        Me.CmbLotes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmbLotes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.CmbLotes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.CmbLotes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.CmbLotes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.CmbLotes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.CmbLotes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.CmbLotes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.CmbLotes.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.CmbLotes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.CmbLotes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.CmbLotes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.CmbLotes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.CmbLotes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.CmbLotes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.CmbLotes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.CmbLotes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.CmbLotes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.CmbLotes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.CmbLotes.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.CmbLotes.Location = New System.Drawing.Point(671, 48)
        Me.CmbLotes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmbLotes.Name = "CmbLotes"
        Me.CmbLotes.Size = New System.Drawing.Size(157, 29)
        Me.CmbLotes.TabIndex = 177
        '
        'CmbAnios
        '
        Me.CmbAnios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbAnios.FormattingEnabled = True
        Me.CmbAnios.Location = New System.Drawing.Point(403, 46)
        Me.CmbAnios.Name = "CmbAnios"
        Me.CmbAnios.Size = New System.Drawing.Size(159, 33)
        Me.CmbAnios.TabIndex = 176
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(335, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 22)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Año :"
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(772, 553)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 43
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'DtgListado
        '
        Appearance13.BackColor = System.Drawing.Color.White
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance13.FontData.Name = "Verdana"
        Me.DtgListado.DisplayLayout.Appearance = Appearance13
        Me.DtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.DtgListado.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.DtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.DtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.DtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.DtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.Navy
        Appearance18.ForeColor = System.Drawing.Color.White
        Me.DtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.DtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.DtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.DtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.DtgListado.DisplayLayout.Override.CellAppearance = Appearance20
        Me.DtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.DtgListado.DisplayLayout.Override.CellPadding = 0
        Me.DtgListado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.DtgListado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.DtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.Color.AliceBlue
        Appearance22.BackColor2 = System.Drawing.Color.Silver
        Appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.TextHAlignAsString = "Left"
        Me.DtgListado.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.DtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.DtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.DtgListado.DisplayLayout.Override.RowAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.Color.White
        Me.DtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.Color.White
        Me.DtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance25
        Appearance26.BackColor = System.Drawing.Color.Navy
        Me.DtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance26
        Me.DtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
        Me.DtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
        Me.DtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.DtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.DtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.DtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgListado.Location = New System.Drawing.Point(0, 313)
        Me.DtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DtgListado.Name = "DtgListado"
        Me.DtgListado.Size = New System.Drawing.Size(1685, 597)
        Me.DtgListado.TabIndex = 42
        Me.DtgListado.Text = "UltraGrid1"
        '
        'BackgroundWorker1
        '
        '
        'FrmReporteBajada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1685, 910)
        Me.Controls.Add(Me.Ptbx_Cargando)
        Me.Controls.Add(Me.DtgListado)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReporteBajada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Bajada"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CmbLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblDiaPic As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnExportarBajada As ToolStripButton
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblTotalMortalidad As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblTotalEngordeEnviadas As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LblTotalAniEnviados As Label
    Friend WithEvents LblTotalPurasEnviadas As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents CmbLotes As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CmbAnios As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents DtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblPorcMortalidad As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTotalCamborEnviadas As Label
    Friend WithEvents LblPesoPromedio As Label
    Friend WithEvents LblPesoProm As Label
    Friend WithEvents LblPesoTotal As Label
    Friend WithEvents Label12 As Label
End Class
