using MonitoreoDrones.Dominio.Entidades;
using MonitoreoDrones.Dominio.Enum;

namespace MonitoreoDrones.Extensiones
{
    public static class ExtensionesDron
    {
        // Metodos
        public static bool TieneBateriaBaja(this Dron dron)
        {
            return dron.NivelBateria <= 20;
        }

        public static bool PuedeIniciarMision(this Dron dron)
        {
            return dron.Estado == EstadoDron.Inactivo && dron.NivelBateria > 20;
        }

        public static string ObtenerResumenEstado(this Dron dron)
        {
            return $"Dron {dron.Id}, Estado: {dron.Estado}, Bateria: {dron.NivelBateria}%, Mision {dron.MisionActual}";
        }
    }
}
