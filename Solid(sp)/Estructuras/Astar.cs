// Algoritmo Astar
// Problema : Robot autonomo que navega en un laberinto

// Mapa matricial :
//
//      c0   c1   c2   c3   c4
//  f0  [S]  [0]  [0]  [1]  [0]
//  f1  [0]  [1]  [0]  [1]  [0]
//  f2  [0]  [1]  [0]  [0]  [0]
//  f3  [0]  [0]  [1]  [1]  [0]
//  f4  [1]  [0]  [0]  [0]  [G]

// Nodos de estados

public class Nodo
{
    public int X, Y;
    public int G; // Costo real acumulado desde el inicio
    public int H; // Heuristica: Distancia a Manhattan a la meta
    public int F => G + H; // f(nodo) = g(nodo) + h(nodo)

    public Nodo Padre; // Para reconstruir el camino

    // Constructor 
    public Nodo(int x, int y)
    {
        X = x;
        Y = y;
        G = 0;
        H = 0;
        Padre = null;
    }
}

class Astar
{
    private int[,] grid =
        { { 0, 0, 0, 1, 0 },
          { 0, 1, 0, 1, 0 },
          { 0, 1, 0, 0, 0 },
          { 0, 0, 1, 1, 0 },
          { 1, 0, 0, 0, 0 } };
    static int filas = 5;
    static int columnas = 5;

    // Heuristica distancia de Manhattan
    // h(n) = |x_n - x_metal| + |y_n - y_meta|

    static int Heuristica(Nodo a, Nodo b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    static bool EstaEnQueue(Queue<Nodo> cola, Nodo buscado)
    {
        foreach (Nodo nodo in cola)
        {
            if (nodo.X == buscado.X && nodo.Y == buscado.Y)
            {
                return true;
            }
        }
        return false;
    }
    public List<Nodo> EncontrarCamino()
    {
        // IMPLEMENTAR CODIGO SIGUIENTE CLASE
    }