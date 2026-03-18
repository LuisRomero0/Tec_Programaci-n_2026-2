using BibliotecaDeLibros;
using ExtensionesBiblioteca;
using ValidacionesBiblioteca;

GestorLibros gestor = new GestorLibros();

// Agregar un libro
gestor.AgregarLibro(new Libro("El señor de los anillos", "Tolkien", 1954));
gestor.AgregarLibro(new Libro("Duna", "Frank", 1965));
gestor.AgregarLibro(new Libro("Juego de tronos", "George", 1996));

// Mostrar libros

Console.WriteLine("Libros en la biblioteca:");
gestor.MostrarLibros();

// USAR MÉTODO DE EXTENSIÓN
Libro libro = gestor.BuscarLibrosPorAutor("George")[0];
Console.WriteLine("Formato de referncia de un libro");
Console.WriteLine(libro.FormatoInformacion());
Console.WriteLine($"Es libro antiguo {libro.EsLibroAntiguo}");


//USA VALIDACIONES

Console.WriteLine("Es año valido 2025" + Validaciones.EsAnioValido(2025));