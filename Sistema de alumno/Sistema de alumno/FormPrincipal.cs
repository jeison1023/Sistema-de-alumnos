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
    public partial class FormPrincipal : Form
    {
        private int childFormNumber = 0;

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
            Calificacion frm = new Calificacion();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
