// Cola (QUEUE)

// FIFO (First In, First Out)

// Solo accede al primer elemento agregado a la cola

// No permite busquedas

// Crear

Queue<string> cola = new Queue<string>(); // Cola de cadenas 

// Añadir elementos a la cola

cola.Enqueue("Primero");
cola.Enqueue("Segundo");
cola.Enqueue("Tercero");

foreach (string s in cola)
{
    Console.WriteLine(s); // Imprime cada elemento en la cola
}

// Eliminar el primer elemento agregado a la cola
string primerElemento = cola.Dequeue(); // Elimina y devuelve el primer elemento agregado a la cola

foreach (string s in cola)
{
    Console.WriteLine(s); // Imprime cada elemento en la cola después de eliminar el primer elemento
}

string frontal = cola.Peek(); // Devuelve el primer elemento agregado a la cola sin eliminarlo