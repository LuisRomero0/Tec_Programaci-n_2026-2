// Pilas

// LIFO ultimo en entrar, primero en salir

// Solo se puede acceder al ultimo elemento agregado a la pila

// No permite busquedas 

// Crear 

Stack<string> pila = new Stack<string>(); // Pila de cadenas

// Aplilar
pila.Push("Primero");
pila.Push("Segundo");
pila.Push("Tercero");

foreach (string elemento in pila)
{
    Console.WriteLine(elemento); // Imprime cada elemento en la pila
}

// Desapilar
string ultimoElemento = pila.Pop(); // Elimina y devuelve el último elemento agregado a la pila

foreach (string elemento in pila)
{
    Console.WriteLine(elemento); // Imprime cada elemento en la pila después de desapilar
}

string superior = pila.Peek(); // Devuelve el último elemento agregado a la pila sin eliminarlo

foreach (string s in pila)
{
    Console.WriteLine(s); // Imprime cada elemento en la pila después de hacer peek
}   