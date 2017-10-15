using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wassy.BLL.Responses
{
    public class CategoryResponse
    {
        public List<Category> Categories { get; set; } = new List<Category>();
    }
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
