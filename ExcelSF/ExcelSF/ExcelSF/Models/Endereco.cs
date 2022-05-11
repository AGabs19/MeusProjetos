using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Endereco
    {
        [Key()]
        public long Id { get; set; }
        public string? Longadouro { get; set; }
        public long NumeroCasa { get; set; }
        public long CEP { get; set; }
        public string? Complemento { get; set; }
    }
}
