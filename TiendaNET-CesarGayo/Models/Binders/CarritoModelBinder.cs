using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaNET_CesarGayo.Models
{
    public class CarritoModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //throw new NotImplementedException();
            CarritoCompra cc = (CarritoCompra)controllerContext.HttpContext.Session["Carrito"];

            if (cc == null)
            {
                cc = new CarritoCompra();
                controllerContext.HttpContext.Session["Carrito"] = cc;
            }
            return cc;
        }
    }
}