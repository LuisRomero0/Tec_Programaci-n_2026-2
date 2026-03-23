
using System.Transactions;

namespace MonitoreoDrones.Utilidades
{
    public static class UtilidadesGeograficas
    {
        public static double CalcularDistancia(double lat1, double long1, double lat2, double long2)
        {
            double R = 6371; // Radio de la Tierra en km
            double dLat = ConvertirARadianes(lat2 - lat1);
            double dLong = ConvertirARadianes(long2 - long1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ConvertirARadianes(lat1)) * Math.Cos(ConvertirARadianes(lat2)) *
                       Math.Sin(dLong / 2) * Math.Sin(dLong / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // Distancia en km
        }

        public static double ConvertirARadianes(double angulo)
        {
            return angulo = angulo * Math.PI / 180;
        }
    }
}
