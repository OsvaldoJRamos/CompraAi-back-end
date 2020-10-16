using CompraAi.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IItemServico
    {
        Task<Item> Criar(Item item);
        Task<Item> Atualizar(Item item);
        Task Excluir(Item item);
        Task ExcluirVarios(Item[] itens);
        Task<Item> RetornarPeloId(Guid itemId);
        Task ExcluirPeloId(Guid itemId);
        Task<List<Item>> RetornarPorFamiliaId(Guid familiaId);
    }
}
