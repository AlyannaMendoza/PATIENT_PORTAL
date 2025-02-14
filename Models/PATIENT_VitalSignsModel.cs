using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PATIENT_PORTAL.Models
{
    public class PATIENT_VitalSigns
    {
        public int Id { get; set; }

        public DateTime DateChecked { get; set; }

        [Required]
        [StringLength(10)]
        public string BloodPressure { get; set; }

        [Required]
        [Range(30, 45)]
        public double Temperature { get; set; }

        [Required]
        [Range(40, 150)]
        public int PulseRate { get; set; }

        [Required]
        [Range(10, 40)]
        public int RespiratoryRate { get; set; }

        [Required]
        [Range(60, 100)]
        public int OxygenSaturation { get; set; }
    }
}