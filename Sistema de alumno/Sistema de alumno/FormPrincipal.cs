using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_alumno
{
    
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        private void nuevoAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlumnos frm = new FormAlumnos();
            frm.MdiParent = this;
            frm.Show();


        }

        private void claficacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AreaCalificacion frm = new AreaCalificacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void elimininarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                // Mostrar un cuadro de diálogo de confirmación 

                {
                    DialogResult resultado = MessageBox.Show(
                        "¿Estás seguro que deseas cerrar?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        Application.Exit();  // Cierra toda la aplicación
                    }
                }


            }
        }
    }
}
    

