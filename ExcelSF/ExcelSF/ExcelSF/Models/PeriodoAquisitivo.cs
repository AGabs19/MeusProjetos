using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class PeriodoAquisitivo
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDaContratacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UltimoPeriodo { get; set; }
    }
}
