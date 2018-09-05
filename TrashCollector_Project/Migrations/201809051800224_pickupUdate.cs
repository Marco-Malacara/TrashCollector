namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickupUdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SpecialPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "SpecialPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "StartPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "EndPickUp", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "EndPickUp");
            DropColumn("dbo.Pickups", "StartPickUp");
            DropColumn("dbo.Pickups", "SpecialPickUp");
            DropColumn("dbo.Customers", "SpecialPickUp");
        }
    }
}
