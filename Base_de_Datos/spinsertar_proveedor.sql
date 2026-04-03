-- PROCEDIMIENTO PARA INSERTAR LOS DATOS --
CREATE PROC spinsertar_proveedor
@nombre_prov	NVARCHAR(200),
@dire_prov		NVARCHAR(300),
@correo_prov	NVARCHAR(200),
@telf_prov      CHAR(9),
@ruc            NVARCHAR(11),
@estado_prov	VARCHAR(10)
AS INSERT INTO tblProveedor(nombre_prov, dire_prov, correo_prov, telf_prov, ruc, estado_prov)
VALUES(@nombre_prov, @dire_prov, @correo_prov, @telf_prov, @ruc, @estado_prov)	

SELECT * FROM tblProveedor

GO
-- PROCEDIMIENTO PARA ACTUALIZAR -- 
CREATE PROC speditar_proveedor
@id_proveedor	INT,
@nombre_prov	NVARCHAR(200),
@dire_prov		NVARCHAR(300),
@correo_prov	NVARCHAR(200),
@telf_prov      CHAR(9),
@ruc            NVARCHAR(11),
@estado_prov	VARCHAR(10)
AS UPDATE tblProveedor 
SET nombre_prov = @nombre_prov, 
	dire_prov   = @dire_prov,
	correo_prov = @correo_prov,
	telf_prov   = @telf_prov,
	ruc         = @ruc,
	estado_prov = @estado_prov
WHERE id_proveedor = @id_proveedor