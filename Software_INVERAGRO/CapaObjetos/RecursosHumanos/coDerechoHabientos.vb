Public Class coDerechoHabiento
    Private _idPersonaHijo As Integer
    Private _numDocumentoHijo As String
    Private _mesConcepcion As DateTime
    Private _fNacimientoHijo As DateTime
    Private _sexoHijo As String
    Private _idTipoDocIdentidadHijo As Integer
    Private _nombresHijo As String
    Private _apellidoPaternoHijo As String
    Private _apellidoMaternoHijo As String
    Private _idVinculoFamiliar As Integer
    Private _idTipoDocVinculante As Integer
    Private _nroDocVinculante As String
    Private _documentoHijo As Byte()
    Private _idPersona As Integer
    Private _Coderror As Integer
    Private _fbaja As DateTime
    Private _idmotivobaja As Integer
    Public Property idmotivobaja As Integer
        Get
            Return _idmotivobaja
        End Get
        Set(value As Integer)
            _idmotivobaja = value
        End Set
    End Property
    Public Property fbaja As DateTime
        Get
            Return _fbaja
        End Get
        Set(value As DateTime)
            _fbaja = value
        End Set
    End Property
    Public Property idPersonaHijo As Integer
        Get
            Return _idPersonaHijo
        End Get
        Set(value As Integer)
            _idPersonaHijo = value
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
    Public Property numDocumentoHijo As String
        Get
            Return _numDocumentoHijo
        End Get
        Set(value As String)
            _numDocumentoHijo = value
        End Set
    End Property

    Public Property mesConcepcion As DateTime
        Get
            Return _mesConcepcion
        End Get
        Set(value As DateTime)
            _mesConcepcion = value
        End Set
    End Property

    Public Property fNacimientoHijo As DateTime
        Get
            Return _fNacimientoHijo
        End Get
        Set(value As DateTime)
            _fNacimientoHijo = value
        End Set
    End Property

    Public Property sexoHijo As String
        Get
            Return _sexoHijo
        End Get
        Set(value As String)
            _sexoHijo = value
        End Set
    End Property

    Public Property idTipoDocIdentidadHijo As Integer
        Get
            Return _idTipoDocIdentidadHijo
        End Get
        Set(value As Integer)
            _idTipoDocIdentidadHijo = value
        End Set
    End Property

    Public Property nombresHijo As String
        Get
            Return _nombresHijo
        End Get
        Set(value As String)
            _nombresHijo = value
        End Set
    End Property

    Public Property apellidoPaternoHijo As String
        Get
            Return _apellidoPaternoHijo
        End Get
        Set(value As String)
            _apellidoPaternoHijo = value
        End Set
    End Property

    Public Property apellidoMaternoHijo As String
        Get
            Return _apellidoMaternoHijo
        End Get
        Set(value As String)
            _apellidoMaternoHijo = value
        End Set
    End Property

    Public Property idVinculoFamiliar As Integer
        Get
            Return _idVinculoFamiliar
        End Get
        Set(value As Integer)
            _idVinculoFamiliar = value
        End Set
    End Property

    Public Property idTipoDocVinculante As Integer
        Get
            Return _idTipoDocVinculante
        End Get
        Set(value As Integer)
            _idTipoDocVinculante = value
        End Set
    End Property

    Public Property nroDocVinculante As String
        Get
            Return _nroDocVinculante
        End Get
        Set(value As String)
            _nroDocVinculante = value
        End Set
    End Property

    Public Property documentoHijo As Byte()
        Get
            Return _documentoHijo
        End Get
        Set(value As Byte())
            _documentoHijo = value
        End Set
    End Property
    Public Sub Setdochijo(pdfData As Byte())
        Me.documentoHijo = pdfData
    End Sub
    Public Property idPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
        End Set
    End Property
End Class
