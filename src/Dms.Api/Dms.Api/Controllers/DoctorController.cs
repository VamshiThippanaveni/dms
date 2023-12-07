using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dms.Infrastructure.Repositories.AdminRepository;
using Dms.Core.Interfaces;
using Dms.Models.Admin;

namespace Dms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ILogger<DoctorController> _logger;
        public DoctorController(IDoctorRepository repository, ILogger<DoctorController> logger)
        {
            _doctorRepository = repository;
            _logger = logger;
        }
        [HttpGet]
        //https://localhost:7110/api/Doctor
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                _logger.LogInformation("Get all doctors method started");
                var doctors = await _doctorRepository.GetAllDoctorsAsync();
                _logger.LogInformation("Successfully retrived all doctors");
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while fetching all doctors method");
                return StatusCode(500, "Internal server error");
            }

        }
        //[HttpGet]
        [HttpGet("{id}")]
        //https://localhost:7110/api/Doctor/Guid
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            try
            {
                _logger.LogInformation($" Get doctor by Id:{id}");
                var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
                if (doctor == null)
                {
                    _logger.LogInformation($"doctor with Id:{id} is not found");
                    return NotFound();
                }
                _logger.LogInformation($"Successfully retrieved doctor by Id:{id}");
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured while getting doctor with Id");
                return StatusCode(500,"Internal server error");
            }
        }
        [HttpPost]
        //https://localhost:7110/api/Doctor/Add
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            try
            {
                _logger.LogInformation("Adding a new doctor");
                await _doctorRepository.AddDoctorAsync(doctor);
                _logger.LogInformation($"Successfully added a new doctor with Id{doctor.DoctorId}");
                return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorId }, doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding a new doctor");
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpPut]
        [HttpPut("{id}")]
        //https://localhost:7110/api/Doctor/EditGuid
        public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] Doctor doctor)
        {
            try
            {
                _logger.LogInformation($"Updating the existing doctor with Id:{id}");
                var existingDoctor = await _doctorRepository.GetDoctorByIdAsync(id);
                if (existingDoctor == null)
                {
                    _logger.LogInformation($"Doctor with Id:{id} is not found");
                    return NotFound();
                }
                await _doctorRepository.UpdateDoctorAsync(existingDoctor);
                _logger.LogInformation($"successfully Updated the existing doctor with Id:{id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured while updating the existing doctor with Id");
                return StatusCode(500,"Internal server error");
            }
        }
        //[HttpDelete]
        [HttpDelete("{id}")]
        //https://localhost:7110/api/Doctor/deleteGuid
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            try
            {
                _logger.LogInformation($"Deleting the doctor with Id:{id}");
                var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
                if (doctor == null)
                {
                    _logger.LogInformation($"Doctor with Id:{id} is not found");
                    return NotFound();
                }
                await _doctorRepository.DeleteDoctorByIdAsync(id);
                _logger.LogInformation($"Successfully deleted the doctor with Id:{id}");
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"An error occured while deleting the doctor with Id");
                return StatusCode(500, "Intenal server error");
            }         
        }
    }
}
