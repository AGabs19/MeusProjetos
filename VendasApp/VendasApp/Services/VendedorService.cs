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
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
