namespace ApiDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleterequiredfromToken : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Token", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Token", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
