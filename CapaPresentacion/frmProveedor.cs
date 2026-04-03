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

        // BOTON REGISTRAR
        private void btnRegistrar_Click(object sender, EventArgs e)
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
        private void btnActualizar_Click(object sender, EventArgs e)
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA DARLE CURVAS SOLO A LOS BORDES SUPERIORES DEL PANEL1
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // 1. Configuración de suavizado para que la curva no se vea "pixelada"
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 2. Definir el radio de la curva y el área del panel
            int borderRadius = 30; // Ajusta este valor para más o menos curva
            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);

            // 3. Crear el camino (Path) personalizado
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // Esquina Superior Izquierda (Curva)
            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);

            // Esquina Superior Derecha (Curva)
            path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);

            // Esquina Inferior Derecha (Recta - simplemente trazamos la línea hasta la esquina)
            path.AddLine(rect.Right, rect.Bottom, rect.Right, rect.Bottom);

            // Esquina Inferior Izquierda (Recta)
            path.AddLine(rect.X, rect.Bottom, rect.X, rect.Bottom);

            path.CloseAllFigures();

            // 4. Aplicar la región al panel para que el fondo se corte
            panel1.Region = new Region(path);

            // 5. Opcional: Dibujar el borde (si quieres una línea de contorno)
            using (Pen pen = new Pen(Color.CadetBlue, 1.5f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // METODO PARA DARLE CURVAS A TODOS LOS BORDES DEL PANEL2
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Definimos el radio de la curva
            int borderRadius = 30;
            float borderThickness = 2f;

            // Creamos la figura con bordes redondeados
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(panel2.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(panel2.Width - borderRadius, panel2.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, panel2.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            // Aplicamos la forma al panel
            panel2.Region = new Region(path);

            // Opcional: Dibujar un borde suave (Antialiasing)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.CadetBlue, borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // METODO PARA DARLE CURVAS SOLO A LOS BORDES INFERIORES DEL PANEL3
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // 1. Configuración de suavizado para que la curva no se vea "pixelada"
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 2. Definir el radio de la curva y el área del panel
            int borderRadius = 30; // Ajusta este valor para más o menos curva (20-40 es ideal)
            Rectangle rect = new Rectangle(0, 0, panel3.Width, panel3.Height);

            // 3. Crear el camino (Path) personalizado
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // Empezamos desde la esquina superior izquierda (Recta)
            path.AddLine(rect.X, rect.Y, rect.X, rect.Y);

            // Esquina Superior Derecha (Recta)
            path.AddLine(rect.Right, rect.Y, rect.Right, rect.Y);

            // Esquina Inferior Derecha (Curva)
            // El arco empieza en 0 grados (derecha) y barre 90 grados hacia abajo
            path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);

            // Esquina Inferior Izquierda (Curva)
            // El arco empieza en 90 grados (abajo) y barre 90 grados hacia la izquierda
            path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);

            path.CloseAllFigures();

            // 4. Aplicar la región al panel para que el fondo se corte
            panel3.Region = new Region(path);

            // 5. Opcional: Dibujar el borde (si quieres una línea de contorno suave)
            // Usamos el color acero #547792 que te gustó
            Color colorBorde = ColorTranslator.FromHtml("#547792");
            using (Pen pen = new Pen(colorBorde, 1.5f))
            {
                e.Graphics.DrawPath(pen, path);
            }
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
