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
    public class PrintanjesController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/Printanjes
        public IQueryable<Printanje> GetPrintanje()
        {
            return db.Printanje;
        }

        // GET: api/Printanjes/5
        [ResponseType(typeof(Printanje))]
        public async Task<IHttpActionResult> GetPrintanje(int id)
        {
            Printanje printanje = await db.Printanje.FindAsync(id);
            if (printanje == null)
            {
                return NotFound();
            }

            return Ok(printanje);
        }

        // PUT: api/Printanjes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrintanje(int id, Printanje printanje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != printanje.PrintanjeId)
            {
                return BadRequest();
            }

            db.Entry(printanje).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrintanjeExists(id))
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

        // POST: api/Printanjes
        [ResponseType(typeof(Printanje))]
        public async Task<IHttpActionResult> PostPrintanje(Printanje printanje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Printanje.Add(printanje);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = printanje.PrintanjeId }, printanje);
        }

        // DELETE: api/Printanjes/5
        [ResponseType(typeof(Printanje))]
        public async Task<IHttpActionResult> DeletePrintanje(int id)
        {
            Printanje printanje = await db.Printanje.FindAsync(id);
            if (printanje == null)
            {
                return NotFound();
            }

            db.Printanje.Remove(printanje);
            await db.SaveChangesAsync();

            return Ok(printanje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrintanjeExists(int id)
        {
            return db.Printanje.Count(e => e.PrintanjeId == id) > 0;
        }
    }
}