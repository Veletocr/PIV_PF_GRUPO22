using Microsoft.AspNetCore.Mvc;
using PIV_PF_GRUPO2.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace PIV_PF_GRUPO2.Controllers
{
    [ValidaeSesion]
   
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [PermisosRolAttribute(Rol.Administrador)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sinpermisost()
        {
            ViewBag.Message = "Usted no cuenta con permisos para ver esta pagina";

            return View();
        }

        public ActionResult NopuedeBorrar()
        {
            ViewBag.Message = "No puede borrar este item, solicite ayuda";

            return View();
        }








        public ActionResult CerrarSesion()
        {
            ViewData["usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }
    }
}