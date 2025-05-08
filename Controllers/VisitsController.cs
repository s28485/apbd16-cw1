using System.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        // 1. Pobranie listy wizyt powiazanych z danym zwierzeciem
        // GET api/visits
        [HttpGet]
        public IActionResult GetVisits(int animalId)
        {
            var visits = Database.Visits.Where(x => x.AnimalId == animalId).ToList();
            return Ok(visits);
        }
        
        // 2. Dodanie nowych wizyt
        // POST api/visits
        [HttpPost]
        public IActionResult AddNewVisit(int animalId, Visit visit)
        {
            if (!Database.Animals.Any(x => x.Id == animalId))
            {
                return NotFound("No such animal in the database");
            }
            
            visit.Id = Database.Visits.Any() ? Database.Visits.Max(x => x.Id) + 1 : 1;
            visit.AnimalId = animalId;
            Database.Visits.Add(visit);

            return Ok(visit);
        }
    }
    
}
