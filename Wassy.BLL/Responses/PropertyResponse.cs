using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wassy.BLL.Responses
{
    class PropertyResponse
    {

    }
    public class Property
    {
        public string  Description { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public Category PropertyCategory { get; set; }
    }
}
