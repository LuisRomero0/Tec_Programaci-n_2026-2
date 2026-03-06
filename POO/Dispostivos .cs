// PROGRAMA PRINCIPAL CON INSTRUCCIONES DE NIVEL SUPERIOR

Lampara lampara = new Lampara("Lamparita", 100, 40);
Ventilador ventilador = new Ventilador("Aire", 500, 50);

// Encender ambos dispositivos 

lampara.Encender();
ventilador.Encender();

// Mostrar información

Console.WriteLine(lampara.MostrarInfo());
Console.WriteLine(ventilador.MostrarInfo());

// Ajustamos consumo 

lampara.AjustarConsumo();
ventilador.AjustarConsumo();

// Comparacion con operadores 

if (lampara > ventilador)
{
    Console.WriteLine("Lampara consume más");
}
else if (lampara < ventilador)
{
    Console.WriteLine("Ventilador consume más")
}
else
{
    Console.WriteLine("Ambos consumen la misma energía")
}


public class Dispositivos
{
    // Atributos
    private string nombre;
    private bool encendido;
    private int consumo;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int Consumo
    {
        get { return encendido ? consumo : 0; } // SOLO CONSUME SI ESTA ENCENDIDO Y SOLO FUNCIONA SI LA VARIABLE ES BOOLEANA 
        set
        {
            if (value < 0)
            {
                consumo = 0
            }
            else
            {
                consumo = value;
            }
        }
    }

    public bool Encendido
    {
        get { return encendido};
        set { encendido = value};
    }

    // Constructor
    public Dispositivo(string nombre, int consumo)
    {
        this.nombre = nombre;
        this.encendido = false;
        this.consumo = consumo;
    }

    // Métodos

    public void Encender()
    {
        Encendido = true;
    }

    public void Apagar()
    {
        Encendido = false
    }

    // Sobrecarga

    public void AjustarConsumo()
    {
        Consumo = 100;
    }

    public void AjustarConsumo(int nuevoConsumo)
    {
        Consumo = nuevoConsumo;
    }

    // Herencia
    public virtual string MostrarInfo()
    {
        return $"Dispositivo: {Nombre}, Encendido: {Encendido}, Consumo: {Consumo}[W] ";
    }

    //Sobrecarga de operdores 
    public static bool operator >(Dispositivos d1, Dispositivos d2)
    {
        return d1.Consumo > d2.Consumo;
    }

    public static bool operator <(Dispositivos d1, Dispositivos d2)
    {
        return d1.Consumo < d2.Consumo;
    }
    public static bool operator ==(Dispositivos d1, Dispositivos d2)
    {
        return d1.Consumo == d2.Consumo;
    }

    public static bool operator != (Dispositivos d1, Dispositivos d2)
    {
        return d1.Consumo != d2.Consumo;
    }


}
// Lampara hija de Dispositivos 

public class Lampara : Dispositivos
{
    // Atributos

    private int intensidad;         // Nivel de brillo

    // Constructor

    public Lampara(string nombre, int consumo, int intensidad) : base(nombre, consumo)
    {
        this.intensidad = intensidad;
    }

    // Metodos
    public override string MostrarInfo()
    {
        return $"Lampara: {base.MostrarInfo()}, Intensidad {intensidad}";
    }
}

// Ventilador hijo de dispositivos

public class Ventilador : Dispositivos
{
    // Atributos 

    private int velocidad;

    // Constructor 

    public Ventilador(string nombre, int consumo, int velocidad) : base(nombre, consumo)
    {
        this.velocidad = velocidad;
    }

    // Metodos

    public override string MostrarInfo()
    {
        return $"Ventilador: {base.MostrarInfo()}, Velocidad {velocidad}";
    }
}