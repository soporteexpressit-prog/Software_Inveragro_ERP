<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistorialLote
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Ptbx_Cargando = New System.Windows.Forms.PictureBox()
        Me.dtgListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblPesoPromDest = New System.Windows.Forms.Label()
        Me.LblPesoTotalDest = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblPesoPromNac = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblPesoTotalNac = New System.Windows.Forms.Label()
        Me.LblMadresParto = New System.Windows.Forms.Label()
        Me.LblTotalMomias = New System.Windows.Forms.Label()
        Me.LblTotalMuertos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCriasParto = New System.Windows.Forms.Label()
        Me.LblFechaNacLote = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LblMadresDestete = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblCriasDestete = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblMachosDestete = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LblHembrasDestete = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LblHembrasParto = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LblMachosParto = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.LblFechaNacLote)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.LblLote)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1011, 1019)
        Me.Panel2.TabIndex = 14
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Ptbx_Cargando)
        Me.GroupBox2.Controls.Add(Me.dtgListado)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 463)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(982, 547)
        Me.GroupBox2.TabIndex = 210
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tratamiento y/o Medicación"
        '
        'Ptbx_Cargando
        '
        Me.Ptbx_Cargando.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ptbx_Cargando.Image = Global.Formularios.My.Resources.Resources.loader
        Me.Ptbx_Cargando.Location = New System.Drawing.Point(420, 245)
        Me.Ptbx_Cargando.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Ptbx_Cargando.Name = "Ptbx_Cargando"
        Me.Ptbx_Cargando.Size = New System.Drawing.Size(64, 57)
        Me.Ptbx_Cargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ptbx_Cargando.TabIndex = 177
        Me.Ptbx_Cargando.TabStop = False
        Me.Ptbx_Cargando.Visible = False
        '
        'dtgListado
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Appearance1.FontData.Name = "Verdana"
        Me.dtgListado.DisplayLayout.Appearance = Appearance1
        Me.dtgListado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.dtgListado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dtgListado.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dtgListado.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.dtgListado.DisplayLayout.MaxColScrollRegions = 1
        Me.dtgListado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.Color.White
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtgListado.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.Color.Navy
        Appearance6.ForeColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.dtgListado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dtgListado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dtgListado.DisplayLayout.Override.CellAppearance = Appearance8
        Me.dtgListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dtgListado.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.dtgListado.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.BackColor = System.Drawing.Color.AliceBlue
        Appearance10.BackColor2 = System.Drawing.Color.Silver
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.TextHAlignAsString = "Left"
        Me.dtgListado.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.dtgListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dtgListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.dtgListado.DisplayLayout.Override.RowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowPreviewAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.Color.White
        Me.dtgListado.DisplayLayout.Override.RowSelectorAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.Navy
        Me.dtgListado.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance14
        Me.dtgListado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dtgListado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dtgListado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dtgListado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dtgListado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dtgListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtgListado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgListado.Location = New System.Drawing.Point(3, 22)
        Me.dtgListado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtgListado.Name = "dtgListado"
        Me.dtgListado.Size = New System.Drawing.Size(976, 522)
        Me.dtgListado.TabIndex = 176
        Me.dtgListado.Text = "UltraGrid1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.LblHembrasParto)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.LblPesoPromNac)
        Me.GroupBox3.Controls.Add(Me.LblMachosParto)
        Me.GroupBox3.Controls.Add(Me.LblMadresParto)
        Me.GroupBox3.Controls.Add(Me.LblTotalMomias)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.LblPesoTotalNac)
        Me.GroupBox3.Controls.Add(Me.LblTotalMuertos)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.LblCriasParto)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 123)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(979, 177)
        Me.GroupBox3.TabIndex = 209
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Información de Parto"
        '
        'LblPesoPromDest
        '
        Me.LblPesoPromDest.AccessibleDescription = " "
        Me.LblPesoPromDest.AutoSize = True
        Me.LblPesoPromDest.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoPromDest.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoPromDest.ForeColor = System.Drawing.Color.Black
        Me.LblPesoPromDest.Location = New System.Drawing.Point(889, 33)
        Me.LblPesoPromDest.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoPromDest.Name = "LblPesoPromDest"
        Me.LblPesoPromDest.Size = New System.Drawing.Size(23, 22)
        Me.LblPesoPromDest.TabIndex = 218
        Me.LblPesoPromDest.Text = "0"
        '
        'LblPesoTotalDest
        '
        Me.LblPesoTotalDest.AccessibleDescription = " "
        Me.LblPesoTotalDest.AutoSize = True
        Me.LblPesoTotalDest.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoTotalDest.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoTotalDest.ForeColor = System.Drawing.Color.Black
        Me.LblPesoTotalDest.Location = New System.Drawing.Point(536, 33)
        Me.LblPesoTotalDest.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoTotalDest.Name = "LblPesoTotalDest"
        Me.LblPesoTotalDest.Size = New System.Drawing.Size(23, 22)
        Me.LblPesoTotalDest.TabIndex = 217
        Me.LblPesoTotalDest.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(692, 33)
        Me.Label18.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(179, 22)
        Me.Label18.TabIndex = 217
        Me.Label18.Text = "Peso Promedio : "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(389, 33)
        Me.Label19.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(133, 22)
        Me.Label19.TabIndex = 216
        Me.Label19.Text = "Peso Total : "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(692, 34)
        Me.Label16.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(179, 22)
        Me.Label16.TabIndex = 215
        Me.Label16.Text = "Peso Promedio : "
        '
        'LblPesoPromNac
        '
        Me.LblPesoPromNac.AccessibleDescription = " "
        Me.LblPesoPromNac.AutoSize = True
        Me.LblPesoPromNac.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoPromNac.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoPromNac.ForeColor = System.Drawing.Color.Black
        Me.LblPesoPromNac.Location = New System.Drawing.Point(889, 34)
        Me.LblPesoPromNac.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoPromNac.Name = "LblPesoPromNac"
        Me.LblPesoPromNac.Size = New System.Drawing.Size(23, 22)
        Me.LblPesoPromNac.TabIndex = 216
        Me.LblPesoPromNac.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(389, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 22)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Peso Total : "
        '
        'LblPesoTotalNac
        '
        Me.LblPesoTotalNac.AccessibleDescription = " "
        Me.LblPesoTotalNac.AutoSize = True
        Me.LblPesoTotalNac.BackColor = System.Drawing.Color.Transparent
        Me.LblPesoTotalNac.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPesoTotalNac.ForeColor = System.Drawing.Color.Black
        Me.LblPesoTotalNac.Location = New System.Drawing.Point(536, 34)
        Me.LblPesoTotalNac.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblPesoTotalNac.Name = "LblPesoTotalNac"
        Me.LblPesoTotalNac.Size = New System.Drawing.Size(23, 22)
        Me.LblPesoTotalNac.TabIndex = 214
        Me.LblPesoTotalNac.Text = "0"
        '
        'LblMadresParto
        '
        Me.LblMadresParto.AutoSize = True
        Me.LblMadresParto.BackColor = System.Drawing.Color.Transparent
        Me.LblMadresParto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMadresParto.ForeColor = System.Drawing.Color.Black
        Me.LblMadresParto.Location = New System.Drawing.Point(250, 34)
        Me.LblMadresParto.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMadresParto.Name = "LblMadresParto"
        Me.LblMadresParto.Size = New System.Drawing.Size(23, 22)
        Me.LblMadresParto.TabIndex = 227
        Me.LblMadresParto.Text = "0"
        '
        'LblTotalMomias
        '
        Me.LblTotalMomias.AccessibleDescription = " "
        Me.LblTotalMomias.AutoSize = True
        Me.LblTotalMomias.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalMomias.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMomias.ForeColor = System.Drawing.Color.Black
        Me.LblTotalMomias.Location = New System.Drawing.Point(248, 131)
        Me.LblTotalMomias.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalMomias.Name = "LblTotalMomias"
        Me.LblTotalMomias.Size = New System.Drawing.Size(23, 22)
        Me.LblTotalMomias.TabIndex = 224
        Me.LblTotalMomias.Text = "0"
        '
        'LblTotalMuertos
        '
        Me.LblTotalMuertos.AutoSize = True
        Me.LblTotalMuertos.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalMuertos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMuertos.ForeColor = System.Drawing.Color.Black
        Me.LblTotalMuertos.Location = New System.Drawing.Point(538, 131)
        Me.LblTotalMuertos.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblTotalMuertos.Name = "LblTotalMuertos"
        Me.LblTotalMuertos.Size = New System.Drawing.Size(23, 22)
        Me.LblTotalMuertos.TabIndex = 222
        Me.LblTotalMuertos.Text = "0"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = " "
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(126, 131)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 22)
        Me.Label6.TabIndex = 218
        Me.Label6.Text = "Momias : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(355, 131)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 22)
        Me.Label5.TabIndex = 217
        Me.Label5.Text = "Total Muertos : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(54, 81)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(178, 22)
        Me.Label4.TabIndex = 216
        Me.Label4.Text = "Total Animales : "
        '
        'LblCriasParto
        '
        Me.LblCriasParto.AutoSize = True
        Me.LblCriasParto.BackColor = System.Drawing.Color.Transparent
        Me.LblCriasParto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCriasParto.ForeColor = System.Drawing.Color.Black
        Me.LblCriasParto.Location = New System.Drawing.Point(248, 81)
        Me.LblCriasParto.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCriasParto.Name = "LblCriasParto"
        Me.LblCriasParto.Size = New System.Drawing.Size(23, 22)
        Me.LblCriasParto.TabIndex = 215
        Me.LblCriasParto.Text = "0"
        '
        'LblFechaNacLote
        '
        Me.LblFechaNacLote.AutoSize = True
        Me.LblFechaNacLote.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaNacLote.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaNacLote.ForeColor = System.Drawing.Color.Black
        Me.LblFechaNacLote.Location = New System.Drawing.Point(905, 80)
        Me.LblFechaNacLote.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblFechaNacLote.Name = "LblFechaNacLote"
        Me.LblFechaNacLote.Size = New System.Drawing.Size(23, 22)
        Me.LblFechaNacLote.TabIndex = 213
        Me.LblFechaNacLote.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(721, 80)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 22)
        Me.Label3.TabIndex = 212
        Me.Label3.Text = "F. Nacimiento : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(97, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 22)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "N° Madres : "
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.BackColor = System.Drawing.Color.Transparent
        Me.LblLote.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LblLote.Location = New System.Drawing.Point(29, 74)
        Me.LblLote.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(33, 29)
        Me.LblLote.TabIndex = 209
        Me.LblLote.Text = "- "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnCerrar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(1011, 40)
        Me.ToolStrip1.TabIndex = 52
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.BtnCerrar.ToolTipText = "Cerrar"
        '
        'BackgroundWorker1
        '
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.LblHembrasDestete)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.LblMachosDestete)
        Me.GroupBox5.Controls.Add(Me.LblPesoPromDest)
        Me.GroupBox5.Controls.Add(Me.LblMadresDestete)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.LblPesoTotalDest)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.LblCriasDestete)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 307)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(979, 139)
        Me.GroupBox5.TabIndex = 228
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Información de Destete"
        '
        'LblMadresDestete
        '
        Me.LblMadresDestete.AutoSize = True
        Me.LblMadresDestete.BackColor = System.Drawing.Color.Transparent
        Me.LblMadresDestete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMadresDestete.ForeColor = System.Drawing.Color.Black
        Me.LblMadresDestete.Location = New System.Drawing.Point(248, 33)
        Me.LblMadresDestete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMadresDestete.Name = "LblMadresDestete"
        Me.LblMadresDestete.Size = New System.Drawing.Size(23, 22)
        Me.LblMadresDestete.TabIndex = 227
        Me.LblMadresDestete.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(54, 86)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(178, 22)
        Me.Label13.TabIndex = 216
        Me.Label13.Text = "Total Animales : "
        '
        'LblCriasDestete
        '
        Me.LblCriasDestete.AutoSize = True
        Me.LblCriasDestete.BackColor = System.Drawing.Color.Transparent
        Me.LblCriasDestete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCriasDestete.ForeColor = System.Drawing.Color.Black
        Me.LblCriasDestete.Location = New System.Drawing.Point(248, 86)
        Me.LblCriasDestete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblCriasDestete.Name = "LblCriasDestete"
        Me.LblCriasDestete.Size = New System.Drawing.Size(23, 22)
        Me.LblCriasDestete.TabIndex = 215
        Me.LblCriasDestete.Text = "0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(97, 33)
        Me.Label20.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(135, 22)
        Me.Label20.TabIndex = 210
        Me.Label20.Text = "N° Madres : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(417, 86)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 22)
        Me.Label9.TabIndex = 229
        Me.Label9.Text = "Machos : "
        '
        'LblMachosDestete
        '
        Me.LblMachosDestete.AutoSize = True
        Me.LblMachosDestete.BackColor = System.Drawing.Color.Transparent
        Me.LblMachosDestete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMachosDestete.ForeColor = System.Drawing.Color.Black
        Me.LblMachosDestete.Location = New System.Drawing.Point(538, 86)
        Me.LblMachosDestete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMachosDestete.Name = "LblMachosDestete"
        Me.LblMachosDestete.Size = New System.Drawing.Size(23, 22)
        Me.LblMachosDestete.TabIndex = 228
        Me.LblMachosDestete.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(751, 86)
        Me.Label17.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 22)
        Me.Label17.TabIndex = 231
        Me.Label17.Text = "Hembras : "
        '
        'LblHembrasDestete
        '
        Me.LblHembrasDestete.AutoSize = True
        Me.LblHembrasDestete.BackColor = System.Drawing.Color.Transparent
        Me.LblHembrasDestete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHembrasDestete.ForeColor = System.Drawing.Color.Black
        Me.LblHembrasDestete.Location = New System.Drawing.Point(887, 86)
        Me.LblHembrasDestete.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblHembrasDestete.Name = "LblHembrasDestete"
        Me.LblHembrasDestete.Size = New System.Drawing.Size(23, 22)
        Me.LblHembrasDestete.TabIndex = 230
        Me.LblHembrasDestete.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(751, 81)
        Me.Label22.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 22)
        Me.Label22.TabIndex = 235
        Me.Label22.Text = "Hembras : "
        '
        'LblHembrasParto
        '
        Me.LblHembrasParto.AutoSize = True
        Me.LblHembrasParto.BackColor = System.Drawing.Color.Transparent
        Me.LblHembrasParto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHembrasParto.ForeColor = System.Drawing.Color.Black
        Me.LblHembrasParto.Location = New System.Drawing.Point(887, 81)
        Me.LblHembrasParto.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblHembrasParto.Name = "LblHembrasParto"
        Me.LblHembrasParto.Size = New System.Drawing.Size(23, 22)
        Me.LblHembrasParto.TabIndex = 234
        Me.LblHembrasParto.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(417, 81)
        Me.Label24.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 22)
        Me.Label24.TabIndex = 233
        Me.Label24.Text = "Machos : "
        '
        'LblMachosParto
        '
        Me.LblMachosParto.AutoSize = True
        Me.LblMachosParto.BackColor = System.Drawing.Color.Transparent
        Me.LblMachosParto.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMachosParto.ForeColor = System.Drawing.Color.Black
        Me.LblMachosParto.Location = New System.Drawing.Point(538, 81)
        Me.LblMachosParto.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.LblMachosParto.Name = "LblMachosParto"
        Me.LblMachosParto.Size = New System.Drawing.Size(23, 22)
        Me.LblMachosParto.TabIndex = 232
        Me.LblMachosParto.Text = "0"
        '
        'FrmHistorialLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 1019)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHistorialLote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORIAL DE LOTE"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Ptbx_Cargando, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtgListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LblCriasParto As Label
    Friend WithEvents LblPesoTotalNac As Label
    Friend WithEvents LblFechaNacLote As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblLote As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnCerrar As ToolStripButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblTotalMuertos As Label
    Friend WithEvents LblMadresParto As Label
    Friend WithEvents LblTotalMomias As Label
    Friend WithEvents LblPesoPromDest As Label
    Friend WithEvents LblPesoTotalDest As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LblPesoPromNac As Label
    Friend WithEvents Ptbx_Cargando As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents LblMadresDestete As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblCriasDestete As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents LblHembrasDestete As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblMachosDestete As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents LblHembrasParto As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents LblMachosParto As Label
End Class
