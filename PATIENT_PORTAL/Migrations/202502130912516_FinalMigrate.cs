namespace PATIENT_PORTAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigrate : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.PATIENT_CaseInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaseNumber = c.String(nullable: false, maxLength: 50),
                        DateCreated = c.DateTime(nullable: false),
                        AttendingPhysician = c.String(nullable: false, maxLength: 100),
                        Diagnosis = c.String(nullable: false, maxLength: 500),
                        SignsSymptoms = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PATIENT_HealthRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaseInfoId = c.Int(),
                        VitalSignsId = c.Int(),
                        BMI_Id = c.Int(),
                        PATIENT_BMI_Id = c.Int(),
                        PATIENT_CaseInfo_Id = c.Int(),
                        PATIENT_VitalSigns_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PATIENT_BMI", t => t.PATIENT_BMI_Id)
                .ForeignKey("dbo.PATIENT_CaseInfo", t => t.PATIENT_CaseInfo_Id)
                .ForeignKey("dbo.PATIENT_VitalSigns", t => t.PATIENT_VitalSigns_Id)
                .Index(t => t.PATIENT_BMI_Id)
                .Index(t => t.PATIENT_CaseInfo_Id)
                .Index(t => t.PATIENT_VitalSigns_Id);
            
            CreateTable(
                "dbo.PATIENT_VitalSigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateChecked = c.DateTime(nullable: false),
                        BloodPressure = c.String(nullable: false, maxLength: 10),
                        Temperature = c.Double(nullable: false),
                        PulseRate = c.Int(nullable: false),
                        RespiratoryRate = c.Int(nullable: false),
                        OxygenSaturation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileImage = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Suffix = c.Int(nullable: false),
                        BloodType = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(maxLength: 100),
                        Sex = c.Int(nullable: false),
                        CivilStatus = c.Int(nullable: false),
                        Nationality = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(nullable: false, maxLength: 11),
                        StreetAddress = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        Province = c.String(nullable: false, maxLength: 50),
                        Region = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 100),
                        ZipCode = c.String(maxLength: 10),
                        HealthRecordId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PATIENT_HealthRecord", t => t.HealthRecordId)
                .Index(t => t.HealthRecordId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Patients", "HealthRecordId", "dbo.PATIENT_HealthRecord");
            DropForeignKey("dbo.PATIENT_HealthRecord", "PATIENT_VitalSigns_Id", "dbo.PATIENT_VitalSigns");
            DropForeignKey("dbo.PATIENT_HealthRecord", "PATIENT_CaseInfo_Id", "dbo.PATIENT_CaseInfo");
            DropForeignKey("dbo.PATIENT_HealthRecord", "PATIENT_BMI_Id", "dbo.PATIENT_BMI");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Patients", new[] { "HealthRecordId" });
            DropIndex("dbo.PATIENT_HealthRecord", new[] { "PATIENT_VitalSigns_Id" });
            DropIndex("dbo.PATIENT_HealthRecord", new[] { "PATIENT_CaseInfo_Id" });
            DropIndex("dbo.PATIENT_HealthRecord", new[] { "PATIENT_BMI_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Patients");
            DropTable("dbo.PATIENT_VitalSigns");
            DropTable("dbo.PATIENT_HealthRecord");
            DropTable("dbo.PATIENT_CaseInfo");
            DropTable("dbo.PATIENT_BMI");
        }
    }
}
