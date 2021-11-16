using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static CollgeWebsite.Models.Teacher;

namespace CollgeWebsite.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("CollegeDb")
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }


    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Dp_Code { get; set; }
        public string Dp_Name { get; set; }
        public string Dp_Description { get; set; }
        public string Dp_Image { get; set; }

    }
    public class Teacher
    {
        public static object Departments { get; internal set; }
        [Key]
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public string Designantion { get; set; }
        public string Credits { get; set; }
        public string image { get; set; }
        public ICollection<Department> Department { get; set; }
    }
        public class Courses
        {
            [Key]
            public int Id { get; set; }
            public string CourseCode { get; set; }
            public string CourseName { get; set; }
            public string Course_CreditHours { get; set; }
            public ICollection<Department> Course_Department { get; set; }
            public ICollection<Teacher> Course_Teacher { get; set; }
            public string Course_Semester { get; set; }

        }

        public class Event
        {
            [Key]
            public int Id { get; set; }
            public string Event_Name { get; set; }
            public string Event_Date { get; set; }
            public string Event_Description { get; set; }

        }
        public class Feedback
        {
            [Key]
            public int Id { get; set; }
            public string User_Name { get; set; }
            public string FeedBack { get; set; }
            public string Reply { get; set; }

        }

        public class Admin
        {
            [Key]
            public int Id { get; set; }
            public string User_Name { get; set; }
            public string E_mail { get; set; }
            public string Password { get; set; }

        }
    }

