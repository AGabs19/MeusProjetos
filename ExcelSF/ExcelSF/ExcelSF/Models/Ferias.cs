using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Ferias
    {
        [Key()]
        public long Id { get; set; }
        public virtual Autorizacao? Autorizacao { get; set; } //Ligação um para um
        public bool AdiantamentoDecimoTerceiro { get; set; }
        public virtual Historico? Historico { get; set; } //Ligação um para um

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Alterei o formato da Data
        public DateTime DataInicio2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Alterei o formato da Data
        public DateTime DataFim2 { get; set; }
        public bool AutorizacaoGerente1 { get; set; }
        public bool AutorizacaoGerente2 { get; set; }
        public virtual PeriodoAquisitivo? PeriodoAquisitivo { get; set; } //Ligação um para um
    }
}
