using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PATIENT_PORTAL.Models
{
    public class PATIENT_BMI
    {
        public int Id { get; set; }

        public DateTime DateChecked { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(50, 250)]
        public double Height { get; set; }

        [Required]
        [Range(20, 300)]
        public double Weight { get; set; }

        //Converts cm to meters then calculates bmi
        public double BMI => Height > 0 ? Math.Round(Weight / Math.Pow(Height / 100, 2), 2) : 0;

        public string Category
        {
            get
            {
                if (BMI < 18.5) return "Underweight";
                if (BMI < 25) return "Normal weight";
                if (BMI < 30) return "Overweight";
                if (BMI < 35) return "Obese Class I";
                if (BMI < 40) return "Obese Class II";
                return "Obese Class III";
            }
        }
    }
}