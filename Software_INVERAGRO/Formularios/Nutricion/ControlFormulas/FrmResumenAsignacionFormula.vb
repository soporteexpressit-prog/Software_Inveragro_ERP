Imports Infragistics.Win.UltraWinGrid

Public Class FrmResumenAsignacionFormula
    Private DtDetalle As DataTable
    Private dsNucleoInsumos As DataTable
    Public nombrePremixero As String
    Public tipoPremixero As String

    Public Sub New(ByVal detalleFormula As DataTable, ByVal nucleoInsumos As DataTable)
        InitializeComponent()

        Me.DtDetalle = detalleFormula
        Me.dsNucleoInsumos = nucleoInsumos
    End Sub
    Private Sub FrmResumenAsignacionFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombrePremixero.Text = nombrePremixero
        lblTipoPremixero.Text = tipoPremixero

        If DtDetalle IsNot Nothing Then
            dtgListadoFormula.DataSource = DtDetalle
            clsBasicas.Formato_Tablas_Grid(dtgListadoFormula)
            FormatearGridFormula()
        End If

        If dsNucleoInsumos IsNot Nothing Then
            dtgListadoNucleo.DataSource = dsNucleoInsumos
            clsBasicas.Formato_Tablas_Grid(dtgListadoNucleo)
            FormatearGridNucleos()
        End If
    End Sub
    Private Sub FormatearGridFormula()
        Try
            With dtgListadoFormula.DisplayLayout.Bands(0)
                .Columns("etiqueta").Header.Caption = "Indicador"
                .Columns("producto").Header.Caption = "Nombre del Producto"
                .Columns("cantidad").Header.Caption = "Cantidad"
                .Columns("premixero").Header.Caption = "Premixero"
                .Columns("tipo_premixero").Header.Caption = "Tipo de Premixero"

                .Columns("codprod").Hidden = True
                .Columns("idpremixero").Hidden = True
                .Columns("btneliminar").Hidden = True
            End With

            PintarPrimeraColumnaFormula()
        Catch ex As Exception
            MessageBox.Show("Error al formatear el grid de la fórmula: " & ex.Message)
        End Try
    End Sub
    Private Sub FormatearGridNucleos()
        Try
            With dtgListadoNucleo.DisplayLayout.Bands(0)
                .Columns("etiqueta").Header.Caption = "Indicador"
                .Columns("producto").Header.Caption = "Nombre del Producto"

                .Columns("codprod").Hidden = True
                .Columns("btneliminar").Hidden = True
            End With

            PintarPrimeraColumnaNucleo()
        Catch ex As Exception
            MessageBox.Show("Error al formatear el grid de núcleos: " & ex.Message)
        End Try
    End Sub

    Public Sub PintarPrimeraColumnaNucleo()
        For Each fila As UltraGridRow In dtgListadoNucleo.Rows
            fila.Cells(0).Appearance.BackColor = Color.FromArgb(255, 231, 0)
            fila.Cells(0).Appearance.ForeColor = Color.FromArgb(255, 231, 0)
        Next
    End Sub

    Public Sub PintarPrimeraColumnaFormula()
        For Each fila As UltraGridRow In dtgListadoFormula.Rows
            Dim tipoPremixero As String = fila.Cells(6).Value.ToString()

            Select Case tipoPremixero
                Case "PREMIXERO 1", "PREMIXERO 2"
                    fila.Cells(0).Appearance.BackColor = Color.FromArgb(13, 242, 5)
                    fila.Cells(0).Appearance.ForeColor = Color.FromArgb(13, 242, 5)
                Case "PREMIXERO 3"
                    fila.Cells(0).Appearance.BackColor = Color.FromArgb(37, 113, 128)
                    fila.Cells(0).Appearance.ForeColor = Color.FromArgb(37, 113, 128)
            End Select
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class