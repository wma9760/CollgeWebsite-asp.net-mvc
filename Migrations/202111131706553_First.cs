namespace CollgeWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Name = c.String(),
                        E_mail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        Course_CreditHours = c.String(),
                        Course_Semester = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Dp_Code = c.String(),
                        Dp_Name = c.String(),
                        Dp_Description = c.String(),
                        Dp_Image = c.String(),
                        Courses_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.Courses_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Courses_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        TeacherAddress = c.String(),
                        TeacherPhone = c.String(),
                        TeacherEmail = c.String(),
                        Designantion = c.String(),
                        Credits = c.String(),
                        image = c.String(),
                        Courses_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Courses_Id)
                .Index(t => t.Courses_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Event_Name = c.String(),
                        Event_Date = c.String(),
                        Event_Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Name = c.String(),
                        FeedBack = c.String(),
                        Reply = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.Departments", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Departments", "Courses_Id", "dbo.Courses");
            DropIndex("dbo.Teachers", new[] { "Courses_Id" });
            DropIndex("dbo.Departments", new[] { "Teacher_Id" });
            DropIndex("dbo.Departments", new[] { "Courses_Id" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Events");
            DropTable("dbo.Teachers");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Admins");
        }
    }
}
