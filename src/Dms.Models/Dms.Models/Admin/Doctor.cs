using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dms.Models.Admin
{
    [Table("Doctor", Schema = "Admin")]
    public class Doctor
    {
        [Key]
        public Guid DoctorId { get; set; }
        [Required(ErrorMessage ="Doctor Name is Required")]
        [MaxLength(50),MinLength(3)]
        public string?  DoctorName { get; set; }
        [Required(ErrorMessage ="Department Name is Required")]
        [MaxLength(50), MinLength(3)]
        public string? DoctorDepartment { get; set; }
        [Required(ErrorMessage ="Date of Birth is Required")]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Phone(ErrorMessage ="Invalid Mobile Number")]
        [StringLength(10)]       
        public string? MobileNumber { get; set; }

    }
}
