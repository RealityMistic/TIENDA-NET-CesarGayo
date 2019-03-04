using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TiendaNET_CesarGayo.Controllers
{
    public class PedidoController : ApiController
    {

        private TiendaNETDBEntities te = new TiendaNETDBEntities();

        // GET: api/Pedidos
        public IQueryable<PedidoSet> GetPedidoSets()
        {
            return te.PedidoSet;
        }

        // GET: api/Pedidos/5
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            TiendaNETDBEntities te = new TiendaNETDBEntities();
            var results = from p in te.PedidoSet
                          where p.Id.Equals(id)
                          select p;

            PedidoSet pedido = results as PedidoSet;
            return Ok(JsonConvert.SerializeObject(pedido));

        }

        // PUT: api/Pedidos/5
        public IHttpActionResult Put(int id, string fecha, string completado, string usuario_id)
        {
           

           // ??? te.PedidoSet.Find(id).State = EntityState.Modified;

            try
            {
                te.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidos
        public IHttpActionResult PostPedido(int id, string fecha, string completado, string usuario_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PedidoSet pedido = new PedidoSet();

            // TODO nutrir objeto
            te.PedidoSet.Add(pedido);
            try
            {
                te.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        public IHttpActionResult DeletePedido(int id)
        {
            PedidoSet pedido = te.PedidoSet.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            te.PedidoSet.Remove(pedido);
            try
            {
                te.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(JsonConvert.SerializeObject(pedido));
        }



        private bool PedidoExists(int id)
        {
            return te.PedidoSet.Count(e => e.Id == id) > 0;
        }

    }
}


