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
        public static DataTable MostrarCategoria() 
        {
            return new DCategoria().MostraCategoria();
        }
        public static string InsertarCategoria(string nombre_catg, string descripcion,
                string estado, DateTime fecha) 
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre_catg = nombre_catg;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            Obj.Fecha = fecha;

            return Obj.InsertarCategoria(Obj);
        }

        public static string ActualizarCategoria(int id_categoria, string nombre_catg, string descripcion,
                string estado, DateTime fecha)
        {
            DCategoria Obj = new DCategoria();

            Obj.Id_categoria = id_categoria;
            Obj.Nombre_catg = nombre_catg;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            Obj.Fecha = fecha;

            return Obj.ActualizarCategoria(Obj);
        }
    }
}
