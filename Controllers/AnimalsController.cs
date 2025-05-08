using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    // api/animals => [controller] = Animals
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {

        // 1. Pobranie listy zwierzat
        // GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            var animals = Database.Animals;
            return Ok(animals);
        }
        
        // 2. Pobranie danych konkretnego zwierzecia po Id
        // GET api/animals/{id} => {id} = 1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            return Ok(animal);
        }

        // 3. Dodanie zwierzecia
        // POST api/animals { "id": 4, "name": "Imie zwierzaka" }
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            Database.Animals.Add(animal);
            return Created();
        }
        
        // 4. Edycja danych zwierzecia
        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Animal newanimal)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            animal.Name = newanimal.Name;
            animal.Category = newanimal.Category;
            animal.Weight = newanimal.Weight;
            animal.FurColor = newanimal.FurColor;
            
            return Ok(animal);
        }
        
        // 5. Usuwanie zwierzecia
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            Database.Animals.Remove(animal);
            return Ok(animal);
        }

        // 6. Wyszukanie zwierzecia na podstawie imienia
        // GET
        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            var animals = Database.Animals.Where(x => x.Name.Contains(name)).ToList();
            return Ok(animals);
        }

    }
}