using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_proveedor;
        private string _nombre_prov;
        private string _dire_prov;
        private string _correo_prov;
        private string _telf_prov;
        private string _ruc;
        private string _estado_prov;
        private string _textobuscar;

        // Get (Obtener) y Set (Enviar o insertar): Encapsulado
        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
        public string Nombre_prov { get => _nombre_prov; set => _nombre_prov = value; }
        public string Dire_prov { get => _dire_prov; set => _dire_prov = value; }
        public string Correo_prov { get => _correo_prov; set => _correo_prov = value; }
        public string Telf_prov { get => _telf_prov; set => _telf_prov = value; }
        public string Ruc { get => _ruc; set => _ruc = value; }
        public string Estado_prov { get => _estado_prov; set => _estado_prov = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }

        // CONSTRUCTOR VACIO
        public DProveedor() 
        {

        }

        // CONSTRUCTOR CON PARAMETROS
        public DProveedor(int id_proveedor, string nombre_prov, string dire_prov, string correo_prov, string telf_prov, string ruc, string estado_prov, string textobuscar)
        {
            // INICIALIZAR LAS PROPIEDADES DE LA CLASE
            Id_proveedor = id_proveedor;
            Nombre_prov  = nombre_prov;
            Dire_prov    = dire_prov;
            Correo_prov  = correo_prov;
            Telf_prov    = telf_prov;
            Estado_prov  = estado_prov;
            Textobuscar  = textobuscar;
        }

        // 1. METODO PARA MOSTRAR DATOS DE UNA TABLA EN UN DATAGRIDVIEW
        public DataTable MostrarProveedor()
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spmostrar_proveedor", SqlCon);
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
        public string InsertarProveedor(DProveedor Proveedor)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("spinsertar_proveedor", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@nombre_prov", Proveedor.Nombre_prov);
                SqlCmd.Parameters.AddWithValue("@dire_prov", Proveedor.Dire_prov);
                SqlCmd.Parameters.AddWithValue("@correo_prov", Proveedor.Correo_prov);
                SqlCmd.Parameters.AddWithValue("@telf_prov", Proveedor.Telf_prov);
                SqlCmd.Parameters.AddWithValue("@ruc", Proveedor.Ruc);
                SqlCmd.Parameters.AddWithValue("@estado_prov", Proveedor.Estado_prov);
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
        public string ActualizarProveedor(DProveedor Proveedor)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speditar_proveedor", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_proveedor", Proveedor.Id_proveedor);
                SqlCmd.Parameters.AddWithValue("@nombre_prov", Proveedor.Nombre_prov);
                SqlCmd.Parameters.AddWithValue("@dire_prov", Proveedor.Dire_prov);
                SqlCmd.Parameters.AddWithValue("@correo_prov", Proveedor.Correo_prov);
                SqlCmd.Parameters.AddWithValue("@telf_prov", Proveedor.Telf_prov);
                SqlCmd.Parameters.AddWithValue("@ruc", Proveedor.Ruc);
                SqlCmd.Parameters.AddWithValue("@estado_prov", Proveedor.Estado_prov);
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
        public string EliminarProveedor(DProveedor Proveedor)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {
                SqlCommand SqlCmd = new SqlCommand("speliminar_proveedor", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN TU TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@id_proveedor", Proveedor.Id_proveedor);
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
        public DataTable BuscarProveedor(DProveedor Proveedor)
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spbuscar_proveedor", SqlCon);   // NOMBRE DE STOREPROCEDURE Y LA CADENA CONEXION
                SqlCmd.CommandType = CommandType.StoredProcedure;
                // PARAMETROS SEGUN LA TABLA DE BD
                SqlCmd.Parameters.AddWithValue("@textobuscar", Proveedor.Textobuscar);
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
