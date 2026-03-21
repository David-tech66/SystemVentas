using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_categoria;
        private string _nombre_catg;
        private string _descripcion;
        private string _estado;
        private DateTime _fecha;
        private string _textobuscar;

        // Get (Obtener) y Set (Enviar o insertar): Encapsulado
        public int Id_categoria { get => _id_categoria; set => _id_categoria = value; }
        public string Nombre_catg { get => _nombre_catg; set => _nombre_catg = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }

        // CONSTRUCTOR VACIO
        public DCategoria() 
        { 
        
        }

        // CONSTRUCTOR CON PARAMETROS
        public DCategoria(int id_categoria, string nombre_catg, string descripcion,
            string estado, DateTime fecha, string textobuscar) 
        { 
            // INICIALIZAR LAS PROPIEDADES DE LA CLASE
            Id_categoria = id_categoria;
            Nombre_catg = nombre_catg;
            Descripcion = descripcion;
            Estado = estado;
            Fecha = fecha;
            Textobuscar = textobuscar;
        }

        // METODO PARA INSERTAR
        public string InsertarCategoria(DCategoria Categoria) 
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try 
            {
                SqlCommand SqlCmd = new SqlCommand("spinsertar_categoria", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@nombre_catg", Categoria.Nombre_catg);
                SqlCmd.Parameters.AddWithValue("@descripcion", Categoria.Descripcion);
                SqlCmd.Parameters.AddWithValue("@estado", Categoria.Estado);
                SqlCmd.Parameters.AddWithValue("@fecha", Categoria.Fecha);
                // EJECUTAR LA CONSULTA DEL CODIGO ANTERIOR
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto";
            }
            catch (Exception ex) 
            { 
                respuesta = ex.Message;
            }

            return respuesta;
        }

        // METODO PARA ACTUALIZAR (UPDATE)
        public string ActualizarCategoria(DCategoria Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speditar_categoria", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_categoria", Categoria.Id_categoria);
                SqlCmd.Parameters.AddWithValue("@nombre_catg", Categoria.Nombre_catg);
                SqlCmd.Parameters.AddWithValue("@descripcion", Categoria.Descripcion);
                SqlCmd.Parameters.AddWithValue("@estado", Categoria.Estado);
                SqlCmd.Parameters.AddWithValue("@fecha", Categoria.Fecha);
                // EJECUTAR LA CONSULTA DEL CODIGO ANTERIOR
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }

        // METODO PARA MOSTRAR
        public DataTable MostraCategoria() 
        { 
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spmostrar_categoria", SqlCon);
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
    }
}
