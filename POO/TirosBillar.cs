// ROMERO CASTRO LUIS ÁNGEL

// --- PROGRAMA PRINCIPAL ---

Bola bola1 = new Bola(0,0,10);
try
{
    int operaciones = int.Parse(Console.ReadLine() ?? "");

    for (int i = 0; i < operaciones; i++)
    {
        string[] entrada = (Console.ReadLine() ?? "").Split(' ');
        string comando = entrada[0];
        switch (comando)
        {
            case "BOLA NORMAL":
                bola1 = new BolaNormal(0, 0, 10);

                break;
            case "BOLA PRO":
                bola1 = new BolaProfesional(0, 0, 10);
                break;

            case "TIRO":
                int impulso = int.Parse(entrada[1]);
                int dirX = int.Parse(entrada[2]);
                int dirY = int.Parse(entrada[3]);
                Tiro tiro = new Tiro(impulso, dirX, dirY);
                break;

            case "CRITERIO FISICA":
                IEstrategiaCalculo estrategiaFisica = new IEstrategiaCalculo.Calculofisico();
                break;

            case "CRITERIO SIMPLE":
                IEstrategiaCalculo estrategiaSimple = new IEstrategiaCalculo.CalculoSimple();
                break;

            case "SIMULAR":
                
                break;

            case "RESULTADO":

                break;

            default: throw new InvalidOperationException("Comando no valido");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// --- CLASES ---

public class Bola
{
    protected internal double Masa { get; set; }
    public double X { get; protected set; }
    public double Y { get; protected set; }

    public Bola(int x, int y, double masa)
    {
        X = x;
        Y = y;
        Masa = masa;
    }

    public void Mover(double dx, double dy)
    {
        X += dx;
        Y += dy;
    }

    public virtual double ObtenerCoeficienteFriccion()
    {
        return 0.0;
    }
}

// --- CLASES HIJAS ---

public class BolaNormal : Bola
{
    public double CoeficienteFriccion = 1.2;

    public BolaNormal(int x, int y, double masa) : base(x, y, masa) { }

    public override double ObtenerCoeficienteFriccion() => CoeficienteFriccion;
}

public class BolaProfesional : Bola
{
    public double CoeficienteFriccion = 0.6;

    public BolaProfesional(int x, int y, double masa) : base(x, y, masa) { }
    public override double ObtenerCoeficienteFriccion() => CoeficienteFriccion;
}

public class Tiro 
{
    public int Impulso { get; set; }
    public int DirX { get; set; } 
    public int DirY { get; set; }

    public Tiro(int impulso, int dirX, int dirY)
    {
        Impulso = impulso;
        DirX = dirX;
        DirY = dirY;
    }
}

// --- INTERFACES ---

public interface IEstrategiaCalculo
{
    double CalcularDistancia(Bola bola, Tiro tiro);

    // Estrategia 1: Cálculo Simple
    public class CalculoSimple : IEstrategiaCalculo
    {
        public double CalcularDistancia(Bola bola, Tiro tiro)
        {
            return tiro.Impulso * 2;
        }
    }

    // Estrategia 2: Cálculo Físico (con fricción)
    public class Calculofisico : IEstrategiaCalculo
    {
        private const double g = 9.81; // Aceleración debido a la gravedad
        public double CalcularDistancia(Bola bola, Tiro tiro)
        {

            double v0 = tiro.Impulso / bola.Masa;

       
            double mu = bola.ObtenerCoeficienteFriccion();
            double a = -mu * g;

            
            double distancia = -(Math.Pow(v0, 2)) / (2 * a);

            return distancia;
        }
    }
}


public class SimuladorBillar
{
    //List<Tiros> tirosRegistrados = new List<Tiros>();
    // METODOS
    private Bola bolaActiva;
    private List<Tiro> tirosRegistrados = new List<Tiro>();
    private IEstrategiaCalculo estrategiaActual;
    private double distanciaTotal;
    public void CrearBola(Bola bola)
    {
   
    }

    public Bola RegistrarTiro(Bola bola, Tiro tiro, IEstrategiaCalculo estrategia)
    {
        double distancia = estrategia.CalcularDistancia(bola, tiro);
        Console.WriteLine($"Distancia calculada: {distancia}");
        return bola;
    }

    public void CambiarEstrategia(string criterio)
    {
        if (criterio == "CRITERIO FISICA")
        {
            IEstrategiaCalculo estrategiaFisica = new IEstrategiaCalculo.Calculofisico();
            Console.WriteLine("Estrategia de cálculo cambiada a física.");
        }
        else if (criterio == "CRITERIO SIMPLE")
        {
            IEstrategiaCalculo estrategiaSimple = new IEstrategiaCalculo.CalculoSimple();
            Console.WriteLine("Estrategia de cálculo cambiada a simple.");
        }
    }

    public void simularTiro(Bola bola, Tiro tiro, IEstrategiaCalculo estrategia)
    {
        if (bolaActiva == null || tirosRegistrados.Count == 0 || estrategia == null)
        {
            throw new InvalidOperationException("No hay bola activa o tiros registrados para simular.");
        }
        else
        {
            Tiro t = tirosRegistrados[tirosRegistrados.Count - 1];
            double distancia = estrategia.CalcularDistancia(bolaActiva, t);
            double hipotenusa = Math.Sqrt(Math.Pow(t.DirX, 2) + Math.Pow(t.DirY, 2));
        }
    }
    public void MoverBola(Bola bola, double distancia, Tiro tiro)
    {
        double hipotenusa = Math.Sqrt(Math.Pow(tiro.DirX, 2) + Math.Pow(tiro.DirY, 2));
        double dx = (tiro.DirX / hipotenusa) * distancia;
        double dy = (tiro.DirY / hipotenusa) * distancia;
        bola.Mover(dx, dy);
    }

    public void MostrarResultados(Bola bola, Tiro tiro, double distancia)
    {
        Console.WriteLine($"Distancia calculada: {distancia}");
        Console.WriteLine($"Bola en posición ({bola.X}, {bola.Y})");
    }
}