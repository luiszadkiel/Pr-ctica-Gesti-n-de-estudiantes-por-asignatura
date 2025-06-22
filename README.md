Sistema de Gestión de Estudiantes
Descripción del Proyecto
Este sistema fue desarrollado como parte de la práctica académica de Análisis de Algoritmos y Estructuras de Datos Básicas. El objetivo principal es crear una aplicación que permita a los docentes universitarios llevar un control eficiente de sus estudiantes, organizados por asignaturas y grupos.
El sistema está diseñado para manejar tanto estudiantes presenciales como a distancia, permitiendo el registro de calificaciones de exámenes y prácticas, así como la generación de reportes con estadísticas de aprobación.
Objetivos Académicos
El desarrollo de este proyecto busca aplicar los siguientes conceptos fundamentales de la programación orientada a objetos:

Herencia: Implementación de una jerarquía de clases con una clase base abstracta
Polimorfismo: Sobrescritura de métodos para comportamientos específicos
Encapsulamiento: Protección de datos y exposición controlada de funcionalidades
Abstracción: Modelado de entidades del mundo real en estructuras de código

Arquitectura del Sistema
Diseño de Clases
El sistema está estructurado siguiendo principios de diseño orientado a objetos, con una clara separación de responsabilidades:
OperationResult: Clase utilitaria que estandariza las respuestas del sistema, facilitando el manejo de errores y el control de flujo.
Estudiante: Clase abstracta que define la estructura base para todos los tipos de estudiantes. Contiene la información común y los métodos que deben ser implementados por las clases derivadas.
EstudiantePresencial y EstudianteDistancia: Clases derivadas que implementan comportamientos específicos para cada modalidad de estudio.
Asignatura: Clase que encapsula la lógica de gestión de grupos de estudiantes por materia.
GestorEstudiantes: Controlador principal que coordina todas las operaciones del sistema.
Estructura del Proyecto
GestionEstudiantes/
├── Models/
│   ├── OperationResult.cs
│   ├── Estudiante.cs
│   ├── EstudiantePresencial.cs
│   ├── EstudianteDistancia.cs
│   └── Asignatura.cs
├── Services/
│   └── GestorEstudiantes.cs
├── Program.cs
└── README.md
Funcionalidades del Sistema
Gestión de Estudiantes por Grupo
El sistema permite agregar estudiantes a grupos específicos dentro de cada asignatura. Esta funcionalidad implementa el patrón de herencia, donde cada estudiante puede ser clasificado como presencial o a distancia, manteniendo información común pero con comportamientos diferenciados.
Sistema de Calificaciones Dual
Se ha implementado un sistema que distingue entre dos tipos de evaluaciones:
Exámenes: Evaluaciones teóricas que miden el conocimiento conceptual
Prácticas: Trabajos prácticos que evalúan la aplicación de conocimientos
El sistema permite registrar múltiples calificaciones de cada tipo y calcula automáticamente la nota final como el promedio ponderado de ambas categorías.
Generación de Reportes
La funcionalidad de reportes proporciona una vista completa del rendimiento académico del grupo, incluyendo:

Listado detallado de todos los estudiantes
Visualización de calificaciones por categoría
Estado de aprobación individual
Estadísticas generales del grupo

Análisis Estadístico
El sistema calcula automáticamente el porcentaje de estudiantes aprobados, utilizando como criterio una nota final igual o superior a 70 puntos. Esta información es valiosa para evaluar el rendimiento general del grupo.
Instrucciones de Instalación y Ejecución
Requisitos del Sistema

Microsoft .NET Framework 6.0 o superior
Entorno de desarrollo compatible (Visual Studio, Visual Studio Code, o similar)
Sistema operativo Windows, macOS, o Linux

Proceso de Instalación

Obtener el código fuente
bashgit clone [URL_DEL_REPOSITORIO]
cd GestionEstudiantes

Compilar la aplicación
bashdotnet build

Ejecutar el sistema
bashdotnet run


Uso del Sistema
Al ejecutar la aplicación, se presentará un menú interactivo con las siguientes opciones:

Crear asignatura con grupo: Establece una nueva materia con su grupo correspondiente
Agregar estudiante a grupo: Registra un nuevo estudiante (presencial o a distancia)
Registrar calificación de examen: Ingresa notas de evaluaciones teóricas
Registrar calificación de práctica: Ingresa notas de trabajos prácticos
Mostrar listado y estadísticas: Genera el reporte completo del grupo

Características Técnicas
Implementación de Patrones
Herencia: La clase base Estudiante define la estructura común, mientras que las clases derivadas implementan comportamientos específicos.
Polimorfismo: El método MostrarInfo() se comporta de manera diferente según el tipo de estudiante, demostrando el polimorfismo en tiempo de ejecución.
Encapsulamiento: Las propiedades están protegidas y se acceden a través de métodos públicos controlados.
Manejo de Datos
El sistema utiliza estructuras de datos en memoria (List<T>) para almacenar la información, cumpliendo con el requisito de no utilizar bases de datos. Esto garantiza simplicidad y rapidez en la ejecución.
Control de Errores
Todas las operaciones del sistema retornan un objeto OperationResult que incluye:

Success: Indicador de éxito o fallo
Message: Descripción del resultado
Data: Información adicional cuando aplica

Consideraciones de Diseño
El sistema fue diseñado priorizando la simplicidad y la claridad del código, manteniendo un equilibrio entre funcionalidad y facilidad de mantenimiento. La arquitectura modular permite futuras extensiones sin afectar el código existente.
La separación entre la lógica de presentación (Program.cs) y la lógica de negocio (Services/GestorEstudiantes.cs) facilita la comprensión y el mantenimiento del código.
Autor
Desarrollado como proyecto académico para el curso de Análisis de Algoritmos y Estructuras de Datos Básicas del Instituto Tecnológico de Las Américas (ITLA).
Información del Repositorio
Este proyecto demuestra la aplicación práctica de conceptos fundamentales de programación orientada a objetos en un escenario real de gestión académica.
