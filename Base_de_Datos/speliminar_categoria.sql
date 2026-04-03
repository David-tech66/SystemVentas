-- CREAR PROCEDIMIENTO ALMACENADO ELIMINAR --
CREATE PROC speliminar_categoria
@id_categoria INT
AS DELETE FROM tblCategoria
WHERE id_categoria = @id_categoria