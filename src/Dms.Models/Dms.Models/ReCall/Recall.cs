using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dms.Models.ReCall
{
    [Table("Recall", Schema = "ReCall")]
    public class Recall
    {
        public Guid RecallId { get; set; }
        [Required(ErrorMessage ="DoctorId is Required")]
        public Guid DoctorId { get; set; }
        [Required(ErrorMessage = "PatientId is Required")]
        public Guid PatientId { get; set; }
        [Required(ErrorMessage ="Consultant date is Required")]
        [DataType(DataType.Date)]
        [Display(Name ="Consultant Date")]
        public DateTime ConsultantDate { get; set; }
        [Required(ErrorMessage = "Recall date is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Recall Date")]
        public DateTime RecallDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Reschedule Date")]
        public DateTime RescheduleDate{ get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

    }
}
