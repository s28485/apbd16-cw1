namespace ConsoleApp1.Containers;

public class Container
{
    // Zmienna, która pozwoli nam generować niepowtarzalne numery seryjne
    public static int serialNrCounter = 1;
    
    public double LoadMass { get; set; }
    public double selfMass;
    public double maxCapacity;
    
    public int Height { get; }
    public int Depth { get; }
    
    public string serialNr;
    
    // Konstruktor
    public Container(string type, int height, int depth, double selfMass, double maxCapacity)
    {
        this.serialNr = $"KON-{type}-{serialNrCounter++}";
        Height = height;
        Depth = depth;
        this.selfMass = selfMass;
        this.maxCapacity = maxCapacity;
    }
    
    // Metody
    public void emptyContainer()
    {
        LoadMass = 0;
    }

    public void loadContainer(double new_load_mass)
    {
        if (new_load_mass + LoadMass >= maxCapacity)
        {
            throw new OverflowException("The load mass exceeds the max capacity");
        }
        LoadMass += new_load_mass;
    }

    public override string ToString()
    {
        return $"{serialNr}: Waga ładunku = {LoadMass} kg, Maksymalna ładowność =  {maxCapacity} kg";
    }

    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }

}