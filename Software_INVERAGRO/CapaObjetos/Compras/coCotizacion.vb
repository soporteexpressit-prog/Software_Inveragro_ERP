Public Class coCotizacion
    Private _codigo As Integer
    Private _fpedido As Date
    Private _total As Decimal ' MONEY se puede mapear a Decimal en VB.NET
    Private _igv As Decimal
    Private _flete As Decimal
    Private _observacion As String ' VARCHAR se mapeará a String en VB.NET
    Private _estado As String
    Private _tipo As String
    Private _iduser As Integer
    Private _idUbicacionOrigen As Integer
    Private _idUbicacionDestino As Integer
    Private _idCondicionpago As Integer
    Private _idTipoDocumento As Integer
    Private _idSolicitante As Integer
    Private _idDestino As Integer
    Private _idTipoCambio As Integer
    Private _msj As String ' Salida (Output) en SQL también es String en VB.NET
    Private _coderror As Integer ' Salida (Output) en SQL también es Integer en VB.NET
    Private _lista_items As String

    Private _fechadesde As Date
    Private _fechahasta As Date
    Public Property Codigo As Integer
        Get
            Return _codigo
        End Get
        Set(value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property Fpedido As Date
        Get
            Return _fpedido
        End Get
        Set(value As Date)
            _fpedido = value
        End Set
    End Property

    Public Property Total As Decimal
        Get
            Return _total
        End Get
        Set(value As Decimal)
            _total = value
        End Set
    End Property

    Public Property Igv As Decimal
        Get
            Return _igv
        End Get
        Set(value As Decimal)
            _igv = value
        End Set
    End Property

    Public Property Flete As Decimal
        Get
            Return _flete
        End Get
        Set(value As Decimal)
            _flete = value
        End Set
    End Property

    Public Property Observacion As String
        Get
            Return _observacion
        End Get
        Set(value As String)
            _observacion = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property Iduser As Integer
        Get
            Return _iduser
        End Get
        Set(value As Integer)
            _iduser = value
        End Set
    End Property

    Public Property IdUbicacionOrigen As Integer
        Get
            Return _idUbicacionOrigen
        End Get
        Set(value As Integer)
            _idUbicacionOrigen = value
        End Set
    End Property

    Public Property IdUbicacionDestino As Integer
        Get
            Return _idUbicacionDestino
        End Get
        Set(value As Integer)
            _idUbicacionDestino = value
        End Set
    End Property

    Public Property IdCondicionpago As Integer
        Get
            Return _idCondicionpago
        End Get
        Set(value As Integer)
            _idCondicionpago = value
        End Set
    End Property

    Public Property IdTipoDocumento As Integer
        Get
            Return _idTipoDocumento
        End Get
        Set(value As Integer)
            _idTipoDocumento = value
        End Set
    End Property

    Public Property IdSolicitante As Integer
        Get
            Return _idSolicitante
        End Get
        Set(value As Integer)
            _idSolicitante = value
        End Set
    End Property

    Public Property IdDestino As Integer
        Get
            Return _idDestino
        End Get
        Set(value As Integer)
            _idDestino = value
        End Set
    End Property

    Public Property IdTipoCambio As Integer
        Get
            Return _idTipoCambio
        End Get
        Set(value As Integer)
            _idTipoCambio = value
        End Set
    End Property

    Public Property Msj As String
        Get
            Return _msj
        End Get
        Set(value As String)
            _msj = value
        End Set
    End Property

    Public Property Coderror As Integer
        Get
            Return _coderror
        End Get
        Set(value As Integer)
            _coderror = value
        End Set
    End Property

    Public Property Lista_items As String
        Get
            Return _lista_items
        End Get
        Set(value As String)
            _lista_items = value
        End Set
    End Property

    Public Property Fechadesde As Date
        Get
            Return _fechadesde
        End Get
        Set(value As Date)
            _fechadesde = value
        End Set
    End Property

    Public Property Fechahasta As Date
        Get
            Return _fechahasta
        End Get
        Set(value As Date)
            _fechahasta = value
        End Set
    End Property
End Class
