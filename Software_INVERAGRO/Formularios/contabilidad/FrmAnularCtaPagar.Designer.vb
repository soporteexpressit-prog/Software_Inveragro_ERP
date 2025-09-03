<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAnularCtaPagar
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
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TsBtn_Cerrar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtmotivoanulacion = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.TsBtn_Cerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(626, 40)
        Me.ToolStrip1.TabIndex = 38
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.Formularios.My.Resources.Resources.guardar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnGuardar.Size = New System.Drawing.Size(121, 30)
        Me.btnGuardar.Tag = "343"
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.ToolTipText = "Guardar"
        '
        'TsBtn_Cerrar
        '
        Me.TsBtn_Cerrar.ForeColor = System.Drawing.Color.White
        Me.TsBtn_Cerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.TsBtn_Cerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtn_Cerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.TsBtn_Cerrar.Name = "TsBtn_Cerrar"
        Me.TsBtn_Cerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.TsBtn_Cerrar.Size = New System.Drawing.Size(84, 30)
        Me.TsBtn_Cerrar.Tag = "3434"
        Me.TsBtn_Cerrar.Text = "Salir"
        Me.TsBtn_Cerrar.ToolTipText = "Cerrar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(28, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 22)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Motivo :"
        '
        'txtmotivoanulacion
        '
        Me.txtmotivoanulacion.Location = New System.Drawing.Point(28, 94)
        Me.txtmotivoanulacion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtmotivoanulacion.MaxLength = 150
        Me.txtmotivoanulacion.Name = "txtmotivoanulacion"
        Me.txtmotivoanulacion.Size = New System.Drawing.Size(572, 192)
        Me.txtmotivoanulacion.TabIndex = 40
        Me.txtmotivoanulacion.Text = ""
        '
        'FrmAnularCtaPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(626, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtmotivoanulacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximumSize = New System.Drawing.Size(648, 356)
        Me.MinimumSize = New System.Drawing.Size(648, 356)
        Me.Name = "FrmAnularCtaPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ANULAR  CUENTA POR PAGAR"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents TsBtn_Cerrar As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtmotivoanulacion As RichTextBox
End Class
