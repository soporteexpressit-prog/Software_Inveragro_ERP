Public Class coControlAlimento
    Private _Codigo As Integer
    Private _IdAlmacenPrincipal As Integer
    Private _IdAlmacenSolicitante As Integer
    Private _ListaAlimentos As String
    Private _ListaMedicamentos As String
    Private _FechaRecepcion As Date
    Private _idUsuario As Integer
    Private _Estado As String
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _fechaDesde As Nullable(Of Date)
    Private _fechaHasta As Nullable(Of Date)
    Private _Descripcion As String
    Private _IdRacion As Integer
    Private _IdUserAnulacion As Integer
    Private _MotivoAnulacion As String
    Private _ListaAlimentoPedir As String
    Private _ListaSalidaAlimento As String
    Private _IdsDetalleAlimento As String
    Private _ListaDestinadoGalponCorral As String
    Private _ListaAlimentoCerdo As String
    Private _idsdetallesalida As String
    Private _IdUbicacion As Integer
    Private _IdSalida As Integer
    Private _Tipo As String
    Private _TipoPremixero As String
    Private _IncluirEnNucleo As String
    Private _IdNutricionista As Integer
    Private _IdPeriodoMedicion As Integer
    Private _FechaPedido As Date
    Private _Observacion As String
    Private _IdPreparacionAlimento As Integer
    Private _IdGalpon As Integer
    Private _IdProducto As Integer
    Private _Cantidad As Decimal
    Private _FechaControl As Date
    Private _IdCampana As Integer
    Private _Anio As Integer
    Private _TipoAlimento As String
    Private _IdArea As Integer
    Private _IdLote As Integer
    Private _IdGrupo As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property IdAlmacenPrincipal As Integer
        Get
            Return _IdAlmacenPrincipal
        End Get
        Set(value As Integer)
            _IdAlmacenPrincipal = value
        End Set
    End Property

    Public Property IdAlmacenSolicitante As Integer
        Get
            Return _IdAlmacenSolicitante
        End Get
        Set(value As Integer)
            _IdAlmacenSolicitante = value
        End Set
    End Property

    Public Property ListaAlimentos As String
        Get
            Return _ListaAlimentos
        End Get
        Set(value As String)
            _ListaAlimentos = value
        End Set
    End Property
    Public Property idsdetallesalida As String
        Get
            Return _idsdetallesalida
        End Get
        Set(value As String)
            _idsdetallesalida = value
        End Set
    End Property

    Public Property ListaMedicamentos As String
        Get
            Return _ListaMedicamentos
        End Get
        Set(value As String)
            _ListaMedicamentos = value
        End Set
    End Property

    Public Property FechaRecepcion As Date
        Get
            Return _FechaRecepcion
        End Get
        Set(value As Date)
            _FechaRecepcion = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _idUsuario
        End Get
        Set(value As Integer)
            _idUsuario = value
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

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
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

    Public Property FechaDesde As Date?
        Get
            Return _fechaDesde
        End Get
        Set(value As Date?)
            _fechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date?
        Get
            Return _fechaHasta
        End Get
        Set(value As Date?)
            _fechaHasta = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
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

    Public Property IdUserAnulacion As Integer
        Get
            Return _IdUserAnulacion
        End Get
        Set(value As Integer)
            _IdUserAnulacion = value
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

    Public Property ListaAlimentoPedir As String
        Get
            Return _ListaAlimentoPedir
        End Get
        Set(value As String)
            _ListaAlimentoPedir = value
        End Set
    End Property

    Public Property ListaSalidaAlimento As String
        Get
            Return _ListaSalidaAlimento
        End Get
        Set(value As String)
            _ListaSalidaAlimento = value
        End Set
    End Property

    Public Property IdsDetalleAlimento As String
        Get
            Return _IdsDetalleAlimento
        End Get
        Set(value As String)
            _IdsDetalleAlimento = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property ListaDestinadoGalponCorral As String
        Get
            Return _ListaDestinadoGalponCorral
        End Get
        Set(value As String)
            _ListaDestinadoGalponCorral = value
        End Set
    End Property

    Public Property ListaAlimentoCerdo As String
        Get
            Return _ListaAlimentoCerdo
        End Get
        Set(value As String)
            _ListaAlimentoCerdo = value
        End Set
    End Property

    Public Property IdUbicacion As Integer
        Get
            Return _IdUbicacion
        End Get
        Set(value As Integer)
            _IdUbicacion = value
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

    Public Property TipoPremixero As String
        Get
            Return _TipoPremixero
        End Get
        Set(value As String)
            _TipoPremixero = value
        End Set
    End Property

    Public Property IncluirEnNucleo As String
        Get
            Return _IncluirEnNucleo
        End Get
        Set(value As String)
            _IncluirEnNucleo = value
        End Set
    End Property

    Public Property IdNutricionista As Integer
        Get
            Return _IdNutricionista
        End Get
        Set(value As Integer)
            _IdNutricionista = value
        End Set
    End Property

    Public Property IdPeriodoMedicion As Integer
        Get
            Return _IdPeriodoMedicion
        End Get
        Set(value As Integer)
            _IdPeriodoMedicion = value
        End Set
    End Property

    Public Property FechaPedido As Date
        Get
            Return _FechaPedido
        End Get
        Set(value As Date)
            _FechaPedido = value
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

    Public Property IdPreparacionAlimento As Integer
        Get
            Return _IdPreparacionAlimento
        End Get
        Set(value As Integer)
            _IdPreparacionAlimento = value
        End Set
    End Property

    Public Property IdGalpon As Integer
        Get
            Return _IdGalpon
        End Get
        Set(value As Integer)
            _IdGalpon = value
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

    Public Property Cantidad As Decimal
        Get
            Return _Cantidad
        End Get
        Set(value As Decimal)
            _Cantidad = value
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

    Public Property IdCampana As Integer
        Get
            Return _IdCampana
        End Get
        Set(value As Integer)
            _IdCampana = value
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

    Public Property TipoAlimento As String
        Get
            Return _TipoAlimento
        End Get
        Set(value As String)
            _TipoAlimento = value
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

    Public Property IdLote As Integer
        Get
            Return _IdLote
        End Get
        Set(value As Integer)
            _IdLote = value
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
End Class
