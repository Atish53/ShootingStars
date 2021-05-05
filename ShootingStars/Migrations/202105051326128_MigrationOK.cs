namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationOK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        QuestionAnswerID = c.Int(nullable: false, identity: true),
                        QuizID = c.Int(nullable: false),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.QuestionAnswerID)
                .ForeignKey("dbo.Quizs", t => t.QuizID, cascadeDelete: true)
                .Index(t => t.QuizID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswers", "QuizID", "dbo.Quizs");
            DropIndex("dbo.QuestionAnswers", new[] { "QuizID" });
            DropTable("dbo.QuestionAnswers");
        }
    }
}
