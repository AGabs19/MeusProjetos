using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class PeriodoAquisitivo
    {
        [Key()]
        public long Id { get; set; }
        public DateTime DataDaContratacao { get; set; }
        public DateTime UltimoPeriodo { get; set; }
    }
}
