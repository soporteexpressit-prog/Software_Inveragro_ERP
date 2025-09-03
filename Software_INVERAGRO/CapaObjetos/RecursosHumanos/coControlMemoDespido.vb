Public Class coControlMemoDespido
    Private _Codigo As Integer
    Private _NumMemoDespido As Integer
    Private _NumDespido As Integer
    Private _FechaEmision As Date
    Private _IdMotivoMemoDespido As Integer
    Private _Nivel As String
    Private _Archivo As Byte()
    Private _IdUsuario As Integer
    Private _IdsTrabajador As String
    Private _Tipo As String
    Private _Coderror As Integer
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _NumRegistros As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property
    Public Property NumMemoDespido As Integer
        Get
            Return _NumMemoDespido
        End Get
        Set(value As Integer)
            _NumMemoDespido = value
        End Set
    End Property

    Public Property FechaEmision As Date
        Get
            Return _FechaEmision
        End Get
        Set(value As Date)
            _FechaEmision = value
        End Set
    End Property

    Public Property IdMotivoMemoDespido As Integer
        Get
            Return _IdMotivoMemoDespido
        End Get
        Set(value As Integer)
            _IdMotivoMemoDespido = value
        End Set
    End Property

    Public Property Nivel As String
        Get
            Return _Nivel
        End Get
        Set(value As String)
            _Nivel = value
        End Set
    End Property

    Public Property Archivo As Byte()
        Get
            Return _Archivo
        End Get
        Set(value As Byte())
            _Archivo = value
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

    Public Property IdsTrabajador As String
        Get
            Return _IdsTrabajador
        End Get
        Set(value As String)
            _IdsTrabajador = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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

    Public Property NumRegistros As Integer
        Get
            Return _NumRegistros
        End Get
        Set(value As Integer)
            _NumRegistros = value
        End Set
    End Property

    Public Sub SetArchivo(pdfData As Byte())
        Me.Archivo = pdfData
    End Sub
End Class
