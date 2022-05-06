namespace VendasApp.Services.Exceptions
{
    public class NotFoundException : ApplicationException //Esta herdando de ApplicationException
    {
        public NotFoundException(string message) : base(message) //Criando uma exceção personalizada, para ter exceções especificas!!! 
        {

        }
    }
}
