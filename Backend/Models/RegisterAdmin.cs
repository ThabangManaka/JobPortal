using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RegisterAdmin
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }

        public string Position { get; set; }
        [Required]
        public string Password { get; set; }

      //  public byte[] PasswordKey { get; set; }

        public DateTime? CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
