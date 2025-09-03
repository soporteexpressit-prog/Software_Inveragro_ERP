Public Class coMedicamentoRacion
    Private _Codigo As Integer
    Private _FechaInicio As Nullable(Of Date)
    Private _FechaFin As Nullable(Of Date)
    Private _IdRacion As Integer
    Private _IdUbicacion As Integer
    Private _Estado As String
    Private _IdUsuario As Integer
    Private _ListaMedicamentos As String
    Private _Tipo As String
    Private _Nota As String
    Private _Coderror As Integer
    Private _TipoPremixero As String
    Private _IncluirEnNucleo As String

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property FechaInicio As Nullable(Of Date)
        Get
            Return _FechaInicio
        End Get
        Set(value As Nullable(Of Date))
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFin As Nullable(Of Date)
        Get
            Return _FechaFin
        End Get
        Set(value As Nullable(Of Date))
            _FechaFin = value
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

    Public Property IdUbicacion As Integer
        Get
            Return _IdUbicacion
        End Get
        Set(value As Integer)
            _IdUbicacion = value
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

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
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

    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Nota As String
        Get
            Return _Nota
        End Get
        Set(value As String)
            _Nota = value
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
End Class
