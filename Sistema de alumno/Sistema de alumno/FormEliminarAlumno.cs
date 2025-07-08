using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using practica;

namespace Sistema_de_alumno
{
    public partial class FormEliminarAlumno : Form
    {
        public FormEliminarAlumno()
        {
            InitializeComponent();
            ConfigurarDataGridViewAlumnoEncontrado();
        }
        private void ConfigurarDataGridViewAlumnoEncontrado()
        {
            dgvAlumnoEncontrado.AutoGenerateColumns = false; 
            dgvAlumnoEncontrado.ReadOnly = true;             
            dgvAlumnoEncontrado.AllowUserToAddRows = false;  

            dgvAlumnoEncontrado.Columns.Clear();

           
            dgvAlumnoEncontrado.Columns.Add("Matricula", "Matrícula");
            dgvAlumnoEncontrado.Columns.Add("Nombre", "Nombre");
            dgvAlumnoEncontrado.Columns.Add("Apellido", "Apellido");
            dgvAlumnoEncontrado.Columns.Add("Edad", "Edad");

            dgvAlumnoEncontrado.Columns["Matricula"].DataPropertyName = "Matricula";
            dgvAlumnoEncontrado.Columns["Nombre"].DataPropertyName = "Nombre";
            dgvAlumnoEncontrado.Columns["Apellido"].DataPropertyName = "Apellido";
            dgvAlumnoEncontrado.Columns["Edad"].DataPropertyName = "Edad";
        }

        private void dgvAlumnoEncontrado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string matriculaBuscada = txtMatriculaEliminar.Text.Trim();

            if (string.IsNullOrEmpty(matriculaBuscada))
            {
                MessageBox.Show("Por favor, ingrese la matrícula del alumno a buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvAlumnoEncontrado.DataSource = null;
                return;
            }

            Alumno alumnoEncontrado = FormAlumnos.ListaAlumnos.FirstOrDefault(a =>
                a.Matricula.Equals(matriculaBuscada, StringComparison.OrdinalIgnoreCase));

            if (alumnoEncontrado != null)
            {
               
                dgvAlumnoEncontrado.DataSource = new List<Alumno> { alumnoEncontrado };
                MessageBox.Show($"Alumno '{alumnoEncontrado.Nombre} {alumnoEncontrado.Apellido}' encontrado.", "Alumno Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvAlumnoEncontrado.DataSource = null; 
                MessageBox.Show($"No se encontró ningún alumno con la matrícula '{matriculaBuscada}'.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string matriculaAEliminar = txtMatriculaEliminar.Text.Trim();

            if (string.IsNullOrEmpty(matriculaAEliminar))
            {
                MessageBox.Show("Por favor, ingrese la matrícula del alumno que desea eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            Alumno alumnoAConfirmar = FormAlumnos.ListaAlumnos.FirstOrDefault(a =>
                a.Matricula.Equals(matriculaAEliminar, StringComparison.OrdinalIgnoreCase));

            if (alumnoAConfirmar == null)
            {
                MessageBox.Show($"No se encontró ningún alumno con matrícula '{matriculaAEliminar}'.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        
            DialogResult confirmResult = MessageBox.Show(
                $"¿Está seguro de que desea eliminar al alumno '{alumnoAConfirmar.Nombre} {alumnoAConfirmar.Apellido}' (Matrícula: {matriculaAEliminar})?\n" +
                "¡Esto también eliminará todas sus calificaciones asociadas de forma permanente!",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
             
                int alumnosRemovidos = FormAlumnos.ListaAlumnos.RemoveAll(a =>
                    a.Matricula.Equals(matriculaAEliminar, StringComparison.OrdinalIgnoreCase));

              
                int calificacionesRemovidas = AreaCalificacion.ListaCalificaciones.RemoveAll(c =>
                    c.MatriculaAlumno.Equals(matriculaAEliminar, StringComparison.OrdinalIgnoreCase));

                if (alumnosRemovidos > 0)
                {
                    MessageBox.Show($"Alumno '{alumnoAConfirmar.Nombre} {alumnoAConfirmar.Apellido}' y sus {calificacionesRemovidas} calificaciones asociadas han sido eliminados exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    txtMatriculaEliminar.Clear();
                    dgvAlumnoEncontrado.DataSource = null;

                    
                    FormAlumnos formAlumnos = Application.OpenForms.OfType<FormAlumnos>().FirstOrDefault();
                    if (formAlumnos != null)
                    {
                        formAlumnos.CargarAlumnosDataGridView(); 
                    }

                   
                    AreaCalificacion formCalificacion = Application.OpenForms.OfType<AreaCalificacion>().FirstOrDefault();
                    if (formCalificacion != null)
                    {
                        formCalificacion.CargarCalificacionesDataGridView(); 
                    }
                }
                else
                {
                    
                    MessageBox.Show($"Ocurrió un error: No se pudo eliminar al alumno con matrícula '{matriculaAEliminar}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void FormEliminarAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
