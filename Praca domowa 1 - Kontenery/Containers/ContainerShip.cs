namespace ConsoleApp1.Containers;

public class ContainerShip
{
    public List<Container> Containers { get; set; } = new List<Container>();
    public int MaxSpeed { get; set; }
    public int MaxNrOfContainers;
    public double MaxAllContainersMass { get; set; }

    public ContainerShip(int maxSpeed, int maxNrOfContainers, double maxAllContainersMass)
    {
        MaxSpeed = maxSpeed;
        MaxAllContainersMass = maxAllContainersMass;
        MaxNrOfContainers = maxNrOfContainers;
    }

    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxNrOfContainers ||
            getAllMass() + container.selfMass + container.LoadMass > MaxAllContainersMass * 1000)
        {
            throw new Exception("The ship cannot fit any more containers.");
        }
        Containers.Add(container);
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }

    public double getAllMass()
    {
        double sum = 0;
        foreach (var c in Containers)
        {
            sum += c.selfMass + c.LoadMass;
        }
        return sum;
    }

    public override string ToString()
    {
        return $"Ship: {Containers.Count}/{MaxNrOfContainers} containers, Weight: {getAllMass()} kg, Max speed: {MaxSpeed} knots";
    }
}