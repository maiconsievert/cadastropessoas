using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MySql.Data.Entity;
using CadastroPessoasDAL.Models;

namespace CadastroPessoasDAL.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CadastrosContext : DbContext
    {
        
        public CadastrosContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pessoas> Pessoas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


    }
}
