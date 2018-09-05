namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickupForMonth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "WeekOne", c => c.DateTime());
            AddColumn("dbo.Pickups", "WeekTwo", c => c.DateTime());
            AddColumn("dbo.Pickups", "WeekThree", c => c.DateTime());
            AddColumn("dbo.Pickups", "WeekFour", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "WeekFour");
            DropColumn("dbo.Pickups", "WeekThree");
            DropColumn("dbo.Pickups", "WeekTwo");
            DropColumn("dbo.Pickups", "WeekOne");
        }
    }
}
