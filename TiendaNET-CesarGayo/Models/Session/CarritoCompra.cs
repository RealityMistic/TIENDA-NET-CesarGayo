using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaNET_CesarGayo.Models;

namespace TiendaNET_CesarGayo.Models
{
    public class CarritoCompra : List<ProductoSet>
    {
        public void NuevoCarrito(ControllerContext controllerContext)
        {
            var cc = new CarritoCompra();
            controllerContext.HttpContext.Session["Carrito"] = cc;
        }

    }
    
}