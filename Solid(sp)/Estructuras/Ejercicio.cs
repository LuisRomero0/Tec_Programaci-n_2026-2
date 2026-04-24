public class Cancion 
{
    // Atributos de la clase Cancion
    public string Titulo { get; set; }
    public int DuracionMinutos { get; set; }
    public string Genero { get; set; }


    // Constructor para inicializar la canción
    public Cancion(string titulo, string genero, int duracionMinutos)
    {
        Titulo = titulo;
        Genero = genero;
        DuracionMinutos = duracionMinutos;
    }

    // Metodo para mostrar la información de la canción
    public override string ToString()
    {
        return $"{Titulo} -- {DuracionMinutos} minutos [{Genero}]";
    }

}


public class Banda
{
    // Atributos de la clase Banda

    public string Nombre { get; set; }

    public string Origen { get; set; }
    public TimeSpan HoraPresentacion { get; set; }

    public Cancion[] SetCanciones { get; set; } 

    // Constructor para inicializar la banda

    public Banda(string nombre, string origen, TimeSpan hora, int cantidadCanciones)
    {
        Nombre = nombre;
        Origen = origen;
        HoraPresentacion = hora;
        SetCanciones = new Cancion[cantidadCanciones];
    }

    // Metodos
}