// Declaración implicita de arreglos
int[] numeros = new int[5];
// Declaración explícita de arreglos
string[] palabras = new string[3] { "Hola", "Mundo", "Adiós" };

// Acceso a elementos

int primerNumero = numeros[0]; // Accede al primer elemento del arreglo de números
palabras[1] = "Universo"; // Modifica el segundo elemento del arreglo de palabras

// Array multidimensional

    // Forma implicita
int[][] matriz = new int[2][]; // Arreglo de arreglos (jagged array)
int [,] matriz2 = new int[3, 3]; // Arreglo bidimensional

    // Forma explicita
int [,] matrizInicializada = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} }; // Arreglo bidimensional con dimensiones explícitas


// Acceso a elementos en arreglos multidimensionales

for (int i = 0; i <= 2; i++)
{
    for (int j = 0; j <= 2 ; j++)
    {
        Console.Write(matrizInicializada[i, j]);
    }
    Console.WriteLine("\n");
}



int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[] {1,2};
jaggedArray[1] = new int[3] {3,4,5};
jaggedArray[2] = new int[] {6};

// Acceder a los elementos del arreglo jagged
foreach (int[] i in jaggedArray)
{
    foreach (int j in i)
    {
        Console.Write(j);
    }
    Console.WriteLine("\n");
}