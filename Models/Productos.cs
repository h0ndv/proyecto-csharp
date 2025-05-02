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
        private string nombre;
        private int id_Producto;
        private string tallasProducto;
        private string coloresProducto;
        private int cantidad;
        private int precio;

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

        // Getters y Setters
        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public int GetId_Producto()
        {
            return id_Producto;
        }

        public void SetId_Producto(int id_Producto)
        {
            this.id_Producto = id_Producto;
        }

        public string GetTallasProducto()
        {
            return tallasProducto;
        }

        public void SetTallasProducto(string tallasProducto)
        {
            this.tallasProducto = tallasProducto;
        }

        public string GetColoresProducto()
        {
            return coloresProducto;
        }

        public void SetColoresProducto(string coloresProducto)
        {
           
            this.coloresProducto = coloresProducto;
        }
        public int GetCantidad()
        {
            return cantidad;
        }

        public void SetCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public int GetPrecio()
        {
            return precio;
        }

        public void SetPrecio(int precio)
        {
            this.precio = precio;
        }

    }
}
