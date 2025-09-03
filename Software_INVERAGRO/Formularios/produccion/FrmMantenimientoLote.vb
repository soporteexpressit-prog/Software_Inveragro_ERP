Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoLote
    Dim cn As New cnControlLoteDestete
    Public anio As Integer = DateTime.Now.Year
    Public idLote As Integer = 0
    Public fApertura As Date
    Public fCierre As Date
    Public numLote As Integer
    Public estado As String
    Public operacion As Integer = 0
    Public idUbicacion As Integer

    Private Sub FrmMantenimientoLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarAnios()
            ListarPlanteles()
            If idLote > 0 Then
                operacion = 1
                NumeroLote.Value = numLote
                DtpFechaApertura.Value = fApertura
                DtpFechaCierre.Value = fCierre
                CmbEstado.Text = estado
            Else
                operacion = 0
                NumeroLote.Value = 1
                DtpFechaApertura.Value = Date.Now
                DtpFechaCierre.Value = Date.Now
                CmbEstado.Text = "ACTIVO"
                CmbEstado.Enabled = False
            End If
            CmbUbicacion.Value = idUbicacion
            CmbUbicacion.Enabled = False
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarAnios()
        For i As Integer = DateTime.Now.Year - 5 To DateTime.Now.Year + 5
            CmbAnios.Items.Add(i.ToString())
        Next
        CmbAnios.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAnios.Text = DateTime.Now.Year.ToString()
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Mantenimiento()
        Try
            If (operacion = 1 OrElse operacion = 2) AndAlso (idLote = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If
            If (operacion = 0 OrElse operacion = 1) AndAlso (NumeroLote.Value < 0 OrElse NumeroLote.Value > 52) Then
                msj_advert("Número de lote no Valida")
                Return
            End If
            If (DtpFechaCierre.Value < DtpFechaApertura.Value) Then
                msj_advert("La fecha de cierre no puede ser menor a la fecha de apertura")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .Operacion = operacion,
                .IdLote = idLote,
                .Anio = CInt(CmbAnios.Text),
                .FechaDesde = DtpFechaApertura.Value,
                .FechaHasta = DtpFechaCierre.Value,
                .NumeroLote = NumeroLote.Value,
                .Estado = CmbEstado.Text,
                .IdPlantel = CmbUbicacion.Value
            }

            Dim _mensaje As String = cn.Cn_MantenimientoLote(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardarLote_Click(sender As Object, e As EventArgs) Handles BtnGuardarLote.Click
        Mantenimiento()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class