using PATIENT_PORTAL.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace PATIENT_PORTAL.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ProfileImageFile { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public SuffixEnum? Suffix { get; set; }

        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [StringLength(100)]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }

        [Required]
        public GenderEnum Sex { get; set; }

        [Required]
        [Display(Name = "Civil Status")]
        public CivilStatusEnum CivilStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Nationality { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact number must be 11 digits and start with 09!")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Invalid phone number format.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Province { get; set; }

        [Required]
        [StringLength(50)]
        public string Region { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }
        
        [StringLength(10)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public int? HealthRecordId { get; set; }
        [ForeignKey("HealthRecordId")]
        public virtual PATIENT_HealthRecord PATIENT_HealthRecord { get; set; }

        public bool IsActive { get; set; } = true;
        
    }
}