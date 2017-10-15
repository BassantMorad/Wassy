using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wassy.DAL.Models
{
    public class User
    {
        public User()
        {
            Properties = new List<Property>();
            Relatives = new List<Relative>();
            Responsible = new List<Models.Responsible>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
      //  [RegularExpression("^((?=.*[a-z])(?=.*[A-Z])(?=.*\\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string Wassaya { get; set; }
        public virtual List<Property> Properties { get; set; }
        public virtual List<Responsible> Responsible { get; set; }
        public virtual List<Relative> Relatives { get; set; }


    }
}