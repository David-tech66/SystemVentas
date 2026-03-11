using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private int _id_cliente;
        private string _nombre;
        private string _apellido;
        private string _correo;
        private string _dni;
        private string _telefono;
        private string _textobuscar;

        public int Id_cliente { get => _id_cliente; set => _id_cliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }

        public DCliente() 
        {
        
        }
        public DCliente(int id_cliente, string nombre, string apellido, string correo,
            string dni, string telefono, string textobuscar)
        {
            Id_cliente = id_cliente;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Dni = dni;
            Telefono = telefono;
            Textobuscar = textobuscar;
        }

        public string RegistrarCliente(DCliente Cliente) 
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.cadena);
            SqlCon.Open();
            try
            {

            }
            catch (Exception ex) 
            {
            
            }
            return respuesta;
        }
    }
}
