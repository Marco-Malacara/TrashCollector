namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Employees", new[] { "PickupId" });
            DropColumn("dbo.Employees", "PickupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PickupId", c => c.Int());
            CreateIndex("dbo.Employees", "PickupId");
            AddForeignKey("dbo.Employees", "PickupId", "dbo.Pickups", "Id");
        }
    }
}
