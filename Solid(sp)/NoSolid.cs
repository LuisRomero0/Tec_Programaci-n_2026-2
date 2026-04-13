// Un sistema de vacunas en una veterinaria 

Console.WriteLine("CASO 1 mascota común:");
var sistema = new SistemaVeterinaria();
sistema.AtenderMascota("Juanito", "Perro", 2);

Console.WriteLine("CASO 2 mascota común no contemplado:");
var sistema2 = new SistemaVeterinaria();
sistema2.AtenderMascota("Jorgito", "Ave", 3);

Console.WriteLine("CASO 3 mascota especial:");
SistemaVeterinaria sistema3 = new SistemaVeterinariaEspecial();
sistema3.AtenderMascota("Rex", "Perro", 8);

Console.WriteLine("CASO 4 mascota especial:");
SistemaVeterinariaEspecial sistema4 = new SistemaVeterinariaEspecial();
sistema4.AtenderMascota("Bolillo", "Cocodrilo", 20);

// Clases dominio 
public class Mascota
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad {  get; set; }

    public Mascota (string nombre, string tipo, int edad)
    {
        Nombre = nombre;
        Tipo = tipo;
        Edad = edad;
    }

    public bool EsValida()
    {
        return !string.IsNullOrEmpty(Nombre) && Edad > 0;
    }

    public decimal CalcularVacuna()
    {
        if (Tipo.StartsWith("P")) return 200;
        if (Tipo.StartsWith("G")) return 180;
        if (Tipo.Contains("tuga")) return 400;

        return Edad * 50;
    }
}

public class EmailService
{
    public void Enviar(string mensaje)                                      // Este metodo se genera independiente, por lo que es necesario llamarlo??
    {
        Console.WriteLine($"Enviando correo: {mensaje}");
    }
}
public class Notificador
{
    private EmailService email = new EmailService();                        // Esto depende del Notificador, cosa que deberia ser
    public void Notificar(Mascota mascota)
    {
        email.Enviar($"Mascota info : {mascota.Nombre} | {mascota.CalcularVacuna()}"); // Posiblemente esp tambien deba ser independiente (revisar)
    }
}
public class SistemaVeterinaria
{
    public List<Mascota> mascotas = new List<Mascota>();
    Notificador notificador = new Notificador();

    public virtual void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);

        if (!mascota.EsValida())                                            // Este metodo de EsValida, no debe depender de un llamado para AtenderMascota
        {
            Console.WriteLine("Mascota no se puede registar");
            return;
        }
        mascotas.Add(mascota);
        decimal costo = mascota.CalcularVacuna();                           // Esto debe ser independiente del método AtenderMascota
        notificador.Notificar(mascota);                                     // Esto debe ser independiente del método AtenderMascota

        Console.WriteLine("Resumen de lista de mascotas | Reporte:");

        foreach (var m in mascotas)
        {
            Console.WriteLine($"{m.Nombre} - {m.Tipo}");
        }
    }
}

public class SistemaVeterinariaEspecial : SistemaVeterinaria
{
    public override void AtenderMascota(string nombre, string tipo, int edad)
    {
        if(tipo == "Perro")
        {
            Console.WriteLine("Los perros no se atienden en este sistema");
            throw new Exception("Sistema incorrecto");
        }
        base.AtenderMascota(nombre, tipo, edad);
    }
}


// codigo comentado donde se establezcan las correcciones que se deberian hacer para cumplir con los 5 metodos Solid 
// crear el codigo Solid.cs donde se corrigen los principios de responsabilidades 