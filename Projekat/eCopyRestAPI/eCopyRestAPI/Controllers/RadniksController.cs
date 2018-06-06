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
    public class RadniksController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Radniks
        public IQueryable<Radnik> GetRadnik()
        {
            return db.Radnik;
        }

        // GET: api/Radniks/5
        [ResponseType(typeof(Radnik))]
        public async Task<IHttpActionResult> GetRadnik(int id)
        {
            Radnik radnik = await db.Radnik.FindAsync(id);
            if (radnik == null)
            {
                return NotFound();
            }

            return Ok(radnik);
        }

        // PUT: api/Radniks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRadnik(int id, Radnik radnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != radnik.RadnikId)
            {
                return BadRequest();
            }

            db.Entry(radnik).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadnikExists(id))
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

        // POST: api/Radniks
        [ResponseType(typeof(Radnik))]
        public async Task<IHttpActionResult> PostRadnik(Radnik radnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Radnik.Add(radnik);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = radnik.RadnikId }, radnik);
        }

        // DELETE: api/Radniks/5
        [ResponseType(typeof(Radnik))]
        public async Task<IHttpActionResult> DeleteRadnik(int id)
        {
            Radnik radnik = await db.Radnik.FindAsync(id);
            if (radnik == null)
            {
                return NotFound();
            }

            db.Radnik.Remove(radnik);
            await db.SaveChangesAsync();

            return Ok(radnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RadnikExists(int id)
        {
            return db.Radnik.Count(e => e.RadnikId == id) > 0;
        }
    }
}