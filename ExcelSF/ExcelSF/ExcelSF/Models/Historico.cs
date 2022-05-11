using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Historico
    {
        [Key()]
        public long Id { get; set; }
        public long QuantidadeDeDias { get; set; }
        public bool Venda { get; set; }
        public DateTime UltimoPeriodo { get; set; }
    }
}
