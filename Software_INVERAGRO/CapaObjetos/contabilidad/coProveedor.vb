Public Class coProveedor
    Private _Operacion As Integer
    Private _idPersona As Integer
    Private _Tipo As String
    Private _NumDocumento As String
    Private _Datos As String
    Private _Direccion As String
    Private _Celular As String
    Private _Correo As String
    Private _IdUsuario As String
    Private _FRegistro As Date
    Private _Estado As String
    Private _IdGiroEmpresa As Integer
    Private _IdTipoDocIdentidad As Integer
    Private _Coderror As Integer
    Private _IdDistrito As Integer

    Public Property IdDistrito As Integer
        Get
            Return _IdDistrito
        End Get
        Set(value As Integer)
            _IdDistrito = value
        End Set
    End Property
    Public Property IdPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
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

    Public Property NumDocumento As String
        Get
            Return _NumDocumento
        End Get
        Set(value As String)
            _NumDocumento = value
        End Set
    End Property

    Public Property Datos As String
        Get
            Return _Datos
        End Get
        Set(value As String)
            _Datos = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Celular As String
        Get
            Return _Celular
        End Get
        Set(value As String)
            _Celular = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
        End Set
    End Property
    Public Property IdUsuario As String
        Get
            Return _IdUsuario
        End Get
        Set(value As String)
            _IdUsuario = value
        End Set
    End Property

    Public Property FRegistro As Date
        Get
            Return _FRegistro
        End Get
        Set(value As Date)
            _FRegistro = value
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

    Public Property IdGiroEmpresa As Integer
        Get
            Return _IdGiroEmpresa
        End Get
        Set(value As Integer)
            _IdGiroEmpresa = value
        End Set
    End Property

    Public Property IdTipoDocIdentidad As Integer
        Get
            Return _IdTipoDocIdentidad
        End Get
        Set(value As Integer)
            _IdTipoDocIdentidad = value
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
End Class
