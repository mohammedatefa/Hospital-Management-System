namespace HospitalSystemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Floor_ID", "dbo.Floors");
            AddColumn("dbo.Rooms", "Floor_ID1", c => c.Int());
            CreateIndex("dbo.Rooms", "Floor_ID1");
            AddForeignKey("dbo.Rooms", "Floor_ID1", "dbo.Floors", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Floor_ID1", "dbo.Floors");
            DropIndex("dbo.Rooms", new[] { "Floor_ID1" });
            DropColumn("dbo.Rooms", "Floor_ID1");
            AddForeignKey("dbo.Rooms", "Floor_ID", "dbo.Floors", "ID");
        }
    }
}
