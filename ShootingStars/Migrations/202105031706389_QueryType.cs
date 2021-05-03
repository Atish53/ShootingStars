namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueryType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Queries", "QueryType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Queries", "QueryType", c => c.Int(nullable: false));
        }
    }
}
