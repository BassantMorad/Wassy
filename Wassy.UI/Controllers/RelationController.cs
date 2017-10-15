using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL.Attachment;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/relation")]
    public class RelationController : ApiController
    {
        private Context db = new Context();

        // GET: api/Relation
        [HttpGet]
        [Route("")]
        public RelationResponse GetRelations()
        {
            GetAllRelationRequest req = new GetAllRelationRequest();
            return req.GetAll();
        }
        [HttpGet]
        [Route("GetF")]
        public RelationFemaleResponse GetFemaleRelations()
        {
            GetAllRelationRequest req = new GetAllRelationRequest();
            return req.GetAllFemales();
        }
        [HttpGet]
        [Route("GetM")]
        public RelationMaleResponse GetMaleRelations()
        {
            GetAllRelationRequest req = new GetAllRelationRequest();
            return req.GetAllMales();
        }
        // GET: api/Relation/5
        [HttpGet]
        //[Route("/{id}")]
        public IHttpActionResult GetRelation(int id)
        {
            DAL.Models.Relation relation = db.Relations.Find(id);
            if (relation == null)
            {
                return NotFound();
            }

            return Ok(relation);
        }

        // PUT: api/Relation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelation(int id, DAL.Models.Relation relation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relation.Id)
            {
                return BadRequest();
            }

            db.Entry(relation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Relation
        [HttpPost]
        [Route("")]
        public IHttpActionResult PostRelation(DAL.Models.Relation relation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Relations.Add(relation);
            db.SaveChanges();

            return Ok(relation);
        }

        // DELETE: api/Relation/5
        [ResponseType(typeof(DAL.Models.Relation))]
        public IHttpActionResult DeleteRelation(int id)
        {
            DAL.Models.Relation relation = db.Relations.Find(id);
            if (relation == null)
            {
                return NotFound();
            }

            db.Relations.Remove(relation);
            db.SaveChanges();

            return Ok(relation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelationExists(int id)
        {
            return db.Relations.Count(e => e.Id == id) > 0;
        }
    }
}