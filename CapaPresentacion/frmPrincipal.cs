using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        /* VARIABLES GLOBALES
        public string id_empleado = "";
        public string num_doc = "";
        public string ap_paterno = "";
        public string ap_materno = "";
        public string acceso = "";
        */

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCategoria);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            frmCategoria categoria = new frmCategoria();
            categoria.Show();
        }
    }
}
