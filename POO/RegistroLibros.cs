// PROGRAMA PRINCIPAL


// CLASES
public class Libro
{
    // Atributos 
    public string Titulo {  get; } // No se establece el cambio en el valor de este atributo por eso se elimina set;
    public string Autor { get; }
    public string Genero { get; }

    // Variable de la clase
    List<int> Calificaciones;

    // Construtor
    public Libro (string titulo, string autor, string genero)
    {
        Titulo = titulo;   
        Autor = autor;
        Genero = genero;
        Calificaciones = new List<int>();
    }

    // Métodos
    public void Calificar(int estrellas)
    {
        if (estrellas >= 1 && estrellas <= 5)
        {
            Calificaciones.Add(estrellas);
        }
        else
        {
            throw new ArgumentException("Calificacion invalida (Debe ser del 1 - 5)");
        }
    }

    // Sobrecarga del metodo calificar 
    public void Calificar (int estrellas, string comentario)
    {
        Console.WriteLine($"Comentario recibido: {comentario}");
        Calificar(estrellas);
    }

    public double ObtenerPromedio()
    {
        if (Calificaciones.Count == 0)
        {
            throw new InvalidOperationException("No hay calificaciones para este libro");
        }
        else
        {
            double promedio = Calificaciones.Average();
            return promedio;
        }
    }

    public int ObtenerCantidadVotos()
    {
        return Calificaciones.Count;
    }
}

// Clases hijas tipos de libros

public class LibroFiccion : Libro
{
    // Variable de clase 
    List<string> tipoFiccion = new List<string> ("Fantasia", "Ciencia_Ficcion", "Romance", "Terror", "Misterio")

    // Constructor 
    public LibroFiccion(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
        if (tipoFiccion.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoria");
        }
    }
}

public class LibroTecnico: Libro
{
    // Variable de clase 
    List<string> tipoTecnico = new List<string>("Matematicas", "Historia", "Programacion", "Filosofia", "Medicina")

    // Constructor 
    public LibroTecnico(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
        if (tipoTecnico.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoria");
        }
    }
}

// Interfaz para criterio de recomendacion 

interface IRecomendable
{
    Libro ObtenerMejorLibro(List <Libro> libros);
}

// Clases que implementan interfaz
public class RecomendacionPorPromedio : IRecomendable
{
    public Libro ObtenerMejorLibro(List<Libro> libros)
    {
        Libro mejorLibro = null;
        double mejorPromedio = 0; // PIVOTE         SE USA PARA ORDENAMIENTO BURBUJA 

        foreach (Libro libro in libros) 
        {
            double promedio = libro.ObtenerPromedio(); //Seleccion del pivote
            if (promedio > mejorPromedio) //Comparacion del elemento siguiente 
            {
                mejorPromedio = promedio;
                mejorLibro = libro;
            }
        }
        return mejorLibro; 
}

    public class RecomendacionPorVoto : IRecomendable
    {
        public Libro ObtenerMejorLibro(List<Libro> libros)
        {
            Libro mejorLibro = null;
            double maxVotos = -1; // PIVOTE         SE USA PARA ORDENAMIENTO BURBUJA 

            foreach (Libro libro in libros)
            {
                int votos = libro.ObtenerPromedio(); //Seleccion del pivote
                if (votos > maxVotos) //Comparacion del elemento siguiente 
                {
                    maxVotos = votos;
                    mejorLibro = libro;
                }
            }
            return mejorLibro;
        }
    }

// Clase de libreria 
public class Libreria
    {
        public List<Libro> libros = new List<Libro> ();
        IRecomendable estrategiaRecomendacion = new RecomendacionPorPromedio();

        // Metodos
        public void AgregarLibro(string titulo, string autor, string genero)
        {
            Libro nuevoLibro;
            try
            {
                nuevoLibro = new LibroFiccion(titulo, autor, genero);
                libros.Add(nuevoLibro);
            }
            catch (Exception ex)
            {
                nuevoLibro = new LibroTecnico(titulo, autor, genero);
                libros.Add(nuevoLibro);
            }
        }

        public void CalificarLibro(string titulo, int estrellas)
        {
            Libro libroEncontrado = null;
            foreach (Libro libro in libros)
            {
                if (libro.Titulo == titulo)
                {
                    libroEncontrado = libro;
                    break; 
                }
            }

            if (libroEncontrado != null)
            {
                libroEncontrado.Calificar(estrellas, comentario);
            }
            else
            {
                throw new KeyNotFoundException("Libro no encontrado");
            }
        }




    }