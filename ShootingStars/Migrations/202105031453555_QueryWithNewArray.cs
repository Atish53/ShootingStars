namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueryWithNewArray : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Queries", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queries", "Type", c => c.String(nullable: false));
        }
    }
}
