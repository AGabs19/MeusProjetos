using VendasApp.DataBase;
using VendasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasApp.Services
{
    public class DepartamentoService
    {
        private readonly VendasAppContext _context;

        public DepartamentoService(VendasAppContext context)
        {
            _context = context;
        }
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(X => X.Nome).ToListAsync();
        }
        /*
        Abaixo é uma operação sincrona, agora vou alterar para assincrona
        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList(); //Usando Linq o OrderBy para retorna organizado, em ordem de Nome!
            //Sim, poderia usar sem o OrderBy porem ele facilita
        } */
    }
}
