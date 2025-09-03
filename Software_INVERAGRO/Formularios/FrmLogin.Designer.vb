<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.btncerrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnverclave = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtclave = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btningresar = New System.Windows.Forms.Button()
        Me.RtnPruebas = New System.Windows.Forms.RadioButton()
        Me.RtnProduccion = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGreen
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(513, 83)
        Me.Panel1.TabIndex = 38
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Berlin Sans FB", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(74, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(396, 54)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "INVERAGRO S.A.C"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(176, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 29)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Iniciar Sesión"
        '
        'txtusuario
        '
        Me.txtusuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtusuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtusuario.Font = New System.Drawing.Font("Verdana", 11.0!)
        Me.txtusuario.Location = New System.Drawing.Point(78, 24)
        Me.txtusuario.MaximumSize = New System.Drawing.Size(274, 80)
        Me.txtusuario.MaxLength = 8
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(225, 27)
        Me.txtusuario.TabIndex = 40
        '
        'btncerrar
        '
        Me.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncerrar.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen
        Me.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncerrar.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btncerrar.Location = New System.Drawing.Point(70, 602)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(375, 57)
        Me.btncerrar.TabIndex = 44
        Me.btncerrar.Text = "CERRAR"
        Me.btncerrar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.txtusuario)
        Me.Panel2.Location = New System.Drawing.Point(70, 317)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(375, 72)
        Me.Panel2.TabIndex = 46
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Formularios.My.Resources.Resources.user64px
        Me.PictureBox2.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(51, 44)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnverclave)
        Me.Panel3.Controls.Add(Me.PictureBox3)
        Me.Panel3.Controls.Add(Me.txtclave)
        Me.Panel3.Location = New System.Drawing.Point(70, 397)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(375, 72)
        Me.Panel3.TabIndex = 47
        '
        'btnverclave
        '
        Me.btnverclave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnverclave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.btnverclave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnverclave.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnverclave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.btnverclave.Image = Global.Formularios.My.Resources.Resources.ojo_cerrado
        Me.btnverclave.Location = New System.Drawing.Point(308, 5)
        Me.btnverclave.Name = "btnverclave"
        Me.btnverclave.Size = New System.Drawing.Size(64, 65)
        Me.btnverclave.TabIndex = 48
        Me.btnverclave.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Formularios.My.Resources.Resources.password64px
        Me.PictureBox3.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(51, 44)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'txtclave
        '
        Me.txtclave.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.txtclave.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtclave.Font = New System.Drawing.Font("Verdana", 11.0!)
        Me.txtclave.Location = New System.Drawing.Point(78, 24)
        Me.txtclave.Name = "txtclave"
        Me.txtclave.Size = New System.Drawing.Size(225, 27)
        Me.txtclave.TabIndex = 40
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Formularios.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(70, 108)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(375, 110)
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'btningresar
        '
        Me.btningresar.BackColor = System.Drawing.Color.DarkGreen
        Me.btningresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btningresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen
        Me.btningresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen
        Me.btningresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btningresar.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btningresar.ForeColor = System.Drawing.Color.White
        Me.btningresar.Image = Global.Formularios.My.Resources.Resources.invisible
        Me.btningresar.Location = New System.Drawing.Point(70, 538)
        Me.btningresar.Name = "btningresar"
        Me.btningresar.Size = New System.Drawing.Size(375, 57)
        Me.btningresar.TabIndex = 43
        Me.btningresar.Text = "INGRESAR"
        Me.btningresar.UseVisualStyleBackColor = False
        '
        'RtnPruebas
        '
        Me.RtnPruebas.AutoSize = True
        Me.RtnPruebas.Location = New System.Drawing.Point(348, 496)
        Me.RtnPruebas.Name = "RtnPruebas"
        Me.RtnPruebas.Size = New System.Drawing.Size(93, 24)
        Me.RtnPruebas.TabIndex = 48
        Me.RtnPruebas.TabStop = True
        Me.RtnPruebas.Text = "Pruebas"
        Me.RtnPruebas.UseVisualStyleBackColor = True
        '
        'RtnProduccion
        '
        Me.RtnProduccion.AutoSize = True
        Me.RtnProduccion.Location = New System.Drawing.Point(213, 496)
        Me.RtnProduccion.Name = "RtnProduccion"
        Me.RtnProduccion.Size = New System.Drawing.Size(113, 24)
        Me.RtnProduccion.TabIndex = 49
        Me.RtnProduccion.TabStop = True
        Me.RtnProduccion.Text = "Producción"
        Me.RtnProduccion.UseVisualStyleBackColor = True
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(513, 703)
        Me.Controls.Add(Me.RtnProduccion)
        Me.Controls.Add(Me.RtnPruebas)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btncerrar)
        Me.Controls.Add(Me.btningresar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOGIN"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtusuario As Windows.Forms.TextBox
    Friend WithEvents btningresar As Windows.Forms.Button
    Friend WithEvents btncerrar As Windows.Forms.Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtclave As TextBox
    Friend WithEvents btnverclave As Button
    Friend WithEvents RtnPruebas As RadioButton
    Friend WithEvents RtnProduccion As RadioButton
End Class
