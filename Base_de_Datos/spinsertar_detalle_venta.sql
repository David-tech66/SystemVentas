-- CREAMOS EL PROCEDIMIENTO ALMACENADO DE INSERTAR --
CREATE PROC spinsertar_detalle_venta
@id_venta          INT,
@id_procduto1      INT,
@fecha_detalle	   DATETIME,
@cantidad_unitaria INT,
@subtotal_venta    DECIMAL(18,2)
AS
INSERT INTO tblDetalleVenta(id_venta, id_producto1, fecha_detalle, cantidad_unitaria, subtotal_venta)
VALUES (@id_venta, @id_procduto1, @fecha_detalle, @cantidad_unitaria, @subtotal_venta)