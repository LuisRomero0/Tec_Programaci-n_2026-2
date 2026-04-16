using System;
using RobotLibrary;

RobotMovil robot = new RobotMovil(15.0f, "RX-200", false, 95, 1, 1);

bool salir = false;
while (!salir)
{
    Console.WriteLine("\n--- MENÚ ROBOT MÓVIL ---");
    Console.WriteLine("1. Encender robot | 2. Apagar robot | 3. Mostrar estado | 4. Verificar energia | 5. Recargar energia");
    Console.WriteLine("6. Mover Adelante | 7. Mover atras | 8. Giro por diferencia | 9. Giro por contrarrotacion"); 
    Console.WriteLine("10. Detener Robot | 11. Medir distancia con sensor Ultrasonico | 12. Aumentar velocidad");
    Console.WriteLine("13. Reducir velocidad | 0. Salir");
    Console.Write("Selecciona una opción: ");

    if (!int.TryParse(Console.ReadLine(), out int opcion)) continue;

        switch (opcion)
    {
        case 1: 
            robot.Encender(); 
            break;
        case 2: 
            robot.Apagar(); 
            break;
        case 3: 
            robot.MostrarEstado(); 
            break;
        case 4:
            Console.WriteLine($"Energía actual: {robot.EnergiaDisponible}%");
            break;
        case 5: 
            Console.Write("Cantidad a recargar: ");
            if (int.TryParse(Console.ReadLine(), out int cant)) robot.RecargarEnergia(cant);
            break;
        case 6: 
            robot.Mover("Adelante", 20); 
            break;
        case 7: 
            robot.Mover("Atras", 10); 
            break;
        case 8:
            Console.Write("Dirección para Giro Diferencial (Izquierda/Derecha): ");
            robot.GiroPorDiferencia(Console.ReadLine());
            break;
        case 9: 
            Console.Write("Dirección para Giro Contrarrotación (Izquierda/Derecha): ");
            robot.GiroPorContrarrotacion(Console.ReadLine());
            break;
        case 10: 
            robot.Detener(); 
            break;
        case 11:
            robot.ObtenerDistanciaSensorUltrasonico();
            break;
        case 12: 
            Console.Write("Cantidad para aumentar velocidad: ");
            if (int.TryParse(Console.ReadLine(), out int inc)) robot.AumentarVelocidad(inc);
            break;
        case 13:
            Console.Write("Cantidad para reducir velocidad: ");
            if (int.TryParse(Console.ReadLine(), out int dec)) robot.DisminuirVelocidad(dec);
            break;
        case 0: 
            salir = true; 
            break;
        default: 
            Console.WriteLine("Opción no válida."); 
            break;
    }
