using Microsoft.AspNetCore.Mvc;
using System.Data;
using AppContext = ExcelSF.DataBase.AppContext;
using ExcelSF.Services;
using System.IO;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace ExcelSF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : Controller
    {
        private readonly ILogger<ExcelController> _logger;
        private readonly IPlanilhaExcel services;
        private readonly AppContext conexao;
        //private readonly ExcelModelValidator validation;
        public ExcelController(ILogger<ExcelController> logger, IPlanilhaExcel services, AppContext conexao) //, ExcelModelValidator validation )
        {
            _logger = logger;
            this.services = services;
            this.conexao = conexao;
            //this.validation = validation;
        }

        [HttpPost]
        public ActionResult PegarArquivo(IFormFile arquivo)
        {
            this.services.SalvarExcel(arquivo);
            return StatusCode(StatusCodes.Status200OK, "Executado com sucesso!");
        }

    }
}