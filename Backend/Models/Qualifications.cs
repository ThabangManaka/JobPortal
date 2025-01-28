using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Qualifications
    {
        [Key]
        public int QualificationID { get; set; }
        public string QualificationName { get; set; }
    }
}
