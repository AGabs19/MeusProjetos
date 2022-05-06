namespace VendasApp.Services.Exceptions
{
    public class NotFoundException : ApplicationException //Estaherando de ApplicationException
    {
        public NotFoundException(string message) : base(message) //Criando uma exceção personalizada, para ter exceções especificas!!! 
        {

        }
    }
}
