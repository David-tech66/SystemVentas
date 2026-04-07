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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW
        private void MostrarCategoria()
        {
            dtCategoria.DataSource = NCategoria.MostrarCategoria();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            MostrarCategoria();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA CAPTURAR LOS VALORES DE LAS CELDAS DEL DATAGRIDVIEW Y MOSTRARLOS EN LOS TEXTBOX CORRESPONDIENTES
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
            txtID.Text = dtCategoria.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dtCategoria.CurrentRow.Cells["CATEGORIA"].Value.ToString();
            txtDescripcion.Text = dtCategoria.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            combEstado.Text = dtCategoria.CurrentRow.Cells["ESTADO"].Value.ToString();
            dtFecha.Text = dtCategoria.CurrentRow.Cells["FECHA"].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void combEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // BOTON ELIMINAR
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún registro.",
                        "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult Opcion1;
                    Opcion1 = MessageBox.Show("¿Realmente desea eliminar el registro?", "TechSolution",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion1 == DialogResult.OK)
                    {
                        string respuesta = "";
                        respuesta = NCategoria.EliminarCategoria(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.",
                                "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarCategoria();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                        "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NCategoria.ActualizarCategoria(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDescripcion.Text, combEstado.Text, dtFecha.Value);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.",
                            "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCategoria();
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

        // BOTON REGISTRAR
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "" || txtDescripcion.Text == "" || combEstado.Text == "" || dtFecha.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.",
                        "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NCategoria.InsertarCategoria(txtNombre.Text, txtDescripcion.Text,
                        combEstado.Text, dtFecha.Value);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.",
                            "TechSolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCategoria();
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

        private void txtID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        // METODO PARA BUSCAR REGISTROS EN LA TABLA CATEGORIA
        private void BuscarCategoria()
        {
            dtCategoria.DataSource = NCategoria.BuscarCategoria(txtBuscar.Text);
        }
        // LLAMAMOS AL METODO BUSCAR CATEGORIA
        private void guna2TextBox1_TextChanged_2(object sender, EventArgs e)
        {
            BuscarCategoria();
        }

        // BOTON CERRAR
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

