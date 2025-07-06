using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_alumno
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (txtUsuario.Text == "admin" && txtClave.Text == "1234")
                {
                    FormPrincipal main = new FormPrincipal();
                    main.Show();
                    this.Hide(); // Oculta el formulario de login
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
        }
    }
}
