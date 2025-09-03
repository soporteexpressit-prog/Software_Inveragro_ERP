Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarJaulaCorralActualizarCerda
    Dim cn As New cnJaulaCorral
    Public idGalpon As Integer
    Public tipo As String
    Private ReadOnly _frmActualizarDatosCerda As FrmActualizarDatosCerda

    Public Sub New(frmActualizarDatosCerda As FrmActualizarDatosCerda)
        InitializeComponent()
        _frmActualizarDatosCerda = frmActualizarDatosCerda
    End Sub

    Private Sub FrmListarJaulaCorralActualizarCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ConsultarJaularCorral()
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoCapacidad As Integer = 6

            'estadoCapacidad
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "LIBRE", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.DarkGoldenrod, "PARCIAL", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "LLENO", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO DISPONIBLE", estadoCapacidad)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoCapacidad).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Sub ConsultarJaularCorral()
        Dim obj As New coJaulaCorral With {
            .Descripcion = Nothing,
            .IdGalpon = idGalpon,
            .Tipo = tipo
        }

        Dim dt As DataTable = cn.Cn_ConsultarDisponible(obj)
        dtgListado.DataSource = dt
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado IsNot Nothing AndAlso dtgListado.Rows.Count > 0 Then
                Dim activeRow = dtgListado.ActiveRow

                If activeRow IsNot Nothing Then
                    Dim codigo As String = If(e.Cell.Row.Cells.Exists("Codigo") AndAlso e.Cell.Row.Cells("Codigo").Value IsNot Nothing, e.Cell.Row.Cells("Codigo").Value.ToString(), "")
                    Dim descripcion As String = If(e.Cell.Row.Cells.Exists("Descripcion") AndAlso e.Cell.Row.Cells("Descripcion").Value IsNot Nothing, e.Cell.Row.Cells("Descripcion").Value.ToString(), "")
                    Dim sala As String = If(e.Cell.Row.Cells.Exists("Sala") AndAlso e.Cell.Row.Cells("Sala").Value IsNot Nothing, e.Cell.Row.Cells("Sala").Value.ToString(), "")

                    If Not String.IsNullOrEmpty(codigo) AndAlso Not String.IsNullOrEmpty(descripcion) AndAlso Not String.IsNullOrEmpty(sala) Then
                        _frmActualizarDatosCerda.LlenarCamposJaulaCorral(codigo, descripcion, sala)
                        Me.Close()
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException("", ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class