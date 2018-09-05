namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickUpForeignKeyFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            AlterColumn("dbo.Customers", "PickupId", c => c.Int());
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            AlterColumn("dbo.Customers", "PickupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id", cascadeDelete: true);
        }
    }
}
