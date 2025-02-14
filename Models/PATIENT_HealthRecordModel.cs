using System.ComponentModel.DataAnnotations.Schema;

namespace PATIENT_PORTAL.Models
{
    public class PATIENT_HealthRecord
    {
        public int Id { get; set; }

        public  int? CaseInfoId { get; set; }
        [ForeignKey("CaseInfoId")]
        public virtual PATIENT_CaseInfo PATIENT_CaseInfo { get; set; }

        public int? VitalSignsId { get; set; }
        [ForeignKey("VitalSignsId")]
        public virtual PATIENT_VitalSigns PATIENT_VitalSigns { get; set; }

        public int? BMI_Id { get; set; }
        [ForeignKey("BMI_Id")]
        public virtual PATIENT_BMI PATIENT_BMI { get; set; }
    }
}