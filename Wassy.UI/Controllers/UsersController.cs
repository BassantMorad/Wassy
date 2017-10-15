using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using Wassy.BLL.Functions;
using Wassy.DAL.Models;
using Wassy.DAL.Models;
using Wassy.UI.Models;

namespace Wassy.UI.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private Context db = new Context();

        [HttpGet]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        [HttpGet]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        [HttpGet]
        public IHttpActionResult getWassaya (int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
                return NotFound();
            return Ok(user.Wassaya);
        }
        [HttpPut]
        [Route("UpdateWassaya")]
        public IHttpActionResult UpdateWassaya(RequestWassaya req)
        {
            string wasaya = req.getWassaya();
         
            User user = db.Users.Find(req.getID());
            if (user == null)
                return NotFound();
           // Console.WriteLine(req.getWassaya());
            user.Wassaya = req.getWassaya();
            db.SaveChanges();
            //db.Entry(olduser).State = EntityState.Modified;
            return Ok(user);
           // user.Wassaya = wassaya;


        }
        //[HttpPost]
        //[Route("AddProperty")]
        //public IHttpActionResult CreatePropert(Property prop)
        //{
        //    try { 
        //        if (!ModelState.IsValid)
        //            return BadRequest();
        //        User user = db.Users.Find(prop.UserId);
        //        user.Properties.Add(prop);
        //        db.SaveChanges();
        //        return Ok(user);
        //    }
        //    catch (Exception e)
        //    {
        //        return InternalServerError();

        //    }
        //}
       

        [HttpPost]
        [Route("register")]
        [ResponseType(typeof(User))]
        public IHttpActionResult Register(User user)
        {
            try { 
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //var date = DateTimeOffset.Now.ToUnixTimeSeconds();
                if (EmailExists(user.Email))
                {
                    return BadRequest("This Email is already used");
                }
                db.Users.Add(user);
                db.SaveChanges();
                AddNewLogin newlogin = new AddNewLogin();
                newlogin.Add(user.Id);
                return Ok(user.Id);
        }
            catch(Exception e)
            {
                return InternalServerError();

            }
}
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login()
        {
            HttpRequestMessage Request = new HttpRequestMessage();
            HttpRequestHeaders headers = base.Request.Headers;
            //Request.fo
            try {
                string email = headers.GetValues("email").First();
                string password = headers.GetValues("password").First();
                User user = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (user == null)
                    return BadRequest("There is no user with this email");

                AddNewLogin newlogin = new AddNewLogin();
                newlogin.Add(user.Id);
                return Ok(user.Id);
            }
            catch(Exception e)
            {
                return InternalServerError();
            }
        }
        [HttpDelete]
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
        private bool EmailExists(string email)
        {
            return db.Users.Count(e => e.Email == email) > 0;
        }
    }
}