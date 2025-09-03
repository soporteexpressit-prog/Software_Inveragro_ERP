Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarTodoInsumo
    Dim cn As New cnProducto
    Dim cnFormulacion As New cnControlFormulacion
    Private ReadOnly _frmGestionInsumo As FrmGestionInsumo
    Private insumosSeleccionados As String = ""
    Private listaValoresPadre As List(Of String)
    Private idNutricionistaInsumo As Integer = 0

    Public Sub New(frmRegistrarNucleo As FrmGestionInsumo, ByVal listaValores As List(Of String), idNutricionista As Integer)
        InitializeComponent()
        _frmGestionInsumo = frmRegistrarNucleo
        listaValoresPadre = listaValores
        idNutricionistaInsumo = idNutricionista
    End Sub

    Private Sub FrmListarTodoInsumo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarInsumos()
            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                If listaValoresPadre.Contains(row.Cells(0).Value.ToString()) Then
                    row.Appearance.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarInsumos()
        Dim dt As DataTable = cn.Cn_ListarInsumosActivos()
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado.Rows.Count > 0 Then
                Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

                If activeRow IsNot Nothing AndAlso activeRow.Cells.Count > 0 AndAlso activeRow.Cells(0).Value IsNot Nothing Then

                    If activeRow.Cells(0).Value.ToString().Trim().Length > 0 Then
                        Dim valorPrimeraColumna As String = activeRow.Cells(0).Value.ToString()

                        If dtgListado.Rows(activeRow.Index).Appearance.BackColor = Color.LightGray Then
                            msj_advert("No puede seleccionar un insumo que ya ha sido seleccionado en la formulación.")
                            Return
                        End If

                        If insumosSeleccionados.Contains(valorPrimeraColumna) Then
                            Dim valoresArray As List(Of String) = insumosSeleccionados.Split(","c).ToList()
                            valoresArray.Remove(valorPrimeraColumna)
                            insumosSeleccionados = String.Join(",", valoresArray)

                            For Each celda As Infragistics.Win.UltraWinGrid.UltraGridCell In activeRow.Cells
                                celda.Appearance.BackColor = Color.White
                            Next
                        Else
                            If insumosSeleccionados = "" Then
                                insumosSeleccionados = valorPrimeraColumna
                            Else
                                insumosSeleccionados &= "," & valorPrimeraColumna
                            End If

                            For Each celda As Infragistics.Win.UltraWinGrid.UltraGridCell In activeRow.Cells
                                celda.Appearance.BackColor = Color.LightBlue
                            Next
                        End If
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
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try
            If String.IsNullOrEmpty(insumosSeleccionados) Then
                msj_advert("Debe seleccionar al menos un insumo.")
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE LOS INSUMOS ASIGNADOS?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coControlFormulacion With {
                    .Operacion = 0,
                    .ListaIdsInsumos = insumosSeleccionados,
                    .IdNutricionista = idNutricionistaInsumo
                }

                Dim _mensaje As String = cnFormulacion.Cn_MantenimientoProductoFormula(obj)

                If obj.Coderror = 0 Then
                    msj_ok(_mensaje)
                    _frmGestionInsumo.ListarInsumos()
                    Me.Close()
                Else
                    msj_advert(_mensaje)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class