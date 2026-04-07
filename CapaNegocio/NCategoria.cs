using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCategoria
    {
        // 1. METODO "MOSTRAR" QUE LLAMA AL METODO MOSTRAR DE LA CLASE DCategoria
        public static DataTable MostrarCategoria() 
        {
            return new DCategoria().MostrarCategoria();
        }

        // 2. METODO "INSERTAR" QUE LLAMA AL METODO INSERTAR DE LA CLASE DCategoria
        public static string InsertarCategoria(string nombre_catg, string descripcion, string estado, DateTime fecha) 
        {
            DCategoria Obj  = new DCategoria();
            Obj.Nombre_catg = nombre_catg;
            Obj.Descripcion = descripcion;
            Obj.Estado      = estado;
            Obj.Fecha       = fecha;

            return Obj.InsertarCategoria(Obj);
        }

        // 3. METODO "ACTUALIZAR" QUE LLAMA AL METODO ACTUALIZAR DE LA CLASE DCategoria
        public static string ActualizarCategoria(int id_categoria, string nombre_catg, string descripcion, string estado, DateTime fecha)
        {
            DCategoria Obj   = new DCategoria();
            Obj.Id_categoria = id_categoria;
            Obj.Nombre_catg  = nombre_catg;
            Obj.Descripcion  = descripcion;
            Obj.Estado       = estado;
            Obj.Fecha        = fecha;

            return Obj.ActualizarCategoria(Obj);
        }

        // 4. METODO "ELIMINAR" QUE LLAMA AL METODO ELIMINAR DE LA CLASE DCategoria
        public static string EliminarCategoria(int id_categoria)
        {
            DCategoria Obj   = new DCategoria();  // Instancia
            Obj.Id_categoria = id_categoria;

            return Obj.EliminarCategoria(Obj);
        }

        // 5. METODO "BUSCAR" QUE LLAMA AL METODO BUSCAR DE LA CLASE DCategoria
        public static DataTable BuscarCategoria(string buscar) 
        {
            DCategoria Obj = new DCategoria();
            Obj.Textobuscar = buscar;
            return Obj.BuscarCategoria(Obj);
        }

        // 6. METODO MOSTRAR PRODUCTO CLIENTE
        public static DataTable MostrarProductosCliente(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.Textobuscar = textobuscar;
            return new DCategoria().MostrarProductosCliente(Obj);
        }
    }
}
