using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL;
using Wassy.BLL.Attachment;
using Wassy.DAL.Models;
using Wassy.UI.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/template")]
    public class TemplateController : ApiController
    {
        
        private Context db = new Context();

        [HttpGet]
        [Route("")]
        public TemplateResponse GetTemplates()
        {
            GetTemplatesRequest req = new GetTemplatesRequest();
            return  req.GetTemplates();
        }

        [HttpGet]
        [ResponseType(typeof(DAL.Models.Template))]
        public IHttpActionResult GetTemplate(int id)
        {
            try
            {
                DAL.Models.Template template = db.Templates.Find(id);
                if (template == null)
                {
                    return NotFound();
                }

                return Ok(template.Wassaya_Template);
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateTemplate(RequestTemplate Request)
        {
            try
            {
                DAL.Models.Template template = new DAL.Models.Template();
                template.Wassaya_Template = Request.wassaya;
                db.Templates.Add(template);
                db.SaveChanges();
                return Ok(template);
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
            
        }
    }
}
