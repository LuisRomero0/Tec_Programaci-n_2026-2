// Práctica #3 Estucturas de datos compuestas
// Contexto: Inventario de una tienda de electrónicos 

// Actividad 1

using System.Globalization;

public class Productos
{
    public int Id { get; set; }
    public string CodigoBarras { get; set; }    // Campo único
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"{Id} | {CodigoBarras} - {Nombre} | {Precio:C} | Stock: {Stock}";
    }

}

public class GestorProductos
{
    // Estructura : Lista 
    // Para mantener el orden de inserción y permitir ordenamientos 

    private List<Productos> listaProductos = new List<Productos>();

    // Estructura : Diccionario
    // Para busquedas rapidas por código de barras 

    private Dictionary<string, Productos> diccionarioPorCodigo = new Dictionary<string, Productos>();

    // OPERACIONES CON LISTA

    public void AgregarProducto(Productos p)
    {
        // Validar codigo de barras único
        if(diccionarioPorCodigo.ContainsKey(p.CodigoBarras))
        {
            throw new Exception("El código de barras ya existe.");
        }
        listaProductos.Add(p);
        diccionarioPorCodigo[p.CodigoBarras] = p;
    }

    public List<Productos> ObtenerListaProductos()
    {
        return new List<Productos>(listaProductos);
    }

    public bool EliminarProducto(string codigoBarras)
    {
        // Validar codigo de barras único
        if (diccionarioPorCodigo.TryGetValue(codigoBarras, out var producto))
        {
            listaProductos.Remove(producto);
            diccionarioPorCodigo.Remove(codigoBarras);
            return true;
        }
        return false;
    }

    public void MostrarInventario()
    {
        Console.WriteLine("Inventario completo (Orden de ingreso):");

        foreach (var p in listaProductos)
        {
            Console.WriteLine(p.ToString());
        }
    }

    // OPERACIONES CON DICCIONARIO (para busquedas especificas)

    public Productos BuscarPorCodigo(string codigoBarras)
    {
        return diccionarioPorCodigo.TryGetValue(codigoBarras, out var producto) ? producto : null;
    }

    public bool ExisteProducto(string codigoBarras)
    {
        return diccionarioPorCodigo.ContainsKey(codigoBarras);
    }

    public void MostrarProductosPorCategoria(string categoria)
    {
        Console.WriteLine($"Productos en la categoría: {categoria}");
        foreach (Productos producto in diccionarioPorCodigo.Values)
        {
            if (producto.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(producto.ToString());
            }
        }
    }
}