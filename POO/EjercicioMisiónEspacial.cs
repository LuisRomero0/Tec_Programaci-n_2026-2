// PROGRAMA PRINCIPAL
Inventario inventario = new Inventario();
bool salir = false;
while (!salir)
{
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("Menu de suministros:");
    Console.WriteLine("1. Mostrar Suministro");
    Console.WriteLine("2. Buscar Suministro");
    Console.WriteLine("3. Ordenar por nombre");
    Console.WriteLine("4. Invertir orden");
    Console.WriteLine("5. Vaciar inventario");
    Console.WriteLine("6. Agregar suministro");
    Console.WriteLine("7. Eliminar suministro");
    Console.WriteLine("8. Salir");

    Console.Write("Ingresa tu selección:");

    int opcion = int.Parse(Console.ReadLine() ?? "");
    switch (option)
    {
        case 1:
            inventario.MostrarSuministro();
            break;
        case 2:
            Console.WriteLine("Ingresa el nombre del suministro a buscar: ");
            string nombre = Console.ReadLine() ?? "";
            inventario.BuscarSuministro();
            break;
        case 3:
            inventario.OrdenarPorNombre();
            break;
        case 4:
            inventario.InvertirOrden();
            break;
        case 5:
            inventario.VaciarInventario();
            break;
        case 6:
            Console.WriteLine("Ingresa el nombre del suministro a agregar:");
            string nombreSum = Console.ReadLine() ?? "";

            Console.WriteLine("Cantidad o vaco:");
            string cantidad = Console.ReadLine() ?? "";

            if (cantidad != "")
            {

                Console.WriteLine("Prioridad o vacio:");
                string nombreSum = Console.ReadLine() ?? "";
                
                inventario.AgregarSuministro(nombreSum, int.Parse(cantidad), int.Parse(prioridad));
            }
            else
            {
                inventario.AgregarSuministro(nombreSum);
            }

            break;
        case 7:
            Console.WriteLine("Ingresa el nombre del suministro eliminar:");
            string nombreSum = Console.ReadLine() ?? "";
            inventario.EliminarSuministro(nombreElim);
            break;
        case 8:
            salir = true;
            break;
        default:
    }
}

 // excepciones al poner letras al agregra suministro 
 // y excepciones al eliminar un elemento 

public class Suministro
{
    // Atributos
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Prioridad { get; set; }

    // Constructor
    public Suministro(string nombre, int cantidad, int prioridad)
    {
        Nombre = nombre;
        Cantidad = cantidad;
        Prioridad = prioridad;
    }

        // Sobrecarga Constructor
        public Suministro(string nombre)
        {
            Nombre = nombre;
            Cantidad = 1;
            Prioridad = 2;
        }

    //Métodos
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre del suministro: {Nombre}");
        Console.WriteLine($"Cantidad disponible del suministro: {Cantidad}");
        Console.WriteLine($"Nivel de prioridad: {Prioridad}");

    }
}

public class Inventario
{
    //Atributos
    private Suministro[] suministros;

    //Constructor
    public Inventario()
    {
        suministros = new Suministro[]
        {
            new Suministro("Oxigeno", 15, 1),
            new Suministro("Gasolina"),
            new Suministro("Comida", 30, 1),
            new Suministro("Almohada", 15, 3),
            new Suministro("Botiquin", 4, 1),
            new Suministro("Herramientas"),
        };

    }



    //Métodos

    public void MostrarSuministros()
    {
        Console.ForegroundColor = ConsoleColor.Yellow; 
        Console.WriteLine("Inventario de suministros:");
        Console.ForegroundColor = ConsoleColor.Blue;

        foreach(Suministro suministro in suministros)
        {
            suministro.MostrarInfo();
        }
    }




    public void BuscarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower());

        if (indice >= 0)
        {
            Console.WriteLine($"{nombre} se encontro en la posicion {indice}");
        }
        else 
        {
            Console.WriteLine($"{nombre} no se encuentra en el inventario");
        }
    }

    public void OrdenarPorNombre()
    {
        Array.Sort(suministros,(x,y) => x.Nombre.CompareTo(y.Nombre));
        Console.WriteLine("Suministros ordenados por nombre");
    }

    public void InvertirOrden()
    {
        Array.Reverse(suministros);
        Console.WriteLine("Orden invertido");
    }

    public void VaciarInventario()
    {
        Array.Clear(suministros, 0, suministros.Length);
        Console.WriteLine($"Inventario borrado: {suministros.Length}");
    }

    // AGREGAR SUMINISTROS

    public void AgregarSuministro(string nombre, int cantidad, int prioridad)
    {
        int indiceNull = Array.FindIndex(suministros, s => s == null);
        if (indiceNull >= 0)
        {
            suministros[indiceNull] = new Suministro(nombre, cantidad, prioridad);
        }
        else
        {
            Array.Resize(ref suministros, suministros.Length + 1);
            suministros[suministros.Length - 1] = new Suministro(nombre, cantidad, prioridad);        
        }
        Console.WriteLine($"{nombre} agregado al inventario");
    }

    public void AgregarSuministro(string nombre)
    {
        AgregarSuministro(nombre, 1, 2);
    }



    // ELIMINAR SUMINISTROS

    public void EliminarSuministro(string nombre)
    {
        int indice = Array.FindIndex(suministros, s => s.Nombre.ToLower() == nombre.ToLower());
        if (indice >= 0)
        {
            for (int i = indice; i < suministros.Length - 1; i++)
            {
                suministros[i] = suministros[i + 1];
            }

            Array.Resize(ref suministros, suministros.Length - 1);
            Console.WriteLine($"{nombre} eliminado del inventario");
        }
        else
        {
            Console.WriteLine($"{nombre} no encontrado");
        }
    }
}
