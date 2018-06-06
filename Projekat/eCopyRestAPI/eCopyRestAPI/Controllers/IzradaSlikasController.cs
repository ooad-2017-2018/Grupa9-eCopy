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
    public class IzradaSlikasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/IzradaSlikas
        public IQueryable<IzradaSlika> GetIzradaSlika()
        {
            return db.IzradaSlika;
        }

        // GET: api/IzradaSlikas/5
        [ResponseType(typeof(IzradaSlika))]
        public async Task<IHttpActionResult> GetIzradaSlika(int id)
        {
            IzradaSlika izradaSlika = await db.IzradaSlika.FindAsync(id);
            if (izradaSlika == null)
            {
                return NotFound();
            }

            return Ok(izradaSlika);
        }

        // PUT: api/IzradaSlikas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIzradaSlika(int id, IzradaSlika izradaSlika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != izradaSlika.IzradaSlikaId)
            {
                return BadRequest();
            }

            db.Entry(izradaSlika).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IzradaSlikaExists(id))
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

        // POST: api/IzradaSlikas
        [ResponseType(typeof(IzradaSlika))]
        public async Task<IHttpActionResult> PostIzradaSlika(IzradaSlika izradaSlika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IzradaSlika.Add(izradaSlika);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = izradaSlika.IzradaSlikaId }, izradaSlika);
        }

        // DELETE: api/IzradaSlikas/5
        [ResponseType(typeof(IzradaSlika))]
        public async Task<IHttpActionResult> DeleteIzradaSlika(int id)
        {
            IzradaSlika izradaSlika = await db.IzradaSlika.FindAsync(id);
            if (izradaSlika == null)
            {
                return NotFound();
            }

            db.IzradaSlika.Remove(izradaSlika);
            await db.SaveChangesAsync();

            return Ok(izradaSlika);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IzradaSlikaExists(int id)
        {
            return db.IzradaSlika.Count(e => e.IzradaSlikaId == id) > 0;
        }
    }
}