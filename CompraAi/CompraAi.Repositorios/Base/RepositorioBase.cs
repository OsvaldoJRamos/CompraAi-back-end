using CompraAi.Repositorios.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Repositorios.Base
{
    public class RepositorioBase<TEntity, TId> : IRepositorioBase<TEntity, TId> where TEntity : class
    {

        private readonly Contexto _contexto;
        private DbSet<TEntity> _dataset;

        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
            _dataset = _contexto.Set<TEntity>();
        }

        public async Task<TEntity> Atualizar(TEntity entity) =>
            await Task.Run(() => _dataset.Update(entity).Entity);

        public async Task<TEntity> Criar(TEntity entity) =>
            await Task.Run(() => _dataset.Add(entity).Entity);

        public async Task Excluir(TEntity entity) =>
            await Task.Run(() => _dataset.Remove(entity));

        public async Task ExcluirPeloId(TId id)
        {
            var entity = await RetornarPeloId(id);
            await Excluir(entity);
        }

        public async Task ExcluirVarios(TEntity[] entityArray) =>
           await Task.Run(() => _dataset.RemoveRange(entityArray));

        public async Task<TEntity> RetornarPeloId(TId id) =>
            await _dataset.FindAsync(id);

        public async Task<bool> SalvarAlteracoesAsync() =>
            await _contexto.SaveChangesAsync() > 0;

    }
}
