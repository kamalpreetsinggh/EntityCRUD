namespace EntityCRUDApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kamapreet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Course_CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Course_CourseID" });
            RenameColumn(table: "dbo.Students", name: "Course_CourseID", newName: "CourseID");
            AddColumn("dbo.Students", "StudentGender", c => c.String());
            AddColumn("dbo.Students", "StudentAge", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "CourseID", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CourseID");
            AddForeignKey("dbo.Students", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
            DropColumn("dbo.Students", "DateOfBirth");
            DropColumn("dbo.Students", "Gender");
            DropColumn("dbo.Students", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Gender", c => c.String());
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Students", "CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseID" });
            AlterColumn("dbo.Students", "CourseID", c => c.Int());
            DropColumn("dbo.Students", "StudentAge");
            DropColumn("dbo.Students", "StudentGender");
            RenameColumn(table: "dbo.Students", name: "CourseID", newName: "Course_CourseID");
            CreateIndex("dbo.Students", "Course_CourseID");
            AddForeignKey("dbo.Students", "Course_CourseID", "dbo.Courses", "CourseID");
        }
    }
}
