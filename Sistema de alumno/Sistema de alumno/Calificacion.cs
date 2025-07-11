using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_alumno
{
    public class Calificacion
    {
        // Propiedad para la matrícula del alumno asociada a esta calificación.
        public string MatriculaAlumno { get; set; }
        // Propiedad para el nombre del alumno (se auto-rellena).
        public string NombreAlumno { get; set; }
        // Propiedad para el apellido del alumno (se auto-rellena).
        public string ApellidoAlumno { get; set; }
        // Propiedad para la materia de la calificación.
        public string Materia { get; set; }
        // Propiedad para el tipo de examen.
        public string Examen { get; set; }
        // Propiedad para la primera calificación.
        public double Calificacion1 { get; set; }
        // Propiedad para la segunda calificación.
        public double Calificacion2 { get; set; }
        // Propiedad para la tercera calificación.
        public double Calificacion3 { get; set; }
        // Propiedad para la cuarta calificación.
        public double Calificacion4 { get; set; }

        // Propiedad calculada para el total de calificación.
        // Se calcula como el 70% del promedio de Calificacion1, Calificacion2, Calificacion3
        // más el 30% de Calificacion4 (considerada como la calificación del examen).
        public double TotalCalificacion
        {
            get
            {
                
                double promedioParciales = (Calificacion1 + Calificacion2 + Calificacion3) / 3.0;
                double rawTotal = (promedioParciales * 0.70) + (Calificacion4 * 0.30);
                return Math.Round(rawTotal);
            }
        }

        // Propiedad calculada para la clasificación (A, B, C, F).
        public string Clasificacion
        {
            get
            {
                if (TotalCalificacion >= 90) return "A";
                if (TotalCalificacion >= 80) return "B";
                if (TotalCalificacion >= 70) return "C";
                return "F";
            }
        }

        // Propiedad calculada para el estado (Aprobado/Reprobado).
        public string Estado
        {
            get
            {
                return TotalCalificacion >= 70 ? "Aprobado" : "Reprobado";
            }
        }

        // Constructor de la clase Calificacion.
        public Calificacion(string matriculaAlumno, string nombreAlumno, string apellidoAlumno, string materia, string examen, double c1, double c2, double c3, double c4)
        {
            MatriculaAlumno = matriculaAlumno;
            NombreAlumno = nombreAlumno;
            ApellidoAlumno = apellidoAlumno;
            Materia = materia;
            Examen = examen;
            Calificacion1 = c1;
            Calificacion2 = c2;
            Calificacion3 = c3;
            Calificacion4 = c4;
        }
    }
}

