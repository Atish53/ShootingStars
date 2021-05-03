namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Query : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Queries", "QueryType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Queries", "QueryType");
        }
    }
}
