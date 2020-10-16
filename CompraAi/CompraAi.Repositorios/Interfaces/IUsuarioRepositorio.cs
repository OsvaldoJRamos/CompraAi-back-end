using CompraAi.Dominio;
using CompraAi.Repositorios.Base.Interfaces;
using System;

namespace CompraAi.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario, Guid>
    {
    }
}
