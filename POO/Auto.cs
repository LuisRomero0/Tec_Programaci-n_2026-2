// PROGRAMA PRINCIPAL CON INSTRUCCIONES DE NIVEL SUPERIOR

Auto auto1 = new Auto();
    auto1.Marca = "Honda";
    auto1.Modelo = "Civic";   
    auto1.VelocidadActual = 30.5f;
    Console.WriteLine($"Marca: {auto1.Marca}");
    Console.WriteLine($"Modelo: {auto1.Modelo}");
    auto1.Acelerar(10f);
    Console.WriteLine($"Velocidad actual: {auto1.VelocidadActual} km/h");
    auto1.Frenar(15f);
    Console.WriteLine($"Velocidad actual después de frenar: {auto1.VelocidadActual} km/h");


    AutoH autoH = new AutoH("Ford", "Mustang");
    autoH.Marca = autoH.Marca;    

    Motocicleta moto = new Motocicleta("Yamaha", "MT-07");

autoH.Acelerar(50.0f);
moto.Acelerar(60.0f);

moto.Frenar(70.0f);

//APLICAR SOBRECARGA DE OPERADORES PARA COMPARAR LA VELOCIDAD DE LOS VEHICULOS

    if (autoH > moto)
    {
        Console.WriteLine($"El auto es más rapido que la moto: {autoH.VelocidadActual}");
    }
    else if (autoH < moto)
    {
        Console.WriteLine($"La moto es más rapida que el auto: {moto.VelocidadActual}");
    }
    else if (autoH == moto)
    {
        Console.WriteLine("El auto y la moto tienen la misma velocidad");
    }

public class Vehiculo
{
    // Atributos
    protected string marca;
    protected string modelo;
    protected float velocidadActual;

    // Atributos publicos con control 
    public  virtual string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public string Modelo
    {
        get { return modelo; }
        set { modelo = value; }
    }

    public float VelocidadActual
    {
        get { return velocidadActual; }
        set
        {
            if (value >= 0)
            {
                velocidadActual = value;
            }
            else
            {
                velocidadActual = 0;
            }
        }
    }
    // Constructor

    public Vehiculo(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.velocidadActual = 0f; // Velocidad inicial
    }

    // Metodos
    public void Acelerar(float incremento)
    {
        velocidadActual += incremento;
    }


    public void Frenar(float decremento)
    {
        VelocidadActual -= decremento;
}

    //Sobrecarga de los operadores > < == pra commaparar la velocidad de dos vehiculos  
    public static bool operator >(Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual > v2.VelocidadActual;
    }

    public static bool operator <(Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual < v2.VelocidadActual;
    }

    public static bool operator ==(Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual == v2.VelocidadActual;
    }

    public static bool operator !=(Vehiculo v1, Vehiculo v2)
    {
        return v1.VelocidadActual != v2.VelocidadActual;
    }

}



public class AutoH : Vehiculo
{
    //Constructor
    public AutoH(string marca, string modelo) : base(marca, modelo)
   
    // Atributos de control 
    publoc override string Marca
    {
        get {
            Console.WriteLine($"La marca del vehiculo es: {marca}");
            return marca; }

        set { Marca = value; }
    }

}

public class Motocicleta : Vehiculo
{
    public Motocicleta(string marca, string modelo) : base(marca, modelo) { }

}

public class Auto
{
    // Atributos
    private string marca;
    private string modelo;
    private float velocidadActual;

    // Atributos publicos con control 
    public string Marca
    {
        get { return marca; }   
        set { marca = value; }
    }

    public string Modelo   
        {
        get { return modelo; }
        set { modelo = value; }
    }   

    public float VelocidadActual
    {
        get { return velocidadActual; }
        set 
        { 
            if (value >= 0)
            {
                velocidadActual = value;
            }
            else
            {
                velocidadActual = 0;
            }
        }
    }
    // Constructor

    // Metodos
    public void Acelerar(float incremento)
    {
        velocidadActual += incremento;
    }

 
    public void Frenar(float decremento)
    {
        VelocidadActual -= decremento;
    }



}