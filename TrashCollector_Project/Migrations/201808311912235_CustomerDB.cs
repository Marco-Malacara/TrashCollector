namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            DropColumn("dbo.Customers", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Adress", c => c.String());
            DropColumn("dbo.Customers", "Address");
        }
    }
}
