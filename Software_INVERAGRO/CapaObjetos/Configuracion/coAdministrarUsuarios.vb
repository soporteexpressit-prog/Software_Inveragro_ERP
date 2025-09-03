Public Class coAdministrarUsuarios
    Private _IdPersona As Integer
    Private _Usuario As String
    Private _NombreCompleto As String
    Private _Tipo As String
    Private _Estado As String
    Private _IdSubModuloNivel1 As Integer
    Private _IdSubModuloNivel2 As Nullable(Of Integer)
    Private _IdModulo As Integer

    Private _IdPerfil As Integer
    Private _Rol As String

    Private _Lista_Permisos As String
    Private _Lista_Personas As String
    Private _Coderror As Integer
    Private _Operacion As Integer

    Public Property IdPersona As Integer
        Get
            Return _IdPersona
        End Get
        Set(value As Integer)
            _IdPersona = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property NombreCompleto As String
        Get
            Return _NombreCompleto
        End Get
        Set(value As String)
            _NombreCompleto = value
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

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    Public Property IdSubModuloNivel1 As Integer
        Get
            Return _IdSubModuloNivel1
        End Get
        Set(value As Integer)
            _IdSubModuloNivel1 = value
        End Set
    End Property

    Public Property IdSubModuloNivel2 As Nullable(Of Integer)
        Get
            Return _IdSubModuloNivel2
        End Get
        Set(value As Nullable(Of Integer))
            _IdSubModuloNivel2 = value
        End Set
    End Property

    Public Property IdModulo As Integer
        Get
            Return _IdModulo
        End Get
        Set(value As Integer)
            _IdModulo = value
        End Set
    End Property

    Public Property IdPerfil As Integer
        Get
            Return _IdPerfil
        End Get
        Set(value As Integer)
            _IdPerfil = value
        End Set
    End Property

    Public Property Rol As String
        Get
            Return _Rol
        End Get
        Set(value As String)
            _Rol = value
        End Set
    End Property

    Public Property Lista_Permisos As String
        Get
            Return _Lista_Permisos
        End Get
        Set(value As String)
            _Lista_Permisos = value
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

    Public Property Lista_Personas As String
        Get
            Return _Lista_Personas
        End Get
        Set(value As String)
            _Lista_Personas = value
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
End Class
