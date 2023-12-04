using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dms.Models.Admin
{
    [Table("Doctor",Schema ="Admin")]
    public class Doctor
    {        
        public Guid DoctorId { get; set; }
        public string?  DoctorName { get; set; }
        public string? DoctorDepartment { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? MobileNumber { get; set; }


    }
}
