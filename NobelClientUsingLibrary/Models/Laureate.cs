using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelClientUsingLibrary.Models
{
    public class Laureate
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string BornCountry { get; set; }
        public string BornCountryCode { get; set; }
        public string BornCity { get; set; }
        public string DiedCountry { get; set; }
        public string DiedCountryCode { get; set; }
        public string DiedCity { get; set; }
        public string Gender { get; set; }
        public List<Prize> Prizes { get; set; }

    }
}
