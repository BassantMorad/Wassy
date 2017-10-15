using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.DAL.Models;

namespace Wassy.BLL.Responses
{
    public class Responsible
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class GetAllResponsibleResponse
    {
        
        
            Context _db = new Context();
            public List<Responsible> responsible { get; set; }
        
    }
}
