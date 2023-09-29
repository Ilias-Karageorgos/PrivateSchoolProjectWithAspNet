namespace PrivateSchoolProjectWithAspNet.Migrations
{
    using PrivateSchoolProjectWithAspNet.Enums;
    using PrivateSchoolProjectWithAspNet.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Web.Razor.Generator;

    internal sealed class Configuration : DbMigrationsConfiguration<PrivateSchoolProjectWithAspNet.MyDatabase.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PrivateSchoolProjectWithAspNet.MyDatabase.ApplicationDbContext context)
        {
            #region Student Seeding
            Student s1 = new Student()
            {
                StudentId = 1,
                FirstName = "Kostas",
                LastName = "Papadopoulos",
                DateOfBirth = new DateTime(2000, 04, 15),
                TuitionFees = 5354
            };

            Student s2 = new Student()
            {
                StudentId = 2,
                FirstName = "Giorgos",
                LastName = "Kolias",
                DateOfBirth = new DateTime(2003, 12, 05),
                TuitionFees = 4645
            };

            List<Student> students = new List<Student>() { s1, s2 };
            context.Students.AddRange(students);
            context.SaveChanges();
            #endregion

            #region Course Seeding
            Course c1 = new Course()
            {
                CourseId = 1,
                Title = "Javascript",
                Type = CourseType.PartTime,
                StartDate = new DateTime(2024, 01, 15),
                EndDate = new DateTime(2024, 06, 18)                
            };

            Course c2 = new Course()
            {
                CourseId = 2,
                Title = "C#",
                Type = CourseType.FullTime,
                StartDate = new DateTime(2024, 02, 12),
                EndDate = new DateTime(2024, 10, 15)
            };

            List<Course> courses = new List<Course>() { c1, c2 };
            context.Courses.AddRange(courses);
            context.SaveChanges();
            #endregion
            
            #region Trainer Seeding
            Trainer t1 = new Trainer()
            {
                TrainerId = 1,
                FirstName = "Labros",
                LastName = "Papadimitriou",
                Age = 32
            };

            Trainer t2 = new Trainer()
            {
                TrainerId = 2,
                FirstName = "Stavros",
                LastName = "Gouleas",
                Age = 30
            };

            List<Trainer> trainers = new List<Trainer>() { t1, t2 };
            context.Trainers.AddRange(trainers);
            context.SaveChanges();
            #endregion

            #region Assignment Seeding
            Assignment a1 = new Assignment()
            {
                AssignmentId = 1,
                Title = "Javascript 1",
                Description = "Javascript First Assignment",
                SubDateTime = new DateTime(2024, 01, 15),
                OralMark = 10,
                TotalMark = 20
            };
           
            Assignment a2 = new Assignment()
            {
                AssignmentId = 2,
                Title = "Javascript 2",
                Description = "Javascript Second Assignment",
                SubDateTime = new DateTime(2024, 02, 15),
                OralMark = 20,
                TotalMark = 30
            };
            Assignment a3 = new Assignment()
            {
                AssignmentId = 3,
                Title = "C# 1",
                Description = "C# First Assignment",
                SubDateTime = new DateTime(2024, 01, 15),
                OralMark = 10,
                TotalMark = 20
            };
           
            Assignment a4 = new Assignment()
            {
                AssignmentId = 4,
                Title = "C# 2",
                Description = "C# Second Assignment",
                SubDateTime = new DateTime(2024, 02, 15),
                OralMark = 20,
                TotalMark = 30
            };

            List<Assignment> assignments = new List<Assignment>() { a1, a2, a3, a4 };
            context.Assignments.AddRange(assignments);
            context.SaveChanges();

            #endregion


        }
    }
}
