using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMarca
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_marca;
        private string _nombre_marc;
        private string _descripcion_marc;
        private string _estado_marc;
        private DateTime _fecha_registro;
        private string _textobuscar;

        // PROPIEDAD PARA OBTENER Y ENVIAR DATOS
        public int Id_marca { get => _id_marca; set => _id_marca = value; }
        public string Nombre_marc { get => _nombre_marc; set => _nombre_marc = value; }
        public string Descripcion_marc { get => _descripcion_marc; set => _descripcion_marc = value; }
        public string Estado_marc { get => _estado_marc; set => _estado_marc = value; }
        public DateTime Fecha_registro { get => _fecha_registro; set => _fecha_registro = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }

        // CONSTRUCTOR VACIO (Si es que ocurre un error)
        public DMarca()
        {

        }

        // CONSTRUCTOR CON PARAMETROS
        public DMarca(int id_marca, string nombre_marc, string descripcion_marc, string estado_marc, DateTime fecha_registro, string textobuscar)
        {
            // INICIALIZAR LAS PROPIEDADES DE LA CLASE
            Id_marca         = id_marca;
            Nombre_marc      = nombre_marc;
            Descripcion_marc = descripcion_marc;
            Estado_marc      = estado_marc;
            Fecha_registro   = fecha_registro;
            Textobuscar      = textobuscar;
        }

        // 1. METODO PARA MOSTRAR DATOS DE UNA TABLA EN UN DATAGRIDVIEW
        public DataTable MostrarMarca()
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spmostrar_marca", SqlCon);  // LLAMA AL PROCEDIMIENTO Y ENVIA LA CADENA DE CONEXION
                SqlCmd.CommandType = CommandType.StoredProcedure;   // EJECUTAR UN PROCEDIMIENTO ALMACENADO

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
        public string InsertarMarca(DMarca Marca)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("spinsertar_marca", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@nombre_marc", Marca.Nombre_marc);
                SqlCmd.Parameters.AddWithValue("@descripcion_marc", Marca.Descripcion_marc);
                SqlCmd.Parameters.AddWithValue("@estado_marc", Marca.Estado_marc);
                SqlCmd.Parameters.AddWithValue("@fecha_registro", Marca.Fecha_registro);
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
        public string ActualizarMarca(DMarca Marca)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speditar_marca", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_marca", Marca.Id_marca);
                SqlCmd.Parameters.AddWithValue("@nombre_marc", Marca.Nombre_marc);
                SqlCmd.Parameters.AddWithValue("@descripcion_marc", Marca.Descripcion_marc);
                SqlCmd.Parameters.AddWithValue("@estado_marc", Marca.Estado_marc);
                SqlCmd.Parameters.AddWithValue("@fecha_registro", Marca.Fecha_registro);
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
        public string EliminarMarca(DMarca Marca)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speliminar_marca", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_marca", Marca.Id_marca);
                // EJECUTAR LA CONSULTA DEL CODIGO ANTERIOR
                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            return respuesta;
        }

        // 5. METODO BUSCAR
        public DataTable BuscarMarca(DMarca Marca)
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spbuscar_marca", SqlCon);   // NOMBRE DE STOREPROCEDURE Y LA CADENA CONEXION
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN LA TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@textobuscar", Marca.Textobuscar);
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
