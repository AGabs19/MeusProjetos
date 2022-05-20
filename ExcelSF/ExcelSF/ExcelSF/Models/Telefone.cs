using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Telefone
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Descricao, {1} = Max, {2} = Min
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] 
        public long Numero { get; set; }
    }
}
