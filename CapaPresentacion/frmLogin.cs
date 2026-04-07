using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDiseño3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtDiseño_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtAcceso_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // BOTON CERRAR 
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        // BOTON INGRESAR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable datos = CapaNegocio.NVendedor.Login(txtUsuario.Text, txtContrasena.Text); // ENVIO LOS PARAMETROS A LA CapaNegocio A SU CLASE     NVendedor  Y SU METODO LOGIN

            if (datos.Rows.Count == 0)  // BUSCA UN RESULTADO EN LA BASE DE DATOS,SÍ ES "0" NO EXISTE
            {
                MessageBox.Show("Usuario o contraseña incorrecto",
                    "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = string.Empty;
                txtContrasena.Text = string.Empty;
                txtUsuario.Focus();
            }
            else  // SI EXISTE EL USUARIO Y LA CONTRASEÑA EN LA BASE DE DATOS, ENTONCES MUESTRO EL FORMULARIO PRINCIPAL
            {
                frmPrincipal principal = new frmPrincipal(); // INSTANCIA EL FORMULARIO PRINCIPAL CAPTURANDO LOS DATOS DEL PROCEDIMIENTO ALMACENADO Y ENVIANDOLOS AL FORMULARIO PRINCIPAL
                principal.id_vendedor      = datos.Rows[0][0].ToString();    // FILA(0) COLUMNA(0)
                principal.primer_apellido  = datos.Rows[0][1].ToString();    // FILA(0) COLUMNA(1)
                principal.segundo_apellido = datos.Rows[0][2].ToString();    // FILA(0) COLUMNA(2)
                principal.acceso           = datos.Rows[0][3].ToString();    // FILA(0) COLUMNA(3)

                principal.Show();   // MOSTRO EL FORMULARIO PRINCIPAL
                this.Hide();    // OCULTO EL FORMULARIO DE LOGIN
            }
        }

        private void combEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
