using System.Linq;

using System.Collections.Generic;

namespace VendasApp.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }
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
