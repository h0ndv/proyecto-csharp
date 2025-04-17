using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp
{
    internal class GestorProductos
    {
        // Lista de productos
        public List<Productos> productos = new List<Productos>();
        public List<Productos> porductosVenta = new List<Productos>();

        // Guardar producto en inventario
        public void GuardarProducto(Productos producto)
        {
            productos.Add(producto);
        }

        // Guardar producto en lista de venta
        public void GuardarProductoVenta(Productos producto)
        {
            porductosVenta.Add(producto);
        }

        // Obtener La lista productos en stock
        public List<Productos> MostrarProductos()
        {
            return productos;
        }

        // Obtener la lista productos en venta
        public List<Productos> MostrarProductosVenta()
        {
            return porductosVenta;
        }
    }
}
