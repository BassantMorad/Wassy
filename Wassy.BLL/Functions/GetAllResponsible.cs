using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;

namespace Wassy.BLL.Functions
{
    public class GetAllResponsible
    {
        Context db = new Context();

        public GetAllResponsibleResponse getAll(int id)
        {
            var response = new GetAllResponsibleResponse
            {
                // relatives = db.Relatives.Include
                responsible = db.Responsibles.Where(r => r.Id == id).Select(r => new Responses.Responsible
                {
                    Name = r.Name,
                    Email = r.Email
                }).ToList()
                // relatives= db.Relatives.Include(r=> r.Relation).Select(r=>new Result {Name= r.RName, Type = r.Relate.Type, Precentage =r.Relate.DefaultPrecentage}).ToList()
            };
            if (response == null)
                return null;
            return response;
        }

    }
}
