Public Class coVentas
    Private _idplantel As Integer
    Private _idproducto As Integer
    Private _cantidad As Decimal
    Private _operacion As Integer
    Private _codigo As Integer
    Private _serie As String ' Agregado para el parámetro @serie
    Private _correlativo As String ' Agregado para el parámetro @correlativo
    Private _fEmision As Date ' Agregado para el parámetro @fEmision
    Private _fpedido As Date
    Private _total As Decimal ' MONEY se puede mapear a Decimal en VB.NET
    Private _igv As Decimal
    Private _flete As Decimal
    Private _Fleteinterno As Decimal
    Private _observacion As String ' VARCHAR se mapeará a String en VB.NET
    Private _estado As String ' Agregado para el parámetro @estado
    Private _estadoRecepcion As String ' Agregado para el parámetro @estadoRecepcion
    Private _iduser As Integer
    Private _idCondicionpago As Integer
    Private _idMotivoTransaccion As Integer ' Agregado para el parámetro @idMotivoTransaccion
    Private _frecepcion As Date? ' Se permite NULL, por lo que se usa un tipo Nullable (Date?)
    Private _idUbicacionOrigen As Integer? ' Se permite NULL, por lo que se usa un tipo Nullable (Integer?)
    Private _idUbicacionDestino As Integer? ' Se permite NULL, por lo que se usa un tipo Nullable (Integer?)
    Private _lista_items As String
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
    Private _tipoprecio As String
    ' Variables adicionales según lo especificado
    Private _fechadesde As Nullable(Of Date)
    Private _fechahasta As Nullable(Of Date)
    Private _montoMinimo As Nullable(Of Decimal)
    Private _todo As Integer
    Private _codigosenasa As String
    Private _motivoanulacion As String

    Private _puntopartida As String
    Private _puntollegada As String
    Private _pesobrudo As Nullable(Of Decimal)
    Private _Idtransportista As Nullable(Of Integer)
    Private _placa As String
    Private _Idcotizacionlista As String
    Private _codigolista As String
    Private _Idconductor As Nullable(Of Integer)
    Private _horometro_incial As Integer
    Private _horometro_final As Integer
    Private _idguia As Integer
    Private _pesobalanza As Decimal
    Private _idordencompra As Integer
    Private _Cantidadsacos As Integer
    Private _idtipopeso As Integer
    Private _pesodescontado As Integer
    Private _checkselecionado As Integer
    Private _idarea As Integer
    Private _idgalpon As Integer
    Private _odometro_inicial As Integer
    Private _entregadirecta As Integer
    Private _precio As Decimal
    Private _Precioalimento As Decimal
    Private _NombreCliente As String
    Private _conigv As String
    Private _peso_promediofinal As Decimal
    Private _Semana As String
    Private _TipoFiltro As Integer
    Private _anio As Integer
    Private _checkcampaña As Integer
    Public Property checkcampaña As Integer
        Get
            Return _checkcampaña
        End Get
        Set(value As Integer)
            _checkcampaña = value
        End Set
    End Property
    Public Property anio As Integer
        Get
            Return _anio
        End Get
        Set(value As Integer)
            _anio = value
        End Set
    End Property
    Public Property entregadirecta As Integer
        Get
            Return _entregadirecta
        End Get
        Set(value As Integer)
            _entregadirecta = value
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
    Public Property pesodescontado As Integer
        Get
            Return _pesodescontado
        End Get
        Set(value As Integer)
            _pesodescontado = value
        End Set
    End Property
    Public Property idgalpon As Integer
        Get
            Return _idgalpon
        End Get
        Set(value As Integer)
            _idgalpon = value
        End Set
    End Property
    Public Property idarea As Integer
        Get
            Return _idarea
        End Get
        Set(value As Integer)
            _idarea = value
        End Set
    End Property
    Public Property odometro_inicial As Integer
        Get
            Return _odometro_inicial
        End Get
        Set(value As Integer)
            _odometro_inicial = value
        End Set
    End Property
    Public Property checkselecionado As Integer
        Get
            Return _checkselecionado
        End Get
        Set(value As Integer)
            _checkselecionado = value
        End Set
    End Property

    Public Property conigv As String
        Get
            Return _conigv
        End Get
        Set(value As String)
            _conigv = value
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
    Public Property Idcotizacionlista As String
        Get
            Return _Idcotizacionlista
        End Get
        Set(value As String)
            _Idcotizacionlista = value
        End Set
    End Property
    Public Property codigolista As String
        Get
            Return _codigolista
        End Get
        Set(value As String)
            _codigolista = value
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

    Public Property Fleteinterno As Decimal
        Get
            Return _Fleteinterno
        End Get
        Set(value As Decimal)
            _Fleteinterno = value
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

    Public Property Puntopartida As String
        Get
            Return _puntopartida
        End Get
        Set(value As String)
            _puntopartida = value
        End Set
    End Property

    Public Property Puntollegada As String
        Get
            Return _puntollegada
        End Get
        Set(value As String)
            _puntollegada = value
        End Set
    End Property


    Public Property Placa As String
        Get
            Return _placa
        End Get
        Set(value As String)
            _placa = value
        End Set
    End Property

    Public Property Idconductor As Integer?
        Get
            Return _Idconductor
        End Get
        Set(value As Integer?)
            _Idconductor = value
        End Set
    End Property

    Public Property Pesobrudo As Decimal?
        Get
            Return _pesobrudo
        End Get
        Set(value As Decimal?)
            _pesobrudo = value
        End Set
    End Property

    Public Property Idtransportista As Integer?
        Get
            Return _Idtransportista
        End Get
        Set(value As Integer?)
            _Idtransportista = value
        End Set
    End Property

    Public Property Horometro_incial As Integer
        Get
            Return _horometro_incial
        End Get
        Set(value As Integer)
            _horometro_incial = value
        End Set
    End Property

    Public Property Horometro_final As Integer
        Get
            Return _horometro_final
        End Get
        Set(value As Integer)
            _horometro_final = value
        End Set
    End Property

    Public Property Idguia As Integer
        Get
            Return _idguia
        End Get
        Set(value As Integer)
            _idguia = value
        End Set
    End Property

    Public Property Pesobalanza As Decimal
        Get
            Return _pesobalanza
        End Get
        Set(value As Decimal)
            _pesobalanza = value
        End Set
    End Property

    Public Property Operacion As Integer
        Get
            Return _operacion
        End Get
        Set(value As Integer)
            _operacion = value
        End Set
    End Property

    Public Property Idproducto As Integer
        Get
            Return _idproducto
        End Get
        Set(value As Integer)
            _idproducto = value
        End Set
    End Property
    Public Property Cantidadsacos As Integer
        Get
            Return _Cantidadsacos
        End Get
        Set(value As Integer)
            _Cantidadsacos = value
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

    Public Property Codigosenasa As String
        Get
            Return _codigosenasa
        End Get
        Set(value As String)
            _codigosenasa = value
        End Set
    End Property

    Public Property Tipoprecio As String
        Get
            Return _tipoprecio
        End Get
        Set(value As String)
            _tipoprecio = value
        End Set
    End Property

    Public Property Idplantel As Integer
        Get
            Return _idplantel
        End Get
        Set(value As Integer)
            _idplantel = value
        End Set
    End Property

    Public Property Idordencompra As Integer
        Get
            Return _idordencompra
        End Get
        Set(value As Integer)
            _idordencompra = value
        End Set
    End Property

    Public Property Idtipopeso As Integer
        Get
            Return _idtipopeso
        End Get
        Set(value As Integer)
            _idtipopeso = value
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

    Public Property Precioalimento As Decimal
        Get
            Return _Precioalimento
        End Get
        Set(value As Decimal)
            _Precioalimento = value
        End Set
    End Property

    Public Property Peso_promediofinal As Decimal
        Get
            Return _peso_promediofinal
        End Get
        Set(value As Decimal)
            _peso_promediofinal = value
        End Set
    End Property

    Public Sub SetArchivo(pdfData As Byte())
        Me.ArchivoRecepcion = pdfData
    End Sub

    Public Property NombreCliente As String
        Get
            Return _NombreCliente
        End Get
        Set(value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property Semana As String
        Get
            Return _Semana
        End Get
        Set(value As String)
            _Semana = value
        End Set
    End Property

    Public Property TipoFiltro As Integer
        Get
            Return _TipoFiltro
        End Get
        Set(value As Integer)
            _TipoFiltro = value
        End Set
    End Property
End Class
