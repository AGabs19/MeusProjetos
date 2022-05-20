using Excel.Models;
using Ganss.Excel;
using Microsoft.EntityFrameworkCore;

namespace Excel.DataBase
{
    public class PopularDB
    {
            private readonly ExcelContext _conexao;

            public PopularDB(ExcelContext conexao)
            {
                _conexao = conexao;
            }
            private Stream AbrirExcel(IFormFile arquivo) ///private Stream AbrirExcel
            {
                var stream = arquivo.OpenReadStream(); //Convertendo em Stream

                //Organizei como eu quero que meu arquivo Excel seja lido 
                var planilhaExcel = new ExcelMapper(arquivo.OpenReadStream()).Fetch<PopularDB>(); //Usando o Excel Mapper

                foreach (var linha in planilhaExcel)
                {
                    Funcionario funcionario = _conexao.Funcionario.FirstOrDefault(x => x.CPF == linha.CPF);
                    if (funcionario == null)
                    {
                        funcionario = new Funcionario();

                        funcionario.Nome = linha.Nome;
                        funcionario.Sobrenome = linha.Sobrenome;
                        funcionario.CPF = linha.CPF;

                        _conexao.Funcionario.Add(funcionario);
                    }

                    Telefone telefone = _conexao.Telefone.FirstOrDefault(x => x.Numero == linha.Numero);
                    if (telefone == null)
                    {
                        telefone = new Telefone();

                        telefone.Numero = linha.Numero;
                        telefone.Descricao = linha.Descricao;

                        _conexao.Telefone.Add(telefone);
                    }

                    Endereco endereco = _conexao.Endereco.FirstOrDefault(x => x.NumeroCasa == linha.NumeroCasa);
                    if (endereco == null)
                    {
                        endereco = new Endereco();

                        endereco.Longadouro = linha.Longadouro;
                        endereco.NumeroCasa = linha.NumeroCasa;
                        endereco.CEP = linha.CEP;
                        endereco.Complemento = linha.Complemento;

                        _conexao.Endereco.Add(endereco);
                    }

                    Cargo cargo = _conexao.Cargo.FirstOrDefault(x => x.Tipo == linha.Cargo);
                    if (cargo == null)
                    {
                        cargo = new Cargo();

                        cargo.Tipo = linha.Cargo;

                        _conexao.Cargo.Add(cargo);

                    }

                    Contrato contrato = _conexao.Contrato.FirstOrDefault(x => x.Salario == linha.Salario);
                    if (contrato == null)
                    {
                        contrato = new Contrato();

                        contrato.DataInicio = linha.DataInicio;
                        contrato.Salario = linha.Salario;

                        _conexao.Contrato.Add(contrato);
                    }

                    Ferias ferias = _conexao.Ferias.FirstOrDefault(x => x.DataInicio2 == linha.DataInicio2);
                    if (ferias == null)
                    {
                        ferias = new Ferias();

                        ferias.DataInicio2 = linha.DataInicio2;
                        ferias.DataFim2 = linha.DataFim2;

                        _conexao.Ferias.Add(ferias);
                    }

                    Autorizacao autorizacao = _conexao.Autorizacao.FirstOrDefault(x => x.ObservacaoFuncionario == linha.ObservacaoFuncionario);
                    if (autorizacao == null)
                    {
                        autorizacao = new Autorizacao();

                        autorizacao.ObservacaoFuncionario = linha.ObservacaoFuncionario;

                        _conexao.Autorizacao.Add(autorizacao);
                    }

                    _conexao.SaveChanges();
                }
                return stream;
            }
            public string SalvarExcel(IFormFile arquivo)
            {
                Stream arquivoaberto = AbrirExcel(arquivo);
                if (arquivo == null)
                {
                    return "o arquivo não possui dados";
                }
                ///fazendo validação!

                return "ok";
                ///testa se o arquivo tem dados
                ///verifica se os dados estão nos lugares certos
                ///faz a leitura dos dados
                ///salvar em banco
                ///retorna ok para quando não tiver erros
            }
      
    }
}