insert into categoriaproducto values('Insumos',1,getdate());
insert into categoriaproducto values('medicina',1,getdate());
insert into categoriaproducto values('vacuna',1,getdate());
insert into categoriaproducto values('epp',1,getdate());
insert into categoriaproducto values('ferreteria',1,getdate());
insert into categoriaproducto values('limpieza',1,getdate());

insert into marca values('OTROS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='ferreteria'));
insert into marca values('ADM',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('AJINOMOTO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('ARGENTINO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('AUROFINO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('BIOMIX',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('BV SCIENCE',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('CEETAL',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('CRINO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('DANISCO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('DESERT KING',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('ECO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('ELANCO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('EPPEN',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('EVONIC',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('GRANO DE ORO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('GRANOS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('ILENDER',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('LAPISA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('LAVET',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('MEIHUA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('MONTANA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('NORGTCH',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('NUSANA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('OTROS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('QUIMPAC',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('QUIMTIA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('SABROSAL',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('VAMPARIO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('YERUVA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('ZINPRO',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('ZN',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='Insumos'));
insert into marca values('OTROS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='limpieza'));
insert into marca values('AGROVETMARKET',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('ALFLEX',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('DENKAVIC',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('INREP S.AC',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('INVESA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('MEDI NOVA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('MIAVIT GMBH',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('MONTANA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('MSD',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('OTROS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('PHARTEC',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('QUIMTIA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('TAVET',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('VETERQUIMICA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('ZIX',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='medicina'));
insert into marca values('BOEHRING INGELHEIM',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));
insert into marca values('CEVA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));
insert into marca values('HIPRA',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));
insert into marca values('MERIAL',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));
insert into marca values('MSD',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));
insert into marca values('OTROS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));
insert into marca values('ZOETIS',1,getdate(),(select idcategoriaproducto from CategoriaProducto where upper(descripcion)='vacuna'));






INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('TONELADA', 'TON');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('SACO', 'SACO');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('BOLSA', 'BOL');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('KILOGRAMO', 'KG');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('UNIDAD', 'UND');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('GALON', 'GAL');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('CAJA', 'CJ');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('BIDON', 'BDN');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('PAQUETE', 'PAQ');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('LITRO', 'LTR');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('POTE', 'POT');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('LATA', 'LAT');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('CILINDRO', 'CIL');

INSERT INTO [dbo].[UnidadMedida] ([descripcion], [abreviatura])
VALUES ('PARES', 'PRS');


insert into producto values('MAIZ',170,'NO','SI','SI','NINGUNO',1,getdate(),4,3,'NINGUNO');
insert into producto values('AFRECHO * 40 KG',100,'NO','SI','SI','',1,getdate(),16,4,'NINGUNO');
insert into producto values('SOYA * 50 KG',2300,'NO','SI','SI','',1,getdate(),17,4,'NINGUNO');
insert into producto values('ARROCILLO * 50 KG',2000,'NO','NO','SI','',1,getdate(),25,4,'NINGUNO');
insert into producto values('POLVILLO  * 30',1000,'NO','NO','SI','',1,getdate(),25,4,'NINGUNO');
insert into producto values('PHOSBIC AL 18.5% * 25',75,'SI','SI','SI','',1,getdate(),26,4,'FOSFATO DICALCICO HIDRATADO 18.5 %');
insert into producto values('CARBONATO DE CALCIO * 50 KG',100,'SI','NO','SI','',1,getdate(),25,4,'CARBONATO DE CALCIO');
insert into producto values('SAL *50 KG',45,'SI','NO','SI','',1,getdate(),28,4,'SAL');
insert into producto values('ACEITE PALMA',3200,'NO','NO','SI','',1,getdate(),25,3,'ACEITE DE  PALMA');
insert into producto values('LISINA * 25 KG',60,'SI','SI','SI','',1,getdate(),21,4,'LISINA');
insert into producto values('METAMINO * 25 KG',25,'SI','SI','SI','',1,getdate(),15,5,'ETIONINA AL 99%');
insert into producto values('THREONINA * 25 KG',25,'SI','SI','SI','',1,getdate(),21,5,'THREONINA');
insert into producto values('TRIPTOFANO  * 25 KG',2,'SI','SI','SI','',1,getdate(),3,5,'TRIPTOFANO');
insert into producto values('VALINA * 25 KG',3,'SI','SI','SI','',1,getdate(),14,4,'VALINA');
insert into producto values('YERHEM  * 25 KG',10,'SI','SI','SI','',1,getdate(),30,5,'HEMOGLOBINA PORCINO');
insert into producto values('YERALBLUM 25 KG',0,'SI','SI','SI','no se esta utilizando',1,getdate(),30,5,'PLASMA PORCINO');
insert into producto values('ENROQUE * 25 KG',4,'SI','SI','SI','',1,getdate(),18,5,'ENRRAMICINA 8 %');
insert into producto values('ACABADO + PAYLEAN * 25 KG',8,'SI','SI','SI','',1,getdate(),18,5,'PRE MESCLA');
insert into producto values('INICIO * 24 KG',5,'SI','SI','SI','',1,getdate(),18,5,'PRE MESCLA');
insert into producto values('CRECIMIENTO * 25 KG',7,'SI','SI','SI','',1,getdate(),18,5,'PRE MESCLA');
insert into producto values('REPRODUCTORA *25 KG',6,'SI','SI','SI','',1,getdate(),18,5,'PRE MESCLA');
insert into producto values('NATURCOLIN  * KG',2,'SI','SI','SI','',1,getdate(),19,5,'BIOCOLINA');
insert into producto values('BUTIPHORCE 1065 * 25 KG',1,'SI','SI','SI','',1,getdate(),24,5,'ACIDO BUTIRICO');
insert into producto values('AVAILA CR 1000 * 25 KG',2,'SI','SI','SI','',1,getdate(),31,5,'CROMO');
insert into producto values('COOPER  PRO *25 KG',3,'SI','SI','SI','',1,getdate(),27,5,'CLORURO DE COBRE');
insert into producto values('OXIDO ZINC 72 % * 25 KG',2,'SI','SI','SI','',1,getdate(),32,5,'NINGUNO');
insert into producto values('SYNCRA *25 KG',2,'SI','SI','SI','',1,getdate(),10,5,'ENSIMA');
insert into producto values('TYLAN  TM 100  * 25 KG',0,'SI','SI','SI','',1,getdate(),13,5,'TILOSINA 100%');
insert into producto values('NUTRAFITO *20 KG',3,'SI','SI','SI','',1,getdate(),11,5,'SECUETRANTE DE AMONIACO ');
insert into producto values('RESOLVE 80  25 KG',5,'SI','SI','SI','',1,getdate(),20,5,'FLORFENICOL AL 8 %');
insert into producto values('SILITECH PROTECTOR  * 25 KG',4,'SI','SI','SI','',1,getdate(),23,5,'PROTECTOR HEPATICO');
insert into producto values('TOXIBOM *25 KG',7,'SI','SI','SI','',1,getdate(),6,5,'ADSORVENTE DE MICOTOXINA');
insert into producto values('DETOXA  * 25 KG',11,'SI','SI','SI','',1,getdate(),7,5,'SECUESTRANTE DE MICOTOXINA ');
insert into producto values('IVERFEED * 25 KG',1,'SI','SI','SI','',1,getdate(),20,5,'ANTI PARACITARIO');
insert into producto values('SURMAX * 25 KG',1,'SI','SI','SI','',1,getdate(),13,5,'AVILAMISINA ');
insert into producto values('AMOXICILINA 99 %* 25 KG',50,'SI','SI','SI','',1,getdate(),25,6,'AMOXICILINA AL 99%');
insert into producto values('VALOZIN - TILVALOSINA BLS * 20 KG',4,'SI','SI','SI','',1,getdate(),12,5,'TILVALOSINA AL 42.5 %');
insert into producto values('PRE INICIO * 25 KG',200,'SI','SI','SI','',1,getdate(),22,4,'NINGUNO');
insert into producto values('INICIO SC* 25 KG',350,'SI','SI','SI','',1,getdate(),22,4,'NINGUNO');
insert into producto values('BIOCET DRY ORIGINAL  * 25 KG',4,'SI','SI','SI','',1,getdate(),8,5,'POLVO SECANTE');
insert into producto values('NEUTOX* 25 KG',6,'SI','SI','SI','',1,getdate(),29,5,'SECUETRANTE DE MICOTOXINA');
insert into producto values('DULCE DE LECHE 56 *25 KG',0,'SI','SI','SI','no se esta utilizando',1,getdate(),9,5,'SUERO DE LECHE');
insert into producto values('ARDEX AFP  * 25',7,'SI','SI','SI','',1,getdate(),2,5,'PROTEINA AISLADA');
insert into producto values('NORFLOXACINA  * 25 KG',25,'SI','SI','SI','',1,getdate(),25,6,'NORFLOXACINA 99 %');
insert into producto values('RAPTOSIN AL 10 % * 10 KG',2,'SI','SI','SI','',1,getdate(),5,5,'CLORHIDRATADO DE RAPTOPAMINA');
insert into producto values('CIPROFLOXACINA * 25 KG',25,'SI','SI','SI','',1,getdate(),25,6,'CIPROFLOXACINA 99 %');
insert into producto values('ADEFORTEX *500 ML',3,'SI','SI','SI','',1,getdate(),43,1,'VITAMINA A,D3,E');
insert into producto values('AGUA DESTILADA*1 GLN',8,'SI','SI','SI','',1,getdate(),43,8,'NINGUNO');
insert into producto values('AGUJA 16G *3/4',50,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('AGUAJA 18*1',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('AGUJA 18*1 1/2',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('AGUJA 20*1',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('AGUJA 20* 1 1/2',0,'SI','SI','SI','no se esta utilizando',1,getdate(),43,1,'NINGUNO');
insert into producto values('AGUJA 22*1',20,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('AINIL *100 ML',6,'SI','SI','SI','',1,getdate(),38,1,'KETOPROFENO');
insert into producto values('ANTALVET *250 ML',3,'SI','SI','SI','',1,getdate(),41,1,'DIPIRONA AL 50%');
insert into producto values('APLICADOR DE 1 ML',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('APLICADOR DE 2 ML',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('APLICADOR DE 2 ML INNOSURE',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('AQUAZIX PLUS *20 LT',2,'SI','SI','SI','',1,getdate(),48,10,'PEROXIDO DE HIDROGENO 50%');
insert into producto values('ARETES CELESTES',100,'SI','SI','SI','',1,getdate(),35,1,'NINGUNO');
insert into producto values('BOLSA CON FILTRO PARA PROCESAR SEMEN',1,'SI','SI','SI','',1,getdate(),43,11,'NINGUNO');
insert into producto values('CATETER POSCERVICAL *500 UN',1,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('CATETER PRIMERISA * 500 UN',1,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('CATETER CERVICAL *500 UN',1,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('CUBRE OBJETO',1,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('PORTA OBJETO',1,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('MATABICHERA *500 ML',3,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('DESCOLMILLADOR DE LECHONES',0,'SI','SI','SI','no se esta utilizando',1,getdate(),43,1,'NINGUNO');
insert into producto values('DILUTORES F8',30,'SI','SI','SI','',1,getdate(),39,1,'NINGUNO');
insert into producto values('ENROPRO 20 LA AL  10% *250 ML',5,'SI','SI','SI','',1,getdate(),41,1,'ENROFLOXACINA AL 10%');
insert into producto values('FRASCOS DE SEMEN *500 UN',1,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('GAS BUTANO',0,'SI','SI','SI','no se esta utilizando',1,getdate(),43,1,'NINGUNO');
insert into producto values('GEL DE INSIMINAR*',3,'SI','SI','SI','',1,getdate(),39,1,'NINGUNO');
insert into producto values('GUANTES PARA PROSESAR SEMEN',1,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('GUANTES QUIRURGICOS',3,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('INVEMOX 15 % LA*250 ML',8,'SI','SI','SI','',1,getdate(),38,1,'AMOXICILINA AL 15 %');
insert into producto values('JERINGA DE 10 ML',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('JERINGA DE 20 ML',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('JERINGA DE 5 ML',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('JERINGA DE 3 ML',10,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('JERINGA DE 1 ML',3,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('LUTAPROS * 100 ML',3,'SI','SI','SI','',1,getdate(),43,1,'CLOPROSTENOL');
insert into producto values('MARCADORES',20,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('MODIVITASAN *500 ML',3,'SI','SI','SI','',1,getdate(),34,1,'COMPUESTO VITAMINICO');
insert into producto values('RATAPLUM',1,'SI','SI','SI','',1,getdate(),43,1,'RATICIDA');
insert into producto values('PEN DUO STREP',1,'SI','SI','SI','',1,getdate(),34,1,'PENICILINA');
insert into producto values('PISTOLA DE DESINFECTAR',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('RESOLVE 300 *100 ML',5,'SI','SI','SI','',1,getdate(),44,1,'NINGUNO');
insert into producto values('SHAMPOO',4,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('STRES LYTE PLUS * KG',3,'SI','SI','SI','',1,getdate(),46,6,'ELECTROLITOS');
insert into producto values('TERMOMETRO DE LABORATORIO',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('TERMOMETRO DIGITAL PARA MARRANA',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('TILOSINA *100 ML',2,'SI','SI','SI','',1,getdate(),38,1,'TILOSINA 100%');
insert into producto values('TINTA PARA TATUAR',1,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('TOLPROX 5% *1 LT',3,'SI','SI','SI','',1,getdate(),41,12,'TOLTRAZURILO COCCIDIAL');
insert into producto values('VITABION RILES* 20 LT',4,'SI','SI','SI','',1,getdate(),43,10,'BIODEGRADADOR');
insert into producto values('YODIGEN 30 PLUS * 20 LT',1,'SI','SI','SI','',1,getdate(),47,10,'YODO');
insert into producto values('ARETES ROJOS',100,'SI','SI','SI','',1,getdate(),35,1,'NINGUNO');
insert into producto values('DUPLAFER *100 ML',30,'SI','SI','SI','',1,getdate(),47,1,'HIERRO AL 20%');
insert into producto values('JUVENSOL 20 *1 LT',4,'SI','SI','SI','',1,getdate(),41,12,'PIRYPROXYFEN');
insert into producto values('AQUAZIX E 52 * 20 LT',6,'SI','SI','SI','',1,getdate(),48,10,'PEROXIDO ');
insert into producto values('MIAFIRSTAID *0.25',0,'','','SI','',1,getdate(),40,1,'EXTRACTO DE PLANTAS');
insert into producto values('MASCARILLA DESECHABLE',3,'SI','SI','SI','',1,getdate(),43,9,'NINGUNO');
insert into producto values('APLICADOR DE 0.5 ML',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('AGUJA VACUTEINER 21*1',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('AGUAJA VACUTEINER 20*1',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('TUBOS DE COLECCIÓN',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('SINGEN SQ 10 *20 LT',3,'SI','SI','SI','',1,getdate(),47,10,'CLORURO ');
insert into producto values('VQ 5000 *60 LT',1,'SI','SI','SI','',1,getdate(),47,10,'NINGUNO');
insert into producto values('OXYTO-SYNT 10 *100 ML',1,'SI','SI','SI','',1,getdate(),34,1,'OXITOSINA');
insert into producto values('EXCELLER*50 ML',30,'SI','SI','SI','',1,getdate(),42,1,'DORAMECTINA');
insert into producto values('ARETES REDONDOS ROJOS',100,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('DENKAPIC*20 KG',1,'SI','SI','SI','',1,getdate(),36,5,'SUSTITUTO LACTEO');
insert into producto values('FLORAFEN 20*1LT',12,'SI','SI','SI','',1,getdate(),45,12,'FLORFENICOL AL 20 %');
insert into producto values('GLACOXAN DELTA-T*1 LT',3,'SI','SI','SI','',1,getdate(),37,12,'DELTAMETRINA 1.5% + TETRAMISINA AL 1%');
insert into producto values('MASTERFLY BAIT  (CEBO DE MOSCA)',1,'SI','SI','SI','',1,getdate(),37,13,'NINGUNO');
insert into producto values('TEMOCID COLA ENTOMOLOGICA LATA *10 KG',1,'SI','SI','SI','',1,getdate(),37,14,'NINGUNO');
insert into producto values('AQUAZIX E 52 *200 LT',1,'SI','SI','SI','',1,getdate(),48,15,'NINGUNO');
insert into producto values('CUCAXAN',0,'SI','SI','SI','',1,getdate(),37,1,'NINGUNO');
insert into producto values('NOVICOX* 1 LT',4,'SI','SI','SI','',1,getdate(),47,12,'TOLTRAZURILO');
insert into producto values('CORTACOLA ELECTRICA',0,'SI','SI','SI','',1,getdate(),43,1,'NINGUNO');
insert into producto values('CIRCOFLEX DE 50 ML *50 DS',24,'SI','SI','SI','',1,getdate(),49,1,'CIRVIRUS PORCINO TIPO 2');
insert into producto values('HYOGEN DE 100 ML * 50 DS',20,'SI','SI','SI','',1,getdate(),50,1,'MYCOPLASMA HYOPNEUMONIAE');
insert into producto values('INNOSURE DE 250 ML *125 DS',20,'SI','SI','SI','',1,getdate(),55,1,'GONADOTROPINA (GNRF)');
insert into producto values('PESTIFFA DE 100 ML *50 DS',30,'SI','SI','SI','',1,getdate(),52,1,'PESTE PORCINA CLASICA');
insert into producto values(' ERYSENG PARVOLEPTO DE 100 ML *50 DS',5,'SI','SI','SI','',1,getdate(),51,1,'PARVOVIROS PORCINO');
insert into producto values('SUISENGEN DE 100 ML * 50 DS',5,'SI','SI','SI','',1,getdate(),51,1,'ESCHERICCHIA COLI');
insert into producto values('GLACER DE 100 ML * 50 DS',5,'SI','SI','SI','',1,getdate(),51,1,'HAEMOPHILUS PARASUIS');
insert into producto values(' PCV + MYCOPLASMA DE 100 ML *50 DS',10,'SI','SI','SI','',1,getdate(),53,1,'CIRCOVIRUS PORCINO TIPO 2 +MYCOPLASMA HYOPNEUMONIAE');
insert into producto values('ERYSENG PARVOLEPTO DE 20 ML *10 DS',10,'SI','SI','SI','',1,getdate(),51,1,'PARVOVIRUS PORCINO');
insert into producto values('ILEITES DE 100 ML *50 DS',33,'SI','SI','SI','',1,getdate(),53,1,'LAWSONIA INTRACELLULARIS');
insert into producto values('NEUMOSUIN DE 100 ML * 50 DS',35,'SI','SI','SI','',1,getdate(),54,1,'ACTINOBACILLUS PLEUROPNEUMONIAC');
insert into producto values('SANDALIA  39',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('SANDALIA 40',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('SANDALIA  41',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('SANDALIA 43',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('BOTAS 38',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('BOTAS 39',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('BOTAS 40',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('BOTAS 41',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('BOTAS 42',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('BOTAS 43',3,'NO','NO','SI','',1,getdate(),57,16,'NINGUNO');
insert into producto values('OBEROL DESECHABLE',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('OBEROL AZUL ',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('GORRAS',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('GORRO CHAVO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS MANGA CORTA',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLERAS  TALLA M',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLERAS  TALLA L',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLERAS  XL',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PANTALONES AFRANELADOS TALLA M',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('BUZO TALLA M',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('BUZO TALLA XL',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('BUZO TALLA L',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PANTALON AFRANELADOS TALLA XL',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PANTALON AFRANELADO TALLA L',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PANTALONES CORTA VIENTO TALLA M',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PANTALON CORTA VIENTO TALLA L',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('CASACA CORTA VIENTO M',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('CASACA CORTA VIENTO L',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS CEMENTOS INCA',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('BIVIDI BLANCO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS PLOMOS MONTANA',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS BLANCOS INVERAGRO CUELLO "V"',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('CAMISAS MANGA LARGA TALLA S,M,L',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS BLANCOS CUELLO PIQUE',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('CASACAS DE JEBE ',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS AZUL MONTANA CUELLO PIQUE',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS INVERAGRO AZUL MARINO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('POLOS DE DEPORTE NARANJA',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('SHORTS VERDE',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('UNIFORME DE ARQUERO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('SHORTS BLANCO ',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('MANDILES AZUL INVERAGRO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PANTALONES CONDUCTORES VERDE',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('TOALLAS BLANCAS INVERAGRO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('CHALECOS INVERAGRO DE VACUNACION',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('LENTES SEGURIDAD TRANSPARENTES',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('LENTES SEGURIDAD OSCURO',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('GUANTES DE SEGURIDAD',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('GUANTES DE BADANA',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('GUANTES DE LATEX',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('FAJAS DE SEGURIDAD',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('CASCOS',0,'NO','NO','SI','',1,getdate(),57,1,'NINGUNO');
insert into producto values('PISTOLA DE DESINFECTAR',0,'SI','SI','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('CHUPONES PARA LECHONES',0,'SI','SI','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('REPUESTO DECHUPONES DE LECHONES',0,'SI','SI','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('CHUPONES PARA MADRES',0,'SI','SI','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('REPUESTO DE CHUPONES DE MADRE',0,'SI','SI','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('CHUPONES PARA ENGORDE',0,'SI','SI','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('ESMALTES ROJO',0,'NO','NO','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('ESMALTE AZUL',0,'NO','NO','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('ESMALTE NEGRO',0,'NO','NO','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('ESMALTE VERDE',0,'NO','NO','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('ESMALTE AMARILLO',0,'NO','NO','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('THINER',0,'NO','NO','SI','',1,getdate(),1,1,'NINGUNO');
insert into producto values('CLAVO DE 3"',0,'NO','NO','SI','',1,getdate(),1,6,'NINGUNO');
insert into producto values('DETERGENTE',0,'NO','NO','SI','',1,getdate(),33,6,'NINGUNO');
