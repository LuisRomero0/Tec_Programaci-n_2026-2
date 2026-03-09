// PROGRAMA PRINCIPAL

Altavoz altavoz = new Altavoz();
Lampara lampara = new Lampara();
Ventilador ventilador = new Ventilador(false);

altavoz.Encender();
altavoz.MostrarEstado();

List<IDispositivoInteligente> dispositivos = new List<IDispositivoInteligente> { lampara, ventilador, altavoz };

// INTERFAZ Y CLASES

public interface IDispositivoInteligente
{
    void Encender();
    void Apagar();
    void MostrarEstado();
}

public class Lampara : IDispositivoInteligente
{
    // ATRIBUTO
    public bool EstaEncendido { get; set; }
    public int IntensidadLuz { get; set; } 

    // Constructor 
    public Lampara() 
    {
        EstaEncendido = false;
        IntensidadLuz = 50;
    }

    // Metodos
    public void Encender()
    {
        EstaEncendido = true;
        Console.WriteLine("La lámpara está encendida.");
    }

    public void Apagar()
    {
        EstaEncendido = false;
        Console.WriteLine("La lámpara está apagada.");
    }

    public void SubirIntensidadLuz(int nivel)
    {
        if (EstaEncendido == true) 
        {
            IntensidadLuz = nivel + 1;
        }
        else
        {
            Console.WriteLine("La lámpara está apagada. No se puede ajustar la intensidad.");
        }
    }

    public void BajarIntensidadLuz(int nivel)
    {
        if (EstaEncendido == true) 
        {
            IntensidadLuz = nivel - 1;
        }
        else
        {
            Console.WriteLine("La lámpara está apagada. No se puede ajustar la intensidad.");
        }
    }

    public void MostrarEstado()
    {
        if (EstaEncendido == true)
        {
            Console.WriteLine($"La lámpara está encendida emitiendo luz con intensidad {IntensidadLuz}.");
        }
        else
        {
            Console.WriteLine("La lámpara está apagada.");
        }
    }
}

public class Ventilador : IDispositivoInteligente
{
    // aTRIBUTO
    public bool EstaEncendido { get; set; }
    public int Velocidad { get; set; }

    // Constructor 
    public Ventilador(bool EstaEncendido)
    {
        this.EstaEncendido = EstaEncendido;
        this.Velocidad = 0;
    }   

    // Metodos
    public void Encender()
    {
        EstaEncendido = true;
        Console.WriteLine("El ventilador está encendido.");
    }

    public void Apagar()
    {
        EstaEncendido = false;
        Console.WriteLine("El ventilador está apagado.");
    }  
    
    public void AumentarVelocidad(int velocidad)
    {
        if (EstaEncendido == true)
        {
            Velocidad = velocidad + 1;
        }
        else
        {
            Console.WriteLine("El ventilador está apagado.");
        }
    }

    public void DisminuirVelocidad(int velocidad)
    {
        if (EstaEncendido == true)
        {
            Velocidad = velocidad - 1;
        }
        else
        {
            Console.WriteLine("El ventilador está apagado.");
        }
    }

    public void MostrarEstado()
    {
        string estado = EstaEncendido ? "encendido" : "apagado";
        Console.WriteLine($"El ventilador está {estado} a velocidad {Velocidad}.");
    }
}

public class Altavoz : IDispositivoInteligente
{
    // aTRIBUTO
    public bool EstaEncendido { get; private set; }

    // Metodos
    public void Encender()
    {
        EstaEncendido = true;
        Console.WriteLine("El altavoz está encendido.");
    }

    public void Apagar()
    {
        EstaEncendido = false;
        Console.WriteLine("El altavoz está apagado.");
    }

    public void ReproducirMusica(string cancion)
    {
        if (EstaEncendido)
        {
            Console.WriteLine($"El altavoz está reproduciendo: {cancion}.");
        }
        else
        {
            Console.WriteLine("El altavoz está apagado.");
        }
    }

    public void MostrarEstado()
    {
        string estado = EstaEncendido ? "encendido" : "apagado";
        Console.WriteLine($"El altavoz está {estado}.");
    }
}
