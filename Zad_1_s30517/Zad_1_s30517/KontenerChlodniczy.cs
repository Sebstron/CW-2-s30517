namespace Zad_1_s30517;

public class KontenerChlodniczy : Kontener 
{
    public override int height => 300;
    protected override int emptyMass => 800;
    public override int depth => 1000;
    protected override int maxLoad => 4000;
    private Product product;
    private double temperature;
    private static readonly Dictionary<Product, double> productTemperature = new()
    {
        { Product.Bananas, 13.3 },
        { Product.Chocolate, 18 },
        { Product.Fish, 2 },
        { Product.Meat, -15 },
        { Product.IceCream, -18 },
        { Product.FrozenPizza, -30 },
        { Product.Cheese, 7.2 },
        { Product.Sausages, 5 },
        { Product.Butter, 20.5 },
        { Product.Eggs, 19 }
    };

    public KontenerChlodniczy(Product product)
    {
        serialNumber = "KON-C-" + seralNumberCounter;
        this.product = product;
        temperature = productTemperature[product];
    }
}