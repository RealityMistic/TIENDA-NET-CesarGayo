using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaNET_CesarGayo;
using TiendaNET_CesarGayo.Models;

namespace TiendaNET_CesarGayo.Controllers
{
    public class CarritoController : Controller
    {
        private TiendaNETDBEntities db = new TiendaNETDBEntities();

        // GET: Carrito
        public ActionResult Index(CarritoCompra cc)
        {
            
            return View(cc);
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoSet pedidoSet = db.PedidoSet.Find(id);
            if (pedidoSet == null)
            {
                return HttpNotFound();
            }
            return View(pedidoSet);
        }

        // GET: Carrito/Create
        public ActionResult Create()
        {
            ViewBag.Usuario_Id = new SelectList(db.UsuarioSet, "Id", "Nombre");
            return View();
        }

        // POST: Carrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Completado,Usuario_Id")] PedidoSet pedidoSet)
        {
            if (ModelState.IsValid)
            {
                db.PedidoSet.Add(pedidoSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Usuario_Id = new SelectList(db.UsuarioSet, "Id", "Nombre", pedidoSet.Usuario_Id);
            return View(pedidoSet);
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoSet pedidoSet = db.PedidoSet.Find(id);
            if (pedidoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Usuario_Id = new SelectList(db.UsuarioSet, "Id", "Nombre", pedidoSet.Usuario_Id);
            return View(pedidoSet);
        }

        // POST: Carrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Completado,Usuario_Id")] PedidoSet pedidoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Usuario_Id = new SelectList(db.UsuarioSet, "Id", "Nombre", pedidoSet.Usuario_Id);
            return View(pedidoSet);
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoSet pedidoSet = db.PedidoSet.Find(id);
            if (pedidoSet == null)
            {
                return HttpNotFound();
            }
            return View(pedidoSet);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoSet pedidoSet = db.PedidoSet.Find(id);
            db.PedidoSet.Remove(pedidoSet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddProducto(CarritoCompra cc, int id)
        {
            ProductoSet p = db.ProductoSet.Find(id);
            cc.Add(p);

            return RedirectToAction("Index", "Productoes");
        }

        public ActionResult RemoveProducto(CarritoCompra cc, int id)
        {
            ProductoSet p = db.ProductoSet.Find(id);
            cc.Remove(p);

            return RedirectToAction("Index", "Productoes");
        }
        public ActionResult VolcarCarrito(CarritoCompra cc)
        {
            

            return RedirectToAction("Index", "Productoes");
        }
    }
}
