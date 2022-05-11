namespace ExcelSF.Services.Exceptions
{
    public class IntegrityException : ApplicationException //Ele está herdando!
    {
        public IntegrityException(string message) : base(message)
        {
            //Criando uma exception personalizada!
        }
    }
}
