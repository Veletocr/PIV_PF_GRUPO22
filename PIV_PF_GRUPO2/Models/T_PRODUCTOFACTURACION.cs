//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PIV_PF_GRUPO2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_PRODUCTOFACTURACION
    {
        public int ID_PRODUCTOFACTURACION { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_FACTURACION { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
        public virtual T_FACTURACION T_FACTURACION { get; set; }
    }
}
