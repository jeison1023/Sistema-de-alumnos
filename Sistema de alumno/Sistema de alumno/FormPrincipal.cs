using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private void ExportarDataGridViewACsv(DataGridView dgv, string tipo)
        {
            if (dgv == null)
            {
                MessageBox.Show("No se encontró un DataGridView en el formulario activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv";
            saveFileDialog.FileName = $"{tipo}_exportado_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                //  Cabecera personalizada
                sb.AppendLine("Archivo generado por el Sistema de Gestión de Alumnos");
                sb.AppendLine($"Tipo de datos exportados: {tipo}");
                sb.AppendLine($"Fecha de exportación: {DateTime.Now:dddd, dd MMMM yyyy - HH:mm:ss}");
                sb.AppendLine(); // línea vacía

                //  Encabezados
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    sb.Append(dgv.Columns[i].HeaderText);
                    if (i < dgv.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();

                //  Filas
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            var celda = fila.Cells[i].Value?.ToString().Replace(",", "");
                            sb.Append(celda);
                            if (i < dgv.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                    }
                }

                File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Exportación completada con éxito.", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exportar el DataGridView del formulario activo a un archivo CSV
            {
                Form activeForm = this.ActiveMdiChild;

            if (activeForm is FormAlumnos formAlumnos)
            {
                ExportarDataGridViewACsv(formAlumnos.Controls.OfType<DataGridView>().FirstOrDefault(), "Alumnos");
            }
            else if (activeForm is AreaCalificacion Calificaciones)
            {
                ExportarDataGridViewACsv(Calificaciones.Controls.OfType<DataGridView>().FirstOrDefault(), "Calificaciones");
            }
            else
            {
                MessageBox.Show("No hay un formulario válido activo para exportar.", "Exportación no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }

        private void eliminarAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEliminarAlumno frm = new FormEliminarAlumno();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
    

