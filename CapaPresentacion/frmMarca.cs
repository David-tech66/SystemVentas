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
            dtMarca.DataSource = NMarca.MostrarMarca();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA MARCA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
        private void frmMarca_Load_1(object sender, EventArgs e)
        {
            MostrarMarca();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            
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
            txtID.Text = dtMarca.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dtMarca.CurrentRow.Cells["MARCA"].Value.ToString();
            txtDescripcion.Text = dtMarca.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            combEstado.Text = dtMarca.CurrentRow.Cells["ESTADO"].Value.ToString();
            dtFechaRegistro.Text = dtMarca.CurrentRow.Cells["FECHA_REGISTRO"].Value.ToString();
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

        // METODO PARA LIMPIAR LOS CAMPOS DE TEXTO
        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            combEstado.SelectedIndex = -1;
            dtFechaRegistro.Text = "";
        }

        // BOTON REGISTRAR
        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "" || txtDescripcion.Text == "" || combEstado.Text == "" || dtFechaRegistro.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NMarca.InsertarMarca(txtNombre.Text, txtDescripcion.Text, combEstado.Text, dtFechaRegistro.Value);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarMarca();
                        this.Limpiar(); // LLAMAMOS AL METODO LIMPIAR PARA LIMPIAR LOS CAMPOS DE TEXTO
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
                    respuesta = NMarca.ActualizarMarca(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDescripcion.Text, combEstado.Text, dtFechaRegistro.Value);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarMarca();
                        this.Limpiar(); // LLAMAMOS AL METODO LIMPIAR PARA LIMPIAR LOS CAMPOS DE TEXTO DESPUES DE ACTUALIZAR LOS DATOS
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
                    MessageBox.Show("No se ha seleccionado ningún registro.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult Opcion1;
                    Opcion1 = MessageBox.Show("¿Realmente desea eliminar el registro?", "TechSolution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion1 == DialogResult.OK)
                    {
                        string respuesta = "";
                        respuesta = NMarca.EliminarMarca(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.", "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarMarca();
                            this.Limpiar(); // LLAMAMOS AL METODO LIMPIAR PARA LIMPIAR LOS CAMPOS DE TEXTO DESPUES DE ELIMINAR EL REGISTRO
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
            dtMarca.DataSource = NMarca.BuscarMarca(txtBuscar.Text);
        }
        // LLAMAMOS AL METODO BUSCAR MARCA
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            BuscarMarca();
        }

        // METODO PARA CAPTURAR LOS VALORES DE LAS CELDAS DEL DATAGRIDVIEW Y MOSTRARLOS EN LOS TEXTBOX CORRESPONDIENTES
        private void dtMarca_DoubleClick(object sender, EventArgs e)
        {
            if (dtMarca.CurrentRow != null) 
            {
                // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
                txtID.Text = dtMarca.CurrentRow.Cells["ID"].Value.ToString();
                // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
                txtNombre.Text = dtMarca.CurrentRow.Cells["MARCA"].Value.ToString();
                txtDescripcion.Text = dtMarca.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                combEstado.Text = dtMarca.CurrentRow.Cells["ESTADO"].Value.ToString();
                dtFechaRegistro.Text = dtMarca.CurrentRow.Cells["FECHA_REGISTRO"].Value.ToString();
            }
        }
    }
}
