using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;
using Wassy.BLL.Attachment;

namespace Wassy.BLL.Functions
{
    public class GetUserRelative
    {
        Context db = new Context();
        public GetAllRelativeResponse getAll(int id)
        {
            var response = new GetAllRelativeResponse
            {
                // relatives = db.Relatives.Include
                relatives = db.Relatives.Where(r => r.UserId == id).Include(r => r.Relation).Select(r => new Relativess
                {
                    Name = r.Name,
                    Type = r.Relation.Type,
                    Percentage = r.Relation.Percentage
                }).ToList()
                // relatives= db.Relatives.Include(r=> r.Relation).Select(r=>new Result {Name= r.RName, Type = r.Relate.Type, Precentage =r.Relate.DefaultPrecentage}).ToList()
            };
            if (response == null)
                return null;
            return response;
        }
    }
}
