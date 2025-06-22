using System.Collections.Generic;
using System.Linq;

public class Asignatura
{
    public string Nombre { get; set; }
    public string Grupo { get; set; }
    public List<Estudiante> Estudiantes { get; set; }

    public Asignatura(string nombre, string grupo)
    {
        Nombre = nombre;
        Grupo = grupo;
        Estudiantes = new List<Estudiante>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }

    public double CalcularPorcentajeAprobados()
    {
        if (!Estudiantes.Any()) return 0;

        int aprobados = Estudiantes.Count(e => e.IsAprobado());
        return (double)aprobados / Estudiantes.Count * 100;
    }
}