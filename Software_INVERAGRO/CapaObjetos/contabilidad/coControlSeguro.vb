Public Class coControlSeguro
    Private _codigo As Integer
    Private _numDocumento As String
    Private _numContratoSalud As String
    Private _fechaEmision As Date
    Private _fechaInicio As Date
    Private _fechaFin As Date
    Private _archivo As Byte()
    Private _idTipoSeguro As Integer
    Private _idProveedorSeguro As Integer
    Private _Operacion As Integer
    Private _coderror As Integer
    Private _idUser As Integer
    Private _estado As String
    Private _lista_items As String
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _MotivoAnulacion As String
    Private _idUsuarioAnulacion As Integer
    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property NumDocumento As String
        Get
            Return _numDocumento
        End Get
        Set(value As String)
            _numDocumento = value
        End Set
    End Property

    Public Property NumContratoSalud As String
        Get
            Return _numContratoSalud
        End Get
        Set(value As String)
            _numContratoSalud = value
        End Set
    End Property

    Public Property FechaEmision As Date
        Get
            Return _fechaEmision
        End Get
        Set(value As Date)
            _fechaEmision = value
        End Set
    End Property

    Public Property FechaInicio As Date
        Get
            Return _fechaInicio
        End Get
        Set(value As Date)
            _fechaInicio = value
        End Set
    End Property

    Public Property FechaFin As Date
        Get
            Return _fechaFin
        End Get
        Set(value As Date)
            _fechaFin = value
        End Set
    End Property

    Public Property Archivo As Byte()
        Get
            Return _archivo
        End Get
        Set(value As Byte())
            _archivo = value
        End Set
    End Property

    Public Property IdTipoSeguro As Integer
        Get
            Return _idTipoSeguro
        End Get
        Set(value As Integer)
            _idTipoSeguro = value
        End Set
    End Property

    Public Property IdProveedorSeguro As Integer
        Get
            Return _idProveedorSeguro
        End Get
        Set(value As Integer)
            _idProveedorSeguro = value
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
            Return _coderror
        End Get
        Set(value As Integer)
            _coderror = value
        End Set
    End Property

    Public Property IdUser As Integer
        Get
            Return _idUser
        End Get
        Set(value As Integer)
            _idUser = value
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

    Public Property Lista_items As String
        Get
            Return _lista_items
        End Get
        Set(value As String)
            _lista_items = value
        End Set
    End Property

    Public Property FechaDesde As Nullable(Of Date)
        Get
            Return _FechaDesde
        End Get
        Set(value As Nullable(Of Date))
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Nullable(Of Date)
        Get
            Return _FechaHasta
        End Get
        Set(value As Nullable(Of Date))
            _FechaHasta = value
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

    Public Property IdUsuarioAnulacion As Integer
        Get
            Return _idUsuarioAnulacion
        End Get
        Set(value As Integer)
            _idUsuarioAnulacion = value
        End Set
    End Property

    Public Sub SetArchivo(pdfData As Byte())
        Me.Archivo = pdfData
    End Sub
End Class
