using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicantDetail
    {

        [Key]  
        public int ApplicantDetailID { get; set; }

        public bool DriversLicense { get; set; } 

        [Required] 
        [MaxLength(20)]  

        public string CurrentPosition { get; set; }

        [Required]  
        [MaxLength(20)]  
  
        public string Company { get; set; }

        [Column(TypeName = "decimal(10,2)")]  
        public decimal? CurrentAnnualSalary { get; set; }  

        [MaxLength(20)] 
        public string PreviousPosition { get; set; }

        [MaxLength(20)]  
        public string PreviousCompany { get; set; }

        public DateTime? PeriodFrom { get; set; }  
        public DateTime? PeriodTo { get; set; }

        public int PostID { get; set; }
        [ForeignKey("PostID")]
        public JobPosts JobPosts { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
