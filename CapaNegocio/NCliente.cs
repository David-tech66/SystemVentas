using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCliente
    {
        // 1. METODO "MOSTRAR" QUE LLAMA AL METODO MOSTRAR DE LA CLASE DCliente
        public static DataTable MostrarCliente() 
        { 
            return new DCliente().MostrarCliente();
        }

        // 2. METODO "INSERTAR" QUE LLAMA AL METODO INSERTAR DE LA CLASE DCliente
        public static string InsertarCliente(string nombre, string apellido, string correo, string dni, string telefono)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre   = nombre;
            Obj.Apellido = apellido;
            Obj.Correo   = correo;
            Obj.Dni      = dni;
            Obj.Telefono = telefono;

            return Obj.InsertarCliente(Obj);
        }

        // 3. METODO "ACTUALIZAR" QUE LLAMA AL METODO ACTUALIZAR DE LA CLASE DCliente
        public static string ActualizarCliente(int id_cliente, string nombre, string apellido, string correo, string dni, string telefono)
        {
            DCliente Obj   = new DCliente();
            Obj.Id_cliente = id_cliente;
            Obj.Nombre     = nombre;
            Obj.Apellido   = apellido;
            Obj.Correo     = correo;
            Obj.Dni        = dni;
            Obj.Telefono   = telefono;

            return Obj.ActualizarCliente(Obj);
        }

        // 4. METODO "ELIMINAR" QUE LLAMA AL METODO ELIMINAR DE LA CLASE DCliente
        public static string EliminarCliente(int id_cliente)
        {
            DCliente Obj = new DCliente();  // Instancia
            Obj.Id_cliente = id_cliente;

            return Obj.EliminarCliente(Obj);
        }

        // 5. METODO "BUSCAR" QUE LLAMA AL METODO BUSCAR DE LA CLASE DCliente
        public static DataTable BuscarCliente(string buscar)
        {
            DCliente Obj = new DCliente();
            Obj.Textobuscar = buscar;
            return Obj.BuscarCliente(Obj);
        }
    }
}
