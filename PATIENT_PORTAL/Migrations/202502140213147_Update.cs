namespace PATIENT_PORTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PATIENT_HealthRecord", "BMI_Id");
            DropColumn("dbo.PATIENT_HealthRecord", "CaseInfoId");
            DropColumn("dbo.PATIENT_HealthRecord", "VitalSignsId");
            RenameColumn(table: "dbo.PATIENT_HealthRecord", name: "PATIENT_BMI_Id", newName: "BMI_Id");
            RenameColumn(table: "dbo.PATIENT_HealthRecord", name: "PATIENT_CaseInfo_Id", newName: "CaseInfoId");
            RenameColumn(table: "dbo.PATIENT_HealthRecord", name: "PATIENT_VitalSigns_Id", newName: "VitalSignsId");
            RenameIndex(table: "dbo.PATIENT_HealthRecord", name: "IX_PATIENT_CaseInfo_Id", newName: "IX_CaseInfoId");
            RenameIndex(table: "dbo.PATIENT_HealthRecord", name: "IX_PATIENT_VitalSigns_Id", newName: "IX_VitalSignsId");
            RenameIndex(table: "dbo.PATIENT_HealthRecord", name: "IX_PATIENT_BMI_Id", newName: "IX_BMI_Id");
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AlterColumn("dbo.Patients", "Suffix", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Suffix", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "ProfileImage");
            RenameIndex(table: "dbo.PATIENT_HealthRecord", name: "IX_BMI_Id", newName: "IX_PATIENT_BMI_Id");
            RenameIndex(table: "dbo.PATIENT_HealthRecord", name: "IX_VitalSignsId", newName: "IX_PATIENT_VitalSigns_Id");
            RenameIndex(table: "dbo.PATIENT_HealthRecord", name: "IX_CaseInfoId", newName: "IX_PATIENT_CaseInfo_Id");
            RenameColumn(table: "dbo.PATIENT_HealthRecord", name: "VitalSignsId", newName: "PATIENT_VitalSigns_Id");
            RenameColumn(table: "dbo.PATIENT_HealthRecord", name: "CaseInfoId", newName: "PATIENT_CaseInfo_Id");
            RenameColumn(table: "dbo.PATIENT_HealthRecord", name: "BMI_Id", newName: "PATIENT_BMI_Id");
            AddColumn("dbo.PATIENT_HealthRecord", "VitalSignsId", c => c.Int());
            AddColumn("dbo.PATIENT_HealthRecord", "CaseInfoId", c => c.Int());
            AddColumn("dbo.PATIENT_HealthRecord", "BMI_Id", c => c.Int());
        }
    }
}
