// Práctica #3 Estucturas de datos compuestas
// Contexto: Inventario de una tienda de electrónicos 


// Crear una instancia del gestor de productos

var gestor  = new GestorProductos();

// ACTIVIDAD 1: IMPLEMENTAR LAS ESTRUCTURAS
Console.WriteLine("Estructuras de datos");

// Agregar productos al inventario
gestor.AgregarProducto(new Productos { Id = 3, CodigoBarras = "123456", Nombre = "Audifonos", Categoria = "Audio", Precio = 5.99m, Stock = 10});
gestor.AgregarProducto(new Productos { Id = 1, CodigoBarras = "789456", Nombre = "Xbox", Categoria = "Entretenimiento", Precio = 1000m, Stock = 10 });
gestor.AgregarProducto(new Productos { Id = 4, CodigoBarras = "456123", Nombre = "Mouse", Categoria = "Accesorios", Precio = 60m, Stock = 15 });
gestor.AgregarProducto(new Productos { Id = 2, CodigoBarras = "741258", Nombre = "PlayStation", Categoria = "Entretenimiento", Precio = 1500m, Stock = 20});

// Mostrar inventario

gestor.MostrarInventario();

// Mostrar por categoria
gestor.MostrarProductosPorCategoria("Entretenimiento");

// Buscar por código de barras
Console.WriteLine("Buscando producto con código 123456:");
var productoEncontrado = gestor.BuscarPorCodigo("123456");
Console.WriteLine(productoEncontrado != null ? productoEncontrado.ToString() : "No encontrado");

// ACTIVIDAD 2: ORDENAR LAS COSAS

Console.WriteLine("Algoritmos de ordenacion");

// Creando copia de la lista a ordenar
var productosParaOrdenarPrecio = new List<Productos>(gestor.ObtenerListaProductos());
Console.WriteLine("Orden por precio");
Ordenador.QuickSortPorPrecio(productosParaOrdenarPrecio);
MostrarListaProductos(productosParaOrdenarPrecio);

var productosParaOrdenarNombre = new List<Productos>(gestor.ObtenerListaProductos());
Console.WriteLine("Orden por nombre");
var productosOrdenadosMerge = Ordenador.MergeSortPorNombre(productosParaOrdenarNombre);
MostrarListaProductos(productosParaOrdenarNombre);


// ACTIVIDAD 3: ALGORITMOS DE BUSQUEDA 

// Ordenar por ID
var productosOrdenadosId = new List<Productos>(gestor.ObtenerListaProductos());
Ordenador.QuickSortPorId(productosOrdenadosId);
Console.WriteLine("Busqueda binaria por ID : 3");
var (productoBin, iterBin) = Buscador.BusquedaBinaria(productosOrdenadosId, 3);
Console.WriteLine($"Resultado: {productoBin?.ToString() ?? "No encontrado"} | Iteraiones: {iterBin}");

// Ordenar por Nombre
var productosOrdenadosNombre = new List<Productos>(gestor.ObtenerListaProductos());
Ordenador.MergeSortPorNombre(productosOrdenadosNombre);
Console.WriteLine("Busqueda Secuencial por Nombre : 3");
var (productoNom, iterNom) = Buscador.BusquedaSecuencial(productosOrdenadosNombre, "Audifonos");
Console.WriteLine($"Resultado: {productoNom?.ToString() ?? "No encontrado"} | Iteraiones: {iterNom}");




// Funcion auxliar para mostrar elementos en listas

void MostrarListaProductos(List<Productos> productos)
        {
            foreach (Productos producto in productos)
            {
                Console.WriteLine(producto.ToString());
            }
        }


// Actividad 1

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


// Actividad 2
public class Ordenador
{
    // ALGORITMO DE ORDENAMIENTO: QuickSort
    public static void QuickSortPorId(List<Productos> productos)
    {
        // Caso en el que termina la recursividad 
        if(productos.Count <= 1)
        {
            return;
        }

        // 1. Elegir pivote
        Productos pivote = productos[productos.Count - 1];
        var menores = new List<Productos>();
        var mayores = new List<Productos>();

        // 2. Reorganizar la lista para determinar menores al pivote o mayores al pivote
        for (int i = 0; i < productos.Count - 1; i++)
        {
            if(productos[i].Id < pivote.Id)
            {
                menores.Add(productos[i]);
            }
            else
            {
                mayores.Add(productos[i]);
            }
        }

        // 3. Recursivamente aplicar el algoritmo 
        QuickSortPorId(menores);
        QuickSortPorId(mayores);

        // 4. Reconstruir lista con elementos ordenados 
        productos.Clear();
        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }

