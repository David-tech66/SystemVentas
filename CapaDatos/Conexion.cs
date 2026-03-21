using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {                                  //     MY_PC: DESKTOP-RAN058S\\SQLEXPRESS
                                       // PC_SENATI: 10PCPK1A1201A21\\SQLEXPRESS
        public static string cadena = "Data Source = DESKTOP-RAN058S\\SQLEXPRESS;" + 
            "Initial Catalog = db_SistemaVenta;" + 
            "Integrated Security = true; TrustServerCertificate = True;";
    }
}
