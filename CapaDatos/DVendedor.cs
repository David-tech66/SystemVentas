using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class DVendedor
    {
        // PROPIEDADES O ATRIBUTOS
        private int _id_vendedor;
        private string _nombre_vendedor;
        private string _primer_apellido;
        private string _segundo_apellido;
        private string _correo_vendedor;
        private string _dni_vendedor;
        private string _telf_vendedor;
        private string _sexo;
        private DateTime _fecha_contrato;
        private string _direccion_vendedor;
        private decimal _salario;
        private string _estado_vendedor;
        private string _usuario;
        private string _contrasena;
        private string _acceso;

        // Get (Obtener) y Set (Enviar o insertar): Encapsulado
        public int Id_vendedor { get => _id_vendedor; set => _id_vendedor = value; }
        public string Nombre_vendedor { get => _nombre_vendedor; set => _nombre_vendedor = value; }
        public string Primer_apellido { get => _primer_apellido; set => _primer_apellido = value; }
        public string Segundo_apellido { get => _segundo_apellido; set => _segundo_apellido = value; }
        public string Correo_vendedor { get => _correo_vendedor; set => _correo_vendedor = value; }
        public string Dni_vendedor { get => _dni_vendedor; set => _dni_vendedor = value; }
        public string Telf_vendedor { get => _telf_vendedor; set => _telf_vendedor = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public DateTime Fecha_contrato { get => _fecha_contrato; set => _fecha_contrato = value; }
        public string Direccion_vendedor { get => _direccion_vendedor; set => _direccion_vendedor = value; }
        public decimal Salario { get => _salario; set => _salario = value; }
        public string Estado_vendedor { get => _estado_vendedor; set => _estado_vendedor = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string Acceso { get => _acceso; set => _acceso = value; }

        // CONSTRUCTOR VACIO
        public DVendedor() 
        {

        }

        // CONSTRUCTOR CON PARAMETROS
        public DVendedor(int id_vendedor, string nombre_vendedor, string primer_apellido, string segundo_apellido, string correo_vendedor, string dni_vendedor, string telf_vendedor, string sexo, DateTime fecha_contrato, string direccion_vendedor, decimal salario, string estado_vendedor, string usuario, string contrasena, string acceso) 
        { 
            Id_vendedor        = id_vendedor;
            Nombre_vendedor    = nombre_vendedor;
            Primer_apellido    = primer_apellido;
            Segundo_apellido   = segundo_apellido;
            Correo_vendedor    = correo_vendedor;
            Dni_vendedor       = dni_vendedor;
            Telf_vendedor      = telf_vendedor;
            Sexo               = sexo;
            Fecha_contrato     = fecha_contrato;
            Direccion_vendedor = direccion_vendedor;
            Salario            = salario;
            Estado_vendedor    = estado_vendedor;
            Usuario            = usuario;
            Contrasena         = contrasena;
            Acceso             = acceso;
        }

        // MÉTODO DE LOGIN (INICIO DE SESIÓN)
        public DataTable Login(DVendedor Vendedor)
        {
            DataTable tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("splogin", SqlCon);  // NOMBRE DEL PROCEDIMIENTO ALMACENADO Y LA CONEXIÓN
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("@usuario", Vendedor.Usuario); //Parámetro 1
                SqlCmd.Parameters.AddWithValue("@contrasena", Vendedor.Contrasena); //Parámetro 2

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd); // EJECUTA EL COMANDO SQL
                SqlDat.Fill(tabla); // LLENA LOS DATOS EN LA TABLA DE LA BASE DE DATOS
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
