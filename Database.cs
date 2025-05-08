using WebApplication1.Models;
namespace WebApplication1;

public class Database
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal() {Id = 1, Name = "Lucyna", Category = "cat", Weight = 3.4, FurColor = "black"},
        new Animal() {Id = 2, Name = "Bakster", Category = "dog", Weight = 7.8, FurColor = "gold"},
        new Animal() {Id = 3, Name = "Łata", Category = "dog", Weight = 12.1, FurColor = "brown"},
        new Animal() {Id = 4, Name = "Mruczek", Category = "cat", Weight = 2.9, FurColor = "grey"},
        new Animal() {Id = 5, Name = "Burmistrz", Category = "parrot", Weight = 0.3, FurColor = "multicolor"}
    };
    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit(){Id = 2501, AnimalId = 2, Date = new DateTime(2025, 01, 04) ,
            DesciptionOfVisit = "Badanie krwi", Price = 150.0},
        new Visit(){Id = 2502, AnimalId = 1, Date = new DateTime(2025, 01, 05) ,
            DesciptionOfVisit = "Pakiet szczepień", Price = 300.0},
        new Visit(){Id = 2503, AnimalId = 1, Date = new DateTime(2025, 01, 18),
            DesciptionOfVisit = "Check-up po szczepieniu", Price = 0.0},
        new Visit(){Id = 2504, AnimalId = 4, Date = new DateTime(2025, 01, 21) ,
            DesciptionOfVisit = "Sterylizacja", Price = 400.0},
        new Visit(){Id = 2505, AnimalId = 3, Date = new DateTime(2024, 01, 21) ,
            DesciptionOfVisit = "Zalozenie opatrunku", Price = 50.0},
        new Visit(){Id = 2506, AnimalId = 5, Date = new DateTime(2024, 01, 26) ,
            DesciptionOfVisit = "Wizyta kontrolna + zestaw badań", Price = 150.0}
    };
}