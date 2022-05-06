namespace VendasApp.Models.ViewModels
{
    public class VendedorFormViewModel //Classe para criar a tela de cadastro do Vendedor!
    {
        public Vendedor Vendedor { get; set; } //Precisa de um vendedor nos dados
        public ICollection<Departamento> Departamentos { get; set; } //Lista de departamento para a caixa de escolha que vou criar, assim em novos registros sera possivel escolher o departamento!!!
    }
}
