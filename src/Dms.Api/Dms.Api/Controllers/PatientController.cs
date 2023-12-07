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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Route("GetPatientById")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            try
            {
                _logger.LogInformation($"Get patient by id:{id}");
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    _logger.LogInformation($"Patient with Id:{id} is not found");
                    return NotFound();
                }
                _logger.LogInformation($"Successfuly retrieved patient by Id:{id}");
                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while getting patient with Id");
                return StatusCode(500, "Internal server error");
            }          
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[Route("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            try
            {
                _logger.LogInformation("Add a new patient");
                await _patientRepository.AddPatientAsync(patient);
                _logger.LogInformation($"Successfully added new patient with Id:{patient.PatientId}");
                return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding new patient");
                return StatusCode(500, "Internal server error");
            }         
        }
        //[HttpGet]
        [HttpPut("{id}")]        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Route("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] Patient patient)
        {
            try
            {
                _logger.LogInformation($"Updating the existing patient with Id:{id}");
                var existingPatient = await _patientRepository.GetPatientByIdAsync(id);
                if (existingPatient == null)
                {
                    _logger.LogInformation($"Patient with id {id} is not found");
                    return NotFound();
                }
                await _patientRepository.UpdatePatientAsync(existingPatient);
                _logger.LogInformation($"Successfully Updated the patient with Id:{id}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while updating the patient with Id");
                return StatusCode(500, "Internal server error");
            }
            
        }
        //[HttpDelete]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Route("DeletePatient")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                _logger.LogInformation($"Deleting the patient with Id:{id}");
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    _logger.LogInformation($"Delete patient with Id:{id} is not found");
                    return NotFound();
                }
                await _patientRepository.DeletePatientByIdAsync(id);
                _logger.LogInformation($"Successfully Deleted the patient with Id:{id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while deleting the patient with Id");
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}
