using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("Caso Lista: ");
        CasoList casoList = new CasoList();

        Alumno a1 = new Alumno(46251, "Maria", 6.5);
        Alumno a2 = new Alumno(42860, "Lucas", 7.0);
        Alumno a3 = new Alumno(51203, "Agustina", 9.0);

        casoList.AgregarAlumno(a1);
        casoList.AgregarAlumno(a2);
        casoList.AgregarAlumno(a3);
        
        Console.WriteLine("\nLista inicial de alumnos:");
        foreach (var alumno in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alumno);
        }

        Console.WriteLine("\nBuscando alumno que existe (Juan):");
        Alumno? encontrado = casoList.BuscarPorNombre("Juan");
        Console.WriteLine(encontrado != null ? encontrado : "No existe");

        Console.WriteLine("\nBuscando alumno que NO existe (Agustin):");
        Alumno? noEncontrado = casoList.BuscarPorNombre("Agustin");
        Console.WriteLine(noEncontrado != null ? noEncontrado : "No existe");

        Console.WriteLine("\nEliminando a 'Maria' de la lista...");
        casoList.EliminarAlumno(a1);

        Console.WriteLine("Lista después de eliminar a Maria:");
        foreach (var alumno in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alumno);
        }

        Console.WriteLine("\nEliminando el primer elemento restante (posición 0)...");
        casoList.EliminarEnPosicion(0);

        Console.WriteLine("Lista final:");
        foreach (var alumno in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alumno);
        }
        Console.WriteLine();
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("Caso Diccionario: ");
        CasoDictionary casoDic = new CasoDictionary();

        casoDic.AgregarAlumno(new Alumno(50246, "Elisa", 9.0));
        casoDic.AgregarAlumno(new Alumno(50384, "Valentina", 6.0));
        casoDic.AgregarAlumno(new Alumno(50982, "Isidro", 7.5));

        Console.WriteLine("\nDiccionario inicial de alumnos:");
        foreach (KeyValuePair<int, Alumno> par in casoDic.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [Legajo: {par.Key}] -> {par.Value}");
        }

        Console.WriteLine("\nBuscando alumno por clave existente (50384):");
        Alumno? enc = casoDic.BuscarPorLegajo(50384);
        Console.WriteLine(enc != null ? enc : "No existe");

        Console.WriteLine("\nBuscando alumno por clave inexistente (50123):");
        Alumno? noEnc = casoDic.BuscarPorLegajo(50123);
        Console.WriteLine(noEnc != null ? noEnc : "No existe");

        Console.WriteLine("\nEliminando alumno con legajo 50246...");
        casoDic.EliminarPorLegajo(50246);

        Console.WriteLine("Diccionario después de la eliminación:");
        foreach (var par in casoDic.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave [Legajo: {par.Key}] -> {par.Value}");
        }
        Console.WriteLine();
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("Caso Linq: ");
        CasoLinq casoLinq = new CasoLinq();

        Console.WriteLine($"1. Primer libro: {casoLinq.GetPrimero()}");

        Console.WriteLine($"2. Último libro: {casoLinq.GetUltimo()}");

        Console.WriteLine($"3. Total de precios: {casoLinq.GetTotalPrecios():C}");

        decimal promedio = casoLinq.GetPromedioPrecios();
        Console.WriteLine($"4. Promedio de precios: {promedio:C}");

        Console.WriteLine("\n5. Libros con Id > 15:");
        foreach (var libro in casoLinq.GetListById())
        {
            Console.WriteLine($"   [Id: {libro.Id}] {libro.Titulo}");
        }

        Console.WriteLine("\n6. Lista formateada:");
        var listaFormateada = casoLinq.GetLibros();
        for (int i = 0; i < Math.Min(10, listaFormateada.Count); i++)
        {
            Console.WriteLine($"   {listaFormateada[i]}");
        }
        Console.WriteLine("   ... (más libros en la lista)");

        Console.WriteLine($"\n7. Libro más caro: {casoLinq.GetMayorPrecio()?.Titulo} - {casoLinq.GetMayorPrecio()?.Precio:C}");

        Console.WriteLine($"8. Libro más barato: {casoLinq.GetMenorPrecio()?.Titulo} - {casoLinq.GetMenorPrecio()?.Precio:C}");

        Console.WriteLine($"\n9. Libros que superan el promedio de {promedio:C}:");
        foreach (var libro in casoLinq.GetMayorPromedio())
        {
            Console.WriteLine($"   {libro.Titulo} ({libro.Precio:C})");
        }

        Console.WriteLine("\n10. Primeros 3 libros ordenados de Z a A:");
        var ordenados = casoLinq.GetLibrosOrdenadosPorTituloDesc();
        for (int i = 0; i < Math.Min(3, ordenados.Count); i++)
        {
            Console.WriteLine($"   {ordenados[i].Titulo}");
        }
        Console.WriteLine();
    }
}
}
