namespace ShootingStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectsDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        SubjectGrade = c.Int(nullable: false),
                        SubjectDescription = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.SubjectMaterials",
                c => new
                    {
                        SubjectMaterialID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        MaterialFile = c.String(),
                        MaterialName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectMaterialID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        TeacherEmail = c.String(),
                        TeacherPhoneNo = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            DropTable("dbo.English4");
            DropTable("dbo.English5");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.English5",
                c => new
                    {
                        English5Id = c.String(nullable: false, maxLength: 128),
                        English5title = c.String(),
                        English5Descr = c.String(),
                        English5Doc = c.String(),
                        English5Image = c.String(),
                        English5Teacher = c.String(),
                        English5TeacherImg = c.String(),
                    })
                .PrimaryKey(t => t.English5Id);
            
            CreateTable(
                "dbo.English4",
                c => new
                    {
                        English4Id = c.String(nullable: false, maxLength: 128),
                        English4title = c.String(),
                        English4Descr = c.String(),
                        English4Doc = c.String(),
                        English4Image = c.String(),
                        English4Teacher = c.String(),
                        English4TeacherImg = c.String(),
                    })
                .PrimaryKey(t => t.English4Id);
            
            DropForeignKey("dbo.Subjects", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.SubjectMaterials", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.SubjectMaterials", new[] { "SubjectID" });
            DropIndex("dbo.Subjects", new[] { "TeacherID" });
            DropTable("dbo.Teachers");
            DropTable("dbo.SubjectMaterials");
            DropTable("dbo.Subjects");
        }
    }
}
