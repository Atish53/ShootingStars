namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Query : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Queries", "QueryTypes", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Queries", "QueryTypes", c => c.String(nullable: false));
        }
    }
}
