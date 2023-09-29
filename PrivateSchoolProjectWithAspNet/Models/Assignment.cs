using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Models
{
    public class Assignment
    {
        public Assignment()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int AssignmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }

        //Nav Props
        public Course Course { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}