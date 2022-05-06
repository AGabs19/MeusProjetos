using VendasApp.DataBase;
using VendasApp.Models;
using Microsoft.EntityFrameworkCore;
using VendasApp.Services.Exceptions;

namespace VendasApp.Services
{
    public class VendedorService
    {
        private readonly VendasAppContext _context;

        public VendedorService(VendasAppContext context)
        {
            _context = context;
        }
        public List<Vendedor> FindAll() //Estou usando a operação para encontrar 
        {
            return _context.Vendedor.ToList(); //Ele vai acessar meus dados da tabela vendedor e vai transforma em lista
        }
        public void Insert(Vendedor obj) //Para Inserir
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Vendedor FindById(int id) //Estou pedindo para localizar pelo Id 
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id); //Usando o metodo FirstOrDefault e lambida (Linq)
            //Include coloquei apos a criaçaõ da opção (model.Departamento.Nome) em Details.cshtml;
            //Eu estou incluindo o Departamento, ele faz join e busca o departamento!
            //É assim que faz eager loading;
            //Eager loading = Carregar outros objetos associados ao objeto principal por isso a inclusão;
        }
        public void Remove(int id) 
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj); //Assim eu removo o obj do BDSet
            _context.SaveChanges(); //Aqui eu salvo essa alteração no meu banco de dados e assim o objeto fica totslmente removido!
        }
        public void Update(Vendedor obj)  //Atualizar um vendedor
        {
            if (!_context.Vendedor.Any(x => x.Id == obj.Id))   //se nãooooo EXISTIR ! Any serve para para vê se existe registro no banco de dados com a condição lambida
            {
                throw new NotFoundException("Id não encontrado");
            }
            try //Se passar pelo if, então solicita a Atualização
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            //Se meu banco de dados der conflito de ambiguidade, a minha exception vai lançar um aviso, pois vai pegar o aviso do banco e transformar em um aviso meu, da minha exception!!!
        }  
          
       
    }
}
