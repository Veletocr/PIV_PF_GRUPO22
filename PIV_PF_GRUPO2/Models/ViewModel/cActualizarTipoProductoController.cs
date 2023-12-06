using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace PIV_PF_GRUPO2.Models.ViewModel
{
    public class cActualizarTipoProductoController : Controller
    {
        public class cActualizarTipoProduct
        {
            [Required]
            [Display(Name = "CodigoTipoProducto")]
            public string CodigoTipoProducto { get; set; }


            [Required]
            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }
        }




    }
}