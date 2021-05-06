namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewClone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentQuizs", "DateAttempted", c => c.DateTime(nullable: false));
            DropColumn("dbo.StudentQuizs", "StartTime");
            DropColumn("dbo.StudentQuizs", "EndTime");
            DropColumn("dbo.StudentQuizs", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentQuizs", "Duration", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentQuizs", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentQuizs", "StartTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.StudentQuizs", "DateAttempted");
        }
    }
}
