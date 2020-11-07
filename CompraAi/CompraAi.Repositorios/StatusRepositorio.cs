using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraAi.Repositorios
{
    public class StatusRepositorio : RepositorioBase<Status, Guid>, IStatusRepositorio
    {
        private readonly Contexto _contexto;
        public StatusRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
