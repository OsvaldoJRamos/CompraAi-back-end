using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Repositorios
{
    public class FamiliaRepositorio : RepositorioBase<Familia, Guid>, IFamiliaRepositorio
    {
        private readonly Contexto _contexto;

        public FamiliaRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
