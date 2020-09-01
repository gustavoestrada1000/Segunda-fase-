using PuntodeVenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace PuntodeVenta.Controllers
{
    public class HomeController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();


        public ActionResult cerrar()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                Session["usuario"] = "";
                return RedirectToAction("Index", "Home");

            }
        }
        public ActionResult Index()
        {
            Session["usuario"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            LoginUsuario_Result u = db.LoginUsuario (user,pass).FirstOrDefault();

            if (u == null)//si no existe el usuario
            {
                string a = Convert.ToString(ViewData["Error"]);

                Session["Error"] = "si";
                return View();
            }
            Session["usuario"] = u.usuario;
            Session["Estado"] = u.estado;
    

            return RedirectToAction("home", "Home");
        }

        public ActionResult Home()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                return View();
            }
        }


    }
}