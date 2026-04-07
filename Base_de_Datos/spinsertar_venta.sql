-- CREAMOS EL PROCEDIMIENTO ALMACENADO DE INSERTAR --
CREATE PROC spinsertar_venta
@id_venta	      INT OUTPUT, -- PARÁMETRO DE SALIDA --
@id_cliente       INT,
@id_vendedor      INT,
@fecha_venta	  DATETIME,
@tipo_comprobante VARCHAR(20),
@serie            VARCHAR(4),
@correlativo      VARCHAR(10),
@igv              DECIMAL(18,0),
@total            DECIMAL(18,0)
AS
INSERT INTO tblVenta(id_venta, id_cliente, id_vendedor, fecha_venta,tipo_comprobante, serie, correlativo, igv, total)
VALUES (@id_venta, @id_cliente, @id_vendedor, @fecha_venta, @tipo_comprobante, @serie, @correlativo, @igv, @total)
-- OBTENEMOS EL ID GENERADO --
SET @id_venta = SCOPE_IDENTITY()