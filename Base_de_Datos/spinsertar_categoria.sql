-- PROCEDIMIENTO PARA INSERTAR LOS DATOS --
CREATE PROC spinsertar_categoria
@nombre_catg	NVARCHAR(100),
@descripcion	NVARCHAR(200),
@estado			NVARCHAR(20),
@fecha			DATETIME
AS INSERT INTO tblCategoria(nombre_catg, descripcion, estado, fecha)
VALUES(@nombre_catg, @descripcion, @estado, @fecha)	

SELECT * FROM tblCategoria

/* CODIGO DE COMO ACTUALIZAR LOS DATOS DE UNA TABLA
UPDATE tblCategoria SET descripcion = 'Teclado HP'
WHERE id_categoria=2
*/

GO
-- PROCEDIMIENTO PARA ACTUALIZAR CATEGORIA -- 
CREATE PROC speditar_categoria
@id_categoria	INT,
@nombre_catg	NVARCHAR(100),
@descripcion	NVARCHAR(200),
@estado			NVARCHAR(20),
@fecha			DATETIME
AS UPDATE tblCategoria 
SET nombre_catg = @nombre_catg, 
	descripcion = @descripcion,
	estado		= @estado,
	fecha		= @fecha
WHERE id_categoria = @id_categoria