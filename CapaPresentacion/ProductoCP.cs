using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class ProductoCP : Form
    {
        public ProductoCP()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Limpiar el grid
            dgvProductos.DataSource = null;

            // Leer descripcion a buscar
            string desBusqueda = txtProductoBuscar.Text;

            // Instanciar capa negocio
            ProductoCN productoCN = new ProductoCN();

            // Buscar con metodo de capa negocio
            List<ProductoCE> productosCE = productoCN.buscarDescripcion(desBusqueda);

            // Insertar a grid
            dgvProductos.DataSource = productosCE;

            FormatearGrid();


        }
        private void FormatearGrid()
        {
            // Ajustar columnas y celdas
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            // Desactivar edicion
            dgvProductos.AllowUserToAddRows = false;

            // Restringir solo lectura de celda
            dgvProductos.ReadOnly = false;
        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                // Recojer fila seleccionada
                DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];

                // Recoger los valores
                int id = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                string descripcion = Convert.ToString(filaSeleccionada.Cells["Descripcion"].Value);
                string categoria = Convert.ToString(filaSeleccionada.Cells["Categoria"].Value);
                double precio = Convert.ToDouble(filaSeleccionada.Cells["Precio"].Value);

                txtId.Text = id.ToString();
                txtDescripcion.Text = descripcion;
                txtCategoria.Text = categoria;
                txtPrecio.Text = precio.ToString();
                
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            bool verificar = char.IsNumber(letra) || char.IsControl(letra) || letra == '.';
            if (verificar)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = char.ToUpper(e.KeyChar);
            e.KeyChar = letra;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = char.ToUpper(e.KeyChar);
            e.KeyChar = letra;
        }
        private void limpiarFormulario()
        {
            txtCategoria.Text = "";
            txtId.Text = "0";
            txtPrecio.Text = "0";
            txtDescripcion.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int idIncial = Convert.ToInt32(txtId.Text);
            if (idIncial == 0)
            {
                if (verificarProducto())
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string descripcion = txtDescripcion.Text;
                    string categoria = txtCategoria.Text;
                    double precio = Convert.ToDouble(txtPrecio.Text);

                    ProductoCE productoCE = new ProductoCE(id, descripcion, categoria, precio);

                    ProductoCN productoCN = new ProductoCN();

                    int idNuevo = productoCN.insertar(productoCE);

                    txtId.Text = idNuevo.ToString();
                }
                else
                {
                    MessageBox.Show("No relleno los espacios correctamente!");
                }
                
               
            }
            else
            {
                MessageBox.Show("No se puede guardar el producto");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idInicial = Convert.ToInt32(txtId.Text);
            if (idInicial == 0)
            {
                MessageBox.Show("¡El Id es 0!");
            }
            else
            {
                if (verificarProducto())
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string descripcion = txtDescripcion.Text;
                    string categoria = txtCategoria.Text;
                    double precio = Convert.ToDouble(txtPrecio.Text);

                    ProductoCE productoCE = new ProductoCE(id, descripcion, categoria, precio);

                    ProductoCN productoCN = new ProductoCN();

                    int filasAfectadas = productoCN.actualizar(productoCE);

                    MessageBox.Show($"{filasAfectadas} filas afectadas");
                    limpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No relleno los espacios correctamente!");
                }
                

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idInicial = Convert.ToInt32(txtId.Text);
            if (idInicial == 0)
            {
                MessageBox.Show("¡El Id es 0!");
            }
            else
            {
                if (verificarProducto())
                {
                    int id = Convert.ToInt32(txtId.Text);
                    string descripcion = txtDescripcion.Text;
                    string categoria = txtCategoria.Text;
                    double precio = Convert.ToDouble(txtPrecio.Text);

                    ProductoCE productoCE = new ProductoCE(id, descripcion, categoria, precio);

                    ProductoCN productoCN = new ProductoCN();

                    int filasAfectadas = productoCN.eliminar(productoCE);

                    MessageBox.Show($"{filasAfectadas} filas afectadas");
                    limpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No relleno los espacios correctamente!");
                }
                

            }
        }
        private bool verificarProducto()
        {
            int numCategoria = txtCategoria.Text.Length;
            int numDescripcion = txtCategoria.Text.Length;
            bool verificar = numCategoria > 0 && numDescripcion > 0;
            return verificar;
        }
    }
}
