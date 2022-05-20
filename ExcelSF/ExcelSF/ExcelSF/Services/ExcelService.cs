using ExcelSF.Models;
using ExcelSF.Services.Exceptions;
using Ganss.Excel;
using Microsoft.EntityFrameworkCore;
using AppContext = ExcelSF.DataBase.AppContext;
using System.IO;

namespace ExcelSF.Services
{
    public class ExcelService : IExcelService
    {
        private readonly AppContext conexao;

        public ExcelService(AppContext conexao)
        {
            this.conexao = conexao;
        }
        private Stream AbrirExcel(IFormFile arquivo) ///private Stream AbrirExcel
        {
            var stream = arquivo.OpenReadStream(); //Convertendo em Stream

            //Organizei como eu quero que meu arquivo Excel seja lido 
            var planilhaExcel = new ExcelMapper(arquivo.OpenReadStream()).Fetch<ExcelModel>(); //Usando o Excel Mapper

            foreach (var linha in planilhaExcel)
            {

                if(linha.Status == "I" || linha.Status == "i")
                {
                    Inserir(linha);
                }
                if(linha.Status == "A" || linha.Status == "a")
                {
                    Atualizar(linha);
                }
                if (linha.Status == "E" || linha.Status == "e")
                {
                    Excluir(linha);
                }
                try
                {
                    LogResultado();
                    this.conexao.SaveChanges();
                }
                catch (DbConcurrencyException e)
                {
                    throw new DbConcurrencyException(e.Message); //Aprendi isso fazendo exception personalizada;
                    //Se o Banco de Dados der conflito de ambiguidade, um erro, a minha exception personalizada vai pegar o aviso do banco e transforma em um aviso meu, da minha exception!!!
                }
            }
                return stream;
        }

        private string Inserir(ExcelModel linha)
        {
            //Primeiro eu vejo se o registro já conta, se não eu peço para inserir ele!

            Funcionario funcionario = this.conexao.Funcionario.FirstOrDefault(x => x.CPF == linha.CPF);
            if (funcionario == null)
            {
                funcionario = new Funcionario(); //Criando um novo Funcionario

                funcionario.Nome = linha.Nome;  //Aqui eu passo o que quero adicionar referente a minha tabela Excel
                funcionario.Sobrenome = linha.Sobrenome;
                funcionario.CPF = linha.CPF;

                this.conexao.Funcionario.Add(funcionario); //Aqui eu ADD.

            }

            Telefone telefone = this.conexao.Telefone.FirstOrDefault(x => x.Numero == linha.Numero);
            if (telefone == null)
            {
                telefone = new Telefone();

                telefone.Numero = linha.Numero;
                telefone.Descricao = linha.Descricao;

                this.conexao.Telefone.Add(telefone);
            }

            Endereco endereco = this.conexao.Endereco.FirstOrDefault(x => x.NumeroCasa == linha.NumeroCasa);
            if (endereco == null)
            {
                endereco = new Endereco();

                endereco.Longadouro = linha.Longadouro;
                endereco.NumeroCasa = linha.NumeroCasa;
                endereco.CEP = linha.CEP;
                endereco.Complemento = linha.Complemento;

                this.conexao.Endereco.Add(endereco);
            }

            Cargo cargo = this.conexao.Cargo.FirstOrDefault(x => x.Tipo == linha.Cargo);
            if (cargo == null)
            {
                cargo = new Cargo();

                cargo.Tipo = linha.Cargo;

                this.conexao.Cargo.Add(cargo);
            }

            Contrato contrato = this.conexao.Contrato.FirstOrDefault(x => x.Salario == linha.Salario);
            if (contrato == null)
            {
                contrato = new Contrato();

                contrato.DataInicio = linha.DataInicio;
                contrato.Salario = linha.Salario;

              this.conexao.Contrato.Add(contrato);
            }
           
            Ferias ferias = this.conexao.Ferias.FirstOrDefault(x => x.DataInicio2 == linha.DataInicio2);
            if (ferias == null)
            {
                ferias = new Ferias();

                ferias.DataInicio2 = linha.DataInicio2;
                ferias.DataFim2 = linha.DataFim2;

                this.conexao.Ferias.Add(ferias);
            }
           

            Autorizacao autorizacao = this.conexao.Autorizacao.FirstOrDefault(x => x.ObservacaoFuncionario == linha.ObservacaoFuncionario);
            if (autorizacao == null)
            {
                autorizacao = new Autorizacao();

                autorizacao.ObservacaoFuncionario = linha.ObservacaoFuncionario;

                this.conexao.Autorizacao.Add(autorizacao);
            }
            return "Salvo com sucesso!";

        }
        private string Atualizar(ExcelModel linha)
        {
            Funcionario funcionario = this.conexao.Funcionario.FirstOrDefault(x => x.CPF == linha.CPF);

            if(funcionario == null) //Se o funcionario for nulo, eu primeiro vou inserir ele
            {
                Inserir(linha);
            } 
            if(funcionario != null) //Se ele existir quero que faça atualização de seus dados!
            {
                funcionario.Nome = linha.Nome;
                funcionario.Sobrenome = linha.Sobrenome;
                funcionario.CPF = linha.CPF;

                this.conexao.Funcionario.Update(funcionario); //Salvando atualização!
            }

            Telefone telefone = this.conexao.Telefone.FirstOrDefault(x => x.Numero == linha.Numero);
            if (telefone == null)
            {
                Inserir(linha);
            }
            if(telefone != null)
            {
                telefone.Numero = linha.Numero;
                telefone.Descricao = linha.Descricao;

                this.conexao.Telefone.Update(telefone);
            }

            Endereco endereco = this.conexao.Endereco.FirstOrDefault(x => x.NumeroCasa == linha.NumeroCasa);
            if (endereco == null)
            {
                Inserir(linha);
            }
            if(endereco != null)
            {
                endereco.Longadouro = linha.Longadouro;
                endereco.NumeroCasa = linha.NumeroCasa;
                endereco.CEP = linha.CEP;
                endereco.Complemento = linha.Complemento;

                this.conexao.Endereco.Update(endereco);
            }

            Cargo cargo = this.conexao.Cargo.FirstOrDefault(x => x.Tipo == linha.Cargo);
            if (cargo == null)
            {
                Inserir(linha);
            }
            if(cargo != null)
            {
                cargo.Tipo = linha.Cargo;

                this.conexao.Cargo.Update(cargo);
            }

            Contrato contrato = this.conexao.Contrato.FirstOrDefault(x => x.Salario == linha.Salario);
            if (contrato == null)
            {
                Inserir(linha);
            }
            if(contrato != null)
            {
                contrato.DataInicio = linha.DataInicio;
                contrato.Salario = linha.Salario;

                this.conexao.Contrato.Update(contrato);
            }

            Ferias ferias = this.conexao.Ferias.FirstOrDefault(x => x.DataInicio2 == linha.DataInicio2);
            if (ferias == null)
            {
                Inserir(linha);
            }
            if(ferias != null)
            {
                ferias.DataInicio2 = linha.DataInicio2;
                ferias.DataFim2 = linha.DataFim2;

                this.conexao.Ferias.Update(ferias);
            }


            Autorizacao autorizacao = this.conexao.Autorizacao.FirstOrDefault(x => x.ObservacaoFuncionario == linha.ObservacaoFuncionario);
            if (autorizacao == null)
            {
                Inserir(linha);
            }
            if(autorizacao != null)
            {
                autorizacao.ObservacaoFuncionario = linha.ObservacaoFuncionario;

                this.conexao.Autorizacao.Update(autorizacao);
            }
            return "Alterado com sucesso!";
        }

