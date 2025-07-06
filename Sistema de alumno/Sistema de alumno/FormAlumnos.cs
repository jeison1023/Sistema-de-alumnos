using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using practica;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Sistema_de_alumno
{
    public partial class FormAlumnos : Form
    {
        // Lista estática para almacenar los alumnos, accesible desde otros formularios.
        // En una aplicación real, esto sería una base de datos o un servicio de datos.
        public static List<Alumno> ListaAlumnos = new List<Alumno>();
        public FormAlumnos()
        {
            InitializeComponent();
            ConfigurarDataGridViewAlumnos(); // Configura las columnas del DataGridView.
            CargarAlumnosDataGridView(); // Carga los alumnos existentes al iniciar.
        }
        // Método para configurar las columnas del DataGridView1.
        private void ConfigurarDataGridViewAlumnos()
        {
            // Se asume que tienes un DataGridView llamado 'dataGridView1' en tu formulario.
            dataGridView1.AutoGenerateColumns = false; // Desactiva la generación automática de columnas.

            // Añade las columnas manualmente.
            dataGridView1.Columns.Add("Matricula", "Matrícula");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");
            dataGridView1.Columns.Add("Edad", "Edad");

            // Asigna las propiedades de datos a las columnas.
            dataGridView1.Columns["Matricula"].DataPropertyName = "Matricula";
            dataGridView1.Columns["Nombre"].DataPropertyName = "Nombre";
            dataGridView1.Columns["Apellido"].DataPropertyName = "Apellido";
            dataGridView1.Columns["Edad"].DataPropertyName = "Edad";
        }

        // Método para cargar la lista de alumnos en el DataGridView1.
        public void CargarAlumnosDataGridView()
        {
            // Asigna la lista de alumnos como fuente de datos para el DataGridView.
            dataGridView1.DataSource = null; // Limpia la fuente de datos actual.
            dataGridView1.DataSource = ListaAlumnos; // Asigna la nueva fuente de datos.
            dataGridView1.Refresh(); // Refresca el DataGridView para mostrar los cambios.
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bnRegistrar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox (se asume TextBox llamados txtMatricula, txtNombre, txtApellido, txtEdad).
            string matricula = txtmatricula.Text.Trim();
            string nombre = txtnombre.Text.Trim();
            string apellido = txtapellido.Text.Trim();
            int edad;

            // Validaciones de entrada.
            if (string.IsNullOrEmpty(matricula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtedad.Text.Trim(), out edad) || edad <= 0)
            {
                MessageBox.Show("Por favor, ingrese una edad válida.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar matrícula única.
            if (ListaAlumnos.Any(a => a.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"La matrícula '{matricula}' ya existe. Por favor, ingrese una matrícula única.", "Matrícula Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear una nueva instancia de Alumno.
            Alumno nuevoAlumno = new Alumno(matricula, nombre, apellido, edad);
            // Añadir el nuevo alumno a la lista.
            ListaAlumnos.Add(nuevoAlumno);
            // Actualizar el DataGridView.
            CargarAlumnosDataGridView();

            MessageBox.Show("Alumno registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos del formulario.
            txtmatricula.Clear();
            txtnombre.Clear();
            txtapellido.Clear();
            txtedad.Clear();

        }
    }
}
