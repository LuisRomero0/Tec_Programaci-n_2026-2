public class Persona
{
    // Atributos
    public string Nombre { get; set; } //Encapsulamiento
    public int Edad { get; set; }

    //Constructor
    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    Persona humano0 = new Persona("Angel", 22);
    Persona humano1 = new Persona("David", 25);
    Persona humano2 = new Persona("Josue", 17);


    // Metodos 
    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre objeto en función: {Nombre}");
        Console.WriteLine($"Edad objeto en función: {Edad}");
    }



    List<string> ListaDePersonas = new List<string>();
    
    ListaDePersonas.Add(humano0);
    ListaDePersonas.Add(humano1);
    ListaDePersonas.Add(humano2);
    



}



// CÓDIGO CORRECTO


public class Persona
{
    // Atributos
    public string Nombre { get; set; } //Encapsulamiento
    public int Edad { get; set; }

    //Constructor
    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    // Metodos 
    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre objeto en función: {Nombre}");
        Console.WriteLine($"Edad objeto en función: {Edad}");
    }
}

List<Persona> personas = new List<Persona>;
personas.Add(new Persona("Angel", 22, "México"));
personas.Add(new Persona("Enrique", 15, "Canadá"));
personas.Add(new Persona("Elias", 8, "Colombia"));
personas.Add(new Persona("Luis", 18, "Uruguay"));
personas.Add(new Persona("Daniela", 21, "Brasil"));

// Imprimir los datos
foreach (Persona persona in personas)
{
    persona.MostrarDatos();
}

// Filtro mayores 18
Console.WriteLine("Mayores de 18");
// personas.Sort();
foreach (Persona persona in personas)
{
    if(persona.Edad >= 18)
    {
        persona.MostrarDatos();
    }
}

