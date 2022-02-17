namespace ApiDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Employees", "Token", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Token", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "Password", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Employees", "Surname", c => c.String(maxLength: 150));
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 250));
        }
    }
}
