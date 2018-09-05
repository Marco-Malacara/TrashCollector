namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debtproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Debt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Debt");
        }
    }
}
