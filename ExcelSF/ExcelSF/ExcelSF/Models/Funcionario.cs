using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Funcionario
    {
		[Key()]
		public long Id { get; set; }
		public string? Nome { get; set; }
		public string? Sobrenome { get; set; }
		public long CPF { get; set; }
		public virtual Telefone? Telefone { get; set; }
		//public long TelefoneId { get; set; }
		public virtual Endereco? Endereco { get; set; }
		//public long EnderecoId { get; set; }
	}
}
