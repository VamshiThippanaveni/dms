using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dms.Models.Admin
{
    [Table("Patient", Schema = "Admin")]
    public class Patient
    {        
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public int Age { get; set; }
        public string? MobileNumber { get; set; }
    }
}
