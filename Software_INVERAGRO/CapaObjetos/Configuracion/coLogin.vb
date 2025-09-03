Public Class coLogin
    ' Propiedades privadas para almacenar la información de inicio de sesión
    Private _IdPersona As Integer
    Private _Usuario As String
    Private _TipoUsuario As String
    Private _DebeCambiarClave As Boolean
    Private _Nombre As String
    Private _Mensaje As String
    Private _clave As String
    Private _Coderror As String

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property

    Public Property clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property
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

    Public Property TipoUsuario As String
        Get
            Return _TipoUsuario
        End Get
        Set(value As String)
            _TipoUsuario = value
        End Set
    End Property

    Public Property DebeCambiarClave As Boolean
        Get
            Return _DebeCambiarClave
        End Get
        Set(value As Boolean)
            _DebeCambiarClave = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
        End Set
    End Property
End Class