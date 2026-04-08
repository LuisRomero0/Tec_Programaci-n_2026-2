using RobotLibrary;
using System.Reflection;

// Creacion de un robot y prueba de sus funcionalidades

RobotMovil robot = new RobotMovil(5.0, "modelo", true, 95, 15.0, "Adelante", 1, 1, 16.0) 

while (true)
{
    Console.WriteLine("Selecciona una opción:");
    Console.WriteLine("1. Encender Robot");
    Console.WriteLine("2. Apagar Robot");
    Console.WriteLine("3. Mostrar estado");
    Console.WriteLine("4. Verificar energia");
    Console.WriteLine("5. Recargar energia");
    Console.WriteLine("6. Mover adelante");
    Console.WriteLine("7. Mover atras");
    Console.WriteLine("8. Giro por diferencia");
    Console.WriteLine("9. Giro por contrarrotacion");
    Console.WriteLine("10. Detener Robot");
    Console.WriteLine("11. Medir distancia con sensor ultrasonico");
    Console.WriteLine("12. Aumentar velocidad");
    Console.WriteLine("13. Reducir velocidad");
    Console.WriteLine("0. Salir");


   /* switch (int.Parse(Console.ReadLine()))
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
            robot.VerificarEnergia();
            break;

        case 5:
           // Console.WriteLine("Ingrese la cantidad de energía a recargar:");
           / int cantidad = int.Parse(Console.ReadLine());
            robot.RecargarEnergia(cantidad);
            break;

        case 6:
            //robot.MoverAdelante();
            break;

        case 7:
            robot.MoverAtras();
            break;

        case 8:
            Console.WriteLine("Ingrese la dirección de giro (Izquierda/Derecha):");
            string direccionGiro = Console.ReadLine();
            robot.GiroPorDiferencia(direccionGiro);
            break;
        case 9:
           // robot.GiroPorContrarrotacion(direccionGiroContrarrotacion);
            break;
        case 10:
           // robot.Detener();
            break;
        case 11:
           // robot.ObtenerDistanciaSensorUltrasonico();
            break;
    }*/
}
