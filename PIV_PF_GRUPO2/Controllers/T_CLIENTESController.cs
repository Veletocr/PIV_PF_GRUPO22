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
using PIV_PF_GRUPO2.Permisos;

namespace PIV_PF_GRUPO2.Controllers
{
    [PermisosRolAttribute(Rol.Administrador)]
    public class T_CLIENTESController : Controller
    {

        static string cadena = "Data Source=LAPTOP-FFB16GOE;Initial Catalog=PIV_PF_ProyectoFinal;Integrated Security=True;TrustServerCertificate=True";

        private PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4();

        // GET: T_CLIENTES
        public ActionResult Index()
        {
            return View(db.T_CLIENTE.ToList());
        }

        // GET: T_CLIENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CLIENTE t_CLIENTE = db.T_CLIENTE.Find(id);
            if (t_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(t_CLIENTE);
        }

        // GET: T_CLIENTES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_CLIENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLIENTE,NOMBRECLIENTE,EMAIL")] T_CLIENTE t_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.T_CLIENTE.Add(t_CLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_CLIENTE);
        }

        // GET: T_CLIENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CLIENTE t_CLIENTE = db.T_CLIENTE.Find(id);
            if (t_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(t_CLIENTE);
        }

        // POST: T_CLIENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLIENTE,NOMBRECLIENTE,EMAIL")] T_CLIENTE t_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_CLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_CLIENTE);
        }

        // GET: T_CLIENTES/Delete/5
        public ActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_CLIENTE t_CLIENTE = db.T_CLIENTE.Find(id);
            if (t_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(t_CLIENTE);
        }

        // POST: T_CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4())
            {
                int ID_CLIENTE = (int)id;
                if(Convert.ToBoolean(db.T_FACTURACION.Where(x => x.ID_CLIENTE == ID_CLIENTE)))
                {
                    T_CLIENTE t_CLIENTE = db.T_CLIENTE.Find(id);
                    db.T_CLIENTE.Remove(t_CLIENTE);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }


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
