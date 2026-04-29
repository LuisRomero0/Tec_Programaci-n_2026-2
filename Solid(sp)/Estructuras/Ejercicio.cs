// Programa Pincipal
Festival festival = new Festival("Kermes FI");
Console.WriteLine($"Bienvenido Al Festival De Música \n      === {festival.Nombre} ===   \n");

// Crear banda y sus sets de canciones
Console.WriteLine("REGISTRANDO BANDAS Y SETS");

// Banda 1
Banda muse = new Banda("Muse", "UK", new TimeSpan(19, 0, 0), 5);
muse.CargarCancion(0, new Cancion("Starlight", 4, "Rock"));
muse.CargarCancion(1, new Cancion("Histeria", 3, "Rock"));
muse.CargarCancion(2, new Cancion("Nights Of Cydonia", 3, "Rock"));
muse.CargarCancion(3, new Cancion("Madness", 5, "Rock"));
muse.CargarCancion(4, new Cancion("ASDFGASDFG", 2, "Rock"));

// Banda 2
Banda djo = new Banda("DJO", "UE", new TimeSpan(18, 0, 0), 3);
djo.CargarCancion(0, new Cancion("Crux", 3, "Rock"));
djo.CargarCancion(1, new Cancion("End of begining", 3, "Rock"));
djo.CargarCancion(2, new Cancion("Back on you", 5, "Rock"));

// Banda 3
Banda bts = new Banda("BTS", "COR", new TimeSpan(21, 0, 0), 3);
bts.CargarCancion(0, new Cancion("butter", 3, "Kpop"));
bts.CargarCancion(1, new Cancion("body to body", 3, "kpop"));
bts.CargarCancion(2, new Cancion("hooli", 3, "kpop"));

// Banda 4
Banda calibre50 = new Banda("Calibre50", "MEX", new TimeSpan(23, 0, 0), 3);
calibre50.CargarCancion(0, new Cancion("Si te pudiera mentir", 4, "Banda"));
calibre50.CargarCancion(1, new Cancion("El tierno se fue", 4, "Banda"));
calibre50.CargarCancion(2, new Cancion("El amor de mi vida", 2, "Banda"));


// Agregar al Festival
festival.AgregarBanda(muse);
festival.AgregarBanda(djo);
festival.AgregarBanda(bts);
festival.AgregarBanda(calibre50);


// Duracion total de cada set
Console.WriteLine($"\nDuracion de sets por banda");
foreach (Banda b in festival.Cartel)
{
    Console.WriteLine($"     {b.Nombre} - {b.DuracionTotalSet()} ");
}


// ORDEN original PRESENTACION
Console.WriteLine($"\nREORDENANDO SHOW");
festival.ResumenCartel();


// Cambio de ultimo minuto de banda nueva invitada confirmada

// Banda 5 Sopresa
Banda MJ = new Banda("MJ", "US", new TimeSpan(22, 0, 0), 2);
MJ.CargarCancion(0, new Cancion("Thriller", 5, "Pop"));
MJ.CargarCancion(1, new Cancion("Beat it", 4, "Pop"));

Console.WriteLine($"\n¡Cambio De Último Minuto, {MJ.Nombre} Confirmado! \n  Despues De BTS, Antes De Calibre 50\n");

// 3. Insertar MJ al orden show
festival.AgregarBanda(MJ);

LinkedListNode<Banda> nodoBTS = festival.OrdenShow.Find(bts);

if (nodoBTS != null)
{
    festival.InsertarBandaDespuesDe(MJ, nodoBTS);
}
else
{
    Console.WriteLine("No se encontró a BTS en el orden del show.\n");
}

// Cancelar a otra
Console.WriteLine("\n PROCESANDO CANCELACIÓN");
festival.CancelarBanda(djo);
Console.WriteLine("\n");
festival.ResumenCartel();

// 4. Fila de Ingreso
Console.WriteLine("\n ASISTENTES EN FILA DE INGRESO");

