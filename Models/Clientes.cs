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
        private string nombre;
        private int rut;
        private int celular;
        private string correo;
        private string compras;
        private string preferencias;

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

        // Getters y Setters
        public string GetNombre()
        {
            return nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public int GetRut()
        {
            return rut;
        }
        public void SetRut(int rut)
        {
            this.rut = rut;
        }
        public int GetCelular()
        {
            return celular;
        }
        public void SetCelular(int celular)
        {
            this.celular = celular;
        }
        public string GetCorreo()
        {
            return correo;
        }
        public void SetCorreo(string correo)
        {
            this.correo = correo;
        }
        public string GetCompras()
        {
            return compras;
        }
        public void SetCompras(string compras)
        {
            this.compras = compras;
        }
        public string GetPreferencias()
        {
            return preferencias;
        }
        public void SetPreferencias(string preferencias)
        {
            this.preferencias = preferencias;
        }
    }
}
