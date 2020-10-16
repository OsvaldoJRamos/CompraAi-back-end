using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using System;

namespace CompraAi.Repositorios
{
    public class ConviteRepositorio : RepositorioBase<Convite, Guid>, IConviteRepositorio
    {
        private readonly Contexto _contexto;

        public ConviteRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
