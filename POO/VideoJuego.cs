// Implementación del juego 

try
{
    Console.WriteLine("Bienvenido al juego de guerreros!");
    Console.WriteLine("Ingresa el nombre de tu guerredo");

    string nombre = Console.ReadLine() ?? "";

    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("Selecciona tu clase:");
    Console.WriteLine("1. Caballero");
    Console.WriteLine("2. Mago");
    Console.WriteLine("3. Arquero");
    Console.WriteLine("4. Guerrero Sombra");


}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error: {ex.Message}");
}


// Apartado de funciones

static Guerrero SeleccionarClase()
{
    while (true)
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Selecciona tu clase:");
            Console.WriteLine("1. Caballero");
            Console.WriteLine("2. Mago");
            Console.WriteLine("3. Arquero");
            Console.WriteLine("4. Guerrero Sombra");

            
        }
        catch
        {

        }
}

// Definiciones de clases

public class Guerrero
{
    // Atributos

    public string Nombre { get; set; }

    public int Vida { get; set; }

    public int Ataque { get; set; }

    // Constructor

    public Guerrero(string nombre, int vida, int ataque)
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
    }

    // Métodos

    public void Atacar(Guerrero enemigo)
    {
        int danio = Ataque + new Random().Next(-3, 5);
        // RECIBIR DAÑO
        enemigo.RecibirDanio(danio);
        Console.WriteLine($"{Nombre} ataca a {enemigo.Nombre} causando {danio} de daño. Vida restante de {enemigo.Nombre}: {enemigo.Vida}");
    }

    public void RecibirDanio(int cantidad)
    {
        Vida = Math.Max(Vida - cantidad, 0);

    }

    // Sobre carga de operador +

    public static Guerrero operator +(Guerrero g1, Guerrero g2)
    {
        Console.WriteLine($"Combinando {g1.Nombre} y {g2.Nombre} para crear un nuevo guerrero...");
        return new Guerrero($"{g1.Nombre}--{g2.Nombre}", (g1.Vida + g2.Vida)/2, (g1.Ataque + g2.Ataque)/2 );)
        
    }

}

// Clase CABALLERO
    
public class Caballero : Guerrero
{
    // CONSTRUCTOR

   
    public Caballero(string nombre : base(nombre, 120, 20){ }
    
    // polimosfismo

    public override void Atacar(Guerrero enemigo)
    {
        Console.WriteLine($"{Nombre} (Caballero ) usa golpe crítico");
        base.Atacar(enemigo);   
    }   
}

// Clase MAGO
    
public class Mago : Guerrero
{
    // CONSTRUCTOR
    public Mago(string nombre) : base(nombre, 80, 25){ }
    
    // polimosfismo
    public override void Atacar(Guerrero enemigo)
    {
        Console.WriteLine($"{Nombre} (Mago) lanza un hechizo de fuego");
        base.Atacar(enemigo);   
    }   
}

// Clase ARQUERO

public class Arquero : Guerrero
{
    // CONSTRUCTOR
    public Arquero(string nombre) : base(nombre, 90, 15){ }
    
    // polimosfismo
    public override void Atacar(Guerrero enemigo)
    {
        int probabilidad = new Random().Next(1, 100);

        if (probabilidad < 30)
        {
                Console.WriteLine($"{Nombre} (Arquero) dispara una flecha y falla");
        } 
        else
        {
            Console.WriteLine($"{Nombre} (Arquero) dispara una flecha y acierta un golpe crítico");
            base.Atacar(enemigo);
        }  
    }   
}


// Clase GUERRERO SOMBRA

public class GuerreroSombra : Guerrero
{
    // CONSTRUCTOR
    public GuerreroSombra(string nombre) : base(nombre, 110, 22){ }
    
    // polimosfismo
    public override void Atacar(Guerrero enemigo)
    {
        int chanse = new Random().Next(1, 100);
        if (chanse < 20)
        {
                Console.WriteLine($"{Nombre} (Guerrero Sombra) desaparece");
        } 
        else
        {
            Console.WriteLine($"{Nombre} (Guerrero Sombra) ataca desde las sombras");
            base.Atacar(enemigo);   
    }   
}