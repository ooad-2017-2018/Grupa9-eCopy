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
    public class FizickoLiceController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/FizickoLice
        public IQueryable<FizickoLice> GetFizickoLice()
        {
            return db.FizickoLice;
        }

        // GET: api/FizickoLice/5
        [ResponseType(typeof(FizickoLice))]
        public async Task<IHttpActionResult> GetFizickoLice(int id)
        {
            FizickoLice fizickoLice = await db.FizickoLice.FindAsync(id);
            if (fizickoLice == null)
            {
                return NotFound();
            }

            return Ok(fizickoLice);
        }

        // PUT: api/FizickoLice/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFizickoLice(int id, FizickoLice fizickoLice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fizickoLice.FizickoLiceId)
            {
                return BadRequest();
            }

            db.Entry(fizickoLice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FizickoLiceExists(id))
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

        // POST: api/FizickoLice
        [ResponseType(typeof(FizickoLice))]
        public async Task<IHttpActionResult> PostFizickoLice(FizickoLice fizickoLice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FizickoLice.Add(fizickoLice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fizickoLice.FizickoLiceId }, fizickoLice);
        }

        // DELETE: api/FizickoLice/5
        [ResponseType(typeof(FizickoLice))]
        public async Task<IHttpActionResult> DeleteFizickoLice(int id)
        {
            FizickoLice fizickoLice = await db.FizickoLice.FindAsync(id);
            if (fizickoLice == null)
            {
                return NotFound();
            }

            db.FizickoLice.Remove(fizickoLice);
            await db.SaveChangesAsync();

            return Ok(fizickoLice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FizickoLiceExists(int id)
        {
            return db.FizickoLice.Count(e => e.FizickoLiceId == id) > 0;
        }
    }
}