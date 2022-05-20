using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Endereco
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string? Longadouro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public long? NumeroCasa { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public long? CEP { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Complemento, {1} = Max, {2} = Min
        public string? Complemento { get; set; }
    }
}
