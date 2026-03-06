// PROGRAMA PRINCIPAL

bool continua = true;

List <IPAGO> list = new List<IPAGO> ();

do
{
    Console.WriteLine("Ingresa el monto a pagar:")
    try 
    {
        string montoTexto = Console.ReadLine() ?? "";  
        
    }
    catch 
    { 
    
    }
} while (continua);




// INTERFAZ Y CLASES

public interface IPAGO
{
    void ProcesarPago();
}

// Clase de pago en efectivo

public class PagoEfectivo : IPAGO
{
    // aTRIBUTO

    public double Monto { get; set; }

    // Constructor 
    public PagoEfectivo(double monto)
    {
        Monto = monto;
    }
    // Metodos

    public void ProcesarPago()
    {
        Console.WriteLine($"Pago en efectivo de {Monto} procesado");
    }

}

public class PagoTarjeta : IPAGO
{
    // aTRIBUTO

    public string NumTarjeta { get; set; }
    public double Monto { get; set; }

    // Constructor 
    public PagoTarjeta(string numeroTarjeta, double monto)
    {
        NumTarjeta = numeroTarjeta;
        Monto = monto;
    }
    // Metodos

    public void ProcesarPago()
    {
        if(NumTarjeta.Length == 16)
        {
            Console.WriteLine($"Pago en efectivo de {Monto} procesado");
        }
        else
        {
            Console.WriteLine($"Tarjeta invalida");
        }
        
    }

}