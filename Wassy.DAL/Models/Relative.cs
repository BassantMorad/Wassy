using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Wassy.DAL.Models;

namespace Wassy.DAL.Models
{
    public class Relative
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int RelationId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("RelationId")]
        public Relation Relation { get; set; }
    }
}