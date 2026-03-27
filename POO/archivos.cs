// Manejo de archivos 
using System.IO;

// Escritura

// Ruta relativa 
string ruta = "./archivo.txt";

// Ruta absoluta
string ruta2 = @"C:\Users\Alumnos\Documents\LROMERO\archivo2.txt";

using (StreamWriter writer = new StreamWriter(ruta))
{
    writer.WriteLine("Hola, este es el segundo archivo de texto");
    writer.WriteLine("Este es el segundo renglón del archivo");
}

using (StreamWriter writer = new StreamWriter(ruta2))
{
    writer.WriteLine("Hola, estes es el segundo archivo de texto");
    writer.WriteLine("Este es el segundo renglón del archivo");
}
// Apartir de este punto se debe generar el archivo en la ruta especificada

// Lectura
using (StreamReader reader = new StreamReader(ruta))
{
    string contenido = reader.ReadToEnd();
    Console.WriteLine("Contenido del archivo:       ");
    Console.WriteLine(contenido);
}

// Archivo binario 
//Escritura
string rutaB = @"C:\Users\Alumnos\Documents\LROMERO\datosBinarios.bin";

using (BinaryWriter writer = new BinaryWriter(File.Open(rutaB, FileMode.Create)))
{
    writer.Write(25); // Escribir un entero
    writer.Write(3.14); // Escribir un double
    writer.Write("Texto Binario"); // Escribir una cadena
}

Console.WriteLine("Archivo binario creado exitosamente.");

// Lectura

using (BinaryReader reader = new BinaryReader(File.Open(rutaB, FileMode.Open)))
{
    //int numero = reader.ReadInt32(); // Escribir un entero
    //double numeroDecimal = reader.ReadDouble();
    string texto = reader.ReadString();
    //Console.WriteLine(numero);
    //Console.WriteLine(numeroDecimal);
    Console.WriteLine(texto);
}

// Acceso secuencial 
string rutaSecuencial = @"C:\Users\Alumnos\Documents\LROMERO\datosSecuenciales.txt";

using (StreamWriter writer = new StreamWriter(rutaSecuencial))
{
    for ( int i = 1; i <= 200; i++)
    {
        writer.WriteLine($"Línea {i}");
    }
}

using (StreamReader reader = new StreamReader(rutaSecuencial))
{
    string lineaLectura;
    while ((lineaLectura = reader.ReadLine()) != null)
    {
        if (lineaLectura == "Linea 150")
        {
            Console.WriteLine(lineaLectura);
            break;
        }
        //Console.WriteLine(lineaLectura);
    }
}

// Acceso aleatorio

string rutaAleatoria = @"C:\Users\Alumnos\Documents\LROMERO\aleatorio.txt";

using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Create, FileAccess.ReadWrite))
{

    using (StreamWriter writer = new StreamWriter(fs))
    {
        writer.WriteLine("Línea 1");
        writer.WriteLine("Línea 2");
        writer.WriteLine("Línea 3");
    }
}


using (FileStream fs = new FileStream(rutaAleatoria, FileMode.Open, FileAccess.ReadWrite))
{
    fs.Seek(23, SeekOrigin.Begin);

    using (StreamReader reader = new StreamReader(fs))
    {
        string lineaLectura = reader.ReadLine();
        Console.WriteLine("Lectura aleatoria en punto 13:" + lineaLectura);
    }
}


