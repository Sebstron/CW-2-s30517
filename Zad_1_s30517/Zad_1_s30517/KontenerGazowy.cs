namespace Zad_1_s30517;

public class KontenerGazowy : Kontener, IHazardNotifier
{
    public override int height => 350;
    protected override int emptyMass => 650;
    public override int depth => 1100;
    protected override int maxLoad => 3000;
    private Gas gas;
    private double pressure;
    private static readonly Dictionary<Gas, double> gasPressure = new()
    {
        { Gas.Oxygen, 75},
        { Gas.Hydrogen, 225},
        { Gas.Co2, 112.5},
    };

    public KontenerGazowy(Gas gas)
    {
        serialNumber = "KON-G-" + seralNumberCounter;
        this.gas = gas;
        pressure=gasPressure[gas];
    }

    public void Notify(Kontener kontener)
    {
        Console.WriteLine("Na kontenerze o ID: " + kontener.serialNumber +
                          " doszło do wykonania niebezpiecznej sytuacji");
        throw new OverfillException("Ładunek jest za duży");
    }

    public override int Unload()
    {
        if (massTogether == emptyMass)
            Console.WriteLine("Nie można rozładować bo kontener jest już pusty");
        else
        {
            massTogether = (int)(emptyMass+0.05*mass);
            Console.WriteLine("Rozładowano kontener, nowa pusta masa: "+massTogether);
        }
        return massTogether;
    }
    public override int Load(int mass)
    {
        massTogether = mass + emptyMass;

        if (massTogether > maxLoad)
        {
            Console.WriteLine("Próba załadowania "+mass+" kg do kontenera "+serialNumber+" przekracza dopuszczalny limit "+maxLoad+" kg.");
            Notify(this); 
        }
        Console.WriteLine("Załadowano komtener masą: "+mass+" kg\nŁączna masa: "+massTogether+" kg");
        return massTogether;
    }

    
}