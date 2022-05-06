using System.Collections.Generic;
using System.Linq;

namespace VendasApp.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>(); //Ligação de Departamento com Vendedor

        public Departamento()
        {
            //Construtor Default, sem argumentos
        }
        public Departamento(int id, string nome) //Construtor com argumentos, não inclui a Coleção
        {
            Id = id;
            Nome = nome;  
        }

        public void AddVendedores(Vendedor vendedor) //Adicionando vendedor
        {
            Vendedores.Add(vendedor);
        }
        public double TotalVendas(DateTime inicial, DateTime final) //Total de vendas do departamento!!!
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicial, final));
            //Estou dando retorno com a lista de TODOS os vendedores desse departamento;
            //Estou usando linq SUM;
            //vendedor => vendedor significa que to chamando CADA vendedor da minha lista de VENDEDORES do departamento;
            //Após chamar cada vendedor, estou chamando o TOTAL DE VENDAS do vendedor no periodo de tempo inicial e final
            //Apos isso faço uma SOMA (SUM) do resultado de todos os vendedores do Departamento;
            //Fim, pois eu cheo ao total de vendas do departamento!!!
        }

    }
}
