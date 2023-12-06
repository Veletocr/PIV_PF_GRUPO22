using PIV_PF_GRUPO2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIV_PF_GRUPO2.Permisos
{
    public class ValidaeSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {

                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

            base.OnActionExecuting(filterContext);
        }


    }
    public class UserExistAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (PIV_PF_ProyectoFinalEntities4 db = new PIV_PF_ProyectoFinalEntities4())
            {
                string email = (string)value;

                if (db.T_CLIENTE.Where(x => x.EMAIL == email).Count() > 0)
                {
                    return new ValidationResult("Correo ya existe");
                }

            }

            return ValidationResult.Success;
        }

    }











}