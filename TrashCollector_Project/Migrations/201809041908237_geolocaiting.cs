namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geolocaiting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "State");
        }
    }
}
