using System.ComponentModel.DataAnnotations;

namespace Excel.Models
{
    public class Telefone
    {
        [Key()]
        public long Id { get; set; }
        public string? Descricao { get; set; }
        public long Numero { get; set; }
    }
}
