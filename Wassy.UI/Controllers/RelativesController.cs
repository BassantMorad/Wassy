using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL.Attachment;
using Wassy.BLL.Functions;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/relative")]
    public class RelativesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Relatives
        public IQueryable<Relative> GetRelatives()
        {
            return db.Relatives;
        }
        [HttpGet]
        [Route("")]
        public GetAllRelativeResponse GetAll()
        {
            GetAllRelatives req = new GetAllRelatives();
            return req.getAll();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetRelative(int id)
        {
            try {

                GetUserRelative relative = new GetUserRelative();

                return Ok(relative.getAll(id));
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }
        [HttpPut]
        [Route("")]
        public IHttpActionResult updateRelative(UpdateRelativeRequest req)
        {
            try
            {
                Relative relative = db.Relatives.Find(req.Id);
                if (relative == null)
                    return NotFound();

                relative.Name = req.Name;
                relative.Mobile = req.Mobile;
                relative.Email = req.Email;
                relative.Address = req.Address;
                relative.RelationId = req.RId;
                
                db.SaveChanges();
                return Ok(relative);
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

        
       
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostRelative(Relative relative)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Relatives.Add(relative);
            db.SaveChanges();

            return Ok(relative);
        }

        // DELETE: api/Relatives/5
        [ResponseType(typeof(Relative))]
        [HttpDelete]
        public IHttpActionResult DeleteRelative(int id)
        {
            try
            {
                Relative relative = db.Relatives.Find(id);
                if (relative == null)
                {
                    return NotFound();
                }

                db.Relatives.Remove(relative);
                db.SaveChanges();

                return Ok(relative);
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelativeExists(int id)
        {
            return db.Relatives.Count(e => e.Id == id) > 0;
        }
    }
}