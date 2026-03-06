// FALTA LO DE LA CLASE QUE FALTE 02 / MARZO
// PROGRAMA PINCIPAL DE HERENCIA CON POLIMORFISMO 

Perro perro = new Perro();
perro.HacerSonido();

Animal otroPerro = new Perro();
otroPerro.HacerSonido();

Animal gato = new Gato();
gato.HacerSonido();

Paloma paloma = new Paloma();
paloma.HacerSonido();
paloma.Volar();

Paloma tucan = new Tucan();
tucan.HacerSonido();
tucan.Volar();

// Con interfaces

IVolar pajaro = new PalomaI();
IAnimal otroPajaro = new PerroI(); 

Dragon dragon = new Dragon();  
dragon.HacerSonido();
dragon.Volar();

// Herencia con polimosfismo 

// CLASE PADRE / CLASE BASE

public class Animal
{
    // METODOS 

    public void Respirar()
    {
        Console.WriteLine("Estoy respirando");
    }

    // Polimorfismo con herencia 

    public virtual void HacerSonido()
    {
        Console.WriteLine("El animal hace sonido");
    }
}


// CLASES HIJAS

public class Perro : Animal
{
    public void Ladrar()
    {
        Console.WriteLine("Guau guau");
    }

    public override void HacerSonido()
    {
        //base.HacerSonido();
        Ladrar();
    }
}

public class Gato : Animal
{
    public override void HacerSonido()
    {
        Console.WriteLine("Miau Miau");
    }
}

public class Paloma : Animal
{
    public void Volar()
    {
        Console.WriteLine("Paloma volando");
    }

    public override void HacerSonido()
    {
        Console.WriteLine("Cucurrucu");
    }
}

public class Tucan : Paloma
{

}

// USANDO INTERFACES

public interface IANIMAL
{
    void HacerSonido();
}

public interface IVolar
{
    void Volar();
}

public class Dragon : IAnimal, IVolar
{
    public void Volar()
    { }
}



public class PerroI : IANIMAL
{
    public void HacerSonido()
    {
        Console.WriteLine("Guau Guau");
    }
}

public class PalomaI : IANIMAL, IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("Cucurrucu")
    }

    public void Volar()
    {
        Console.WriteLine("Paloma vuela")
    }
}

public class ColibriI : IANIMAL, IVolar
{
    public void HacerSonido()
    {
        Console.WriteLine("Sonido Colibri")
    }

    public void Volar()
    {
        Console.WriteLine("Colibri vuela")
    }
}