namespace HospitalSystemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        SupplierName = c.String(),
                        SupplierPhone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicalHistories",
                c => new
                    {
                        MedicalHistoryID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        PatientName = c.String(),
                        Diagnosis = c.String(),
                        Treatment = c.String(),
                        Medication = c.String(),
                        OtherDetails = c.String(),
                    })
                .PrimaryKey(t => t.MedicalHistoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedicalHistories");
            DropTable("dbo.Inventories");
        }
    }
}
