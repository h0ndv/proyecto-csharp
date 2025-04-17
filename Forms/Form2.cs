using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectocsharp
{
    public partial class Form2 : Form
    {
        // Instanciar el controlador
        GestorProductos controlador = new GestorProductos();
        GestorClientes controladorClientes = new GestorClientes();
        GestorPerifericos gestorPerifericos = new GestorPerifericos();

        public Form2()
        {
            InitializeComponent();

            
            // Cargar descuentos en comboBox
            string[] descuentos = { "0%", "5%", "10%", "15%", "20%", "25%", "30%", "35%" };
            comboBoxDescuentos.Items.AddRange(descuentos);
            comboBoxDescuentos.SelectedIndex = 0;

            // Cargar perifericos en la tabla
            gestorPerifericos.GenerarEjemplos();
            mostrarPerifericos();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {   
                // Validar si el usuario inicio sesion
                if (Form1.session == 0)
                {
                    MessageBox.Show("Inicia sesion para agregar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar campos
                string validacion = validarCampos();

                if (validacion != null)
                {
                    MessageBox.Show(validacion, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores de los campos
                string nombreProducto = txtNombre.Text;
                int idProducto = int.Parse(txtID.Text);
                string tallasProducto = txtTallas.Text;
                string coloresProducto = txtColores.Text;
                int cantidadProducto = int.Parse(txtCantidad.Text);
                int precioProducto = int.Parse(txtPrecio.Text);

                // Crear objeto tipo producto
                controlador.GuardarProducto(new Productos(nombreProducto, idProducto, tallasProducto, coloresProducto, cantidadProducto, precioProducto));

                // Mostrar producto en tabla
                mostrarProductos();
                limpiarCampos();
                MessageBox.Show("Producto agregado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Manejo de excepciones
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si el usuario inicio sesion
                if (Form1.session == 0)
                {
                    MessageBox.Show("Inicia sesion para agregar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar campos
                string validacion = validarCamposClientes();
                if (validacion != null)
                {
                    MessageBox.Show(validacion, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores de los campos
                string nombreCliente = txtNombreCliente.Text;
                int rutCliente = int.Parse(txtRutCliente.Text);
                int celularCliente = int.Parse(txtCelularCliente.Text);
                string correoCliente = txtCorreoCliente.Text;
                string comprasCliente = txtCompras.Text;
                string preferenciasCliente = txtPreferencias.Text;

                // Crear objeto tipo cliente
                controladorClientes.GuardarCliente(new Clientes(nombreCliente, rutCliente, celularCliente, correoCliente, comprasCliente, preferenciasCliente));

                // Mostrar cliente en la tabla
                mostrarClientes();
                limpiarCampos();
                MessageBox.Show("Cliente agregado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Manejo de excepciones
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si el usuario inicio sesion
                if (Form1.session == 0)
                {
                    MessageBox.Show("Inicia sesion para agregar productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar campos
                string validacion = validarCamposVenta();
                if (validacion != null)
                {
                    MessageBox.Show(validacion, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los valores de los campos
                int idProducto = int.Parse(txtIdVenta.Text);
                int cantidadProducto = int.Parse(txtCantidadVenta.Text);

                // Validar si el producto existe en la lista de inventario
                if (!controlador.productos.Any(p => p.id_Producto == idProducto))
                {
                    MessageBox.Show("El producto no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validad si la cantidad es mayor a la cantidad en la lista de inventario
                var stockProducto = controlador.productos.Find(p => p.id_Producto == idProducto);

                if (stockProducto != null && cantidadProducto > stockProducto.cantidad)
                {
                    MessageBox.Show("La cantidad es mayor a la cantidad en stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Restar producto de la lista de ivnentario
                stockProducto.cantidad -= cantidadProducto;

                // Aplicar descuento al precio del producto si es distinto de 0%
                if (comboBoxDescuentos.SelectedItem.ToString() != "0%")
                {
                    int descuento = int.Parse(comboBoxDescuentos.SelectedItem.ToString().Replace("%", ""));
                    stockProducto.precio -= (stockProducto.precio * descuento) / 100;
                }

                // Crear objeto tipo producto y setear parametros
                Productos producto = new Productos();
                producto.id_Producto = idProducto;
                producto.nombre = stockProducto.nombre;
                producto.tallasProducto = stockProducto.tallasProducto;
                producto.coloresProducto = stockProducto.coloresProducto;
                producto.cantidad = cantidadProducto;
                producto.precio = stockProducto.precio;


                // Agregar producto a la lista de venta
                controlador.GuardarProductoVenta(producto);

                // Mostrar producto en la tabla ventas
                mostrarProductosVenta();
                limpiarCampos();
                MessageBox.Show("Producto vendido", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Manejo de excepciones
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validar campos productos
        public string validarCampos()
        {
            // Diccionario key, value para validar los campos
            var campos = new Dictionary<TextBox, string>
            {
                { txtNombre, "El nombre del producto no puede estar vacio" },
                { txtID, "El ID del producto no puede estar vacio" },
                { txtTallas, "La talla del producto no puede estar vacia" },
                { txtColores, "El color del producto no puede estar vacio" },
                { txtCantidad, "La cantidad del producto no puede estar vacia" },
                { txtPrecio, "El precio del producto no puede estar vacio" }
            };

            // Validar campos vacioss
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Key.Text))
                {
                    return campo.Value;
                }
            }

            // Validaciones para ingresar solo numeros
            if (!int.TryParse(txtID.Text, out _))
            {
                return "Ingresa solo numeros en ID del producto";
            }

            if (!int.TryParse(txtCantidad.Text, out _))
            {
                return "Ingresa solo numeros en la cantidad de productos";
            }

            if (!int.TryParse(txtPrecio.Text, out _))
            {
                return "Ingresa solo numeros en el precio del producto";
            }

            return null;
        }

        // Validar clientes
        public string validarCamposClientes()
        {
            // Diccionario key, value para validar campos vacios
            var campos = new Dictionary<TextBox, string>
            {
                { txtNombreCliente, "El nombre del cliente no puede estar vacio" },
                { txtRutCliente, "El rut del cliente no puede estar vacio" },
                { txtCelularCliente, "El celular del cliente no puede estar vacio" },
                { txtCorreoCliente, "El correo del cliente no puede estar vacio" },
                { txtCompras, "Las compras del cliente no pueden estar vacias" },
                { txtPreferencias, "Las preferencias del cliente no pueden estar vacias" }
            };
            
            // Validar campos vacios
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Key.Text))
                {
                    return campo.Value;
                }
            }

            // Validaciones para ingresar solo numeros
            if (!int.TryParse(txtRutCliente.Text, out _))
            {
                return "Ingresa solo numeros en el rut del cliente";
            }

            if (!int.TryParse(txtCelularCliente.Text, out _))
            {
                return "Ingresa solo numeros en el celular del cliente";
            }
            return null;
        }

        // Validar campos de venta
        public string validarCamposVenta()
        {
            // Diccionario key, value para validar campos vacios
            var campos = new Dictionary<TextBox, string>
            {
                { txtIdVenta, "El ID del producto no puede estar vacio" },
                { txtCantidadVenta, "La cantidad del producto no puede estar vacia" }
            };

            // Validar campos vacios
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Key.Text))
                {
                    return campo.Value;
                }
            }

            // Validaciones para ingresar solo numeros
            if (!int.TryParse(txtIdVenta.Text, out _))
            {
                return "Ingresa solo numeros en el ID del producto";
            }
            if (!int.TryParse(txtCantidadVenta.Text, out _))
            {
                return "Ingresa solo numeros en la cantidad de productos";
            }

            return null;
        }

        // Agregar productos en la tabla DataGridView
        public void mostrarProductos()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = controlador.productos;
            }
        }

        // Agregar clientes en la tabla dataGridView2
        public void mostrarClientes()
        {
            if (dataGridView2 != null)
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = controladorClientes.clientes;
            }
        }

        // Agregar productos en venta a la tabla dataGridView3
        public void mostrarProductosVenta()
        {
            if (dataGridView3 != null)
            {
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = controlador.porductosVenta;
            }
        }

        private void btnTotalVenta_Click(object sender, EventArgs e)
        {
            // Sumar el total del precio de los productos
            int total = 0;
            if (dataGridView3 != null) {
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if (row.Cells["precio"].Value != null)
                    {
                        total += Convert.ToInt32(row.Cells["precio"].Value);
                    }
                }

                MessageBox.Show($"El total de la venta es: {total}", "Total", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerarBoleta_Click(object sender, EventArgs e)
        {
            // Generar boleta con los productos vendidos de la tabla ventas
            string boleta = "========= BOLETA DE VENTA =========\n\n";
            try
            {
                if (dataGridView3 != null)
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (row.Cells["nombre"].Value != null)
                        {
                            boleta += $"{row.Cells["nombre"].Value} - {row.Cells["cantidad"].Value} - {row.Cells["precio"].Value}\n";
                        }
                    }

                    boleta += "\n====================================";
                    MessageBox.Show(boleta, "Boleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpiar la tabla de ventas
                if (dataGridView3 != null)
                {
                    controlador.porductosVenta.Clear();
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = controlador.porductosVenta;
                }

            }

            // Manejo de excepciones
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Selecciona un producto de la lista para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener id del producto selecconado
                int idProducto = (int)dataGridView1.SelectedRows[0].Cells["id_Producto"].Value;

                // Eliminar producto
                var producto = controlador.productos.Find(p => p.id_Producto == idProducto);
                if (producto != null)
                {
                    controlador.productos.Remove(producto);
                    mostrarProductos();
                    MessageBox.Show("Producto eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("El producto no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Manejo de excepciones
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnPeriferico_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            // Verificar que selecciono un periferico de la tabla
            if (dataGridView4.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecciona un periferico de la lista para conectar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el periferico seleccionado y cambiar el estado desconectado a conectado
            var periferico = (Perifericos)dataGridView4.SelectedRows[0].DataBoundItem;
            if (periferico != null)
            {
                if (periferico.estado == false)
                {
                    // Barra de progreso
                    for (int i = 0; i <= 100; i++)
                    {
                        await Task.Delay(25);
                        progressBar1.Value = i;
                    }

                    // Cambiar el estado del periferico a conectado
                    periferico.estado = true;
                    MessageBox.Show($"El periferico {periferico.nombrePeriferico} se ha conectado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El periferico {periferico.nombrePeriferico} ya esta conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void mostrarPerifericos()
        {
            // Añadir perifericos a la lista 
            if (dataGridView4 != null)
            {
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = gestorPerifericos.perifericos;
            }
        }

        private async void btnDesconectar_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            // Verificar si se selecciono un periferico de la tabla
            if (dataGridView4.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Selecciona un periferico de la lista para desconectar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el periferico seleccionado y cambiar el estado conectado a desconectado
            var periferico = (Perifericos)dataGridView4.SelectedRows[0].DataBoundItem;            
            if (periferico != null)
            {
                if (periferico.estado == true)
                {
                    // Barra de progreso
                    for (int i = 0; i <= 100; i++)
                    {
                        await Task.Delay(25);
                        progressBar1.Value = i;
                    }

                    // Cambiar el estado del periferico a desconectado
                    periferico.estado = false;
                    MessageBox.Show($"El periferico {periferico.nombrePeriferico} se ha desconectado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El periferico {periferico.nombrePeriferico} ya esta desconectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("Selecciona un cliente de la lista para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener id del producto selecconado
                int rutCliente = (int)dataGridView2.SelectedRows[0].Cells["rut"].Value;

                // Eliminar producto
                var cliente = controladorClientes.clientes.Find(p => p.rut == rutCliente);
                if (cliente != null)
                {
                    controladorClientes.clientes.Remove(cliente);
                    mostrarProductos();
                    MessageBox.Show($"Cliente {cliente.nombre} eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El Cliente {cliente.nombre} no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Manejo de excepciones
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Limpiar campos
        public void limpiarCampos()
        {
            txtNombre.Clear();
            txtID.Clear();
            txtTallas.Clear();
            txtColores.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtNombreCliente.Clear();
            txtRutCliente.Clear();
            txtCelularCliente.Clear();
            txtCorreoCliente.Clear();
            txtCompras.Clear();
            txtPreferencias.Clear();
            txtIdVenta.Clear();
            txtCantidadVenta.Clear();
        }

        private void btnRealizarEnvio_Click(object sender, EventArgs e)
        {

        }

        // end
    }
}
