using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp
{
    internal class Productos
    {
        // Atributos
        public string nombre { set; get; }
        public int id_Producto { set; get; }
        public string tallasProducto { set; get; }
        public string coloresProducto { set; get; }
        public int cantidad { set; get; }
        public int precio { set; get; }

        // Constructores
        public Productos() { }
        public Productos(string nombre, int id_Producto, String tallasProducto, String coloresProducto, int cantidad, int precio)
        {
            this.nombre = nombre;
            this.id_Producto = id_Producto;
            this.tallasProducto = tallasProducto;
            this.coloresProducto = coloresProducto;
            this.cantidad = cantidad;
            this.precio = precio;
        }
    }
}
