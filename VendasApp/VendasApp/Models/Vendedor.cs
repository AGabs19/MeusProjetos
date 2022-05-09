using System.Linq;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VendasApp.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} obrigatório")] //Campo obrigatorio
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Nome, {1} = Max e {2} = Min
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Por Favor digite um email valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Dia/Mês/Ano
        public DateTime Aniversario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(100.00, 50000.00, ErrorMessage = "{0} tem que ser entre {1} e {2}")] //O salaiio tem que ser entre minimo e maximo
        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")] //Determinando o formato de duas casas decimais!!!
        public double SalarioBase { get; set; }

        public virtual Departamento Departamento { get; set; } //Ligação Vendedor possui 1 Departamento
        public int DepartamentoId {get; set;}
        public ICollection<RegistroDeVenda> Vendas { get; set; } = new List<RegistroDeVenda>(); //Ligação para muitos 

        public Vendedor()
        {

        }
        public Vendedor( int id,string nome,string email, DateTime aniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(RegistroDeVenda rv) //Para adicionar um venda
        {
            Vendas.Add(rv); 
        }

        public void RemoveVendas(RegistroDeVenda rv) //Para remover uma venda 
        {
            Vendas.Remove(rv);
        }
        public double TotalVendas(DateTime inicial, DateTime final) //Calculando o total de vendas de um vendedos, ussando Linq
        {
            return Vendas.Where(rv => rv.Data >= inicial && rv.Data <= final).Sum(rv => rv.Quantia);
            //Retorno do Total de Vendas desse vendedor, nesse periodo de Data Inicial e Final;
            //Chamei a Coleção de Vendas, pois é onde está a ligação do Vendedor com o Registro de Vendas;
            //Filtrei a lista usando Where, pois só quero o retorno apenas das vendas com esse intervalo de data;
            //Peguei todos os objetos rv = Registo de vendas;
            //Apois a filtragem de Inicial e Final eu pedi a soma das vendas usando o SUM;
        }
    }
}
