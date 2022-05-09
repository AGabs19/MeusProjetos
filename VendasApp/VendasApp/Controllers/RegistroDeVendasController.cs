using Microsoft.AspNetCore.Mvc;
using VendasApp.Services;

namespace VendasApp.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendaService _registroDeVendaService;
        public RegistroDeVendasController(RegistroDeVendaService registroDeVendaService)
        {
            _registroDeVendaService = registroDeVendaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minData, DateTime? maxData) //Agrupamento Simples
        {
            if (!minData.HasValue) //Se a Data não for passada, quero que use a Data do inicio do ano ATUAl, ou seja o que estamos agora.
            {
                minData = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxData.HasValue) //Mesma coisa aqui, só que o limite é o DIA que estamos
            {
                maxData = DateTime.Now;
            }
            //Agora vou passar para minha View
            ViewData["minData"] = minData.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = minData.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendaService.FindByDateAsync(minData, maxData);
            return View(result);
        }
        public IActionResult GroupingSearch() //Pesquisa de agrupamento
        {
            return View();
        }
    }
}
