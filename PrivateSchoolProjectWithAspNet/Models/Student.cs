using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TuitionFees { get; set; }
               
        //Nav Props
        public ICollection<Course> Courses { get; set; }
    }
}