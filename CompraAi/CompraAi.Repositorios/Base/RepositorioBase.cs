using CompraAi.Repositorios.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Repositorios.Base
{
    public class RepositorioBase<TEntity, TId> : IRepositorioBase<TEntity, TId> where TEntity : class
    {

        protected readonly Contexto _contexto;
        protected DbSet<TEntity> _dataset;

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

        public async Task<List<TEntity>> RetornarTodos()=> 
           await _dataset.ToListAsync();


        public async Task<List<TEntity>> RetornarTodos(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _dataset.Where(i => true);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.ToListAsync();
        }

        /// <summary>
        /// Pesquisar por Predicates.
        /// http://appetere.com/post/passing-include-statements-into-a-repository
        /// </summary>
        /// <param name="predicate">O predicate.</param>
        /// <param name="includes">Os includes.</param>
        /// <returns></returns>
        public async Task<TEntity> PesquisarPor(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _dataset.Where(predicate);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.FirstOrDefaultAsync();
        }


        public async Task<bool> SalvarAlteracoesAsync() =>
            await _contexto.SaveChangesAsync() > 0;

    }
}
