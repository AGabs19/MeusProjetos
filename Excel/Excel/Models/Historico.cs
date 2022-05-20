using System.ComponentModel.DataAnnotations;

namespace Excel.Models
{
    public class Historico
    {
        [Key()]
        public long Id { get; set; }
        public long QuantidadeDeDias { get; set; }
        public bool Venda { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Alterei o formato da Data
        public DateTime UltimoPeriodo { get; set; }
    }
}
