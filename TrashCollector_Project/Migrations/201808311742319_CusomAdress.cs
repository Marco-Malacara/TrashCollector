namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CusomAdress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Adress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Adress");
        }
    }
}
