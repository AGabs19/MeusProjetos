using System.ComponentModel.DataAnnotations;

namespace Excel.Models
{
    public class Funcionario
    {
		[Key()]
		public long Id { get; set; }
		public string? Nome { get; set; }
		public string? Sobrenome { get; set; }
		public long CPF { get; set; }
		ICollection<Telefone> Telefones { get; set; } //Um funcionario pode ter varios telefones, ligação de muitos para muitos!
		public virtual Endereco? Endereco { get; set; } //Um funcionario pode ter um endereço
	}
}