        private string Excluir(ExcelModel linha) //Exclusão logica
        {
            bool hasAny = this.conexao.Funcionario.Any(x => x.CPF == linha.CPF); //Para vê se existe registro no banco
            if (!hasAny) //Se NÃO existir
            {
                return "O funcionario já está desativado!";
            }
            try //Se existir registro, quero que o exclua
            {
                exclusao(linha.CPF);
                return "Funcionarario, desativado com sucesso";
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message); //Aprendi isso fazendo exception personalizada;
                //Se o Banco de Dados der conflito de ambiguidade, um erro, a minha exception personalizada vai pegar o aviso do banco e transforma em um aviso meu, da minha exception!!!
            }
            return "Ok";
        }
        private void exclusao(long CPF) //exclusao logica!
        {
           //Fiz Eager Loading, carregando outros objetos associados, usando Join das tabelas, Include + expressão lambda no FirstOurDefault.

            var funcionario = this.conexao.Funcionario
                .Include(x => x.Endereco)
                .Include(x => x.Telefone)
                .Include(x => x.Contrato)
                .Include(x => x.Ferias)
                .Include(x => x.Ferias.Autorizacao)
                .Include(x => x.Ferias.Historico)
                .Include(x => x.Ferias. PeriodoAquisitivo)
                .FirstOrDefault(x => x.CPF == CPF);


            //Quero que fique inativo os registros do Funcionario soclicitado no Excel!
            funcionario.Enabled = false;

            //Aqui estoou pedindo para fazer uma atualização, assim o Funcionario e seus dados se tornam inativos!
            this.conexao.Funcionario.Update(funcionario);
        }

        private void LogResultado()
        {
            const string filePath = @"C:\Users\anaga\MeusProjetos\ExcelSF\ExcelSF\Log.txt"; //Caminho do arquivo completo

            //File.Create(filePath);

            using var StreamWriter = File.AppendText(filePath);
            StreamWriter.WriteLine("Importando uma tabela Excel");
            StreamWriter.WriteLine($"{Inserir} Arquivos Inseridos com Sucesso!");
            StreamWriter.WriteLine($"{Atualizar} Arquivos Atualizados com Sucesso!");
            StreamWriter.WriteLine($"{Excluir} Arquivos Excluidos com Sucesso!");
            StreamWriter.Close();
        }

        public string Excel(IFormFile arquivo)
        {
            Stream arquivoaberto = AbrirExcel(arquivo);
            if (arquivo == null) //Se o arquivo for nulo
            {
                return "O arquivo não possui dados";
            }
            return "Ok";
        }
    }
}