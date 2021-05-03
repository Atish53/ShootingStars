namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "SubjectImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "SubjectImg");
        }
    }
}
