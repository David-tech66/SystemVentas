using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NMarca
    {
        // 1. METODO "MOSTRAR" QUE LLAMA AL METODO MOSTRAR DE LA CLASE DMarca
        public static DataTable MostrarMarca()
        {
            return new DMarca().MostrarMarca();
        }

        // 2. METODO "INSERTAR" QUE LLAMA AL METODO INSERTAR DE LA CLASE DMarca
        public static string InsertarMarca(string nombre_marc, string descripcion_marc, string estado_marc, DateTime fecha_registro)
        {
            DMarca Obj           = new DMarca();
            Obj.Nombre_marc      = nombre_marc;
            Obj.Descripcion_marc = descripcion_marc;
            Obj.Estado_marc      = estado_marc;
            Obj.Fecha_registro   = fecha_registro;

            return Obj.InsertarMarca(Obj);
        }

        // 3. METODO "ACTUALIZAR" QUE LLAMA AL METODO ACTUALIZAR DE LA CLASE DMarca
        public static string ActualizarMarca(int id_marca, string nombre_marc, string descripcion_marc, string estado_marc, DateTime fecha_registro)
        {
            DMarca Obj           = new DMarca();
            Obj.Id_marca         = id_marca;
            Obj.Nombre_marc      = nombre_marc;
            Obj.Descripcion_marc = descripcion_marc;
            Obj.Estado_marc      = estado_marc;
            Obj.Fecha_registro   = fecha_registro;

            return Obj.ActualizarMarca(Obj);
        }

        // 4. METODO "ELIMINAR" QUE LLAMA AL METODO ELIMINAR DE LA CLASE DMarca
        public static string EliminarMarca(int id_marca)
        {
            DMarca Obj   = new DMarca();  // Instancia
            Obj.Id_marca = id_marca;

            return Obj.EliminarMarca(Obj);
        }

        // 5. METODO "BUSCAR" QUE LLAMA AL METODO BUSCAR DE LA CLASE DMarca
        public static DataTable BuscarMarca(string buscar)
        {
            DMarca Obj = new DMarca();
            Obj.Textobuscar = buscar;
            return Obj.BuscarMarca(Obj);
        }
    }
}
