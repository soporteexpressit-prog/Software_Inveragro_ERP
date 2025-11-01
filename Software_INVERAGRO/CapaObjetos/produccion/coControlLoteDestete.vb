Public Class coControlLoteDestete
    Private _Operacion As Integer
    Private _NumeroLote As Integer
    Private _Estado As String
    Private _IdControlFicha As Integer
    Private _IdRegularizarCerdo As Integer
    Private _IdLote As Integer
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _Anio As Integer
    Private _IdJaulaCorral As Integer
    Private _ListaItems As String
    Private _ListaIdsCorralCantidad As String
    Private _ListaIdsCerdosRegistrados As String
    Private _ListaCriasRegistrar As String
    Private _ListaIdsControlParto As String
    Private _ListaCerdoDescarte As String
    Private _IdPlantel As Integer
    Private _CantidadAnimalesNoRegistradas As Integer
    Private _CantidadTatuadas As Integer
    Private _CantidadVenta As Integer
    Private _CantidadPuras As Integer
    Private _CantidadMeishan As Integer
    Private _Observacion As String
    Private _PesoTotal As Double
    Private _PesoPromedio As Double
    Private _TipoBajada As String
    Private _IdPlantelSalida As Integer
    Private _IdPlantelLlegada As Integer
    Private _IdConductor As Integer
    Private _IdTransporte As Integer
    Private _IdControlFichaMortalidad As Integer
    Private _IdUsuario As Integer
    Private _TipoFiltro As String
    Private _NumDepuracion As Integer
    Private _Coderror As Integer
    Private _EnvioTotal As String
    Private _ListaDatosDestete As String
    Private _IdAnimal As Integer
    Private _IdJaulaCorralEmbarcadero As Integer
    Private _EsBajada As String
    Private _EsRetorno As String
    Private _FechaControl As Date
    Private _idMovimientoBajada As Integer
    Private _EdadLote As Integer
    Private _ListaIdsLotes As String
    Private _IdCampana As Integer
    Private _IdSalida As Integer
    Private _Mes As Integer
    Private _Semana As Integer
    Private _Meta As Integer
    Private _IdGrupo As Integer
    Private _IdRacion As Integer
    Private _Objetivo As Decimal
    Private _PesoDestete As Decimal
    Private _Ca As Decimal
    Private _PresentacionSacos As Decimal
    Private _EsChanchilla As Boolean

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
        End Set
    End Property

    Public Property NumeroLote As Integer
        Get
            Return _NumeroLote
        End Get
        Set(value As Integer)
            _NumeroLote = value
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

    Public Property IdControlFicha As Integer
        Get
            Return _IdControlFicha
        End Get
        Set(value As Integer)
            _IdControlFicha = value
        End Set
    End Property

    Public Property IdRegularizarCerdo As Integer
        Get
            Return _IdRegularizarCerdo
        End Get
        Set(value As Integer)
            _IdRegularizarCerdo = value
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

    Public Property IdJaulaCorral As Integer
        Get
            Return _IdJaulaCorral
        End Get
        Set(value As Integer)
            _IdJaulaCorral = value
        End Set
    End Property

    Public Property ListaItems As String
        Get
            Return _ListaItems
        End Get
        Set(value As String)
            _ListaItems = value
        End Set
    End Property

    Public Property ListaIdsCorralCantidad As String
        Get
            Return _ListaIdsCorralCantidad
        End Get
        Set(value As String)
            _ListaIdsCorralCantidad = value
        End Set
    End Property

    Public Property ListaIdsCerdosRegistrados As String
        Get
            Return _ListaIdsCerdosRegistrados
        End Get
        Set(value As String)
            _ListaIdsCerdosRegistrados = value
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

    Public Property ListaIdsControlParto As String
        Get
            Return _ListaIdsControlParto
        End Get
        Set(value As String)
            _ListaIdsControlParto = value
        End Set
    End Property

    Public Property ListaCerdoDescarte As String
        Get
            Return _ListaCerdoDescarte
        End Get
        Set(value As String)
            _ListaCerdoDescarte = value
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

    Public Property CantidadAnimalesNoRegistradas As Integer
        Get
            Return _CantidadAnimalesNoRegistradas
        End Get
        Set(value As Integer)
            _CantidadAnimalesNoRegistradas = value
        End Set
    End Property

    Public Property CantidadTatuadas As Integer
        Get
            Return _CantidadTatuadas
        End Get
        Set(value As Integer)
            _CantidadTatuadas = value
        End Set
    End Property

    Public Property CantidadVenta As Integer
        Get
            Return _CantidadVenta
        End Get
        Set(value As Integer)
            _CantidadVenta = value
        End Set
    End Property

    Public Property CantidadPuras As Integer
        Get
            Return _CantidadPuras
        End Get
        Set(value As Integer)
            _CantidadPuras = value
        End Set
    End Property

    Public Property CantidadMeishan As Integer
        Get
            Return _CantidadMeishan
        End Get
        Set(value As Integer)
            _CantidadMeishan = value
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

    Public Property PesoTotal As Double
        Get
            Return _PesoTotal
        End Get
        Set(value As Double)
            _PesoTotal = value
        End Set
    End Property

    Public Property PesoPromedio As Double
        Get
            Return _PesoPromedio
        End Get
        Set(value As Double)
            _PesoPromedio = value
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

    Public Property TipoBajada As String
        Get
            Return _TipoBajada
        End Get
        Set(value As String)
            _TipoBajada = value
        End Set
    End Property

    Public Property IdPlantelSalida As Integer
        Get
            Return _IdPlantelSalida
        End Get
        Set(value As Integer)
            _IdPlantelSalida = value
        End Set
    End Property

    Public Property IdPlantelLlegada As Integer
        Get
            Return _IdPlantelLlegada
        End Get
        Set(value As Integer)
            _IdPlantelLlegada = value
        End Set
    End Property

    Public Property IdConductor As Integer
        Get
            Return _IdConductor
        End Get
        Set(value As Integer)
            _IdConductor = value
        End Set
    End Property

    Public Property IdTransporte As Integer
        Get
            Return _IdTransporte
        End Get
        Set(value As Integer)
            _IdTransporte = value
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

    Public Property FechaDesde As Date
        Get
            Return _FechaDesde
        End Get
        Set(value As Date)
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date
        Get
            Return _FechaHasta
        End Get
        Set(value As Date)
            _FechaHasta = value
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

    Public Property NumDepuracion As Integer
        Get
            Return _NumDepuracion
        End Get
        Set(value As Integer)
            _NumDepuracion = value
        End Set
    End Property

    Public Property EnvioTotal As String
        Get
            Return _EnvioTotal
        End Get
        Set(value As String)
            _EnvioTotal = value
        End Set
    End Property

    Public Property TipoFiltro As String
        Get
            Return _TipoFiltro
        End Get
        Set(value As String)
            _TipoFiltro = value
        End Set
    End Property

    Public Property ListaDatosDestete As String
        Get
            Return _ListaDatosDestete
        End Get
        Set(value As String)
            _ListaDatosDestete = value
        End Set
    End Property

    Public Property IdAnimal As Integer
        Get
            Return _IdAnimal
        End Get
        Set(value As Integer)
            _IdAnimal = value
        End Set
    End Property

    Public Property IdJaulaCorralEmbarcadero As Integer
        Get
            Return _IdJaulaCorralEmbarcadero
        End Get
        Set(value As Integer)
            _IdJaulaCorralEmbarcadero = value
        End Set
    End Property

    Public Property EsBajada As String
        Get
            Return _EsBajada
        End Get
        Set(value As String)
            _EsBajada = value
        End Set
    End Property

    Public Property EsRetorno As String
        Get
            Return _EsRetorno
        End Get
        Set(value As String)
            _EsRetorno = value
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

    Public Property IdMovimientoBajada As Integer
        Get
            Return _idMovimientoBajada
        End Get
        Set(value As Integer)
            _idMovimientoBajada = value
        End Set
    End Property

    Public Property EdadLote As Integer
        Get
            Return _EdadLote
        End Get
        Set(value As Integer)
            _EdadLote = value
        End Set
    End Property

    Public Property ListaIdsLotes As String
        Get
            Return _ListaIdsLotes
        End Get
        Set(value As String)
            _ListaIdsLotes = value
        End Set
    End Property

    Public Property IdCampana As Integer
        Get
            Return _IdCampana
        End Get
        Set(value As Integer)
            _IdCampana = value
        End Set
    End Property

    Public Property IdSalida As Integer
        Get
            Return _IdSalida
        End Get
        Set(value As Integer)
            _IdSalida = value
        End Set
    End Property

    Public Property Mes As Integer
        Get
            Return _Mes
        End Get
        Set(value As Integer)
            _Mes = value
        End Set
    End Property

    Public Property Semana As Integer
        Get
            Return _Semana
        End Get
        Set(value As Integer)
            _Semana = value
        End Set
    End Property

    Public Property Meta As Integer
        Get
            Return _Meta
        End Get
        Set(value As Integer)
            _Meta = value
        End Set
    End Property

    Public Property IdGrupo As Integer
        Get
            Return _IdGrupo
        End Get
        Set(value As Integer)
            _IdGrupo = value
        End Set
    End Property

    Public Property IdRacion As Integer
        Get
            Return _IdRacion
        End Get
        Set(value As Integer)
            _IdRacion = value
        End Set
    End Property

    Public Property Objetivo As Decimal
        Get
            Return _Objetivo
        End Get
        Set(value As Decimal)
            _Objetivo = value
        End Set
    End Property

    Public Property PesoDestete As Decimal
        Get
            Return _PesoDestete
        End Get
        Set(value As Decimal)
            _PesoDestete = value
        End Set
    End Property

    Public Property Ca As Decimal
        Get
            Return _Ca
        End Get
        Set(value As Decimal)
            _Ca = value
        End Set
    End Property

    Public Property PresentacionSacos As Decimal
        Get
            Return _PresentacionSacos
        End Get
        Set(value As Decimal)
            _PresentacionSacos = value
        End Set
    End Property

    Public Property EsChanchilla As Boolean
        Get
            Return _EsChanchilla
        End Get
        Set(value As Boolean)
            _EsChanchilla = value
        End Set
    End Property
End Class
