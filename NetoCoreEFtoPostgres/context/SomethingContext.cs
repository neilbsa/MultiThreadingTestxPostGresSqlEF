

using Microsoft.EntityFrameworkCore;
using NetoCoreEFtoPostgres.Entities;

namespace NetoCoreEFtoPostgres.context
{
    class SomethingContext: DbContext
    {
        public DbSet<SomethingModel> Somethings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql("Host=host.docker.internal;Database=TestDatabase;Username=admin;Password=j04AD1140");
    }
}
