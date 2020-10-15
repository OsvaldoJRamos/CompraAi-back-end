﻿using CompraAi.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CompraAi.Repositorios
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Convite> Convite { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
