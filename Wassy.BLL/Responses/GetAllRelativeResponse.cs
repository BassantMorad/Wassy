using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.DAL.Models;

namespace Wassy.BLL.Responses
{
   
    public class Relativess
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Percentage { get; set; }
    }
    public class GetAllRelativeResponse
    {
        Context _db = new Context();
        public List<Relativess> relatives { get; set; }
    }
}
