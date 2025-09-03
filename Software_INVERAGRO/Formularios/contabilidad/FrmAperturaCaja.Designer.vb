<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAperturaCaja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.txt_glosa = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.dtfecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.txtsaldoanterior = New System.Windows.Forms.TextBox()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.Label15 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripGuardarctac = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.txt_glosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtfecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_glosa
        '
        Me.txt_glosa.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Standard
        Me.txt_glosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_glosa.Location = New System.Drawing.Point(175, 50)
        Me.txt_glosa.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_glosa.MaxLength = 200
        Me.txt_glosa.Multiline = True
        Me.txt_glosa.Name = "txt_glosa"
        Me.txt_glosa.Size = New System.Drawing.Size(161, 73)
        Me.txt_glosa.TabIndex = 3
        Me.txt_glosa.Text = "NINGUNO"
        '
        'txtmonto
        '
        Me.txtmonto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.Location = New System.Drawing.Point(175, 153)
        Me.txtmonto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(162, 26)
        Me.txtmonto.TabIndex = 0
        Me.txtmonto.Text = "0.00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtfecha
        '
        Appearance7.FontData.Name = "Arial"
        Appearance7.FontData.SizeInPoints = 12.0!
        Me.dtfecha.Appearance = Appearance7
        Me.dtfecha.DateTime = New Date(2024, 1, 9, 0, 0, 0, 0)
        Me.dtfecha.Location = New System.Drawing.Point(175, 25)
        Me.dtfecha.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtfecha.Name = "dtfecha"
        Me.dtfecha.Size = New System.Drawing.Size(161, 27)
        Me.dtfecha.TabIndex = 5
        Me.dtfecha.TabStop = False
        Me.dtfecha.Value = New Date(2024, 1, 9, 0, 0, 0, 0)
        '
        'txtsaldoanterior
        '
        Me.txtsaldoanterior.BackColor = System.Drawing.Color.Orange
        Me.txtsaldoanterior.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsaldoanterior.Location = New System.Drawing.Point(175, 127)
        Me.txtsaldoanterior.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtsaldoanterior.Name = "txtsaldoanterior"
        Me.txtsaldoanterior.ReadOnly = True
        Me.txtsaldoanterior.Size = New System.Drawing.Size(162, 26)
        Me.txtsaldoanterior.TabIndex = 302
        Me.txtsaldoanterior.Text = "0.00"
        Me.txtsaldoanterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UltraLabel4
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.FontData.BoldAsString = "False"
        Appearance8.FontData.Name = "Verdana"
        Appearance8.FontData.SizeInPoints = 9.0!
        Appearance8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance8
        Me.UltraLabel4.Location = New System.Drawing.Point(16, 128)
        Me.UltraLabel4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(152, 20)
        Me.UltraLabel4.TabIndex = 303
        Me.UltraLabel4.Text = "Saldo Anterior :"
        '
        'UltraLabel8
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.FontData.BoldAsString = "False"
        Appearance9.FontData.Name = "Verdana"
        Appearance9.FontData.SizeInPoints = 9.0!
        Appearance9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance9.TextHAlignAsString = "Right"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance9
        Me.UltraLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel8.Location = New System.Drawing.Point(43, 51)
        Me.UltraLabel8.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(110, 20)
        Me.UltraLabel8.TabIndex = 100
        Me.UltraLabel8.Text = "Observación :"
        '
        'Label15
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.FontData.BoldAsString = "False"
        Appearance10.FontData.Name = "Verdana"
        Appearance10.FontData.SizeInPoints = 9.0!
        Appearance10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance10.TextHAlignAsString = "Right"
        Appearance10.TextVAlignAsString = "Middle"
        Me.Label15.Appearance = Appearance10
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 28)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 100
        Me.Label15.Text = "Fecha de Creación:"
        '
        'UltraLabel5
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.FontData.BoldAsString = "False"
        Appearance11.FontData.Name = "Verdana"
        Appearance11.FontData.SizeInPoints = 9.0!
        Appearance11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance11
        Me.UltraLabel5.Location = New System.Drawing.Point(16, 153)
        Me.UltraLabel5.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(152, 20)
        Me.UltraLabel5.TabIndex = 100
        Me.UltraLabel5.Text = "Monto de Apertura :"
        '
        'UltraLabel20
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.Name = "Segoe UI"
        Appearance12.FontData.SizeInPoints = 11.0!
        Appearance12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.UltraLabel20.Appearance = Appearance12
        Me.UltraLabel20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel20.Location = New System.Drawing.Point(25, 51)
        Me.UltraLabel20.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.Size = New System.Drawing.Size(138, 20)
        Me.UltraLabel20.TabIndex = 100
        Me.UltraLabel20.Text = "Observación:"
        Me.UltraLabel20.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripGuardarctac, Me.btncerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 27)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(430, 38)
        Me.ToolStrip1.TabIndex = 136
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripGuardarctac
        '
        Me.ToolStripGuardarctac.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripGuardarctac.ForeColor = System.Drawing.Color.White
        Me.ToolStripGuardarctac.Image = Global.Formularios.My.Resources.Resources.apertura_caja
        Me.ToolStripGuardarctac.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripGuardarctac.Margin = New System.Windows.Forms.Padding(5)
        Me.ToolStripGuardarctac.Name = "ToolStripGuardarctac"
        Me.ToolStripGuardarctac.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripGuardarctac.Size = New System.Drawing.Size(127, 28)
        Me.ToolStripGuardarctac.Text = "Apertura Caja"
        Me.ToolStripGuardarctac.ToolTipText = "GUARDAR"
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
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.txtsaldoanterior)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.UltraLabel5)
        Me.GroupBox1.Controls.Add(Me.UltraLabel4)
        Me.GroupBox1.Controls.Add(Me.UltraLabel20)
        Me.GroupBox1.Controls.Add(Me.txtmonto)
        Me.GroupBox1.Controls.Add(Me.txt_glosa)
        Me.GroupBox1.Controls.Add(Me.dtfecha)
        Me.GroupBox1.Controls.Add(Me.UltraLabel8)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 73)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(412, 237)
        Me.GroupBox1.TabIndex = 137
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Apertura"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(430, 27)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "APERTURA DE CAJA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmAperturaCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(430, 317)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmAperturaCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APERTURA DE CAJA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txt_glosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtfecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_glosa As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtmonto As Windows.Forms.TextBox
    Friend WithEvents dtfecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Label15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtsaldoanterior As Windows.Forms.TextBox
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripGuardarctac As ToolStripButton
    Friend WithEvents btncerrar As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
End Class
