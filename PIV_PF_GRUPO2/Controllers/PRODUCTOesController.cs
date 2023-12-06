using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIV_PF_GRUPO2.Models;

namespace PIV_PF_GRUPO2.Controllers
{
    public class PRODUCTOesController : Controller
    {
        private PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4();

        // GET: PRODUCTOes
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.ESTADO_PRODUCTO);
            return View(pRODUCTO.ToList());
        }

        // GET: PRODUCTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.ESTADO_PRODUCTO, "ID_ESTADO_PRODUCTO", "ID_ESTADO_PRODUCTO");
            return View();
        }





        // POST: PRODUCTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,DESCRIPCION,PRECIO_PRODUCTO,ID_ESTADO_PRODUCTO,CANTIDAD_STOCK,ID_TIPO_PRODUCTO")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.ESTADO_PRODUCTO, "ID_ESTADO_PRODUCTO", "ID_ESTADO_PRODUCTO", pRODUCTO.ID_TIPO_PRODUCTO);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.ESTADO_PRODUCTO, "ID_ESTADO_PRODUCTO", "ID_ESTADO_PRODUCTO", pRODUCTO.ID_TIPO_PRODUCTO);
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,DESCRIPCION,PRECIO_PRODUCTO,ID_ESTADO_PRODUCTO,CANTIDAD_STOCK,ID_TIPO_PRODUCTO")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.ESTADO_PRODUCTO, "ID_ESTADO_PRODUCTO", "ID_ESTADO_PRODUCTO", pRODUCTO.ID_TIPO_PRODUCTO);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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
