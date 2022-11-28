using Aplicacion_Centros_Comerciales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aplicacion_Centros_Comerciales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var CentrosComerciales = new CentroComercialModel();
            CentrosComerciales.CentrosComerciales = Negocio.Centros_Comerciales.Centros_Comerciales_Activos();
            return View(CentrosComerciales);
          
        }

      
        public IActionResult GetTiendas(long id, string Nombre)
        {
            try {
                var Tiendas = new TiendasModel();
                Tiendas.Tiendas = Negocio.Tiendas.ListarTiendas(id);
                Tiendas.NombreCentroComercial = Nombre;
                return Json(Tiendas);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}