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
    public partial class frmVenta : Form
    {
        private DataTable dtDetalle;   // VARIABLE GLOBAL

        public frmVenta()
        {
            InitializeComponent();
        }

        private void RellenarComboCliente()
        {
            //combCliente.DataSource = NCliente.MostrarClientes();
            //cbCliente.ValueMember = "id_cliente";
            //combCliente.DisplayMember = "nombre_cliente";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // BOTON CERRAR
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // METODO CREAR TABLA DETALLE DE VENTA
        private void crearTabla() 
        { 
            //dtDetalle = new DataTable("Detalle");
            //dtDetalle.Columns.Add("id_venta", System.Type.GetType("System.Int32"));
            //dtDetalle.Columns.Add("id_producto1", System.Type.GetType("System.Int32"));
            //dtDetalle.Columns.Add("cantidad_unitaria", System.Type.GetType("System.Int32"));
            //dtDetalle.Columns.Add("subtotal_venta", System.Type.GetType("System.Decimal"));
            //dtDetalle.Columns.Add("vuelto", System.Type.GetType("System.Decimal"));
            //// AGREGAMOS LAS COLUMNAS AL DATAGRIDVIEW LLAMADO: dtDetalleVenta
            //dtDetalleVenta.DataSource = dtDetalleVenta;

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //idProducto.Text = dtProductos.Text.CurrentRow.Cells["ID"].Value.ToString();
            //txtPrecio.Text = Convert.ToDecimal(dtProductos.Text.CurrentRow.Cells["Precio"].Value).ToString();
            //txtCantidad.Focus();
        }

        // BOTON AGREGAR PRODUCTO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // VALIDAR SI ALGUN CAMPO ESTA VACIO
            //    if (txtCantidad.Text == "" || txtPrecio.Text == "" || idProducto.Text == "")
            //    {
            //        // ENVIA UNA ALERTA EN PANTALLA
            //        MessageBox.Show("Debe ingresar un producto, precio y cantidad", "Error al agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else  // CASO CONTRARIO
            //    {
            //        bool registrar = true;
            //        // EVALUAR SI EL PRODUCTO YA ESTA EN LA LISTA DETALLE DE VENTA
            //        foreach (DataRow dr in dtDetalleVenta.Rows)  // RECORRE LA LINEA POR LINEA EN EL DATAGRIDVIEW DETALLE DE VENTA
            //        {
            //            if (Convert.ToInt32(dr["id_producto"]) == Convert.ToInt32(idProducto.Text))  // SI EL ID DEL PRODUCTO YA ESTA EN LA LISTA DETALLE DE VENTA
            //            {
            //                registrar = false;  // PONER EN FALSE EL RESTRAR
            //                MessageBox.Show("El producto ya se encuentra en la lista detalle de venta", "Error al agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStock, Text))   // AGREGA PRODUCTO  
            //        {
            //            DataRow row = dtDetalle.NewRow();  // CREA UNA NUEVA FILA

            //            row["id_producto"] = Convert.ToInt32(idProducto.Text);
            //            row["cantidad_unitaria"] = Convert.ToInt32(txtCantidad.Text);
            //            row["subtotal_venta"] = Convert.ToDecimal(txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text);
            //        }
            //        else 
            //        { 
            //            MessageBox.Show("La cantidad ingresada supera el stock disponible", "Error al agregar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
