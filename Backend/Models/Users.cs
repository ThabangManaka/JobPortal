using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Users
    {

        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public byte[] PasswordSalt { get; set; }
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string CellphoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string PostalCode { get; set; }
        public string CVFilePath { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int ProvinceID { get; set; }
        [ForeignKey("ProvinceID")]
        public Provinces Province { get; set; }

    }
}
