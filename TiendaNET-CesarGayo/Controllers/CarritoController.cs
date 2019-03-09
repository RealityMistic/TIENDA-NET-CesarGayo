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
        int PrecioTotal = 0;
        private TiendaNETDBEntities db = new TiendaNETDBEntities();

        // GET: Carrito
        public ActionResult Index(CarritoCompra cc)
        {
            return View(cc.ToList());
        }

        public ActionResult AniadirProducto(CarritoCompra cc, int id, int cantidad)
        {
            
            ProductoSet nuevop = db.ProductoSet.Find(id);


            if (cantidad == 0)
            {

                nuevop.Cantidad = 1;
           
            } else
            {
                nuevop.Cantidad = cantidad;
            }
            cc.Add(nuevop);
           
            return RedirectToAction("Index");
        }
            

            // GET: Carrito/Delete/5
            public ActionResult Eliminar(CarritoCompra cc, int id)
            {
            
                int indice = cc.FindIndex(x => x.Id == id);
                cc.RemoveAt(indice);
                return RedirectToAction("Index", "Carrito");

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

       
        public ActionResult VolcarCarrito(CarritoCompra cc)
        {
            PedidoSet nuevopedido = new PedidoSet();
            foreach (ProductoSet p in cc)
            {
                nuevopedido.Precio = p.Precio;
                PrecioTotal += p.Precio;
                nuevopedido.Producto_Id = p.Id;
                nuevopedido.Cantidad = p.Cantidad;
                db.PedidoSet.Add(nuevopedido);
                db.SaveChanges();
                ProductoSet temp = db.ProductoSet.Find(p.Id);
                temp.Stock = temp.Stock - nuevopedido.Cantidad;
                comprobarStock(p.Id);
                temp.Cantidad = 0;
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();

                
            }
           // nuevopedido.Precio = PrecioTotal;
            
           // 
            
            cc.NuevoCarrito(ControllerContext);

            return View(cc.ToList());
            
        }

        public void comprobarStock(int id)
        {
            int stock = db.ProductoSet.Find(id).Stock;
            if (stock <= 2)
            {
                StockSet nuevostockset = new StockSet();
                nuevostockset.Producto_Id = db.ProductoSet.Find(id).Id;
                nuevostockset.Cantidad = 100;
                db.StockSet.Add(nuevostockset);
                db.SaveChanges();
            }
        }
    }
}
