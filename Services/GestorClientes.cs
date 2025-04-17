using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp
{
    internal class GestorClientes
    {
        // Lista de clientes
        public List<Clientes> clientes = new List<Clientes>();

        // Guardar cliente

        public void GuardarCliente(Clientes cliente)
        {
            clientes.Add(cliente);
        }

        // Obtener La lista clientes
        public List<Clientes> MostrarClientes()
        {
            return clientes;
        }
    }
}
