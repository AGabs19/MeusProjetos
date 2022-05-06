namespace VendasApp.Models.ViewModels;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public string Message { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); //Vai retorna se não é nulo ou vazio

}
