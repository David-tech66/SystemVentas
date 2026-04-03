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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CLIENTE EN EL DATAGRIDVIEW
        private void MostrarCliente() 
        {
            dataGridView1.DataSource = NCliente.MostrarCliente();
        }

        // METODO PARA MOSTRAR LOS REGISTROS DE LA TABLA CATEGORIA EN EL DATAGRIDVIEW CUANDO SE CARGUE EL FORMULARIO
        private void frmCliente_Load(object sender, EventArgs e)
        {
            MostrarCliente();
        }

        // BOTON REGISTRAR
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "" || txtApellido.Text == "" || txtCorreo.Text == "" || txtDni.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("Faltan ingresar algunos datos.",
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NCliente.InsertarCliente(txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtDni.Text, txtTelefono.Text);
                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Se insertó de forma correcta el registro.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCliente();
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
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    respuesta = NCliente.ActualizarCliente(Convert.ToInt32(txtID.Text), txtNombre.Text, txtApellido.Text, txtCorreo.Text, txtDni.Text, txtTelefono.Text);

                    if (respuesta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos se actualizaron correctamente.",
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCliente();
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
                        "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult Opcion1;
                    Opcion1 = MessageBox.Show("¿Realmente desea eliminar el registro?", "Sistema de Ventas",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion1 == DialogResult.OK)
                    {
                        string respuesta = "";
                        respuesta = NCliente.EliminarCliente(Convert.ToInt32(txtID.Text));
                        if (respuesta.Equals("OK"))
                        {
                            MessageBox.Show("El registro se eliminó correctamente.",
                                "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarCliente();
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA CAPTURAR LOS VALORES DE LAS CELDAS DEL DATAGRIDVIEW Y MOSTRARLOS EN LOS TEXTBOX CORRESPONDIENTES
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // CAPTURAMOS EL VALOR DE LA COLUMNA EN UN TextBox LLAMADO txtID
            txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            // CAPTURA EL VALOR DE LA COLUMNA (NOMBRE) EN UN TextBox LLAMADO txtNombre
            txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells["APELLIDO"].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells["CORREO"].Value.ToString();
            txtDni.Text = dataGridView1.CurrentRow.Cells["DNI"].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA DARLE CURVAS A TODOS LOS BORDES DEL PANEL1
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Definimos el radio de la curva
            int borderRadius = 30;
            float borderThickness = 2f;

            // Creamos la figura con bordes redondeados
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(panel1.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(panel1.Width - borderRadius, panel1.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, panel1.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            // Aplicamos la forma al panel
            panel1.Region = new Region(path);

            // Opcional: Dibujar un borde suave (Antialiasing)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.CadetBlue, borderThickness))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // BORDES CURVADOS PARA EL PANEL INFERIOR
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // 1. Configuración de suavizado para que la curva no se vea "pixelada"
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 2. Definir el radio de la curva y el área del panel
            int borderRadius = 30; // Ajusta este valor para más o menos curva (20-40 es ideal)
            Rectangle rect = new Rectangle(0, 0, panel2.Width, panel2.Height);

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
            panel2.Region = new Region(path);

            // 5. Opcional: Dibujar el borde (si quieres una línea de contorno suave)
            // Usamos el color acero #547792 que te gustó
            Color colorBorde = ColorTranslator.FromHtml("#547792");
            using (Pen pen = new Pen(colorBorde, 1.5f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // BORDES PARA EL PANEL SUPERIOR
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            // 1. Configuración de suavizado para que la curva no se vea "pixelada"
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 2. Definir el radio de la curva y el área del panel
            int borderRadius = 30; // Ajusta este valor para más o menos curva
            Rectangle rect = new Rectangle(0, 0, panel4.Width, panel4.Height);

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
            panel4.Region = new Region(path);

            // 5. Opcional: Dibujar el borde (si quieres una línea de contorno)
            using (Pen pen = new Pen(Color.CadetBlue, 1.5f))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        // METODO PARA BUSCAR REGISTROS EN LA TABLA CLIENTE
        private void BuscarCliente()
        {
            dataGridView1.DataSource = NCliente.BuscarCliente(txtBuscar.Text);
        }
        // LLAMAMOS AL METODO BUSCAR CLIENTE
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarCliente();
        }
    }
}
