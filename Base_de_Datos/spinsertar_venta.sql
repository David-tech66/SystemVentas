-- CREAMOS EL PROCEDIMIENTO ALMACENADO DE INSERTAR --
CREATE PROC spinsertar_venta
@id_venta	 INT OUTPUT, -- PARÁMETRO DE SALIDA --
@id_cliente  INT,
@id_vendedor INT,
@fecha		 DATETIME,
@total		 INT,
@subtotal    DECIMAL(18,0),
@vuelto      DECIMAL(18,0)
AS
INSERT INTO tblVenta(id_venta, id_cliente, id_vendedor, fecha, total, subtotal, vuelto)
VALUES (@id_venta, @id_cliente, @id_vendedor, @fecha, @total, @subtotal, @vuelto)
-- OBTENEMOS EL ID GENERADO --
SET @id_venta = SCOPE_IDENTITY()