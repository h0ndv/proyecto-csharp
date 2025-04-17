using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp
{
    internal class GestorPerifericos
    {
        // Lista de Perifericos
        public List<Perifericos> perifericos = new List<Perifericos>();

        // Guardar Periferico
        public void GuardarPeriferico(Perifericos periferico)
        {
            perifericos.Add(periferico);
        }

        // Obtener La lista de Perifericos
        public List<Perifericos> MostrarPerifericos()
        {
            return perifericos;
        }

        // Ejemplos de perifericos
        public void GenerarEjemplos()
        {
            // Crear perifericos de ejemplo
            Perifericos impresora1 = new Perifericos("Impresora HP", "192.168.1.100", "00:1B:44:11:3A:B7", false);
            Perifericos impresora2 = new Perifericos("Impresora Epson", "192.168.1.101", "00:1A:2B:3C:4D:5E", false);
            Perifericos impresora3 = new Perifericos("Impresora Cannon", "192.168.1.102", "E4:8D:8C:B7:C9:1A", false);

            // Guardar los perifericos en la lista
            GuardarPeriferico(impresora1);
            GuardarPeriferico(impresora2);
            GuardarPeriferico(impresora3);
        }
    }
}
