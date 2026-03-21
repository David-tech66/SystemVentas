using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LLAMA A UNA CLASE

using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        public static DataTable MostrarCliente() 
        { 
            return new DCliente().MostrarCliente();
        }
    }
}
