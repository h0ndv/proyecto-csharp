using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp
{
    internal class Perifericos
    {
        // Atribituos
        public string nombrePeriferico { set; get; }
        public string ipAdress { set; get; }
        public string macAdress { set; get; }
        public Boolean estado { set; get; }

        // Constructores
        public Perifericos() { }

        public Perifericos(string nombrePeriferico, string ipAdress, string macAdress, Boolean estado)
        {
            this.nombrePeriferico = nombrePeriferico;
            this.ipAdress = ipAdress;
            this.macAdress = macAdress;
            this.estado = estado;
        }
    }
}
