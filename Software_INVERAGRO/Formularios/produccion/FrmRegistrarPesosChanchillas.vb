Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarPesosChanchillas
    Dim cn As New cnControlLoteDestete
    Public idLote As Integer = 0
    Public valorLote As String = ""
    Public numChanchillas As Integer = 0
    Private DtDetalle As New DataTable("TempDetPeso")
    Private clasificacion As String = "DESTETE"

    Private Sub FrmRegistrarPesosChanchillas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarTablaDetallePesoCria()
            Me.KeyPreview = True
            LblNombreLote.Text = valorLote
            LblEdad.Visible = False
            LblEdadChanchillas.Visible = False
            LblFecha.Visible = False
            DtpFecha.Visible = False
            LblTotalChanchillas.Text = numChanchillas.ToString("N0")
            clsBasicas.Formato_Tablas_Grid(DtgListadoPesosDestete)
            clsBasicas.Formato_Tablas_Grid(DtgListadoPesosBajada)
            ConsultarxIdLote()
            AddHandler PesosDestete.Enter, AddressOf PesosDestete_Enter
            AddHandler PesosBajada.Enter, AddressOf PesosBajada_Enter
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub PesosDestete_Enter(sender As Object, e As EventArgs)
        DtDetalle.Clear()
        DtgListadoPesosDestete.DataSource = Nothing
        clasificacion = "DESTETE"
        CargarTablaDetallePesoCria()
        ConsultarxIdLote()
    End Sub

    Private Sub PesosBajada_Enter(sender As Object, e As EventArgs)
        DtDetalle.Clear()
        DtgListadoPesosBajada.DataSource = Nothing
        clasificacion = "BAJADA"
        CargarTablaDetallePesoCria()
        ConsultarxIdLote()
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        NumAnimales.Enabled = False
        TxtPeso.Enabled = False
        btnAgregar.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        NumAnimales.Enabled = True
        TxtPeso.Enabled = True
        btnAgregar.Enabled = True
    End Sub

    Sub ConsultarxIdLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .TipoFiltro = "CHANCHILLA",
                .TipoBajada = clasificacion
            }
            Dim dt As New DataSet
            dt = cn.Cn_ConsultarPesosBajada(obj).Copy

            If (dt.Tables(0).Rows.Count > 0) Then
                For i = 0 To dt.Tables(0).Rows.Count - 1
                    Dim dr As DataRow = DtDetalle.NewRow
                    dr(0) = dt.Tables(0).Rows(i)("idPesoBajada")
                    dr(1) = dt.Tables(0).Rows(i)("Cantidad")
                    dr(2) = dt.Tables(0).Rows(i)("Peso")
                    dr(3) = ""
                    DtDetalle.Rows.Add(dr)
                Next

                If clasificacion = "BAJADA" Then
                    DtgListadoPesosBajada.DataSource = DtDetalle
                Else
                    DtgListadoPesosDestete.DataSource = DtDetalle
                End If
            End If

            If dt.Tables.Count > 1 And DtDetalle.Rows.Count <> 0 And clasificacion = "BAJADA" Then
                If dt.Tables(1).Rows.Count > 0 Then
                    Dim fechaControl As Date = CDate(dt.Tables(1).Rows(0)("fPesoChanchilla"))
                    DtpFecha.Value = fechaControl
                    LblEdadChanchillas.Text = CInt(dt.Tables(1).Rows(0)("edad"))
                    LblEdad.Visible = True
                    LblEdadChanchillas.Visible = True
                    LblFecha.Visible = True
                    DtpFecha.Visible = True
                End If
            Else
                LblEdad.Visible = False
                LblEdadChanchillas.Visible = False
                LblFecha.Visible = False
                DtpFecha.Visible = False
                DtpFecha.Value = Date.Now
            End If

            CalcularCantidadesLabels()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetallePesoCria()
        DtDetalle = New DataTable("TempDetPeso")
        DtDetalle.Columns.Add("idPesoBajada", GetType(Integer))
        DtDetalle.Columns.Add("Cantidad", GetType(Integer))
        DtDetalle.Columns.Add("Peso", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        If clasificacion = "BAJADA" Then
            DtgListadoPesosBajada.DataSource = DtDetalle
        Else
            DtgListadoPesosDestete.DataSource = DtDetalle
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim cantidadChanchillas As Integer = SumarCantidad()

            If TxtPeso.Text.Trim() = "" Then
                msj_advert("Por Favor Ingrese Peso")
                TxtPeso.Select()
                Return
            End If

            If Not IsNumeric(TxtPeso.Text) Then
                msj_advert("Por Favor Ingrese un Peso válido")
                TxtPeso.Select()
                Return
            End If

            If NumAnimales.Value = 0 Then
                msj_advert("Ingrese una Cantidad")
                Return
            ElseIf CDec(TxtPeso.Text) = 0 Then
                msj_advert("Por Favor Ingrese Peso válido")
                TxtPeso.Select()
                Return
            ElseIf CDec(TxtPeso.Text) = 0 Then
                msj_advert("Por Favor Ingrese la Peso diferente de cero")
                TxtPeso.Select()
                Return
            End If

            If (cantidadChanchillas + NumAnimales.Value) > CInt(LblTotalChanchillas.Text) Then
                msj_advert("El valor no puede ser mayor a la cantidad de chanchillas que se tiene")
                Return
            End If
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
                .CantidadVenta = NumAnimales.Value,
                .PesoTotal = CDec(TxtPeso.Text),
                .IdLote = idLote,
                .TipoFiltro = "CHANCHILLA",
                .FechaControl = DtpFecha.Value,
                .TipoBajada = clasificacion
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarPesosBajada(obj)
            If (obj.Coderror = 0) Then
                If clasificacion = "BAJADA" Then
                    DtgListadoPesosBajada.DataSource = Nothing
                Else
                    DtgListadoPesosDestete.DataSource = Nothing
                End If
                DtDetalle.Clear()
                ConsultarxIdLote()
                DesbloquearControladores()
            Else
                msj_advert(MensajeBgWk)
            End If
            CalcularCantidadesLabels()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CalcularCantidadesLabels()
        LblTotalAnimales.Text = SumarCantidad().ToString("N0")
        LblPesoTotal.Text = SumarPesos().ToString("N2")
        If clasificacion = "BAJADA" Then
            LblNumRegistros.Text = DtgListadoPesosBajada.Rows.Count
        Else
            LblNumRegistros.Text = DtgListadoPesosDestete.Rows.Count
        End If
    End Sub

    Private Function SumarCantidad() As Integer
        Dim total As Integer = 0

        If DtDetalle IsNot Nothing AndAlso DtDetalle.Rows.Count > 0 Then
            For Each fila As DataRow In DtDetalle.Rows
                If Not IsDBNull(fila("cantidad")) Then
                    total += CInt(fila("cantidad"))
                End If
            Next
        End If

        Return total
    End Function

    Private Function SumarPesos() As Decimal
        Dim total As Decimal = 0

        If DtDetalle IsNot Nothing AndAlso DtDetalle.Rows.Count > 0 Then
            For Each fila As DataRow In DtDetalle.Rows
                If Not IsDBNull(fila("peso")) Then
                    total += CDec(fila("peso"))
                End If
            Next
        End If

        Return total
    End Function

    Private Sub FrmRegistrarPesosChanchillas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAgregar.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub DtgListadoPesosDestete_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoPesosDestete.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Cantidad"
                .Columns(2).Header.Caption = "Peso"
                .Columns(3).Header.Caption = "Eliminar"
                .Columns(3).Width = 60
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoPesosDestete_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgListadoPesosDestete.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim idPesoBajada As Integer = Convert.ToInt32(e.Cell.Row.Cells(0).Value)
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                DtgListadoPesosDestete.DataSource = DtDetalle

                Dim obj As New coControlLoteDestete With {
                    .IdControlFicha = idPesoBajada
                }

                Dim MensajeBgWk As String = cn.Cn_EliminarPesosBajada(obj)
                If (obj.Coderror = 0) Then
                    DtgListadoPesosDestete.DataSource = Nothing
                    DtDetalle.Clear()
                    ConsultarxIdLote()
                Else
                    msj_advert(MensajeBgWk)
                End If

                CalcularCantidadesLabels()
            End If
        End If
    End Sub

    Private Sub DtgListadoPesosBajada_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoPesosBajada.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Cantidad"
                .Columns(2).Header.Caption = "Peso"
                .Columns(3).Header.Caption = "Eliminar"
                .Columns(3).Width = 60
                .Columns(3).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(3).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(3).CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
                .Columns(3).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoPesosBajada_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgListadoPesosBajada.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim idPesoBajada As Integer = Convert.ToInt32(e.Cell.Row.Cells(0).Value)
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                DtgListadoPesosBajada.DataSource = DtDetalle

                Dim obj As New coControlLoteDestete With {
                    .IdControlFicha = idPesoBajada
                }

                Dim MensajeBgWk As String = cn.Cn_EliminarPesosBajada(obj)
                If (obj.Coderror = 0) Then
                    DtgListadoPesosBajada.DataSource = Nothing
                    DtDetalle.Clear()
                    ConsultarxIdLote()
                Else
                    msj_advert(MensajeBgWk)
                End If

                CalcularCantidadesLabels()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class