public class Persona
{
	// Atributos
	public string Nombre { get; set; } //Encapsulamiento
	public int Edad { get; set; }

	// Atributo static

	public static string Pais { get; set; } = "España";


	// Variable de clase
	int i = 0;


	//Constructor
	public Persona(string nombre, int edad, string pais)
	{
		Nombre = nombre;
		Edad = edad;
		Pais = pais;
	}

	// Metodos 
	
	public void MostrarDatos()
	{
		Console.WriteLine($"Nombre objeto en función: {Nombre}");
        Console.WriteLine($"Edad objeto en función: {Edad}");
    }

	public static void MostrarPais()
	{
        Console.WriteLine($"Pais objeto en función: {Pais}");
    }
}
