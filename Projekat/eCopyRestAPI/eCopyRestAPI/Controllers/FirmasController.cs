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
    public class FirmasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Firmas
        public IQueryable<Firma> GetFirma()
        {
            return db.Firma;
        }

        // GET: api/Firmas/5
        [ResponseType(typeof(Firma))]
        public async Task<IHttpActionResult> GetFirma(int id)
        {
            Firma firma = await db.Firma.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }

            return Ok(firma);
        }

        // PUT: api/Firmas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFirma(int id, Firma firma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firma.FirmaId)
            {
                return BadRequest();
            }

            db.Entry(firma).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmaExists(id))
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

        // POST: api/Firmas
        [ResponseType(typeof(Firma))]
        public async Task<IHttpActionResult> PostFirma(Firma firma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Firma.Add(firma);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = firma.FirmaId }, firma);
        }

        // DELETE: api/Firmas/5
        [ResponseType(typeof(Firma))]
        public async Task<IHttpActionResult> DeleteFirma(int id)
        {
            Firma firma = await db.Firma.FindAsync(id);
            if (firma == null)
            {
                return NotFound();
            }

            db.Firma.Remove(firma);
            await db.SaveChangesAsync();

            return Ok(firma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FirmaExists(int id)
        {
            return db.Firma.Count(e => e.FirmaId == id) > 0;
        }
    }
}