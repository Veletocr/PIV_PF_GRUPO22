using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PIV_PF_GRUPO2.Models;
using PIV_PF_GRUPO2.Permisos;
using System.Web.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace PIV_PF_GRUPO2.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        static string cadena = "Data Source=LAPTOP-FFB16GOE;Initial Catalog=PIV_PF_ProyectoFinal;Integrated Security=True;TrustServerCertificate=True";

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registrar(T_USUARIO oTUsuario)
        {
            bool registrado;
            string mensaje;
            if (oTUsuario.CLAVE == oTUsuario.CONFIRMARCLAVE)
            {
                oTUsuario.CLAVE = ConvertirSha256(oTUsuario.CLAVE);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection cn = new SqlConnection(cadena))
            {

    
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
                try
                {
                    cmd.Parameters.AddWithValue("NOMBRE_USUARIO", oTUsuario.NOMBRE_USUARIO);
                    cmd.Parameters.AddWithValue("EMAIL", oTUsuario.EMAIL);
                    cmd.Parameters.AddWithValue("TIPO_USUARIO", oTUsuario.TIPO_USUARIO);
                    cmd.Parameters.AddWithValue("ESTADO_USUARIO", oTUsuario.ESTADO_USUARIO);
                    cmd.Parameters.AddWithValue("CLAVE", oTUsuario.CLAVE);
                    cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) 
                {
                }
            
                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                try
                {
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    ViewData["Mensaje"] = mensaje;
                }
                catch(Exception ex)
                {

                }
          
            }
            if (registrado)
            {
  
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }



        }


        [HttpPost]
        public ActionResult Login(T_USUARIO oTUsuario)
        {
            oTUsuario.CLAVE = ConvertirSha256(oTUsuario.CLAVE);
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn))
                {
                    cmd.Parameters.AddWithValue("Email", oTUsuario.EMAIL);
                    cmd.Parameters.AddWithValue("Clave", oTUsuario.CLAVE);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    oTUsuario.ID_USUARIOS = Convert.ToInt32(cmd.ExecuteScalar().ToString());


                    if (oTUsuario.ID_USUARIOS != 0)
                    {

                        T_USUARIO objeto = new LO_USUARIO().EncontrarUsuario(oTUsuario);

                        if (objeto.NOMBRE_USUARIO != null)
                        {
                            FormsAuthentication.SetAuthCookie(objeto.EMAIL, false);
                            Session["Usuario"] = objeto;
                            return RedirectToAction("Index", "Home");
                        }


                        return RedirectToAction("Index", "Home");


                    }
                    else
                    {
                        ViewData["Mensaje"] = "Usuario no encontrado";
                        return View();
                    }
                }

            }





        }





        public static string ConvertirSha256(string texto)
        
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
 
            using (SHA256 hash = SHA256.Create())
                {
                try
                {
                    Encoding enc = Encoding.UTF8;
                    byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                    foreach (byte b in result)
                        Sb.Append(b.ToString("x2"));

                }catch(Exception ex) { }

                }
                return Sb.ToString();
       


           
        }




    }

}
