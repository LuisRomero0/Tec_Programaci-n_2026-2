using System;

namespace RobotLibrary
{
    // Actividad 1: Clase Base Robot
    public class Robot
    {
        private int _energiaDisponible;

        public float Peso { get; set; }
        public string Modelo { get; set; }
        public bool Estado { get; set; } 

        public int EnergiaDisponible
        {
            get { return _energiaDisponible; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("La energía no puede ser negativa. Se establece a 0.");
                    _energiaDisponible = 0;
                }
                else if (value > 100)
                {
                    Console.WriteLine("La energía no puede exceder el 100%. Se establece a 100.");
                    _energiaDisponible = 100;
                }
                else
                {
                    _energiaDisponible = value;
                }
            }
        }

        // Constructor completo para inicializar todos los atributos
        public Robot(float peso, string modelo, bool estado, int energiaDisponible)
        {
            Peso = peso;
            Modelo = modelo;
            Estado = estado;
            EnergiaDisponible = energiaDisponible; 
        }

        // Constructor sin parámetros (Valores por defecto)
        public Robot()
        {
            Modelo = "Robot Genérico";
            Peso = 5.0f;
            EnergiaDisponible = 100;
            Estado = false;
        }

        // MÉTODOS VIRTUALES: Permiten ser sobrescritos en la clase hija para añadir funcionalidad específica
        public virtual void Encender()
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

        public virtual void Apagar()
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

        public virtual int VerificarEnergia()
        {
            return EnergiaDisponible;
        }

        public virtual void RecargarEnergia(int cantidad)
        {
            if (cantidad < 0)
            {
                Console.WriteLine("No se puede recargar una cantidad negativa de energía.");
                return;
            }
            EnergiaDisponible += cantidad;
            Console.WriteLine($"Energía base modificada. Total: {EnergiaDisponible}%");
        }

        public virtual void MostrarEstado()
        {
            Console.WriteLine($"El robot modelo {Modelo} está {(Estado ? "Encendido" : "Apagado")}.");
        }

