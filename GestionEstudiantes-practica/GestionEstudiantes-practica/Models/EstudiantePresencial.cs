public class EstudiantePresencial : Estudiante
{
    public EstudiantePresencial(string nombre, string matricula) : base(nombre, matricula)
    {
    }

    public override string GetTipo()
    {
        return "Presencial";
    }

    public override string MostrarInfo()
    {
        return $"{Nombre} ({Matricula}) - {GetTipo()} - Nota Final: {GetCalificacionFinal():F1} - {(IsAprobado() ? "APROBADO" : "REPROBADO")}";
    }
}