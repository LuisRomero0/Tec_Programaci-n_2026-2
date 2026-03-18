using BibliotecaDeLibros;

namespace ExtensionesBiblioteca
{
    public static class LibroExtensiones
    {
        public static bool EsLibroAntiguo(this Libro libro)
        {
            return ((DateTime.Now.Year - libro.AnioPublication) > 50);
        }

        public static string FormatoInformacion(this Libro libro)
        {
            return $"{libro.Autor} ({libro.Titulo} - {libro.AnioPublication})";
        }
    }
}
