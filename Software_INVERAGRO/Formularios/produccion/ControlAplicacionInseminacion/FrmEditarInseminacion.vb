Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEditarInseminacion
    Dim cn As New cnControlGestacion
    Dim idDetalleInseminacion As Integer = 0
    Dim idMaterialGenetico As Integer = 0
    Dim idInseminador As Integer = 0
    Dim idPlantel As Integer = 0
    Dim idCerda As Integer = 0
    Public idDetInseminacion As Integer = 0

    Private Sub FrmEditarInseminacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtCodInseminacion.ReadOnly = True
            TxtDniEncargado.ReadOnly = True
            TxtNombreEncargado.ReadOnly = True
            ConsultarInseminacionCerdaxId()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarInseminacionCerdaxId()
        Try
            Dim obj As New coControlGestacion With {
                .IdDetalleInseminacion = idDetInseminacion
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarInseminacionxIdCerda(obj).Copy
            If (dt.Rows.Count > 0) Then
                idDetalleInseminacion = dt.Rows(0)("idDetInseminacion").ToString()
                DtpFechaMonta.Value = dt.Rows(0)("fMonta").ToString()
                TxtCantExpulsada.Text = dt.Rows(0)("cantExpulsada").ToString()
                NumDosisInseminar.Value = dt.Rows(0)("numDosis").ToString()
                CmbViaAplicacion.Text = dt.Rows(0)("via").ToString()
                TxtCodInseminacion.Text = dt.Rows(0)("codAplicacion").ToString()
                TxtCondCorporal.Text = dt.Rows(0)("condCorporal").ToString()
                idMaterialGenetico = dt.Rows(0)("idMaterialGenetico").ToString()
                idInseminador = dt.Rows(0)("idPersona").ToString()
                TxtDniEncargado.Text = dt.Rows(0)("numDocumento").ToString()
                TxtNombreEncargado.Text = dt.Rows(0)("datos").ToString()
                LblCodArete.Text = dt.Rows(0)("codArete").ToString()
                idPlantel = dt.Rows(0)("idUbicacion").ToString()
                idCerda = dt.Rows(0)("idAnimal").ToString()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposMaterialGenetico(id As Integer, codVerraco As String, dosisDisponible As Integer)
        idMaterialGenetico = id
        TxtCodInseminacion.Text = codVerraco
        LblDosisDisponibles.Text = dosisDisponible
    End Sub

    Private Sub BtnBuscarMG_Click(sender As Object, e As EventArgs) Handles BtnBuscarMG.Click
        Dim frm As New FrmListarMaterialGeneticoEditar(Me) With {
            .idPlantel = idPlantel
        }
        frm.ShowDialog()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaMonta.Value > Now.Date Then
                msj_advert("La fecha de inseminación no puede ser mayor a la fecha actual.")
                Return
            End If

            If (idMaterialGenetico = 0) Then
                msj_advert("Seleccione un Material Genético")
                Return
            ElseIf (TxtCantExpulsada.Text.Length = 0) Then
                msj_advert("Ingrese Cantidad Expulsada")
                Return
            ElseIf (CDec(TxtCantExpulsada.Text) <= 0) Then
                msj_advert("Ingrese Cantidad Expulsada mayor a 0")
                Return
            ElseIf (NumDosisInseminar.Value = 0) Then
                msj_advert("Ingrese Número dosis para inseminar")
                Return
            ElseIf (NumDosisInseminar.Value <= 0) Then
                msj_advert("Ingrese Número dosis para inseminar mayor a 0")
                Return
            ElseIf (TxtCondCorporal.Text.Length = 0) Then
                msj_advert("Ingrese la condición corporal")
                Return
            ElseIf (CDec(TxtCondCorporal.Text) <= 0) Then
                msj_advert("la condición corporal debe ser mayor a cero")
                Return
            ElseIf (LblDosisDisponibles.Text <> "- - -") Then
                If (NumDosisInseminar.Value > CDec(LblDosisDisponibles.Text)) Then
                    msj_advert("Número de dosis para inseminar no puede ser mayor a las dosis disponibles")
                    Return
                End If
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE EDITAR INSEMINACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlGestacion With {
                .CantidadExpulsada = TxtCantExpulsada.Text,
                .NumDosis = NumDosisInseminar.Value,
                .IdUsuario = VP_IdUser,
                .IdCerda = idCerda,
                .IdMaterialGenetico = idMaterialGenetico,
                .IdDetalleInseminacion = idDetalleInseminacion,
                .FechaMonta = DtpFechaMonta.Value,
                .IdPersona = idInseminador,
                .CodCorporal = CDec(TxtCondCorporal.Text),
                .ViaAplicacion = CmbViaAplicacion.Text
            }

            Dim mensaje As String = cn.Cn_EditarInseminacion(obj)

            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Dispose()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposInseminador(codigo As Integer, numDocumento As String, datos As String)
        idInseminador = codigo
        TxtDniEncargado.Text = numDocumento
        TxtNombreEncargado.Text = datos
    End Sub

    Private Sub BtnEncargado_Click(sender As Object, e As EventArgs) Handles BtnEncargado.Click
        Try
            Dim frm As New FrmListarEncargadoInseminarEditar(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class