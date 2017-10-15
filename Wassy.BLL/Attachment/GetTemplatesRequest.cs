using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wassy.DAL.Models;

namespace Wassy.BLL.Attachment
{
    public class GetTemplatesRequest
    {
        Context db = new Context();

        public TemplateResponse GetTemplates ()
        {
            var response = new TemplateResponse
            {
                Templates = db.Templates.Select(t => new Template { wassaya = t.Wassaya_Template ,Id = t.Id}).ToList()
            };
            return response;
        }
    }
}
