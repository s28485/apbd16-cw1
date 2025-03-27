namespace ConsoleApp1.Containers;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; }
    public string Product { get; }

    public RefrigeratedContainer(double temperature, string product, int height, int depth, double selfMass,
        double maxCapacity)
        : base("C", height, depth, selfMass, maxCapacity)
    {
        Temperature = temperature;
        Product = product;
    }
}