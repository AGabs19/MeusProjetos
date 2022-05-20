using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Funcionario
    {

		[Key()]
		public long Id { get; set; }

		public bool Enabled { get; set; } = true;

		[Required(ErrorMessage = "{0} obrigatório")] //{0} = Nome + obrigátorio!
		[StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Nome, {1} = Max, {2} = Min
        public string? Nome { get; set; }

		[Required(ErrorMessage = "{0} obrigatório")] //{0} = Sobrenome + obrigátorio!
		[StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Sobrenome, {1} = Max, {2} = Min
		public string? Sobrenome { get; set; }

		[Required(ErrorMessage = "{0} obrigatório")]
		public long CPF { get; set; }
		//ICollection<Telefone> Telefone { get; set; } = new List<Telefone>(); //Um funcionario pode ter varios telefones, ligação de muitos para muitos!
		public virtual Telefone? Telefone { get; set; }
		public virtual Ferias? Ferias { get; set; }
		public virtual Contrato? Contrato { get; set; }
		public virtual Endereco? Endereco { get; set; } //Um funcionario pode ter um endereço
	}
}
