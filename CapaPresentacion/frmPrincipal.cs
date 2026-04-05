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
    public partial class frmPrincipal : Form
    {
        /* VARIABLES GLOBALES
        public string id_empleado = "";
        public string num_doc = "";
        public string ap_paterno = "";
        public string ap_materno = "";
        public string acceso = "";
        */

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            // 1. Limpiamos el panel de cualquier control previo (otros formularios)
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.Clear();
            }

            // 2. Configuraciones para INTEGRAR el formulario
            formularioHijo.TopLevel = false;            // IMPORTANTE: Le quita el comportamiento de ventana independiente
            formularioHijo.FormBorderStyle = FormBorderStyle.None; // Quita la barra de título, bordes y botones (X, _, [])
            formularioHijo.Dock = DockStyle.Fill;       // Obliga al formulario a estirarse al tamaño del panel

            // 3. Agregamos el formulario al panel
            this.pnlContenedor.Controls.Add(formularioHijo);
            this.pnlContenedor.Tag = formularioHijo;    // Opcional: Para guardar una referencia

            // 4. Lo mostramos y lo traemos al frente
            formularioHijo.Show();
            formularioHijo.BringToFront();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        // BOTON VENTAS PARA ABRIR EL FORMULARIO DE VENTA
        private void btnVenta_Click_1(object sender, EventArgs e)
        {
            //Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmVenta);
            //if (frm != null)
            //{
            //    frm.BringToFront();
            //    return;
            //}
            //frmVenta venta = new frmVenta();
            //venta.Show();
            AbrirFormularioEnPanel(new frmVenta());
        }

        // BOTON PRODUCTOS PARA ABRIR EL FORMULARIO DE PRODUCTO
        private void btnProducto_Click_1(object sender, EventArgs e)
        {
            //Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProducto);
            //if (frm != null)
            //{
            //    frm.BringToFront();
            //    return;
            //}
            //frmProducto producto = new frmProducto();
            //producto.Show();
            AbrirFormularioEnPanel(new frmProducto());
        }

        // BOTON CATEGORIAS PARA ABRIR EL FORMULARIO DE CATEGORIA
        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            //Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCategoria);
            //if (frm != null)
            //{
            //    frm.BringToFront();
            //    return;
            //}
            //frmCategoria categoria = new frmCategoria();
            //categoria.Show();

            AbrirFormularioEnPanel(new frmCategoria());
        }

        // BOTON MARCAS PARA ABRIR EL FORMULARIO DE MARCA
        private void btnMarca_Click(object sender, EventArgs e)
        {
            //Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMarca);
            //if (frm != null)
            //{
            //    frm.BringToFront();
            //    return;
            //}
            //frmMarca marca = new frmMarca();
            //marca.Show();
            AbrirFormularioEnPanel(new frmMarca());
        }

        // BOTON CLIENTES PARA ABRIR EL FORMULARIO DE CLIENTE
        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            //Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCliente);
            //if (frm != null)
            //{
            //    frm.BringToFront();
            //    return;
            //}
            //frmCliente cliente = new frmCliente();
            //cliente.Show();
            AbrirFormularioEnPanel(new frmCliente());
        }

        // BOTON PROVEEDORES PARA ABRIR EL FORMULARIO DE PROVEEDOR
        private void btnProveedor_Click_1(object sender, EventArgs e)
        {
            //Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedor);
            //if (frm != null)
            //{
            //    frm.BringToFront();
            //    return;
            //}
            //frmProveedor proveedor = new frmProveedor();
            //proveedor.Show();
            AbrirFormularioEnPanel(new frmProveedor());
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
