using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eCopyRestAPI.Models;

namespace eCopyRestAPI.Controllers
{
    public class IzradaReklamnogMaterijalasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/IzradaReklamnogMaterijalas
        public IQueryable<IzradaReklamnogMaterijala> GetIzradaReklamnogMaterijala()
        {
            return db.IzradaReklamnogMaterijala;
        }

        // GET: api/IzradaReklamnogMaterijalas/5
        [ResponseType(typeof(IzradaReklamnogMaterijala))]
        public async Task<IHttpActionResult> GetIzradaReklamnogMaterijala(int id)
        {
            IzradaReklamnogMaterijala izradaReklamnogMaterijala = await db.IzradaReklamnogMaterijala.FindAsync(id);
            if (izradaReklamnogMaterijala == null)
            {
                return NotFound();
            }

            return Ok(izradaReklamnogMaterijala);
        }

        // PUT: api/IzradaReklamnogMaterijalas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIzradaReklamnogMaterijala(int id, IzradaReklamnogMaterijala izradaReklamnogMaterijala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != izradaReklamnogMaterijala.IzradaReklamnogMaterijalaId)
            {
                return BadRequest();
            }

            db.Entry(izradaReklamnogMaterijala).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IzradaReklamnogMaterijalaExists(id))
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

        // POST: api/IzradaReklamnogMaterijalas
        [ResponseType(typeof(IzradaReklamnogMaterijala))]
        public async Task<IHttpActionResult> PostIzradaReklamnogMaterijala(IzradaReklamnogMaterijala izradaReklamnogMaterijala)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IzradaReklamnogMaterijala.Add(izradaReklamnogMaterijala);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = izradaReklamnogMaterijala.IzradaReklamnogMaterijalaId }, izradaReklamnogMaterijala);
        }

        // DELETE: api/IzradaReklamnogMaterijalas/5
        [ResponseType(typeof(IzradaReklamnogMaterijala))]
        public async Task<IHttpActionResult> DeleteIzradaReklamnogMaterijala(int id)
        {
            IzradaReklamnogMaterijala izradaReklamnogMaterijala = await db.IzradaReklamnogMaterijala.FindAsync(id);
            if (izradaReklamnogMaterijala == null)
            {
                return NotFound();
            }

            db.IzradaReklamnogMaterijala.Remove(izradaReklamnogMaterijala);
            await db.SaveChangesAsync();

            return Ok(izradaReklamnogMaterijala);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IzradaReklamnogMaterijalaExists(int id)
        {
            return db.IzradaReklamnogMaterijala.Count(e => e.IzradaReklamnogMaterijalaId == id) > 0;
        }
    }
}