-- CREAMOS EL PROCEDIMIENTO ALMACENADO DE INSERTAR --
CREATE PROC spinsertar_detalle_venta
@id_venta          INT,
@id_procduto1      INT,
@fecha_det		   DATETIME,
@cantidad_uni_det  INT,
@subtotal_det_vent DECIMAL(18,2)
AS
INSERT INTO tblDetalleVenta(id_venta, id_producto1, fecha_det, cantidad_uni_det, subtotal_det_vent)
VALUES (@id_venta, @id_procduto1, @fecha_det, @cantidad_uni_det, @subtotal_det_vent)