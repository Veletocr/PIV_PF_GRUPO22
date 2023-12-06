using PIV_PF_GRUPO2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace PIV_PF_GRUPO2.Permisos
{
  
        public enum Rol
        {

            Administrador = 30,
            Vendedor = 31,
            Contabilidad = 32,
        }



        public class LO_USUARIO
        {
            static string cadenas = "Data Source=LAPTOP-FFB16GOE;Initial Catalog=PIV_PF_ProyectoFinal;Integrated Security=True;TrustServerCertificate=True";

            public T_USUARIO EncontrarUsuario(T_USUARIO oTUsuario)
            {
                T_USUARIO objeto = new T_USUARIO();
                using (SqlConnection cn = new SqlConnection(cadenas))
                {
                    using (SqlCommand cmd2 = new SqlCommand("sp_ObtenerDatosUsuarioPorID", cn))
                    {

                        cmd2.Parameters.AddWithValue("@ID_USUARIO", oTUsuario.ID_USUARIOS);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataReader dr = cmd2.ExecuteReader())
                        {

                            while (dr.Read())
                            {

                                objeto = new T_USUARIO()
                                {
                                    NOMBRE_USUARIO = dr["NOMBRE_USUARIO"].ToString(),
                                    EMAIL = dr["EMAIL"].ToString(),
                                    CLAVE = dr["CLAVE"].ToString(),
                                    TIPO_USUARIO = (string)dr["TIPO_USUARIO"]



                                };

                            }

                        }

                    }
                    return objeto;
                }





            }





        }


    
}