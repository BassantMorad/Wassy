using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL.Attachment;
using Wassy.BLL.Functions;
using Wassy.DAL.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/responsible")]
    public class ResponsiblesController : ApiController
    {
        private Context db = new Context();
        [HttpGet]
        [Route("")]
        // GET: api/Responsibles
        public IQueryable<Responsible> GetResponsibles()
        {
            return db.Responsibles;
        }

        // GET: api/Responsibles/5
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Responsible))]
        public IHttpActionResult GetResponsible(UserGetResponsibleRequest req)
        {
            GetAllResponsible response = new GetAllResponsible();

            return Ok(response.getAll(req.Id));
        }

        // PUT: api/Responsibles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResponsible(ResponsibleRequest req)
        {
            try
            {
                Responsible responsible = db.Responsibles.Find(req.Id);
                if (responsible == null)
                    return NotFound();
                UpdateResponsible resp = new UpdateResponsible();

                return Ok(resp.Update(req));
            }catch(Exception e)
            {
                return InternalServerError();
            }
        }

        // POST: api/Responsibles
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostResponsible(Responsible responsible)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Responsibles.Add(responsible);
            db.SaveChanges();

            return Ok(responsible.Id);
        }

        // DELETE: api/Responsibles/5
        [ResponseType(typeof(Responsible))]
        public IHttpActionResult DeleteResponsible(int id)
        {
            Responsible responsible = db.Responsibles.Find(id);
            if (responsible == null)
            {
                return NotFound();
            }

            db.Responsibles.Remove(responsible);
            db.SaveChanges();

            return Ok(responsible);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResponsibleExists(int id)
        {
            return db.Responsibles.Count(e => e.Id == id) > 0;
        }
    }
}