-- PROCEDIMIENTO ALMACENADO PARA MOSTRAR LOS DATOS --
CREATE PROC spmostrar_marca
AS
SELECT id_marca  AS ID, 
nombre_marc		 AS MARCA, 
descripcion_marc AS DESCRIPCION, 
estado_marc		 AS ESTADO, 
fecha_registro   AS FECHA_REGISTRO 
FROM tblMarca