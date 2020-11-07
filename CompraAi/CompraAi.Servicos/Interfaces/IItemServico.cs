using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IItemServico : IServicoBase<Item, Guid, IItemRepositorio>
    {
        Task<List<Item>> RetornarPorFamiliaId(Guid familiaId);
        Task AnexarImagem(Guid itemId, byte[] imagem);
        Task<byte[]> RetornarImagem(Guid itemId);
    }
}
