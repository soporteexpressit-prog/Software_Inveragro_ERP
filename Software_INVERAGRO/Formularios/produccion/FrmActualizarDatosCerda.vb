Imports CapaNegocio
Imports CapaObjetos

Public Class FrmActualizarDatosCerda
    Dim cn As New cnControlAnimal
    Dim tipoJaulaCorral As String = ""
    Dim idJaulaCorral As Integer = 0
    Dim idJaulaCorralOriginal As Integer = 0
    Dim idGenetica As Integer = 0
    Public idCerda As Integer = 0
    Public diasVida As Integer = 0
    Public etapaReproductiva As String = ""

    Private Sub FrmSeguimientoMonitoreoAnimal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            ListarGenetica()
            ConsultarCerdaxId()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtJaulaCorral.ReadOnly = True
        TxtSala.ReadOnly = True
        RbnJaula.Checked = True
        LblDiasVida.Text = diasVida.ToString()
    End Sub

    Sub ListarGenetica()
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

    Public Sub LlenarCamposJaulaCorral(codigo As Integer, descripcion As String, sala As String)
        idJaulaCorral = codigo
        TxtJaulaCorral.Text = descripcion
        TxtSala.Text = sala
    End Sub

    Private Sub ConsultarCerdaxId()
        Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }
        Dim dt As New DataTable
        dt = cn.Cn_ConsultarAnimalxId(obj).Copy
        If (dt.Rows.Count > 0) Then
            LblCodArete.Text = dt.Rows(0)("codCerdo").ToString()
            TxtCodArete.Text = dt.Rows(0)("codCerdo").ToString()
            TxtCondCorporal.Text = dt.Rows(0)("condCorporal").ToString()
            TxtPeso.Text = dt.Rows(0)("peso").ToString()
            TxtTatuaje.Text = dt.Rows(0)("valorTatuaje").ToString()
            TxtIndice.Text = dt.Rows(0)("indice").ToString()
            CmbUbicacion.Value = dt.Rows(0)("idUbicacion").ToString()
            TxtCalificacionPatas.Text = dt.Rows(0)("calificacionPatas")
            TxtNumTetillas.Text = dt.Rows(0)("numTetillas")
            ListarGalpones(CmbUbicacion.Value)
            CmbGalpon.Value = dt.Rows(0)("idGalpon")
            tipoJaulaCorral = dt.Rows(0)("tipo")
            idJaulaCorral = dt.Rows(0)("idJaulaCorral")
            idJaulaCorralOriginal = dt.Rows(0)("idJaulaCorral")
            If (tipoJaulaCorral = "JAULA") Then
                RbnJaula.Checked = True
            Else
                RbnCorral.Checked = True
            End If
            TxtJaulaCorral.Text = dt.Rows(0)("descripcion").ToString()
            TxtSala.Text = dt.Rows(0)("sala").ToString()
            DtpFechaNacimiento.Value = dt.Rows(0)("fNacimiento")
            CmbGenetica.Value = dt.Rows(0)("idGenetica")
            ChxComportamientoCambor.Checked = CBool(dt.Rows(0)("comCamborough"))
            idGenetica = dt.Rows(0)("idGenetica")

            If (CInt(TxtCalificacionPatas.Text) > 0) Then
                TxtCalificacionPatas.ReadOnly = True
            Else
                TxtCalificacionPatas.ReadOnly = False
            End If

            If idGenetica = 1 Or idGenetica = 2 Then
                ChxComportamientoCambor.Visible = True
            End If
        End If
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
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

    Private Sub TxtCondCorporal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondCorporal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtCalificacionPatas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCalificacionPatas.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub BtnBuscarJaulaCorral_Click(sender As Object, e As EventArgs) Handles BtnBuscarJaulaCorral.Click
        Try
            Dim frm As New FrmListarJaulaCorralActualizarCerda(Me) With {
                .idGalpon = CmbGalpon.Value,
                .tipo = If(RbnCorral.Checked, "CORRAL", "JAULA")
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles CmbUbicacion.ValueChanged
        Try
            ListarGalpones(CmbUbicacion.Value)
            idJaulaCorral = 0
            TxtJaulaCorral.Text = ""
            TxtSala.Text = ""
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (TxtCondCorporal.Text.Length = 0) Then
                msj_advert("Ingrese la condición corporal")
                Return
            ElseIf (CInt(TxtCondCorporal.Text) = 0) Then
                msj_advert("La condición corporal no puede ser 0")
                Return
            ElseIf (TxtPeso.Text.Length = 0) Then
                msj_advert("Ingrese el peso")
                Return
            ElseIf (CInt(TxtPeso.Text) = 0) Then
                msj_advert("El peso no puede ser 0")
                Return
            ElseIf (TxtNumTetillas.Value = 0) Then
                msj_advert("Ingrese el número de tetillas")
                Return
            ElseIf (idJaulaCorral = 0) Then
                msj_advert("Seleccione una jaula o corral")
                Return
            End If

            If (etapaReproductiva = "LACTANTE" And idJaulaCorral <> idJaulaCorralOriginal) Then
                If (MessageBox.Show("ETAPA DE LACTANTE, AL CAMBIAR SU UBICACIÓN DE LA CERDA SUS CRÍAS TAMBIÉN SE MOVERÁN. ¿ESTÁS SEGURO DE ACTUALIZAR LOS DATOS DEL ANIMAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
            Else
                If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR LOS DATOS DEL ANIMAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
            End If

            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .CondCorporal = TxtCondCorporal.Text,
                .NumTetillas = TxtNumTetillas.Value,
                .Peso = TxtPeso.Text,
                .IdJaulaCorral = idJaulaCorral,
                .CalificacionPatas = TxtCalificacionPatas.Text,
                .IdUsuario = VP_IdUser,
                .EtapaReproductiva = If(etapaReproductiva = "LACTANTE", "SI", "NO"),
                .ValorTatuaje = TxtTatuaje.Text,
                .Indice = TxtIndice.Text,
                .CodArete = TxtCodArete.Text,
                .FechaNacimiento = DtpFechaNacimiento.Value,
                .IdGenetica = CmbGenetica.Value,
                .ComportamientoCamborough = ChxComportamientoCambor.Checked
            }

            Dim _mensaje As String = cn.Cn_ActualizarDatosCerda(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCalificacionPatas_Click(sender As Object, e As EventArgs) Handles BtnCalificacionPatas.Click
        Dim frm As New FrmCalificacionPatas
        frm.ShowDialog()
    End Sub

    Private Sub RbnCorral_CheckedChanged(sender As Object, e As EventArgs) Handles RbnCorral.CheckedChanged
        If (RbnCorral.Checked) Then
            LblJaulaCorral.Text = "Corral :"
        Else
            TxtJaulaCorral.Text = ""
            TxtSala.Text = ""
        End If
    End Sub

    Private Sub RbnJaula_CheckedChanged(sender As Object, e As EventArgs) Handles RbnJaula.CheckedChanged
        If (RbnJaula.Checked) Then
            LblJaulaCorral.Text = "Jaula :"
        Else
            TxtJaulaCorral.Text = ""
            TxtSala.Text = ""
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class