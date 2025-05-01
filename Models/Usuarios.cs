using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectocsharp.Models
{
    internal class Usuarios
    {
        private string usuario;
        private string contraseña;


        public Usuarios(string usuario, string contraseña)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
        }

        // Getters y Setters
        public string GetUsuario()
        {
            return usuario;
        }

        public void SetUsuario(string usuario)
        {
            this.usuario = usuario;
        }

        public string GetContraseña()
        {
            return contraseña;
        }

        public void SetContraseña(string contraseña)
        {
            this.contraseña = contraseña;
        }
    }
}
