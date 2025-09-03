Imports CapaNegocio
Imports CapaObjetos

Public Class FrmActualizarDatosVerraco
    Dim cn As New cnControlAnimal
    Dim tipoJaulaCorral As String = ""
    Dim idJaulaCorral As Integer = 0
    Public idVerraco As Integer = 0
    Dim idMotivoMortalidad As Integer = 0

    Private Sub FrmActualizarDatosVerraco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            ListarGenetica()
            ConsultarVerracoxId()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtJaulaCorral.ReadOnly = True
        TxtSala.ReadOnly = True
        RbnJaula.Checked = False
        RbnCorral.Checked = False
    End Sub

    Sub ListarGenetica()
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

    Public Sub LlenarCamposJaulaCorral(codigo As Integer, descripcion As String, sala As String)
        idJaulaCorral = codigo
        TxtJaulaCorral.Text = descripcion
        TxtSala.Text = sala
    End Sub

    Private Sub ConsultarVerracoxId()
        Dim obj As New coControlAnimal With {
                .Codigo = idVerraco
            }
        Dim dt As New DataTable
        dt = cn.Cn_ConsultarAnimalxId(obj).Copy
        If (dt.Rows.Count > 0) Then
            LblCodArete.Text = dt.Rows(0)("codCerdo").ToString()
            TxtCodArete.Text = dt.Rows(0)("codCerdo").ToString()
            TxtPeso.Text = dt.Rows(0)("peso").ToString()
            TxtTatuaje.Text = dt.Rows(0)("valorTatuaje").ToString()
            TxtIndice.Text = dt.Rows(0)("indice").ToString()
            CmbUbicacion.Value = dt.Rows(0)("idUbicacion").ToString()
            ListarGalpones(CmbUbicacion.Value)
            CmbGalpon.Value = dt.Rows(0)("idGalpon")
            tipoJaulaCorral = dt.Rows(0)("tipo")
            idJaulaCorral = dt.Rows(0)("idJaulaCorral")
            If (tipoJaulaCorral = "JAULA") Then
                RbnJaula.Checked = True
            Else
                RbnCorral.Checked = True
            End If
            TxtJaulaCorral.Text = dt.Rows(0)("descripcion").ToString()
            TxtSala.Text = dt.Rows(0)("sala").ToString()
            DtpFechaNacimiento.Value = dt.Rows(0)("fNacimiento")
            CmbGenetica.Value = dt.Rows(0)("idGenetica")
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
        Dim obj As New coGalpon
        obj.IdUbicacion = idplantel
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

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnBuscarJaulaCorral_Click(sender As Object, e As EventArgs) Handles BtnBuscarJaulaCorral.Click
        Try
            Dim frm As New FrmListarJaulaCorralActualizarVerraco(Me) With {
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
            If (TxtPeso.Text.Length = 0) Then
                msj_advert("Ingrese el peso")
                Return
            ElseIf (CInt(TxtPeso.Text) = 0) Then
                msj_advert("El peso no puede ser 0")
                Return
            ElseIf (idJaulaCorral = 0) Then
                msj_advert("Seleccione una jaula o corral")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR LOS DATOS DEL ANIMAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Codigo = idVerraco,
                .CodArete = TxtCodArete.Text,
                .Peso = TxtPeso.Text,
                .IdJaulaCorral = idJaulaCorral,
                .IdUsuario = VP_IdUser,
                .ValorTatuaje = TxtTatuaje.Text,
                .Indice = TxtIndice.Text,
                .FechaNacimiento = DtpFechaNacimiento.Value,
                .IdGenetica = CmbGenetica.Value
            }

            Dim _mensaje As String = cn.Cn_ActualizarDatosVerraco(obj)
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