using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Ferias
    {
        [Key()]
        public long Id { get; set; }
        public virtual Autorizacao? Autorizacao { get; set; }
        //public virtual DateTime AutorizacaoId { get; set; }
        public bool AdiantamentoDecimoTerceiro { get; set; }
        public virtual Historico? Historico { get; set; }
        //public virtual DateTime HistoricoId { get; set; }
        public DateTime DataInicio2 { get; set; }
        public DateTime DataFim2 { get; set; }
        public bool AutorizacaoGerente1 { get; set; }
        public bool AutorizacaoGerente2 { get; set; }
        public virtual PeriodoAquisitivo? PeriodoAquisitivo { get; set; }
        //public virtual DateTime PeriodoAquisitivoId { get; set; }
    }
}
