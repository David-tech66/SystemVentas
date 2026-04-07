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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void MostrarProducto()
        {
            dtProducto.DataSource = NProducto.MostrarProducto();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            MostrarProducto();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA BUSCAR REGISTROS EN LA TABLA CATEGORIA
        private void BuscarProducto()
        {
            dtProducto.DataSource = NProducto.BuscarProducto(txtBuscar.Text);
        }
        // LLAMAMOS AL METODO BUSCAR CATEGORIA
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        // BOTON REGISTRAR  
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string respuesta = "";
            //    if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtPrecio.Text == "" || dtFechaIngreso.Text == "")
            //    {
            //        MessageBox.Show("Faltan ingresar algunos datos.",
            //            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        respuesta = NProducto.InsertarProducto(txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, dtFechaIngreso.Value);
            //        if (respuesta.Equals("OK"))
            //        {
            //            MessageBox.Show("Se insertó de forma correcta el registro.",
            //                "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            MostrarProducto();
            //        }
            //        else
            //        {
            //            MessageBox.Show(respuesta);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        // BOTON ACTUALIZAR
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string respuesta = "";
            //    if (txtID.Text == "")
            //    {
            //        MessageBox.Show("No se ha seleccionado ningun registro.",
            //            "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        respuesta = NProducto.ActualizarProducto(Convert.ToInt32(txtID.Text), txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, dtFechaIngreso.Value);

            //        if (respuesta.Equals("OK"))
            //        {
            //            MessageBox.Show("Los datos se actualizaron correctamente.",
            //                "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            MostrarProducto();
            //        }
            //        else
            //        {
            //            MessageBox.Show(respuesta);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        // BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
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
                        respuesta = NProducto.EliminarProducto(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.",
                                "db_SistemaVenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarProducto();
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

        private void dtProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
