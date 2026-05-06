// SISTEMA DE ANALISIS DE TORMENTAS ELECTRICAS
// Estructuras No Lineales

// Crear descargas electricas como tuplas inmutables, con latitud, longitud y kilovoltios.

var origen = new Descarga(19.43, -99.320, 320.5);
var rama1 = new Descarga(25.12, -78.62, 285.6);
var rama2 = new Descarga(19.3328, -99.1821, 210.7);
var rama2a = new Descarga(19.15, -99.17, 95.3);

// Construir el arbol de propagacion del rayo

var analizador = new AnalizadorTormenta(origen);
var nodoRama1 = analizador.Propagacion.Origen;
analizador.Propagacion.Bifurcar(analizador.Propagacion.Origen, rama1);
analizador.Propagacion.Bifurcar(analizador.Propagacion.Origen, rama2);
var nodoRama2 = analizador.Propagacion.Origen.Ramas[1];
analizador.Propagacion.Bifurcar(nodoRama2, rama2a);

// Registrar sensores en la red
analizador.Red.Registrar(new SensorCampoElectrico("CE-01", 19.42, -99.10));
analizador.Red.Registrar(new SensorCampoElectrico("CE-02", 19.44, -99.14));
analizador.Red.Registrar(new SensorCampoElectrico("CE-03", 19.43, -99.13));

analizador.Red.Registrar(new SensorAcustico("AC-01", 19.40, -99.12));
analizador.Red.Registrar(new SensorAcustico("AC-02", 19.47, -99.16));

// Generar reporte de la tormenta

analizador.GenerarReporte();

// Sensor mas cercano a la descarga

var cercano = analizador.DetectarMasCercano(rama2a);
Console.WriteLine($"Sensor mas cercano a rama2a : {cercano.Id}");

// Acceso por ID 
var s = analizador.Red.ObtenerPorID("CE-02");
Console.WriteLine($"Consulta directa: {s.Medir()}");

// Excepcion

try
{
    analizador.Red.ObtenerPorID("CE-05");
}
catch (SensorNoEncontradoException ex)
{
    Console.WriteLine($" [ERROR] {ex.Message}");
}


// Record - Tupla inmutable (Tupla constante)

public record Descarga(double Latitud, double Longitud, double Kilovoltios)
{
    public double DistanciaA(Descarga otra)
    {
        return Math.Sqrt(Math.Pow(Latitud - otra.Latitud, 2) + Math.Pow(Longitud - otra.Longitud, 2));
    }
    public override string ToString()
    {
        return $"({Latitud:F2}, {Longitud:F2}) - {Kilovoltios:F1} kV";
    }
}

// Arbol clase para representar un nodo del arbol

public class NodoRayo
{
    public Descarga Descarga { get; set; }
    public int Nivel { get; }
    public List<NodoRayo> Ramas { get; } = new();
    // Abreviar de new List<NodoRayo>() a new()

    public NodoRayo(Descarga descarga, int nivel)
    {
        this.Descarga = descarga;
        this.Nivel = nivel;
    }
}

public class ArbolRayo
{
    public NodoRayo Origen { get; }

    public ArbolRayo(Descarga descargaOrigen) => Origen = new NodoRayo(descargaOrigen, 0);

    public void Bifurcar (NodoRayo padre, Descarga nueva)
    {
        padre.Ramas.Add(new NodoRayo(nueva, padre.Nivel + 1));
    }

    // Suma de los kV de todos los nodos del arbol
    public double IntensidadTotal(NodoRayo nodo)
    {
       return SumarkV(Origen);
    }

    private double SumarkV(NodoRayo nodo)
    {
        double total = nodo.Descarga.Kilovoltios;
        foreach (var rama in nodo.Ramas)
        {
            total += SumarkV(rama);
        }
        return total;
    }

    // DFS profundidad maxima del arbol

    public int ProfundidadMaxima(NodoRayo nodo)
    {
        return Profundidad(Origen);
    }

    private int Profundidad(NodoRayo nodo)
    {
        if(nodo.Ramas.Count == 0)
        {
            return nodo.Nivel;
        }
        return nodo.Ramas.Max(r => Profundidad(r));
    }

