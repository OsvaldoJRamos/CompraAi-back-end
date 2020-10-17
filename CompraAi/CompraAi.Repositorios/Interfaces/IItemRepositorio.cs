using CompraAi.Dominio;
using CompraAi.Repositorios.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraAi.Repositorios.Interfaces
{
    public interface IItemRepositorio : IRepositorioBase<Item, Guid>
    {
        Task<List<Item>> RetornarPorFamiliaId(Guid familiaId);
    }
}
