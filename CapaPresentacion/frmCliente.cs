using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// LLAMA A UNA CLASE
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        private void MostrarCliente() 
        {
            dataGridView1.DataSource = CapaNegocio.NCliente.MostrarCliente();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            MostrarCliente();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
