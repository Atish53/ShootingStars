namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question1 = c.String(nullable: false),
                        Question2 = c.String(nullable: false),
                        Question3 = c.String(nullable: false),
                        Question4 = c.String(nullable: false),
                        Question5 = c.String(nullable: false),
                        Question6 = c.String(nullable: false),
                        Question7 = c.String(nullable: false),
                        Question8 = c.String(nullable: false),
                        Question9 = c.String(nullable: false),
                        Question10 = c.String(),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectReviews", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.SubjectReviews", new[] { "SubjectID" });
            DropTable("dbo.SubjectReviews");
        }
    }
}
