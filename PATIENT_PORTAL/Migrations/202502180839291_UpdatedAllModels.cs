namespace PATIENT_PORTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAllModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PATIENT_CaseInfo", newName: "CaseInfoes");
            RenameTable(name: "dbo.PATIENT_VitalSigns", newName: "VitalSigns");
            DropForeignKey("dbo.PATIENT_HealthRecord", "BMI_Id", "dbo.PATIENT_BMI");
            DropForeignKey("dbo.PATIENT_HealthRecord", "CaseInfoId", "dbo.PATIENT_CaseInfo");
            DropForeignKey("dbo.PATIENT_HealthRecord", "VitalSignsId", "dbo.PATIENT_VitalSigns");
            DropForeignKey("dbo.Patients", "HealthRecordId", "dbo.PATIENT_HealthRecord");
            DropIndex("dbo.PATIENT_HealthRecord", new[] { "CaseInfoId" });
            DropIndex("dbo.PATIENT_HealthRecord", new[] { "VitalSignsId" });
            DropIndex("dbo.PATIENT_HealthRecord", new[] { "BMI_Id" });
            DropIndex("dbo.Patients", new[] { "HealthRecordId" });
            CreateTable(
                "dbo.BMIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HealthRecordId = c.Int(nullable: false),
                        DateChecked = c.DateTime(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HealthRecords", t => t.HealthRecordId, cascadeDelete: true)
                .Index(t => t.HealthRecordId);
            
            CreateTable(
                "dbo.HealthRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            AddColumn("dbo.CaseInfoes", "HealthRecordId", c => c.Int(nullable: false));
            AddColumn("dbo.VitalSigns", "HealthRecordId", c => c.Int(nullable: false));
            CreateIndex("dbo.CaseInfoes", "HealthRecordId");
            CreateIndex("dbo.VitalSigns", "HealthRecordId");
            AddForeignKey("dbo.CaseInfoes", "HealthRecordId", "dbo.HealthRecords", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VitalSigns", "HealthRecordId", "dbo.HealthRecords", "Id", cascadeDelete: true);
            DropColumn("dbo.Patients", "HealthRecordId");
            DropTable("dbo.PATIENT_BMI");
            DropTable("dbo.PATIENT_HealthRecord");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PATIENT_HealthRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaseInfoId = c.Int(),
                        VitalSignsId = c.Int(),
                        BMI_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PATIENT_BMI",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateChecked = c.DateTime(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "HealthRecordId", c => c.Int());
            DropForeignKey("dbo.VitalSigns", "HealthRecordId", "dbo.HealthRecords");
            DropForeignKey("dbo.HealthRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.CaseInfoes", "HealthRecordId", "dbo.HealthRecords");
            DropForeignKey("dbo.BMIs", "HealthRecordId", "dbo.HealthRecords");
            DropIndex("dbo.VitalSigns", new[] { "HealthRecordId" });
            DropIndex("dbo.CaseInfoes", new[] { "HealthRecordId" });
            DropIndex("dbo.HealthRecords", new[] { "PatientId" });
            DropIndex("dbo.BMIs", new[] { "HealthRecordId" });
            DropColumn("dbo.VitalSigns", "HealthRecordId");
            DropColumn("dbo.CaseInfoes", "HealthRecordId");
            DropTable("dbo.HealthRecords");
            DropTable("dbo.BMIs");
            CreateIndex("dbo.Patients", "HealthRecordId");
            CreateIndex("dbo.PATIENT_HealthRecord", "BMI_Id");
            CreateIndex("dbo.PATIENT_HealthRecord", "VitalSignsId");
            CreateIndex("dbo.PATIENT_HealthRecord", "CaseInfoId");
            AddForeignKey("dbo.Patients", "HealthRecordId", "dbo.PATIENT_HealthRecord", "Id");
            AddForeignKey("dbo.PATIENT_HealthRecord", "VitalSignsId", "dbo.PATIENT_VitalSigns", "Id");
            AddForeignKey("dbo.PATIENT_HealthRecord", "CaseInfoId", "dbo.PATIENT_CaseInfo", "Id");
            AddForeignKey("dbo.PATIENT_HealthRecord", "BMI_Id", "dbo.PATIENT_BMI", "Id");
            RenameTable(name: "dbo.VitalSigns", newName: "PATIENT_VitalSigns");
            RenameTable(name: "dbo.CaseInfoes", newName: "PATIENT_CaseInfo");
        }
    }
}
