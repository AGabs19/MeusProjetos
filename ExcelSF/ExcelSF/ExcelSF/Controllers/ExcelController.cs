using Microsoft.AspNetCore.Mvc;
using System.Data;
using AppContext = ExcelSF.DataBase.AppContext;
using ExcelSF.Services;
using System.IO;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using ExcelSF.Services.Exceptions;
using ExcelSF.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelSF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : Controller
    {
        private readonly ILogger<ExcelController> _logger;
        private readonly IExcelService services; //this.service
        private readonly AppContext conexao; //this.conexao
        
        public ExcelController(ILogger<ExcelController> logger, IExcelService services, AppContext conexao) //ExcelService excelService
        {
            _logger = logger;
            this.services = services;
            this.conexao = conexao;
        }
        [HttpPost]
        public ActionResult PegarArquivo(IFormFile arquivo)
        {
            if (!ModelState.IsValid) //Quando o modelo NÃO for valido!
            {
                return StatusCode(StatusCodes.Status204NoContent, "Por Favor selecione um modelo valido!");
            }
            this.services.Excel(arquivo);
            return StatusCode(StatusCodes.Status200OK, "Executado com sucesso!");
        }


        //O CODIGO ABAIXO EU ESCREVI PARA FAZER REQUISIÇÕA SEPARADA!!!
        //[HttpGet]
        //public ActionResult LocalizarID(long id)
        //{
        //    var list = this.services.FindById(id);
        //    return StatusCode(StatusCodes.Status200OK, "Id encontrado");
        //}
        //[HttpDelete]
        //public ActionResult DeletarArquivo(long? id)
        //{
        //    if (id == null) //Se o Id for nulo, passou de um jeito errado
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
        //    }

        //    var obj = this.services.FindById(id.Value); //FindById para localizar pelo Id e como declarei que pode ser nulo ? eu uso o .Value

        //    if (obj == null) //Se ele já não existir
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "Id não encontrado!");
        //    }
            
        //    try
        //    {
        //        this.services.Delete(id.Value);
        //        return StatusCode(StatusCodes.Status200OK, "Funcionario Deletado"); //Se tudo der certo até aqui, quero que me retorne isso!
        //    }
        //    catch(IntegrityException e)
        //    {
        //        throw new IntegrityException(e.Message);
        //    } 
        //} 

        //[HttpPut]
        //public ActionResult AtualizarArquivo(long? id, Funcionario funcionario)
        //{
        //    if (!ModelState.IsValid) //Se o modelo não for valido, quero que me retorne isso!
        //    {
        //        return StatusCode(StatusCodes.Status200OK, "Id não fornecido");
        //        //return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
        //    }

        //    if (id != funcionario.Id) //se o id for diferente!
        //    {
        //        return StatusCode(StatusCodes.Status200OK, "id não corresponde");

        //        //return statuscode(statuscodes.status204nocontent, "id não corresponde");
        //    }

        //    if (id == null) //Se o Id for nulo, passou de um jeito errado
        //    {
        //        return StatusCode(StatusCodes.Status200OK, "Id não fornecido");
        //        //return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
        //    }
        //    var obj = this.services.FindById(id.Value);

        //    if (obj == null) //Se ele já não existir
        //    {
        //        return StatusCode(StatusCodes.Status200OK, "Id não encontrado!");
        //        //return StatusCode(StatusCodes.Status204NoContent, "Id não encontrado!");
        //    }
        //    try
        //    {
        //        this.services.Update(funcionario);
        //        return StatusCode(StatusCodes.Status200OK, "Funcionario alterado com sucesso!");
        //    }
        //    catch (NotFoundException e)
        //    {
        //        throw new DbConcurrencyException(e.Message); //São as excepetion personalizadas que criei!
        //    }
        //    catch (DbConcurrencyException e)
        //    {
        //        throw new DbConcurrencyException(e.Message);
        //    }
        //}
    }
}