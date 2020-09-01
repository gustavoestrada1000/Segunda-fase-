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
    public class BODE_PRODUCTOController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: BODE_PRODUCTO


        public ActionResult products()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                return View(db.BODE_PRODUCTO.ToList());
            }
        }


        public ActionResult Index()
        {
            return View(db.BODE_PRODUCTO.ToList());
        }

        // GET: BODE_PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BODE_PRODUCTO bODE_PRODUCTO = db.BODE_PRODUCTO.Find(id);
            if (bODE_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(bODE_PRODUCTO);
        }

        // GET: BODE_PRODUCTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BODE_PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Marca,Modelo,Categoria,PrecioVenta,PrecioCompra")] BODE_PRODUCTO bODE_PRODUCTO)
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {

                bODE_PRODUCTO.Existencia = 0;
                if (ModelState.IsValid)
                {
                    db.BODE_PRODUCTO.Add(bODE_PRODUCTO);
                    db.SaveChanges();
                    return RedirectToAction("products");
                }

                return RedirectToAction("products");
            }
        }

        // GET: BODE_PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BODE_PRODUCTO bODE_PRODUCTO = db.BODE_PRODUCTO.Find(id);
            if (bODE_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(bODE_PRODUCTO);
        }

        // POST: BODE_PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Nombre,Marca,Modelo,Categoria,Existencia,PrecioVenta,PrecioCompra")] BODE_PRODUCTO bODE_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bODE_PRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bODE_PRODUCTO);
        }

        // GET: BODE_PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BODE_PRODUCTO bODE_PRODUCTO = db.BODE_PRODUCTO.Find(id);
            if (bODE_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(bODE_PRODUCTO);
        }

        // POST: BODE_PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BODE_PRODUCTO bODE_PRODUCTO = db.BODE_PRODUCTO.Find(id);
            db.BODE_PRODUCTO.Remove(bODE_PRODUCTO);
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
