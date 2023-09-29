using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelClientUsingLibrary.Models
{
    public class Prize
    {
        public string Category { get; set; }
        public string Year { get; set; }
        public string Share { get; set; }
        public string Motivation { get; set; }
        public List<Affiliation> Affiliations { get; set; }
    }
}
