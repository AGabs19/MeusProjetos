using Microsoft.AspNetCore.Mvc;

namespace VendasApp.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
