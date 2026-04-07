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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW
        private void MostrarProveedor()
        {
            dataGridView1.DataSource = NProveedor.MostrarProveedor();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            MostrarProveedor();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmProveedor_Load_1(object sender, EventArgs e)
        {

        }

        private void combEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtRuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        // BOTON REGISTRAR
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || txtRuc.Text == "" || txtTelefono.Text == "" || combEstado.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.",
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NProveedor.InsertarProveedor(txtNombre.Text, txtDireccion.Text, txtCorreo.Text, txtRuc.Text, txtTelefono.Text, combEstado.Text);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProveedor();
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
                        "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NProveedor.ActualizarProveedor(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDireccion.Text, txtCorreo.Text, txtRuc.Text, txtTelefono.Text, combEstado.Text);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.",
                            "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProveedor();
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
                        "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult Opcion1;
                    Opcion1 = MessageBox.Show("¿Realmente desea eliminar el registro?", "db_SistemaVenta",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion1 == DialogResult.OK)
                    {
                        string respuesta = "";
                        respuesta = NProveedor.EliminarProveedor(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.",
                                "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarProveedor();
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

        // METODO PARA BUSCAR REGISTROS EN LA TABLA PROVEEDOR
        private void BuscarProveedor()
        {
            dataGridView1.DataSource = NProveedor.BuscarProveedor(txtBuscar.Text);
        }
        // LLAMAMOS A AL METODO BUSCAR PROVEEDOR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProveedor();
        }
    }
}
