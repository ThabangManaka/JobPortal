using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobPosts
    {
        [Key]
        public int PostID { get; set; }

        public string  PostName { get; set; }

        public string JobDescription { get; set; }

        public string ManagerName { get; set; }

        public string  ManagerEmail { get; set; }

        public bool DriversLicenseRequired { get; set; }

        public  DateTime OpeningDate { get; set; }

        public DateTime ClosingDate { get; set; }

        [Required]
        public int BusinessUnitID { get; set; }

        [ForeignKey("BusinessUnitID")]
        public BusinessUnit BusinessUnit { get; set; } // Navigation Property

        [Required]
        public int ExperienceID { get; set; }

        [ForeignKey("ExperienceID")]
        public ExperienceYears Experience { get; set; } // Navigation Property

        [Required]
        public int QualificationID { get; set; }

        [ForeignKey("QualificationID")]
        public Qualifications Qualification { get; set; } // Navigation Property
    }
}
