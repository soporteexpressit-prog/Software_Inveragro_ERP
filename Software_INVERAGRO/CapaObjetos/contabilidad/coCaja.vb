Public Class coCaja
    Private _iduser As Integer
    Private _mi As Decimal
    Private _observacion As String
    Private _saldoanterior As Decimal
    Private _sueldominimo As Decimal
    Private _masvida As Decimal
    Private _asigfamiliar As Decimal
    Private _bonoagrario As Decimal
    Private _essalud As Decimal
    Private _montoeventual As Decimal
    Private _plantel1 As Decimal
    Private _plantel1monitoreo As Decimal
    Private _plantel2 As Decimal
    Private _plantel3 As Decimal
    Private _plantel4 As Decimal
    Private _plantel5 As Decimal
    Private _costomolino As Decimal
    Private _costomarrana As Decimal
    Private _idcaja As Integer
    Private _codreturn As Integer
    Private _msj As String

    Private _v1 As Integer
    Private _img As Byte()

    Public Property costomarrana As Decimal
        Get
            Return _costomarrana
        End Get
        Set(value As Decimal)
            _costomarrana = value
        End Set
    End Property
    Public Property costomolino As Decimal
        Get
            Return _costomolino
        End Get
        Set(value As Decimal)
            _costomolino = value
        End Set
    End Property
    Public Property plantel5 As Decimal
        Get
            Return _plantel5
        End Get
        Set(value As Decimal)
            _plantel5 = value
        End Set
    End Property
    Public Property plantel1 As Decimal
        Get
            Return _plantel1
        End Get
        Set(value As Decimal)
            _plantel1 = value
        End Set
    End Property
    Public Property plantel4 As Decimal
        Get
            Return _plantel4
        End Get
        Set(value As Decimal)
            _plantel4 = value
        End Set
    End Property
    Public Property plantel3 As Decimal
        Get
            Return _plantel3
        End Get
        Set(value As Decimal)
            _plantel3 = value
        End Set
    End Property
    Public Property plantel2 As Decimal
        Get
            Return _plantel2
        End Get
        Set(value As Decimal)
            _plantel2 = value
        End Set
    End Property
    Public Property plantel1monitoreo As Decimal
        Get
            Return _plantel1monitoreo
        End Get
        Set(value As Decimal)
            _plantel1monitoreo = value
        End Set
    End Property

    Private _idalcance3 As Integer
    Public Sub SetImg(pdfData As Byte())
        Me.Img = pdfData
    End Sub
    Public Property sueldominimo As Decimal
        Get
            Return _sueldominimo
        End Get
        Set(value As Decimal)
            _sueldominimo = value
        End Set
    End Property
    Public Property montoeventual As Decimal
        Get
            Return _montoeventual
        End Get
        Set(value As Decimal)
            _montoeventual = value
        End Set
    End Property
    Public Property masvida As Decimal
        Get
            Return _masvida
        End Get
        Set(value As Decimal)
            _masvida = value
        End Set
    End Property
    Public Property asigfamiliar As Decimal
        Get
            Return _asigfamiliar
        End Get
        Set(value As Decimal)
            _asigfamiliar = value
        End Set
    End Property
    Public Property bonoagrario As Decimal
        Get
            Return _bonoagrario
        End Get
        Set(value As Decimal)
            _bonoagrario = value
        End Set
    End Property
    Public Property essalud As Decimal
        Get
            Return _essalud
        End Get
        Set(value As Decimal)
            _essalud = value
        End Set
    End Property
    Public Property Mi As Decimal
        Get
            Return _mi
        End Get
        Set(value As Decimal)
            _mi = value
        End Set
    End Property

    Public Property Observacion As String
        Get
            Return _observacion
        End Get
        Set(value As String)
            _observacion = value
        End Set
    End Property

    Public Property Saldoanterior As Decimal
        Get
            Return _saldoanterior
        End Get
        Set(value As Decimal)
            _saldoanterior = value
        End Set
    End Property

    Public Property Codreturn As Integer
        Get
            Return _codreturn
        End Get
        Set(value As Integer)
            _codreturn = value
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

    Public Property Iduser As Integer
        Get
            Return _iduser
        End Get
        Set(value As Integer)
            _iduser = value
        End Set
    End Property

    Public Property Idcaja As Integer
        Get
            Return _idcaja
        End Get
        Set(value As Integer)
            _idcaja = value
        End Set
    End Property

    Public Property V1 As Integer
        Get
            Return _v1
        End Get
        Set(value As Integer)
            _v1 = value
        End Set
    End Property

    Public Property Img As Byte()
        Get
            Return _img
        End Get
        Set(value As Byte())
            _img = value
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
End Class
