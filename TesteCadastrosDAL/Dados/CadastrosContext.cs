using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TesteCadastrosDAL.Dados
{
    public class CadastrosContext : DbContext
    {
        public CadastrosContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CadastrosContext>(new CreateDatabaseIfNotExists<CadastrosContext>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cadastros> Cadastros { get; set; }
        public DbSet<Config> Config { get; set; }

        public System.Data.Entity.DbSet<TesteCadastrosDAL.Dados.CadastrosTelefones> CadastrosTelefones { get; set; }
    }
}
