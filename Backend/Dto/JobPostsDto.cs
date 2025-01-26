using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Dto
{
    public class JobPostsDto
    {

        public string PostName { get; set; }
        public string JobDescription { get; set; }
        public int BusinessUnitID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public int ExperienceID { get; set; }
        public int QualificationID { get; set; }
        public bool DriversLicenseRequired { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

    }
}
