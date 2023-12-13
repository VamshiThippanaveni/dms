using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="Patient is Required")]
        public string? PatientName { get; set; }
        [Required(ErrorMessage ="Age is Required")]
        public int Age { get; set; }
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        [StringLength(10)]
        public string? MobileNumber { get; set; }
    }
}
