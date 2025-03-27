namespace ConsoleApp1.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(double pressure, int height, int depth, double selfMass, double maxCapacity)
        : base("G", height, depth, selfMass, maxCapacity)
    {
        Pressure = pressure;
    }

    public void notifyHazard(string msg)
    {
        Console.WriteLine("Container " + this.serialNr + " : " + msg);
    }

    public new void unloadContainer()
    {
        LoadMass *= 0.05;
    }
}