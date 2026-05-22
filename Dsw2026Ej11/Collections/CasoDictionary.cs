using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    
    private readonly Dictionary<int, Alumno> _alumnosDiccionario = new Dictionary<int, Alumno>();

    public void AgregarAlumno(Alumno alumno)
    {
        if (alumno != null)
        {
            _alumnosDiccionario.TryAdd(alumno.Id, alumno);
        }
    }

    public Alumno? BuscarPorLegajo(int legajo)
    {
        if (_alumnosDiccionario.TryGetValue(legajo, out Alumno? alumno))
        {
            return alumno;
        }
        return null;
    }

    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return _alumnosDiccionario;
    }

    public bool EliminarPorLegajo(int legajo)
    {
        return _alumnosDiccionario.Remove(legajo);
    }

}
