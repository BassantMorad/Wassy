using System.Linq;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;

namespace Wassy.BLL.Attachment
{
    public class GetAllCategoriesRequest
    {
        Context db = new Context();
        public int Id { get; set; }
        public string Type { get; set; }

        public CategoryResponse GetAll()
        {
            var response = new CategoryResponse
            {
                Categories = db.Categoriess.Select(t => new Responses.Category { Id = t.Id , Type = t.Type}).ToList()
            };
            return response;
        }
    }
}
