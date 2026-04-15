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

    // La mascota no debería validarse a sí misma.
    public bool EsValida()
    {
        return !string.IsNullOrEmpty(Nombre) && Edad > 0;
    }

    // Si llega un animal nuevo, hay que modificar esta clase y la lógica de costo debe estar fuera.
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
    // Esto deberia de considerarse una una interfaz.
    private EmailService email = new EmailService(); 

    public void Notificar(Mascota mascota)
    {
        // El notificador no debería saber como se calcula la vacuna, solo deberia enviar el texto.
        email.Enviar($"Mascota info : {mascota.Nombre} | {mascota.CalcularVacuna()}"); 
    }
}

public class SistemaVeterinaria
{
    public List<Mascota> mascotas = new List<Mascota>();
    // El notificador ya deberia estar creado
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
        
        // El método AtenderMascota hace demasiadas cosas como crear, validar, calcular, notificar e imprimir cuando solo deberia llamar a diferentes metodos que hagan eso individualemtne 
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
    // Se altera la herencia por que se logra ingresar un perro apesar de que no es aceptado, y eso sucede por los metodo heredados.
        if(tipo == "Perro")
        {
            Console.WriteLine("Los perros no se atienden en este sistema");
            throw new Exception("Sistema incorrecto");
        }
        base.AtenderMascota(nombre, tipo, edad);
    }
}
