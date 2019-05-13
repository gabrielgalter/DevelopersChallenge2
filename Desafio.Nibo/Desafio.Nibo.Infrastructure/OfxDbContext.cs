using Desafio.Nibo.Domain;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Nibo.Infrastructure
{
    public class OfxDbContext : DbContext
    {
        public OfxDbContext()
        {
            Database.SetInitializer<OfxDbContext>(null);
        }

        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<OfxDbContext>(modelBuilder));
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
