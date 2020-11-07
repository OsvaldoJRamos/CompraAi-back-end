using CompraAi.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CompraAi.Repositorios
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Usuario>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
            builder.Entity<UsuarioFamilia>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
            builder.Entity<Familia>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
            builder.Entity<Convite>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
            builder.Entity<Item>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
            builder.Entity<Status>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
        }

        public override int SaveChanges()
        {
            AtualizarStatusExclusaoLogica();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AtualizarStatusExclusaoLogica();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AtualizarStatusExclusaoLogica();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AtualizarStatusExclusaoLogica()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["ExcluidoEm"] = null;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["ExcluidoEm"] = DateTime.Now;
                        break;
                }
            }
        }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioFamilia> UsuarioFamilia { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Convite> Convite { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
