namespace VendasApp.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException //Herança
    {
        public DbConcurrencyException(string message) : base(message) //Criando uma exceção personalizada, para ter exceções especificas!!! 
        {
        
        }
    }
}
