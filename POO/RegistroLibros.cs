// PROGRAMA PRINCIPAL

Libreria libreria = new Libreria();

try
{
    int operaciones = int.Parse(Console.ReadLine() ?? "");

    for (int i = 0;  i < operaciones; i++)
    {
        string[] entrada = (Console.ReadLine()??"").Split(' ');

        string comando = entrada[0];

        switch (comando)
        {
            case "LIBRO":
                libreria.AgregarLibro(entrada[1], entrada[2], entrada[3]);
                    break;

            case "CALIFICAR":
                if (entrada.Length == 4)
                {
                    libreria.CalificarLibro(entrada[1], int.Parse(entrada[3]));
                }
                else
                {
                    // Control
                    Console.WriteLine(entrada.Length);

                    libreria.CalificarLibro(entrada[1], int.Parse(entrada[3], string.Join(" ", entrada.Skip(4))));
                 
                }
                    break;

            case "MEJOR":
                libreria.MostrarMejorLibro(entrada[1]);
                break;

            case "CRITERIO":
                libreria.CambiarCriterio(entrada[1]);
                break;

            default: throw new InvalidOperationException("Comando no valido");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

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
    List<string> tipoFiccion = new List<string>("Fantasia", "Ciencia_Ficcion", "Romance", "Terror", "Misterio");

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
    List<string> tipoTecnico = new List<string>("Matematicas", "Historia", "Programacion", "Filosofia", "Medicina");

    // Constructor 
    public LibroTecnico(string titulo, string autor, string genero) : base(titulo, autor, genero)
    {
       /* if (tipoTecnico.Contains(genero))
        {
            throw new ArgumentException("El libro no pertenece a esta categoria");
        }*/
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
        Libreria libro = new Libreria();
        public List<Libro> libros = new List<Libro>();
        IRecomendable estrategiaRecomendacion = new RecomendacionPorPromedio();

        // Metodos
        public void AgregarLibro(string titulo, string autor, string genero)
        {
            Libro nuevoLibro;
            try
            {
                if (tipoFiccion.Contains(genero))
                {
                    nuevoLibro = new LibroFiccion(titulo, autor, genero);
                    libros.Add(nuevoLibro);
                }
                else if (tipoTecnico.Contains(genero))
                {
                    nuevoLibro = new LibroTecnico(titulo, autor, genero);
                    libros.Add(nuevoLibro);
                }
            }
            catch (Exception ex)
            {

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
                libroEncontrado.Calificar(estrellas);
            }
            else
            {
                throw new KeyNotFoundException("Libro no encontrado");
            }
        }

        public void CambiarCriterio(string criterio)
        {
            if (criterio == "PROMEDIO")
            {
                estrategiaRecomendacion = new RecomendacionPorPromedio();
            }
            else if (criterio == "VOTOS")
            {
                estrategiaRecomendacion = new RecomendacionPorVoto();
            }
        }

        public void MostrarMejorLibro(string genero)
        {
            List<Libro> librosGenero = new List<Libro>();

            foreach (Libro libro in libros)
            {
                if (libro.Genero == genero)
                {
                    librosGenero.Add(libro);
                }
            }

            Libro mejorlibro = estrategiaRecomendacion.ObtenerMejorLibro(librosGenero);

            if (mejorlibro != null)
            {
                Console.WriteLine(mejorlibro.Titulo);
            }
            else
            {
                Console.WriteLine("Ninguno");
            }
        }
    } }