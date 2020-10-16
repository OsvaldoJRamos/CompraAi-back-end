using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using System;

namespace CompraAi.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, Guid>, IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        public UsuarioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
