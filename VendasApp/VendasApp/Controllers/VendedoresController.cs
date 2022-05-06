using Microsoft.AspNetCore.Mvc;
using VendasApp.Models;
using VendasApp.Services;

namespace VendasApp.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        public VendedoresController(VendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }
        public IActionResult Index() //Ele vai chamar a operação FindAll do meu Vendedor Service!
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
           // return RedirectToAction("Index"); //Estou redirecionando para minha tela posso escrever desse jeito tambem!
        }
    }
}
