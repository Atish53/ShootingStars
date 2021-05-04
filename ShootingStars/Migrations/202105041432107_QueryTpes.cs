namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueryTpes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Queries", "QueryTypes", c => c.String(nullable: false));
            DropColumn("dbo.Queries", "QueryType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Queries", "QueryType", c => c.String(nullable: false));
            DropColumn("dbo.Queries", "QueryTypes");
        }
    }
}
