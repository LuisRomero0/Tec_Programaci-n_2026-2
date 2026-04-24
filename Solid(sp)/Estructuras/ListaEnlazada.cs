// Lista enlazada

// Cada elemento tiene un valor y una referencia al siguiente elemento

LinkedList<string> frutas = new LinkedList<string>(); // Lista enlazada de cadenas

// Agregar nodos a la lista enlazada

frutas.AddLast("Mango"); // Agrega un nodo al final de la lista
frutas.AddFirst("Mandarina"); // Agrega un nodo al inicio de la lista
frutas.AddLast("Sandía"); // Agrega un nodo al final de la lista
frutas.AddLast("Uva"); // Agrega un nodo al final de la lista

foreach (string fruta in frutas)
{
    Console.WriteLine(fruta); // Imprime cada fruta en la lista enlazada
}

// Recorrer mostrando enlaces 

Console.WriteLine("Frutas en lista enlazada:");

LinkedListNode<string> nodoActual = frutas.First; // Obtiene el primer nodo de la lista

/*while (nodoActual != null)
{
    string anterior = nodoActual.Previous?.Value ?? "null"; // Obtiene el valor del nodo anterior o "null" si no existe
    string siguiente = nodoActual.Next?.Value ?? "null"; // Obtiene el valor del nodo siguiente o "null" si no existe

    Console.WriteLine($"[{anterior}] <- {nodoActual.Value} -> [{siguiente}]"); // Imprime el valor del nodo actual y sus enlaces
    nodoActual = nodoActual.Next; // Avanza al siguiente nodo

}*/

LinkedListNode<string> nodoNuevo = frutas.Find("Uva"); // Crea un nuevo nodo con el valor "Uva"
frutas.AddBefore(frutas.First, "Mango"); // Agrega el nuevo nodo antes del primer nodo de la lista
frutas.AddAfter(nodoNuevo, "Tuna"); // Agrega el nuevo nodo después del último nodo de la lista

while (nodoActual != null)
{
    string anterior = nodoActual.Previous?.Value ?? "null"; // Obtiene el valor del nodo anterior o "null" si no existe
    string siguiente = nodoActual.Next?.Value ?? "null"; // Obtiene el valor del nodo siguiente o "null" si no existe

    Console.WriteLine($"[{anterior}] <- {nodoActual.Value} -> [{siguiente}]"); // Imprime el valor del nodo actual y sus enlaces
    nodoActual = nodoActual.Next; // Avanza al siguiente nodo

}