using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Autorizacao
    {
        public bool Enabled { get; set; } = true;

        [Key()]
        public long Id { get; set; }
        public string? ObservacaoFuncionario { get; set; }
        public long IdGerente1 { get; set; }
        public string? ObservacaoGerente1 { get; set; }
        public bool StatusGerente1 { get; set; }
        public long IdGerente2 { get; set; }
        public string? ObservacaoGerente2 { get; set; }
        public bool StatusGerente2 { get; set; }
    }
}
