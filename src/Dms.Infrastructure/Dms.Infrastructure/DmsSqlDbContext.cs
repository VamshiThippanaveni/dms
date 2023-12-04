using Dms.Models.Admin;
using Dms.Models.ReCall;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dms.Infrastructure
{
    public class DmsSqlDbContext : DbContext 
    {
        public DbSet<Models.Admin.Doctor> Doctors { get; init; }
        public DbSet<Models.Admin.Patient> Patients { get; init; }
        public DbSet<Models.ReCall.Recall> Recalls { get; init; }

        public DmsSqlDbContext(DbContextOptions<DmsSqlDbContext> options) : base(options)
        {
            
        }
    }
}
