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
        int? PrecioTotal = 0;
        private TiendaNETDBEntities db = new TiendaNETDBEntities();

        // GET: Carrito
        public ActionResult Index(CarritoCompra cc)
        {
            return View(cc.ToList());
        }

        public ActionResult AniadirProducto(CarritoCompra cc, int id)
        {
            ProductoSet nuevop = db.ProductoSet.Find(id);
          //  nuevop.Cantidad = cantidadAPedir;
            cc.Add(nuevop);
            /*
            ProductoSet p = cc.Find(x => x.Id == id);

            if (p == null)
            {
                ProductoSet nuevop = db.ProductoSet.Find(id);
                nuevop.Cantidad = 1;
                cc.Add(nuevop);
            }
            else
            {
                ProductoSet nuevop = p;
                
                nuevop.Cantidad = cantidadAPedir;
                cc.Add(nuevop);
            }

            */
            return RedirectToAction("Index");
        }
            /*
            ProductoSet productoAAniadir = db.ProductoSet.Find(id);
foreach (var item in cc)
{
            if (productoAAniadir.Cantidad + item.Cantidad <= productoAAniadir.Stock))
            {
                productoAAniadir.Cantidad += item.Cantidad;
            }
            db.ProductoSet.Add(productoAAniadir);
            db.SaveChanges();
            this.PrecioTotal += item.Cantidad * item.Precio;

}
cc.Add(productoAAniadir);
return RedirectToAction("Productos", "Home");
*/
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

        
        /*
        public ActionResult RemoveProducto(CarritoCompra cc, int id)
        {
            ProductoSet p = db.ProductoSet.Find(id);
            cc.Remove(p);

            return RedirectToAction("Index", "Productoes");
        }
        */
        public ActionResult VolcarCarrito(CarritoCompra cc)
        {
           // Factura f = new Factura();
           // f.Total = this.CalculateTotal(cc);
           // f.Usuario_Id = User.Identity.GetUserName();
           // db.Facturas.Add(f);
           // db.SaveChanges();

            // db.Facturas.Add(f);

            foreach (ProductoSet p in cc)
            {
                PedidoSet pedido = new PedidoSet();
                pedido.Precio = p.Precio;
                pedido.Producto_Id = p.Id;
                pedido.Cantidad = p.Cantidad;

                ProductoSet temp = db.ProductoSet.Find(p.Id);
                temp.Cantidad = temp.Cantidad - pedido.Cantidad;
                comprobarStock(p.Id);
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();

               // pedido.Factura_Id = db.Facturas.Find(f.Id).Id;

                db.PedidoSet.Add(pedido);
                db.SaveChanges();
            }

            cc.NuevoCarrito(ControllerContext);

            return View(cc.ToList());

            return RedirectToAction("Index", "Productoes");
        }

        public void comprobarStock(int id)
        {
            int cantidad = db.ProductoSet.Find(id).Cantidad;
            if (cantidad <= 2)
            {
                StockSet stock = new StockSet();
                stock.Producto_Id = db.ProductoSet.Find(id).Id;
                stock.Cantidad = cantidad;
                db.SaveChanges();
            }
        }
    }
}
