Public Class coControlBonificacionVehiculoNN
    Private _Codigo As Integer
    Private _NumPermiso As String
    Private _NumResolucion As String
    Private _FechaResolucion As Date
    Private _FechaInicio As Date
    Private _FechaFin As Date
    Private _PdfResolucion As Byte()
    Private _Estado As String
    Private _NumExpediente As String
    Private _FechaApertura As Date
    Private _PdfExpediente As Byte()
    Private _Iduser As Integer
    Private _IdActivo As Integer
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _Placa As String
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

    Public Property NumPermiso As String
        Get
            Return _NumPermiso
        End Get
        Set(value As String)
            _NumPermiso = value
        End Set
    End Property

    Public Property NumResolucion As String
        Get
            Return _NumResolucion
        End Get
        Set(value As String)
            _NumResolucion = value
        End Set
    End Property

    Public Property FechaResolucion As Date
        Get
            Return _FechaResolucion
        End Get
        Set(value As Date)
            _FechaResolucion = value
        End Set
    End Property

    Public Property FechaInicio As Date
        Get
            Return _FechaInicio
        End Get
        Set(value As Date)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFin As Date
        Get
            Return _FechaFin
        End Get
        Set(value As Date)
            _FechaFin = value
        End Set
    End Property

    Public Property PdfResolucion As Byte()
        Get
            Return _PdfResolucion
        End Get
        Set(value As Byte())
            _PdfResolucion = value
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

    Public Property NumExpediente As String
        Get
            Return _NumExpediente
        End Get
        Set(value As String)
            _NumExpediente = value
        End Set
    End Property

    Public Property FechaApertura As Date
        Get
            Return _FechaApertura
        End Get
        Set(value As Date)
            _FechaApertura = value
        End Set
    End Property

    Public Property PdfExpediente As Byte()
        Get
            Return _PdfExpediente
        End Get
        Set(value As Byte())
            _PdfExpediente = value
        End Set
    End Property

    Public Property Iduser As Integer
        Get
            Return _Iduser
        End Get
        Set(value As Integer)
            _Iduser = value
        End Set
    End Property

    Public Property IdActivo As Integer
        Get
            Return _IdActivo
        End Get
        Set(value As Integer)
            _IdActivo = value
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
            Return _FechaDesde
        End Get
        Set(value As Date?)
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date?
        Get
            Return _FechaHasta
        End Get
        Set(value As Date?)
            _FechaHasta = value
        End Set
    End Property

    Public Property Placa As String
        Get
            Return _Placa
        End Get
        Set(value As String)
            _Placa = value
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

    Public Sub SetArchivoResolucion(pdfData As Byte())
        Me.PdfResolucion = pdfData
    End Sub

    Public Sub SetArchivoExpediente(pdfData As Byte())
        Me.PdfExpediente = pdfData
    End Sub
End Class
