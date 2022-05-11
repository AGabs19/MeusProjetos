using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class Contrato
    {
        [Key()]
        public long Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Double Salario { get; set; }
        public virtual Cargo? Cargo { get; set; }
        //public long CargoId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
        //public long FuncionarioId { get; set; }
    }
}
