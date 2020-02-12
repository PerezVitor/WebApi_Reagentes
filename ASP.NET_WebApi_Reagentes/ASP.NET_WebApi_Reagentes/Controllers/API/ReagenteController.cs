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
    public class ReagenteController : ApiController
    {
        private EstoqueContext db = new EstoqueContext();
        // GET: api/Reagente
        public IEnumerable<Reagentes> Get()
        {
            return db.Reagentes;
        }

        // GET: api/Reagente/5
        [ResponseType(typeof(Reagentes))]
        public IHttpActionResult Get(int id)
        {
            Reagentes reagente = db.Reagentes.Find(id);
            if(reagente == null)
            {
                return NotFound();
            }

            return Ok(reagente);
        }

        // POST: api/Reagente
        [ResponseType(typeof(Reagentes))]
        public IHttpActionResult Post(Reagentes reagente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reagentes.Add(reagente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reagente.Id }, reagente);
        }

        // PUT: api/Reagente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Reagentes reagente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != reagente.Id)
            {
                return BadRequest();
            }

            db.Entry(reagente).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Reagente/5
        [ResponseType(typeof(Reagentes))]
        public IHttpActionResult Delete(int id)
        {
            Reagentes reagente = db.Reagentes.Find(id);
            if(reagente == null)
            {
                return NotFound();
            }

            db.Reagentes.Remove(reagente);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                db.Dispose();
            
            base.Dispose(disposing);
        }
    }
}