    // Imprimir el arbol con sangria por nivel

    public void Imprimir()
    {
        ImprimirNodo(Origen);
    }

    private void ImprimirNodo(NodoRayo nodo)
    {
        string sangria = new string(' ', nodo.Nivel * 3);
        string prefijo = nodo.Nivel == 0 ? "[ORIGEN]" : "└─";
        Console.WriteLine($"{sangria}{prefijo} {nodo.Descarga}");

        foreach (var rama in nodo.Ramas)
        {
            ImprimirNodo(rama);
        }
    }
}

// Clases para sensores 

// Excepcion personalizada 

public class SensorNoEncontradoException : Exception
{
    public SensorNoEncontradoException(string id) : base($"Sensor con ID '{id}' no registrado en la red.") { }
}

// Clase abstracta con polimosfismo Medir 
public abstract class SensorMeteorologico
{
    public string Id { get; }
    public double Latitud { get; }
    public double Longitud { get; }

    public bool Activo { get; set; } = true;

    public SensorMeteorologico(string id, double latitud, double longitud)
    {
        Id = id;
        Latitud = latitud;
        Longitud = longitud;
    }
    public abstract string Medir();
    public double DistanciaA(Descarga d)
    {
        return Math.Sqrt(Math.Pow(Latitud - d.Latitud, 2) + Math.Pow(Longitud - d.Longitud, 2));
    }
}

public class SensorCampoElectrico : SensorMeteorologico
{
    public SensorCampoElectrico(string id, double latitud, double longitud) : base(id, latitud, longitud) { }

    public override string Medir()
    {
        return $"[CE - {Id}] Campo: {new Random().Next(10, 200)} V/m";
    }
}

public class SensorAcustico : SensorMeteorologico
{
    public SensorAcustico(string id, double latitud, double longitud) : base(id, latitud, longitud) { }

    public override string Medir()
    {
        return $"[AC - {Id}] Ruido: {new Random().Next(80, 130)} dB";
    }
}

// Clase para red de sensores

public class RedSensores
{
    private Dictionary<string, SensorMeteorologico> sensores = new();

    public void Registrar(SensorMeteorologico s)
    {
        sensores[s.Id] = s;
    }

    public SensorMeteorologico ObtenerPorID(string id)
    {
        if (! sensores.TryGetValue(id, out var sensor))
        {
            throw new SensorNoEncontradoException(id);
        }
        return sensor;
    }

    public Dictionary<string, SensorMeteorologico> SensoresActivos()
    {
        return sensores.Where(par => par.Value.Activo).ToDictionary(par => par.Key, par => par.Value);
    }
}

// Interfaz

public interface IAnalizador
{
    SensorMeteorologico DetectarMasCercano(Descarga descarga);

    double IntensidadTotal();
    void GenerarReporte();
}

public class AnalizadorTormenta : IAnalizador
{
        public RedSensores Red { get; } = new();
        public ArbolRayo Propagacion { get; }

    public AnalizadorTormenta(Descarga origen) => Propagacion = new ArbolRayo(origen);
    
    // Buscar en el diccionario en el sensor mas cercano 

    public SensorMeteorologico DetectarMasCercano(Descarga descarga)
    {
        var activos = Red.SensoresActivos();
        if (! activos.Any())
        {
            throw new InvalidOperationException("Sin sensores activos");
        }
        return activos.Values.MinBy(s => s.DistanciaA(descarga));
    }

    public double IntensidadTotal()
    {
        return Propagacion.IntensidadTotal(Propagacion.Origen);
    }

    public void GenerarReporte()
    {
        Console.WriteLine("Reporte de Tormenta Electrica:");
        Console.WriteLine($"[Arbol de propagacion del rayo]");
        Propagacion.Imprimir();
        Console.WriteLine($"[Intensidad acumulada] {IntensidadTotal()} kV");
        Console.WriteLine($"[Sensores en red] {Red.ToString()}");
        Console.WriteLine($"[Mediciones activas]");

        foreach (var par in Red.SensoresActivos())
        {
            Console.WriteLine($"[{par.Key}] {par.Value.Medir()}");
        }
    }
}