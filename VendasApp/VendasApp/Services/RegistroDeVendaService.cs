using Microsoft.EntityFrameworkCore;
using VendasApp.DataBase;
using VendasApp.Models;

namespace VendasApp.Services
{
    public class RegistroDeVendaService
    {
        private readonly VendasAppContext _context;
        public RegistroDeVendaService(VendasAppContext context)
        {
            _context = context;
        }
        public async Task<List<RegistroDeVenda>> FindByDateAsync(DateTime? minData, DateTime? maxData) //Para retorna uma lista de Resgitro de Vendas, recebendo Data minima e Maxima!
        { //Logica para encontrar as vendas com esse tempo determinado:

            var result = from obj in _context.RegistroDeVenda select obj;
            if (minData.HasValue) //Se for informado uma data MIN
            {
                result = result.Where(x => x.Data >= minData.Value); //Maior ou igual
            }
            if (minData.HasValue) //Se for infomado uma data MAX
            {
                result = result.Where(x => x.Data <= maxData.Value); // Menor ou igual
            }
            return await result //Vou fazer um Join e depois ordenar
                .Include(x => x.Vendedor) //Incluindo vendedor
                .Include(x => x.Vendedor.Departamento) //Incluindo Vendedor e Departamento
                .OrderByDescending(x => x.Data) //Usando Linq e ordenando por data
                .ToListAsync(); //Por fim retornando a Lista!
             

        }
    }
}
