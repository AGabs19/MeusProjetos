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
        public async Task<IActionResult> Index() //Ele vai chamar a operação FindAll do meu Vendedor Service!
        {
            var list = await _vendedorService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create() //Metodo que vai abrir meu formulario para cadastro de novos vendedores
        {
            var departamentos = await _departamentoService.FindAllAsync(); //Para ele buscar no banco de dados todos os departamentos!
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos }; //É o que tem no View Model, departamentos e vendedor;
            return View(viewModel);// Pedindo retorno da lista de Departamentos 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid) //Se NÃO for validado meu modelo, então retorna meu obj, até o usuario preencher direitinho a View!
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorService.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
            // return RedirectToAction("Index"); //Estou redirecionando para minha tela posso escrever desse jeito tambem!
        }
        public async Task<IActionResult> Delete(int? id) // ? significa que é opcional 
        {
            if (id == null) //Se o Id for nulo, a pessoa fez a requisição de um jeito errado!
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" }); //Lembrar de personalizar o aviso do erro
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value); //Ele é um valor opcional

            if (obj == null) //Se o Id não existir
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            //Se até aqui tudo deu certo, eu quero que retorne esse obj 
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vendedorService.RemoveAsync(id);
                return RedirectToAction(nameof(Index)); //Para redirecionar
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public async Task<IActionResult> Details(int? id) //LOgica muito parecida com o Delete
        {
            if (id == null) //Se o Id for nulo, a pessoa fez a requisição de um jeito errado!
            {
                return RedirectToAction(nameof(Error), new {message = "Id não foi fornecido"}); //Lembrar de personalizar o aviso do erro
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value); //Ele é um valor opcional

            if (obj == null) //Se o Id não existir
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            //Se até aqui tudo deu certo, eu quero que retorne esse obj 
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) //Testando se existe 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null) //Testando se existe 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            //Se passar pelos if, vou abrir a tela de edição:

            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos }; //Obj é o obj que buscamos no banco de dados (escrito logo acima no if)
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Vendedor vendedor)
        {
            if (!ModelState.IsValid) //Se NÃO for validado meu modelo, então retorna meu obj, até o usuario preencher direitinho a View!
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id) //Quando o Id for diferente
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                await _vendedorService.UpdateAsync(vendedor);
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
