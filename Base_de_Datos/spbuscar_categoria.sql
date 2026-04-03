-- PROCEDIMIENTO ALAMCENADO PARA BUSCAR --
CREATE PROC spbuscar_categoria
@textobuscar VARCHAR(50)
AS 
SELECT * FROM tblCategoria
WHERE nombre_catg LIKE '%' + @textobuscar + '%'
