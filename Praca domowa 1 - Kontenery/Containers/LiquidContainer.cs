namespace ConsoleApp1.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(bool isHazardous, int height, int depth, double selfMass, double maxCapacity) 
        : base("L",  height, depth, selfMass, maxCapacity)
    {
        this.IsHazardous = isHazardous;
    }
    
    public void notifyHazard(string msg)
    {
        Console.WriteLine("Container " + this.serialNr + " : " + msg);
    }

    public new void loadContainer(double new_load_mass)
    {
        double allowedLoadMass = IsHazardous ? maxCapacity * 0.5 : maxCapacity * 0.9;
        if (new_load_mass > allowedLoadMass)
        {
            notifyHazard("Hazardous load  mass exceeds allowed");
            throw new OverfillException("");
        }
        base.loadContainer(new_load_mass);
    }
}