using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace CapaDatos
{
    public class DProducto
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_producto;
        private int _id_categoria;
        private int _id_marca;
        private string _nombre_prod;
        private decimal _precio;
        private int _stock;
        private int _garantia;
        private DateTime _fecha_ingreso;

        // Get (Obtener) y Set (Enviar o insertar): Encapsulado
        public int Id_producto { get => _id_producto; set => _id_producto = value; }
        public int Id_categoria { get => _id_categoria; set => _id_categoria = value; }
        public int Id_marca { get => _id_marca; set => _id_marca = value; }
        public string Nombre_prod { get => _nombre_prod; set => _nombre_prod = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int Garantia { get => _garantia; set => _garantia = value; }
        public DateTime Fecha_ingreso { get => _fecha_ingreso; set => _fecha_ingreso = value; }

        // CONSTRUCTOR VACIO
        public DProducto()
        {
        
        }

        // CONSTRUCTOR CON PARAMETROS
        public DProducto(int id_producto, int id_categoria, int id_marca, string nombre_prod, decimal precio, int stock, int garantia, DateTime fecha_ingreso) 
        { 
            // INICIALIZAR LAS PROPIEDADES DE LA CLASE
            Id_producto   = id_producto;
            Id_categoria  = id_categoria;
            Id_marca      = id_marca;
            Nombre_prod   = nombre_prod;
            Precio        = precio;
            Stock         = stock;
            Garantia      = garantia;
            Fecha_ingreso = fecha_ingreso;
        }

        // 1. METODO PARA MOSTRAR DATOS DE UNA TABLA EN UN DATAGRIDVIEW
        public DataTable MostrarProducto()
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spmostrar_producto", SqlCon);
                // NOMBRE DE STOREPROCEDURE Y LA CADENA CONEXION
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);  // EJECUTAR COMANDO
                SqlDat.Fill(tabla);  // LLENAR LOS DATOS DE LA BD
            }
            catch (Exception ex)
            {
                tabla = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return tabla;
        }

        // 2. METODO PARA INSERTAR
        public string InsertarProducto(DProducto Producto)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("spinsertar_producto", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@nombre_prod", Producto.Nombre_prod);
                SqlCmd.Parameters.AddWithValue("@precio", Producto._precio);
                SqlCmd.Parameters.AddWithValue("@stock", Producto.Stock);
                SqlCmd.Parameters.AddWithValue("@garantia", Producto.Garantia);
                SqlCmd.Parameters.AddWithValue("Fecha_ingreso", Producto.Fecha_ingreso);
                // EJECUTAR LA CONSULTA DEL CODIGO ANTERIOR
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }

        // 3. METODO PARA ACTUALIZAR (UPDATE)
        public string ActualizarProducto(DProducto Producto)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speditar_producto", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_producto", Producto.Id_producto);
                SqlCmd.Parameters.AddWithValue("@nombre_prod", Producto.Nombre_prod);
                SqlCmd.Parameters.AddWithValue("@precio", Producto.Precio);
                SqlCmd.Parameters.AddWithValue("@stock", Producto.Stock);
                SqlCmd.Parameters.AddWithValue("@garantia", Producto.Garantia);
                SqlCmd.Parameters.AddWithValue("@fecha_ingreso", Producto.Fecha_ingreso);
                // EJECUTAR LA CONSULTA DEL CODIGO ANTERIOR
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }

        // 4. METODO ELIMINAR
        public string EliminarProducto(DProducto Producto)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speliminar_producto", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_producto", Producto.Id_producto);
                // EJECUTAR LA CONSULTA DEL CODIGO ANTERIOR
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }
    }
}
