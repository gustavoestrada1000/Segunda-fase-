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
    public class VENT_CompraDetalleController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: VENT_CompraDetalle
        public ActionResult detalle(int id)
        {
            string[,] d = new string[15, 3];
            
           

            return View();
        }

        // GET: VENT_CompraDetalle/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_CompraDetalle vENT_CompraDetalle = db.VENT_CompraDetalle.Find(id);
            if (vENT_CompraDetalle == null)
            {
                return HttpNotFound();
            }
            return View(vENT_CompraDetalle);
        }

        // GET: VENT_CompraDetalle/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.BODE_PRODUCTO, "IdProducto", "Nombre");
            ViewBag.NumeroFactura = new SelectList(db.VENT_CompraEncabezado, "NumeroFactura", "UserSystem");
            return View();
        }

        // POST: VENT_CompraDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroFactura,IdProducto,cantidad,precioU")] VENT_CompraDetalle vENT_CompraDetalle)
        {
            if (ModelState.IsValid)
            {
                db.VENT_CompraDetalle.Add(vENT_CompraDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.BODE_PRODUCTO, "IdProducto", "Nombre", vENT_CompraDetalle.IdProducto);
            ViewBag.NumeroFactura = new SelectList(db.VENT_CompraEncabezado, "NumeroFactura", "UserSystem", vENT_CompraDetalle.NumeroFactura);
            return View(vENT_CompraDetalle);
        }

        // GET: VENT_CompraDetalle/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_CompraDetalle vENT_CompraDetalle = db.VENT_CompraDetalle.Find(id);
            if (vENT_CompraDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.BODE_PRODUCTO, "IdProducto", "Nombre", vENT_CompraDetalle.IdProducto);
            ViewBag.NumeroFactura = new SelectList(db.VENT_CompraEncabezado, "NumeroFactura", "UserSystem", vENT_CompraDetalle.NumeroFactura);
            return View(vENT_CompraDetalle);
        }

        // POST: VENT_CompraDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroFactura,IdProducto,cantidad,precioU")] VENT_CompraDetalle vENT_CompraDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENT_CompraDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.BODE_PRODUCTO, "IdProducto", "Nombre", vENT_CompraDetalle.IdProducto);
            ViewBag.NumeroFactura = new SelectList(db.VENT_CompraEncabezado, "NumeroFactura", "UserSystem", vENT_CompraDetalle.NumeroFactura);
            return View(vENT_CompraDetalle);
        }

        // GET: VENT_CompraDetalle/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_CompraDetalle vENT_CompraDetalle = db.VENT_CompraDetalle.Find(id);
            if (vENT_CompraDetalle == null)
            {
                return HttpNotFound();
            }
            return View(vENT_CompraDetalle);
        }

        // POST: VENT_CompraDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VENT_CompraDetalle vENT_CompraDetalle = db.VENT_CompraDetalle.Find(id);
            db.VENT_CompraDetalle.Remove(vENT_CompraDetalle);
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
