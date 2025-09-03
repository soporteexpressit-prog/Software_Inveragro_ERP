Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarCriasMovimiento
    Dim cn As New cnControlAnimal
    Private ReadOnly _frmRegistrarMovimientoLechon As FrmRegistrarMovimientoLechon
    Public idCerda As Integer = 0
    Private SelectedIds As New List(Of Integer)

    Public Sub New(frmRegistrarMovimientoLechon As FrmRegistrarMovimientoLechon)
        InitializeComponent()
        _frmRegistrarMovimientoLechon = frmRegistrarMovimientoLechon
    End Sub

    Private Sub FrmListarCriasMovimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }
            dtgListado.DataSource = cn.Cn_ListarCriasCerdasDonantes(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 Then
            If dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0 Then
                Dim idValue As Integer = CInt(dtgListado.ActiveRow.Cells(0).Value)
                If Not SelectedIds.Contains(idValue) Then
                    SelectedIds.Add(idValue)
                    dtgListado.ActiveRow.Appearance.BackColor = Color.LightBlue
                Else
                    SelectedIds.Remove(idValue)
                    dtgListado.ActiveRow.Appearance.BackColor = Color.White
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If SelectedIds.Count > 0 Then
            Dim selectedIdsCriasString As String = String.Join("+", SelectedIds)
            Dim numeroTotalCrias As Integer = SelectedIds.Count

            _frmRegistrarMovimientoLechon.GuardarSeleccionCrias(selectedIdsCriasString, numeroTotalCrias)
            Me.Close()
        Else
            msj_advert("No ha seleccionado ningún registro.")
        End If
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class