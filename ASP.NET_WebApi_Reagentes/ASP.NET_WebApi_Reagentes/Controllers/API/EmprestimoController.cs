using ASP.NET_WebApi_Reagentes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ASP.NET_WebApi_Reagentes.Controllers.API
{
    public class EmprestimoController : ApiController
    {
        private EstoqueContext db = new EstoqueContext();

        //GET: api/Emprestimo
        public IEnumerable<Emprestimo> Get()
        {
            return db.Emprestimos;
        }

        //GET: api/Emprestimo/5
        [ResponseType(typeof(Emprestimo))]
        public IHttpActionResult GetEmprestimo(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if(emprestimo == null)
            {
                return NotFound();
            }

            return Ok(emprestimo);
        }

        //PUT: api/Emprestimo/2
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Emprestimo emprestimo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != emprestimo.Id)
            {
                return BadRequest();
            }

            db.Entry(emprestimo).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/Emprestimo
        [ResponseType(typeof(Emprestimo))]
        public IHttpActionResult Post(Emprestimo emprestimo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emprestimos.Add(emprestimo);

            return CreatedAtRoute("DefaultApi", new { id = emprestimo.Id }, emprestimo);
        }

        //DELETE: api/Emprestimo
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if(emprestimo == null)
            {
                return NotFound();
            }

            db.Emprestimos.Remove(emprestimo);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}
