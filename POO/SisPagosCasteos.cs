// PROGRAMA PRINCIPAL

bool continua = true;

List <IPAGO> list = new List<IPAGO> ();

do
{
    Console.WriteLine("Ingresa el monto a pagar:")
    string montoTexto = Console.ReadLine() ?? "";
    if (double.TryParse(montoTexto, out double monto))
    {
        string modoPagoT;
        int modoPago;

        do
        {
            Console.WriteLine("1- Pago con tarjeta");
            Console.WriteLine("2- Pago en efectivo");

            modoPagoT = Console.ReadLine() ?? "";

        } while (!int.TryParse(modoPagoT, out int modoPago) || (modoPago != 1 && modoPago != 2));
    
            if (modoPago == 1)
            {
                Console.WriteLine("Ingresa el numero de tarjeta:");
                string tarjeta = Console.ReadLine() ?? "";

                // CREANDO OBJETO PARA PAGO CON TARJETA

                IPAGO pago = new PagoTarjeta(tarjeta, monto);
                listaPagos.Add(pago);
            }
            else 
            {
                // CREANDO OBJETO PARA PAGO EN EFECTIVO

                IPAGO pago = new PagoEfectivo(monto);
                listaPagos.Add(pago);
            }

    }
    else
    {
        Console.WriteLine("Error monto invalido");
        return; 
    }

    Console.WriteLine("Presiona S para procesar más pagos:");
    char continuaT = char.Parse(Console.ReadLine() ?? "");

    if ( continuaT == 's')
    {
        continua = true;
    }
    else
    {
        continua = false;
    }

} while (continua);



foreach (IPAGO pago in listaPagos)
{
    pago.ProcesarPago();
}




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