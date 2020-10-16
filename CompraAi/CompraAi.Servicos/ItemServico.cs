﻿using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class ItemServico : IItemServico
    {
        private readonly IItemRepositorio _itemRepositorio;
        public ItemServico(IItemRepositorio itemRepositorio)
        {
            _itemRepositorio = itemRepositorio;
        }

        public async Task<Item> Atualizar(Item item)
        {
            item.Validar();
            _itemRepositorio.Atualizar(item);
            await _itemRepositorio.SalvarAlteracoesAsync();
            return item;
        }

        public async Task<Item> Criar(Item item)
        {
            item.Validar();
            _itemRepositorio.Criar(item);
            await _itemRepositorio.SalvarAlteracoesAsync();
            return item;
        }

        public async Task Excluir(Item item)
        {
            _itemRepositorio.Excluir(item);
            await _itemRepositorio.SalvarAlteracoesAsync();
        }

        public async Task ExcluirPeloId(Guid itemId)
        {
            _itemRepositorio.ExcluirPeloId(itemId);
            await _itemRepositorio.SalvarAlteracoesAsync();
        }

        public async Task ExcluirVarios(Item[] itens)
        {
            _itemRepositorio.ExcluirVarios(itens);
            await _itemRepositorio.SalvarAlteracoesAsync();
        }

        public async Task<Item> RetornarPeloId(Guid itemId)
        {
            return await Task.Run(() => _itemRepositorio.RetornarPeloId(itemId));
        }

        public async Task<List<Item>> RetornarPorFamiliaId(Guid familiaId)
        {
            return await Task.Run(() => _itemRepositorio.RetornarPorFamiliaId(familiaId));
        }
    }
}
