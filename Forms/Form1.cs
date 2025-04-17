using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectocsharp
{
    public partial class Form1 : Form
    {
        // Atributo global para saber si el usuario inicio sesion
        public static int session = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;

            if (user == "admin" && password == "admin")
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
                session = 1;
                MessageBox.Show($"Sesion iniciada {session}");
            }
            else
            {
                MessageBox.Show("Usuario o conraseña incorrecto");
            }
        }
    }
}
