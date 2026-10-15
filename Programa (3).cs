/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/

using System;

public interface ICurable
{
    void Curar();
}

public interface IDefendible
{
    void Defender();
}

public abstract class Personaje
{
    private string nombre;
    private int vida;
    private int nivel;

    public string Nombre
    {
        get { return nombre; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre no puede estar vacío.");

            nombre = value;
        }
    }

    public int Vida
    {
        get { return vida; }
        protected set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value));

            vida = value;
        }
    }

    public int Nivel
    {
        get { return nivel; }
        protected set
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            nivel = value;
        }
    }

    protected Personaje(string nombre, int vida, int nivel)
    {
        Nombre = nombre;

        if (vida < 1 || vida > 100)
            throw new ArgumentOutOfRangeException(nameof(vida));

        Vida = vida;
        Nivel = nivel;
    }

    public void MostrarEstado()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Vida: {Vida}");
        Console.WriteLine($"Nivel: {Nivel}");
    }

    public abstract void Atacar();

    public void RecibirDanio(int cantidad)
    {
        if (cantidad < 0)
        {
            Console.WriteLine("El daño no puede ser negativo.");
            return;
        }

        if (Vida == 0)
        {
            Console.WriteLine($"{Nombre} ya ha sido derrotado.");
            return;
        }

        Console.WriteLine($"{Nombre} recibe {cantidad} puntos de daño.");

        Vida = Math.Max(0, Vida - cantidad);

        Console.WriteLine($"Vida restante: {Vida}");

        if (Vida == 0)
            Console.WriteLine($"{Nombre} ha sido derrotado.");
    }

    protected void RecuperarVida(int cantidad)
    {
        if (cantidad < 0)
            return;

        int vidaAnterior = Vida;
        Vida = Math.Min(100, Vida + cantidad);

        Console.WriteLine($"Vida recuperada: {Vida - vidaAnterior}");
        Console.WriteLine($"Vida actual: {Vida}");
    }
}

public class Guerrero : Personaje, IDefendible
{
    public int Fuerza { get; private set; }

    public Guerrero(string nombre, int vida, int nivel, int fuerza)
        : base(nombre, vida, nivel)
    {
        if (fuerza < 0)
            throw new ArgumentOutOfRangeException(nameof(fuerza));

        Fuerza = fuerza;
    }

    public override void Atacar()
    {
        Console.WriteLine(
            $"{Nombre} ataca con su espada causando {Fuerza} puntos de daño."
        );
    }

    public void Defender()
    {
        Console.WriteLine(
            $"{Nombre} levanta su escudo y se prepara para defenderse."
        );
    }
}

public class Mago : Personaje, ICurable
{
    public int Mana { get; private set; }

    public Mago(string nombre, int vida, int nivel, int mana)
        : base(nombre, vida, nivel)
    {
        if (mana < 0)
            throw new ArgumentOutOfRangeException(nameof(mana));

        Mana = mana;
    }

    public override void Atacar()
    {
        Console.WriteLine(
            $"{Nombre} lanza un hechizo causando 40 puntos de daño."
        );
    }

    public void Curar()
    {
        Console.WriteLine($"{Nombre} utiliza magia de curación.");
        RecuperarVida(20);
    }
}

public class Arquero : Personaje
{
    public int Flechas { get; private set; }

    public Arquero(string nombre, int vida, int nivel, int flechas)
        : base(nombre, vida, nivel)
    {
        if (flechas < 0)
            throw new ArgumentOutOfRangeException(nameof(flechas));

        Flechas = flechas;
    }

    public override void Atacar()
    {
        if (Flechas == 0)
        {
            Console.WriteLine($"{Nombre} no tiene flechas disponibles.");
            return;
        }

        Console.WriteLine(
            $"{Nombre} dispara una flecha causando 25 puntos de daño."
        );

        Flechas--;

        Console.WriteLine($"Flechas restantes: {Flechas}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Guerrero guerrero = new Guerrero("Kratos", 100, 5, 30);
        Mago mago = new Mago("Merlín", 80, 6, 100);
        Arquero arquero = new Arquero("Legolas", 90, 4, 3);

        Personaje[] personajes =
        {
            guerrero,
            mago,
            arquero
        };

        Console.WriteLine("===== PERSONAJES =====\n");

        foreach (Personaje personaje in personajes)
        {
            personaje.MostrarEstado();
            Console.WriteLine();

            personaje.Atacar();

            Console.WriteLine("\n--------------------\n");
        }

        Console.WriteLine("===== HABILIDADES =====\n");

        guerrero.Defender();

        Console.WriteLine();

        mago.RecibirDanio(30);

        Console.WriteLine();

        mago.Curar();

        Console.WriteLine();

        Console.WriteLine("===== ATAQUES DEL ARQUERO =====\n");

        arquero.Atacar();
        arquero.Atacar();
        arquero.Atacar();
        arquero.Atacar();

        Console.WriteLine();

        Console.WriteLine("===== DAÑO AL GUERRERO =====\n");

        guerrero.RecibirDanio(30);

        Console.WriteLine("\n===== ESTADO FINAL =====\n");

        foreach (Personaje personaje in personajes)
        {
            personaje.MostrarEstado();
            Console.WriteLine();
        }

        Console.WriteLine("Presiona una tecla para finalizar.");
        Console.ReadKey();
    }
}
