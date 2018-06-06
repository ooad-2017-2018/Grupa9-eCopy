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
    public class IzradaPersonaliziranihPredmetasController : ApiController
    {
        private OOADModel db = new OOADModel();

        // GET: api/IzradaPersonaliziranihPredmetas
        public IQueryable<IzradaPersonaliziranihPredmeta> GetIzradaPersonaliziranihPredmeta()
        {
            return db.IzradaPersonaliziranihPredmeta;
        }

        // GET: api/IzradaPersonaliziranihPredmetas/5
        [ResponseType(typeof(IzradaPersonaliziranihPredmeta))]
        public async Task<IHttpActionResult> GetIzradaPersonaliziranihPredmeta(int id)
        {
            IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta = await db.IzradaPersonaliziranihPredmeta.FindAsync(id);
            if (izradaPersonaliziranihPredmeta == null)
            {
                return NotFound();
            }

            return Ok(izradaPersonaliziranihPredmeta);
        }

        // PUT: api/IzradaPersonaliziranihPredmetas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIzradaPersonaliziranihPredmeta(int id, IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != izradaPersonaliziranihPredmeta.IzradaPersonaliziranihPredmetaId)
            {
                return BadRequest();
            }

            db.Entry(izradaPersonaliziranihPredmeta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IzradaPersonaliziranihPredmetaExists(id))
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

        // POST: api/IzradaPersonaliziranihPredmetas
        [ResponseType(typeof(IzradaPersonaliziranihPredmeta))]
        public async Task<IHttpActionResult> PostIzradaPersonaliziranihPredmeta(IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IzradaPersonaliziranihPredmeta.Add(izradaPersonaliziranihPredmeta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = izradaPersonaliziranihPredmeta.IzradaPersonaliziranihPredmetaId }, izradaPersonaliziranihPredmeta);
        }

        // DELETE: api/IzradaPersonaliziranihPredmetas/5
        [ResponseType(typeof(IzradaPersonaliziranihPredmeta))]
        public async Task<IHttpActionResult> DeleteIzradaPersonaliziranihPredmeta(int id)
        {
            IzradaPersonaliziranihPredmeta izradaPersonaliziranihPredmeta = await db.IzradaPersonaliziranihPredmeta.FindAsync(id);
            if (izradaPersonaliziranihPredmeta == null)
            {
                return NotFound();
            }

            db.IzradaPersonaliziranihPredmeta.Remove(izradaPersonaliziranihPredmeta);
            await db.SaveChangesAsync();

            return Ok(izradaPersonaliziranihPredmeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IzradaPersonaliziranihPredmetaExists(int id)
        {
            return db.IzradaPersonaliziranihPredmeta.Count(e => e.IzradaPersonaliziranihPredmetaId == id) > 0;
        }
    }
}