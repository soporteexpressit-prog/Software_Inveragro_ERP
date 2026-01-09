Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMonitoreoCondicionCorporal
    Dim cn As New cnControlAnimal
    Dim idCerda As Integer = 0
    Public idUbicacion As Integer = 0
    Public tipoControl As String = ""

    Private Sub FrmMonitoreoCondicionCorporal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarMonitoreoCondCorporalGestacion()
            If tipoControl = "LACTANTE" Then
                GroupBox3.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarMonitoreoCondCorporalGestacion()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Dim obj As New coControlAnimal With {
            .Codigo = idCerda
        }
        dtgListado.DataSource = cn.Cn_ConsultarMonitoreoCondCorporalxIdCerda(obj)
    End Sub

    Public Sub LlenarCamposCerda(id As Integer, codigo As String, diasEtapa As Integer, condicionCorporal As Decimal)
        Try
            idCerda = id
            LblCodArete.Text = codigo
            LblDiasEtapa.Text = diasEtapa
            TxtCondCorporal.Text = condicionCorporal.ToString("0.00")

            ' Consultar información adicional de gestación
            If tipoControl = "GESTANTE" Then
                ConsultarInfoGestacion()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarInfoGestacion()
        Try
            If idCerda = 0 Then
                ' Limpiar labels si no hay cerda seleccionada
                LblNumSemana.Text = "-"
                LblNumLote.Text = "-"
                LblFechaInicio.Text = "-"
                LblFechaFin.Text = "-"
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }

            Dim dt As DataTable = cn.Cn_ConsultarInfoCerdaGestacion(obj)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ' Setear los valores en los labels correspondientes
                Dim row As DataRow = dt.Rows(0)

                ' NumSemana
                If Not IsDBNull(row("numeroSemana")) Then
                    LblNumSemana.Text = row("numeroSemana").ToString()
                Else
                    LblNumSemana.Text = "-"
                End If

                ' NumLote
                If Not IsDBNull(row("numLoteParto")) Then
                    LblNumLote.Text = row("numLoteParto").ToString()
                Else
                    LblNumLote.Text = "-"
                End If

                ' FechaInicio
                If Not IsDBNull(row("fechaDesde")) Then
                    Dim fechaInicio As Date = Convert.ToDateTime(row("fechaDesde"))
                    LblFechaInicio.Text = fechaInicio.ToString("dd/MM/yyyy")
                Else
                    LblFechaInicio.Text = "-"
                End If

                ' FechaFin
                If Not IsDBNull(row("fechaHasta")) Then
                    Dim fechaFin As Date = Convert.ToDateTime(row("fechaHasta"))
                    LblFechaFin.Text = fechaFin.ToString("dd/MM/yyyy")
                Else
                    LblFechaFin.Text = "-"
                End If
            Else
                ' Si no hay datos, limpiar los labels
                LblNumSemana.Text = "-"
                LblNumLote.Text = "-"
                LblFechaInicio.Text = "-"
                LblFechaFin.Text = "-"
            End If
        Catch ex As Exception
            ' En caso de error, limpiar los labels
            LblNumSemana.Text = "-"
            LblNumLote.Text = "-"
            LblFechaInicio.Text = "-"
            LblFechaFin.Text = "-"
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (idCerda = 0) Then
                msj_advert("Seleccione cerda para registrar condición corporal")
                Return
            End If

            If (TxtCondCorporal.Text.Length = 0) Then
                msj_advert("Ingrese valor para condición corporal")
                Return
            ElseIf (CInt(TxtCondCorporal.Text) = 0) Then
                msj_advert("Ingrese condición corporal mayor a 0")
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .CondCorporal = TxtCondCorporal.Text,
                .DiasTranscurridos = LblDiasEtapa.Text,
                .IdUsuario = VP_IdUser
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR CONDICIÓN CORPORAL DE LA CERDA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim mensaje As String = cn.Cn_RegistrarMonitoreCondCorporal(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                ListarMonitoreoCondCorporalGestacion()
            Else
                msj_advert(mensaje)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtCondCorporal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondCorporal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdasMaternidadMC(Me) With {
                .idPlantel = idUbicacion,
                .tipo = tipoControl
            }
            frm.ShowDialog()
            ListarMonitoreoCondCorporalGestacion()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class