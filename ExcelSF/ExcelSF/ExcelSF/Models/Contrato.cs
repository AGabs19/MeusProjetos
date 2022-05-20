using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Contrato
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public Double Salario { get; set; }
        public virtual Cargo? Cargo { get; set; }

    }
}
