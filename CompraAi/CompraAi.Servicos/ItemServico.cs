using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base;
using CompraAi.Servicos.Exceptions;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class ItemServico : ServicoBase<Item, Guid, IItemRepositorio>, IItemServico
    {
        public ItemServico(IItemRepositorio repositorio) : base(repositorio)
        {
        }

        public async Task<List<Item>> RetornarPorFamiliaId(Guid familiaId) =>
            await _repositorio.RetornarPorFamiliaId(familiaId);

        public async Task AnexarImagem(Guid itemId, byte[] imagem)
        {
            Item item = await RetornarPeloId(itemId);

            if (item == null)
                new ServicoException($"Não foi possível anexar a imagem, pois não foi encontrado um item de id '{itemId}'");

            item.ImagemProduto = imagem;

            await Atualizar(item);

            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task<byte[]> RetornarImagem(Guid itemId)
        {
            Item item = await RetornarPeloId(itemId);

            if (item == null)
                return null;

            return item.ImagemProduto;
        }
    }
}
