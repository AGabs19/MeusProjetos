using VendasApp.Models;
using VendasApp.Models.Enums;

namespace VendasApp.DataBase
{
    public class PopularService
    {
        private VendasAppContext _context;

        public PopularService()
        {

        }

        public PopularService( VendasAppContext context)
        {
            _context = context;
        }
        public void Popular() //Vai preencher a base de dados!
        {
            if (_context.Departamento.Any() || //Se já existe dados no meu banco de dados não faça nada
                _context.Vendedor.Any() || //Operação Any para vê se contem elementos
                _context.RegistroDeVenda.Any())
            {
                return; //Se já existir, dados não precisa fazer nada!
            }

            //Vou instanciar os objetos e salvar no banco de dados!
            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Roupas");
            Departamento d4 = new Departamento(4, "Livros");
            //Departamento d5 = new Departamento { Id = 5, Nome = "Ana" } Pode fazer dessa maneira tambem!

            Vendedor v1 = new Vendedor(1, "Ana Alves", "Ana1913@gmail.com", new DateTime(2000, 8, 27), 800.00, d1);
            Vendedor v2 = new Vendedor(2, "Irelia Blue", "MariBlue@gmail.com", new DateTime(1998, 5, 19), 1000.00, d4);
            Vendedor v3 = new Vendedor(3, "Akali Green", "Greenkali@gmail.com", new DateTime(2000, 8, 25), 800.00, d1);
            Vendedor v4 = new Vendedor(4, "Neeko Red", "Neekorainha@gmail.com", new DateTime(2002, 12, 25), 1400.00, d3);
            Vendedor v5 = new Vendedor(5, "Orianna Yellow", "Abelinha@gmail.com", new DateTime(1999, 9, 9), 1200.00, d2);
            Vendedor v6 = new Vendedor(6, "Fiora Black ", "Blacksky@gmail.com", new DateTime(1998, 11, 18), 1200.00, d2);
            //No final eu declaro o departamento de cada vendedor!

            RegistroDeVenda r1 = new RegistroDeVenda(1, new DateTime(2022, 05, 1), 3000.00, VendasStatus.Faturado, v1);
            RegistroDeVenda r2 = new RegistroDeVenda(2, new DateTime(2022, 05, 1), 2000.00, VendasStatus.Faturado, v3);
            RegistroDeVenda r3 = new RegistroDeVenda(3, new DateTime(2022, 05, 1), 1000.00, VendasStatus.Faturado, v4);
            RegistroDeVenda r4 = new RegistroDeVenda(4, new DateTime(2022, 05, 2), 800.00, VendasStatus.Faturado, v6);
            RegistroDeVenda r5 = new RegistroDeVenda(5, new DateTime(2022, 05, 2), 300.00, VendasStatus.Faturado, v5);
            RegistroDeVenda r6 = new RegistroDeVenda(6, new DateTime(2022, 05, 2), 100.00, VendasStatus.Faturado, v1);
            RegistroDeVenda r7 = new RegistroDeVenda(7, new DateTime(2022, 05, 2), 4000.00, VendasStatus.Cancelado, v3);
            RegistroDeVenda r8 = new RegistroDeVenda(8, new DateTime(2022, 05, 3), 320.00, VendasStatus.Faturado, v2);
            RegistroDeVenda r9 = new RegistroDeVenda(9, new DateTime(2022, 05, 3), 440.00, VendasStatus.Pendente, v4);
            RegistroDeVenda r10 = new RegistroDeVenda(10, new DateTime(2022, 05, 3), 6700.00, VendasStatus.Faturado, v6);
            RegistroDeVenda r11 = new RegistroDeVenda(11, new DateTime(2022, 05, 3), 490.00, VendasStatus.Faturado, v1);
            RegistroDeVenda r12 = new RegistroDeVenda(12, new DateTime(2022, 05, 4), 650.00, VendasStatus.Cancelado, v5);
            RegistroDeVenda r13 = new RegistroDeVenda(13, new DateTime(2022, 05, 4), 1120.00, VendasStatus.Pendente, v2);
            RegistroDeVenda r14 = new RegistroDeVenda(14, new DateTime(2022, 05, 05), 330.00, VendasStatus.Faturado, v3);
            RegistroDeVenda r15 = new RegistroDeVenda(15, new DateTime(2022, 05, 05), 600.00, VendasStatus.Faturado, v2);
            RegistroDeVenda r16 = new RegistroDeVenda(16, new DateTime(2022, 05, 05), 400.00, VendasStatus.Faturado, v2);
            RegistroDeVenda r17 = new RegistroDeVenda(17, new DateTime(2022, 05, 06), 5000.00, VendasStatus.Faturado, v3);
            RegistroDeVenda r18 = new RegistroDeVenda(18, new DateTime(2022, 05, 06), 850.00, VendasStatus.Pendente, v6);
            RegistroDeVenda r19 = new RegistroDeVenda(19, new DateTime(2022, 05, 06), 420.00, VendasStatus.Pendente, v4);
            //No fim eu declaro cada vendedor!

            //Agora vou adicionar no banco de dados usando EntityFramework!
            _context.Departamento.AddRange(d1, d2, d3, d4); //Metodo AddRange me permite adicionar varios objetos de uma vez!

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

            _context.RegistroDeVenda.AddRange(r1, r2, r3, r4, r5, r6,r7, r8, r9, r10, r11,r12, r13, r14, r15, r16, r17, r18, r19);

            _context.SaveChanges(); //Ele vai salvar e confirma as alterações no banco de dados!

        }
    }
}
