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

        }

        public DbSet<Departamento> Departamento { get; set; }
    }
}
