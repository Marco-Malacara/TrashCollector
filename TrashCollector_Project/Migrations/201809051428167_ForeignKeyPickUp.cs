namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyPickUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickupId");
            AddForeignKey("dbo.Customers", "PickupId", "dbo.Pickups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupId" });
            DropColumn("dbo.Customers", "PickupId");
        }
    }
}
