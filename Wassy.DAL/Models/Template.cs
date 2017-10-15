using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wassy.DAL.Models
{
    public class Template
    {
        [Key]
        public int Id { get; set; }
        public string Wassaya_Template { get; set; }
    }
}