// asistentes
festival.FilaIngreso.Enqueue(new Asistente("Gustavo", 1001, new TimeSpan(16, 30, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Carlos", 1002, new TimeSpan(16, 37, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Bruno", 1003, new TimeSpan(16, 42, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Daniela", 1004, new TimeSpan(16, 44, 0)));
festival.FilaIngreso.Enqueue(new Asistente("Jorge", 1005, new TimeSpan(16, 49, 0)));


Console.WriteLine($"{festival.FilaIngreso.Count} Asistentes Esperando...\n");

while (festival.FilaIngreso.Count > 0)
{
    Asistente admitido = festival.AdmitirSiguiente();
    Console.WriteLine($"✓ Ingresa: {admitido}");
}

// 5. Bandass Tocando
Console.WriteLine("\n SIMULACIÓN DE PRESENTACIONES EN EL ESCENARIO");

festival.RegistrarPresentacion(muse);
festival.RegistrarPresentacion(bts);
festival.RegistrarPresentacion(MJ);
Console.WriteLine($"En el escenario ahora: {festival.UltimaEnTocar().Nombre}");

Console.WriteLine("\n HISTORIAL DE PRESENTACIONES (Más reciente primero)");
Stack<Banda> historialCopia = new Stack<Banda>(festival.HistorialEscenario);

int puesto = 1;
while (historialCopia.Count > 0)
{
    Banda b = historialCopia.Pop();
    Console.WriteLine($"{puesto}. {b.Nombre}");
    puesto++;
}



Console.WriteLine($"\n RESUMEN FINAL DEL CARTEL: {festival.Nombre}");
festival.ResumenCartel();

Console.WriteLine($"\n¡Gracias por asistir a {festival.Nombre}!");




public class Cancion
{
    // Atributos de la clase Cancion
    public string Titulo { get; set; }
    public int DuracionMinutos { get; set; }
    public string Genero { get; set; }


    // Constructor para inicializar la canción
    public Cancion(string titulo, int duracionMinutos, string genero)
    {
        Titulo = titulo;
        DuracionMinutos = duracionMinutos;
        Genero = genero;
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

    // MetodosA 

    public void CargarCancion(int posicion, Cancion cancion)
    {
        if (posicion >= SetCanciones.Length || posicion < 0)
        {
            throw new ArgumentException($"¨Posicion Invalida: {posicion}");
        }

        SetCanciones[posicion] = cancion;
    }

    public int DuracionTotalSet()
    {
        // Recorrer el arreglo sumando duraciones
        int total = 0;
        foreach (Cancion cancion in SetCanciones)
        {
            if (cancion != null)
            {
                total += cancion.DuracionMinutos;
            }
        }

        return total;
    }

    public override string ToString()
    {
        return $"{Nombre} ({Origen}) | {HoraPresentacion: hh\\:mm}";
    }

}

public class Asistente
{
    // Atributos y Propiedades
    public string Nombre { get; set; }
    public int NumeroEntrada { get; set; }
    public TimeSpan HoraLlegada { get; set; }
    public bool YaIngreso { get; set; }

    // Constructor Linea 90 miss
    public Asistente(string nombre, int numeroEntrada, TimeSpan horaLlegada)
    {
        Nombre = nombre;
        NumeroEntrada = numeroEntrada;
        HoraLlegada = horaLlegada;
        YaIngreso = true;
    }

    // Metodos
    public override string ToString()
    {
        return $"#{NumeroEntrada} {Nombre} llego a las {HoraLlegada:hh\\:mm} ";
    }
}

public class Festival
{
    // Propiedades Y Atributos
    // Normal
    public string Nombre { get; set; }

    // 4 Estructuras Lineales
    public List<Banda> Cartel { get; set; }
    public Stack<Banda> HistorialEscenario { get; set; }
    public Queue<Asistente> FilaIngreso { get; set; }
    public LinkedList<Banda> OrdenShow { get; set; }

    // Constructor
    public Festival(string nombre)
    {
        Nombre = nombre;
        Cartel = new List<Banda>();
        HistorialEscenario = new Stack<Banda>();
        FilaIngreso = new Queue<Asistente>();
        OrdenShow = new LinkedList<Banda>();
    }

    // Metodos
    public void AgregarBanda(Banda banda)
    {
        Cartel.Add(banda);
        OrdenShow.AddLast(banda);
        Console.WriteLine($"[+] Banda Confirmada {banda.Nombre}");
    }

    public void CancelarBanda(Banda banda)
    {
        if (Cartel.Contains(banda))
        {
            Cartel.Remove(banda);
            OrdenShow.Remove(banda);
            Console.WriteLine($"[-] Banda Cancelada {banda.Nombre}");
        }
        else
        {
            Console.WriteLine($"Banda{banda.Nombre} no se encontró");
        }
    }

    public void InsertarBandaDespuesDe(Banda nueva, LinkedListNode<Banda> despuesDe)
    {
        OrdenShow.Remove(nueva);
        OrdenShow.AddAfter(despuesDe, nueva);
        Console.WriteLine($"    [] {nueva.Nombre} Reubicada en el orden del show");
    }

    public void RegistrarPresentacion(Banda banda)
    {
        HistorialEscenario.Push(banda); // push apila pero no saca
        // para sacar hay dos metodos, uno que elimina y otro que no elimina...
        Console.WriteLine($"  [★] Presentacion registrada: {banda.Nombre}");

    }

    public Asistente AdmitirSiguiente()
    {
        // es una cola asi que cuando se sacan de la cola, tambien se deben de eliminar con DEQUEUE
        Asistente asistente = FilaIngreso.Dequeue();
        asistente.YaIngreso = true;
        return asistente;
    }

    public Banda UltimaEnTocar()
    {
        // El peek muestra cual es la ultima banda...
        return HistorialEscenario.Peek();
    }

    public void ResumenCartel()
    {

        // Copia de la lista de bandas para no alterar el original.
        List<Banda> ordenada = new List<Banda>(Cartel);

        // Ordenamiento Burbuja Sobre hora de presentacion
        int n = ordenada.Count;
        for (int i = 0; i < n - 1; i++) // indices todos los elementos menos 1 porque inicia en 0
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (ordenada[j].HoraPresentacion > ordenada[j + 1].HoraPresentacion)
                {
                    Banda temp = ordenada[j];
                    ordenada[j] = ordenada[j + 1];
                    ordenada[j + 1] = temp;
                }
            }
        }

        Console.WriteLine($"Cartel Oficial - {Nombre}");
        foreach (Banda b in ordenada)
        {
            Console.WriteLine($"     {b.HoraPresentacion:hh\\:mm} {b.Nombre}");
        }
    }
}
