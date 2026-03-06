// Programa para ver excepciones 

/*

int divisor = 0;
// int resultado = 10 / divisor; // Lanza excepción 

try
{
    int resultado = 10 / divisor;
}
catch (DivideByZeroException ex )
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("No se puede dividir / elige otro numero");
}
finally
{
    Console.WriteLine("Bloque que siempre se ejecuta"); 
}

*/

try
{
    Console.WriteLine("Introduce un numero entero positivo: ");
    int numero = int.Parse(Console.ReadLine() ?? "");

    if (numero < 0)
    {
        throw new ArgumentException("El numero no puedes ser negativo");
    }
}
catch (FormatException ex)
{
    Console.WriteLine("Escribiste algo que no es un numero");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Siempre se ejecuta");
}
