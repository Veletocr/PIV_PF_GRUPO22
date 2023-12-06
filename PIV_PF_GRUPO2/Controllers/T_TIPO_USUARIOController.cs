using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIV_PF_GRUPO2.Models;

namespace PIV_PF_GRUPO2.Controllers
{
    public class T_TIPO_USUARIOController : Controller
    {

        static string cn = "Data Source=LAPTOP-FFB16GOE;Initial Catalog=PIV_PF_ProyectoFinal;Integrated Security=True;TrustServerCertificate=True";

        private PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4();

        // GET: T_TIPO_USUARIO
        public ActionResult Index()
        {
            return View(db.T_TIPO_USUARIO.ToList());
        }
 
        

        // GET: T_TIPO_USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TIPO_USUARIO t_TIPO_USUARIO = db.T_TIPO_USUARIO.Find(id);
            if (t_TIPO_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(t_TIPO_USUARIO);
        }

        // GET: T_TIPO_USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_TIPO_USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tipo_USUARIO,TIPO_USUARIO")] T_TIPO_USUARIO t_TIPO_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.T_TIPO_USUARIO.Add(t_TIPO_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_TIPO_USUARIO);
        }

        // GET: T_TIPO_USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TIPO_USUARIO t_TIPO_USUARIO = db.T_TIPO_USUARIO.Find(id);
            if (t_TIPO_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(t_TIPO_USUARIO);
        }

        // POST: T_TIPO_USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tipo_USUARIO,TIPO_USUARIO")] T_TIPO_USUARIO t_TIPO_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_TIPO_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_TIPO_USUARIO);
        }

        // GET: T_TIPO_USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_TIPO_USUARIO t_TIPO_USUARIO = db.T_TIPO_USUARIO.Find(id);
            if (t_TIPO_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(t_TIPO_USUARIO);
        }

        // POST: T_TIPO_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        
        {


            T_TIPO_USUARIO t_TIPO_USUARIO = db.T_TIPO_USUARIO.Find(id);
            db.T_TIPO_USUARIO.Remove(t_TIPO_USUARIO);
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
