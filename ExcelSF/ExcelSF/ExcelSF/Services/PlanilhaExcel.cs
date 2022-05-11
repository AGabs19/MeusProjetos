using AppContext = ExcelSF.DataBase.AppContext;
using ExcelSF.Models;
using OfficeOpenXml;
using Ganss.Excel;
using Microsoft.EntityFrameworkCore;
using ExcelSF.Services.Exceptions;

namespace ExcelSF.Services
{
    public class PlanilhaExcel : IPlanilhaExcel
    {
        private readonly AppContext conexao;

        public PlanilhaExcel(AppContext conexao)
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
                Funcionario funcionario = this.conexao.Funcionario.FirstOrDefault(x => x.CPF == linha.CPF);
                if (funcionario == null)
                {
                    funcionario = new Funcionario();

                    funcionario.Nome = linha.Nome;
                    funcionario.Sobrenome = linha.Sobrenome;
                    funcionario.CPF = linha.CPF;

                    this.conexao.Funcionario.Add(funcionario);
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

                this.conexao.SaveChanges();
            }
            return stream;
        }
        public async Task<List<Funcionario>> FindAllAsync() //Usei essa operação para encontrar
        {
            return await conexao.Funcionario.ToListAsync();  //Ele vai acessar meus dados da tabela vendedor e vai transforma em lista
        }
        public async Task InsertAsync(ExcelModel arquivo) //Para Inserir
        {
            conexao.Add(arquivo);
            await conexao.SaveChangesAsync();
        }

        public async Task<Funcionario> FindByIdAsync(int id) //Estou pedindo para localizar pelo Id
        {
            return await conexao.Funcionario.Include(arquivo => arquivo.CPF).FirstOrDefaultAsync(arquivo => arquivo.Id == id); //Usando FirstOrDefault e lambida do linq
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var arquivo = await conexao.Funcionario.FindAsync(id); //Procurando pelo Id
                conexao.Funcionario.Remove(arquivo); //Aqui eu removo o arquivo do BDSet
                await conexao.SaveChangesAsync(); //Eu salvo minha alteração no meu banco de dados e assim o que eu remover fica totalmente removido!
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException("Não foi possivel excluir esse Funcionario!");
            }
        }
        public async Task UpdateAsync(Funcionario arquivo) //Para atualizar um funcionario!
        {
            bool hasAny = await conexao.Funcionario.AnyAsync(x => x.Id == arquivo.Id);
            if(! hasAny) //Se NÃO existir, Any serve para vê se existe registro no banco de dados com a condição lambida!!!
            {
                throw new NotFoundException("Id não encontrado");
            }
            try //Se passar pelo If entao aqui solicito atualização
            {
                conexao.Update(arquivo);
                await conexao.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        //Se meu banco de dados der conflito de ambiguidade, a minha exception vai lançar um aviso, pois vai pegar o aviso do banco e transformar em um aviso meu, da minha exception!!!
   

        //public string SalvarExcel(IFormFile arquivo)
        //{
        //    Stream arquivoaberto = AbrirExcel(arquivo);
        //    if (arquivo == null)
        //    {
        //        return "o arquivo não possui dados";
        //    }
           

        //    return "ok";
        //    ///testa se o arquivo tem dados
        //    ///verifica se os dados estão nos lugares certos
        //    ///faz a leitura dos dados
        //    ///salvar em banco
        //    ///retorna ok para quando não tiver erros

        //}

    }
}