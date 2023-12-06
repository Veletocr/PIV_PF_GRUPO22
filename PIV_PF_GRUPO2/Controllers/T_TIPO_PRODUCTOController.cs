using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PIV_PF_GRUPO2.Models;

namespace PIV_PF_GRUPO2.Controllers
{
    public class T_TIPO_PRODUCTOController : Controller
    {
        private PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4();

        // GET: T_TIPO_PRODUCTO
        public ActionResult Index()
        {
            var t_TIPO_PRODUCTO = db.T_TIPO_PRODUCTO.Include(t => t.T_ADMINISTRADOR);
            return View(t_TIPO_PRODUCTO.ToList());
        }

        // GET: T_TIPO_PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TIPO_PRODUCTO t_TIPO_PRODUCTO = db.T_TIPO_PRODUCTO.Find(id);
            if (t_TIPO_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(t_TIPO_PRODUCTO);
        }

        // GET: T_TIPO_PRODUCTO/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.T_ADMINISTRADOR, "ID_ADMINISTRADOR", "NOMBRE_USUARIO");
            return View();
        }

        // POST: T_TIPO_PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPO_PRODUCTO,TIPO_PRODUCTO,DESCRIPCION,ID_PRODUCTO")] T_TIPO_PRODUCTO t_TIPO_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.T_TIPO_PRODUCTO.Add(t_TIPO_PRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPO_PRODUCTO = new SelectList(db.T_ADMINISTRADOR, "ID_ADMINISTRADOR", "NOMBRE_USUARIO", t_TIPO_PRODUCTO.ID_TIPO_PRODUCTO);
            return View(t_TIPO_PRODUCTO);
        }

        // GET: T_TIPO_PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            T_TIPO_PRODUCTO t_TIPO_PRODUCTO = db.T_TIPO_PRODUCTO.Find(id);
            if (t_TIPO_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(t_TIPO_PRODUCTO);
        }

        // POST: T_TIPO_PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPO_PRODUCTO,TIPO_PRODUCTO,DESCRIPCION,ID_PRODUCTO")] T_TIPO_PRODUCTO t_TIPO_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_TIPO_PRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_TIPO_PRODUCTO);
        }

        // GET: T_TIPO_PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            T_TIPO_PRODUCTO t_TIPO_PRODUCTO = db.T_TIPO_PRODUCTO.Find(id);
            if (t_TIPO_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(t_TIPO_PRODUCTO);
        }

        // POST: T_TIPO_PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
                T_TIPO_PRODUCTO t_TIPO_PRODUCTO = db.T_TIPO_PRODUCTO.Find(id);
            try{


                if (t_TIPO_PRODUCTO.ID_PRODUCTO > 0)
                {
                   
                    return RedirectToAction("NopuedeBorrar", "Home");
                }                            
                    db.T_TIPO_PRODUCTO.Remove(t_TIPO_PRODUCTO);
                    db.SaveChanges();              
               
            }catch(FormatException e)
            {


            }
              
           
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
