using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wassy.BLL.Attachment
{
    public class UpdatePropertyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
