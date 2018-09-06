namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpickupfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            AddColumn("dbo.Employees", "PickupId", c => c.Int());
            CreateIndex("dbo.Employees", "PickupId");
            AddForeignKey("dbo.Employees", "PickupId", "dbo.Pickups", "Id");
            DropColumn("dbo.Employees", "FristName");
            DropColumn("dbo.Employees", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "FristName", c => c.String());
            DropForeignKey("dbo.Employees", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Employees", new[] { "PickupId" });
            DropColumn("dbo.Employees", "PickupId");
            DropColumn("dbo.Employees", "Name");
        }
    }
}
