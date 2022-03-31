using Senior.Revenda.Repository.Entities;
using System.Data;
using System.Data.Entity;

namespace Senior.Revenda.Repository.Contexts
{
    public class RevendaContext : DbContext
    {
        public RevendaContext() : base("RevendaContext")
        {

        }

        public bool IgnoreSaveChangeAndUseTransaction { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }

        public override int SaveChanges()
        {
            if (!IgnoreSaveChangeAndUseTransaction)
                return base.SaveChanges();

            return 0;
        }

        public IDbConnection GetConnection()
        {
            return Database.Connection;
        }
    }
}
