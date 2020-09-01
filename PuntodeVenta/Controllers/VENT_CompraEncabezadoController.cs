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
    public class VENT_CompraEncabezadoController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();

        public ActionResult sales()
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                ViewBag.Idproveedor = new SelectList(db.VENT_Proveedor, "IdEmpresa", "Nombre");
                return View(db.VENT_CompraEncabezado.ToList());
            }
        }


        public ActionResult Index()
        {
            var vENT_CompraEncabezado = db.VENT_CompraEncabezado.Include(v => v.RRHH_Usuario).Include(v => v.VENT_Proveedor);
            return View(vENT_CompraEncabezado.ToList());
        }


        // GET: VENT_CompraEncabezado/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_CompraEncabezado vENT_CompraEncabezado = db.VENT_CompraEncabezado.Find(id);
            if (vENT_CompraEncabezado == null)
            {
                return HttpNotFound();
            }
            return View(vENT_CompraEncabezado);
        }

        // GET: VENT_CompraEncabezado/Create
        public ActionResult Create()
        {
            ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña");
            ViewBag.Idproveedor = new SelectList(db.VENT_Proveedor, "IdEmpresa", "Nombre");
            return View();
        }

        // POST: VENT_CompraEncabezado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idproveedor,Fecha,NumeroFactura,Total")] VENT_CompraEncabezado vENT_CompraEncabezado)
        {
            if (Session["usuario"] == null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {

                vENT_CompraEncabezado.UserSystem = Convert.ToString(Session["usuario"]);
                vENT_CompraEncabezado.Estado = "Sin Datos";
                if (ModelState.IsValid)
                {
                    db.VENT_CompraEncabezado.Add(vENT_CompraEncabezado);
                    db.SaveChanges();
                    return RedirectToAction("sales");
                }

                ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña", vENT_CompraEncabezado.UserSystem);
                ViewBag.Idproveedor = new SelectList(db.VENT_Proveedor, "IdEmpresa", "Nombre", vENT_CompraEncabezado.Idproveedor);
                return RedirectToAction("sales");
            }
        }

        // GET: VENT_CompraEncabezado/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_CompraEncabezado vENT_CompraEncabezado = db.VENT_CompraEncabezado.Find(id);
            if (vENT_CompraEncabezado == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña", vENT_CompraEncabezado.UserSystem);
            ViewBag.Idproveedor = new SelectList(db.VENT_Proveedor, "IdEmpresa", "Nombre", vENT_CompraEncabezado.Idproveedor);
            return View(vENT_CompraEncabezado);
        }

        // POST: VENT_CompraEncabezado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idproveedor,Fecha,NumeroFactura,UserSystem")] VENT_CompraEncabezado vENT_CompraEncabezado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENT_CompraEncabezado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserSystem = new SelectList(db.RRHH_Usuario, "usuario", "contraseña", vENT_CompraEncabezado.UserSystem);
            ViewBag.Idproveedor = new SelectList(db.VENT_Proveedor, "IdEmpresa", "Nombre", vENT_CompraEncabezado.Idproveedor);
            return View(vENT_CompraEncabezado);
        }

        // GET: VENT_CompraEncabezado/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENT_CompraEncabezado vENT_CompraEncabezado = db.VENT_CompraEncabezado.Find(id);
            if (vENT_CompraEncabezado == null)
            {
                return HttpNotFound();
            }
            return View(vENT_CompraEncabezado);
        }

        // POST: VENT_CompraEncabezado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VENT_CompraEncabezado vENT_CompraEncabezado = db.VENT_CompraEncabezado.Find(id);
            db.VENT_CompraEncabezado.Remove(vENT_CompraEncabezado);
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
