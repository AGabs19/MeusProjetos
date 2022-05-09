using Microsoft.AspNetCore.Mvc;

namespace VendasApp.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SimpleSearch() //Agrupamento Simples
        {
            return View();
        }
        public IActionResult GroupingSearch() //Pesquisa de agrupamento
        {
            return View();
        }
    }
}
