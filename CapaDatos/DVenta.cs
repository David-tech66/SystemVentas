using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_venta;
        private int _id_cliente;
        private int _id_vendedor;
        private DateTime _fecha;
        private string _tipo_comprobante;
        private string _serie;
        private string _correlativo;
        private decimal _igv;   // IGV: IMPUESTO GENERAL A LAS VENTAS
        private string _total;


        // Get (Obtener) y Set (Enviar o insertar): Encapsulado
        public int Id_venta { get => _id_venta; set => _id_venta = value; }
        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public int Id_vendedor { get => _id_vendedor; set => _id_vendedor = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Tipo_comprobante { get => _tipo_comprobante; set => _tipo_comprobante = value; }
        public string Serie { get => _serie; set => _serie = value; }
        public string Correlativo { get => _correlativo; set => _correlativo = value; }
        public decimal Igv { get => _igv; set => _igv = value; }
        public string Total { get => _total; set => _total = value; }


        // CONSTRUCTOR VACIO
        public DVenta()
        {

        }

        // CONSTRUCTOR CON PARAMETROS
        public DVenta(int id_venta, int id_cliente, int id_vendedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, decimal total)
        {
            // INICIALIZAR LAS PROPIEDADES DE LA CLASE
            Id_venta         = id_venta;
            Id_cliente       = id_cliente;
            Id_vendedor      = id_vendedor;
            Fecha            = fecha;
            Tipo_comprobante = tipo_comprobante;
            Serie            = serie;
            Correlativo      = correlativo;
            Igv              = igv;
            Total            = total.ToString();
        }

        // 1. METODO PARA INSERTAR
        public string InsertarVenta(DVenta Venta, List<DDetalleVenta> Detalle)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cadena;  // LlAMAMOS A LA CADENA DE CONEXION
                SqlCon.Open();  // ABRIR LA CONEXION

                // ESTABLECER LA TRANSACCION
                SqlTransaction SqlTra = SqlCon.BeginTransaction();

                // ESTABLECER EL COMANDO (PARA EJECUTAR UN SQL)
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                // PARAMETRO PARA RECUPERAR EL ID DE SALIDA AUTOGENERADO
                SqlParameter ParIdVenta = new SqlParameter("@id_venta", System.Data.SqlDbType.Int);
                ParIdVenta.Direction = System.Data.ParameterDirection.Output;

                // AGREGAR PARAMETROS
                SqlCmd.Parameters.AddWithValue("@id_vendedor", Venta.Id_vendedor);
                SqlCmd.Parameters.AddWithValue("@fecha", Venta.Fecha);
                SqlCmd.Parameters.AddWithValue("@tipo_comprobante", Venta.Tipo_comprobante);
                SqlCmd.Parameters.AddWithValue("@serie", Venta.Serie);
                SqlCmd.Parameters.AddWithValue("@correlativo", Venta.Correlativo);
                SqlCmd.Parameters.AddWithValue("@igv", Venta.Igv);
                SqlCmd.Parameters.AddWithValue("@total", Venta.Total);

                // EJECUTAMOS EL COMANDO
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO SE INSERTO LOS DATOS";

                if (respuesta.Equals("OK")) 
                {
                    // OBTENER EL ID DE VENTA GENERADO
                    Id_venta = Convert.ToInt32(SqlCmd.Parameters["@id_venta"].Value);

                    // BUCLE PARA RECORRER CADA ELEMENTO DE UNA LISTA DE DETALLE_VENTA
                    foreach (DDetalleVenta det in Detalle) 
                    { 
                        det.Id_venta = Id_venta;

                        // LLAMAMOS AL METODO PARA InsertarDetalleVenta
                        respuesta = det.InsertarDetalleVenta(det, ref SqlCon, ref SqlTra);
                        if (!respuesta.Equals("OK"))
                        {
                            break;  // ROMPE LA EJECUCION DEL BUCLE SI HAY UN ERROR EN LA INSERCION DE UN DETALLE_VENTA
                        }
                        // SI EN CASO SE QUIERE DESCONTAR UN STOCK DE UN PRODUCTO
                        else 
                        {
                            // CODIGO PARA DISMINUIR EL STOCK DE LOS PRODUCTOS VENDIDOS
                        }
                    }
                }
                if (respuesta.Equals("OK")) // SI TODO SALIO BIEN
                {
                    SqlTra.Commit();        // SE INSERTA LOS DATOS EN LAS TABLAS
                }
                else                        // SI EN CASO HAY UN ERROR
                { 
                    SqlTra.Rollback();      // ELIMINA TODOS LOS DATOS REGISTRADOS
                }
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }
    }
}
