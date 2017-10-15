using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;

namespace Wassy.BLL.Attachment
{
    public class GetAllRelationRequest
    {
        Context db = new Context();
        public RelationResponse GetAll()
        {
            var response = new RelationResponse
            {
                Relations = db.Relations.Select(t => new Responses.Relation
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.Type
                }).ToList()
            };
            return response;
        }
        public RelationFemaleResponse GetAllFemales()
        {
            string female = "Female";
            var response = new RelationFemaleResponse
            {
                RelationFemale = db.Relations.Where(t => t.Type == female.ToString()).Select(t => new Responses.Relation
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.Type
                }).ToList()
            };
            return response;
        }
        public RelationMaleResponse GetAllMales()
        {
            string male = "Male";
            var response = new RelationMaleResponse
            {
                RelationMale = db.Relations.Where(t => t.Type == male.ToString()).Select(t => new Responses.Relation
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.Type
                }).ToList()
            };
            return response;
        }

    }
}
