using System;
using System.Collections.Generic;

namespace practica
{

    public class Alumno
    {
        // Propiedad para la matrícula única del alumno.
        public string Matricula { get; set; }
        // Propiedad para el nombre del alumno.
        public string Nombre { get; set; }
        // Propiedad para el apellido del alumno.
        public string Apellido { get; set; }
        // Propiedad para la edad del alumno.
        public int Edad { get; set; }

        // Constructor de la clase Alumno.
        public Alumno(string matricula, string nombre, string apellido, int edad)
        {
            Matricula = matricula;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        // Sobrescribe el método ToString para una representación legible del objeto.
        public override string ToString()
        {
            return $"{Matricula} - {Nombre} {Apellido}";
        }
    }
}



