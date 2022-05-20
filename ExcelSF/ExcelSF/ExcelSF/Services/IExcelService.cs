using ExcelSF.Models;

namespace ExcelSF.Services
{
    public interface IExcelService
    {
        string Excel(IFormFile Arquivo);
        //string Delete(long id);
        //string Update(Funcionario obj); //Funcionario obj
        //Funcionario FindById(long id);
        //List<Funcionario> FindAll();
    }
}
