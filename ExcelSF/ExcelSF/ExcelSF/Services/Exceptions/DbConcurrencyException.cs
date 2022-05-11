namespace ExcelSF.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException //Herança
    {
        public DbConcurrencyException(string message) : base(message)
        {
            //Aqui eu estou criando uma exceção personalizada, para ter exceções especificas minhas!!!
        }
    }
}
