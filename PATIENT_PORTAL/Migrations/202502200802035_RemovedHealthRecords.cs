namespace PATIENT_PORTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedHealthRecords : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BMIs", "HealthRecordId", "dbo.HealthRecords");
            DropForeignKey("dbo.CaseInfoes", "HealthRecordId", "dbo.HealthRecords");
            DropForeignKey("dbo.HealthRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.VitalSigns", "HealthRecordId", "dbo.HealthRecords");
            DropIndex("dbo.BMIs", new[] { "HealthRecordId" });
            DropIndex("dbo.HealthRecords", new[] { "PatientId" });
            DropIndex("dbo.CaseInfoes", new[] { "HealthRecordId" });
            DropIndex("dbo.VitalSigns", new[] { "HealthRecordId" });
            AddColumn("dbo.BMIs", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.CaseInfoes", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.VitalSigns", "PatientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "City", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.BMIs", "PatientId");
            CreateIndex("dbo.CaseInfoes", "PatientId");
            CreateIndex("dbo.VitalSigns", "PatientId");
            AddForeignKey("dbo.BMIs", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CaseInfoes", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VitalSigns", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            DropColumn("dbo.BMIs", "HealthRecordId");
            DropColumn("dbo.CaseInfoes", "HealthRecordId");
            DropColumn("dbo.Patients", "Age");
            DropColumn("dbo.VitalSigns", "HealthRecordId");
            DropTable("dbo.HealthRecords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HealthRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VitalSigns", "HealthRecordId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "Age", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.CaseInfoes", "HealthRecordId", c => c.Int(nullable: false));
            AddColumn("dbo.BMIs", "HealthRecordId", c => c.Int(nullable: false));
            DropForeignKey("dbo.VitalSigns", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.CaseInfoes", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.BMIs", "PatientId", "dbo.Patients");
            DropIndex("dbo.VitalSigns", new[] { "PatientId" });
            DropIndex("dbo.CaseInfoes", new[] { "PatientId" });
            DropIndex("dbo.BMIs", new[] { "PatientId" });
            AlterColumn("dbo.Patients", "City", c => c.String(maxLength: 100));
            DropColumn("dbo.VitalSigns", "PatientId");
            DropColumn("dbo.CaseInfoes", "PatientId");
            DropColumn("dbo.BMIs", "PatientId");
            CreateIndex("dbo.VitalSigns", "HealthRecordId");
            CreateIndex("dbo.CaseInfoes", "HealthRecordId");
            CreateIndex("dbo.HealthRecords", "PatientId");
            CreateIndex("dbo.BMIs", "HealthRecordId");
            AddForeignKey("dbo.VitalSigns", "HealthRecordId", "dbo.HealthRecords", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HealthRecords", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CaseInfoes", "HealthRecordId", "dbo.HealthRecords", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BMIs", "HealthRecordId", "dbo.HealthRecords", "Id", cascadeDelete: true);
        }
    }
}
