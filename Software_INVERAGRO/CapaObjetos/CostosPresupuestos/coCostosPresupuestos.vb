Public Class coCostosPresupuestos
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Fecha1 As Date
    Private _Fecha2 As Date
    Private _Operacion As Integer
    Private _Coderror As Integer

    Private _iduserreg As Integer
    Private _iduseraprovacion As Integer
    Private _iduseranulacion As Integer
    Private _motivoanulacion As String

    Private _idalcance3 As Integer
    Private _cantidad As Decimal
    Private _idproducto As Integer
    Private _data As String
    Private _fechappto As String
    Private _precio As Decimal
    Private _idalcance3_anterior As Integer
    Private _idproducto_anterior As Integer
    Private _msj As String
    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
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

    Public Property Fecha1 As Date
        Get
            Return _Fecha1
        End Get
        Set(value As Date)
            _Fecha1 = value
        End Set
    End Property

    Public Property Fecha2 As Date
        Get
            Return _Fecha2
        End Get
        Set(value As Date)
            _Fecha2 = value
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

    Public Property Iduserreg As Integer
        Get
            Return _iduserreg
        End Get
        Set(value As Integer)
            _iduserreg = value
        End Set
    End Property

    Public Property Iduseraprovacion As Integer
        Get
            Return _iduseraprovacion
        End Get
        Set(value As Integer)
            _iduseraprovacion = value
        End Set
    End Property

    Public Property Iduseranulacion As Integer
        Get
            Return _iduseranulacion
        End Get
        Set(value As Integer)
            _iduseranulacion = value
        End Set
    End Property

    Public Property Motivoanulacion As String
        Get
            Return _motivoanulacion
        End Get
        Set(value As String)
            _motivoanulacion = value
        End Set
    End Property

    Public Property Idalcance3 As Integer
        Get
            Return _idalcance3
        End Get
        Set(value As Integer)
            _idalcance3 = value
        End Set
    End Property

    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get
        Set(value As Decimal)
            _cantidad = value
        End Set
    End Property

    Public Property Idproducto As Integer
        Get
            Return _idproducto
        End Get
        Set(value As Integer)
            _idproducto = value
        End Set
    End Property

    Public Property Data As String
        Get
            Return _data
        End Get
        Set(value As String)
            _data = value
        End Set
    End Property

    Public Property Fechappto As String
        Get
            Return _fechappto
        End Get
        Set(value As String)
            _fechappto = value
        End Set
    End Property

    Public Property Idalcance3_anterior As Integer
        Get
            Return _idalcance3_anterior
        End Get
        Set(value As Integer)
            _idalcance3_anterior = value
        End Set
    End Property

    Public Property Precio As Decimal
        Get
            Return _precio
        End Get
        Set(value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property Idproducto_anterior As Integer
        Get
            Return _idproducto_anterior
        End Get
        Set(value As Integer)
            _idproducto_anterior = value
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
End Class
