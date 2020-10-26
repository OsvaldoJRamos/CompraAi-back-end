using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraAi.Repositorios
{
    public class UsuarioFamiliaRepositorio : RepositorioBase<UsuarioFamilia, Guid>, IUsuarioFamiliaRepositorio
    {
        private readonly Contexto _contexto;

        public UsuarioFamiliaRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
