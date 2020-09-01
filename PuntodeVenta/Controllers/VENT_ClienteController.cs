using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuntodeVenta.Models;

namespace PuntodeVenta.Controllers
{
    public class VENT_ClienteController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: VENT_Cliente
        public ActionResult cliente()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                var vENT_Cliente = db.VENT_Cliente.Include(v => v.RRHH_Usuario);
                return View(vENT_Cliente.ToList());
            }
        }


        public ActionResult Index()
        {
            var vENT_Cliente = db.VENT_Cliente.Include(v => v.RRHH_Usuario);
            return View(vENT_Cliente.ToList());
        }

        // GET: VENT_Cliente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_Cliente vENT_Cliente = db.VENT_Cliente.Find(id);
            if (vENT_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(vENT_Cliente);
        }

        // GET: VENT_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña");
            return View();
        }

        // POST: VENT_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nit,Nombre,FechaNac,Direccion")] VENT_Cliente vENT_Cliente)
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                vENT_Cliente.UserSystem = Convert.ToString(Session["usuario"]);
                if (ModelState.IsValid)
                {
                    Session["DatoInsertado"] = "si";
                    db.VENT_Cliente.Add(vENT_Cliente);
                    db.SaveChanges();
                    return RedirectToAction("cliente");
                }

                ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña", vENT_Cliente.UserSystem);
                return RedirectToAction("cliente");
            }
        }

        // GET: VENT_Cliente/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_Cliente vENT_Cliente = db.VENT_Cliente.Find(id);
            if (vENT_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña", vENT_Cliente.UserSystem);
            return View(vENT_Cliente);
        }

        // POST: VENT_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nit,Nombre,FechaNac,Direccion,UserSystem")] VENT_Cliente vENT_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENT_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña", vENT_Cliente.UserSystem);
            return View(vENT_Cliente);
        }

        // GET: VENT_Cliente/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_Cliente vENT_Cliente = db.VENT_Cliente.Find(id);
            if (vENT_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(vENT_Cliente);
        }

        // POST: VENT_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VENT_Cliente vENT_Cliente = db.VENT_Cliente.Find(id);
            db.VENT_Cliente.Remove(vENT_Cliente);
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
    }
}
