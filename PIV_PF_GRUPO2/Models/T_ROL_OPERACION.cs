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
    
    public partial class T_ROL_OPERACION
    {
        public int ID_ROL_OPERACION { get; set; }
        public string ID_TIPO_USUARIO { get; set; }
        public int ID_ACCIONES { get; set; }
        public Nullable<int> ID_ESTADOUSUARIO { get; set; }
    
        public virtual T_ACCIONES T_ACCIONES { get; set; }
        public virtual T_ESTADO_USUARIO T_ESTADO_USUARIO { get; set; }
        public virtual T_TIPO_USUARIO T_TIPO_USUARIO { get; set; }
    }
}
