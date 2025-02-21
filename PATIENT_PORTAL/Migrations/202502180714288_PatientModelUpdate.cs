namespace PATIENT_PORTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Region", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
