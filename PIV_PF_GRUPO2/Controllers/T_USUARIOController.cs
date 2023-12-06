using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PIV_PF_GRUPO2.Models;

namespace PIV_PF_GRUPO2.Controllers
{
    public class T_USUARIOController : Controller
    {
        static string cadena = "Data Source=LAPTOP-FFB16GOE;Initial Catalog=PIV_PF_ProyectoFinal;Integrated Security=True;TrustServerCertificate=True";

        private PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4();

        // GET: T_USUARIO




        public ActionResult Index()
        {


            IQueryable<T_USUARIO> t_USUARIO = db.T_USUARIO.Include(t => t.T_ADMINISTRADOR).Include(t => t.T_TIPO_USUARIO);
            return View(t_USUARIO.ToList());
        }



        // GET: T_USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_USUARIO t_USUARIO = db.T_USUARIO.Find(id);
            if (t_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(t_USUARIO);
        }

        // GET: T_USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.ID_USUARIOS = new SelectList(db.T_ADMINISTRADOR, "ID_ADMINISTRADOR", "NOMBRE_USUARIO");
            ViewBag.TIPO_USUARIO = new SelectList(db.T_TIPO_USUARIO, "ID_Tipo_USUARIO", "TIPO_USUARIO");
            return View();
        }

        // POST: T_USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIOS,NOMBRE_USUARIO,EMAIL,TIPO_USUARIO,ESTADO_USUARIO,CLAVE,CONFIRMARCLAVE")] T_USUARIO t_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.T_USUARIO.Add(t_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USUARIOS = new SelectList(db.T_ADMINISTRADOR, "ID_ADMINISTRADOR", "NOMBRE_USUARIO", t_USUARIO.ID_USUARIOS);
            ViewBag.TIPO_USUARIO = new SelectList(db.T_TIPO_USUARIO, "ID_Tipo_USUARIO", "TIPO_USUARIO", t_USUARIO.TIPO_USUARIO);
            return View(t_USUARIO);
        }

        // GET: T_USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_USUARIO t_USUARIO = db.T_USUARIO.Find(id);
            if (t_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USUARIOS = new SelectList(db.T_ADMINISTRADOR, "ID_ADMINISTRADOR", "NOMBRE_USUARIO", t_USUARIO.ID_USUARIOS);
            ViewBag.TIPO_USUARIO = new SelectList(db.T_TIPO_USUARIO, "ID_Tipo_USUARIO", "TIPO_USUARIO", t_USUARIO.TIPO_USUARIO);
            return View(t_USUARIO);
        }

        // POST: T_USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIOS,NOMBRE_USUARIO,EMAIL,TIPO_USUARIO,ESTADO_USUARIO,CLAVE,CONFIRMARCLAVE")] T_USUARIO t_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USUARIOS = new SelectList(db.T_ADMINISTRADOR, "ID_ADMINISTRADOR", "NOMBRE_USUARIO", t_USUARIO.ID_USUARIOS);
            ViewBag.TIPO_USUARIO = new SelectList(db.T_TIPO_USUARIO, "ID_Tipo_USUARIO", "TIPO_USUARIO", t_USUARIO.TIPO_USUARIO);
            return View(t_USUARIO);
        }

        // GET: T_USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_USUARIO t_USUARIO = db.T_USUARIO.Find(id);
            if (t_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(t_USUARIO);
        }

        // POST: T_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_USUARIO t_USUARIO = db.T_USUARIO.Find(id);
            db.T_USUARIO.Remove(t_USUARIO);
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
