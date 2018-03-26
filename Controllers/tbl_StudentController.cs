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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class tbl_StudentController : ApiController
    {
        private SchoolMangementEntities db = new SchoolMangementEntities();

        // GET: api/tbl_Student
        public IQueryable<tbl_Student> Gettbl_Student()
        {
            return db.tbl_Student;
        }

        // GET: api/tbl_Student/5
        [ResponseType(typeof(tbl_Student))]
        public IHttpActionResult Gettbl_Student(int id)
        {
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return NotFound();
            }

            return Ok(tbl_Student);
        }

        // PUT: api/tbl_Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Student(int id, tbl_Student tbl_Student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Student.StudentID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_StudentExists(id))
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

        // POST: api/tbl_Student
        [ResponseType(typeof(tbl_Student))]
        public IHttpActionResult Posttbl_Student(tbl_Student tbl_Student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Student.Add(tbl_Student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Student.StudentID }, tbl_Student);
        }

        // DELETE: api/tbl_Student/5
        [ResponseType(typeof(tbl_Student))]
        public IHttpActionResult Deletetbl_Student(int id)
        {
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return NotFound();
            }

            db.tbl_Student.Remove(tbl_Student);
            db.SaveChanges();

            return Ok(tbl_Student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_StudentExists(int id)
        {
            return db.tbl_Student.Count(e => e.StudentID == id) > 0;
        }
    }
}