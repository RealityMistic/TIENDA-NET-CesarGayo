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
using TiendaNET_CesarGayo;

namespace TiendaNET_CesarGayo.Controllers
{
    public class ProductoController : ApiController
    {
        private TiendaNETDBEntities db = new TiendaNETDBEntities();

        // GET: api/Producto
        public IQueryable<ProductoSet> GetProductoSet()
        {
            return db.ProductoSet;
        }

        // GET: api/Producto/5
        [ResponseType(typeof(ProductoSet))]
        public IHttpActionResult GetProductoSet(int id)
        {
            ProductoSet productoSet = db.ProductoSet.Find(id);
            if (productoSet == null)
            {
                return NotFound();
            }

            return Ok(productoSet);
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductoSet(int id, ProductoSet productoSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productoSet.Id)
            {
                return BadRequest();
            }

            db.Entry(productoSet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoSetExists(id))
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

        // POST: api/Producto
        [HttpPost]
        [ResponseType(typeof(ProductoSet))]
        public IHttpActionResult PostProductoSet(ProductoSet productoSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductoSet.Add(productoSet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productoSet.Id }, productoSet);
        }

        // DELETE: api/Producto/5
        [ResponseType(typeof(ProductoSet))]
        public IHttpActionResult DeleteProductoSet(int id)
        {
            ProductoSet productoSet = db.ProductoSet.Find(id);
            if (productoSet == null)
            {
                return NotFound();
            }

            db.ProductoSet.Remove(productoSet);
            db.SaveChanges();

            return Ok(productoSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoSetExists(int id)
        {
            return db.ProductoSet.Count(e => e.Id == id) > 0;
        }
    }
}