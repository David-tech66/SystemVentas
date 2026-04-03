-- PROCEDIMIENTO ALMACENADO PARA MOSTRAR LOS DATOS --
CREATE PROC spmostrar_cliente 
AS
SELECT id_cliente	AS ID, 
nombre				AS NOMBRE, 
apellido			AS APELLIDO, 
correo				AS CORREO, 
dni					AS DNI,
telefono			AS TELEFONO
FROM tblCliente