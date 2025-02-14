using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PATIENT_PORTAL.Models
{
    public class PATIENT_PORTALContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PATIENT_PORTALContext() : base("name=PATIENT_PORTALContext")
        {
        }

        public System.Data.Entity.DbSet<PATIENT_PORTAL.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<PATIENT_PORTAL.Models.PATIENT_HealthRecord> PATIENT_HealthRecord { get; set; }
    }
}
