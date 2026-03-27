using MonitoreoDrones.Dominio.Entidades;
using MonitoreoDrones.Extensiones;
using MonitoreoDrones.Utilidades;

// Crear Dron

var dron = new Dron(
    id:1,
    modelo: "Dron2DJI",
    nivelBateria: 80,
    posicion: new Posicion(19.4326, -99.1332)
    );

// Crear una mision 

var mision = new Mision(1, "Rescate", 30);

// Validar si puede iniciar mision

if(dron.PuedeIniciarMision())
{
    dron.AsignarMision(mision);
}

// Calcular distancia 
double distancia = UtilidadesGeograficas.CalcularDistancia(
    dron.Posicion.Latitud, dron.Posicion.Longitud,
    19.4270, -99.1276
    );

// Estimar consumo
double consumo = UtilidadesCalculoDron.EstimarConsumoBateria(distancia);

// Actualizar bateria
dron.ActualizarBateria(dron.NivelBateria -  consumo);

// Mostrar resutados
Console.WriteLine(dron.ObtenerResumenEstado());
Console.WriteLine($"Distancia: {distancia:F2} [km]");
Console.WriteLine($"Consumo estimado {consumo:F2}%");
