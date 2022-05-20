using ExcelSF.Models;
using System.ComponentModel.DataAnnotations;

namespace ExcelSF.Models
{
    public class ExcelModel
    {
        public string Status { get; set; }
       
        [Required(ErrorMessage = "{0} obrigatório")] //{0} = Nome + obrigátorio!
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Nome, {1} = Max, {2} = Min
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] //{0} = Sobrenome + obrigátorio!
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Sobrenome, {1} = Max, {2} = Min
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public long CPF { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public long Numero { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Descricao, {1} = Max, {2} = Min
        public string Descricao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string Longadouro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public long NumeroCasa { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public long CEP { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = Complemento, {1} = Max, {2} = Min
        public string Complemento { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")] //Dia/Mês/Ano
        public string Cargo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")] //Dia/Mês/Ano
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(100.00, 50000.00, ErrorMessage = "{0} tem que ser entre {1} e {2}")]
        public Double Salario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")] //Dia/Mês/Ano
        public DateTime DataInicio2 { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")] //Dia/Mês/Ano
        public DateTime DataFim2 { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [StringLength(120, MinimumLength = 10, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1}")] //Colocando limites. {0} = ObservacaoFuncionario, {1} = Max, {2} = Min
        public string ObservacaoFuncionario { get; set; }
    }
}
