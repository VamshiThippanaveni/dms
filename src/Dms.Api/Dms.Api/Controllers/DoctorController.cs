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
        public DoctorController(IDoctorRepository repository)
        {
            _doctorRepository = repository;
        }
        [HttpGet]
        //https://localhost:7110/api/Doctor
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();
            return Ok(doctors);
        }
        //[HttpGet]
        [HttpGet("{id}")]
        //https://localhost:7110/api/Doctor/Guid
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
        [HttpPost]
        //https://localhost:7110/api/Doctor/Add
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            await _doctorRepository.AddDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.DoctorId }, doctor);
        }
        //[HttpPut]
        [HttpPut("{id}")]
        //https://localhost:7110/api/Doctor/EditGuid
        public async Task<IActionResult> UpdateDoctor(Guid id,[FromBody] Doctor doctor)
        {
            var existingDoctor = await _doctorRepository.GetDoctorByIdAsync(id);
            if(existingDoctor== null)
            {
                return NotFound();
            }
            await _doctorRepository.UpdateDoctorAsync(existingDoctor);
            return NoContent();
        }
        //[HttpDelete]
        [HttpDelete("{id}")]
        //https://localhost:7110/api/Doctor/deleteGuid
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var doctor=await _doctorRepository.GetDoctorByIdAsync(id);
            if(doctor == null)
            {
                return NotFound();
            }
            await _doctorRepository.DeleteDoctorByIdAsync(id);
            return NoContent();
        }
    }
}
