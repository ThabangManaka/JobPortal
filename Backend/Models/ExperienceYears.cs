﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExperienceYears
    {
        [Key]
        public int ExperienceID { get; set; }
        public string ExperienceDescription { get; set; }
    }
}
