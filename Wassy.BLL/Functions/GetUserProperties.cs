using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;
using System.Data.Entity;

namespace Wassy.BLL.Functions
{
    public class GetUserProperties
    {
        Context db = new Context();
        public GetAllPropertyResponse getAll(int id)
        {
            var response = new GetAllPropertyResponse
            {
                Properties = db.Properties.Where(r => r.UserId == id).Include(r => r.Category).Select(r => new UserProperties
                {
                    Name = r.Name,
                    Amount = r.Amount,
                    Description = r.Description,
                    Type = r.Category.Type
                }
                ).ToList()
            };

            return response;
        }
    }
}
