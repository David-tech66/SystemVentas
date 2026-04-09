-- PROCEDIMIENTO ALAMCENADO PARA BUSCAR --
CREATE PROC spbuscar_marca
@textobuscar VARCHAR(50)
AS 
SELECT * FROM tblMarca
WHERE nombre_marc LIKE '%' + @textobuscar + '%'