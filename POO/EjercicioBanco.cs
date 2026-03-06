// PROGRAMA PRINCIPAL BANCO 

Banco banco = new Banco();

do
{
try
{
    CuentaBancaria cuentaOrigen = banco.BuscarCuenta("123456");

    Console.WriteLine("Presiona 1- Depositar, 2- Transferir, 3- Retirar");
    int opcion = int.Parse(Console.ReadLine() ?? "");

    switch (opcion)
    {
        case 1:
            Console.WriteLine($"Saldo inicial: {cuentaOrigen.Saldo}");
            Console.WriteLine("Ingrese la cuenta bancaria destino");
            CuentaBancaria cuentaDestino = banco.BuscarCuenta(Console.ReadLine());
            Console.WriteLine("Escribe la cantidad a depositar: ");
            decimal cantidad = decimal.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Haciendo transferencia:  ");
            cuentaOrigen.Depositar(cuentaDestino, cantidad);

            Console.WriteLine($"Saldo final: {cuentaOrigen.Saldo}");


        case 2:
            Console.WriteLine($"Saldo inicial: {cuentaOrigen.Saldo}");
            Console.WriteLine("Ingrese la cuenta bancaria destino");
            CuentaBancaria cuentaDestino = banco.BuscarCuenta(Console.ReadLine());
            Console.WriteLine("Escribe la cantidad a transferir: ");
            decimal cantidad = decimal.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Haciendo transferencia:  ");
            cuentaOrigen.Transferir(cuentaDestino, cantidad);

            Console.WriteLine($"Saldo final: {cuentaOrigen.Saldo}");
            break;


        case 3:
            Console.WriteLine($"Saldo inicial: {cuentaOrigen.Saldo}");
            
            Console.WriteLine("Escribe la cantidad a retirar: ");
            decimal cantidad = decimal.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("Haciendo retiro:  ");
            cuentaOrigen.Retirar(cuentaDestino, cantidad);

            Console.WriteLine($"Saldo final: {cuentaOrigen.Saldo}");
            break;
    }

        Console.WriteLine("Escribe Y para realizar mas operaciones:");
        repetir = char.Parse(Console.ReadLine() ?? "");

}
catch (CuentaNoEncontradaException ex)
{
    Console.WriteLine(ex.Message);
}
catch (SaldoInsuficienteException ex)
{
    Console.WriteLine(ex.Message);
}
catch (DepositoInvalidoException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
}

char repetir = "y";
while (repetir == "y" || repetir == "Y")
{
    Console.WriteLine("Mensaje");
    repetir = "n";
}










class SaldoInsuficienteException : Exception
{
    // CONSTRUCTOR 
    public SaldoInsuficienteException(string mensaje) : base(mensaje) { }

}

class CuentaNoEncontradaException : Exception
{
    public CuentaNoEncontradaException(string mensaje) : base(mensaje) { }
}

class DepositoInvalidoException: Exception
{
    public DepositoInvalidoException(string mensaje) : base(mensaje) { }
}


public class CuentaBancaria
{
    //Atributos

    public string NumeroCuenta { get; }
    public decimal Saldo { get; set; }

    //Constructor

    public CuentaBancaria(string numeroCuenta, decimal saldo)
    {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
    }

    //Metodos

    public void Depositar(decimal cantidad)
    {
        if (Saldo > 0)
        {
            throw new DepositoInvalidoException("No puedes depositar" + "cantidades negativas");
        }
        Saldo += cantidad;

    }

    public void Retirar(decimal cantidad)
    {
        if (cantidad > Saldo)
        {
            throw new SaldoInsuficienteException("No cuentas con dicha cantidad a retirar");
        }
        Saldo -= cantidad;

    }

    public void Transferir(CuentaBancaria destino, decimal cantidad)
    {
        if (destino == null)
        {
            throw new CuentaNoEncontradaException("Cuenta no encontrada");
        }
        Retirar(cantidad);
        destino.Depositar(cantidad);
    }
}

public class Banco
{
    // Atributos

    private CuentaBancaria[] cuentas;
    
    // Constructor

    public Banco()
    {
        cuentas = new CuentaBancaria[];
        {
            new CuentaBancaria("123456", 6),
            new CuentaBancaria("789456", 20),
            new CuentaBancaria("741852", 10000),
        };
    }

    // Metodos 

    public CuentaBancaria BuscarCuenta(string numeroCuenta)
    {
        foreach(CuentaBancaria cuenta in cuentas)
        {
            if (cuenta.NumeroCuenta == numeroCuenta)
            {
                return cuenta;
            }
        }
        throw new CuentaNoEncontradaException("Cuenta no encontrada");
    }
}