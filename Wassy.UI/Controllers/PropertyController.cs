using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL.Attachment;
using Wassy.BLL.Functions;
using Wassy.DAL.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/property")]
    public class PropertyController : ApiController
    {
        private Context db = new Context();

        // GET: api/Property
        public IQueryable<DAL.Models.Property> GetProperties()
        {
            return db.Properties;
        }

        // GET: api/Property/5
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetAllProperty(int id)
        {
            try
            {
                GetUserProperties p = new GetUserProperties();
                return Ok(p.getAll(id));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        // PUT: api/Property/5
        [ResponseType(typeof(void))]
        //when I update property , will i take Id from Developer
        [HttpPut]
        [Route("")]
        public IHttpActionResult PutProperty(UpdatePropertyRequest req)
        {
            try
            {
                DAL.Models.Property property = db.Properties.Find(req.Id);
                if (property == null)
                    return NotFound();
                UpdateProperty update = new UpdateProperty();
                return Ok(update.Update(req));
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }

        [Route("")]
        public IHttpActionResult PostProperty(DAL.Models.Property property)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Properties.Add(property);
                db.SaveChanges();

                return Ok(property);
            }
            catch (Exception e)
            {
                return InternalServerError();

            }
        }

        // DELETE: api/Property/5
        [ResponseType(typeof(DAL.Models.Property))]
        public IHttpActionResult DeleteProperty(int id)
        {
            DAL.Models.Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.Id == id) > 0;
        }
    }
}