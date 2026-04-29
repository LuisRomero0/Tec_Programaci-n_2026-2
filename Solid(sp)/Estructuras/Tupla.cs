// TUPLA

// No son estructuras, son una forma de agrupar datos heterogeneos sin necesidad de definir una clase o estructura personalizada
// Tamaño fijo
// Inmutable
// Limite de elementos 8

// Creacion
// Tupla sin nombres

(string, int) persona1 = ("Ana", 25);

// Tupla con nombres

(string nombre, int edad) persona2 = ("Juan", 30);

// Acceso a los elementos

Console.WriteLine(persona1.Item1);
Console.WriteLine(persona2.nombre);

Console.WriteLine(persona1.Item2);
Console.WriteLine(persona2.edad);

// Devolver Tupla en metodos

static (int, int) Dividir(int dividendo, int divisor)
{
    return (dividendo / divisor, dividendo % divisor);
}

var resultado = Dividir(10, 3);
Console.WriteLine($"Cociente: {resultado.Item1}, Modulo: {resultado.Item2}");