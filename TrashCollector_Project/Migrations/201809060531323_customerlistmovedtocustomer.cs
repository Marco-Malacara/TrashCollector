namespace TrashCollector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerlistmovedtocustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Customers", new[] { "Employee_Id" });
            AddColumn("dbo.Customers", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Customer_Id");
            AddForeignKey("dbo.Customers", "Customer_Id", "dbo.Customers", "Id");
            DropColumn("dbo.Customers", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Employee_Id", c => c.Int());
            DropForeignKey("dbo.Customers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Customers", new[] { "Customer_Id" });
            DropColumn("dbo.Customers", "Customer_Id");
            CreateIndex("dbo.Customers", "Employee_Id");
            AddForeignKey("dbo.Customers", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
