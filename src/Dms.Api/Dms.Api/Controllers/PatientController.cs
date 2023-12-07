using Dms.Core.Interfaces;
using Dms.Models.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientController> _logger;
        public PatientController(IPatientRepository repository,ILogger<PatientController> logger)
        {
            _patientRepository = repository;   
            _logger = logger;
        }
        [HttpGet]
        //[Route("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                _logger.LogInformation("Get all patients method started");
                var patient = await _patientRepository.GetAllPatientsAsync();
                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while fetching all patients method");
                return StatusCode(500, "Internal server error");
            }
           
        }
        //[HttpGet]
        [HttpGet("{id}")]
        //[Route("GetPatientById")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient=await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpPost]
        //[Route("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            await _patientRepository.AddPatientAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
        }
        //[HttpGet]
        [HttpPut("{id}")]
        //[Route("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] Patient patient)
        {
            var existingPatient=await _patientRepository.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound();
            }
            await _patientRepository.UpdatePatientAsync(existingPatient);
            return NoContent();
        }
        //[HttpDelete]
        [HttpDelete("{id}")]
        //[Route("DeletePatient")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            await _patientRepository.DeletePatientByIdAsync(id);
            return NoContent();
        }
    }
}
