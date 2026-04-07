using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProducto
    {
        // 1. METODO "MOSTRAR" QUE LLAMA AL METODO MOSTRAR DE LA CLASE DProducto
        public static DataTable MostrarProducto()
        {
            return new DProducto().MostrarProducto();
        }

        // 2. METODO "INSERTAR" QUE LLAMA AL METODO INSERTAR DE LA CLASE DProducto
        public static string InsertarProducto(string nombre_prod, string descripcion, decimal precio, DateTime fecha_ingreso)
        {
            DProducto Obj     = new DProducto();
            Obj.Nombre_prod   = nombre_prod;
            Obj.Descripcion   = descripcion;
            Obj.Precio        = precio;
            Obj.Fecha_ingreso = fecha_ingreso;

            return Obj.InsertarProducto(Obj);
        }

        // 3. METODO "ACTUALIZAR" QUE LLAMA AL METODO ACTUALIZAR DE LA CLASE DCategoria
        public static string ActualizarProducto(int id_producto, string nombre_prod, string descripcion, decimal precio, DateTime fecha_ingreso)
        {
            DProducto Obj     = new DProducto();
            Obj.Id_producto   = id_producto;
            Obj.Nombre_prod   = nombre_prod;
            Obj.Descripcion   = descripcion;
            Obj.Precio        = precio;
            Obj.Fecha_ingreso = fecha_ingreso;

            return Obj.ActualizarProducto(Obj);
        }

        // 4. METODO "ELIMINAR" QUE LLAMA AL METODO ELIMINAR DE LA CLASE DCategoria
        public static string EliminarProducto(int id_producto)
        {
            DProducto Obj = new DProducto();  // Instancia
            Obj.Id_producto = id_producto;

            return Obj.EliminarProducto(Obj);
        }

        // 5. METODO "BUSCAR" QUE LLAMA AL METODO BUSCAR DE LA CLASE DCategoria
        public static DataTable BuscarProducto(string buscar)
        {
            DProducto Obj = new DProducto();
            Obj.Textobuscar = buscar;
            return Obj.BuscarProducto(Obj);
        }
    }
}
