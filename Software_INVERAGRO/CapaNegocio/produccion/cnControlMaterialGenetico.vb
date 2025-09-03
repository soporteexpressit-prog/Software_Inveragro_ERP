Imports CapaDatos
Imports CapaObjetos

Public Class cnControlMaterialGenetico
    Private cls_at As New cdControlMaterialGenetico

    Public Function Cn_Mantenimiento(ByRef obj As coControlMaterialGenetico) As String
        Return cls_at.Cd_Mantenimiento("[w_pa_mant_material_genetico]", obj)
    End Function

    Public Function Cn_Consultar(ByRef obj As coControlMaterialGenetico) As DataSet
        Return cls_at.Cd_Consultar("[w_pa_cons_material_genetico]", obj)
    End Function

    Public Function Cn_ConsultarxIdUbicacionDestino(ByRef obj As coControlMaterialGenetico) As DataTable
        Return cls_at.Cd_ConsultarxUbicacionDestino("[w_pa_cons_material_genetico_x_id_ubicacion]", obj)
    End Function

    Public Function Cn_RegistrarPedidoSemenCerdoProveedor(ByRef obj As coControlMaterialGenetico) As String
        Return cls_at.Cd_RegistrarPedidoSemenCerdoProveedor("[w_pa_registrar_pedido_semen_cerdo_proveedor]", obj)
    End Function

    Public Function Cn_ListarGeneticaVerraco() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_list_genetica_verraco]")
    End Function

    Public Function Cn_ListarGeneticaCerda() As DataTable
        Return cls_at.Cd_ListarGeneral("[w_pa_list_genetica_cerda]")
    End Function

    Public Function Cn_AnularMaterialGenetico(ByRef obj As coControlMaterialGenetico) As String
        Return cls_at.Cd_DescartarMaterialGenetico("[w_pa_anular_material_genetico]", obj)
    End Function

    Public Function Cn_DescartarMaterialGenetico(ByRef obj As coControlMaterialGenetico) As String
        Return cls_at.Cd_DescartarMaterialGenetico("[w_pa_descartar_material_genetico]", obj)
    End Function

    Public Function Cn_ActualizarMotilidadDiluMaterialGenetico(ByRef obj As coControlMaterialGenetico) As String
        Return cls_at.Cd_ActualizarMotilidadDiluMaterialGenetico("[w_pa_actualizar_motilidad_material_genetico]", obj)
    End Function

    Public Function Cn_ParticionDosisMaterialGenetico(ByRef obj As coControlMaterialGenetico) As String
        Return cls_at.Cd_ParticionDosisMaterialGenetico("[w_pa_particion_dosis_material_genetico]", obj)
    End Function

    Public Function Cn_ConsultarExtraccionesxIdVerraco(ByRef obj As coControlMaterialGenetico) As DataTable
        Return cls_at.Cd_ConsultarxIdVerraco("[w_pa_cons_material_genetico_x_id_verraco]", obj)
    End Function
End Class
