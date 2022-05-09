using Microsoft.AspNetCore.Mvc;
using VendasApp.Models;
using VendasApp.Services;
using VendasApp.Models.ViewModels;
using VendasApp.Services.Exceptions;
using System.Diagnostics;

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
            if (!ModelState.IsValid) //Se NÃO for validado meu modelo, então retorna meu obj, até o usuario preencher direitinho a View!
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
            // return RedirectToAction("Index"); //Estou redirecionando para minha tela posso escrever desse jeito tambem!
        }
        public IActionResult Delete(int? id) // ? significa que é opcional 
        {
            if (id == null) //Se o Id for nulo, a pessoa fez a requisição de um jeito errado!
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" }); //Lembrar de personalizar o aviso do erro
            }

            var obj = _vendedorService.FindById(id.Value); //Ele é um valor opcional

            if (obj == null) //Se o Id não existir
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
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
        public IActionResult Details(int? id) //LOgica muito parecida com o Delete
        {
            if (id == null) //Se o Id for nulo, a pessoa fez a requisição de um jeito errado!
            {
                return RedirectToAction(nameof(Error), new {message = "Id não foi fornecido"}); //Lembrar de personalizar o aviso do erro
            }

            var obj = _vendedorService.FindById(id.Value); //Ele é um valor opcional

            if (obj == null) //Se o Id não existir
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            //Se até aqui tudo deu certo, eu quero que retorne esse obj 
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) //Testando se existe 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null) //Testando se existe 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            //Se passar pelos if, vou abrir a tela de edição:

            List<Departamento> departamentos = _departamentoService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos }; //Obj é o obj que buscamos no banco de dados (escrito logo acima no if)
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Vendedor vendedor)
        {
            if (!ModelState.IsValid) //Se NÃO for validado meu modelo, então retorna meu obj, até o usuario preencher direitinho a View!
            {
                var departamentos = _departamentoService.FindAll();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id) //Quando o Id for diferente
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _vendedorService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e) //Para não repetir as duas, chamei uma super Exception e dei um apelido para ela
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

            //catch (NotFoundException e) //Minhas Exception personalizadas
            //{
            //    return RedirectToAction(nameof(Error), new { message = e.Message });
            //}
            //catch (DbConcurrencyException e) //Se tambem ocorrer essa Excepition
            //{
            //    return RedirectToAction(nameof(Error), new { message = e.Message });
            //}
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel //Instanciei
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //É uma forma de solicitar o Id interno da requisição
                // ?? == Se ele for nulo quero no lugar o HttpContext.TraceIdentifier 
            };
            return View(viewModel);
        }
    }
}
