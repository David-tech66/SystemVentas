using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NVendedor
    {
        public static DataTable Login(string usuario, string contrasena)
        {
            DVendedor Obj = new DVendedor();
            Obj.Usuario = usuario;
            Obj.Contrasena = contrasena;
            return Obj.Login(Obj);
        }
    }
}
