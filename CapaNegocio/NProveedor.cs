using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProveedor
    {
        // METODO "MOSTRAR" QUE LLAMA AL METODO MOSTRAR DE LA CLASE DProveedor
        public static DataTable MostrarProveedor()
        {
            return new DProveedor().MostrarProveedor();
        }

        // METODO "INSERTAR" QUE LLAMA AL METODO INSERTAR DE LA CLASE DProveedor
        public static string InsertarProveedor(string nombre_prov, string dire_prov, string correo_prov, string telf_prov, string ruc, string estado_prov)
        {
            DProveedor Obj  = new DProveedor();
            Obj.Nombre_prov = nombre_prov;
            Obj.Dire_prov   = dire_prov;
            Obj.Correo_prov = correo_prov;
            Obj.Telf_prov   = telf_prov;
            Obj.Ruc         = ruc;
            Obj.Estado_prov = estado_prov;

            return Obj.InsertarProveedor(Obj);
        }

        // METODO "ACTUALIZAR" QUE LLAMA AL METODO ACTUALIZAR DE LA CLASE DProveedor
        public static string ActualizarProveedor(int id_proveedor, string nombre_prov, string dire_prov, string correo_prov, string telf_prov, string ruc, string estado_prov)
        {
            DProveedor Obj   = new DProveedor();
            Obj.Id_proveedor = id_proveedor;
            Obj.Nombre_prov  = nombre_prov;
            Obj.Dire_prov    = dire_prov;
            Obj.Correo_prov  = correo_prov;
            Obj.Telf_prov    = telf_prov;
            Obj.Estado_prov  = estado_prov;

            return Obj.ActualizarProveedor(Obj);
        }

        // METODO "ELIMINAR" QUE LLAMA AL METODO ELIMINAR DE LA CLASE DProveedor
        public static string EliminarProveedor(int id_proveedor)
        {
            DProveedor Obj = new DProveedor();  // Instancia
            Obj.Id_proveedor = id_proveedor;

            return Obj.EliminarProveedor(Obj);
        }

        // 5. METODO "BUSCAR" QUE LLAMA AL METODO BUSCAR DE LA CLASE DProveedor
        public static DataTable BuscarProveedor(string buscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.Textobuscar = buscar;
            return Obj.BuscarProveedor(Obj);
        }
    }
}
