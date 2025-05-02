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
        private string nombrePeriferico;
        private string ipAdress;
        private string macAdress;
        private Boolean estado;

        // Constructores
        public Perifericos() { }

        public Perifericos(string nombrePeriferico, string ipAdress, string macAdress, Boolean estado)
        {
            this.nombrePeriferico = nombrePeriferico;
            this.ipAdress = ipAdress;
            this.macAdress = macAdress;
            this.estado = estado;
        }

        // Getters y Setters
        public string GetNombrePeriferico()
        {
            return nombrePeriferico;
        }

        public void SetNombrePeriferico(string nombrePeriferico)
        {
            this.nombrePeriferico = nombrePeriferico;
        }

        public string GetIpAdress()
        {
            return ipAdress;
        }

        public void SetIpAdress(string ipAdress)
        {
            this.ipAdress = ipAdress;
        }

        public string GetMacAdress()
        {
            return macAdress;
        }

        public void SetMacAdress(string macAdress)
        {
            this.macAdress = macAdress;
        }

        public Boolean GetEstado()
        {
            return estado;
        }

        public void SetEstado(Boolean estado)
        {
            this.estado = estado;
        }
    }
}
