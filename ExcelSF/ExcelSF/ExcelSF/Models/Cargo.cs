using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Cargo
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }
        public String? Tipo { get; set; }
    }
}
