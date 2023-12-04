using System;
using System.Collections.Generic;
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
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime ConsultantDate { get; set; }
        public DateTime RecallDate { get; set; }
        public DateTime RescheduleDate{ get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

    }
}
