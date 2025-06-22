using System.Collections.Generic;
using System.Linq;

public abstract class Estudiante
{
    public string Nombre { get; set; }
    public string Matricula { get; set; }
    public List<double> CalificacionesExamenes { get; set; }
    public List<double> CalificacionesPracticas { get; set; }

    public Estudiante(string nombre, string matricula)
    {
        Nombre = nombre;
        Matricula = matricula;
        CalificacionesExamenes = new List<double>();
        CalificacionesPracticas = new List<double>();
    }

    public abstract string GetTipo();
    public abstract string MostrarInfo();

    // Calcula promedio final (50% exámenes + 50% prácticas)
    public double GetCalificacionFinal()
    {
        double promedioExamenes = CalificacionesExamenes.Any() ? CalificacionesExamenes.Average() : 0;
        double promedioPracticas = CalificacionesPracticas.Any() ? CalificacionesPracticas.Average() : 0;
        return (promedioExamenes + promedioPracticas) / 2;
    }

    public bool IsAprobado() => GetCalificacionFinal() >= 70;

    public void AgregarCalificacionExamen(double nota)
    {
        CalificacionesExamenes.Add(nota);
    }

    public void AgregarCalificacionPractica(double nota)
    {
        CalificacionesPracticas.Add(nota);
    }
}