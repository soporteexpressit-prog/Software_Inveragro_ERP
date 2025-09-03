Public Class coCtaPagar
    Private _id As Integer
    Private _idpersona As Integer
    Private _fdesde As Date
    Private _fhasta As Date
    Private _estado As String
    Private _estadoliquidado As String
    Private _serie As String
    Private _correlativo As String
    Private _numdocreferencia As String
    Private _total As Decimal
    Private _fpago As Date
    Private _comentario As String
    Private _idusuario As Integer
    Private _idcuentapagar As Integer
    Private _idformapago As Integer
    Private _tipocambio As Decimal
    Private _idctabancoorigen As Integer
    Private _idctabancodestino As Integer
    Private _idtipodocumento As Integer
    Private _idmoneda As Integer
    Private _coderror As Integer
    Private _liquidado As Integer
    Private _motivoanulacion As String
    Private _listaidspagos As String
    Private _idcuota As Integer
    Private _idcuentabancotrabajador As Integer
    Private _iddestino As Integer
    Private _idactivo As Integer
    Private _idctacontable As Integer
    Private _observacion As String
    Private _detalle As String
    Private _cantidad As Decimal
    Private _precio As Decimal
    Private _idcondicionpago As Integer
    Private _fotopdf As Integer
    Private _ArchivoRecepcion As Byte()
    Private _IdBanco As Integer
    Private _Liquidadotransferencia As Integer
    Public Property Idpersona As Integer
        Get
            Return _idpersona
        End Get
        Set(value As Integer)
            _idpersona = value
        End Set
    End Property
    Public Property fotopdf As Integer
        Get
            Return _fotopdf
        End Get
        Set(value As Integer)
            _fotopdf = value
        End Set
    End Property
    Public Property Liquidadotransferencia As Integer
        Get
            Return _Liquidadotransferencia
        End Get
        Set(value As Integer)
            _Liquidadotransferencia = value
        End Set
    End Property

    Public Property Fdesde As Date
        Get
            Return _fdesde
        End Get
        Set(value As Date)
            _fdesde = value
        End Set
    End Property

    Public Property Fhasta As Date
        Get
            Return _fhasta
        End Get
        Set(value As Date)
            _fhasta = value
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
    Public Property estadoliquidado As String
        Get
            Return _estadoliquidado
        End Get
        Set(value As String)
            _estadoliquidado = value
        End Set
    End Property

    Public Property listaidspagos As String
        Get
            Return _listaidspagos
        End Get
        Set(value As String)
            _listaidspagos = value
        End Set
    End Property

    Public Property Serie As String
        Get
            Return _serie
        End Get
        Set(value As String)
            _serie = value
        End Set
    End Property

    Public Property Correlativo As String
        Get
            Return _correlativo
        End Get
        Set(value As String)
            _correlativo = value
        End Set
    End Property

    Public Property Numdocreferencia As String
        Get
            Return _numdocreferencia
        End Get
        Set(value As String)
            _numdocreferencia = value
        End Set
    End Property

    Public Property Total As Decimal
        Get
            Return _total
        End Get
        Set(value As Decimal)
            _total = value
        End Set
    End Property

    Public Property Fpago As Date
        Get
            Return _fpago
        End Get
        Set(value As Date)
            _fpago = value
        End Set
    End Property

    Public Property Comentario As String
        Get
            Return _comentario
        End Get
        Set(value As String)
            _comentario = value
        End Set
    End Property

    Public Property Idusuario As Integer
        Get
            Return _idusuario
        End Get
        Set(value As Integer)
            _idusuario = value
        End Set
    End Property

    Public Property Idcuentapagar As Integer
        Get
            Return _idcuentapagar
        End Get
        Set(value As Integer)
            _idcuentapagar = value
        End Set
    End Property

    Public Property Idformapago As Integer
        Get
            Return _idformapago
        End Get
        Set(value As Integer)
            _idformapago = value
        End Set
    End Property

    Public Property Tipocambio As Decimal
        Get
            Return _tipocambio
        End Get
        Set(value As Decimal)
            _tipocambio = value
        End Set
    End Property

    Public Property Idctabancoorigen As Integer
        Get
            Return _idctabancoorigen
        End Get
        Set(value As Integer)
            _idctabancoorigen = value
        End Set
    End Property
    Public Property idcuentabancotrabajador As Integer
        Get
            Return _idcuentabancotrabajador
        End Get
        Set(value As Integer)
            _idcuentabancotrabajador = value
        End Set
    End Property
    Public Property Idctabancodestino As Integer
        Get
            Return _idctabancodestino
        End Get
        Set(value As Integer)
            _idctabancodestino = value
        End Set
    End Property

    Public Property Idtipodocumento As Integer
        Get
            Return _idtipodocumento
        End Get
        Set(value As Integer)
            _idtipodocumento = value
        End Set
    End Property

    Public Property Idmoneda As Integer
        Get
            Return _idmoneda
        End Get
        Set(value As Integer)
            _idmoneda = value
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

    Public Property Motivoanulacion As String
        Get
            Return _motivoanulacion
        End Get
        Set(value As String)
            _motivoanulacion = value
        End Set
    End Property

    Public Property Idcuota As Integer
        Get
            Return _idcuota
        End Get
        Set(value As Integer)
            _idcuota = value
        End Set
    End Property

    Public Property Liquidado As Integer
        Get
            Return _liquidado
        End Get
        Set(value As Integer)
            _liquidado = value
        End Set
    End Property

    Public Property Iddestino As Integer
        Get
            Return _iddestino
        End Get
        Set(value As Integer)
            _iddestino = value
        End Set
    End Property

    Public Property Idactivo As Integer
        Get
            Return _idactivo
        End Get
        Set(value As Integer)
            _idactivo = value
        End Set
    End Property

    Public Property Idctacontable As Integer
        Get
            Return _idctacontable
        End Get
        Set(value As Integer)
            _idctacontable = value
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

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Detalle As String
        Get
            Return _detalle
        End Get
        Set(value As String)
            _detalle = value
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

    Public Property Precio As Decimal
        Get
            Return _precio
        End Get
        Set(value As Decimal)
            _precio = value
        End Set
    End Property

    Public Property Idcondicionpago As Integer
        Get
            Return _idcondicionpago
        End Get
        Set(value As Integer)
            _idcondicionpago = value
        End Set
    End Property

    Public Property ArchivoRecepcion As Byte()
        Get
            Return _ArchivoRecepcion
        End Get
        Set(value As Byte())
            _ArchivoRecepcion = value
        End Set
    End Property

    Public Sub SetArchivo(pdfData As Byte())
        Me.ArchivoRecepcion = pdfData
    End Sub

    Public Property IdBanco As Integer
        Get
            Return _IdBanco
        End Get
        Set(value As Integer)
            _IdBanco = value
        End Set
    End Property
End Class
