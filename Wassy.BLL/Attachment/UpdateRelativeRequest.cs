using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wassy.BLL.Attachment
{
    public class UpdateRelativeRequest
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int RId { get; set; }
        public int Id { get; set; }

    }
}
