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
        //public ActionResult Index()
        //{
        //    var list = this.services.FindAll();
        //    return View(list);
        //}

        [HttpPost]
        public ActionResult PegarArquivo(IFormFile arquivo)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
            }
            this.services.Insert(arquivo);
            return StatusCode(StatusCodes.Status200OK, "Executado com sucesso!");
        }
        //public ActionResult DeletarArquivo(long? id)
        //{
        //    if (id == null) //Se o Id for nulo, passou de um jeito errado
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
        //    }
        //    var obj = this.services.FindById(id.Value);
        //    if (obj == null) //Se ele já não existir
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "Id não encontrado!");
        //    }
        //    return View(obj); //Se tudo deu certo até aqui, quero que me retorne isso!
        //}

        [HttpPut]
        public ActionResult DeletarArquivo(long id)
        {
            try
            {
                this.services.Delete(id);
                return StatusCode(StatusCodes.Status200OK, "Funcionario Deletado");
            }
            catch(IntegrityException e)
            {
                throw new IntegrityException(e.Message);
            }

        }
        //public ActionResult AtualizarArquivo(long? id)
        //{
        //    if (id == null) //Se o Id for nulo, passou de um jeito errado
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
        //    }

        //    var obj = this.services.FindById(id.Value);

        //    if (obj == null) //Se ele já não existir
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "Id não encontrado!");
        //    }
        //    return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido"); ;
        //}
        [HttpDelete]
        public ActionResult AtualizarArquivo(long id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status204NoContent, "Id não fornecido");
            }

            if (id != funcionario.Id) //Se o Id diferente!
            {
                return StatusCode(StatusCodes.Status204NoContent, "Id não corresponde");
            }
            try
            {
                this.services.Update(funcionario);
                return StatusCode(StatusCodes.Status200OK, "Funcionario alterado com sucesso!");
            }
            catch(NotFoundException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}