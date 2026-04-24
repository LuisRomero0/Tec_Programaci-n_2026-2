
namespace RobotLibrary
{
    // Atributos 
    public class Robot
    {
        public float Peso { get; set; }
        public string Modelo { get; set; }
        public bool Estado { get; set; }
        public int EnergiaDisponible
        {

            get { return EnergiaDisponible; }

            set
            {
                if (value < 0)
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
        public string Direccion { get; set; }
        public int MotorIzquierdo { get; set; }
        public int MotorDerecho { get; set; }
        public bool SensorUltrasonico { get; set; }

        // Metodo constructor para RobotMovil
        public void ConsumirEnergia(int cantidad)
        {
            if (cantidad < 0)
            {
                Console.WriteLine("No se puede consumir una cantidad negativa de energía.");
                return;
            }
            EnergiaDisponible -= cantidad;
            if (EnergiaDisponible < 0)
            {
                EnergiaDisponible = 0; // Limitar a 0
            }
            Console.WriteLine($"Energía consumida. Energía disponible: {EnergiaDisponible}%");
        }

        public void Mover(string direccion, float velocidad)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para moverlo.");
                return;
            }
            Direccion = direccion;
            Velocidad = velocidad;

            string option = Direccion switch
            {
                "Adelante" => "Adelante",
                "Atras" => "Atras",
                _ => "Desconocida"
            };

            switch (option)
            {
                case "Adelante":
                    Console.WriteLine($"El robot se mueve hacia adelante a una velocidad de {Velocidad} m/s.");
                    break;
                case "Atras":
                    Console.WriteLine($"El robot se mueve hacia atrás a una velocidad de {Velocidad} m/s.");
                    break;

                default:
                    Console.WriteLine("Dirección desconocida.");
                    break;
            }


            Console.WriteLine($"El robot se mueve hacia {Direccion} a una velocidad de {Velocidad} m/s.");
            // Metodo para consumir energía basado en la velocidad
            switch (velocidad)
            {
                case > 0.0f and < 25.0f:
                    ConsumirEnergia(5);
                    break;
                case >= 25.0f and < 50.0f:
                    ConsumirEnergia(10);
                    break;
                case >= 50.0f and < 75.0f:
                    ConsumirEnergia(15);
                    break;
                case >= 75.0f and <= 100.0f:
                    ConsumirEnergia(20);
                    break;
                default:
                    Console.WriteLine($"Velocidad fuera de rango o detenida: {velocidad} m/s.");
                    break;
            }
        }

        public void Detener()
        {
            Velocidad = 0;
            Direccion = "Detenido";
            Console.WriteLine("El robot se ha detenido.");
            ConsumirEnergia(2); // Consumir energía por detenerse
        }

        public void GiroPorDiferencia(string direccion)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para realizar un giro.");
                return;
            }
            switch (direccion)
            {
                case "Izquierda":
                    MotorIzquierdo = 0; // Detener el motor izquierdo
                    Console.WriteLine("El robot gira a la izquierda utilizando el motor derecho.");

                    break;
                case "Derecha":
                    MotorDerecho = 0; // Detener el motor derecho
                    Console.WriteLine("El robot gira a la derecha utilizando el motor izquierdo.");
                    break;
                default:
                    Console.WriteLine("Dirección de giro desconocida.");
                    break;
            }
            ConsumirEnergia(5); // Consumir energía por el giro
        }

        public void GiroPorContrarrotacion(string direccion)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para realizar un giro.");
                return;
            }
            switch (direccion)
            {
                case "Izquierda":
                    MotorIzquierdo = -1; // Invertir el motor izquierdo
                    MotorDerecho = 1; // Mantener el motor derecho en dirección normal
                    Console.WriteLine("El robot gira a la izquierda por contrarrotación.");
                    break;
                case "Derecha":
                    MotorIzquierdo = 1; // Mantener el motor izquierdo en dirección normal
                    MotorDerecho = -1; // Invertir el motor derecho
                    Console.WriteLine("El robot gira a la derecha por contrarrotación.");
                    break;
                default:
                    Console.WriteLine("Dirección de giro desconocida.");
                    break;
            }
            ConsumirEnergia(10); // Consumir energía por el giro
        }

        public void ObtenerDistanciaSensorUltrasonico()
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para obtener la distancia del sensor ultrasonico.");
                return;
            }
            if (SensorUltrasonico)
            {
                Random random = new Random();
                float distancia = (float)(random.NextDouble() * 100); // Simula una distancia entre 0 y 100 cm
                Console.WriteLine($"Distancia medida por el sensor ultrasonico: {distancia} cm.");
            }
            else
            {
                Console.WriteLine("El sensor ultrasonico no está activo.");
            }
        }

        public void AumentarVelocidad(int incremento)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para aumentar la velocidad.");
                return;
            }
            Velocidad += incremento;
            if (Velocidad > 100)
            {
                Velocidad = 100; // Limitar a 100
            }
            Console.WriteLine($"Velocidad aumentada. Velocidad actual: {Velocidad} m/s.");
            ConsumirEnergia(5); // Consumir energía por aumentar la velocidad
        }

        public void DisminuirVelocidad(int decremento)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para disminuir la velocidad.");
                return;
            }
            Velocidad -= decremento;
            if (Velocidad < 0)
            {
                Velocidad = 0; // Limitar a 0
            }
            Console.WriteLine($"Velocidad disminuida. Velocidad actual: {Velocidad} m/s.");
            ConsumirEnergia(2); // Consumir energía por disminuir la velocidad
        }

        // Constructor que llama al constructor de la clase base Robot
        public RobotMovil(float peso, string modelo, bool estado, int energiaDisponible, float velocidad, 
        string direccion, int motorIzquierdo, int motorDerecho, float sensorUltrasonico)
            : base(peso, modelo, estado, energiaDisponible)
        {
            Velocidad = 0;
            Direccion = "Detenido";
            MotorIzquierdo = motorIzquierdo;
            MotorDerecho = motorDerecho;
            SensorUltrasonico = true;
        }
    }
}
