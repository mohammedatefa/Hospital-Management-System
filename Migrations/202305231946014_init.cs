namespace HospitalSystemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Salary = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Department_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .Index(t => t.Department_ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Department_ID = c.Int(),
                        Floor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .ForeignKey("dbo.Floors", t => t.Floor_ID)
                .Index(t => t.Department_ID)
                .Index(t => t.Floor_ID);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfRooms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        PatientName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Doctor_ID = c.Int(),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .ForeignKey("dbo.Rooms", t => t.Room_ID)
                .Index(t => t.Doctor_ID)
                .Index(t => t.Room_ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NationalID = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        BloodType = c.String(),
                        Description = c.String(),
                        Doctor_ID = c.Int(),
                        Room_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .ForeignKey("dbo.Rooms", t => t.Room_ID)
                .Index(t => t.Doctor_ID)
                .Index(t => t.Room_ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        PatientID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                        Paymented = c.Double(nullable: false),
                        Remained = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Salary = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        JopTitle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAdmins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.Patients", "Doctor_ID", "dbo.Doctors");
            DropForeignKey("dbo.Histories", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.Histories", "Doctor_ID", "dbo.Doctors");
            DropForeignKey("dbo.Rooms", "Floor_ID", "dbo.Floors");
            DropForeignKey("dbo.Rooms", "Department_ID", "dbo.Departments");
            DropForeignKey("dbo.Doctors", "Department_ID", "dbo.Departments");
            DropIndex("dbo.Patients", new[] { "Room_ID" });
            DropIndex("dbo.Patients", new[] { "Doctor_ID" });
            DropIndex("dbo.Histories", new[] { "Room_ID" });
            DropIndex("dbo.Histories", new[] { "Doctor_ID" });
            DropIndex("dbo.Rooms", new[] { "Floor_ID" });
            DropIndex("dbo.Rooms", new[] { "Department_ID" });
            DropIndex("dbo.Doctors", new[] { "Department_ID" });
            DropTable("dbo.UserAdmins");
            DropTable("dbo.Staffs");
            DropTable("dbo.Payments");
            DropTable("dbo.Patients");
            DropTable("dbo.Histories");
            DropTable("dbo.Floors");
            DropTable("dbo.Rooms");
            DropTable("dbo.Doctors");
            DropTable("dbo.Departments");
        }
    }
}
