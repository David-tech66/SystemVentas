using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleVenta
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_det_venta;
        private int _id_venta;
        private int _id_producto1;
        private DateTime _fecha_detalle;
        private int _cantidad_unitaria;
        private decimal _subtotal_venta;
        private decimal _vuelto;

        // Get (Obtener) y Set (Enviar o insertar): Encapsulado
        public int Id_det_venta { get => _id_det_venta; set => _id_det_venta = value; }
        public int Id_venta { get => _id_venta; set => _id_venta = value; }
        public int Id_producto1 { get => _id_producto1; set => _id_producto1 = value; }
        public DateTime Fecha_detalle { get => _fecha_detalle; set => _fecha_detalle = value; }
        public int Cantidad_unitaria { get => _cantidad_unitaria; set => _cantidad_unitaria = value; }
        public decimal Subtotal_venta { get => _subtotal_venta; set => _subtotal_venta = value; }
        public decimal Vuelto { get => _vuelto; set => _vuelto = value; }

        // CONSTRUCTOR VACIO
        public DDetalleVenta()
        {

        }

        // CONSTRUCTOR CON PARAMETROS
        public DDetalleVenta(int id_det_venta, int id_venta, int id_producto1, DateTime fecha_detalle, int cantidad_unitaria, decimal subtotal_venta, decimal vuelto)
        {
            // INICIALIZAR LAS PROPIEDADES DE LA CLASE
            Id_det_venta      = id_det_venta;
            Id_venta          = id_venta;
            Id_producto1      = id_producto1;
            Fecha_detalle     = fecha_detalle;
            Cantidad_unitaria = cantidad_unitaria;
            Subtotal_venta    = subtotal_venta;
            Vuelto            = vuelto;
        }

        // 1. METODO PARA INSERTAR
        public string InsertarDetalleVenta(DDetalleVenta Detalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra) 
        {
            string respuesta = "";
            try
            {
                SqlCommand SqlCmd = new SqlCommand(); // Instanciamos al comando para ejecutar SQL
                SqlCmd.Connection = SqlCon;           // Llamamos a la conexión para ejecutar el comando
                SqlCmd.Transaction = SqlTra;           // Ejecutamos una transacción para asegurar la integridad de los datos
                SqlCmd.CommandText = "spinsertar_detalle_venta";                // Ejecutamos el procedimiento almacenado
                SqlCmd.CommandType = System.Data.CommandType.StoredProcedure;   // Tipo de comando: Procedimiento almacenado
                SqlCmd.Parameters.AddWithValue("@id_venta", Detalle_Venta.Id_venta);
                SqlCmd.Parameters.AddWithValue("@id_producto1", Detalle_Venta.Id_producto1);
                SqlCmd.Parameters.AddWithValue("@fecha_det", Detalle_Venta.Fecha_detalle);
                SqlCmd.Parameters.AddWithValue("@cantidad_uni_det", Detalle_Venta.Cantidad_unitaria);
                SqlCmd.Parameters.AddWithValue("@subtotal_det_vent", Detalle_Venta.Subtotal_venta);
                SqlCmd.Parameters.AddWithValue("@vuelto", Detalle_Venta.Vuelto);

                // EJECUTA EL QUERY DEL PROCEDIMIENTO ALMACENADO
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                // MUESTRA UN ERROR
                respuesta = ex.Message;
            }
            finally 
            {
                // CIERRA LA CONEXION EN CASO HAY UN ALGUN ERROR
                if (SqlCon.State == System.Data.ConnectionState.Open) SqlCon.Close();
            }

            // RETORNA UNA RESPUESTA AL METODO
            return respuesta;
        }
    }
}
