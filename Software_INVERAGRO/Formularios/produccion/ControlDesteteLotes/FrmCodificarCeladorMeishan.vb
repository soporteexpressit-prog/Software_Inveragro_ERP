Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmCodificarCeladorMeishan
    Dim cn As New cnControlAnimal
    Public idJaulaCorral As Integer = 0
    Public TotalEngorde As Integer = 0
    Public IdLote As Integer = 0
    Public IdPlantel As Integer = 0

    Private Sub FrmCodificarCeladorMeishan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            If (IdPlantel > 0) Then
                ListarGalpones(IdPlantel)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        DtpFechaLlegada.Value = Now.Date
        CmbGenero.SelectedIndex = 0
        TxtJaulaCorral.ReadOnly = True
        TxtSala.ReadOnly = True
        RbnCorral.Checked = True
        LblTotalEngorde.Text = TotalEngorde
    End Sub

    Sub ListarGeneticaCerda()
        Dim cn As New cnControlMaterialGenetico
        Dim tb As New DataTable
        tb = cn.Cn_ListarGeneticaCerda().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione Genética"
        With CmbGenetica
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarGeneticaVerraco()
        Dim cn As New cnControlMaterialGenetico
        Dim tb As New DataTable
        tb = cn.Cn_ListarGeneticaVerraco().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione Genética"
        With CmbGenetica
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarGalpones(idplantel As Integer)
        Dim cn As New cnGalpon
        Dim tb As New DataTable
        Dim obj As New coGalpon With {
            .IdUbicacion = idplantel
        }
        tb = cn.Cn_Listar_Galpones_Por_Plantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With CmbGalpon
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Public Sub LlenarCamposJaulaCorral(codigo As Integer, descripcion As String, sala As String)
        idJaulaCorral = codigo
        TxtJaulaCorral.Text = descripcion
        TxtSala.Text = sala
    End Sub

    Private Sub BtnBuscarJaulaCorral_Click(sender As Object, e As EventArgs) Handles BtnBuscarJaulaCorral.Click
        Try
            Dim frm As New FrmListarJaulaCorralCM(Me) With {
                .idGalpon = CmbGalpon.Value,
                .tipo = If(RbnCorral.Checked, "CORRAL", "JAULA")
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub RbnJaula_CheckedChanged(sender As Object, e As EventArgs) Handles RbnJaula.CheckedChanged
        If RbnJaula.Checked Then
            LblAmbiente.Text = "Jaula:"
        Else
            LblAmbiente.Text = "Corral:"
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaLlegada.Value > Now.Date Then
                msj_advert("La fecha de llegada no puede ser mayor a la actual")
                Return
            End If

            If (idJaulaCorral = 0) Then
                msj_advert("Seleccione un Ubicación")
                Return
            End If


            If (MessageBox.Show("¿ESTÁ SEGURO DE CODIFICAR ESTE ANIMAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
               .FechaLlegada = DtpFechaLlegada.Value,
               .IdGenetica = CmbGenetica.Value,
               .IdJaulaCorral = idJaulaCorral,
               .IdLote = IdLote,
               .Sexo = CmbGenero.Text,
               .CodArete = TxtCodArete.Text.Trim
            }

            Dim mensaje As String = cn.Cn_RegistrarCodificacionAnimalCM(obj)
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

    Private Sub CmbGenero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbGenero.SelectedIndexChanged
        If (CmbGenero.Text = "HEMBRA") Then
            ListarGeneticaCerda()
        Else
            ListarGeneticaVerraco()
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class