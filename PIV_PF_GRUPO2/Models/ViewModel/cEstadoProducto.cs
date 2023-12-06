using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIV_PF_GRUPO2.Models.ViewModel
{
    public class cEstadoProducto
    {

        public int IdProducto  { get; set; }


        [Required]
        [Display(Name = "Escoja un Estado del Producto")]
        public string EstadoProducto{ get;}


    }
}