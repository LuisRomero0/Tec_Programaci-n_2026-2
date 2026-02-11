// Programa de forma secuencial 

Console.WriteLine("Ingresa el nombre:");
string nombre  = Console.ReadLine() ?? "";

Console.WriteLine("Ingresa la edad:");
int edad = int.Parse(Console.ReadLine() ?? "");

/*Console.WriteLine($"Nombre: {nombre}");
Console.WriteLine($"Edad: {edad}");*/

// Programa orientado a objetos 

Persona humano1 = new Persona(nombre, edad, pais); // Instancia un nuevo objeto de tipo persona 

/*Console.WriteLine($"Nombre objeto: {humano1.Nombre}");
Console.WriteLine($"Edad objeto: {humano1.Edad}");*/

humano1.MostrarDatos();

Persona humano2 = new Persona("Angel", 22, "España");
humano2.MostrarDatos();
