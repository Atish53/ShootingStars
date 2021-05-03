namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grade = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Q1 = c.String(),
                        Q2 = c.String(),
                        Q3 = c.String(),
                        Q4 = c.String(),
                        Q5 = c.String(),
                        Q6 = c.String(),
                        Q7 = c.String(),
                        Q8 = c.String(),
                        Q9 = c.String(),
                        Q10 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeacherReviews");
        }
    }
}