        public void MostrarInformation()
        {
            Console.WriteLine($"Modelo: {Modelo} | Peso: {Peso} kg");
        }
    }

    // Actividad 2: Clase Derivada RobotMovil
    public class RobotMovil : Robot
    {
        private float _velocidad;

        public float Velocidad
        {
            get { return _velocidad; }
            set
            {
                if (value < 0) _velocidad = 0;
                else if (value > 100) _velocidad = 100;
                else _velocidad = value;
            }
        }

        public string Direccion { get; set; }
        public int MotorIzquierdo { get; set; }
        public int MotorDerecho { get; set; }
        public float SensorUltrasonico { get; set; } 

        // Constructor: Recibe parámetros para la base e inicializa los atributos específicos
        public RobotMovil(float peso, string modelo, bool estado, int energiaDisponible, float valorInicialSensor)
            : base(peso, modelo, estado, energiaDisponible)
        {
            Velocidad = 0;
            Direccion = "detenido";
            MotorIzquierdo = 1;
            MotorDerecho = 1;
            SensorUltrasonico = valorInicialSensor;
        }

        // SOBRESCRITURA DE MÉTODOS 
        public override void Encender()
        {
            base.Encender(); 
            Console.WriteLine("[RobotMóvil]: Sistemas de tracción y 4 ruedas listos."); 
        }

        public override void Apagar()
        {
            base.Apagar(); 
            Velocidad = 0;
            Direccion = "detenido";
            Console.WriteLine("[RobotMóvil]: Sensores desactivados y motores desconectados."); 
        }

        public override int VerificarEnergia()
        {
            Console.WriteLine($"[Batería Li-Po]: Analizando estado de las celdas..."); 
            return base.VerificarEnergia();
        }

        public override void RecargarEnergia(int cantidad)
        {
            if (cantidad < 0)
            {
                Console.WriteLine("No se puede recargar una cantidad negativa.");
                return;
            }
            base.RecargarEnergia(cantidad); // Ejecuta la lógica base de la clase padre
            Console.WriteLine($"[Carga]: ¡Módulo de energía del RobotMóvil actualizado de forma segura!"); 
        }

        public override void MostrarEstado()
        {
            base.MostrarEstado(); 
            Console.WriteLine($"-> Velocidad actual: {Velocidad} cm/s | Dirección: {Direccion}"); 
        }

        // MÉTODOS PROPIOS DE LA CLASE DERIVADA
        public void ConsumirEnergia(int cantidad)
        {
            if (cantidad < 0) return;
            EnergiaDisponible -= cantidad;
            Console.WriteLine($"Energía consumida: -{cantidad}%. Energía disponible: {EnergiaDisponible}%");
        }

   
        public void Mover(float velocidad, string direccion)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo antes de realizar cualquier movimiento.");
                return;
            }

            Direccion = direccion;
            Velocidad = velocidad;

            Console.WriteLine($"El robot se mueve hacia '{Direccion}' a una velocidad de {Velocidad} cm/s.");

            if (Velocidad > 0 && Velocidad < 25) ConsumirEnergia(5);
            else if (Velocidad >= 25 && Velocidad < 50) ConsumirEnergia(10);
            else if (Velocidad >= 50 && Velocidad < 75) ConsumirEnergia(15);
            else if (Velocidad >= 75 && Velocidad <= 100) ConsumirEnergia(20);
        }

        public void Detener()
        {
            Velocidad = 0;
            Direccion = "detenido";
            MotorIzquierdo = 0;
            MotorDerecho = 0;
            Console.WriteLine("El robot se ha detenido por completo.");
            ConsumirEnergia(2);
        }

        public void GiroPorDiferencia(string direccion)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para realizar un giro.");
                return;
            }

            if (direccion.Equals("Izquierda", StringComparison.OrdinalIgnoreCase))
            {
                MotorIzquierdo = 0;
                MotorDerecho = 1;
                Direccion = "Girando a la Izquierda (Curvo)";
                Console.WriteLine("Giro diferencial: Motor izquierdo detenido. Girando a la izquierda.");
            }
            else if (direccion.Equals("Derecha", StringComparison.OrdinalIgnoreCase))
            {
                MotorIzquierdo = 1;
                MotorDerecho = 0;
                Direccion = "Girando a la Derecha (Curvo)";
                Console.WriteLine("Giro diferencial: Motor derecho detenido. Girando a la derecha.");
            }
            else
            {
                Console.WriteLine("Dirección de giro no válida.");
                return;
            }
            ConsumirEnergia(5);
        }

        public void GiroPorContrarrotacion(string direccion)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para realizar un giro.");
                return;
            }

            if (direccion.Equals("Izquierda", StringComparison.OrdinalIgnoreCase))
            {
                MotorIzquierdo = -1;
                MotorDerecho = 1;
                Direccion = "Contrarrotación Izquierda";
                Console.WriteLine("Giro cerrado: Motor izquierdo invierte sentido. Girando a la izquierda.");
            }
            else if (direccion.Equals("Derecha", StringComparison.OrdinalIgnoreCase))
            {
                MotorIzquierdo = 1;
                MotorDerecho = -1;
                Direccion = "Contrarrotación Derecha";
                Console.WriteLine("Giro cerrado: Motor derecho invierte sentido. Girando a la derecha.");
            }
            else
            {
                Console.WriteLine("Dirección de giro no válida.");
                return;
            }
            ConsumirEnergia(10);
        }

        public void ObtenerDistanciaSensorUltrasonico()
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado. Enciéndelo para usar el sensor.");
                return;
            }
            Random random = new Random();
            SensorUltrasonico = (float)(random.NextDouble() * 150);
            Console.WriteLine($"Lectura del Sensor Ultrasónico: {SensorUltrasonico:F2} cm.");
        }

        public void AumentarVelocidad(int incremento)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado.");
                return;
            }
            Velocidad += incremento;
            Console.WriteLine($"Velocidad aumentada. Velocidad actual: {Velocidad} cm/s.");
            ConsumirEnergia(5);
        }

        public void DisminuirVelocidad(int decremento)
        {
            if (!Estado)
            {
                Console.WriteLine("El robot está apagado.");
                return;
            }
            Velocidad -= decremento;
            Console.WriteLine($"Velocidad reducida. Velocidad actual: {Velocidad} cm/s.");
            ConsumirEnergia(2);
        }
    }
}
