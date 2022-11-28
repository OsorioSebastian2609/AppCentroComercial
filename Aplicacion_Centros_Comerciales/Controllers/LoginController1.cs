using Microsoft.AspNetCore.Mvc;
using Aplicacion_Centros_Comerciales.Models;


namespace Aplicacion_Centros_Comerciales.Controllers
{
    public class LoginController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult LoginViewdos()
        
        {
            return View("Formulario");
        }
        [HttpPost]  
        public ActionResult Datos(string Correo, string contraseña)
        {
            UsuarioModel Usuario = new UsuarioModel();
            if((Usuario.Correo==Correo) &&(Usuario.Contraseña==contraseña))
            {
                return View();
            }
            else
            {
                return View();
            }
            return View();
        }
        

    }
}
