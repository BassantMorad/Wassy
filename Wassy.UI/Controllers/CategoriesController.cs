using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL.Attachment;
using Wassy.BLL.Responses;
using Wassy.DAL.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private Context db = new Context();

        [HttpGet]
        [Route("")]
        public CategoryResponse GetCategoriess()
        {
            GetAllCategoriesRequest req = new GetAllCategoriesRequest();
            return req.GetAll();
        }

        // GET: api/Categories/5

        public IHttpActionResult GetCategory(int id)
        {
            Wassy.DAL.Models.Category category = db.Categoriess.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Wassy.DAL.Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]FormDataCollection formdata)
        {
            Wassy.DAL.Models.Category category = new Wassy.DAL.Models.Category();
            string filepath = "";
            Dictionary<string, object> dict = new Dictionary<string, object>();
            // var typee = formdata.GetValues("Type").FirstOrDefault();
            var httpRequest = HttpContext.Current.Request;
            // var httpRequest = formdata.Get("image");

            foreach (string file in httpRequest.Files)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                var postedFile = httpRequest.Files[file];
                if (postedFile != null && postedFile.ContentLength > 0)
                {

                    int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                    var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (!AllowedFileExtensions.Contains(extension))
                    {

                        var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                        dict.Add("error", message);
                        return BadRequest(message);
                    }
                    else if (postedFile.ContentLength < MaxContentLength)
                    {

                        var message = string.Format("Please Upload a file upto 1 mb.");

                        dict.Add("error", message);
                        return BadRequest(message);
                    }

                    filepath = HttpContext.Current.Server.MapPath("~/Image" + postedFile.FileName + extension);

                    postedFile.SaveAs(filepath);
                    category.ImagePath = postedFile.FileName;
                    //  return 
                }

            }
            // var typee = formdata.GetValues("Type");
            // category.ImagePath = filepath;
            category.Type = formdata.Get("Type");
            //category.Type= HttpContext.Current.Request.Form["Type"];
            // category.Type = HttpContext.Current.Request.Params["Type"];

            db.Categoriess.Add(category);
            db.SaveChanges();

            return Ok(category);

        }

        // DELETE: api/Categories/5
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            Wassy.DAL.Models.Category category = db.Categoriess.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categoriess.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categoriess.Count(e => e.Id == id) > 0;
        }
    }
}