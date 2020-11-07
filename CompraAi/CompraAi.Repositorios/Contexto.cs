using CompraAi.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompraAi.Repositorios
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioFamilia> UsuarioFamilia { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Convite> Convite { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasQueryFilter(entity => entity.ExcluidoEm == null || entity.ExcluidoEm > DateTime.Now);
        }
    }
}
