Imports CapaNegocio

Public Class FrmBuscarTrabajador_Asis
    Dim cn As New cnControlAsistencia
    Private ReadOnly _frmControlAsistencia As FrmControlAsistencia
    Private ReadOnly _frmEditarAsistencia As FrmEditarAsistencia
    Public Property codtrabajador As Integer
    Public Property tipoTrabajador As String = ""
    Public Property datos As String
    Public Property quincenaEventual As Integer

    Public Sub New(frmEditarAsistencia As FrmEditarAsistencia)
        InitializeComponent()
        _frmEditarAsistencia = frmEditarAsistencia
    End Sub

    Public Sub New(frmControlAsistencia As FrmControlAsistencia)
        InitializeComponent()
        _frmControlAsistencia = frmControlAsistencia
    End Sub

    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarTrabajadoresPorPlanillaEventual(tipoTrabajador)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmBuscarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub
    Sub Seleccionar()
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                codtrabajador = dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString
                datos = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString

                Dispose()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub DtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        If e.Cell Is Nothing OrElse e.Cell.Row Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If

        If e.Cell.Row.Index < 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return
        End If
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim dni As String = e.Cell.Row.Cells(1).Value.ToString()
                    Dim datos As String = e.Cell.Row.Cells(2).Value.ToString()
                    Dim tipo As String = e.Cell.Row.Cells(3).Value.ToString()

                    If tipoTrabajador = "EVENTUAL" Then
                        If _frmControlAsistencia IsNot Nothing Then

                            If quincenaEventual = 1 Then
                                _frmControlAsistencia.LlenarTablaAsistenciaEventualQuincena(dni, datos, tipo)
                            Else
                                _frmControlAsistencia.LlenarTablaAsistenciaEventual(dni, datos, tipo)
                            End If

                        ElseIf _frmEditarAsistencia IsNot Nothing Then

                            If quincenaEventual = 1 Then
                                _frmEditarAsistencia.LlenarTablaAsistenciaEventualQuincena(dni, datos, tipo)
                            Else
                                _frmEditarAsistencia.LlenarTablaAsistenciaEventual(dni, datos, tipo)
                            End If

                        End If
                    ElseIf tipoTrabajador = "PLANILLA" Then
                        If _frmControlAsistencia IsNot Nothing Then
                            _frmControlAsistencia.LlenarTablaAsistencia(dni, datos, tipo)
                        ElseIf _frmEditarAsistencia IsNot Nothing Then
                            _frmEditarAsistencia.LlenarTablaAsistencia(dni, datos, tipo)
                        End If
                    End If

                    Dispose()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub

End Class