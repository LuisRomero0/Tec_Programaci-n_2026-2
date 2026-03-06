// PROGRAMA PRINCIPAL DE DISPOSITIVOS ELECTRONICOS

Altavoz altavoz = new Altavoz();
Lampara lampara = new Lampara();
Ventilador ventilador = new Ventilador(false);

altavoz.Encender();
altavoz.MostrarEstado();
// corregir

// INTERFAZ Y CLASES

public interface IDispositivos
{
    void Encender();
    void Apagar();
    void MostrarEstado();
}


// Clase de pago en efectivo

public class Lampara : IDispositivos
{
    // ATRIBUTO
    public bool EstaEncendido { get; set; }
    public int SubirIntensidadLuz { get; set; }
    public int BajarIntensidadLuz { get; set; }

    // Constructor 


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

    public void SubirIntensidadLuz(int nivel = 0)
    {
        if (EstaEncendido = true)
        {
            AumentarIntensidadLuz = nivel + 1;
        }
        else
        {
            Console.WriteLine("La lámpara está apagada. No se puede ajustar la intensidad de luz.");
        }

    public void BajarIntensidadLuz(int nivel = 0)
    {
        if (EstaEncendido = true)
        {
            DisminuirIntensidadLuz = nivel - 1;
        }
        else
        {
            Console.WriteLine("La lámpara está apagada. No se puede ajustar la intensidad de luz.");
        }


    }

    public void MostrarEstado()
    {
        if (EstaEncendido = true)
        {
            Console.WriteLine("La lámpara está encendida.");
        }
        else
        {
            Console.WriteLine("La lámpara está apagada.");
        }

        if (EstaEncendido)
        {
            Console.WriteLine($"La lámpara está emitiendo luz con intensidad {nivel}.");
        }
        else
        {
            Console.WriteLine("La lámpara está apagada. No se puede ajustar la intensidad de luz.");
        }


    }
}












public class Ventilador : IDispositivos
{
    // aTRIBUTO
    public bool EstaEncendido { get; set; }
    public int AumentarVelocidad { get; set; }
    public int DisminuirVelocidad { get; set; }

    // Constructor 
    public Ventilador(bool EstaEncendido)
        {
        this.EstaEncendido = EstaEncendido;
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
    
    public void AumentarVelocidad(int velocidad = 0)
        {
            if (EstaEncendido = true)
            {
                AumentarVelocidad = velocidad + 1;
            }
            else
            {
                Console.WriteLine("El ventilador está apagado. No se puede ajustar la velocidad a la que gira.");
            }
    }

    public int DisminuirVelocidad(int velocidad = 0)
    {
        if (EstaEncendido = true)
        {
            DisminuirVelocidad = velocidad - 1;
        }
        else
        {
            Console.WriteLine("El ventilador está apagado. No se puede ajustar la velocidad a la que gira.");
        }
        return DisminuirVelocidad;      // corregir
    }

    public void MostrarEstado()
    {
        string estado = EstaEncendido ? "encendido" : "apagado";
        Console.WriteLine($"El ventilador está {estado}.");
    }


}













public class Altavoz : IDispositivos
{
    // aTRIBUTO
    public bool EstaEncendido { get; private set; }

    // Constructor 


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
            Console.WriteLine($"El altavoz está reproduciendo la canción: {cancion}.");
        }
        else
        {
            Console.WriteLine("El altavoz está apagado. No se puede reproducir música.");
        }
    }

    public void MostrarEstado()
    {
        string estado = EstaEncendido ? "encendido" : "apagado";
        Console.WriteLine($"El altavoz está {estado}.");
    }
}




// corregir mostrar estado de todos 
// checar el constructor de todos
// checar lo de crear lista 

List <IDispositivos> dispositivos = new List<IDispositivos>( lampara,ventilador, altavoz ); // ??