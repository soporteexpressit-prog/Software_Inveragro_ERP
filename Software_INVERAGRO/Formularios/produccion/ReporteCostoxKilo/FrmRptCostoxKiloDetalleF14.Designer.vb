<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCostoxKiloDetalleF14
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
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.LblConsumoCabeza = New System.Windows.Forms.Label()
        Me.LblTotalVendidos = New System.Windows.Forms.Label()
        Me.LblPrecioKiloProm = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTotalAlimento = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblCostoxCabeza = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblRacion = New System.Windows.Forms.Label()
        Me.BarraOpciones = New System.Windows.Forms.ToolStrip()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2.SuspendLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BarraOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Ptbx_Cargando)
        Me.Panel2.Controls.Add(Me.LblConsumoCabeza)
        Me.Panel2.Controls.Add(Me.LblTotalVendidos)
        Me.Panel2.Controls.Add(Me.LblPrecioKiloProm)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.LblTotalAlimento)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.LblCostoxCabeza)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.LblRacion)
        Me.Panel2.Controls.Add(Me.BarraOpciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(305, 301)
        Me.Panel2.TabIndex = 15
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(130, 143)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(43, 37)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 251
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'LblConsumoCabeza
        '
        Me.LblConsumoCabeza.AutoSize = True
        Me.LblConsumoCabeza.BackColor = System.Drawing.Color.Transparent
        Me.LblConsumoCabeza.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsumoCabeza.ForeColor = System.Drawing.Color.Black
        Me.LblConsumoCabeza.Location = New System.Drawing.Point(205, 201)
        Me.LblConsumoCabeza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblConsumoCabeza.Name = "LblConsumoCabeza"
        Me.LblConsumoCabeza.Size = New System.Drawing.Size(14, 13)
        Me.LblConsumoCabeza.TabIndex = 250
        Me.LblConsumoCabeza.Text = "0"
        '
        'LblTotalVendidos
        '
        Me.LblTotalVendidos.AutoSize = True
        Me.LblTotalVendidos.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalVendidos.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalVendidos.ForeColor = System.Drawing.Color.Black
        Me.LblTotalVendidos.Location = New System.Drawing.Point(205, 167)
        Me.LblTotalVendidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalVendidos.Name = "LblTotalVendidos"
        Me.LblTotalVendidos.Size = New System.Drawing.Size(14, 13)
        Me.LblTotalVendidos.TabIndex = 249
        Me.LblTotalVendidos.Text = "0"
        '
        'LblPrecioKiloProm
        '
        Me.LblPrecioKiloProm.AutoSize = True
        Me.LblPrecioKiloProm.BackColor = System.Drawing.Color.Transparent
        Me.LblPrecioKiloProm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecioKiloProm.ForeColor = System.Drawing.Color.Black
        Me.LblPrecioKiloProm.Location = New System.Drawing.Point(205, 134)
        Me.LblPrecioKiloProm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPrecioKiloProm.Name = "LblPrecioKiloProm"
        Me.LblPrecioKiloProm.Size = New System.Drawing.Size(14, 13)
        Me.LblPrecioKiloProm.TabIndex = 248
        Me.LblPrecioKiloProm.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(23, 200)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 14)
        Me.Label1.TabIndex = 247
        Me.Label1.Text = "Consumo x Cabeza (kg) :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(27, 133)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 14)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Precio x Kilo Promedio  :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(52, 102)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 14)
        Me.Label5.TabIndex = 239
        Me.Label5.Text = "Total Alimento (kg) :"
        '
        'LblTotalAlimento
        '
        Me.LblTotalAlimento.AutoSize = True
        Me.LblTotalAlimento.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalAlimento.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAlimento.ForeColor = System.Drawing.Color.Black
        Me.LblTotalAlimento.Location = New System.Drawing.Point(205, 103)
        Me.LblTotalAlimento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTotalAlimento.Name = "LblTotalAlimento"
        Me.LblTotalAlimento.Size = New System.Drawing.Size(14, 13)
        Me.LblTotalAlimento.TabIndex = 224
        Me.LblTotalAlimento.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(84, 166)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 14)
        Me.Label11.TabIndex = 223
        Me.Label11.Text = "Total Vendidos :"
        '
        'LblCostoxCabeza
        '
        Me.LblCostoxCabeza.AutoSize = True
        Me.LblCostoxCabeza.BackColor = System.Drawing.Color.GreenYellow
        Me.LblCostoxCabeza.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCostoxCabeza.ForeColor = System.Drawing.Color.Black
        Me.LblCostoxCabeza.Location = New System.Drawing.Point(205, 239)
        Me.LblCostoxCabeza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCostoxCabeza.Name = "LblCostoxCabeza"
        Me.LblCostoxCabeza.Size = New System.Drawing.Size(16, 16)
        Me.LblCostoxCabeza.TabIndex = 222
        Me.LblCostoxCabeza.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.GreenYellow
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(56, 239)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 16)
        Me.Label6.TabIndex = 221
        Me.Label6.Text = "COSTO X CABEZA :"
        '
        'LblRacion
        '
        Me.LblRacion.AutoSize = True
        Me.LblRacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.LblRacion.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LblRacion.Location = New System.Drawing.Point(84, 56)
        Me.LblRacion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblRacion.Name = "LblRacion"
        Me.LblRacion.Size = New System.Drawing.Size(80, 18)
        Me.LblRacion.TabIndex = 128
        Me.LblRacion.Text = "RACION"
        '
        'BarraOpciones
        '
        Me.BarraOpciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BarraOpciones.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BarraOpciones.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BarraOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCerrar})
        Me.BarraOpciones.Location = New System.Drawing.Point(0, 0)
        Me.BarraOpciones.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.BarraOpciones.Name = "BarraOpciones"
        Me.BarraOpciones.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BarraOpciones.Size = New System.Drawing.Size(305, 38)
        Me.BarraOpciones.TabIndex = 52
        Me.BarraOpciones.Text = "ToolStrip1"
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
        Me.BtnCerrar.Size = New System.Drawing.Size(66, 28)
        Me.BtnCerrar.Text = "Salir"
        '
        'BackgroundWorker1
        '
        '
        'FrmRptCostoxKiloDetalleF14
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 301)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRptCostoxKiloDetalleF14"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE DETALLADO"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BarraOpciones.ResumeLayout(False)
        Me.BarraOpciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblTotalAlimento As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblRacion As Label
    Friend WithEvents BarraOpciones As ToolStrip
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents LblCostoxCabeza As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblConsumoCabeza As Label
    Friend WithEvents LblTotalVendidos As Label
    Friend WithEvents LblPrecioKiloProm As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Ptbx_Cargando As PictureBox
End Class
