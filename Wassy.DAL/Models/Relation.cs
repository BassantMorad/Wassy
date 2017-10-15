using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.DAL.Models;

namespace Wassy.DAL.Models
{
    public class Relation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Percentage { get; set; }
        public virtual List<Relative> Relatives { get; set; }
    }
}
