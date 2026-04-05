CREATE PROC splogin
@usuario    NVARCHAR(200),
@contrasena NVARCHAR(200)
AS SELECT id_vendedor, primer_apellido, segundo_apellido, acceso
FROM tblVendedor
WHERE usuario = @usuario AND contrasena = @contrasena
