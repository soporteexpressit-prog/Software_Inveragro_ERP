Public Class coIngreso
    Private _codigo As Integer
    Private _serie As String ' Agregado para el parámetro @serie
    Private _correlativo As String ' Agregado para el parámetro @correlativo
    Private _fEmision As Date ' Agregado para el parámetro @fEmision
    Private _fpedido As Date
    Private _total As Decimal ' MONEY se puede mapear a Decimal en VB.NET
    Private _igv As Decimal
    Private _flete As Decimal
    Private _fleteinterno As Decimal
    Private _observacion As String ' VARCHAR se mapeará a String en VB.NET
    Private _estado As String ' Agregado para el parámetro @estado
    Private _estadoRecepcion As String ' Agregado para el parámetro @estadoRecepcion
    Private _pagoanticipado As String ' Agregado para el parámetro @estadoRecepcion
    Private _iduser As Integer
    Private _idCondicionpago As Integer
    Private _valorServicio As Integer
    Private _idMotivoTransaccion As Integer ' Agregado para el parámetro @idMotivoTransaccion
    Private _frecepcion As Date? ' Se permite NULL, por lo que se usa un tipo Nullable (Date?)
    Private _idUbicacionOrigen As Integer? ' Se permite NULL, por lo que se usa un tipo Nullable (Integer?)
    Private _idUbicacionDestino As Integer? ' Se permite NULL, por lo que se usa un tipo Nullable (Integer?)
    Private _lista_items As String
    Private _ListaItemslotes As String
    Private _idmoneda As Integer
    Private _idtipodocumento As Integer
    Private _idproveedor As Integer
    Private _tipocambio As Decimal
    Private _idcotizacion As Integer
    Private _msj As String ' Salida (Output) en SQL también es String en VB.NET
    Private _coderror As Integer ' Salida (Output) en SQL también es Integer en VB.NET
    Private _NombreProducto As String
    Private _NombreProveedor As String
    Private _NumDocumentoRecepcion As String ' Agregado para el parámetro @numDocumento
    Private _ArchivoRecepcion As Byte() ' Agregado para el parámetro @archivo

    ' Variables adicionales según lo especificado
    Private _fechadesde As Nullable(Of Date)
    Private _fechahasta As Nullable(Of Date)
    Private _montoMinimo As Nullable(Of Decimal)
    Private _todo As Integer
    Private _lotizacion As Integer
    Private _conigv As String
    Private _motivoanulacion As String
    Private _numdocumentoguiatran As String
    Private _listafacturas As String


    Public Property listafacturas As String
        Get
            Return _listafacturas
        End Get
        Set(value As String)
            _listafacturas = value
        End Set
    End Property
    Public Property numdocumentoguiatran As String
        Get
            Return _numdocumentoguiatran
        End Get
        Set(value As String)
            _numdocumentoguiatran = value
        End Set
    End Property
    Public Property pagoanticipado As String
        Get
            Return _pagoanticipado
        End Get
        Set(value As String)
            _pagoanticipado = value
        End Set
    End Property
    Public Property valorServicio As Integer
        Get
            Return _valorServicio
        End Get
        Set(value As Integer)
            _valorServicio = value
        End Set
    End Property
    Public Property Codigo As Integer
        Get
            Return _codigo
        End Get
        Set(value As Integer)
            _codigo = value
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

    Public Property FEmision As Date
        Get
            Return _fEmision
        End Get
        Set(value As Date)
            _fEmision = value
        End Set
    End Property

    Public Property Fpedido As Date
        Get
            Return _fpedido
        End Get
        Set(value As Date)
            _fpedido = value
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

    Public Property Igv As Decimal
        Get
            Return _igv
        End Get
        Set(value As Decimal)
            _igv = value
        End Set
    End Property

    Public Property Flete As Decimal
        Get
            Return _flete
        End Get
        Set(value As Decimal)
            _flete = value
        End Set
    End Property
    Public Property Fleteinterno As Decimal
        Get
            Return _fleteinterno
        End Get
        Set(value As Decimal)
            _fleteinterno = value
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

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property EstadoRecepcion As String
        Get
            Return _estadoRecepcion
        End Get
        Set(value As String)
            _estadoRecepcion = value
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

    Public Property IdCondicionpago As Integer
        Get
            Return _idCondicionpago
        End Get
        Set(value As Integer)
            _idCondicionpago = value
        End Set
    End Property

    Public Property IdMotivoTransaccion As Integer
        Get
            Return _idMotivoTransaccion
        End Get
        Set(value As Integer)
            _idMotivoTransaccion = value
        End Set
    End Property

    Public Property Frecepcion As Date?
        Get
            Return _frecepcion
        End Get
        Set(value As Date?)
            _frecepcion = value
        End Set
    End Property

    Public Property IdUbicacionOrigen As Integer?
        Get
            Return _idUbicacionOrigen
        End Get
        Set(value As Integer?)
            _idUbicacionOrigen = value
        End Set
    End Property

    Public Property IdUbicacionDestino As Integer?
        Get
            Return _idUbicacionDestino
        End Get
        Set(value As Integer?)
            _idUbicacionDestino = value
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
    Public Property ListaItemslotes As String
        Get
            Return _ListaItemslotes
        End Get
        Set(value As String)
            _ListaItemslotes = value
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

    Public Property Coderror As Integer
        Get
            Return _coderror
        End Get
        Set(value As Integer)
            _coderror = value
        End Set
    End Property

    Public Property Fechadesde As Nullable(Of Date)
        Get
            Return _fechadesde
        End Get
        Set(value As Nullable(Of Date))
            _fechadesde = value
        End Set
    End Property

    Public Property Fechahasta As Nullable(Of Date)
        Get
            Return _fechahasta
        End Get
        Set(value As Nullable(Of Date))
            _fechahasta = value
        End Set
    End Property

    Public Property MontoMinimo As Nullable(Of Decimal)
        Get
            Return _montoMinimo
        End Get
        Set(value As Nullable(Of Decimal))
            _montoMinimo = value
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

    Public Property Idproveedor As Integer
        Get
            Return _idproveedor
        End Get
        Set(value As Integer)
            _idproveedor = value
        End Set
    End Property

    Public Property Todo As Integer
        Get
            Return _todo
        End Get
        Set(value As Integer)
            _todo = value
        End Set
    End Property
    Public Property lotizacion As Integer
        Get
            Return _lotizacion
        End Get
        Set(value As Integer)
            _lotizacion = value
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

    Public Property Idmoneda As Integer
        Get
            Return _idmoneda
        End Get
        Set(value As Integer)
            _idmoneda = value
        End Set
    End Property

    Public Property Idcotizacion As Integer
        Get
            Return _idcotizacion
        End Get
        Set(value As Integer)
            _idcotizacion = value
        End Set
    End Property

    Public Property NombreProducto As String
        Get
            Return _NombreProducto
        End Get
        Set(value As String)
            _NombreProducto = value
        End Set
    End Property

    Public Property NombreProveedor As String
        Get
            Return _NombreProveedor
        End Get
        Set(value As String)
            _NombreProveedor = value
        End Set
    End Property

    Public Property NumDocumentoRecepcion As String
        Get
            Return _NumDocumentoRecepcion
        End Get
        Set(value As String)
            _NumDocumentoRecepcion = value
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

    Public Property Motivoanulacion As String
        Get
            Return _motivoanulacion
        End Get
        Set(value As String)
            _motivoanulacion = value
        End Set
    End Property

    Public Property Conigv As String
        Get
            Return _conigv
        End Get
        Set(value As String)
            _conigv = value
        End Set
    End Property

    Public Sub SetArchivo(pdfData As Byte())
        Me.ArchivoRecepcion = pdfData
    End Sub
End Class
