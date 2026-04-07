using CapaNegocio;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CLIENTE EN EL DATAGRIDVIEW
        private void MostrarCliente() 
        {
            dataGridView1.DataSource = NCliente.MostrarCliente();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA CAPTURAR LOS VALORES DE LAS CELDAS DEL DATAGRIDVIEW Y MOSTRARLOS EN LOS TEXTBOX CORRESPONDIENTES
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
            txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells["APELLIDO"].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells["CORREO"].Value.ToString();
            txtDni.Text = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // BOTON REGISTRAR
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "" || txtApellido.Text == "" || txtCorreo.Text == "" || txtDni.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.",
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NCliente.InsertarCliente(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtDni.Text, txtTelefono.Text);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCliente();
                    }
                    else
                    {
                        MessageBox.Show(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        // BOTON ACTUALIZAR
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtID.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningun registro.",
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NCliente.ActualizarCliente(Convert.ToInt32(txtID.Text), txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtDni.Text, txtTelefono.Text);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCliente();
                    }
                    else
                    {
                        MessageBox.Show(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        // BOTON ELIMINAR
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún registro.",
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult Opcion1;
                    Opcion1 = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Ventas",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion1 == DialogResult.OK)
                    {
                        string respuesta = "";
                        respuesta = NCliente.EliminarCliente(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.",
                                "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarCliente();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // BOTON CERRAR
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // METODO PARA BUSCAR REGISTROS EN LA TABLA CLIENTE
        private void BuscarCliente()
        {
            dataGridView1.DataSource = NCliente.BuscarCliente(txtBuscar.Text);
        }
        // LLAMAMOS AL METODO BUSCAR CLIENTE
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            BuscarCliente();
        }
    }
}
