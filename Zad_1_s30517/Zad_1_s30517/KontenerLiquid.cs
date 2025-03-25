namespace Zad_1_s30517;

public class KontenerLiquid : Kontener, IHazardNotifier
{
    public override int height => 400;
    protected override int emptyMass => 1000;
    public override int depth => 1200;
    protected override int maxLoad => 5000;
    private Liquid liquid;
    private bool dangerous;

    private static readonly Dictionary<Liquid, bool> liquidDangerous = new()
    {
        { Liquid.Milk, false },
        { Liquid.Water, false },
        { Liquid.Fuel, true },
        { Liquid.LiquidNitrogen, true }
    };

    public KontenerLiquid(Liquid liquid)
    {
        serialNumber = "KON-L-" + seralNumberCounter;
        this.liquid = liquid;
        dangerous = liquidDangerous[liquid];
    }

    public void Notify(Kontener kontener)
    {
        Console.WriteLine("Na kontenerze o ID: " + kontener.serialNumber +
                          " doszło do wykonania niebezpiecznej sytuacji");
        throw new OverfillException("Ładunek jest za duży");
    }

    public override int Load(int mass)
    {
        int newMaxLoad = dangerous ? (int)(maxLoad * 0.5) : (int)(maxLoad * 0.9);
        massTogether = mass + emptyMass;

        if (massTogether > newMaxLoad)
        {
            Console.WriteLine("Próba załadowania "+mass+" kg do kontenera "+serialNumber+" przekracza nowy dopuszczalny limit "+newMaxLoad+" kg.");
            Notify(this); 
        }
        Console.WriteLine("Załadowano komtener masą: "+mass+" kg\nŁączna masa: "+massTogether+" kg");
        return massTogether;
    }
}