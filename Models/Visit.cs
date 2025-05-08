namespace WebApplication1.Models;

public class Visit
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public DateTime Date { get; set; }
    public string DesciptionOfVisit { get; set; }
    public double Price { get; set; }
}