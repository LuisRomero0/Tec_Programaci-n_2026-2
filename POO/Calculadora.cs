//Programa principal 
Calculadora calculadora = new Calculadora (5,2);
float resultado = calculadora.Division();

Console.WriteLine(resultado);


//Clases

//Calculadora basica que solo opera 2 numeros 

public class Calculadora
{    // Atributos
    public int Numero1 { get; set; }
    public int Numero2 { get; set; }

    // Constructor
    public Calculadora(int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }
    // Metodos

    public void resultado(Calculadora.Suma, Calculadora.Resta, Calculadora.Mul)
    public int Suma()
    {
        return Numero1 + Numero2;

    }
    public int Resta()
    {
        return Numero1 - Numero2;
    }
    public int Multiplicacion()
    {
        return Numero1 * Numero2;
    }

    public float Division()
    {
        if (Numero2 == 0)
        {
            Console.WriteLine("MathError");
            return 0;
        }
        return (float) Numero1 / Numero2;
    }
}