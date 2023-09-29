using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Models
{
    public class Trainer
    {
        public Trainer()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int TrainerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
                
        //Nav Props
        public ICollection<Course> Courses { get; set; }
    }
}