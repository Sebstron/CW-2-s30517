namespace Zad_1_s30517;

public abstract class Kontener
{
    protected int mass;
    public abstract int height { get; }
    protected abstract int emptyMass { get; }
    public abstract int depth { get; }
    protected abstract int maxLoad { get;  }
    public string serialNumber { get; set; }
    public int massTogether { get; set; }
    protected static int seralNumberCounter = 0;

    protected Kontener()
    {
        seralNumberCounter++;
        massTogether = emptyMass;
    }

    public virtual int Unload()
    {   
        if (massTogether == emptyMass)
            Console.WriteLine("Nie można rozładować bo kontener jest już pusty");
        else
        {
            massTogether = emptyMass;
            Console.WriteLine("Rozładowano kontener");
        }
        return massTogether;
    }

    public virtual int Load(int mass)
    {
        this.mass = mass;
        massTogether = mass + emptyMass;
        if (massTogether > maxLoad)
            throw new OverfillException("Ładunek jest za duży");
        Console.WriteLine("Załadowano komtener masą: "+mass+" kg\nŁączna masa: "+massTogether+" kg");
        return massTogether;
    }

    public int getMassTogether()
    {
        return massTogether;
    }

    public string getSerialNumber()
    {
        return serialNumber;
    }
}