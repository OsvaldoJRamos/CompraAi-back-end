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

        public TEntity Atualizar(TEntity entity) =>
            _dataset.Update(entity).Entity;

        public TEntity Criar(TEntity entity) =>
            _dataset.Add(entity).Entity;

        public void Excluir(TEntity entity) =>
            _dataset.Remove(entity);

        public void ExcluirPeloId(TId id)
        {
            var entity = RetornarPeloId(id);
            Excluir(entity);
        }

        public void ExcluirVarios(TEntity[] entityArray) =>
            _dataset.RemoveRange(entityArray);

        public TEntity RetornarPeloId(TId id) =>
            _dataset.Find(id);

        public async Task<bool> SalvarAlteracoesAsync() =>
            await _contexto.SaveChangesAsync() > 0;

    }
}
