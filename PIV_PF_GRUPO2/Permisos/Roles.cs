using PIV_PF_GRUPO2.Models;
using PIV_PF_GRUPO2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
namespace PIV_PF_GRUPO2.Permisos
{

    public class PermisosRolAttribute : ActionFilterAttribute
    {
        private Rol idrol;

        public PermisosRolAttribute(Rol _idrol)
        {
            idrol = _idrol;
        }

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] != null)
            {

                T_USUARIO usuario = HttpContext.Current.Session["Usuario"] as T_USUARIO;


                if (usuario.TIPO_USUARIO != Convert.ToString(this.idrol))
                {

                    filterContext.Result = new RedirectResult("~/Home/Sinpermisost");

                }


            }
            base.OnActionExecuting(filterContext);


        }







    }





}