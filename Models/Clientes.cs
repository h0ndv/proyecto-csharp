using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp
{
    internal class Clientes
    {
        // Atributos
        public string nombre { set; get; }
        public int rut { set; get; }
        public int celular { set; get; }
        public string correo { set; get; }
        public string compras { set; get; }
        public string preferencias { set; get; }

        // Constructores
        public Clientes() { }

        public Clientes(string nombre, int rut, int celular, string correo, string compras, string preferencias)
        {
            this.nombre = nombre;
            this.rut = rut;
            this.celular = celular;
            this.correo = correo;
            this.compras = compras;
            this.preferencias = preferencias;
        }
    }
}
