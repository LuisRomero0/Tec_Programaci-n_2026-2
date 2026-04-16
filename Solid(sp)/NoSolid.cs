// Un sistema de vacunas en una veterinaria 

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

    //  La mascota no debería validarse a sí misma
    public bool EsValida()
    {
        return !string.IsNullOrEmpty(Nombre) && Edad > 0;
    }

    // Si llega un animal nuevo, hay que modificar esta clase. La lógica de costo debe estar fuera.
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
    public void Enviar(string mensaje)
    {
        Console.WriteLine($"Enviando correo: {mensaje}");
    }
}

public class Notificador
{
    // Aquí dependemos de una clase concreta (EmailService). Debería ser una interfaz.
    private EmailService email = new EmailService(); 

    public void Notificar(Mascota mascota)
    {
        // El notificador no debería saber cómo se calcula la vacuna, solo enviar el texto.
        email.Enviar($"Mascota info : {mascota.Nombre} | {mascota.CalcularVacuna()}"); 
    }
}

public class SistemaVeterinaria
{
    public List<Mascota> mascotas = new List<Mascota>();
    // Estamos creando el notificador aquí adentro. Debería recibirse ya creado.
    Notificador notificador = new Notificador();

    public virtual void AtenderMascota(string nombre, string tipo, int edad)
    {
        var mascota = new Mascota(nombre, tipo, edad);

        if (!mascota.EsValida())
        {
            Console.WriteLine("Mascota no se puede registar");
            return;
        }
        mascotas.Add(mascota);
        
        // El método AtenderMascota hace demasiadas cosas (crea, valida, calcula, notifica e imprime).
        decimal costo = mascota.CalcularVacuna();
        notificador.Notificar(mascota);

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
        // Estamos alterando el comportamiento esperado. Si el padre acepta perros, el hijo también debería.
        if(tipo == "Perro")
        {
            Console.WriteLine("Los perros no se atienden en este sistema");
            throw new Exception("Sistema incorrecto");
        }
        base.AtenderMascota(nombre, tipo, edad);
    }
}
