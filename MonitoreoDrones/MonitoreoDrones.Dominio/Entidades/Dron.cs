using MonitoreoDrones.Dominio.Enum;

namespace MonitoreoDrones.Dominio.Entidades
{
    public class Dron
    {
        // Atributos
        public int Id { get; set; }
        public string Modelo { get; set; }
        public double NivelBateria { get; set; }
        public EstadoDron Estado { get; set; }
        public Posicion Posicion { get; set; }
        public Mision MisionActual { get; set; }

        // Constructor

        public Dron(int id, string modelo, double nivelBateria, Posicion posicion)
        {
            Id = id;
            Modelo = modelo;
            NivelBateria = nivelBateria;
            Posicion = posicion;
            Estado = EstadoDron.Inactivo;
            
        }

        // Metodos
        public void AsignarMision(Mision mision)
        {
            if (Estado != EstadoDron.Inactivo)
            {
                throw new InvalidOperationException("El dron no está disponible");
            }
            Estado = EstadoDron.EnMision;
            MisionActual = mision;
        }

        public void ActualizarBateria(double nivel)
        {
            NivelBateria = nivel;
            if (NivelBateria <= 5)
            {
                Estado = EstadoDron.FueraDeServicio;
            }
        }

        public void EnviarAMantenimiento()
        {
            Estado = EstadoDron.Mantenimiento;
        }
    }
}
