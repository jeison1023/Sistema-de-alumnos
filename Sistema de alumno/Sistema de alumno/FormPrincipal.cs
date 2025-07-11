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

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas guardar como PDF?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    //  Mostrar diálogo para elegir ubicación y nombre del archivo
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Title = "Guardar informe PDF";
                    saveDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    saveDialog.FileName = "Calificaciones_Alumnos.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaArchivo = saveDialog.FileName;

                        iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                        doc.Open();

                        //  Encabezado
                        iTextSharp.text.Font tituloFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_BOLD, 18, iTextSharp.text.BaseColor.BLUE);
                        doc.Add(new iTextSharp.text.Paragraph("INFORME DE CALIFICACIONES Y ALUMNOS", tituloFont));
                        doc.Add(iTextSharp.text.Chunk.NEWLINE);

                        //  CALIFICACIONES
                        iTextSharp.text.Font subtituloFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.BaseColor.BLACK);
                        doc.Add(new iTextSharp.text.Paragraph("📘 CALIFICACIONES", subtituloFont));
                        doc.Add(iTextSharp.text.Chunk.NEWLINE);

                        iTextSharp.text.pdf.PdfPTable tablaCalificaciones = new iTextSharp.text.pdf.PdfPTable(12);
                        tablaCalificaciones.WidthPercentage = 100;

                        string[] encabezados1 = {
                    "Matrícula", "Nombre", "Apellido", "Materia", "Examen",
                    "C1", "C2", "C3", "C4", "Total", "Clasificación", "Estado"
                };

                        foreach (string texto in encabezados1)
                        {
                            var celda = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(texto,
                                iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10)))
                            {
                                BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                            };
                            tablaCalificaciones.AddCell(celda);
                        }

                        foreach (var c in AreaCalificacion.ListaCalificaciones)
                        {
                            tablaCalificaciones.AddCell(c.MatriculaAlumno);
                            tablaCalificaciones.AddCell(c.NombreAlumno);
                            tablaCalificaciones.AddCell(c.ApellidoAlumno);
                            tablaCalificaciones.AddCell(c.Materia);
                            tablaCalificaciones.AddCell(c.Examen);
                            tablaCalificaciones.AddCell(c.Calificacion1.ToString());
                            tablaCalificaciones.AddCell(c.Calificacion2.ToString());
                            tablaCalificaciones.AddCell(c.Calificacion3.ToString());
                            tablaCalificaciones.AddCell(c.Calificacion4.ToString());
                            tablaCalificaciones.AddCell(c.TotalCalificacion.ToString());
                            tablaCalificaciones.AddCell(c.Clasificacion);
                            tablaCalificaciones.AddCell(c.Estado);
                        }

                        doc.Add(tablaCalificaciones);
                        doc.Add(iTextSharp.text.Chunk.NEWLINE);

                        //  ALUMNOS
                        doc.Add(new iTextSharp.text.Paragraph("📗 DATOS DE ALUMNOS", subtituloFont));
                        doc.Add(iTextSharp.text.Chunk.NEWLINE);

                        iTextSharp.text.pdf.PdfPTable tablaAlumnos = new iTextSharp.text.pdf.PdfPTable(3);
                        tablaAlumnos.WidthPercentage = 70;

                        string[] encabezados2 = { "Matrícula", "Nombre", "Apellido" };

                        foreach (string texto in encabezados2)
                        {
                            var celda = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(texto,
                                iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10)))
                            {
                                BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                            };
                            tablaAlumnos.AddCell(celda);
                        }

                        foreach (var a in FormAlumnos.ListaAlumnos)
                        {
                            tablaAlumnos.AddCell(a.Matricula);
                            tablaAlumnos.AddCell(a.Nombre);
                            tablaAlumnos.AddCell(a.Apellido);
                        }

                        doc.Add(tablaAlumnos);
                        doc.Close();

                        MessageBox.Show("PDF guardado exitosamente 🎉", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La operación fue cancelada por el usuario.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
}
    

