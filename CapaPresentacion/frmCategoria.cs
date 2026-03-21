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
        private void MostrarCategoria() 
        {
            dataGridView1.DataSource = NCategoria.MostrarCategoria();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try 
            { 
                string respuesta = "";
                if (txtNombre.Text == "" || txtDescripcion.Text == "" || combEstado.Text == "" || dtFecha.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.",
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    respuesta = NCategoria.InsertarCategoria(txtNombre.Text, txtDescripcion.Text,
                        combEstado.Text, dtFecha.Value);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            MostrarCategoria();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
            txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
            combEstado.Text = dataGridView1.CurrentRow.Cells["ESTADO"].Value.ToString();
            dtFecha.Text = dataGridView1.CurrentRow.Cells["FECHA"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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
                    respuesta = NCategoria.ActualizarCategoria(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDescripcion.Text,
                        combEstado.Text, dtFecha.Value);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

