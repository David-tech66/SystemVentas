-- CREAR PROCEDIMIENTO ALMACENADO ELIMINAR --
CREATE PROC speliminar_cliente
@id_cliente INT
AS DELETE FROM tblCliente
WHERE id_cliente = @id_cliente