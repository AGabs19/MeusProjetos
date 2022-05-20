using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Historico
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }
        public long QuantidadeDeDias { get; set; }
        public bool Venda { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Alterei o formato da Data
        public DateTime UltimoPeriodo { get; set; }
    }
}
