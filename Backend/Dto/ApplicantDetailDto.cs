using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ApplicantDetailDto
    {
        public bool DriversLicense { get; set; }
        public string CurrentPosition { get; set; }
        public string Company { get; set; }
        public decimal? CurrentAnnualSalary { get; set; }
        public string PreviousPosition { get; set; }
        public string PreviousCompany { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public int PostID { get; set; }   
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
