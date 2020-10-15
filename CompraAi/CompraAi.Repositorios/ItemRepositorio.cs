using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Repositorios
{
    public class ItemRepositorio : RepositorioBase<Item, Guid>, IItemRepositorio
    {
        private readonly Contexto _contexto;

        public ItemRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Item> RetornarPorFamiliaId(Guid familiaId) =>
            (from i in _contexto.Item
             where i.FamiliaId == familiaId
             select i).ToList();
    }
}
