using System;

class Program
{
    static void Main(string[] args)
    {
        var gestor = new GestorEstudiantes();
        bool continuar = true;

        Console.WriteLine("=== SISTEMA DE GESTIÓN DE ESTUDIANTES ===\n");

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearAsignatura(gestor);
                    break;
                case "2":
                    AgregarEstudianteAGrupo(gestor); // FUNCIONALIDAD 1
                    break;
                case "3":
                    RegistrarCalificacionExamen(gestor); // FUNCIONALIDAD 2A
                    break;
                case "4":
                    RegistrarCalificacionPractica(gestor); // FUNCIONALIDAD 2B
                    break;
                case "5":
                    MostrarListadoCalificaciones(gestor); // FUNCIONALIDAD 3 y 4
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("❌ Opción inválida");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("🎓 === MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Crear asignatura con grupo");
        Console.WriteLine("2. 📝 Agregar estudiante a grupo (FUNCIONALIDAD 1)");
        Console.WriteLine("3. 📊 Registrar calificación de EXAMEN (FUNCIONALIDAD 2)");
        Console.WriteLine("4. 🔬 Registrar calificación de PRÁCTICA (FUNCIONALIDAD 2)");
        Console.WriteLine("5. 📋 Mostrar listado y porcentaje de aprobados (FUNCIONALIDAD 3 y 4)");
        Console.WriteLine("6. Salir");
        Console.Write("\n▶️ Selecciona una opción: ");
    }

    static void CrearAsignatura(GestorEstudiantes gestor)
    {
        Console.Write("📚 Nombre de la asignatura: ");
        string nombre = Console.ReadLine();

        Console.Write("👥 Nombre del grupo: ");
        string grupo = Console.ReadLine();

        var resultado = gestor.CrearAsignatura(nombre, grupo);
        Console.WriteLine("✅ " + resultado.Message);
    }

    // FUNCIONALIDAD 1: Agregar estudiantes a un grupo dentro de una asignatura
    static void AgregarEstudianteAGrupo(GestorEstudiantes gestor)
    {
        Console.WriteLine("\n🎯 FUNCIONALIDAD 1: Agregar estudiante a grupo");
        MostrarAsignaturas(gestor);

        Console.Write("📋 Índice de asignatura: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.Write("👤 Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            Console.Write("🆔 Matrícula: ");
            string matricula = Console.ReadLine();

            Console.WriteLine("🏢 Tipo de estudiante:");
            Console.WriteLine("  1 - Presencial");
            Console.WriteLine("  2 - A Distancia");
            Console.Write("▶️ Selecciona: ");
            string tipo = Console.ReadLine();

            var resultado = gestor.AgregarEstudiante(index, nombre, matricula, tipo);
            Console.WriteLine(resultado.Success ? "✅ " + resultado.Message : "❌ " + resultado.Message);
        }
    }

    // FUNCIONALIDAD 2A: Registrar calificaciones de exámenes
    static void RegistrarCalificacionExamen(GestorEstudiantes gestor)
    {
        Console.WriteLine("\n🎯 FUNCIONALIDAD 2: Registrar calificación de EXAMEN");
        MostrarAsignaturas(gestor);

        Console.Write("📋 Índice de asignatura: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.Write("🆔 Matrícula del estudiante: ");
            string matricula = Console.ReadLine();

            Console.Write("📊 Calificación del examen (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double nota))
            {
                var resultado = gestor.RegistrarCalificacionExamen(index, matricula, nota);
                Console.WriteLine(resultado.Success ? "✅ " + resultado.Message : "❌ " + resultado.Message);
            }
        }
    }

    // FUNCIONALIDAD 2B: Registrar calificaciones de prácticas
    static void RegistrarCalificacionPractica(GestorEstudiantes gestor)
    {
        Console.WriteLine("\n🎯 FUNCIONALIDAD 2: Registrar calificación de PRÁCTICA");
        MostrarAsignaturas(gestor);

        Console.Write("📋 Índice de asignatura: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            Console.Write("🆔 Matrícula del estudiante: ");
            string matricula = Console.ReadLine();

            Console.Write("🔬 Calificación de la práctica (0-100): ");
            if (double.TryParse(Console.ReadLine(), out double nota))
            {
                var resultado = gestor.RegistrarCalificacionPractica(index, matricula, nota);
                Console.WriteLine(resultado.Success ? "✅ " + resultado.Message : "❌ " + resultado.Message);
            }
        }
    }

    // FUNCIONALIDAD 3 y 4: Mostrar listado de calificaciones y calcular porcentaje de aprobados
    static void MostrarListadoCalificaciones(GestorEstudiantes gestor)
    {
        Console.WriteLine("\n🎯 FUNCIONALIDAD 3 y 4: Listado de calificaciones y porcentaje de aprobados");
        MostrarAsignaturas(gestor);

        Console.Write("📋 Índice de asignatura: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            var resultado = gestor.MostrarListadoCalificacionesPorGrupo(index);
            if (resultado.Success)
                Console.WriteLine(resultado.Data);
            else
                Console.WriteLine("❌ " + resultado.Message);
        }
    }

    static void MostrarAsignaturas(GestorEstudiantes gestor)
    {
        var asignaturas = gestor.GetAsignaturas();
        Console.WriteLine("\n📚 === ASIGNATURAS DISPONIBLES ===");

        if (asignaturas.Count == 0)
        {
            Console.WriteLine("❌ No hay asignaturas creadas. Crea una primero.");
            return;
        }

        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"{i}. {asignaturas[i].Nombre} - Grupo: {asignaturas[i].Grupo} ({asignaturas[i].Estudiantes.Count} estudiantes)");
        }
        Console.WriteLine();
    }
}