using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BusinessUnit
    {
        [Key]
        public int BusinessUnitID { get; set; }
        public string BusinessUnitName { get; set; }
    }
}
