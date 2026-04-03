-- CREAR PROCEDIMIENTO ALMACENADO ELIMINAR --
CREATE PROC speliminar_marca
@id_marca INT
AS DELETE FROM tblMarca
WHERE id_marca = @id_marca