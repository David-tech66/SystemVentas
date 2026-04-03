-- PROCEDIMIENTO ALAMCENADO PARA BUSCAR --
CREATE PROC spbuscar_cliente
@textobuscar VARCHAR(50)
AS 
SELECT * FROM tblCliente
WHERE NOMBRE LIKE '%' + @textobuscar + '%'