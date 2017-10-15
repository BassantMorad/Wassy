using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.BLL.Attachment;
using Wassy.DAL.Models;

namespace Wassy.BLL.Functions
{
    public class UpdateResponsible
    {
        Context db = new Context();
        public Responsible Update(ResponsibleRequest req)
        {
            Responsible responsible = db.Responsibles.Find(req.Id);

            responsible.Name = req.Name;
            responsible.Email = req.Email;

            db.SaveChanges();
            return responsible;
        }
    }
}
