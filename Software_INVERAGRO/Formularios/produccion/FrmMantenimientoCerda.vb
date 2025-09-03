Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoCerda
    Private idJaulaCorral As Integer = 0
    Private idProductoCerda As Integer = 0
    Private cn As New cnControlAnimal
    Public idUbicacion As Integer = 0

    Private Sub FrmMantenimientoCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            CmbUbicacion.Value = idUbicacion
            CmbUbicacion.Enabled = False
            ListarGenetica()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        RbnJaula.Checked = True
        TxtJaulaCorral.ReadOnly = True
        TxtSala.ReadOnly = True
        TxtPeso.Select()
        CbxGraja.Checked = True
        TxtCerdaExterna.ReadOnly = True
        TxtGenetica.ReadOnly = True
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

    Private Sub RbnCorral_CheckedChanged(sender As Object, e As EventArgs) Handles RbnCorral.CheckedChanged
        If (RbnCorral.Checked) Then
            LblJaulaCorral.Text = "Corral :"
        Else
            idJaulaCorral = 0
            TxtJaulaCorral.Text = ""
            TxtSala.Text = ""
        End If
    End Sub

    Private Sub RbnJaula_CheckedChanged(sender As Object, e As EventArgs) Handles RbnJaula.CheckedChanged
        If (RbnJaula.Checked) Then
            LblJaulaCorral.Text = "Jaula :"
        Else
            idJaulaCorral = 0
            TxtJaulaCorral.Text = ""
            TxtSala.Text = ""
        End If
    End Sub

    Public Sub LlenarCamposJaulaCorral(codigo As Integer, descripcion As String, sala As String)
        idJaulaCorral = codigo
        TxtJaulaCorral.Text = descripcion
        TxtSala.Text = sala
    End Sub

    Public Sub LlenarCamposCerda(codigo As String, descripcion As String, presentacion As String)
        idProductoCerda = codigo
        TxtCerdaExterna.Text = descripcion
        TxtGenetica.Text = presentacion
    End Sub

    Private Sub BtnBuscarJaulaCorral_Click(sender As Object, e As EventArgs) Handles BtnBuscarJaulaCorral.Click
        Try
            Dim frm As New FrmListarJaulaCorralCerda(Me) With {
                .idGalpon = CmbGalpon.Value,
                .tipo = If(RbnCorral.Checked, "CORRAL", "JAULA")
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (TxtPeso.Text.Length = 0) Then
                msj_advert("Ingrese un Peso")
                Return
            ElseIf (CDec(TxtPeso.Text) <= 0) Then
                msj_advert("Ingrese un Peso mayor a 0")
                Return
            ElseIf (TxtCondicionCorporal.Text.Length = 0) Then
                msj_advert("Ingrese condición corporal")
                Return
            ElseIf (CDec(TxtCondicionCorporal.Text) <= 0) Then
                msj_advert("Ingrese condición corporal mayor a 0")
                Return
            ElseIf (TxtNumTetillas.Text.Length = 0) Then
                msj_advert("Ingrese número de tetillas")
                Return
            ElseIf (CDec(TxtNumTetillas.Text) <= 0) Then
                msj_advert("Ingrese número de tetillas mayor a 0")
                Return
            ElseIf (idJaulaCorral = 0) Then
                msj_advert("Seleccione un Ubicación")
                Return
            ElseIf (idProductoCerda = 0 And Not CbxGraja.Checked) Then
                msj_advert("Seleccione el cerdo de adquisición")
                Return
            ElseIf (dtpFechaNacimiento.Value > Now) Then
                msj_advert("La fecha de nacimiento no puede ser mayor a la fecha actual")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR A LA CERDA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .FechaNacimiento = dtpFechaNacimiento.Value,
                .Peso = TxtPeso.Text,
                .Indice = If(TxtIndice.Text = "", 0, TxtIndice.Text),
                .IdGenetica = CmbGenetica.Value,
                .IdJaulaCorral = idJaulaCorral,
                .NumTetillas = TxtNumTetillas.Text,
                .CondCorporal = TxtCondicionCorporal.Text,
                .NumPartos = NumPartos.Value,
                .TipoAdquisicion = If(CbxGraja.Checked, "GRANJA", "COMPRADO"),
                .IdProducto = If(CbxGraja.Checked, Nothing, idProductoCerda),
                .IdUsuario = VP_IdUser,
                .ValorTatuaje = TxtTatuaje.Text,
                .FechaLlegada = DtpFechaLlegada.Value,
                .CodArete = TxtCodArete.Text
            }

            Dim mensaje As String = cn.Cn_RegistrarCerda(obj)
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

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtNumTetillas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumTetillas.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtCondicionCorporal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondicionCorporal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub NumPartos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumPartos.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub CbxGraja_CheckedChanged(sender As Object, e As EventArgs) Handles CbxGraja.CheckedChanged
        If CbxGraja.Checked Then
            UgbInfoAdquisicion.Visible = False
            Me.Height = 530
        Else
            UgbInfoAdquisicion.Visible = True
            Me.Height = 610
        End If
        TxtCerdaExterna.Text = ""
        TxtGenetica.Text = ""
        idProductoCerda = 0
    End Sub

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        If Not CbxGraja.Checked Then
            Dim frm As New FrmListarProductoCerda(Me)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub TxtIndice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIndice.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub CmbGalpon_TextChanged(sender As Object, e As EventArgs) Handles CmbGalpon.TextChanged
        idJaulaCorral = 0
        TxtJaulaCorral.Text = ""
        TxtSala.Text = ""
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class