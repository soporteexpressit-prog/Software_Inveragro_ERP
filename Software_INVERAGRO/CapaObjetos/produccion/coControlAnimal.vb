Public Class coControlAnimal
    Private _Operacion As Integer
    Private _Codigo As Integer
    Private _CodArete As String
    Private _FechaNacimiento As Date
    Private _FechaLlegada As Date
    Private _Peso As Decimal
    Private _DiasVida As Integer
    Private _Indice As Decimal
    Private _IdGenetica As Integer
    Private _NumTetillas As Integer
    Private _CondCorporal As Decimal
    Private _NumPartos As Integer
    Private _IdJaulaCorral As Integer
    Private _Coderror As Integer
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _EstadoVivo As String
    Private _EstadoVenta As String
    Private _TipoAdquisicion As String
    Private _IdProducto As Integer
    Private _IdUsuario As Integer
    Private _DiasTranscurridos As Integer
    Private _Resultado As String
    Private _Observacion As String
    Private _IdDetalleInseminacion As Integer
    Private _EtapaReproductiva As String
    Private _CalificacionPatas As Integer
    Private _FechaPartoProbable As Date
    Private _IdHistorialEtapaAnimal As Integer
    Private _FechaControl As Date
    Private _TotalNacidosMachos As Integer
    Private _TotalNacidosHembras As Integer
    Private _TotalBallicos As Integer
    Private _TotalMomias As Integer
    Private _PesoPromedioCrias As Decimal
    Private _PesoTotalCrias As Decimal
    Private _Duracion As Decimal
    Private _ListaPesoCrias As String
    Private _IdResponsable As Integer
    Private _TotalMuertos As Integer
    Private _ListaCriasRegistrar As String
    Private _IdPlantel As Integer
    Private _IdMotivoMortalidad As Integer
    Private _TipoControl As String
    Private _ListaIdsCriasConCod As String
    Private _ListaIdsCriasSinCod As String
    Private _CantidadMuertoConCod As Integer
    Private _CantidadMuertoSinCod As Integer
    Private _IdControlParto As Integer
    Private _IdLote As Integer
    Private _Anio As Integer
    Private _ArchivoFotoCamal As Byte()
    Private _ArchivoFotoMortalidad As Byte()
    Private _IdHistorialEnvioCamal As Integer
    Private _CantidadCrias As Integer
    Private _CantidadCriasRegistradas As Integer
    Private _ValorTatuaje As String
    Private _CantidadMuertosEngorde As Integer
    Private _CantidadMuertosTatuaje As Integer
    Private _CantidadCamalEngorde As Integer
    Private _CantidadCamalTatuaje As Integer
    Private _DiaPic As Integer
    Private _DejarVaciaoLactando As String
    Private _IdControlFichaMortalidad As Integer
    Private _ListaCerdasDonantes As String
    Private _ListaIdsCriasDonantes As String
    Private _TotalCriasDonar As Integer
    Private _IdControlFichaDonacion As Integer
    Private _MotivoAnulacion As String
    Private _Filtro As String
    Private _ComportamientoCamborough As Boolean
    Private _Estado As String
    Private _NumRegistros As Integer
    Private _IdMotivoTransaccion As Integer
    Private _Sexo As String
    Private _IdControlFicha As Integer
    Private _EnvioCamal As String
    Private _ListaIdsControlFicha As String
    Private _IdArea As Integer
    Private _ChanchillaEngorde As Boolean
    Private _IdCampaña As Integer

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
        End Set
    End Property

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property CodArete As String
        Get
            Return _CodArete
        End Get
        Set(value As String)
            _CodArete = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            _FechaNacimiento = value
        End Set
    End Property

    Public Property FechaLlegada As Date
        Get
            Return _FechaLlegada
        End Get
        Set(value As Date)
            _FechaLlegada = value
        End Set
    End Property

    Public Property Peso As Decimal
        Get
            Return _Peso
        End Get
        Set(value As Decimal)
            _Peso = value
        End Set
    End Property

    Public Property DiasVida As Integer
        Get
            Return _DiasVida
        End Get
        Set(value As Integer)
            _DiasVida = value
        End Set
    End Property

    Public Property Indice As Decimal
        Get
            Return _Indice
        End Get
        Set(value As Decimal)
            _Indice = value
        End Set
    End Property

    Public Property IdGenetica As Integer
        Get
            Return _IdGenetica
        End Get
        Set(value As Integer)
            _IdGenetica = value
        End Set
    End Property

    Public Property NumTetillas As Integer
        Get
            Return _NumTetillas
        End Get
        Set(value As Integer)
            _NumTetillas = value
        End Set
    End Property

    Public Property CondCorporal As Decimal
        Get
            Return _CondCorporal
        End Get
        Set(value As Decimal)
            _CondCorporal = value
        End Set
    End Property

    Public Property NumPartos As Integer
        Get
            Return _NumPartos
        End Get
        Set(value As Integer)
            _NumPartos = value
        End Set
    End Property

    Public Property IdJaulaCorral As Integer
        Get
            Return _IdJaulaCorral
        End Get
        Set(value As Integer)
            _IdJaulaCorral = value
        End Set
    End Property

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property

    Public Property FechaDesde As Nullable(Of Date)
        Get
            Return _FechaDesde
        End Get
        Set(value As Nullable(Of Date))
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Nullable(Of Date)
        Get
            Return _FechaHasta
        End Get
        Set(value As Nullable(Of Date))
            _FechaHasta = value
        End Set
    End Property

    Public Property EstadoVivo As String
        Get
            Return _EstadoVivo
        End Get
        Set(value As String)
            _EstadoVivo = value
        End Set
    End Property

    Public Property EstadoVenta As String
        Get
            Return _EstadoVenta
        End Get
        Set(value As String)
            _EstadoVenta = value
        End Set
    End Property

    Public Property TipoAdquisicion As String
        Get
            Return _TipoAdquisicion
        End Get
        Set(value As String)
            _TipoAdquisicion = value
        End Set
    End Property

    Public Property IdProducto As Integer
        Get
            Return _IdProducto
        End Get
        Set(value As Integer)
            _IdProducto = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
        End Set
    End Property

    Public Property DiasTranscurridos As Integer
        Get
            Return _DiasTranscurridos
        End Get
        Set(value As Integer)
            _DiasTranscurridos = value
        End Set
    End Property

    Public Property Resultado As String
        Get
            Return _Resultado
        End Get
        Set(value As String)
            _Resultado = value
        End Set
    End Property

    Public Property Observacion As String
        Get
            Return _Observacion
        End Get
        Set(value As String)
            _Observacion = value
        End Set
    End Property

    Public Property IdDetalleInseminacion As Integer
        Get
            Return _IdDetalleInseminacion
        End Get
        Set(value As Integer)
            _IdDetalleInseminacion = value
        End Set
    End Property

    Public Property EtapaReproductiva As String
        Get
            Return _EtapaReproductiva
        End Get
        Set(value As String)
            _EtapaReproductiva = value
        End Set
    End Property

    Public Property CalificacionPatas As Integer
        Get
            Return _CalificacionPatas
        End Get
        Set(value As Integer)
            _CalificacionPatas = value
        End Set
    End Property

    Public Property FechaPartoProbable As Date
        Get
            Return _FechaPartoProbable
        End Get
        Set(value As Date)
            _FechaPartoProbable = value
        End Set
    End Property

    Public Property IdHistorialEtapaAnimal As Integer
        Get
            Return _IdHistorialEtapaAnimal
        End Get
        Set(value As Integer)
            _IdHistorialEtapaAnimal = value
        End Set
    End Property

    Public Property FechaControl As Date
        Get
            Return _FechaControl
        End Get
        Set(value As Date)
            _FechaControl = value
        End Set
    End Property

    Public Property TotalNacidosMachos As Integer
        Get
            Return _TotalNacidosMachos
        End Get
        Set(value As Integer)
            _TotalNacidosMachos = value
        End Set
    End Property

    Public Property TotalNacidosHembras As Integer
        Get
            Return _TotalNacidosHembras
        End Get
        Set(value As Integer)
            _TotalNacidosHembras = value
        End Set
    End Property

    Public Property TotalBallicos As Integer
        Get
            Return _TotalBallicos
        End Get
        Set(value As Integer)
            _TotalBallicos = value
        End Set
    End Property

    Public Property TotalMomias As Integer
        Get
            Return _TotalMomias
        End Get
        Set(value As Integer)
            _TotalMomias = value
        End Set
    End Property

    Public Property PesoPromedioCrias As Decimal
        Get
            Return _PesoPromedioCrias
        End Get
        Set(value As Decimal)
            _PesoPromedioCrias = value
        End Set
    End Property

    Public Property PesoTotalCrias As Decimal
        Get
            Return _PesoTotalCrias
        End Get
        Set(value As Decimal)
            _PesoTotalCrias = value
        End Set
    End Property

    Public Property Duracion As Decimal
        Get
            Return _Duracion
        End Get
        Set(value As Decimal)
            _Duracion = value
        End Set
    End Property

    Public Property ListaCrias As String
        Get
            Return _ListaPesoCrias
        End Get
        Set(value As String)
            _ListaPesoCrias = value
        End Set
    End Property

    Public Property IdResponsable As Integer
        Get
            Return _IdResponsable
        End Get
        Set(value As Integer)
            _IdResponsable = value
        End Set
    End Property

    Public Property TotalMuertos As Integer
        Get
            Return _TotalMuertos
        End Get
        Set(value As Integer)
            _TotalMuertos = value
        End Set
    End Property

    Public Property ListaCriasRegistrar As String
        Get
            Return _ListaCriasRegistrar
        End Get
        Set(value As String)
            _ListaCriasRegistrar = value
        End Set
    End Property

    Public Property IdPlantel As Integer
        Get
            Return _IdPlantel
        End Get
        Set(value As Integer)
            _IdPlantel = value
        End Set
    End Property

    Public Property IdMotivoMortalidadCamal As Integer
        Get
            Return _IdMotivoMortalidad
        End Get
        Set(value As Integer)
            _IdMotivoMortalidad = value
        End Set
    End Property

    Public Property TipoControl As String
        Get
            Return _TipoControl
        End Get
        Set(value As String)
            _TipoControl = value
        End Set
    End Property

    Public Property ListaIdsCriasConCod As String
        Get
            Return _ListaIdsCriasConCod
        End Get
        Set(value As String)
            _ListaIdsCriasConCod = value
        End Set
    End Property

    Public Property ListaIdsCriasSinCod As String
        Get
            Return _ListaIdsCriasSinCod
        End Get
        Set(value As String)
            _ListaIdsCriasSinCod = value
        End Set
    End Property

    Public Property CantidadMuertoConCod As Integer
        Get
            Return _CantidadMuertoConCod
        End Get
        Set(value As Integer)
            _CantidadMuertoConCod = value
        End Set
    End Property

    Public Property CantidadMuertoSinCod As Integer
        Get
            Return _CantidadMuertoSinCod
        End Get
        Set(value As Integer)
            _CantidadMuertoSinCod = value
        End Set
    End Property

    Public Property IdControlParto As Integer
        Get
            Return _IdControlParto
        End Get
        Set(value As Integer)
            _IdControlParto = value
        End Set
    End Property

    Public Property IdLote As Integer
        Get
            Return _IdLote
        End Get
        Set(value As Integer)
            _IdLote = value
        End Set
    End Property

    Public Property Anio As Integer
        Get
            Return _Anio
        End Get
        Set(value As Integer)
            _Anio = value
        End Set
    End Property

    Public Property ArchivoFotoCamal As Byte()
        Get
            Return _ArchivoFotoCamal
        End Get
        Set(value As Byte())
            _ArchivoFotoCamal = value
        End Set
    End Property

    Public Property IdHistorialEnvioCamal As Integer
        Get
            Return _IdHistorialEnvioCamal
        End Get
        Set(value As Integer)
            _IdHistorialEnvioCamal = value
        End Set
    End Property

    Public Property CantidadCrias As Integer
        Get
            Return _CantidadCrias
        End Get
        Set(value As Integer)
            _CantidadCrias = value
        End Set
    End Property

    Public Property CantidadCriasRegistradas As Integer
        Get
            Return _CantidadCriasRegistradas
        End Get
        Set(value As Integer)
            _CantidadCriasRegistradas = value
        End Set
    End Property

    Public Property ValorTatuaje As String
        Get
            Return _ValorTatuaje
        End Get
        Set(value As String)
            _ValorTatuaje = value
        End Set
    End Property

    Public Property CantidadMuertosEngorde As Integer
        Get
            Return _CantidadMuertosEngorde
        End Get
        Set(value As Integer)
            _CantidadMuertosEngorde = value
        End Set
    End Property

    Public Property CantidadMuertosTatuaje As Integer
        Get
            Return _CantidadMuertosTatuaje
        End Get
        Set(value As Integer)
            _CantidadMuertosTatuaje = value
        End Set
    End Property

    Public Property CantidadCamalEngorde As Integer
        Get
            Return _CantidadCamalEngorde
        End Get
        Set(value As Integer)
            _CantidadCamalEngorde = value
        End Set
    End Property

    Public Property CantidadCamalTatuaje As Integer
        Get
            Return _CantidadCamalTatuaje
        End Get
        Set(value As Integer)
            _CantidadCamalTatuaje = value
        End Set
    End Property

    Public Property DiaPic As Integer
        Get
            Return _DiaPic
        End Get
        Set(value As Integer)
            _DiaPic = value
        End Set
    End Property

    Public Property DejarVaciaoLactando As String
        Get
            Return _DejarVaciaoLactando
        End Get
        Set(value As String)
            _DejarVaciaoLactando = value
        End Set
    End Property

    Public Property IdControlFichaMortalidad As Integer
        Get
            Return _IdControlFichaMortalidad
        End Get
        Set(value As Integer)
            _IdControlFichaMortalidad = value
        End Set
    End Property

    Public Property ListaCerdasDonantes As String
        Get
            Return _ListaCerdasDonantes
        End Get
        Set(value As String)
            _ListaCerdasDonantes = value
        End Set
    End Property

    Public Property ListaIdsCriasDonantes As String
        Get
            Return _ListaIdsCriasDonantes
        End Get
        Set(value As String)
            _ListaIdsCriasDonantes = value
        End Set
    End Property

    Public Property TotalCriasDonar As Integer
        Get
            Return _TotalCriasDonar
        End Get
        Set(value As Integer)
            _TotalCriasDonar = value
        End Set
    End Property

    Public Property IdControlFichaDonacion As Integer
        Get
            Return _IdControlFichaDonacion
        End Get
        Set(value As Integer)
            _IdControlFichaDonacion = value
        End Set
    End Property

    Public Property ArchivoFotoMortalidad As Byte()
        Get
            Return _ArchivoFotoMortalidad
        End Get
        Set(value As Byte())
            _ArchivoFotoMortalidad = value
        End Set
    End Property

    Public Property Filtro As String
        Get
            Return _Filtro
        End Get
        Set(value As String)
            _Filtro = value
        End Set
    End Property

    Public Property MotivoAnulacion As String
        Get
            Return _MotivoAnulacion
        End Get
        Set(value As String)
            _MotivoAnulacion = value
        End Set
    End Property

    Public Property ComportamientoCamborough As Boolean
        Get
            Return _ComportamientoCamborough
        End Get
        Set(value As Boolean)
            _ComportamientoCamborough = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    Public Property IdMotivoTransaccion As Integer
        Get
            Return _IdMotivoTransaccion
        End Get
        Set(value As Integer)
            _IdMotivoTransaccion = value
        End Set
    End Property

    Public Property Sexo As String
        Get
            Return _Sexo
        End Get
        Set(value As String)
            _Sexo = value
        End Set
    End Property

    Public Property IdControlFicha As Integer
        Get
            Return _IdControlFicha
        End Get
        Set(value As Integer)
            _IdControlFicha = value
        End Set
    End Property

    Public Property EnvioCamal As String
        Get
            Return _EnvioCamal
        End Get
        Set(value As String)
            _EnvioCamal = value
        End Set
    End Property

    Public Property ListaIdsControlFicha As String
        Get
            Return _ListaIdsControlFicha
        End Get
        Set(value As String)
            _ListaIdsControlFicha = value
        End Set
    End Property

    Public Property IdArea As Integer
        Get
            Return _IdArea
        End Get
        Set(value As Integer)
            _IdArea = value
        End Set
    End Property

    Public Property ChanchillaEngorde As Boolean
        Get
            Return _ChanchillaEngorde
        End Get
        Set(value As Boolean)
            _ChanchillaEngorde = value
        End Set
    End Property

    Public Property IdCampaña As Integer
        Get
            Return _IdCampaña
        End Get
        Set(value As Integer)
            _IdCampaña = value
        End Set
    End Property
End Class
