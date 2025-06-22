using System;
using System.Collections.Generic;
using System.Linq;

public class GestorEstudiantes
{
    private List<Asignatura> asignaturas;

    public GestorEstudiantes()
    {
        asignaturas = new List<Asignatura>();
    }

    // FUNCIONALIDAD 1: Crear asignatura con grupo
    public OperationResult CrearAsignatura(string nombre, string grupo)
    {
        var asignatura = new Asignatura(nombre, grupo);
        asignaturas.Add(asignatura);
        return new OperationResult(true, "Asignatura creada exitosamente", asignatura);
    }

    // FUNCIONALIDAD 1: Agregar estudiantes a un grupo dentro de una asignatura
    public OperationResult AgregarEstudiante(int indexAsignatura, string nombre, string matricula, string tipo)
    {
        if (indexAsignatura >= asignaturas.Count)
            return new OperationResult(false, "Asignatura no encontrada");

        Estudiante estudiante = tipo == "1"
            ? new EstudiantePresencial(nombre, matricula)
            : new EstudianteDistancia(nombre, matricula);

        asignaturas[indexAsignatura].AgregarEstudiante(estudiante);
        return new OperationResult(true, $"Estudiante {nombre} agregado al grupo {asignaturas[indexAsignatura].Grupo} de {asignaturas[indexAsignatura].Nombre}");
    }

    // FUNCIONALIDAD 2A: Registrar calificaciones de EXÁMENES
    public OperationResult RegistrarCalificacionExamen(int indexAsignatura, string matricula, double nota)
    {
        if (indexAsignatura >= asignaturas.Count)
            return new OperationResult(false, "Asignatura no encontrada");

        var estudiante = asignaturas[indexAsignatura].Estudiantes
            .FirstOrDefault(e => e.Matricula == matricula);

        if (estudiante == null)
            return new OperationResult(false, "Estudiante no encontrado");

        estudiante.AgregarCalificacionExamen(nota);
        return new OperationResult(true, $"Calificación de examen ({nota}) registrada para {estudiante.Nombre}");
    }

    // FUNCIONALIDAD 2B: Registrar calificaciones de PRÁCTICAS
    public OperationResult RegistrarCalificacionPractica(int indexAsignatura, string matricula, double nota)
    {
        if (indexAsignatura >= asignaturas.Count)
            return new OperationResult(false, "Asignatura no encontrada");

        var estudiante = asignaturas[indexAsignatura].Estudiantes
            .FirstOrDefault(e => e.Matricula == matricula);

        if (estudiante == null)
            return new OperationResult(false, "Estudiante no encontrado");

        estudiante.AgregarCalificacionPractica(nota);
        return new OperationResult(true, $"Calificación de práctica ({nota}) registrada para {estudiante.Nombre}");
    }

    // FUNCIONALIDAD 3: Mostrar listado de calificaciones por grupo
    public OperationResult MostrarListadoCalificacionesPorGrupo(int indexAsignatura)
    {
        if (indexAsignatura >= asignaturas.Count)
            return new OperationResult(false, "Asignatura no encontrada");

        var asignatura = asignaturas[indexAsignatura];
        var resultado = $"\n=== LISTADO DE CALIFICACIONES ===\n";
        resultado += $"Asignatura: {asignatura.Nombre}\n";
        resultado += $"Grupo: {asignatura.Grupo}\n";
        resultado += new string('-', 50) + "\n";

        foreach (var estudiante in asignatura.Estudiantes)
        {
            resultado += estudiante.MostrarInfo() + "\n";
            resultado += $"   Exámenes: [{string.Join(", ", estudiante.CalificacionesExamenes)}]\n";
            resultado += $"   Prácticas: [{string.Join(", ", estudiante.CalificacionesPracticas)}]\n";
            resultado += new string('-', 30) + "\n";
        }

        // FUNCIONALIDAD 4: Calcular porcentaje de estudiantes aprobados
        double porcentaje = asignatura.CalcularPorcentajeAprobados();
        resultado += $"\n📊 PORCENTAJE DE APROBADOS: {porcentaje:F1}%\n";
        resultado += $"📈 Total de estudiantes: {asignatura.Estudiantes.Count}\n";
        resultado += $"✅ Estudiantes aprobados: {asignatura.Estudiantes.Count(e => e.IsAprobado())}\n";

        return new OperationResult(true, "Listado generado exitosamente", resultado);
    }

    public List<Asignatura> GetAsignaturas() => asignaturas;

    public OperationResult BuscarEstudiante(int indexAsignatura, string matricula)
    {
        if (indexAsignatura >= asignaturas.Count)
            return new OperationResult(false, "Asignatura no encontrada");

        var estudiante = asignaturas[indexAsignatura].Estudiantes
            .FirstOrDefault(e => e.Matricula == matricula);

        if (estudiante == null)
            return new OperationResult(false, "Estudiante no encontrado");

        return new OperationResult(true, "Estudiante encontrado", estudiante);
    }
}