using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            

            return View(db.ProductoSet.ToList());
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}