    public static void QuickSortPorPrecio(List<Productos> productos)
    {
        // Caso en el que termina la recursividad 
        if (productos.Count <= 1)
        {
            return;
        }

        // 1. Elegir pivote
        Productos pivote = productos[productos.Count - 1];
        var menores = new List<Productos>();
        var mayores = new List<Productos>();

        // 2. Reorganizar la lista para determinar menores al pivote o mayores al pivote
        for (int i = 0; i < productos.Count - 1; i++)
        {
            if (productos[i].Precio < pivote.Precio)
            {
                menores.Add(productos[i]);
            }
            else
            {
                mayores.Add(productos[i]);
            }
        }

        // 3. Recursivamente aplicar el algoritmo 
        QuickSortPorPrecio(menores);
        QuickSortPorPrecio(mayores);

        // 4. Reconstruir lista con elementos ordenados 
        productos.Clear();
        productos.AddRange(menores);
        productos.Add(pivote);
        productos.AddRange(mayores);
    }

    // ALGORITMO DE ORDENAMIENTO: MergeSort

    public static List<Productos> MergeSortPorNombre(List<Productos> productos)
    {
        // Caso que detiene la recursividad
        if (productos.Count <= 1)
        {
            return productos;
        }

        // 1. Dividir la lista en dos mitades
        int mitad = productos.Count / 2;
        var izquierda = productos.GetRange(0, mitad);
        var derecha = productos.GetRange(mitad, productos.Count - mitad);

        // 2. Ordenar recursivamente cada mitad
        izquierda = MergeSortPorNombre(izquierda);
        derecha = MergeSortPorNombre(derecha);

        // 3. Mezclar las dos mitades ordenadas
        return Mezclar(izquierda, derecha);

    }
    private static List <Productos> Mezclar(List<Productos> izquierda, List<Productos> derecha)
    {
        var resultado = new List<Productos>();
        int i = 0, j = 0;

        // 4. Comparar y agregar en orden 

        while(i < izquierda.Count && j < derecha.Count)
        {
            if (string.Compare(izquierda[i].Nombre, derecha[j].Nombre) < 0)
            {
                resultado.Add(izquierda[i++]);
            }
            else
            {
                resultado.Add(derecha[j++]);
            }
        }

        // 5. Agregar los elementos restantes (si los hay)
        while (i < izquierda.Count)
        {
            resultado.Add(izquierda[i++]);
        }
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j++]);
        }
        return resultado;   
    }


    public static List<Productos> MergeSortPorPrecio(List<Productos> productos)
    {
        // Caso que detiene la recursividad
        if (productos.Count <= 1)
        {
            return productos;
        }

        // 1. Dividir la lista en dos mitades
        int mitad = productos.Count / 2;
        var izquierda = productos.GetRange(0, mitad);
        var derecha = productos.GetRange(mitad, productos.Count - mitad);

        // 2. Ordenar recursivamente cada mitad
        izquierda = MergeSortPorPrecio(izquierda);
        derecha = MergeSortPorPrecio(derecha);

        // 3. Mezclar las dos mitades ordenadas
        return MezclarPrecio(izquierda, derecha);

    }
    private static List<Productos> MezclarPrecio(List<Productos> izquierda, List<Productos> derecha)
    {
        var resultado = new List<Productos>();
        int i = 0, j = 0;

        // 4. Comparar y agregar en orden 

        while (i < izquierda.Count && j < derecha.Count)
        {
            if (izquierda[i].Precio < derecha[j].Precio)
            {
                resultado.Add(izquierda[i++]);
            }
            else
            {
                resultado.Add(derecha[j++]);
            }
        }

        // 5. Agregar los elementos restantes (si los hay)
        while (i < izquierda.Count)
        {
            resultado.Add(izquierda[i++]);
        }
        while (j < derecha.Count)
        {
            resultado.Add(derecha[j++]);
        }
        return resultado;
    }
}


// Actividad 3

public class Buscador
{
    // Algoritmo de búsqueda: Busqueda binaria (lista ordenada por ID)

    public static (Productos, int) BusquedaBinaria(List<Productos> productos, int idBuscado)
    {
        int inicio = 0;
        int fin = productos.Count - 1;
        int iteraciones = 0;

        while (inicio <= fin)
        {
            iteraciones++;

            // 1. Calcular el punto medio
            int medio = (inicio + fin) / 2;

            // 2. Comprobar si encontramos el ID 
            if (productos[medio].Id == idBuscado)
            {
                return (productos[medio], iteraciones);
            }

            // 3. Ajustar los limites de busqueda 
            if(productos[medio].Id < idBuscado)
            {
                inicio = medio + 1; // Buscar en la mitad derecha
            }
            else
            {
                fin = medio - 1; // Buscar en la mitad izquierda
            }
        }
        return (null, iteraciones); // Retornar null si no se encuentra el ID
    }

    // Busqueda secuencial (lista no ordenada)

    public static (Productos, int) BusquedaSecuencial(List<Productos> productos, string nombreBuscado)
    {
        int iteraciones = 0;

        // 1. Recorrer la lista elemento a elemento
        foreach (Productos producto in productos)
        {
            iteraciones++;

            // 2. Comparar el código de barras
            if (producto.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return (producto, iteraciones);
            }
        }
        return (null, iteraciones); // No encontrado
    }
}