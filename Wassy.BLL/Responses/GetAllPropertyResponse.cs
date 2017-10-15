using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.DAL.Models;

namespace Wassy.BLL.Responses
{
    public class UserProperties
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Type  { get; set; }
    }
    public class GetAllPropertyResponse
    {
        Context _db = new Context();
        public List<UserProperties> Properties { get; set; }
    }
}
