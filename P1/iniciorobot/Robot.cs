// Atributos 
public class Robot
{
    public float Peso { get; set; }
    public string Modelo { get; set; }
    public bool Estado { get; set; }
    public int EnergiaDisponible 
    {

        get { return EnergiaDisponible; }  
    
        set {if (value < 0)
            {
                Console.WriteLine("La energía no puede ser negativa. Se establece a 0.");
                EnergiaDisponible = 0;
            }
            else if (value > 100)
            {
                Console.WriteLine("La energía no puede exceder el 100%. Se establece a 100.");
                EnergiaDisponible = 100;
            }
            else
            {
                EnergiaDisponible = value;
            }
        }
    }  

    // Constructor
    public Robot(float peso, string modelo, bool estado, int energiaDisponible)
    {
        Peso = peso;
        Modelo = modelo;
        Estado = estado;
        EnergiaDisponible = energiaDisponible;
    }

    public Robot(float peso, string modelo, int energiaDisponible)
    {
        Peso = 5;
        Modelo = "Robot Generico";
        EnergiaDisponible = 100;
    }

    // Metodos 

    public void Encender()
    {
        if (!Estado)
        {
            Estado = true;
            Console.WriteLine("Robot encendido.");
        }
        else
        {
            Console.WriteLine("El robot ya está encendido.");
        }
    }

    public void Apagar()
    {
        if (Estado)
        {
            Estado = false;
            Console.WriteLine("Robot apagado.");
        }
        else
        {
            Console.WriteLine("El robot ya está apagado.");
        }
    }

    public int VerificarEnergia()
    {
        return EnergiaDisponible;
    }

    public void RecargarEnergia(int cantidad)
    {
        if (cantidad < 0)
        {
            Console.WriteLine("No se puede recargar una cantidad negativa de energía.");
            return;
        }
        EnergiaDisponible += cantidad;
        if (EnergiaDisponible > 100)
        {
            EnergiaDisponible = 100; // Limitar a 100
        }
        Console.WriteLine($"Energía recargada. Energía disponible: {EnergiaDisponible}%");
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"El robot con Modelo: {Modelo}, se encuentra {(Estado ? "Encendido" : "Apagado")}");
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Peso: {Peso} kg");
    }
}

public class RobotMovil : Robot
{
    // Atributos adicionales para RobotMovil
    public float Velocidad { get; set; }
    // Metodo constructor para RobotMovil
    // Constructor que llama al constructor de la clase base Robot
}