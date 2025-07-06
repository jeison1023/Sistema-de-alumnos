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
    public partial class AreaCalificacion : Form
    {
        // Lista estática para almacenar las calificaciones.
        public static List<Calificacion> ListaCalificaciones = new List<Calificacion>();
        public AreaCalificacion()
        {
            InitializeComponent();
            ConfigurarDataGridViewCalificaciones(); // Configura las columnas del DataGridView.
            CargarCalificacionesDataGridView(); // Carga las calificaciones existentes al iniciar.
        }

        // Método para configurar las columnas del DataGridView2.
        private void ConfigurarDataGridViewCalificaciones()
        {
            // Se asume que tienes un DataGridView llamado 'dataGridView2' en tu formulario.
            dataGridView2.AutoGenerateColumns = false; // Desactiva la generación automática de columnas.

            // Añade las columnas manualmente.
            dataGridView2.Columns.Add("MatriculaAlumno", "Matrícula");
            dataGridView2.Columns.Add("NombreAlumno", "Nombre");
            dataGridView2.Columns.Add("ApellidoAlumno", "Apellido");
            dataGridView2.Columns.Add("Materia", "Materia");
            dataGridView2.Columns.Add("Examen", "Examen");
            dataGridView2.Columns.Add("Calificacion1", "C1");
            dataGridView2.Columns.Add("Calificacion2", "C2");
            dataGridView2.Columns.Add("Calificacion3", "C3");
            dataGridView2.Columns.Add("Calificacion4", "C4");
            // Nuevas columnas calculadas
            dataGridView2.Columns.Add("TotalCalificacion", "Total de Calificación");
            dataGridView2.Columns.Add("Clasificacion", "Clasificación");
            dataGridView2.Columns.Add("Estado", "Estado");

            // Asigna las propiedades de datos a las columnas.
            dataGridView2.Columns["MatriculaAlumno"].DataPropertyName = "MatriculaAlumno";
            dataGridView2.Columns["NombreAlumno"].DataPropertyName = "NombreAlumno";
            dataGridView2.Columns["ApellidoAlumno"].DataPropertyName = "ApellidoAlumno";
            dataGridView2.Columns["Materia"].DataPropertyName = "Materia";
            dataGridView2.Columns["Examen"].DataPropertyName = "Examen";
            dataGridView2.Columns["Calificacion1"].DataPropertyName = "Calificacion1";
            dataGridView2.Columns["Calificacion2"].DataPropertyName = "Calificacion2";
            dataGridView2.Columns["Calificacion3"].DataPropertyName = "Calificacion3";
            dataGridView2.Columns["Calificacion4"].DataPropertyName = "Calificacion4";
            // Asigna las propiedades de datos para las nuevas columnas calculadas.
            dataGridView2.Columns["TotalCalificacion"].DataPropertyName = "TotalCalificacion";
            dataGridView2.Columns["Clasificacion"].DataPropertyName = "Clasificacion";
            dataGridView2.Columns["Estado"].DataPropertyName = "Estado";
        }

        // Método para cargar la lista de calificaciones en el DataGridView2.
        public void CargarCalificacionesDataGridView()
        {
            // Asigna la lista de calificaciones como fuente de datos para el DataGridView.
            dataGridView2.DataSource = null; // Limpia la fuente de datos actual.
            dataGridView2.DataSource = ListaCalificaciones; // Asigna la nueva fuente de datos.
            dataGridView2.Refresh(); // Refresca el DataGridView para mostrar los cambios.
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox (se asume TextBox llamados txtMatriculaCalificacion, txtMateria, txtExamen, txtCalificacion1, etc.).
            string matricula = txtmatricula.Text.Trim();
            string materia = txtmateria.Text.Trim();
            string examen = txtexamen.Text.Trim();
            double c1, c2, c3, c4;

            // Validaciones de entrada.
            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(materia) || string.IsNullOrEmpty(examen))
            {
                MessageBox.Show("Por favor, complete todos los campos de calificación.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtC1.Text.Trim(), out c1) || c1 < 0 || c1 > 100 ||
                !double.TryParse(txtC2.Text.Trim(), out c2) || c2 < 0 || c2 > 100 ||
                !double.TryParse(txtC3.Text.Trim(), out c3) || c3 < 0 || c3 > 100 ||
                !double.TryParse(txtC4.Text.Trim(), out c4) || c4 < 0 || c4 > 100)
            {
                MessageBox.Show("Por favor, ingrese calificaciones válidas entre 0 y 100.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar el alumno para obtener su nombre y apellido.
            Alumno alumnoEncontrado = FormAlumnos.ListaAlumnos.FirstOrDefault(a => a.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase));

            if (alumnoEncontrado == null)
            {
                MessageBox.Show($"No se encontró ningún alumno con la matrícula '{matricula}'. Por favor, registre al alumno primero.", "Alumno No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear una nueva instancia de Calificacion.
            Calificacion nuevaCalificacion = new Calificacion(
                matricula,
                alumnoEncontrado.Nombre,
                alumnoEncontrado.Apellido,
                materia,
                examen,
                c1, c2, c3, c4
            );
            // Añadir la nueva calificación a la lista.
            ListaCalificaciones.Add(nuevaCalificacion);
            // Actualizar el DataGridView.
            CargarCalificacionesDataGridView();

            MessageBox.Show("Calificación registrada exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos del formulario.
            txtmatricula.Clear();
            txtmateria.Clear();
            txtexamen.Clear();
            txtC1.Clear();
            txtC2.Clear();
            txtC3.Clear();
            txtC4.Clear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
