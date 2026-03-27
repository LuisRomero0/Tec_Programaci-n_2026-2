// Clase que representa Estudiantes

public class Estudiante
{
    // Atributos

    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public double Calificacion { get; set; }

    // Constructor
    // Métodos

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Edad: {Edad}, Calificación: {Calificacion}";
    }


}

// Clase para manejar el archivo de estudiantes
public class GestorEstudiantes
{
    // Atributos 
    private string rutaArchivo;
    //Constructor
    public GestorEstudiantes(string ruta)
    {
        rutaArchivo = ruta;
    }
    // Metodos para guardar la lista de estudiantes en un archivo de texto
    public void GuardarEstudiantes(List<Estudiante> estudiantes)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                foreach (Estudiante estudiante in estudiantes)
                {
                    writer.WriteLine(estudiante.ToString());
                }
            }
            Console.WriteLine("Estudiantes guardados exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Metodos para leer la lista de estudiantes desde un archivo de texto

   /* public List<Estudiante> LeerEstudiantes()
    {
        List<Estudiante> estudiantesLectura = new List<Estudiante>();

        try
        {
            using (StreamReader reader = new)
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }*/

}