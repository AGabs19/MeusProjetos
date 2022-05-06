using VendasApp.DataBase;
using VendasApp.Models;

namespace VendasApp.Services
{
    public class DepartamentoService
    {
        private readonly VendasAppContext _context;

        public DepartamentoService(VendasAppContext context)
        {
            _context = context;
        }
        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList(); //Usando Linq o OrderBy para retorna organizado, em ordem de Nome!
            //Sim, poderia usar sem o OrderBy porem ele facilita
        }
    }
}
