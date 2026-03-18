namespace BibliotecaDeLibros
{
    public class Libro
    {
        // ATRIBUTOS
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int AnioPublication {  get; set; }

        // CONSTRUCTOR 
        
        public Libro(string titulo, string autor, int anioPublication)
        {
            Titulo = titulo;
            Autor = autor;
            AnioPublication = anioPublication;
        }
    }

    public class GestorLibros
    {
        private List<Libro> libros = new List<Libro>();

        // METODOS
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void EliminarLibro(string titulo)
        {
            libros.RemoveAll(l => l.Titulo == titulo);
        }

        public List<Libro> BuscarLibrosPorAutor(string autor)
        {
            return libros.FindAll(l => l.Autor == autor);
        }

        public void MostrarLibros()
        {
            foreach (Libro libro in libros)
            {
                Console.WriteLine($"Titulo: {libro.Titulo} | Autor: {libro.Autor} | Año: {libro.AnioPublication}");
            }
        }
    }
}

/*namespace BibliotecaA
{
    public class Calculadora
    {

    }
}

namespace BibliotecaB
{
    public class Calculadora
    {

    }
}*/