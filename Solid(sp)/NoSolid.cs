using System;
using System.Collections.Generic;

// PROGRAMA PRINCIPAL

        var servicioEmail = new EmailService();
        var calculadora = new CalculadoraVeterinaria();

        var sistema = new SistemaVeterinaria(servicioEmail, calculadora);

        var miMascota = new Mascota("Juanito", "Perro", 2);
        sistema.AtenderMascota(miMascota);



// Definimos Interfaces Principio D: Inversión de Dependencias
public interface INotificador {
    void EnviarNotificacion(string mensaje);
}

// Clase de Datos pura Principio S: Responsabilidad Única
public class Mascota {
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Edad { get; set; }
    public Mascota(string n, string t, int e) { Nombre = n; Tipo = t; Edad = e; }
}

// Clase para Lógica de Cálculos Principio O: Abierto/Cerrado
public class CalculadoraVeterinaria {
    public decimal CalcularCosto(Mascota m) {
        if (m.Tipo.StartsWith("P")) return 200;
        if (m.Tipo.StartsWith("G")) return 180;
        return m.Edad * 50;
    }
}

// Implementación del Notificado
public class EmailService : INotificador {
    public void EnviarNotificacion(string mensaje) {
        Console.WriteLine($"[EMAIL]: {mensaje}");
    }
}

// Sistema principal coordinando clases independientes
public class SistemaVeterinaria {
    private List<Mascota> _mascotas = new List<Mascota>();
    private INotificador _notificador; // Dependemos de la interfaz
    private CalculadoraVeterinaria _calc;

    // Recibimos las clases ya listas para usar
    public SistemaVeterinaria(INotificador notificador, CalculadoraVeterinaria calc) {
        _notificador = notificador;
        _calc = calc;
    }

    public void AtenderMascota(Mascota mascota) {
        // Validación simple antes de procesar cada mascota que ingrese 
        if (string.IsNullOrEmpty(mascota.Nombre)) return;

        _mascotas.Add(mascota);
        decimal costo = _calc.CalcularCosto(mascota);
        
        _notificador.EnviarNotificacion($"Mascota: {mascota.Nombre}, Costo: {costo}");
        
        MostrarReporte();
    }

    public void MostrarReporte() {
        Console.WriteLine("--- Reporte Actualizado ---");
        _mascotas.ForEach(m => Console.WriteLine($"- {m.Nombre}"));
    }
}
