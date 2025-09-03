<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCroquis
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbPlantel5 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbPlantel4 = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.rbPlantel3 = New System.Windows.Forms.RadioButton()
        Me.rbPlantel1 = New System.Windows.Forms.RadioButton()
        Me.rbPlantel2 = New System.Windows.Forms.RadioButton()
        Me.PanelContenedor = New System.Windows.Forms.Panel()
        Me.RbLineaProduccionReproductiva = New System.Windows.Forms.RadioButton()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.RbLineaProduccionReproductiva)
        Me.Panel2.Controls.Add(Me.rbPlantel5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.rbPlantel4)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.rbPlantel3)
        Me.Panel2.Controls.Add(Me.rbPlantel1)
        Me.Panel2.Controls.Add(Me.rbPlantel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2145, 132)
        Me.Panel2.TabIndex = 9
        '
        'rbPlantel5
        '
        Me.rbPlantel5.AutoSize = True
        Me.rbPlantel5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPlantel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.rbPlantel5.Location = New System.Drawing.Point(1425, 31)
        Me.rbPlantel5.Name = "rbPlantel5"
        Me.rbPlantel5.Size = New System.Drawing.Size(130, 26)
        Me.rbPlantel5.TabIndex = 5
        Me.rbPlantel5.TabStop = True
        Me.rbPlantel5.Text = "PLANTEL 5"
        Me.rbPlantel5.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(28, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(402, 29)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "CROQUIS DE LOS PLANTELES"
        '
        'rbPlantel4
        '
        Me.rbPlantel4.AutoSize = True
        Me.rbPlantel4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPlantel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.rbPlantel4.Location = New System.Drawing.Point(1199, 31)
        Me.rbPlantel4.Name = "rbPlantel4"
        Me.rbPlantel4.Size = New System.Drawing.Size(130, 26)
        Me.rbPlantel4.TabIndex = 4
        Me.rbPlantel4.TabStop = True
        Me.rbPlantel4.Text = "PLANTEL 4"
        Me.rbPlantel4.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 92)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(2145, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCerrar.Size = New System.Drawing.Size(84, 30)
        Me.btnCerrar.Text = "Salir"
        Me.btnCerrar.ToolTipText = "Salir"
        '
        'rbPlantel3
        '
        Me.rbPlantel3.AutoSize = True
        Me.rbPlantel3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPlantel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.rbPlantel3.Location = New System.Drawing.Point(959, 31)
        Me.rbPlantel3.Name = "rbPlantel3"
        Me.rbPlantel3.Size = New System.Drawing.Size(130, 26)
        Me.rbPlantel3.TabIndex = 3
        Me.rbPlantel3.TabStop = True
        Me.rbPlantel3.Text = "PLANTEL 3"
        Me.rbPlantel3.UseVisualStyleBackColor = True
        '
        'rbPlantel1
        '
        Me.rbPlantel1.AutoSize = True
        Me.rbPlantel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPlantel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.rbPlantel1.Location = New System.Drawing.Point(538, 31)
        Me.rbPlantel1.Name = "rbPlantel1"
        Me.rbPlantel1.Size = New System.Drawing.Size(130, 26)
        Me.rbPlantel1.TabIndex = 1
        Me.rbPlantel1.TabStop = True
        Me.rbPlantel1.Text = "PLANTEL 1"
        Me.rbPlantel1.UseVisualStyleBackColor = True
        Me.rbPlantel1.Visible = False
        '
        'rbPlantel2
        '
        Me.rbPlantel2.AutoSize = True
        Me.rbPlantel2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPlantel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.rbPlantel2.Location = New System.Drawing.Point(726, 31)
        Me.rbPlantel2.Name = "rbPlantel2"
        Me.rbPlantel2.Size = New System.Drawing.Size(130, 26)
        Me.rbPlantel2.TabIndex = 2
        Me.rbPlantel2.TabStop = True
        Me.rbPlantel2.Text = "PLANTEL 2"
        Me.rbPlantel2.UseVisualStyleBackColor = True
        '
        'PanelContenedor
        '
        Me.PanelContenedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContenedor.Location = New System.Drawing.Point(0, 132)
        Me.PanelContenedor.Name = "PanelContenedor"
        Me.PanelContenedor.Size = New System.Drawing.Size(2145, 636)
        Me.PanelContenedor.TabIndex = 10
        '
        'RbLineaProduccionReproductiva
        '
        Me.RbLineaProduccionReproductiva.AutoSize = True
        Me.RbLineaProduccionReproductiva.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLineaProduccionReproductiva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RbLineaProduccionReproductiva.Location = New System.Drawing.Point(1657, 30)
        Me.RbLineaProduccionReproductiva.Name = "RbLineaProduccionReproductiva"
        Me.RbLineaProduccionReproductiva.Size = New System.Drawing.Size(402, 26)
        Me.RbLineaProduccionReproductiva.TabIndex = 129
        Me.RbLineaProduccionReproductiva.TabStop = True
        Me.RbLineaProduccionReproductiva.Text = "LÍNEA DE PRODUCCIÓN REPRODUCTIVA"
        Me.RbLineaProduccionReproductiva.UseVisualStyleBackColor = True
        '
        'FrmCroquis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(2145, 768)
        Me.Controls.Add(Me.PanelContenedor)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmCroquis"
        Me.Text = "CROQUIS"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents PanelContenedor As Panel
    Friend WithEvents rbPlantel5 As RadioButton
    Friend WithEvents rbPlantel4 As RadioButton
    Friend WithEvents rbPlantel3 As RadioButton
    Friend WithEvents rbPlantel2 As RadioButton
    Friend WithEvents rbPlantel1 As RadioButton
    Friend WithEvents RbLineaProduccionReproductiva As RadioButton
End Class
