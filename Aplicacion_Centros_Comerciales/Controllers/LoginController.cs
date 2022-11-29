using Aplicacion_Centros_Comerciales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion_Centros_Comerciales.Controllers
{
    public class LoginController : Controller
    {

        UsuarioModel Usuario = new UsuarioModel();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult LoginViewdos()
        
        {
            return View("Formulario");
        }
        [HttpPut]
        public ActionResult Update(string usuario, string nombre, string correo)
        {
            var estado = Negocio.Perfil.ActualizarPerfil(usuario, nombre, correo);
            if (estado != "1")
            {
                return RedirectToAction("Perfil", estado);
            }
            else
            {
                Usuario.Nombre = nombre;
                Usuario.Correo = correo;
                return RedirectToAction("perfil", Usuario);
            }
        }


        public ActionResult Perfil()
        {

            /*   if(Usuario != null)
               {
                   return RedirectToAction("/login/LoginViewdos");
               }
               else
               {
                   return View(Usuario);
               }
                */
            return View();
        }

        public ActionResult Registrar()
        {

            return View();
        }

        [HttpPost]  
        public ActionResult Datos(string usuario, string contraseña)
        {
            
            var usuario_validado = Negocio.Perfil.ValidarPerfil(usuario, contraseña); 
            if (usuario_validado != null)
            {
                Usuario.Username = usuario_validado.Username;
                Usuario.Nombre = usuario_validado.Nombre;
                Usuario.Correo = usuario_validado.Correo;
                return RedirectToAction("/home/index", User);
            }
            else
            {
                return View();
            }
        }
    }
}
