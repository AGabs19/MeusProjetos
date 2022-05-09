#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasApp.Models;

namespace VendasApp.DataBase
{
    public class VendasAppContext : DbContext
    {
        public VendasAppContext (DbContextOptions<VendasAppContext> options)
            : base(options)
        {
            //Ligação com o banco de dados, program.cs e appsettings.json contém as ligações
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroDeVenda> RegistroDeVenda { get; set; }
    }
}
