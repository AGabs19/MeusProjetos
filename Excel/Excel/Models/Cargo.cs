using System.ComponentModel.DataAnnotations;

namespace Excel.Models
{
    public class Cargo
    {
        [Key()]
        public long Id { get; set; }
        public String? Tipo { get; set; }
    }
}
