Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarJaulaCorralParto
    Dim cn As New cnJaulaCorral
    Public idGalpon As Integer
    Public tipo As String
    Private ReadOnly _frmRegParto As FrmRegParto

    Public Sub New(frmRegParto As FrmRegParto)
        InitializeComponent()
        _frmRegParto = frmRegParto
    End Sub

    Private Sub FrmListarJaulaCorralParto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ConsultarJaularCorral()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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
        Colorear()
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

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim codigo As String = e.Cell.Row.Cells("Codigo").Value.ToString()
                    Dim descripcion As String = e.Cell.Row.Cells("Descripcion").Value.ToString()
                    Dim sala As String = e.Cell.Row.Cells("Sala").Value.ToString()
                    _frmRegParto.LlenarCamposJaulaCorral(codigo, descripcion, sala)
                    Me.Close()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class