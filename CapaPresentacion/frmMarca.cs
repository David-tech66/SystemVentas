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
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA MARCA EN EL DATAGRIDVIEW
        private void MostrarMarca()
        {
            dataGridView1.DataSource = NMarca.MostrarMarca();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA MARCA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
        private void frmMarca_Load(object sender, EventArgs e)
        {
            MostrarMarca();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // METODO PARA CAPTURAR LOS VALORES DE LAS CELDAS DEL DATAGRIDVIEW Y MOSTRARLOS EN LOS TEXTBOX CORRESPONDIENTES
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
            txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dataGridView1.CurrentRow.Cells["MARCA"].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            combEstado.Text = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
            dtFechaRegistro.Text = dataGridView1.CurrentRow.Cells["FECHA_REGISTRO"].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        // BOTON REGISTRAR
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "" || txtDescripcion.Text == "" || combEstado.Text == "" || dtFechaRegistro.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.",
                        "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NMarca.InsertarMarca(txtNombre.Text, txtDescripcion.Text,
                        combEstado.Text, dtFechaRegistro.Value);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.",
                            "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarMarca();
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
                    respuesta = NMarca.ActualizarMarca(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDescripcion.Text,
                        combEstado.Text, dtFechaRegistro.Value);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.",
                            "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarMarca();
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
                        respuesta = NMarca.EliminarMarca(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.",
                                "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarMarca();
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

        // METODO PARA BUSCAR REGISTROS EN LA TABLA MARCA
        private void BuscarMarca()
        {
            dataGridView1.DataSource = NMarca.BuscarMarca(txtBuscar.Text);
        }
        // LLAMAMOS AL METODO BUSCAR MARCA
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            BuscarMarca();
        }
    }
}
