-- PROCEDIMIENTO PARA INSERTAR LOS DATOS --
CREATE PROC spinsertar_marca
@nombre_marc		NVARCHAR(100),
@descripcion_marc	NVARCHAR(300),
@estado_marc		VARCHAR(10),
@fecha_registro		DATETIME
AS INSERT INTO tblMarca(nombre_marc, descripcion_marc, estado_marc, fecha_registro)
VALUES(@nombre_marc, @descripcion_marc, @estado_marc, @fecha_registro)	

SELECT * FROM tblMarca

GO
-- PROCEDIMIENTO PARA ACTUALIZAR -- 
CREATE PROC speditar_marca
@id_marca			INT,
@nombre_marc		NVARCHAR(100),
@descripcion_marc	NVARCHAR(300),
@estado_marc		NVARCHAR(10),
@fecha_registro		DATETIME
AS UPDATE tblMarca 
SET nombre_marc		 = @nombre_marc, 
	descripcion_marc = @descripcion_marc,
	estado_marc		 = @estado_marc,
	fecha_registro	 = @fecha_registro
WHERE id_marca = @id_marca