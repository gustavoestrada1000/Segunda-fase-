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
    public class VENT_ProveedorController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: VENT_Proveedor
        public ActionResult Index()
        {
            return View(db.VENT_Proveedor.ToList());
        }


        public ActionResult providers()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                return View(db.VENT_Proveedor.ToList());
            }
        }
        // GET: VENT_Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_Proveedor vENT_Proveedor = db.VENT_Proveedor.Find(id);
            if (vENT_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(vENT_Proveedor);
        }

        // GET: VENT_Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENT_Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Telefono,Direccion,Asesor")] VENT_Proveedor vENT_Proveedor)
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.VENT_Proveedor.Add(vENT_Proveedor);
                    db.SaveChanges();
                    return RedirectToAction("providers");
                }

                return View("providers");
            }
        }

        // GET: VENT_Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_Proveedor vENT_Proveedor = db.VENT_Proveedor.Find(id);
            if (vENT_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(vENT_Proveedor);
        }

        // POST: VENT_Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpresa,Nombre,Telefono,Direccion,Asesor")] VENT_Proveedor vENT_Proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENT_Proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vENT_Proveedor);
        }

        // GET: VENT_Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_Proveedor vENT_Proveedor = db.VENT_Proveedor.Find(id);
            if (vENT_Proveedor == null)
            {
                return HttpNotFound();
            }
            return View(vENT_Proveedor);
        }

        // POST: VENT_Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENT_Proveedor vENT_Proveedor = db.VENT_Proveedor.Find(id);
            db.VENT_Proveedor.Remove(vENT_Proveedor);
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
