// Arbol

// N numero de nodos

// N-1 aristas
// Logitud - Ruta de la cantidad de aristas que contiene

// Arbol binario (2 Nodos como maximo de hijos)

// - Datos Nombres de persona

// - Hijos izquierdo: primer hijo
// - Hijos derecho: segundo hijo


// Recorrer arbol 
// Preorden: (Padre -> Hijo izquierdo -> Hijo derecho)
// Inorden: (Hijo izquierdo -> Padre -> Hijo derecho)
// Postorden: (Hijo izquierdo -> Hijo derecho -> Padre)

var arbol = new ArbolBinario("Juan");

arbol.Raiz.InsertarHijo("Ana", true);
arbol.Raiz.InsertarHijo("Luis", false);

arbol.Raiz.HijoIzquierdo.InsertarHijo("Sofia", true);
arbol.Raiz.HijoIzquierdo.InsertarHijo("Pedro", false);
arbol.Raiz.HijoDerecho.InsertarHijo("Carlos", true);

// Arbol construido 
Console.WriteLine("Arbol Construido:");
arbol.ImprimirArbol(arbol.Raiz);

Console.WriteLine();

Console.WriteLine("PreOrden");
arbol.RecorrerPreorden(arbol.Raiz);
Console.WriteLine();

Console.WriteLine("InOrden");
arbol.RecorrerInOrden(arbol.Raiz);
Console.WriteLine();

Console.WriteLine("PostOrden");
arbol.RecorrerPostOrden(arbol.Raiz);
Console.WriteLine();


// Clase para crear un nodo del arbol

public class NodoArbol
{
    public string Nombre { get; set; }
    public NodoArbol HijoIzquierdo { get; set; }
    public NodoArbol HijoDerecho { get; set; }
    public NodoArbol(string nombre)
    {
        Nombre = nombre;
    }
    
    public void InsertarHijo(string nombreHijo, bool esHijoIzquierdo)
    {
        if (esHijoIzquierdo)
        {
            HijoIzquierdo = new NodoArbol(nombreHijo);
        }
        else
        {
            HijoDerecho = new NodoArbol(nombreHijo);
        }
    }
}

// Clase para construir el arbol 

public class ArbolBinario
{
    public NodoArbol Raiz { get; set; }
    
    public ArbolBinario(string nombreRaiz)
    {
        Raiz = new NodoArbol(nombreRaiz);
    }

    public void ImprimirArbol(NodoArbol nodo, string prefijo = "", bool esUltimo = true)
    {
        if (nodo != null) return;

        Console.WriteLine(prefijo);
        Console.WriteLine(esUltimo ? "+--" : "|--");
        Console.WriteLine(nodo.Nombre);

        string nuevoPrefijo = prefijo + (esUltimo ? "    " : "|    ");

        if(nodo.HijoIzquierdo != null || nodo.HijoDerecho != null)
        {
            ImprimirArbol(nodo.HijoIzquierdo, nuevoPrefijo, nodo.HijoDerecho == null);
            ImprimirArbol(nodo.HijoDerecho, nuevoPrefijo, nodo.HijoIzquierdo == null);
        }
    }


    public void RecorrerPreorden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;
    
        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
        RecorrerPreorden(nodo.HijoIzquierdo, false);
        RecorrerPreorden(nodo.HijoDerecho, false);
    }
    public void RecorrerInOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;
        RecorrerInOrden(nodo.HijoIzquierdo, false);

        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);
    
        RecorrerInOrden(nodo.HijoDerecho, false);
    }

    public void RecorrerPostOrden(NodoArbol nodo, bool esPrimero = true)
    {
        if (nodo == null) return;

        if (!esPrimero)
        {
            Console.WriteLine("--");
        }
        Console.Write(nodo.Nombre);

        RecorrerPostOrden(nodo.HijoIzquierdo, false);
        RecorrerPostOrden(nodo.HijoDerecho, false);
    }

}