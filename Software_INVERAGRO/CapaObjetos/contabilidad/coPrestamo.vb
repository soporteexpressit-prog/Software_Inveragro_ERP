Public Class coPrestamo
    ' Propiedades para el registro del préstamo
    Private _idprestamo As Integer
    Private _codReferencia As String
    Private _totalCuotas As Integer
    Private _importe As Decimal
    Private _fSolicitud As Date
    Private _fAprobacion As Date?
    Private _fCuota As Date
    Private _tasaInteres As Decimal
    Private _estadoPrestamo As String
    Private _comentario As String
    Private _idUsuario As String
    Private _idBanco As Integer
    Private _idCuentaBancoDestDepo As Integer
    Private _idTipoPrestamo As Integer
    Private _idSolicitante As Integer
    Private _idMoneda As Integer
    Private _tipoCambio As Decimal
    Private _lista_items As String

    ' Propiedades de salida
    Private _msj As String
    Private _coderror As Integer

    ' Propiedades Públicas para acceder a los campos
    Public Property CodReferencia As String
        Get
            Return _codReferencia
        End Get
        Set(value As String)
            _codReferencia = value
        End Set
    End Property

    Public Property TotalCuotas As Integer
        Get
            Return _totalCuotas
        End Get
        Set(value As Integer)
            _totalCuotas = value
        End Set
    End Property

    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(value As Decimal)
            _importe = value
        End Set
    End Property

    Public Property FSolicitud As Date
        Get
            Return _fSolicitud
        End Get
        Set(value As Date)
            _fSolicitud = value
        End Set
    End Property

    Public Property FAprobacion As Date?
        Get
            Return _fAprobacion
        End Get
        Set(value As Date?)
            _fAprobacion = value
        End Set
    End Property

    Public Property FCuota As Date
        Get
            Return _fCuota
        End Get
        Set(value As Date)
            _fCuota = value
        End Set
    End Property

    Public Property TasaInteres As Decimal
        Get
            Return _tasaInteres
        End Get
        Set(value As Decimal)
            _tasaInteres = value
        End Set
    End Property

    Public Property EstadoPrestamo As String
        Get
            Return _estadoPrestamo
        End Get
        Set(value As String)
            _estadoPrestamo = value
        End Set
    End Property

    Public Property Comentario As String
        Get
            Return _comentario
        End Get
        Set(value As String)
            _comentario = value
        End Set
    End Property

    Public Property IdUsuario As String
        Get
            Return _idUsuario
        End Get
        Set(value As String)
            _idUsuario = value
        End Set
    End Property

    Public Property IdBanco As Integer
        Get
            Return _idBanco
        End Get
        Set(value As Integer)
            _idBanco = value
        End Set
    End Property

    Public Property IdCuentaBancoDestDepo As Integer
        Get
            Return _idCuentaBancoDestDepo
        End Get
        Set(value As Integer)
            _idCuentaBancoDestDepo = value
        End Set
    End Property

    Public Property IdTipoPrestamo As Integer
        Get
            Return _idTipoPrestamo
        End Get
        Set(value As Integer)
            _idTipoPrestamo = value
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

    Public Property IdMoneda As Integer
        Get
            Return _idMoneda
        End Get
        Set(value As Integer)
            _idMoneda = value
        End Set
    End Property

    Public Property TipoCambio As Decimal
        Get
            Return _tipoCambio
        End Get
        Set(value As Decimal)
            _tipoCambio = value
        End Set
    End Property

    ' Propiedades de salida
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

    Public Property Idprestamo As Integer
        Get
            Return _idprestamo
        End Get
        Set(value As Integer)
            _idprestamo = value
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
End Class
