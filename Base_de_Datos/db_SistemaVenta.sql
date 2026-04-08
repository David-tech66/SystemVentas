CREATE DATABASE db_SistemaVenta
USE db_SistemaVenta


CREATE TABLE tblCliente
(
id_cliente	INT PRIMARY KEY IDENTITY(1, 1),
nombre		NVARCHAR(200) NOT NULL,
apellido	NVARCHAR(300) NOT NULL,
correo		NVARCHAR(100) NOT NULL,
dni			CHAR(8) NOT NULL,
telefono	CHAR(9) NOT NULL
)
SELECT * FROM tblCliente


CREATE TABLE tblVendedor
(
id_vendedor		   INT PRIMARY KEY IDENTITY(1, 1),
nombre_vendedor	   NVARCHAR(200) NOT NULL,
primer_apellido	   NVARCHAR(300) NOT NULL,
segundo_apellido   NVARCHAR(300) NOT NULL,
correo_vendedor    NVARCHAR(200) NOT NULL,
dni_vendedor  	   CHAR(8) NOT NULL,
telf_vendedor      CHAR(9) NOT NULL,
sexo               CHAR(9) NOT NULL,
fecha_contrato     DATETIME NOT NULL,
direccion_vendedor NVARCHAR(300) NOT NULL,
salario			   DECIMAL(10, 2) NOT NULL,
estado_vendedor	   VARCHAR(10) NOT NULL,
usuario			   NVARCHAR(200) NOT NULL,
contrasena         NVARCHAR(200) NOT NULL,
acceso             NVARCHAR(100) NOT NULL
)
SELECT * FROM tblVendedor


CREATE TABLE tblProveedor
(
id_proveedor	INT PRIMARY KEY IDENTITY(1, 1),
nombre_prov		NVARCHAR(200) NOT NULL,
dire_prov		NVARCHAR(300) NOT NULL,
correo_prov		NVARCHAR(200) NOT NULL,
telf_prov		CHAR(9) NOT NULL,
ruc				NVARCHAR(11) NOT NULL,
estado_prov		VARCHAR(10) NOT NULL
)
SELECT * FROM tblProveedor


CREATE TABLE tblCategoria
(
id_categoria	INT PRIMARY KEY IDENTITY(1, 1),
nombre_catg		NVARCHAR(100) NOT NULL,
descripcion		NVARCHAR(200) NOT NULL,
estado			NVARCHAR(20) NOT NULL,
fecha			DATETIME NOT NULL
)
SELECT * FROM tblCategoria


CREATE TABLE tblMarca
(
id_marca			INT PRIMARY KEY IDENTITY(1, 1),
nombre_marc			NVARCHAR(100) NOT NULL,
descripcion_marc	NVARCHAR(300) NOT NULL,
estado_marc			VARCHAR(10) NOT NULL,
fecha_registro		DATETIME NOT NULL
)
SELECT * FROM tblMarca


-- INICIO DE TABLAS CON LLAVES FORANEAS --

CREATE TABLE tblProducto
(
id_producto		INT PRIMARY KEY IDENTITY(1, 1),
id_categoria	INT,
id_marca		INT,
nombre_prod		NVARCHAR(200) NOT NULL,
descripcion     NVARCHAR(200) NOT NULL,
precio			DECIMAL(18,2) NOT NULL,
stock			INT NOT NULL,
fech_ingreso	DATETIME NOT NULL
constraint fk_fcategoria foreign key(id_categoria) references tblCategoria(id_categoria),
constraint fk_fmarca foreign key(id_marca) references tblMarca(id_marca)
)
SELECT * FROM tblProducto


CREATE TABLE tblVenta
(
id_venta		 INT PRIMARY KEY IDENTITY(1, 1),
id_cliente		 INT,
id_vendedor		 INT,
fecha			 DATETIME NOT NULL,
tipo_comprobante VARCHAR(20) NOT NULL,
serie			 VARCHAR(4) NOT NULL,
correlativo	     VARCHAR(10) NOT NULL,
igv			     DECIMAL(18, 0) NOT NULL,
total			 DECIMAL(18, 0) NOT NULL
constraint fk_fcliente foreign key(id_cliente) references tblCliente(id_cliente),
constraint fk_fvendedor foreign key(id_vendedor) references tblVendedor(id_vendedor)
)
SELECT * FROM tblVenta


-- TABLA INTERMEDIA --
CREATE TABLE tblDetalleVenta
(
id_det_venta		INT PRIMARY KEY IDENTITY(1, 1),
id_venta			INT,
id_producto1		INT,
fecha_detalle		DATETIME NOT NULL,
cantidad_unitaria	INT NOT NULL,
subtotal_venta		DECIMAL(18,2) NOT NULL
constraint fk_fventa foreign key(id_venta) references tblVenta(id_venta),
constraint fk_fproducto1 foreign key(id_producto1) references tblProducto(id_producto)
)
SELECT * FROM tblDetalleVenta


CREATE TABLE tblCompra
(
id_compra		INT PRIMARY KEY IDENTITY(1, 1),
id_proveedor	INT,
total_compra	DECIMAL(18,2) NOT NULL,
fecha_compra	DATETIME NOT NULL,
constraint fk_fproveedor foreign key(id_proveedor) references tblProveedor(id_proveedor)
)
SELECT * FROM tblCompra


-- TABLA INTERMEDIA --
CREATE TABLE tblDetalleCompra
(
id_det_compra	INT PRIMARY KEY IDENTITY(1, 1),
id_compra		INT,
id_producto		INT,
cantidad_uni	INT NOT NULL,
costo_unitario	DECIMAL(18,2) NOT NULL,
subtotal_det	DECIMAL(18,2) NOT NULL
constraint fk_fcompra foreign key(id_compra) references tblCompra(id_compra),
constraint fk_fproducto foreign key(id_producto) references tblProducto(id_producto)
)
SELECT * FROM tblDetalleCompra


CREATE TABLE tblPago
(
id_pago		INT PRIMARY KEY IDENTITY(1, 1),
id_venta1	INT,
fecha_pago	DATETIME NOT NULL,
monto_pago	VARCHAR(50) NOT NULL,
monto		DECIMAL(18,2) NOT NULL,
vuelto_pago DECIMAL(18,2)
constraint fk_fventa1 foreign key(id_venta1) references tblVenta(id_venta)
)
SELECT * FROM tblPago