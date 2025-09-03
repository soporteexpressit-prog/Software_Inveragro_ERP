Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAlimentacionPresupuesto
    Dim cn As New cnControlLoteDestete
    Private search As Boolean = False
    Public idPlantel As Integer = 0
    Dim idRacion As Integer = 0
    Dim idGrupo As Integer = 0
    Dim ds As New DataSet

    Private Sub FrmAlimentacionPresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtTotalAlimento.ReadOnly = True
        txtDescripcionAlimento.ReadOnly = True
        LblResultado.ReadOnly = True
        TxtConsumoAlimento.ReadOnly = True
        TxtGrupo.ReadOnly = True
        clsBasicas.LlenarComboAnios(CmbAnios)
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = idPlantel
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Private Sub btnBuscarInsumos_Click(sender As Object, e As EventArgs) Handles btnBuscarInsumos.Click
        Try
            If idGrupo = 0 Then
                msj_advert("Selecciona primero un grupo")
                Return
            End If

            Dim f As New FrmListaRacionesPresupuesto(Me) With {
                .IdUbicacionDestino = idPlantel
            }
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposAlimento(codigo As Integer, descripcion As String)
        idRacion = codigo
        txtDescripcionAlimento.Text = descripcion

        If idRacion <> 0 Then
            ConsultarPresupuestoAlimento()
        End If
    End Sub

    Private Sub ConsultarPresupuestoAlimento()
        Try
            If idGrupo = 0 Then
                msj_advert("Seleccione un Grupo")
                Return
            ElseIf idRacion = 0 Then
                msj_advert("Seleccione un Alimento")
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdGrupo = idGrupo,
                .IdLote = CmbLotes.Value,
                .IdRacion = idRacion
            }

            Dim dt As DataTable = cn.Cn_ConsultarPresupuestoAlimentoGrupo(obj)

            If dt.Rows.Count > 0 Then
                Dim fila As DataRow = dt.Rows(0)
                TxtObjetivo.Text = CDec(fila("objetivo")).ToString("N2")
                TxtPesoDestete.Text = CDec(fila("pesoDestete")).ToString("N2")
                TxtCa.Text = CDec(fila("ca")).ToString("N2")
                TxtPresentacionSacos.Text = CDec(fila("presentacionSacos")).ToString("N2")
                TxtConsumoAlimento.Text = (CDec(fila("stockConsumidoGrupo").ToString()) / CInt(LblTotalAnimales.Text)).ToString("N2")
            Else
                TxtObjetivo.Text = ""
                TxtPesoDestete.Text = ""
                TxtCa.Text = ""
                TxtPresentacionSacos.Text = ""
                TxtConsumoAlimento.Text = ""
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSeleccioneGrupo_Click(sender As Object, e As EventArgs) Handles BtnSeleccioneGrupo.Click
        Try
            Dim f As New FrmListaGrupoDestete(Me) With {
                .idLote = CmbLotes.Value
            }
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposGrupo(codigo As Integer, cantAnimales As Integer, grupo As String, edadLote As Integer, fechaNacimiento As Integer)
        idGrupo = codigo
        LblTotalAnimales.Text = cantAnimales
        TxtGrupo.Text = grupo
        LblEdad.Text = edadLote
        LblFechaNacimiento.Text = fechaNacimiento
        LimpiarCampos()
    End Sub

    Private Sub LimpiarCampos()
        idRacion = 0
        txtDescripcionAlimento.Text = ""
        TxtObjetivo.Text = ""
        TxtPesoDestete.Text = ""
        TxtCa.Text = ""
        TxtPresentacionSacos.Text = ""
        TxtConsumoAlimento.Text = ""
        LblResultado.Text = ""
        TxtTotalAlimento.Text = ""
    End Sub

    Private Sub TxtObjetivo_TextChanged(sender As Object, e As EventArgs) Handles TxtObjetivo.TextChanged
        CalcularResultado()
    End Sub

    Private Sub TxtPesoDestete_TextChanged(sender As Object, e As EventArgs) Handles TxtPesoDestete.TextChanged
        CalcularResultado()
    End Sub

    Private Sub TxtCa_TextChanged(sender As Object, e As EventArgs) Handles TxtCa.TextChanged
        CalcularResultado()
    End Sub

    Private Sub CalcularResultado()
        If TxtObjetivo.Text <> "" AndAlso TxtPesoDestete.Text <> "" AndAlso TxtCa.Text <> "" Then
            LblResultado.Text = ((CDec(TxtObjetivo.Text) - CDec(TxtPesoDestete.Text)) * CDec(TxtCa.Text)).ToString("N2")
            TxtTotalAlimento.Text = CDec(LblResultado.Text) * CInt(LblTotalAnimales.Text)
        Else
            LblResultado.Text = "0"
            TxtTotalAlimento.Text = "0"
        End If
    End Sub

    Private Sub TxtObjetivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjetivo.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtPesoDestete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPesoDestete.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtCa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCa.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(TxtObjetivo.Text) Then
                msj_advert("Por favor, ingrese un objetivo")
                TxtObjetivo.Select()
                Return
            ElseIf String.IsNullOrWhiteSpace(TxtPesoDestete.Text) Then
                msj_advert("Por favor, ingrese un peso destete")
                TxtPesoDestete.Select()
                Return
            ElseIf String.IsNullOrWhiteSpace(TxtCa.Text) Then
                msj_advert("Por favor, ingrese un C.A")
                TxtCa.Select()
                Return
            ElseIf String.IsNullOrWhiteSpace(TxtPresentacionSacos.Text) Then
                msj_advert("Por favor, ingrese presentación en sacos")
                TxtPresentacionSacos.Select()
                Return
            End If

            If CDec(TxtObjetivo.Text) = 0 Then
                msj_advert("Por Favor Ingrese un objetivo válido")
                TxtObjetivo.Select()
                Return
            ElseIf CDec(TxtPesoDestete.Text) = 0 Then
                msj_advert("Por Favor Ingrese un peso destete válido")
                TxtPesoDestete.Select()
                Return
            ElseIf CDec(TxtCa.Text) = 0 Then
                msj_advert("Por Favor Ingrese un C.A válido")
                TxtCa.Select()
                Return
            ElseIf CDec(TxtPresentacionSacos.Text) = 0 Then
                msj_advert("Por Favor Ingrese presentación en sacos válido")
                TxtPresentacionSacos.Select()
                Return
            ElseIf idGrupo = 0 Then
                msj_advert("Por Favor seleccione un grupo")
                Return
            ElseIf idRacion = 0 Then
                msj_advert("Por Favor seleccione un alimento")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR PRESUPUESTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value,
                .IdGrupo = idGrupo,
                .IdRacion = idRacion,
                .Objetivo = CDec(TxtObjetivo.Text),
                .PesoDestete = CDec(TxtPesoDestete.Text),
                .Ca = CDec(TxtCa.Text),
                .PresentacionSacos = CDec(TxtPresentacionSacos.Text)
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarPresupuestoAlimentoGrupo(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                ConsultarPresupuestoAlimento()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnDividirGrupos_Click(sender As Object, e As EventArgs) Handles BtnDividirGrupos.Click
        Try
            If idGrupo = 0 Then
                msj_advert("Selecciona un grupo")
                Return
            End If

            If idRacion = 0 Then
                msj_advert("Selecciona un alimento")
                Return
            End If

            Dim frm As New FrmAlimentarGrupoDestete With {
                .nombreGrupo = TxtGrupo.Text,
                .nombreAlimento = txtDescripcionAlimento.Text,
                .idLote = CmbLotes.Value,
                .idGrupo = idGrupo,
                .idProducto = idRacion,
                .idUbicacion = idPlantel
            }
            frm.ShowDialog()
            ConsultarPresupuestoAlimento()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnIngresarGrupo_Click(sender As Object, e As EventArgs) Handles btnIngresarGrupo.Click
        Try
            If idGrupo = 0 Then
                msj_advert("Selecciona un grupo")
                Return
            End If

            If idRacion = 0 Then
                msj_advert("Selecciona un alimento")
                Return
            End If

            Dim frm As New FrmDetalleAlimentoGrupo With {
                .IdGrupo = idGrupo,
                .IdAlimento = idRacion,
                .IdUbicacion = idPlantel
            }
            frm.ShowDialog()
            ConsultarPresupuestoAlimento()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class