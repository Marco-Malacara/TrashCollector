namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Schedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Schedule", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Schedule");
        }
    }
}
