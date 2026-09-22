<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsultarCalculoRpteLote
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
        Me.Contenedor = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rtbFormulas = New System.Windows.Forms.RichTextBox()
        Me.Contenedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'Contenedor
        '
        Me.Contenedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Contenedor.Controls.Add(Me.rtbFormulas)
        Me.Contenedor.Controls.Add(Me.Label6)
        Me.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Contenedor.Location = New System.Drawing.Point(0, 0)
        Me.Contenedor.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.Size = New System.Drawing.Size(586, 514)
        Me.Contenedor.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(33, 24)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(223, 18)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "FORMULAS DE CALCULO"

        ' rtbFormulas
        '
        Me.rtbFormulas.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.rtbFormulas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbFormulas.Location = New System.Drawing.Point(36, 60)
        Me.rtbFormulas.Name = "rtbFormulas"
        Me.rtbFormulas.ReadOnly = True
        Me.rtbFormulas.Size = New System.Drawing.Size(512, 420)
        Me.rtbFormulas.TabIndex = 129
        Me.rtbFormulas.Text = ""
        '
        'FrmConsultarCalculoRpteLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 514)
        Me.Controls.Add(Me.Contenedor)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsultarCalculoRpteLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Calculo Reporte Lote"
        Me.Contenedor.ResumeLayout(False)
        Me.Contenedor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Contenedor As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents rtbFormulas As RichTextBox

    ' (Removed duplicated form-level fields — these are declared in the code-behind file)
End Class
