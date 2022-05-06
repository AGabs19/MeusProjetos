using Microsoft.AspNetCore.Mvc;
using VendasApp.Models;
using VendasApp.Services;
using VendasApp.Models.ViewModels;

namespace VendasApp.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;
        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index() //Ele vai chamar a operação FindAll do meu Vendedor Service!
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }
        public IActionResult Create() //Metodo que vai abrir meu formulario para cadastro de novos vendedores
        {
            var departamentos = _departamentoService.FindAll(); //Para ele buscar no banco de dados todos os departamentos!
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos }; //É o que tem no View Model, departamentos e vendedor;
            return View(viewModel);// Pedindo retorno da lista de Departamentos 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
           // return RedirectToAction("Index"); //Estou redirecionando para minha tela posso escrever desse jeito tambem!
        }
        public IActionResult Delete(int? id) // ? significa que é opcional 
        {
            if (id == null) //Se o Id for nulo, a pessoa fez a requisição de um jeito errado!
            {
                return NotFound(); //Lembrar de personalizar o aviso do erro
            }

            var obj = _vendedorService.FindById(id.Value); //Ele é um valor opcional

            if( obj == null) //Se o Id não existir
            {
                return NotFound();
            }
            //Se até aqui tudo deu certo, eu quero que retorne esse obj 
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index)); //Para redirecionar
        }
    }
}
