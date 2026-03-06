//Programa principal 

/*Calculadora calculadora1 = new Calculadora (5,2);
Calculadora calculadora2 = new Calculadora(12, 8);

float resultado1 = calculadora1.Division();
float resultado2 = calculadora2.Division();



Console.WriteLine(resultado1);
Console.WriteLine(resultado2);

// Get 

Console.WriteLine($"El primer numero de la primer calculadora es: {calculadora1.Numero1}");
Console.WriteLine($"El primer numero de la segunda calculadora es: {calculadora2.Numero1}");

// Set 
calculadora1.Numero1 = 8;
calculadora2.Numero1 = 6;

Console.WriteLine($"El primer numero de la primer calculadora es: {calculadora1.Numero1}");
Console.WriteLine($"El primer numero de la segunda calculadora es: {calculadora2.Numero1}");*/

/*
    //Funcion Factorial 
Calculadora calculadora1 = new Calculadora(1, 3);
Calculadora calculadora2 = new Calculadora(3, 8);
CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(5, 2);
Console.WriteLine($"El resultado calculadora Cientifica : {calculadoraCientifica.Suma()}");
Console.WriteLine($"El resultado calculadora Basica : {calculadora2.Suma()}");
Console.WriteLine($"El resultado calculadora Basica : {calculadora2.Suma(3)}");

Calculadora calculadora3 = calculadora1 + calculadora2; // Sobrecarga del operador suma
Console.WriteLine($"Calcuadora 3 ({calculadora3.Numero1}, {calculadora3.Numero2})");        */

Console.WriteLine("Ingresa el primer numero a operar:");
int num1 = int.Parse(Console.ReadLine() ?? "");
Console.WriteLine("Ingresa el segudo numero a operar:");
int num2 = int.Parse(Console.ReadLine() ?? "");


Console.WriteLine("Presiona 1- Calculadora Basica, 2- Calculadora Cientifica");
int opcion = int.Parse(Console.ReadLine() ?? "");

if (opcion == 1)
{
    Calculadora calculadora1 = new Calculadora(num1, num2);
    Console.WriteLine("1- SUMA");
    Console.WriteLine("2- RESTA");
    Console.WriteLine("3- MULTIPLICAR");
    Console.WriteLine("4- DIVIDIR ");
    opcion = int .Parse(Console.ReadLine() ?? "");
    
    switch (opcion)
    {
        case 1:
            Console.WriteLine($"EL resultado de la suma es: {calculadora1.Suma()}");
            break;
        case 2:
            Console.WriteLine($"EL resultado de la suma es: {calculadora1.Resta()}");
        break;
        case 3:
        Console.WriteLine($"EL resultado de la suma es: {calculadora1.Multiplicacion()}");
        break;
        case 4:
        Console.WriteLine($"EL resultado de la suma es: {calculadora1.Division()}");
        break;
            opcion = int.Parse(Console.ReadLine() ?? "");


        default:
            Console.WriteLine("Opcion no valida");
            break;
    }
}
else if (opcion == 2)
{
    CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(num1, num2);
    Console.WriteLine("1- SUMA");
    Console.WriteLine("2- RESTA");
    Console.WriteLine("3- MULTIPLICAR");
    Console.WriteLine("4- DIVIDIR");
    Console.WriteLine("5- lOGARITMO");
    Console.WriteLine("6- RAIZ CUADRADA");
    Console.WriteLine("7- FACTORIAL");

    opcion = int.Parse(Console.ReadLine() ?? "");

    switch (opcion)
    {
        case 1:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.Suma()}");
            break;
        case 2:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.Resta()}");
            break;
        case 3:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.Division()}");
            break;
        case 5:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.Logaritmo()}");
            break;
        case 6:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.RaizCuadrada()}");
            break;
        case 7:
            Console.WriteLine($"EL resultado de la suma es: {calculadoraCientifica.Factorial()}");
            break;

            opcion = int.Parse(Console.ReadLine() ?? "");

        default:
            Console.WriteLine("Opción no valida");
            break;
    }
}





//Clases

//Calculadora basica que solo opera 2 numeros 

public class Calculadora

{    
    // Atributos
    public int Numero1 { get; set; }
    public int Numero2 { get; set; }

    // Atributo privado
    private int Resultado;
    private string Mensaje = "El mensaje es privado";

    // Constructor
    public Calculadora(int numero1, int numero2)
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }
    // Metodos
    
    public virtual int Suma()
    {
        Resultado = Numero1 + Numero2;
        return Resultado;

    }
    //Metodo privado
        private void MostrarMensaje()
    {
        Console.WriteLine(Mensaje);
    }
    //Metodo protegido
    protected void MensajeProtegido()
    {
        MostrarMensaje();
    }
    // Sobre carga del metodo suma
    public virtual int Suma(int num3) 
    {
        return Numero1 + Numero2 + num3;
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
    // Sobrecarga del operador
    public static Calculadora operator + (Calculadora cal1, Calculadora cal2)
    {
        return new Calculadora(cal1.Numero1 + cal2.Numero1, cal1.Numero2 + cal2.Numero2);
    }
   
}

//Clase hija

public class CalculadoraCientifica : Calculadora
{
    // Atributos 
   
    // Constructor

    public CalculadoraCientifica(int num1, int num2) : base(num1, num2)
    {

    }

    // Metodos
        public double Logaritmo()

    {
        return MathF.Log(Numero1);
    }
    public double RaizCuadrada()
    {
        return MathF.Sqrt(Numero1);
    }

    // Override cambia el metodo heredado 
    public override int Suma()
    {
        int resultado = base.Suma();
   
        return resultado * resultado;

    }
    //Metodo publico en la clase hija que llama a un metodo protegido de la clase padre
        public void MensajeHijo()
    {
        base.MensajeProtegido();

    }
    public int Factorial()
    {
        if (Numero1 == 0 || Numero1 == 1)
        {
            return 1;
        }
        else if (Numero1 < 0)
        {
            Console.WriteLine("No es posible calcular el factorial de un numero negativo");
            return 0;

        }
        else
        {
            int fct = 1;
            for (int i = 2; i >= Numero1; i++)
            {
                fct = fct * i;
            }
            return fct;

        }
    }
}