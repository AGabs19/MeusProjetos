using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasApp.Models.ViewModels;
using VendasApp.DataBase;
using VendasApp.DataBase;

namespace VendasApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VendasAppContext _vendasAppContext;

        private readonly PopularService _popularService;
        public HomeController(ILogger<HomeController> logger, PopularService popularService, VendasAppContext vendasAppContext )
        {
            _logger = logger;
            _popularService = popularService;
            _vendasAppContext = vendasAppContext;
        }

        public async Task <IActionResult> Index()
        {
            return View();
        }
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Salvar(PopularService _popularService)
        {
            if (ModelState.IsValid)
            {
                _vendasAppContext.Add(_popularService);
                await _vendasAppContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                  
            }
            return View(_popularService);
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