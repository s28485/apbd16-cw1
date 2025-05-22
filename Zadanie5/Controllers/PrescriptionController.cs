using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cwiczenia5.DTOs;
using Cwiczenia5.Services;

namespace Cwiczenia5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _dbService;
        public PrescriptionController(IDbService service)
        {
            _dbService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription(PrescriptionDto prescriptionDto)
        {
            try
            {
                await _dbService.AddPrescription(prescriptionDto);
                return Ok("");
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("patient/{id}")]
        public async Task<IActionResult> GetPatientInfo(int id)
        {
            var result = await _dbService.GetPatientInfo(id);
            if(result == null)
                return NotFound("Patient not in the database");
        
            return Ok(result);
        }
    }
}
