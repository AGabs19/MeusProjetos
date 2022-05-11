using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Cargo
    {
        [Key()]
        public long Id { get; set; }
        public String? Tipo { get; set; }
    }
}
