using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PATIENT_PORTAL.Models
{
    public class CaseInfo
    {
        public  int Id { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Case Number")]
        public string CaseNumber { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Attending Physician")]
        public string AttendingPhysician { get; set; }

        [StringLength(500)]
        [Display(Name = "Signs and Symptoms")]
        public string SignsSymptoms { get; set; }

        [Required]
        [StringLength(500)]
        public string Diagnosis { get; set; }
    }
}