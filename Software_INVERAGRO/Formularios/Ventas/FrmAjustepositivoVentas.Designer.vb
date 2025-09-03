<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjustepositivoVentas
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnguardarnuerte = New System.Windows.Forms.ToolStripButton()
        Me.TsBtn_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.txtcantidad = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxpedidoreferencia = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtobservacion = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnanular = New System.Windows.Forms.ToolStripButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbxpedidoreferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnguardarnuerte, Me.btnanular, Me.TsBtn_Cerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(744, 38)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "Guardar"
        '
        'btnguardarnuerte
        '
        Me.btnguardarnuerte.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardarnuerte.ForeColor = System.Drawing.Color.White
        Me.btnguardarnuerte.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnguardarnuerte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnguardarnuerte.Margin = New System.Windows.Forms.Padding(5)
        Me.btnguardarnuerte.Name = "btnguardarnuerte"
        Me.btnguardarnuerte.Padding = New System.Windows.Forms.Padding(2)
        Me.btnguardarnuerte.Size = New System.Drawing.Size(89, 28)
        Me.btnguardarnuerte.Tag = "343"
        Me.btnguardarnuerte.Text = "Guardar"
        Me.btnguardarnuerte.ToolTipText = "Guardar"
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
        'txtcantidad
        '
        Appearance1.BackColor = System.Drawing.Color.Orange
        Me.txtcantidad.Appearance = Appearance1
        Me.txtcantidad.BackColor = System.Drawing.Color.Orange
        Me.txtcantidad.Location = New System.Drawing.Point(226, 134)
        Me.txtcantidad.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtcantidad.MaxLength = 8
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(130, 21)
        Me.txtcantidad.TabIndex = 177
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxpedidoreferencia)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(29, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(676, 62)
        Me.GroupBox2.TabIndex = 182
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información de Venta"
        '
        'cbxpedidoreferencia
        '
        Me.cbxpedidoreferencia.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cbxpedidoreferencia.Location = New System.Drawing.Point(195, 27)
        Me.cbxpedidoreferencia.Name = "cbxpedidoreferencia"
        Me.cbxpedidoreferencia.Size = New System.Drawing.Size(389, 22)
        Me.cbxpedidoreferencia.TabIndex = 178
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(38, 31)
        Me.Label21.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(153, 14)
        Me.Label21.TabIndex = 162
        Me.Label21.Text = "Pedido de Referencia  :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(149, 138)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 14)
        Me.Label4.TabIndex = 178
        Me.Label4.Text = "Cantidad :"
        '
        'txtobservacion
        '
        Me.txtobservacion.Location = New System.Drawing.Point(224, 164)
        Me.txtobservacion.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtobservacion.MaxLength = 100
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(391, 46)
        Me.txtobservacion.TabIndex = 180
        Me.txtobservacion.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(123, 170)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 14)
        Me.Label9.TabIndex = 179
        Me.Label9.Text = "Observación :"
        '
        'btnanular
        '
        Me.btnanular.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnanular.ForeColor = System.Drawing.Color.White
        Me.btnanular.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnanular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnanular.Margin = New System.Windows.Forms.Padding(5)
        Me.btnanular.Name = "btnanular"
        Me.btnanular.Padding = New System.Windows.Forms.Padding(2)
        Me.btnanular.Size = New System.Drawing.Size(78, 28)
        Me.btnanular.Tag = "343"
        Me.btnanular.Text = "Anular"
        Me.btnanular.ToolTipText = "Guardar"
        Me.btnanular.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"IRRECUPERABLE", "VENTA"})
        Me.ComboBox1.Location = New System.Drawing.Point(226, 134)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(186, 21)
        Me.ComboBox1.TabIndex = 184
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(124, 137)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 14)
        Me.Label1.TabIndex = 183
        Me.Label1.Text = "Tipo ajuste :"
        '
        'FrmAjustepositivoVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(744, 226)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtobservacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmAjustepositivoVentas"
        Me.Text = "AJUSTE POSITIVO DE VENTA"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.txtcantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cbxpedidoreferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnguardarnuerte As ToolStripButton
    Friend WithEvents TsBtn_Cerrar As ToolStripButton
    Friend WithEvents txtcantidad As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbxpedidoreferencia As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label21 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtobservacion As RichTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnanular As ToolStripButton
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
End Class
