using Dms.Core.Interfaces;
using Dms.Models.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dms.Infrastructure.Repositories.AdminRepository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DmsSqlDbContext _dbContext;
        public DoctorRepository(DmsSqlDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _dbContext.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            return await _dbContext.Doctors.FindAsync(id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
             await _dbContext.SaveChangesAsync();
        }
           
        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _dbContext.Doctors.Update(doctor);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteDoctorByIdAsync(Guid id)
        {
            var doctor=await _dbContext.Doctors.FindAsync(id);
            if (doctor!=null)
            {
                _dbContext.Doctors.Remove(doctor);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
