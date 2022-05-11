using ExcelSF.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelSF.DataBase
{

    public partial class AppContext : DbContext //Ele vai encapsular
    {
        public AppContext()
        {

        }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            //Conexão com meu Banco de Dados, ligada ao meu Program.cs e appsettings.json
        }

        public DbSet<Autorizacao> Autorizacao { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Ferias> Ferias { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<PeriodoAquisitivo> PeriodoAquisitivo { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autorizacao>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cargo>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contrato>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Endereco>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ferias>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Funcionario>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Historico>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<PeriodoAquisitivo>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            modelBuilder.Entity<Telefone>()
           .Property(x => x.Id)
           .ValueGeneratedOnAdd();

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}