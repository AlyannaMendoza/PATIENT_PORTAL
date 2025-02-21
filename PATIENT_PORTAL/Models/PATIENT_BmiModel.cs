using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PATIENT_PORTAL.Models
{
    public class BMI
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        public DateTime DateChecked { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(50, 250)]
        public double Height { get; set; }

        [Required]
        [Range(20, 300)]
        public double Weight { get; set; }

        //Converts cm to meters then calculates bmi
        public double BodyMass
        {
            get
            {
                return Height > 0 ? Math.Round(Weight / Math.Pow(Height / 100, 2), 2) : 0;
            }
        } 

        public string Category
        {
            get
            {
                if (BodyMass < 18.5) return "Underweight";
                if (BodyMass < 25) return "Normal weight";
                if (BodyMass < 30) return "Overweight";
                if (BodyMass < 35) return "Obese Class I";
                if (BodyMass < 40) return "Obese Class II";
                return "Obese Class III";
            }
        }
    }
}