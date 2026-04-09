-- PROCEDIMIENTO ALAMCENADO PARA BUSCAR --
CREATE PROC spbuscar_proveedor
@textobuscar VARCHAR(50)
AS 
SELECT * FROM tblProveedor
WHERE nombre_prov LIKE '%' + @textobuscar + '%'