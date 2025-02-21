namespace PATIENT_PORTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePatientAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Age", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Patients", "City", c => c.String(maxLength: 100));
            DropColumn("dbo.Patients", "ProfileImage");
            DropColumn("dbo.Patients", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Country", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Patients", "ProfileImage", c => c.String());
            AlterColumn("dbo.Patients", "City", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Patients", "Age");
        }
    }
}
