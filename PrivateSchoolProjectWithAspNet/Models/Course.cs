using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PrivateSchoolProjectWithAspNet.Enums;

namespace PrivateSchoolProjectWithAspNet.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Assignments = new HashSet<Assignment>();
            Trainers = new HashSet<Trainer>();
        }

        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public CourseType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }                

        //Nav Props
        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
    }
}