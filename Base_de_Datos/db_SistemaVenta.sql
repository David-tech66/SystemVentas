CREATE DATABASE db_SistemaVenta
USE db_SistemaVenta

CREATE TABLE tblCliente
(
id_cliente INT PRIMARY KEY IDENTITY(1, 1),
nombre nvarchar(200) not null,
apellido nvarchar(300) not null,
correo nvarchar(100) not null,
dni char(8) not null,
telefono char(9) not null
)

CREATE TABLE tblVendedor
(
id_vendedor INT PRIMARY KEY IDENTITY(1, 1),
nombre_ven nvarchar(200) not null,
apellido_ven nvarchar(300) not null,
dni_ven char(8) not null,
telf_ven char(9) not null
)

CREATE TABLE tblProveedor
(
id_proveedor INT PRIMARY KEY IDENTITY(1, 1),
nombre_prov nvarchar(200) not null,
dire_prov nvarchar(300) not null,
telf_prov char(9) not null,
ruc nvarchar(11) not null
)

CREATE TABLE tblCategoria
(
id_categoria INT PRIMARY KEY IDENTITY(1, 1),
nombre_catg nvarchar(100) not null
)
/* AGREGAR ATRIBUTOS FALTANTES A UNA TABLA EXISTENTE:
ALTER TABLE tblCategoria
ADD descripcion NVARCHAR(200) NOT NULL, estado NVARCHAR(20) NOT NULL, fecha DATETIME NOT NULL
*/

CREATE TABLE tblMarca
(
id_marca INT PRIMARY KEY IDENTITY(1, 1),
nombre_marc nvarchar(100) not null
)

-- INICIO DE TABLAS CON LLAVES FORANEAS --

CREATE TABLE tblVenta
(
id_venta INT PRIMARY KEY IDENTITY(1, 1),
total int not null,
fecha datetime not null,
id_cliente int,
id_vendedor int,
constraint fk_fcliente foreign key(id_cliente) references tblCliente(id_cliente),
constraint fk_fvendedor foreign key(id_vendedor) references tblVendedor(id_vendedor)
)

CREATE TABLE tblCompra
(
id_compra INT PRIMARY KEY IDENTITY(1, 1),
total_compra int not null,
fecha_compra datetime not null,
id_proveedor int,
constraint fk_fproveedor foreign key(id_proveedor) references tblProveedor(id_proveedor)
)

CREATE TABLE tblProducto
(
id_producto INT PRIMARY KEY IDENTITY(1, 1),
nombre_prod nvarchar(200) not null,
precio decimal(18,0) not null,
stock int not null,
id_categoria int,
id_marca int,
constraint fk_fcategoria foreign key(id_categoria) references tblCategoria(id_categoria),
constraint fk_fmarca foreign key(id_marca) references tblMarca(id_marca)
)

CREATE TABLE tblDetalleCompra
(
id_det_compra INT PRIMARY KEY IDENTITY(1, 1),
cantidad int not null,
costo_unitario decimal(18,0) not null,
id_compra int,
id_producto int,
constraint fk_fcompra foreign key(id_compra) references tblCompra(id_compra),
constraint fk_fproducto foreign key(id_producto) references tblProducto(id_producto)
)

CREATE TABLE tblDetalleVenta
(
id_det_venta INT PRIMARY KEY IDENTITY(1, 1),
fecha_det datetime not null,
cantidad_uni int not null,
id_venta int,
id_producto1 int,
constraint fk_fventa foreign key(id_venta) references tblVenta(id_venta),
constraint fk_fproducto1 foreign key(id_producto1) references tblProducto(id_producto)
)

CREATE TABLE tblPago
(
id_pago INT PRIMARY KEY IDENTITY(1, 1),
fecha_pago datetime not null,
monto_pago varchar(20) not null,
monto decimal(18,0) not null,
id_venta1 int,
constraint fk_fventa1 foreign key(id_venta1) references tblVenta(id_venta)
)