// Listas

// Son dinamicas y pueden crecer o reducir su tamaño segun se necesite

List<int> numeros = new List<int>(); // Lista de enteros

List<string> palabras = new List<string> {"Hola", "Mundo", "Adiós"}; // Lista de cadenas

numeros.Add(10); // Agrega un número a la lista
numeros.AddRange(new int[] { 20, 30, 40 }); // Agrega varios números a la lista

foreach (int numero in numeros)
{
    Console.WriteLine(numero); // Imprime cada número en la lista
}

numeros[1] = 60; // Modifica el segundo elemento de la lista
Console.WriteLine(numeros[1]); // Imprime el segundo elemento de la lista

// Insertar un elemento en una posición específica

numeros.Insert(2, 25); // Inserta el número 25 en la posición 2
foreach (int numero in numeros)
{
    Console.WriteLine(numero); // Imprime cada número en la lista
}

numeros.Remove(20); // Elimina el número 20 de la lista
numeros.RemoveAt(3); // Elimina el elemento en la posición 3

foreach (int numero in numeros)
{
    Console.WriteLine(numero); // Imprime cada número en la lista
}

bool existe = numeros.Contains(20); // Verifica si el número 20 está en la lista
int indice = numeros.IndexOf(40); // Obtiene el índice del número 40 en la lista
int mayor15 = numeros.Find(x => x > 15); // Encuentra el primer número mayor a 15 en la lista
List<int> mayores15 = numeros.FindAll(x => x > 25); // Encuentra todos los números mayores a 25 en la lista

