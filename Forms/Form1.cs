using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectocsharp.Models;

namespace proyectocsharp
{
    public partial class Form1 : Form
    {
        // Atributo global para saber si el usuario inicio sesion
        public static int session = 0;

        // Instanciar la clase GestorUsuarios
        GestorUsuarios gestorUsuarios = new GestorUsuarios();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los campos
                if (validarCamposVacios() != null)
                {
                    MessageBox.Show(validarCamposVacios(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string usuario = textBox1.Text;
                string contraseña = textBox2.Text;

                // Crear objeto tipo usuario
                Usuarios usuarios = new Usuarios(usuario, contraseña);

                // Validar el usuario en la base de datos
                string validarUsuario = gestorUsuarios.validarUsuario(usuarios);
                if (validarUsuario != null)
                {
                    MessageBox.Show(validarUsuario, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si el usuario existe, abrir el dashboard y ocultar el formulario de login
                Form2 dashboard = new Form2();
                dashboard.Show();
                this.Hide();
                session = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string validarCamposVacios()
        {
            Dictionary<string, string> campos = new Dictionary<string, string>
            {
                { "Usuario", textBox1.Text },
                { "Contraseña", textBox2.Text }
            };

            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Value))
                {
                    return $"El campo {campo.Key} no puede estar vacio";
                }
            }

            return null;
        }
    }
}
