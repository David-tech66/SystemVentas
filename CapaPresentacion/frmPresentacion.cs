using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = "Data Source = 10PCPK1A1201A21\\SQLEXPRESS;" + 
                "Initial Catalog = db_SistemaVenta;" + 
                "Integrated Security = True; TrustServerCertificate = True;";
            
            SqlConnection cn = new SqlConnection(cadena);

            try { cn.Open(); MessageBox.Show("Conexion Exitosa...");  } 
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
