using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaNET_CesarGayo.Models;

namespace TiendaNET_CesarGayo.Controllers
{
    public class HomeController : Controller
    {
        TiendaNETDBEntities db = new TiendaNETDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Productos()
        {

            ViewBag.Message = "Productos de la Tienda";
            
            var lista = db.ProductoSet.Select(x=> new ProductoViewModel
            {
                CantidadAPedir = 0,
                Descripcion = x.Descripcion,
                Nombre = x.Nombre,
                Stock = x.Stock,
                Id = x.Id
                
            });
          
            return View(lista);
        
            // return View(db.ProductoSet);
        }
        public ActionResult AgregarACarrito(int id, int cantidadAPedir)
        {
            CarritoCompra productoCantidad = new CarritoCompra();
           // productoCantidad.AddCarrito(id, cantidadAPedir);
           // Session["Carrito"] = productoCantidad;

            return RedirectToAction("Index", "Carrito");
           // return View("Index");
        }
        public ActionResult Mas()
        {
            return RedirectToAction("Productos");
        }

        public ActionResult Menos()
        {
            return RedirectToAction("Productos");
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}