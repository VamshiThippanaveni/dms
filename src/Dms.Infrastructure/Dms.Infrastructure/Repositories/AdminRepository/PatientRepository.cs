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
    public class PatientRepository : IPatientRepository
    {
        private readonly DmsSqlDbContext _dbContext;
        public PatientRepository(DmsSqlDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _dbContext.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            return await _dbContext.Patients.FindAsync(id);
        }
        public async Task AddPatientAsync(Patient patient)
        {
            _dbContext.Patients.Add(patient);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdatePatientAsync(Patient patient)
        {
            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePatientByIdAsync(Guid id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
           if(patient != null)
            {
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}
