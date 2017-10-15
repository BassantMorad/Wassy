using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.BLL.Attachment;
using Wassy.DAL.Models;

namespace Wassy.BLL.Functions
{
    public class UpdateProperty
    {
        Context db = new Context();
        public Property Update(UpdatePropertyRequest req)
        {
            Property property = db.Properties.Find(req.Id);

            property.Name = req.Name;
            property.Amount = req.Amount;
            property.Description = req.Description;
            property.CategoryId = req.CategoryId;
            
            db.SaveChanges();
            return property;
        }
    }
}
