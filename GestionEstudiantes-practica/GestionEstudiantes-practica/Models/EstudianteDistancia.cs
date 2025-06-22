public class EstudianteDistancia : Estudiante
{
    public EstudianteDistancia(string nombre, string matricula) : base(nombre, matricula)
    {
    }

    public override string GetTipo()
    {
        return "A Distancia";
    }

    public override string MostrarInfo()
    {
        return $"{Nombre} ({Matricula}) - {GetTipo()} - Nota Final: {GetCalificacionFinal():F1} - {(IsAprobado() ? "APROBADO" : "REPROBADO")}";
    }
}