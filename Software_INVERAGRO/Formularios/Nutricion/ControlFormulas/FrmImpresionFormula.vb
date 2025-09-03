Imports CapaNegocio
Imports CapaObjetos

Public Class FrmImpresionFormula
    Dim cn As New cnControlFormulacion
    Dim ds As New DataSet
    Dim idPeriodoMedicacionValor As Integer = 0
    Dim idPeriodoPlusValor As Integer = 0
    Public idFormulaRacion As Integer = 0
    Public idRacion As Integer = 0
    Public racion As String = ""
    Public idUbicacionMedicacion As Integer = 0
    Public idUbicacionPlus As Integer = 0

    Private Sub FrmImpresionFormula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CmTipoPremixero.SelectedIndex = 0
            CbxMedicado.Checked = False
            CbxAnti.Checked = False
            'para el medicado
            LblMedicaciones.Visible = False
            BtnBuscarMedicacion.Visible = False
            LblSeleccionadoMedic.Visible = False
            'para el plus
            LblPlus.Visible = False
            BtnPlus.Visible = False
            LblSeleccionadoPlus.Visible = False
            MedicacionAntiRacion()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub MedicacionAntiRacion()
        Dim obj As New coControlFormulacion With {
            .IdFormulaRacion = idFormulaRacion
        }

        Dim ds As DataSet = cn.Cn_ConsultarAntiMedicadoRacion(obj)

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                Dim tieneAnti As String = ds.Tables(1).Rows(0)("anti")
                Dim tieneMedicado As String = ds.Tables(1).Rows(0)("medicado")
                Dim tienePlus As String = ds.Tables(1).Rows(0)("plus")

                If tieneMedicado = "SI" Then
                    CbxMedicado.Enabled = True
                End If

                If tieneAnti = "SI" Then
                    CbxAnti.Enabled = True
                    CbxAnti.Checked = True
                End If

                If tienePlus = "SI" Then
                    CbxMedicado.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub txtPreparacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPreparacion.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnImpresionRacion_Click(sender As Object, e As EventArgs) Handles BtnImpresionRacion.Click
        Try
            Dim tipoRacion As String = ""

            If (txtPreparacion.Text = "") Then
                msj_advert("La cantidad de preparación no puede ser vacía")
                Return
            End If

            If (CDec(txtPreparacion.Text) <= 0) Then
                msj_advert("La cantidad de preparación debe ser mayor a 0")
                Return
            End If

            If CbxMedicado.Checked And CbxPlus.Checked Then
                If idUbicacionMedicacion <> idUbicacionPlus Then
                    msj_advert("Las ubicaciones de la medicación y el plus deben ser iguales")
                    Return
                End If
            End If

            If (CbxMedicado.Checked = False And CbxAnti.Checked = False And CbxPlus.Checked = False) Then
                tipoRacion = "NORMAL"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = False And CbxPlus.Checked = False) Then
                tipoRacion = "ANTI"
            ElseIf (CbxMedicado.Checked = True And CbxAnti.Checked = False And CbxPlus.Checked = False) Then
                tipoRacion = "MEDICADO"
            ElseIf (CbxAnti.Checked = False And CbxMedicado.Checked = False And CbxPlus.Checked = True) Then
                tipoRacion = "PLUS"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = True And CbxPlus.Checked = False) Then
                tipoRacion = "ANTI-MEDICADO"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = False And CbxPlus.Checked = True) Then
                tipoRacion = "ANTI-PLUS"
            ElseIf (CbxAnti.Checked = False And CbxMedicado.Checked = True And CbxPlus.Checked = True) Then
                tipoRacion = "MEDICADO-PLUS"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = True And CbxPlus.Checked = True) Then
                tipoRacion = "ANTI-MEDICADO-PLUS"
            End If

            If CbxMedicado.Checked And idPeriodoMedicacionValor = 0 Then
                msj_advert("Debe seleccionar una medicación")
                Return
            End If

            If CbxPlus.Checked And idPeriodoPlusValor = 0 Then
                msj_advert("Debe seleccionar un plus")
                Return
            End If

            Dim obj As New coControlFormulacion With {
                .IdFormulaRacion = idFormulaRacion,
                .Diseño = CDec(txtPreparacion.Text),
                .Descripcion = racion,
                .Tipo = tipoRacion,
                .Nota = TxtNota.Text,
                .IdPeriodoMedicion = idPeriodoMedicacionValor,
                .IdPeriodoPlus = idPeriodoPlusValor
            }

            ds = cn.Cn_ObtenerPreparacionFormulaTotal(obj)
            GenerarReporteTotal(ds, tipoRacion)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnImpresionPremixero_Click(sender As Object, e As EventArgs) Handles BtnImpresionPremixero.Click
        Try
            Dim tipoPremixero As String = ""
            Dim tipoRacion As String = ""

            If (txtPreparacion.Text = "") Then
                msj_advert("La cantidad de preparación no puede ser vacía")
                Return
            End If

            If (CInt(txtPreparacion.Text) <= 0) Then
                msj_advert("La cantidad de preparación debe ser mayor a 0")
                Return
            End If

            If CbxMedicado.Checked And CbxPlus.Checked Then
                If idUbicacionMedicacion <> idUbicacionPlus Then
                    msj_advert("Las ubicaciones de la medicación y el plus deben ser iguales")
                    Return
                End If
            End If

            If (CbxMedicado.Checked = False And CbxAnti.Checked = False And CbxPlus.Checked = False) Then
                tipoRacion = "NORMAL"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = False And CbxPlus.Checked = False) Then
                tipoRacion = "ANTI"
            ElseIf (CbxMedicado.Checked = True And CbxAnti.Checked = False And CbxPlus.Checked = False) Then
                tipoRacion = "MEDICADO"
            ElseIf (CbxAnti.Checked = False And CbxMedicado.Checked = False And CbxPlus.Checked = True) Then
                tipoRacion = "PLUS"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = True And CbxPlus.Checked = False) Then
                tipoRacion = "ANTI-MEDICADO"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = False And CbxPlus.Checked = True) Then
                tipoRacion = "ANTI-PLUS"
            ElseIf (CbxAnti.Checked = False And CbxMedicado.Checked = True And CbxPlus.Checked = True) Then
                tipoRacion = "MEDICADO-PLUS"
            ElseIf (CbxAnti.Checked = True And CbxMedicado.Checked = True And CbxPlus.Checked = True) Then
                tipoRacion = "ANTI-MEDICADO-PLUS"
            End If

            If CbxMedicado.Checked And idPeriodoMedicacionValor = 0 Then
                msj_advert("Debe seleccionar una medicación")
                Return
            End If

            If CbxPlus.Checked And idPeriodoPlusValor = 0 Then
                msj_advert("Debe seleccionar un plus")
                Return
            End If

            tipoPremixero = CmTipoPremixero.Text

            Dim obj As New coControlFormulacion With {
                .IdFormulaRacion = idFormulaRacion,
                .Diseño = CInt(txtPreparacion.Text),
                .Descripcion = racion,
                .Tipo = tipoRacion,
                .Nota = TxtNota.Text,
                .TipoPremixero = tipoPremixero,
                .IdPeriodoMedicion = idPeriodoMedicacionValor,
                .IdPeriodoPlus = idPeriodoPlusValor
            }

            ds = cn.Cn_ObtenerPreparacionFormulaTipoPremixero(obj)
            GenerarReportePorPremixero(ds, tipoPremixero)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub GenerarReportePorPremixero(ByVal dsFiltrado As DataSet, tipoPremixero As String)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            If (tipoPremixero = "PREMIXERO 1") Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_PorPremixeroSumatoria.mrt"))
            Else
                If CbxAnti.Checked And tipoPremixero = "PREMIXERO 2" Then
                    StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_PorPremixeroConAnti.mrt"))
                Else
                    StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_PorPremixero.mrt"))
                End If
            End If
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsFiltrado)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub GenerarReporteTotal(ByVal dsFiltrado As DataSet, tipoRacion As String)
        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            If (tipoRacion.Contains("ANTI")) Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_TotalPremixerosConAnti.mrt"))
            Else
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_TotalPremixeros.mrt"))
            End If
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsFiltrado)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CbxMedicado_CheckedChanged(sender As Object, e As EventArgs) Handles CbxMedicado.CheckedChanged
        If CbxMedicado.Checked Then
            LblMedicaciones.Visible = True
            BtnBuscarMedicacion.Visible = True
            LblSeleccionadoMedic.Visible = True
        Else
            LblMedicaciones.Visible = False
            BtnBuscarMedicacion.Visible = False
            LblSeleccionadoMedic.Visible = False
            LblSeleccionadoMedic.Text = ""
            idPeriodoMedicacionValor = 0
        End If
    End Sub

    Private Sub CbxPlus_CheckedChanged(sender As Object, e As EventArgs) Handles CbxPlus.CheckedChanged
        If CbxPlus.Checked Then
            LblPlus.Visible = True
            BtnPlus.Visible = True
            LblSeleccionadoPlus.Visible = True
        Else
            LblPlus.Visible = False
            BtnPlus.Visible = False
            LblSeleccionadoPlus.Visible = False
            LblSeleccionadoPlus.Text = ""
            idPeriodoPlusValor = 0
        End If
    End Sub

    Public Sub ActualizarMedicacionRacion(codigo As Integer, tipo As String, ubicacion As String, idUbicacion As Integer)
        If tipo.Contains("MEDICADO") Then
            idPeriodoMedicacionValor = codigo
            LblSeleccionadoMedic.Text = tipo & " / " & ubicacion
            idUbicacionMedicacion = idUbicacion
        ElseIf tipo.Contains("PLUS") Then
            idPeriodoPlusValor = codigo
            LblSeleccionadoPlus.Text = tipo & " / " & ubicacion
            idUbicacionPlus = idUbicacion
        End If
    End Sub

    Private Sub BtnBuscarMedicacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarMedicacion.Click
        Try
            Dim frm As New FrmListaMedicacionPorRacion(Me) With {
                .idRacion = idRacion,
                .tipo = "MEDICACIÓN"
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnPlus_Click(sender As Object, e As EventArgs) Handles BtnPlus.Click
        Try
            Dim frm As New FrmListaMedicacionPorRacion(Me) With {
                .idRacion = idRacion,
                .tipo = "PLUS"
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class