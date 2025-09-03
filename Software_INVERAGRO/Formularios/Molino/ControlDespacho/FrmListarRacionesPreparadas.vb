Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarRacionesPreparadas
    Dim cn As New cnControlDespacho
    Public idRequerimiento As Integer
    Private ReadOnly _frmRegistrarDespachoRacion As FrmRegistrarDespachoRacion

    Public Sub New(frmRegistrarDespachoRacion As FrmRegistrarDespachoRacion)
        InitializeComponent()
        _frmRegistrarDespachoRacion = frmRegistrarDespachoRacion
    End Sub

    Private Sub FrmListarRacionesPreparadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarRaciones()
    End Sub

    Private Sub ConsultarRaciones()
        Try
            Dim obj As New coControlDespacho With {
                .Codigo = idRequerimiento
            }
            dtgListadoRaciones.DataSource = cn.Cn_ConsultarRacionPreparadaCerdoxId(obj)
            dtgListadoRaciones.DisplayLayout.Bands(0).Columns("idDetalleSalida").Hidden = True
            dtgListadoRaciones.DisplayLayout.Bands(0).Columns("Código").Hidden = True
            dtgListadoRaciones.DisplayLayout.Bands(0).Columns("medicadoPlus").Hidden = True
            dtgListadoRaciones.DisplayLayout.Bands(0).Columns("Tipo Alimento").Hidden = True
            clsBasicas.Formato_Tablas_Grid(dtgListadoRaciones)
            Colorear()
            PintarRegistroStock()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListadoRaciones.Rows.Count > 0) Then
            Dim estadoPreparacion As Integer = 7
            Dim estadoRecepcion As Integer = 8

            'estadoPreparacion
            clsBasicas.Colorear_SegunValor(dtgListadoRaciones, Color.Green, Color.White, "PREPARADO", estadoPreparacion)

            'estadoRecepcion
            clsBasicas.Colorear_SegunValor(dtgListadoRaciones, Color.Yellow, Color.Black, "POR ENVIAR", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoRaciones, Color.LightGray, Color.Black, "EN TRANSITO", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoRaciones, Color.Orange, Color.White, "PARCIAL", estadoRecepcion)
            clsBasicas.Colorear_SegunValor(dtgListadoRaciones, Color.LightGreen, Color.DarkGreen, "COMPLETADO", estadoRecepcion)

            'centrar columnas
            With dtgListadoRaciones.DisplayLayout.Bands(0)
                .Columns(estadoPreparacion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoRecepcion).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub PintarRegistroStock()
        Dim totalColumns As Integer = dtgListadoRaciones.DisplayLayout.Bands(0).Columns.Count
        If totalColumns > 1 Then
            dtgListadoRaciones.DisplayLayout.Bands(0).Columns(totalColumns - 4).CellAppearance.BackColor = Color.LightBlue
            dtgListadoRaciones.DisplayLayout.Bands(0).Columns(totalColumns - 3).CellAppearance.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub dtgListadoRaciones_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListadoRaciones.DoubleClickCell
        Try
            If (dtgListadoRaciones.Rows.Count > 0) Then
                Dim activeRow = dtgListadoRaciones.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    Dim estadoRecepcion = activeRow.Cells("Estado Recepción").Value.ToString()

                    If estadoRecepcion = "COMPLETADO" Then
                        msj_advert("EL DESPACHO DE LA RACIÓN FUE COMPLETADA")
                        Return
                    End If

                    Dim idDetalleSalida = activeRow.Cells("idDetalleSalida").Value.ToString()
                    Dim codigo = activeRow.Cells("Código").Value.ToString()
                    Dim racion = activeRow.Cells("Ración").Value.ToString()
                    Dim cantidadTotal = activeRow.Cells("Cantidad Solicitada (tn)").Value.ToString()
                    Dim cantidadEnviada = activeRow.Cells("Cantidad Enviada (tn)").Value.ToString()
                    Dim stock = activeRow.Cells("Stock (tn)").Value.ToString()
                    Dim medicadoPlus = activeRow.Cells("medicadoPlus").Value.ToString()
                    Dim tipoAlimento = activeRow.Cells("Tipo Alimento").Value.ToString()

                    _frmRegistrarDespachoRacion.LlenarTablaDespacho(idDetalleSalida, codigo, racion, cantidadTotal, cantidadEnviada, stock, medicadoPlus, tipoAlimento)
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class