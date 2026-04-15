using System;
using RobotLibrary;

RobotMovil robot = new RobotMovil(15.0f, "RX-200", false, 95, 1, 1);

bool salir = false;
while (!salir)
{
    Console.WriteLine("\n--- MENÚ ROBOT MÓVIL ---");
    Console.WriteLine("1. Encender | 2. Apagar | 3. Estado | 4. Recargar | 5. Mover Adelante");
    Console.WriteLine("6. Mover Atrás | 7. Giro Diferencia | 8. Detener | 9. Sensor | 0. Salir");
    Console.Write("Selecciona una opción: ");

    if (!int.TryParse(Console.ReadLine(), out int opcion)) continue;

    switch (opcion)
    {
        case 1: robot.Encender(); break;
        case 2: robot.Apagar(); break;
        case 3: robot.MostrarEstado(); break;
        case 4:
            Console.Write("Cantidad a recargar: ");
            if (int.TryParse(Console.ReadLine(), out int cant)) robot.RecargarEnergia(cant);
            break;
        case 5: robot.Mover("Adelante", 20); break;
        case 6: robot.Mover("Atras", 10); break;
        case 7:
            Console.Write("Dirección (Izquierda/Derecha): ");
            robot.GiroPorDiferencia(Console.ReadLine());
            break;
        case 8: robot.Detener(); break;
        case 9: robot.ObtenerDistancia(); break;
        case 0: salir = true; break;
        default: Console.WriteLine("Opción no válida."); break;
    }
}
