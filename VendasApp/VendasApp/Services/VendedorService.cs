using VendasApp.DataBase;
using VendasApp.Models;

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
            return _context.Vendedor.FirstOrDefault(obj => obj.Id == id); //Usando o metodo FirstOrDefault e lambida (Linq)
        }
        public void Remove(int id) 
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj); //Assim eu removo o obj do BDSet
            _context.SaveChanges(); //Aqui eu salvo essa alteração no meu banco de dados e assim o objeto fica totslmente removido!
        }
    }
}
