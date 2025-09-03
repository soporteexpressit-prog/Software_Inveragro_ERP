Module VariablesGlobales
    Public VP_VersionSistema As String = "0.1"
    Public tipoIngresoLogin As String = ""
    Public idPlantelGlobal As Integer = 1
    Public estadoBloqueo As Boolean = False

    'Sirve para identificar la persona que se logueo en el sistema
    Public VP_IdUser As Integer = GlobalReferences.ActiveSessionId


    'Parametros para Usar en el Sistema
    Public P_FormatoDecimales As String = "###,###,##0.00"
    Public P_FormatoDecimales2 As String = "###,###,##0.0000"
    Public P_FormatoDecimales5 As String = "###,###,##0.0000000000"
    Public P_FormatoDecimales1 As String = "###,###,##0.0"
    Public P_FormatoDecimales3 As String = "###,###,##0.000"
    Public P_Redondeo_Decimal As Integer = 2
    Public P_Redondeo_Decimal3 As Integer = 3
    Public P_IdAlmacenPrincipal As Integer = 6
    Public P_IdAlcance3 As Integer = 0


    ' Diccionario para parámetros de parto con valores por defecto PARICION
    Public ParametrosParto As New Dictionary(Of String, Object) From {
        {"fParto", Now.Date},
        {"fPartoBloqueo", 0},
        {"condCorporal", 0},
        {"condCorporalBloqueo", 0},
        {"idLote", 0},
        {"valorLote", ""},
        {"loteBloqueo", 0},
        {"idPartero", 0},
        {"valorDni", ""},
        {"valorNombre", ""},
        {"parteroBloqueo", 0},
        {"horaInicio", Now.Date.AddHours(12)},
        {"horaInicioBloqueo", 0},
        {"horaFin", Now.Date.AddHours(13)},
        {"horaFinBloqueo", 0},
        {"tatuaje", ""},
        {"tatuajeBloqueo", 0},
        {"idGalpon", 0},
        {"galponBloqueo", 0}
    }

    'Diccionario para parámetros de pérdida reproductiva
    Public ParametrosPerdidaReproductiva As New Dictionary(Of String, Object) From {
        {"fPerdidadReproductiva", Now.Date},
        {"fPerdidadReproductivaBloqueo", 0},
        {"resultado", 0},
        {"resultadoBloqueo", 0}
    }

    Public ParametrosEnvioCamalAnimal As New Dictionary(Of String, Object) From {
        {"fEnvioCamal", Now.Date},
        {"fEnvioCamalBloqueo", 0},
        {"idMotivoCamal", 0},
        {"valorMotivoCamal", ""},
        {"motivoCamalBloqueo", 0}
    }

    Public ParametrosEnvioCamalMasivo As New Dictionary(Of String, Object) From {
        {"fEnvioCamal", Now.Date},
        {"fEnvioCamalBloqueo", 0},
        {"idMotivoCamal", 0},
        {"valorMotivoCamal", ""},
        {"motivoCamalBloqueo", 0}
    }

    Public ParametrosMortalidadAnimal As New Dictionary(Of String, Object) From {
        {"fMortalidad", Now.Date},
        {"fMortalidadBloqueo", 0},
        {"idMotivoMortalidad", 0},
        {"valorMotivoMortalidad", ""},
        {"motivoMortalidadBloqueo", 0}
    }

    ' Diccionario para parámetros de parto con valores por defecto INSEMINACION
    Public ParametrosInseminacion As New Dictionary(Of String, Object) From {
        {"fMonta", Now.Date},
        {"fMontaBloqueo", 0},
        {"cantExpulsada", 3},
        {"cantExpulsadaBloqueo", 0},
        {"via", "CERVICAL"},
        {"viaBloqueo", 0},
        {"idInseminador", ""},
        {"valorNombre", ""},
        {"inseminadorBloqueo", 0}
    }

    ' Diccionario para parámetros de parto con valores por defecto Codificacion Animales
    Public ParametrosCodificacionAnimales As New Dictionary(Of String, Object) From {
        {"fLlegada", Now.Date},
        {"fLlegadaBloqueo", 0},
        {"pesoActual", 0},
        {"pesoActualBloqueo", 0},
        {"idGenetica", 1},
        {"geneticaBloqueo", 0},
        {"idJaulaCorral", 0},
        {"valorJaulaCorral", ""},
        {"valorSala", ""},
        {"jaulaCorralBloqueo", 0}
    }

    Public ParametrosMortalidadCriasMaternidad As New Dictionary(Of String, Object) From {
        {"fMortalidad", Now.Date},
        {"fMortalidadBloqueo", 0},
        {"idMotivoMortalidad", 0},
        {"valorMotivoMortalidad", ""},
        {"motivoMortalidadBloqueo", 0}
    }

    Public ParametrosNodriza As New Dictionary(Of String, Object) From {
        {"fNodriza", Now.Date},
        {"fNodrizaBloqueo", 0}
    }

    Public ParametrosMovimientoMaternidad As New Dictionary(Of String, Object) From {
        {"fMovimiento", Now.Date},
        {"fMovimientoBloqueo", 0},
        {"idCerda1", 0},
        {"txtArete1", ""},
        {"totalCriasCerda1", 0},
        {"idLote1", 0},
        {"cerda1Bloqueo", 0},
        {"idCerda2", 0},
        {"txtArete2", ""},
        {"totalCriasCerda2", 0},
        {"idLote2", 0},
        {"cerda2Bloqueo", 0}
    }

    'Variables seleccionadas para compartir entre formularios'
    Public Sub msj_error(msj As [String])
        'Configuramos un estilo de mensaje de error estandar'
        Try
            MessageBox.Show(msj.ToString.ToUpper, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub
    Public Sub msj_advert(msj As [String])
        'Configuramos un estilo de mensaje de advertencia estandar'
        Try
            MessageBox.Show(msj.ToString.ToUpper, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
        End Try
    End Sub
    Public Sub msj_ok(msj As [String])
        'Configuramos un estilo de mensaje de ok estandar'
        Try
            MessageBox.Show(msj.ToString.ToUpper, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
        End Try
    End Sub

    'CONSTANTES PARA TABLA MAESTRA DE CONFIGURACIONES
    Public Const ID_CARTA_DESPIDO_P1 As Integer = 7
    Public Const ID_CARTA_DESPIDO_P2 As Integer = 8
    Public Const ID_NOMBRE_ANIO As Integer = 9
    Public Const ID_MEMORANDUM_P1 As Integer = 10
    Public Const ID_MEMORANDUM_P2 As Integer = 11
    Public Const ID_LOGO_MEMORANDUM As Integer = 13
    Public Const ID_LOGO_CARTA_DESPIDO As Integer = 14
End Module
