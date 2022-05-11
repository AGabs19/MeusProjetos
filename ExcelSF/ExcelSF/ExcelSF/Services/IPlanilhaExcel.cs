namespace ExcelSF.Services
{
    public interface IPlanilhaExcel
    {
        string InsertAsync(IFormFile Arquivo);
        string DeleteAsync(IFormFile Arquivo);
        string UpdateAsync(IFormFile Arquivo);
    }
}
