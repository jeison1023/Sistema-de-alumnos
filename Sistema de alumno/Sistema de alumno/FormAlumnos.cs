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
    public partial class FormAlumnos : Form
    {
        public FormAlumnos()
        {
            InitializeComponent();
            IniciaColmna();
        }
        private void IniciaColmna()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Matrcula";
            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[2].Name = "Apellido"; 
            dataGridView1.Columns[3].Name = "Edad";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bnRegistrar_Click(object sender, EventArgs e)
        {
            string[] filas = new string[]
            {
                txtmatricula.ToString (),
                txtnombre.Text,
                txtapellido.Text,
                txtedad.Text,
               
            };

            dataGridView1.Rows.Add(filas);

              
        }
    }
}
