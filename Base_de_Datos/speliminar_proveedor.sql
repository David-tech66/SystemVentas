-- CREAR PROCEDIMIENTO ALMACENADO ELIMINAR --
CREATE PROC speliminar_proveedor
@id_proveedor INT
AS DELETE FROM tblProveedor
WHERE id_proveedor = @id_proveedor