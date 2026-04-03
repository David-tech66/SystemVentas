-- PROCEDIMIENTO ALMACENADO PARA MOSTRAR LOS DATOS --
CREATE PROC spmostrar_proveedor
AS
SELECT id_proveedor  AS ID, 
nombre_prov			 AS NOMBRE, 
dire_prov			 AS DIRECCION, 
correo_prov		     AS CORREO, 
telf_prov            AS TELEFONO,
ruc					 AS RUC,
estado_prov			 AS ESTADO
FROM tblProveedor