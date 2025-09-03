<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEvidenciaCapacitacion
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.picEvidenciaCapacitacion1 = New System.Windows.Forms.PictureBox()
        Me.picEvidenciaCapacitacion2 = New System.Windows.Forms.PictureBox()
        Me.picEvidenciaCapacitacion3 = New System.Windows.Forms.PictureBox()
        Me.picEvidenciaCapacitacion4 = New System.Windows.Forms.PictureBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.picEvidenciaCapacitacion1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEvidenciaCapacitacion2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEvidenciaCapacitacion3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEvidenciaCapacitacion4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(497, 38)
        Me.ToolStrip1.TabIndex = 172
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = Global.Formularios.My.Resources.Resources.salir
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Padding = New System.Windows.Forms.Padding(2)
        Me.btnCerrar.Size = New System.Drawing.Size(65, 28)
        Me.btnCerrar.Text = "Salir"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'picEvidenciaCapacitacion1
        '
        Me.picEvidenciaCapacitacion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEvidenciaCapacitacion1.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picEvidenciaCapacitacion1.Location = New System.Drawing.Point(20, 42)
        Me.picEvidenciaCapacitacion1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picEvidenciaCapacitacion1.Name = "picEvidenciaCapacitacion1"
        Me.picEvidenciaCapacitacion1.Size = New System.Drawing.Size(213, 176)
        Me.picEvidenciaCapacitacion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEvidenciaCapacitacion1.TabIndex = 171
        Me.picEvidenciaCapacitacion1.TabStop = False
        '
        'picEvidenciaCapacitacion2
        '
        Me.picEvidenciaCapacitacion2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEvidenciaCapacitacion2.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picEvidenciaCapacitacion2.Location = New System.Drawing.Point(267, 42)
        Me.picEvidenciaCapacitacion2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picEvidenciaCapacitacion2.Name = "picEvidenciaCapacitacion2"
        Me.picEvidenciaCapacitacion2.Size = New System.Drawing.Size(213, 176)
        Me.picEvidenciaCapacitacion2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEvidenciaCapacitacion2.TabIndex = 173
        Me.picEvidenciaCapacitacion2.TabStop = False
        '
        'picEvidenciaCapacitacion3
        '
        Me.picEvidenciaCapacitacion3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEvidenciaCapacitacion3.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picEvidenciaCapacitacion3.Location = New System.Drawing.Point(20, 245)
        Me.picEvidenciaCapacitacion3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picEvidenciaCapacitacion3.Name = "picEvidenciaCapacitacion3"
        Me.picEvidenciaCapacitacion3.Size = New System.Drawing.Size(213, 176)
        Me.picEvidenciaCapacitacion3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEvidenciaCapacitacion3.TabIndex = 174
        Me.picEvidenciaCapacitacion3.TabStop = False
        '
        'picEvidenciaCapacitacion4
        '
        Me.picEvidenciaCapacitacion4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picEvidenciaCapacitacion4.Image = Global.Formularios.My.Resources.Resources.sinimagen
        Me.picEvidenciaCapacitacion4.Location = New System.Drawing.Point(267, 245)
        Me.picEvidenciaCapacitacion4.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.picEvidenciaCapacitacion4.Name = "picEvidenciaCapacitacion4"
        Me.picEvidenciaCapacitacion4.Size = New System.Drawing.Size(213, 176)
        Me.picEvidenciaCapacitacion4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEvidenciaCapacitacion4.TabIndex = 175
        Me.picEvidenciaCapacitacion4.TabStop = False
        '
        'FrmEvidenciaCapacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 432)
        Me.Controls.Add(Me.picEvidenciaCapacitacion4)
        Me.Controls.Add(Me.picEvidenciaCapacitacion3)
        Me.Controls.Add(Me.picEvidenciaCapacitacion2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.picEvidenciaCapacitacion1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEvidenciaCapacitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EVIDENCIA CAPACITACIÓN"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.picEvidenciaCapacitacion1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEvidenciaCapacitacion2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEvidenciaCapacitacion3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEvidenciaCapacitacion4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picEvidenciaCapacitacion1 As PictureBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents picEvidenciaCapacitacion2 As PictureBox
    Friend WithEvents picEvidenciaCapacitacion3 As PictureBox
    Friend WithEvents picEvidenciaCapacitacion4 As PictureBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
