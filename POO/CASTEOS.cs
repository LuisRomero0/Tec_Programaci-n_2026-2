// CASTEOS

// CONVERSION IMPLICITA 

int numeroEntero = 42;
double numDouble = numeroEntero;

Console.WriteLine(numDouble);

// CONVERSION EXPLICITA

double numDouble2 = 42.75;
int numEntero2 = (int)numDouble2;
Console.WriteLine(numEntero2);

// CONVERSION CON METODOS

string texto = "123";
int numerot = Convert.ToInt32(texto);
Console.WriteLine(numerot);

// PARSE

string texto2 = "3.14";
double doublet = double.Parse(texto2);
Console.WriteLine(doublet);

string texto3 = "314";
int entero4 = int.Parse(texto3);

// Try Parse 

string texto3 = "31.4";
bool exito = int.TryParse(texto3, out int resultado);
Console.WriteLine(exito);
Console.WriteLine(resultado);

// Casteos entre objetos y clases 

// Upper casting Hijo - Padre

Animal miAnimal = new Perro();

// Down casting Padre - Hijo

Animal animal = new Animal()

//Perro perro = (Perro)new Animal();
//animal as Perro();
//perro.Ladrar();

    if (animal is Perro)
    {
        Console.WriteLine("Es un perro");
    }

object obj = "cadena"
string texto5= obj as string;
Console.WriteLine(obj);


