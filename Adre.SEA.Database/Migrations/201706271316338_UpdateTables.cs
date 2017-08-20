namespace Adre.SEA.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "DOB", c => c.DateTime());
            DropColumn("dbo.Athletes", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athletes", "Weight", c => c.Single(nullable: false));
            DropColumn("dbo.Athletes", "DOB");
        }
    }
}
