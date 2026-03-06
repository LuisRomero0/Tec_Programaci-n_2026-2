// Arreglos

// Declaracion con tamaño explicito
int [] numeros = new int[2];

// Asignar elementos al arreglo

numeros[1] = 8;     // Accediendo a traves del indice 

// Obtener valores 

if (numeros[0] == 0)
{
    Console.WriteLine("Hay un cero");
}

// Obtener la logitude del arreglo

Console.WriteLine(numeros.Length);




// Declaracion implicita 
int[] numeros2 = new int[] {4, 5, 3, 6, 5}

Console.WriteLine(numeros2[3]);

char[] vocales = new[] { 'a', 'e', 'i', 'o', 'u' };

for (int i = 0; i < vocales.Length; i++)
{
    Console.WriteLine(vocales[i]);

}

foreach (char c in vocales)
{
    Console.WriteLine(c);
}

bool [] estado = new bool[3];

foreach (bool b in estado)
{
    Console.WriteLine(b);

    if(!b)
    {
        Console.WriteLine("Esto se imprime por?")
    }
}

// Metodos mas utilizados de los arreglos




Console.WriteLine("Desordenado");
foreach (int numero in nuemros2)
{
    Console.WriteLine(numero);
}

Array.Sort(numeros2);               // Ordena el arreglo 

Console.WriteLine("Ordenado");
foreach (int numero in nuemros2)
{
    Console.WriteLine(numero);
}

/*Console.WriteLine("Sort");
foreach (int numero in nuemros2)
{
    Console.WriteLine(numero);
}

Array.Reverse(numeros2);            // Invierte el arreglo

Console.WriteLine("Ordenado");
foreach (int numero in nuemros2)
{
    Console.WriteLine(numero);
}
*/

// Metodo para buscar un valor 

int indice = Array.BinarySearch(numeros2, 6);
Console.WriteLine(indice);

//Listas
List <int> numeros3 = new List<int>();

numeros3.Add(0);
numeros3.Add(20);

foreach (int numero in numeros3)
{
    Console.WriteLine(numero); 
}

// Acceder a un elemento de al lista

numeros3.Add(30);

int primerNumero = numeros3[0];

Console.WriteLine(primerNumero);

// Eliminar un elemento

numeros3.Remove(primerNumero);

foreach (int numero in numeros3)
{
    Console.WriteLine(numero);
}

// Eliminar por indice

numeros3.RemoveAt(0);
primerNumero = numeros3[0];
Console.WriteLine(primerNumero);

// Declarar lista con valores asignados 

List<string> nombres = new List<string> { "Ana", "Luis", "Carlos" };

nombres.Add("Pablo");

nombres.Count();    //CONTADOR DE ELEMENTOS QUE SE ENCUENTRAN EN LA LISTA 
Console.WriteLine(nombres.Count());

nombres.Sort();
foreach (string nombre in nombres)
{
    Console.WriteLine(nombre);
}


nombres.Clear();        //Elimina todos los valores de la lista

Console.WriteLine(nombres.Contains("Carlos"));