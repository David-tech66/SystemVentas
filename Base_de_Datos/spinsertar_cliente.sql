CREATE PROC spinsertar_cliente
@nombre		NVARCHAR(200),
@apellido	NVARCHAR(300),
@correo		NVARCHAR(100),
@dni		CHAR(8),
@telefono	CHAR(9)
AS INSERT INTO tblCliente(nombre, apellido, correo, dni, telefono)
VALUES(@nombre, @apellido, @correo, @dni, @telefono)

SELECT * FROM tblCliente

GO
-- PROCEDIMIENTO PARA ACTUALIZAR CLIENTE --
CREATE PROC speditar_cliente
@id_cliente	INT,
@nombre		NVARCHAR(200),
@apellido	NVARCHAR(300),
@correo		NVARCHAR(100),
@dni		CHAR(8),
@telefono	CHAR(9)
AS UPDATE tblCliente
SET nombre		= @nombre,
	apellido	= @apellido,
	correo		= @correo,
	dni			= @dni,
	telefono	= @telefono
WHERE id_cliente = @id_cliente
