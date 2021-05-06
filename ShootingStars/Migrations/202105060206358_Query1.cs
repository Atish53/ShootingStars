namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Query1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Queries", "QueryTypes", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Queries", "QueryTypes", c => c.String());
        }
    }
}
