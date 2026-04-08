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
            dtProveedor.DataSource = NProveedor.MostrarProveedor();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
        private void frmProveedor_Load_1(object sender, EventArgs e)
        {
            MostrarProveedor();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
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
                if (txtNombre.Text == "" || txtDireccion.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == "" || txtRuc.Text == "" || combEstado.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NProveedor.InsertarProveedor(txtNombre.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtRuc.Text, combEstado.Text);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("No se ha seleccionado ningun registro.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NProveedor.ActualizarProveedor(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtRuc.Text, combEstado.Text);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("No se ha seleccionado ningún registro.","TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult Opcion1;
                    Opcion1 = MessageBox.Show("¿Realmente desea eliminar el registro?", "TechSolution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion1 == DialogResult.OK)
                    {
                        string respuesta = "";
                        respuesta = NProveedor.EliminarProveedor(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dtProveedor.DataSource = NProveedor.BuscarProveedor(txtBuscar.Text);
        }
        // LLAMAMOS A AL METODO BUSCAR PROVEEDOR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void dtProveedor_DoubleClick(object sender, EventArgs e)
        {
            // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
            txtID.Text = dtProveedor.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dtProveedor.CurrentRow.Cells["NOMBRE"].Value.ToString();
            txtDireccion.Text = dtProveedor.CurrentRow.Cells["DIRECCION"].Value.ToString();
            txtCorreo.Text = dtProveedor.CurrentRow.Cells["CORREO"].Value.ToString();
            txtTelefono.Text = dtProveedor.CurrentRow.Cells["TELEFONO"].Value.ToString();
            txtRuc.Text = dtProveedor.CurrentRow.Cells["RUC"].Value.ToString();
            combEstado.Text = dtProveedor.CurrentRow.Cells["ESTADO"].Value.ToString();
        }
    }
}
