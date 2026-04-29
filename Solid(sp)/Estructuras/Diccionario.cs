// Estructura no lineal Diccionario
// Cada clave es única y tiene un valor asociado
// No mantiene un orden especifico 
// No tiene orden de inserción

// Creacion

Dictionary<string, int> edades = new Dictionary<string, int>();

// Agregar elementos
edades.Add("Ana", 25);
edades.Add("Juan", 30);
edades["Maria"] = 28;

// Acceso 
int edadAna = edades["Ana"];
Console.WriteLine(edadAna);

// Verificar existencia de clave 
if (edades.ContainsKey("Carlos"))
{
    Console.WriteLine("Carlos existe.");
}

if(edades.ContainsValue(25))
{
    Console.WriteLine("Alguien tiene 25 años.");
}

// Intentar obtener el valor de una clave

if(edades.TryGetValue("Juan", out int edadJuan))
{
    Console.WriteLine($"La edad de Juan es {edadJuan}.");
}
else
{
    Console.WriteLine("Juan no existe en el diccionario.");
}

// Recorrer el diccionario
foreach (KeyValuePair <string, int> kvp in edades)
{
    Console.WriteLine($"Clave: {kvp.Key}, Valor: {kvp.Value}");
}

foreach (string nombre in edades.Keys)
{
    Console.WriteLine(nombre);
}

foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}

// Eliminar un elemento

edades.Remove("Ana");
foreach (int edad in edades.Values)
{
    Console.WriteLine(edad);
}



Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
