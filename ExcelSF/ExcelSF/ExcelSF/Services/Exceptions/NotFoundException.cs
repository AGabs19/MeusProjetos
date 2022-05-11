namespace ExcelSF.Services.Exceptions
{
    public class NotFoundException : ApplicationException //Está herdando!!!
    {
        public NotFoundException(string message) : base(message)
        {
            //Criando uma exception personalizada!!!
        }
    }
}
